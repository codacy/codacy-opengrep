#include <cstring>

char *dup_bad(const char *s) {
    char *d = new char[strlen(s)]; // Noncompliant
    strcpy(d, s);
    return d;
}

char *dup_good(const char *s) {
    char *d = new char[strlen(s) + 1];
    strcpy(d, s);
    return d;
}
