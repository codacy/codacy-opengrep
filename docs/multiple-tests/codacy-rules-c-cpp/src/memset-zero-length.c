#include <string.h>

void clear_bad(char *buf, size_t len) {
    memset(buf, len, 0); // Noncompliant
}

void clear_good(char *buf, size_t len) {
    memset(buf, 0, len);
}

void clear_later_good(char *buf) {
    size_t len = 0;
    if (buf[0])
        len = 16;
    memset(buf, 0, len);
}
