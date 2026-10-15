#include <cstdlib>

struct Widget { int id; };

void array_bad(int n) {
    int *values = new int[n];
    values[0] = 1;
    delete values; // Noncompliant
}

void object_bad() {
    Widget *w = new Widget();
    delete[] w; // Noncompliant
}

void malloc_bad() {
    char *p = (char *) malloc(16);
    delete p; // Noncompliant
}

void new_free_bad() {
    Widget *w = new Widget();
    free(w); // Noncompliant
}

void array_good(int n) {
    int *values = new int[n];
    values[0] = 1;
    delete[] values;
}

void object_good() {
    Widget *w = new Widget();
    delete w;
}

void malloc_good() {
    char *p = (char *) malloc(16);
    free(p);
}

void pointer_array_good(int n) {
    Widget **list = new Widget*[n];
    list[0] = new Widget();
    delete list[0];
    delete[] list;
}

void pointer_array_bad(int n) {
    Widget **list = new Widget*[n];
    delete list; // Noncompliant
}
