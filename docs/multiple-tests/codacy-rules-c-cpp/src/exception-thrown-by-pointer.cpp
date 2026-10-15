#include <stdexcept>

void fail_bad() {
    throw new std::runtime_error("failed"); // Noncompliant
}

void fail_good() {
    throw std::runtime_error("failed");
}
