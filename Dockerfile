ARG OPENGREP_VERSION=v1.11.5

# Build codacy-opengrep wrapper
FROM golang:1.23-alpine3.21 as builder
WORKDIR /src
COPY go.mod go.mod
COPY go.sum go.sum
RUN go mod download
COPY cmd cmd
COPY internal internal
RUN go build -o bin/codacy-opengrep -ldflags="-s -w" ./cmd/tool
COPY .tool_version .tool_version
COPY docs /docs
RUN go run ./cmd/docgen -docFolder /docs

# Compress binaries for smaller image size
FROM alpine:3.21 as compressor
RUN apk add --no-cache upx
COPY --from=builder /src/bin/codacy-opengrep /src/bin/codacy-opengrep
RUN upx --lzma /src/bin/codacy-opengrep

# Final published image for the codacy-opengrep wrapper
FROM python:3.12-slim
RUN apt update && apt install -y tar bash cosign curl adduser
RUN adduser --uid 2004 --disabled-password --gecos "" docker

# Download and extract opengrep binary from GitHub releases
ARG OPENGREP_VERSION
ARG TARGETARCH
ENV OPENGREP_VERSION=${OPENGREP_VERSION}

# Download appropriate binary based on architecture
RUN if [ "$TARGETARCH" = "arm64" ]; then \
        curl -L -o /usr/local/bin/opengrep "https://github.com/opengrep/opengrep/releases/download/${OPENGREP_VERSION}/opengrep_manylinux_aarch64"; \
    else \
        curl -L -o /usr/local/bin/opengrep "https://github.com/opengrep/opengrep/releases/download/${OPENGREP_VERSION}/opengrep_manylinux_x86"; \
    fi \
    && chmod +x /usr/local/bin/opengrep


COPY --from=builder --chown=docker:docker /docs /docs
COPY --from=compressor /src/bin /dist/bin

USER docker
CMD [ "/dist/bin/codacy-opengrep" ]
