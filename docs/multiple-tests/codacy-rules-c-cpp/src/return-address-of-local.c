#include <stdio.h>

char *name_bad(int id) {
    char buf[32];
    snprintf(buf, sizeof(buf), "user-%d", id);
    return buf; // Noncompliant
}

int *counter_bad(void) {
    int count = 0;
    return &count; // Noncompliant
}

char *name_good(int id) {
    static char buf[32];
    snprintf(buf, sizeof(buf), "user-%d", id);
    return buf;
}

int *counter_good(void) {
    static int count = 0;
    return &count;
}

int value_good(void) {
    int count = 0;
    return count;
}

extern int global_counter;
static char global_buf[16];

int *global_good(void) {
    return &global_counter;
}

char *global_buf_good(void) {
    return global_buf;
}
