#include <ctype.h>

int count_digits_bad(const char *s) {
    int n = 0;
    for (; *s; s++) {
        char c = *s;
        if (isdigit(c)) // Noncompliant
            n++;
    }
    return n;
}

int upper_bad(char c) {
    return toupper(c); // Noncompliant
}

int count_digits_good(const char *s) {
    int n = 0;
    for (; *s; s++) {
        unsigned char c = (unsigned char) *s;
        if (isdigit(c))
            n++;
    }
    return n;
}

int upper_good(char c) {
    return toupper((unsigned char) c);
}

int is_space_good(int c) {
    return isspace(c);
}
