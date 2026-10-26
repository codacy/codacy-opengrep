#include <stdio.h>

int check_bad(int x, int y) {
    if (x = y) { // Noncompliant
        return 1;
    }
    return 0;
}

void loop_bad(int *p, int v) {
    while (*p = v) // Noncompliant
        p++;
}

int check_good(int x, int y) {
    if (x == y) {
        return 1;
    }
    return 0;
}

void read_good(FILE *f) {
    int c;
    while ((c = fgetc(f)) != EOF) {
        putchar(c);
    }
}

void intended_good(char *dst, const char *src) {
    while ((*dst++ = *src++))
        ;
}

int nested_good(int *out, int x) {
    int r;
    if ((r = x * 2)) {
        if (r > 10) {
            *out = r;
        }
        if (r != 3)
            return 1;
    }
    return 0;
}

int compound_good(int x) {
    if (x <= 3 && x >= 0)
        return 1;
    return 0;
}
