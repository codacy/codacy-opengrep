#include <stdlib.h>
#include <string.h>

char *copy_bad(const char *s) {
    char *d = malloc(strlen(s)); // Noncompliant
    strcpy(d, s);
    return d;
}

char *copy_bad2(const char *s) {
    char *d = (char *) malloc(sizeof(char) * strlen(s)); // Noncompliant
    strcpy(d, s);
    return d;
}

char *copy_bad3(const char *s) {
    return calloc(strlen(s), 1); // Noncompliant
}

char *copy_good(const char *s) {
    char *d = malloc(strlen(s) + 1);
    strcpy(d, s);
    return d;
}

char *copy_good2(const char *s) {
    return calloc(strlen(s) + 1, sizeof(char));
}
