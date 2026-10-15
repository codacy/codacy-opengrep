#include <string>

bool after_bad(const std::string &a, const std::string &b) {
    return a.compare(b) == 1; // Noncompliant
}

bool after_good(const std::string &a, const std::string &b) {
    return a.compare(b) > 0;
}
