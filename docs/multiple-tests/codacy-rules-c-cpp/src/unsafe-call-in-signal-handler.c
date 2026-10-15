#include <signal.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

static volatile sig_atomic_t stop_requested = 0;

void on_interrupt(int sig) {
    printf("interrupted by %d\n", sig); // Noncompliant
    exit(1); // Noncompliant
}

void on_term(int sig) {
    stop_requested = 1;
    _exit(0);
}

void not_a_handler(int code) {
    printf("code %d\n", code);
}

int main(void) {
    signal(SIGINT, on_interrupt);
    signal(SIGTERM, on_term);
    not_a_handler(2);
    while (!stop_requested) {
        pause();
    }
    return 0;
}
