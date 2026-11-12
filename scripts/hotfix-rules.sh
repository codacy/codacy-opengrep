#!/bin/sh
# TEMPORARY: patch rules in the generated rules.yaml that fail to parse with
# the current Opengrep version. Remove each fix once it is fixed upstream.
#
# - csharp_crypto_rule-CertificateValidationDisabled (GitLab sast-rules):
#   the pattern "(...) => true;" is not a valid C# expression pattern, so
#   Opengrep reports a rule parse error and the scan exits with code 2.
#   Dropping the trailing semicolon keeps the rule's behaviour.
#   See https://github.com/codacy/codacy-opengrep/issues/44
set -eu

RULES="${1:-/docs/rules.yaml}"
TMP="$(mktemp)"

awk -v target="csharp_crypto_rule-CertificateValidationDisabled" \
    -v broken="(...) => true;" '
  # Rules start at column 0 in the generated file; nested "- id:" lines
  # inside patterns are indented and must not change the current rule.
  /^- id:/ {
    id = $0
    sub(/^- id:[ \t]*/, "", id)
    gsub(/["\047 \t]/, "", id)
    in_rule = (id == target)
  }
  in_rule && (i = index($0, broken)) > 0 {
    # keep everything except the trailing ";" of the broken pattern
    $0 = substr($0, 1, i + length(broken) - 2) substr($0, i + length(broken))
    patched++
  }
  { print }
  END {
    if (patched == 0) {
      print "hotfix-rules: no \"" broken "\" found in " target \
            " - fixed upstream? Remove this hotfix." > "/dev/stderr"
      exit 1
    }
    print "hotfix-rules: patched " patched " line(s) in " target > "/dev/stderr"
  }
' "$RULES" > "$TMP"

mv "$TMP" "$RULES"