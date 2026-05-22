#include <iostream>
#include <cstdlib>
#include <string>
#include <cstdint>

namespace newNamespace {
    using String_t = std::string;
}

namespace osutility {
    // [SHOULD NOT FLAG]: This is a definition.
    std::int32_t system(const newNamespace::String_t& cmd, newNamespace::String_t& output) {
        output = "Executed safely: " + cmd;
        return 0; // Success
    }
}

int main() {
    newNamespace::String_t my_cmd = "ls -la";
    newNamespace::String_t my_out;

    // [SHOULD NOT FLAG]: Custom system function in osutility namespace
    osutility::system(my_cmd, my_out);

    // [SHOULD FLAG]: Standard global system call
    system("echo 'This is dangerous'");

    // [SHOULD FLAG]: Explicit standard namespace system call
    std::system("echo 'This is also dangerous'");

    // [SHOULD FLAG]: Explicit global namespace system call
    ::system("echo 'Still dangerous'");

    return 0;
}