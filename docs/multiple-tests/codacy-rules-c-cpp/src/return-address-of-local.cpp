#include <string>
#include <cstdio>

std::string key_good(int i) {
    char buf[100];
    std::snprintf(buf, sizeof(buf), "key_%d", i);
    return buf;
}

const char *key_bad(int i) {
    char buf[100];
    std::snprintf(buf, sizeof(buf), "key_%d", i);
    return buf; // Noncompliant
}
