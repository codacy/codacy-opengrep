package tool

import (
	"bytes"
	"encoding/json"
	"errors"
	"fmt"
	"io"
	"os"
	"os/exec"
	"strings"

	codacy "github.com/codacy/codacy-engine-golang-seed/v6"
	"github.com/codacy/codacy-opengrep/internal/docgen"
	"github.com/samber/lo"
)

type SemgrepOutput struct {
	Results []SemgrepResult `json:"results"`
	Errors  []SemgrepError  `json:"errors"`
}

type SemgrepResult struct {
	CheckID       string          `json:"check_id"`
	Path          string          `json:"path"`
	StartLocation SemgrepLocation `json:"start"`
	EndLocation   SemgrepLocation `json:"end"`
	Extra         SemgrepExtra    `json:"extra"`
}

type SemgrepLocation struct {
	Line int `json:"line"`
}

type SemgrepExtra struct {
	IsIgnored   bool   `json:"is_ignored"`
	Message     string `json:"message"`
	RenderedFix string `json:"rendered_fix,omitempty"`
}

type SemgrepError struct {
	Message  string               `json:"message"`
	Location SemgrepErrorLocation `json:"location"`
}

type SemgrepErrorLocation struct {
	Path string `json:"path"`
}

func executeCommandForFiles(configurationFile *os.File, toolExecution codacy.ToolExecution, patternDescriptions *[]codacy.PatternDescription, language string, files []string) ([]codacy.Result, error) {
	semgrepCmd := createCommand(configurationFile, toolExecution.SourceDir, language, files)

	output, semgrepError, err := runAndParseCommand(semgrepCmd, patternDescriptions)
	if err != nil {
		return nil, errors.New("Error running semgrep: " + semgrepError + "\n" + err.Error())
	}
	return output, nil
}

func createCommand(configurationFile *os.File, sourceDir, language string, files []string) *exec.Cmd {
	params := createCommandParameters(language, configurationFile, files)
	cmd := exec.Command("/usr/local/bin/opengrep", params...)
	cmd.Dir = sourceDir

	return cmd
}

func createCommandParameters(language string, configurationFile *os.File, filesToAnalyse []string) []string {

	// Reset file pointer to the beginning for later use
	if _, err := configurationFile.Seek(0, io.SeekStart); err != nil {
		fmt.Printf("Error resetting config file pointer: %v\n", err)
	}
	cmdParams := []string{
		"scan",
		"--json", //"-json_nodots",
		"--config", configurationFile.Name(),
		//"-l", language,
		"--timeout", "10",
		"--timeout-threshold", "5",
		"--max-target-bytes", "0",
		"--taint-intrafile",
		//"--error-recovery",
		"--max-memory", "5000",
		//"-j", strconv.Itoa(runtime.NumCPU()),
		//"-fast",
		// adding pro features
		//"--historical-secrets",
		//"-deep_inter_file",
		//"--deep-intra-file",
		//"--secrets",
		//"--pro",
	}
	// adding files to analyse
	cmdParams = append(
		cmdParams,
		filesToAnalyse...,
	)
	return cmdParams
}

func runAndParseCommand(cmd *exec.Cmd, patternDescriptions *[]codacy.PatternDescription) ([]codacy.Result, string, error) {
	stdoutPipe, err := cmd.StdoutPipe()
	if err != nil {
		return nil, "", err
	}

	stderrPipe, err := cmd.StderrPipe()
	if err != nil {
		return nil, "", err
	}

	stderrTail := &limitedBuffer{max: maxStderrBytes}
	stderrDone := make(chan error, 1)
	go func() {
		_, copyErr := io.Copy(stderrTail, stderrPipe)
		stderrDone <- copyErr
	}()

	if err := cmd.Start(); err != nil {
		return nil, "", err
	}

	results, parseErr := parseCommandOutput(patternDescriptions, stdoutPipe)
	if parseErr != nil && cmd.Process != nil {
		_ = cmd.Process.Kill()
	}

	waitErr := cmd.Wait()
	stderrCopyErr := <-stderrDone
	if stderrCopyErr != nil && !isBenignStreamClose(stderrCopyErr) {
		return nil, stderrTail.String(), stderrCopyErr
	}
	if parseErr != nil {
		return nil, stderrTail.String(), parseErr
	}
	if waitErr != nil {
		return nil, stderrTail.String(), waitErr
	}

	return results, "", nil
}

