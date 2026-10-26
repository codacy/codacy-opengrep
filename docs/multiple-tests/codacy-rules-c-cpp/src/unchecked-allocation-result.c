#include <stdlib.h>
#include <string.h>

struct node { int value; struct node *next; };

struct node *make_bad(int v) {
    struct node *n = malloc(sizeof(struct node));
    n->value = v; // Noncompliant
    n->next = NULL; // Noncompliant
    return n;
}

int *zeros_bad(size_t count) {
    int *a = calloc(count, sizeof(int));
    a[0] = 1; // Noncompliant
    return a;
}

char *dup_bad(const char *s) {
    char *d = (char *) malloc(strlen(s) + 1);
    strcpy(d, s); // Noncompliant
    return d;
}

struct node *make_good(int v) {
    struct node *n = malloc(sizeof(struct node));
    if (n == NULL) {
        return NULL;
    }
    n->value = v;
    n->next = NULL;
    return n;
}

int *zeros_good(size_t count) {
    int *a = calloc(count, sizeof(int));
    if (!a)
        return NULL;
    a[0] = 1;
    return a;
}

char *dup_good(const char *s) {
    char *d = malloc(strlen(s) + 1);
    if (d != NULL) {
        strcpy(d, s);
    }
    return d;
}

int first_good(size_t count) {
    int *a = malloc(count * sizeof(int));
    return a && a[0];
}
