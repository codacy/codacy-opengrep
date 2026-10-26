#include <stdlib.h>

int grow_bad(int *items, size_t n) {
    items = realloc(items, n * sizeof(int)); // Noncompliant
    return items != NULL;
}

int grow_good(int **items, size_t n) {
    int *tmp = realloc(*items, n * sizeof(int));
    if (tmp == NULL) {
        return 0;
    }
    *items = tmp;
    return 1;
}
