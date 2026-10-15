#include <string.h>

int greater_bad(const char *a, const char *b) {
    return strcmp(a, b) == 1; // Noncompliant
}

int less_bad(const void *a, const void *b, size_t n) {
    if (memcmp(a, b, n) == -1) { // Noncompliant
        return 1;
    }
    return 0;
}

int greater_good(const char *a, const char *b) {
    return strcmp(a, b) > 0;
}

int equal_good(const char *a, const char *b) {
    return strcmp(a, b) == 0;
}
