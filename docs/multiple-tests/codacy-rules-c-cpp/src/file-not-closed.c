#include <stdio.h>
#include <dirent.h>

int first_byte_bad(const char *path) {
    FILE *f = fopen(path, "r"); // Noncompliant
    if (f == NULL)
        return -1;
    return fgetc(f);
}

int count_bad(const char *path) {
    int n = 0;
    DIR *d = opendir(path); // Noncompliant
    while (readdir(d) != NULL)
        n++;
    return n;
}

int first_byte_good(const char *path) {
    int c;
    FILE *f = fopen(path, "r");
    if (f == NULL)
        return -1;
    c = fgetc(f);
    fclose(f);
    return c;
}

FILE *open_log_good(const char *path) {
    FILE *f = fopen(path, "a");
    return f;
}

struct ctx { FILE *out; };

void attach_good(struct ctx *c, const char *path) {
    FILE *f = fopen(path, "w");
    c->out = f;
}
