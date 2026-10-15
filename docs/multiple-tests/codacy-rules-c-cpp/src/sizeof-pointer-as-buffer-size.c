#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void clear_bad(char *buf) {
    memset(buf, 0, sizeof(buf)); // Noncompliant
}

void copy_bad(char *dst, const char *src) {
    strncpy(dst, src, sizeof(dst)); // Noncompliant
}

void read_bad(FILE *f) {
    char *line = malloc(128);
    fgets(line, sizeof(line), f); // Noncompliant
    free(line);
}

void format_bad(char buf[], int n) {
    snprintf(buf, sizeof(buf), "%d", n); // Noncompliant
}

void clear_good(void) {
    char buf[64];
    memset(buf, 0, sizeof(buf));
}

void clear_good2(char *buf, size_t len) {
    memset(buf, 0, len);
}

void clear_struct(struct stat_like *p) {
    memset(p, 0, sizeof(*p));
}
