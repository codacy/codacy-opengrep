using System;

namespace Tests.Practices
{
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }

    [Flags]
    enum Access
    {
        None = 0,
        Read = 1,
        Write = 2
    }

    class Usage
    {
        void M()
        {
            var x = Permissions.Read | Permissions.Write;  // Noncompliant
            var y = Access.Read | Access.Write;
        }
    }
}
