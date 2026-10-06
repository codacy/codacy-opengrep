package tool

import (
	"bufio"
	"fmt"
	"io/fs"
	"os"
	"path"
	"path/filepath"
	"regexp"
	"strings"

	codacy "github.com/codacy/codacy-engine-golang-seed/v6"
	"github.com/samber/lo"
)

var htmlCommentRegex = regexp.MustCompile(`<!--\s*([A-Z_]+)\s*-->`)

const sourceConfigurationFileName = ".semgrep.yaml"

// TODO: should respect cli flag for docs location
const rulesDefinitionFileName = "/docs/rules.yaml"

func newConfigurationFile(toolExecution codacy.ToolExecution) (*os.File, error) {

	if toolExecution.Patterns == nil {
		// Use the tool's configuration file, if it exists.
		// Otherwise use the tool's default patterns.
		if sourceConfigurationFileExists(toolExecution.SourceDir) {
			return getSourceConfigurationFile(toolExecution.SourceDir)
		}

		return createConfigurationFileFromDefaultPatterns(*toolExecution.ToolDefinition.Patterns)
	}

	if len(*toolExecution.Patterns) == 0 {
		return nil, nil
	}

	// if there are configured patterns, create a configuration file from them
	return createConfigurationFileFromPatterns(toolExecution.Patterns)
}

func sourceConfigurationFileExists(sourceDir string) bool {
	if fileInfo, err := os.Stat(path.Join(sourceDir, sourceConfigurationFileName)); err != nil || fileInfo.IsDir() {
		return false
	}

	return true
}

func createConfigurationFileFromDefaultPatterns(patterns []codacy.Pattern) (*os.File, error) {
	defaultPatterns := lo.Filter(patterns, func(pattern codacy.Pattern, _ int) bool {
		return pattern.Enabled
	})
	return createConfigurationFileFromPatterns(&defaultPatterns)
}

func getSourceConfigurationFile(sourceFolder string) (*os.File, error) {
	filename := path.Join(sourceFolder, sourceConfigurationFileName)
	file, err := os.Open(filename)
	if err != nil {
		return nil, err
	}
	return file, nil
}

func createConfigurationFileFromPatterns(patterns *[]codacy.Pattern) (*os.File, error) {

	defaultConfigurationFileScanner, err := newRulesScanner()
	if err != nil {
		return nil, err
	}

	configurationFile, err := createAndWriteConfigurationFile(defaultConfigurationFileScanner, patterns)
	if err != nil {
		return nil, err
	}
	return configurationFile, nil
}

func newRulesScanner() (*bufio.Scanner, error) {

	rulesConfigurationFile, err := os.Open(rulesDefinitionFileName)
	if err != nil {
		return nil, err
	}

	defaultConfigurationFileScanner := bufio.NewScanner(rulesConfigurationFile)

	return defaultConfigurationFileScanner, nil
}

func createAndWriteConfigurationFile(scanner *bufio.Scanner, patterns *[]codacy.Pattern) (*os.File, error) {
	configurationFile, err := os.CreateTemp(os.TempDir(), "semgrep-*.yaml")
	if err != nil {
		return nil, err
	}
	_, err = configurationFile.WriteString("rules:\n")
	if err != nil {
		return nil, err
	}

	idIsPresent := false
	var currentPattern *codacy.Pattern
	for scanner.Scan() {
		line := scanner.Text()

		idIsPresent, currentPattern = defaultRuleIsConfiguredWithPattern(line, patterns, idIsPresent, currentPattern)
		if idIsPresent {
			// Replace HTML comment placeholders with parameter values
			processedLine := replaceParameterPlaceholders(line, currentPattern)
			_, err := configurationFile.WriteString(processedLine + "\n")
			if err != nil {
				return nil, err
			}
		}
	}
	return configurationFile, nil
}

func defaultRuleIsConfigured(line string, patterns *[]codacy.Pattern, idIsPresent bool) bool {
	if strings.Contains(line, "- id:") {
		id := strings.TrimSpace(strings.Split(line, ":")[1])
		return isIDPresent(id, patterns)
	}
	return idIsPresent // We want to keep the same value
}

func defaultRuleIsConfiguredWithPattern(line string, patterns *[]codacy.Pattern, idIsPresent bool, currentPattern *codacy.Pattern) (bool, *codacy.Pattern) {
	if strings.Contains(line, "- id:") {
		id := strings.TrimSpace(strings.Split(line, ":")[1])
		pattern, found := lo.Find(*patterns, func(item codacy.Pattern) bool {
			return item.ID == id
		})
		if found {
			return true, &pattern
		}
		return false, nil
	}
	return idIsPresent, currentPattern
}

