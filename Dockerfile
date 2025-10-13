ARG OPENGREP_VERSION=v1.10.0

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
FROM alpine:3.21
RUN adduser -u 2004 -D docker
RUN apk add --no-cache curl

# Download and extract opengrep binary from GitHub releases
ARG OPENGREP_VERSION
ENV OPENGREP_VERSION=${OPENGREP_VERSION}
RUN apk add --no-cache tar
# RUN curl -L -o /tmp/opengrep-core.tar.gz "https://github.com/opengrep/opengrep/releases/download/${OPENGREP_VERSION}/opengrep-core_linux_x86.tar.gz" \
#	&& tar -xzvf /tmp/opengrep-core.tar.gz -C /usr/local/bin/ \
#	&& chmod +x /usr/local/bin/opengrep-core

# RUN curl -L -o /usr/local/bin/opengrep "https://github.com/opengrep/opengrep/releases/download/${OPENGREP_VERSION}/opengrep_musllinux_x86" \
#	&& chmod +x /usr/local/bin/opengrep
RUN curl -fsSL https://raw.githubusercontent.com/opengrep/opengrep/main/install.sh | sh
RUN mv ~/.opengrep/cli/${OPENGREP_VERSION}/opengrep /usr/local/bin/opengrep
RUN chmod +x /usr/local/bin/opengrep


COPY --from=builder --chown=docker:docker /docs /docs
COPY --from=compressor /src/bin /dist/bin


CMD [ "/dist/bin/codacy-opengrep" ]