func parseCommandOutput(patternDescriptions *[]codacy.PatternDescription, stream io.Reader) ([]codacy.Result, error) {
	var result []codacy.Result

	// Create a JSON decoder
	decoder := json.NewDecoder(stream)
	// Read and process the JSON stream
	for {
		var semgrepOutput SemgrepOutput // or a struct that matches your JSON structure
		if err := decoder.Decode(&semgrepOutput); err != nil {
			if isBenignStreamClose(err) {
				break // End of input
			}
			return nil, err
		}

		// Process the data
		result = appendIssueToResult(result, patternDescriptions, semgrepOutput)
		result = appendErrorToResult(result, semgrepOutput)
	}

	return result, nil
}

const maxStderrBytes = 64 * 1024

type limitedBuffer struct {
	buf bytes.Buffer
	max int
}

func (l *limitedBuffer) Write(p []byte) (int, error) {
	if l.max <= 0 {
		return len(p), nil
	}
	if len(p) >= l.max {
		l.buf.Reset()
		_, _ = l.buf.Write(p[len(p)-l.max:])
		return len(p), nil
	}
	if l.buf.Len()+len(p) > l.max {
		drop := l.buf.Len() + len(p) - l.max
		current := l.buf.Bytes()
		l.buf.Reset()
		_, _ = l.buf.Write(current[drop:])
	}
	_, _ = l.buf.Write(p)
	return len(p), nil
}

func (l *limitedBuffer) String() string {
	return l.buf.String()
}

func isBenignStreamClose(err error) bool {
	return errors.Is(err, io.EOF) || errors.Is(err, os.ErrClosed) || strings.Contains(err.Error(), "file already closed")
}

func appendIssueToResult(result []codacy.Result, patternDescriptions *[]codacy.PatternDescription, semgrepOutput SemgrepOutput) []codacy.Result {
	for _, semgrepRes := range semgrepOutput.Results {
		if semgrepRes.Extra.IsIgnored {
			continue
		}

		checkID := semgrepRes.CheckID
		if after, ok := strings.CutPrefix(checkID, "tmp."); ok {
			checkID = after
		}
		result = append(result, codacy.Issue{
			PatternID:  checkID,
			Message:    getMessage(patternDescriptions, checkID, strings.TrimSpace(semgrepRes.Extra.Message)),
			Line:       semgrepRes.StartLocation.Line,
			File:       semgrepRes.Path,
			Suggestion: semgrepRes.Extra.RenderedFix,
		})
	}

	return result
}

func getMessage(patternDescriptions *[]codacy.PatternDescription, id string, extraMessage string) string {
	// If message is empty, get the pattern title
	if extraMessage == "" {
		description, ok := lo.Find(*patternDescriptions, func(d codacy.PatternDescription) bool {
			return d.PatternID == id
		})
		if ok {
			return description.Description
		}
	}
	return docgen.GetFirstSentence(strings.ReplaceAll(extraMessage, "\n", " "))
}

func appendErrorToResult(result []codacy.Result, semgrepOutput SemgrepOutput) []codacy.Result {
	for _, semgrepError := range semgrepOutput.Errors {
		// Determine the size of the error message we're logging
		sizeMessage := 250

		//to avoid errors truncating messages with less than sizeMessage length
		if sizeMessage > len(semgrepError.Message) {
			sizeMessage = len(semgrepError.Message)
		}

		// The error message already with sizeMessage length
		truncatedMessage := semgrepError.Message[:sizeMessage]

		// Append the error to the result but only if it doesn't contain
		// "Syntax error at line" to avoid logging syntax errors that are not relevant for the user
		if !strings.Contains(truncatedMessage, "Syntax error at line") {
			result = append(result, codacy.FileError{
				Message: truncatedMessage,
				File:    semgrepError.Location.Path,
			})
		}
	}
	return result
}
