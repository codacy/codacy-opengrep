# Codacy Opengrep

This is the docker engine we use at Codacy to have [Opengrep](https://github.com/opengrep/opengrep) support.

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/689e72eabdb24722a24b8bc08b979cfa)](https://app.codacy.com/gh/codacy/codacy-opengrep/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![CircleCI](https://circleci.com/gh/codacy/codacy-opengrep.svg?style=svg)](https://circleci.com/gh/codacy/codacy-opengrep)

## Usage

You can create the docker by doing:

```bash
docker build --build-arg TOOL_VERSION=$(cat .tool_version) -t codacy-opengrep:latest .
```

The docker is ran with the following command:

```bash
docker run -it -v $srcDir:/src codacy-opengrep:latest
```

## Generate Docs

1. Update the version in `.tool_version`

2. Get the latest commit for the `release` branch from the github.com/opengrep/opengrep-rules repo and update it in DocGenerator file `internal/docgen/parsing.go`.

3.  Run the DocGenerator:
```bash
go run ./cmd/docgen
```

## Test

We use the [codacy-plugins-test](https://github.com/codacy/codacy-plugins-test) to test our external tools integration.
You can follow the instructions there to make sure your tool is working as expected.

## Agent Playbook: Updating This Repository End-to-End

This section is written for an AI coding agent (or a human) tasked with updating this repo — most commonly bumping the wrapped Opengrep version, but also opengrep-rules/GitLab-rules commit pins, orb, or dependency bumps. Follow it top to bottom; it tells you what to change, how to regenerate derived files, how to test locally, and how to interpret CI so you can iterate on failures without guessing.

### 1. What this repository is

This is a **Codacy engine**: a Go wrapper (`cmd/tool`, `internal/tool`, built on `github.com/codacy/codacy-engine-golang-seed/v6`) that packages the [Opengrep](https://github.com/opengrep/opengrep) static analysis engine (a fork of Semgrep) as a Docker image Codacy's platform can run against a customer's source code. The wrapper itself does not run Opengrep's engine in-process — the `Dockerfile` downloads the prebuilt `opengrep` binary release directly from GitHub and shells out to it at runtime.

The `docs/` directory holds both hand-maintained inputs and generated outputs:

- `docs/codacy-rules.yaml`, `docs/codacy-rules-i18n.yaml`, `docs/codacy-rules-ai.yaml`, `docs/codacy-rules-exotic.yaml` — Codacy's own custom Semgrep-style rules, hand-maintained, merged in alongside the upstream rule sets.
- `docs/tool-description.md` — short blurb about the tool, hand-maintained.
- `docs/patterns.json`, `docs/description/*.json`, `docs/description/*.md`, `docs/rules.yaml`, `docs/semgrep-pro-rules.yaml` — **generated, git-ignored** (see `.gitignore`: "Ignore generated documentation files to avoid licensing issues"). Do not hand-edit and do not expect to see them in `git status`/PR diffs — they're produced fresh on every `go run ./cmd/docgen` and inside the `Dockerfile` build itself.

These generated files come from **`internal/docgen`** (entry point `cmd/docgen/main.go`), which downloads three rule sources — the `opengrep/opengrep-rules` GitHub repo (pinned to a specific commit), GitLab's `sast-rules` repo (tracks its default branch, no commit pin), and Codacy's own `docs/codacy-rules*.yaml` files — parses the Semgrep-format YAML rules, and converts them into Codacy's pattern/description format. This means the generator needs **network access** and **git** installed locally (it clones the rule repos).

### 2. Files that encode versions — check all of these on every update

| File | What it controls | What to check |
|---|---|---|
| `.tool_version` | The Opengrep release version reported/used by the wrapper, and consumed by `internal/docgen` when generating `patterns.json` | Bump to the target version (e.g. `1.24.0`, no leading `v`). |
| `Dockerfile` → `ARG OPENGREP_VERSION` | Which Opengrep GitHub release binary is downloaded at image build time | Must be bumped **in lock-step** with `.tool_version`, with a leading `v` (e.g. `v1.24.0`). Past PRs have shipped inconsistent bumps here — a prior fix commit exists specifically because this ARG was left stale while `.tool_version` was updated, so double-check both are aligned. |
| `internal/docgen/parsing.go` → `getSemgrepRegistryRules()` commit hash | Which commit of `github.com/opengrep/opengrep-rules` (`release` branch) is used as the rule source | Get the latest commit for the `release` branch of that repo and update the hardcoded commit string. |
| `.circleci/config.yml` → `codacy/base` orb, `codacy/plugins-test` orb | Shared CircleCI steps and plugin-test runner | Check for newer published orb versions if the task scope includes CI tooling bumps. |
| `go.mod` / `go.sum` | Go module dependencies (e.g. `codacy-engine-golang-seed`) | Only bump if the task scope includes dependency updates; run `go mod tidy` after. |

### 3. Step-by-step update procedure

1. **Bump `.tool_version` and the Dockerfile's `OPENGREP_VERSION` ARG together** to the same target version.
2. **Update the opengrep-rules commit pin** in `internal/docgen/parsing.go` if the task calls for picking up new/changed upstream rules (find the latest commit on the `release` branch of `opengrep/opengrep-rules`).
3. **Regenerate the docs**: `go run ./cmd/docgen`. This produces `docs/patterns.json`, `docs/rules.yaml`, and `docs/description/*` fresh — since these are git-ignored, you won't see them in the diff, but the run itself is the validation that the rule set still parses cleanly (it `panic`s on unrecognized severities/categories/languages, so a clean exit is a meaningful signal).
4. **Run the Go unit tests**: `go test $(go list ./... | grep -v /docs/)` (this is the exact command CI's `unit_tests` job runs).
5. **Build the Docker image**: `docker build --build-arg TOOL_VERSION=$(cat .tool_version) -t codacy-opengrep:latest .` — this exercises the full chain: Go build, `go run ./cmd/docgen` inside the builder stage, and the architecture-specific Opengrep binary download, so a failure here can also reveal a bad version/commit pin.
6. **Run `codacy-plugins-test` locally** before pushing — clone https://github.com/codacy/codacy-plugins-test and run the relevant test commands (this repo runs `run_multiple_tests: true` in CI, reflecting the many fixture directories under `docs/multiple-tests/`) against your local image tag.
7. **Iterate on failures**, re-running only the relevant test command after each fix.
8. **Commit** the version bump(s) together in one change (README-only changes, like this playbook section, should be committed separately).
9. **Push and open a PR** against `main`.
10. **Poll the PR's real CI checks until they all pass — local validation is NOT the finish line.** After every push, run `gh pr checks <pr-url>` and keep re-polling (short sleep while any check is `pending`) until all checks finish. If a check fails, fetch its actual log (don't guess), find the true root cause, fix it, push again (never `--no-verify`, never force-push), and re-poll. Repeat until every check is green. **The CI environment's toolchain can differ from your local one**, so a clean local run does not guarantee CI passes. Only stop iterating when every check passes, or you hit a genuine product/infra decision that needs a human.

### 4. Common failure modes and fixes

| Symptom | Cause | Fix |
|---|---|---|
| `Dockerfile` build downloads the wrong Opengrep binary or fails the `curl` step | `.tool_version` and the Dockerfile's `OPENGREP_VERSION` ARG got out of sync during a bump (this has happened before — see commit history) | Bump both together, in the same commit, and grep the whole diff for the old version string before pushing to make sure no reference was missed. |
| `go run ./cmd/docgen` panics with `unknown severity`/`unknown category`/`unknown language` | The upstream rule source (opengrep-rules or GitLab rules) introduced a new value not handled in `internal/docgen/parsing.go`'s mapping switch statements | Read the panic message for the offending rule ID/value, extend the relevant `switch` in `parsing.go` to handle it. |
| CI `unit_tests` job fails but `go test ./...` passes locally | The CI job explicitly excludes `/docs/` (`go test $(go list ./... \| grep -v /docs/)`); a local run of plain `go test ./...` can behave differently if generated docs files are present/stale locally | Run the exact CI command locally, and regenerate/clean `docs/` before testing. |

### 5. Definition of done

- `.tool_version` and the Dockerfile's `OPENGREP_VERSION` ARG bumped together and consistent.
- `internal/docgen/parsing.go` commit pin updated if the rule source needed to move.
- `go run ./cmd/docgen` completes without errors (no `panic` from unrecognized rule metadata).
- `go test $(go list ./... | grep -v /docs/)` passes.
- Docker image builds successfully via the exact `docker build --build-arg TOOL_VERSION=...` command from the README.
- `codacy-plugins-test` commands pass locally against the freshly built image.
- **After pushing and opening/updating the PR, every CI check on it is green.** Poll `gh pr checks <pr-url>` and iterate on any failure until all pass.

## What is Codacy?

[Codacy](https://www.codacy.com/) is an Automated Code Review Tool that monitors your technical debt, helps you improve your code quality, teaches best practices to your developers, and helps you save time in Code Reviews.

### Among Codacy’s features

-   Identify new Static Analysis issues
-   Commit and Pull Request Analysis with GitHub, BitBucket/Stash, GitLab (and also direct git repositories)
-   Auto-comments on Commits and Pull Requests
-   Integrations with Slack, HipChat, Jira, YouTrack
-   Track issues in Code Style, Security, Error Proneness, Performance, Unused Code and other categories

Codacy also helps keep track of Code Coverage, Code Duplication, and Code Complexity.

Codacy supports PHP, Python, Ruby, Java, JavaScript, and Scala, among others.

### Free for Open Source

Codacy is free for Open Source projects.
