#include <stdexcept>
#include <iostream>

void run_bad() {
    try {
        throw std::runtime_error("failed");
    } catch (std::exception e) { // Noncompliant
        std::cerr << e.what();
    }
}

void run_bad2() {
    try {
        throw std::runtime_error("failed");
    } catch (const std::runtime_error e) { // Noncompliant
        std::cerr << e.what();
    }
}

void run_good() {
    try {
        throw std::runtime_error("failed");
    } catch (const std::exception &e) {
        std::cerr << e.what();
    } catch (int code) {
        std::cerr << code;
    } catch (...) {
        std::cerr << "unknown";
    }
}
