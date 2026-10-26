#include <stddef.h>
#include <stdint.h>

int find_bad(const int *a, size_t n, int v) {
    size_t i;
    for (i = n - 1; i >= 0; i--) { // Noncompliant
        if (a[i] == v)
            return 1;
    }
    return 0;
}

int valid_bad(unsigned int len) {
    if (len < 0) { // Noncompliant
        return 0;
    }
    return 1;
}

int check_bad(void) {
    uint32_t value = 10;
    return value >= 0; // Noncompliant
}

int valid_good(int len) {
    if (len < 0) {
        return 0;
    }
    return 1;
}

int empty_good(size_t n) {
    return n == 0;
}