func isIDPresent(id string, patterns *[]codacy.Pattern) bool {
	_, res := lo.Find(*patterns, func(item codacy.Pattern) bool {
		return item.ID == id
	})
	return res
}

// replaceParameterPlaceholders replaces HTML comment placeholders (e.g., <!-- MODEL_REGEX -->)
// with the corresponding parameter values from the pattern
func replaceParameterPlaceholders(line string, pattern *codacy.Pattern) string {
	if pattern == nil || len(pattern.Parameters) == 0 {
		return line
	}

	// Check if line contains an HTML comment placeholder
	if !htmlCommentRegex.MatchString(line) {
		return line
	}

	// Replace each HTML comment with the corresponding parameter value
	result := htmlCommentRegex.ReplaceAllStringFunc(line, func(match string) string {
		matches := htmlCommentRegex.FindStringSubmatch(match)
		if len(matches) > 1 {
			paramName := matches[1]
			// Convert UPPER_CASE to camelCase to match parameter name format
			formattedParamName := formatParameterName(paramName)
			// Find the parameter in the pattern
			for _, param := range pattern.Parameters {

				if param.Name == formattedParamName {
					// Use Value if set, otherwise use Default
					value := param.Value
					if value == nil {
						value = param.Default
					}
					if value != nil {
						valueStr := fmt.Sprintf("%v", value)

						// If parameter name ends with _ALLOW_LIST, convert comma-separated list to regex pattern
						if strings.HasSuffix(paramName, "_ALLOW_LIST") {
							return convertListToRegex(valueStr, false)
						}
						return valueStr
					}
				}
			}
		}
		// If no parameter found, keep the original placeholder
		return match
	})

	return result
}

// convertListToRegex converts a comma-separated list into a regex alternation pattern
// Example: "gemini-2.5-flash,gpt-3.5-turbo,old-llama-model" -> "^(gemini-2\\.5-flash|gpt-3\\.5-turbo|old-llama-model)$"
func convertListToRegex(list string, include bool) string {
	// Split by comma and trim spaces
	items := strings.Split(list, ",")
	for i, item := range items {
		// Trim whitespace
		item = strings.TrimSpace(item)
		// Escape dots for regex
		item = strings.ReplaceAll(item, ".", "\\.")
		items[i] = item
	}

	// Join with pipe separator and wrap in regex anchors
	if include {
		return fmt.Sprintf("^(%s)$", strings.Join(items, "|"))
	}

	return fmt.Sprintf("^(?!(%s)$).*", strings.Join(items, "|"))
}

// formatParameterName converts UPPER_CASE to camelCase
func formatParameterName(name string) string {
	parts := strings.Split(strings.ToLower(name), "_")
	if len(parts) == 0 {
		return name
	}

	result := parts[0]
	for i := 1; i < len(parts); i++ {
		if len(parts[i]) > 0 {
			result += strings.ToUpper(string(parts[i][0])) + parts[i][1:]
		}
	}
	return result
}

// filesToAnalyse holds every file to scan, regardless of language: opengrep
// picks the rules that apply to each file, so a single run covers all languages.
var filesToAnalyse []string

func populateFilesToAnalyse(toolExecutionFiles *[]string, toolExecutionSourceDir string) error {
	// If there are files to analyse, analyse only those files
	if toolExecutionFiles != nil && len(*toolExecutionFiles) > 0 {
		return populateFilesToAnalyseFromFiles(*toolExecutionFiles)
	}
	// If there are no files to analyse, analyse all files from source dir
	return populateFilesToAnalyseFromSourceDir(toolExecutionSourceDir)
}

func populateFilesToAnalyseFromFiles(toolExecutionFiles []string) error {
	for _, file := range toolExecutionFiles {
		addFileToAnalyse(file)
	}

	return nil
}

func populateFilesToAnalyseFromSourceDir(toolExecutionSourceDir string) error {
	// Semgrep can analyse full directories and its subdirectories
	// but we will have to analyse every extension from every file
	// so we will have to do this walk somewhere else if we dont do it here
	err := filepath.WalkDir(toolExecutionSourceDir, processFile)
	if err != nil {
		return err
	}

	return nil
}

func processFile(path string, info fs.DirEntry, err error) error {
	if err != nil {
		return err
	}
	pathInfo, pathErr := info.Info()
	if pathErr != nil {
		return pathErr
	}
	// if it is a file and it is not a hidden file
	if !pathInfo.IsDir() && !strings.HasPrefix(pathInfo.Name(), ".") {
		addFileToAnalyse(path)
	}

	return nil
}

func addFileToAnalyse(fileName string) {
	filesToAnalyse = append(filesToAnalyse, fileName)
}
