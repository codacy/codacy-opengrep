#define BEGIN_CLEANUP void cleanup_resources() {
#define END_CLEANUP }

// Semgrep sees "BEGIN_CLEANUP" and thinks it's a variable or 
// invalid statement because it's missing the expected function structure.
BEGIN_CLEANUP
    free(ptr);
END_CLEANUP