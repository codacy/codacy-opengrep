#include <string>
#include <cstdio>

std::string get_name();

struct User { std::string name() const; };

void print_bad(const User &u) {
    const char *p = get_name().c_str(); // Noncompliant
    std::puts(p);
}

void print_bad2(const User &u) {
    const char *p = u.name().c_str(); // Noncompliant
    std::puts(p);
}

void print_bad3(const std::string &a, const std::string &b) {
    const char *p = (a + b).c_str(); // Noncompliant
    std::puts(p);
}

void print_good(const User &u) {
    std::string name = u.name();
    const char *p = name.c_str();
    std::puts(p);
}

void print_good2() {
    std::puts(get_name().c_str());
}

struct Slice { const char *data() const; };
Slice generate(int n);

void slice_good() {
    const char *p = generate(10).data();
    std::puts(p);
}
