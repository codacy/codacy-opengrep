package main

import (
	"os"

	codacy "github.com/codacy/codacy-engine-golang-seed/v6"
	"github.com/codacy/codacy-opengrep/internal/tool"
)

func main() {
	codacyOpengrep := tool.New()
	retCode := codacy.StartTool(codacyOpengrep)

	os.Exit(retCode)
}
