using System;

namespace Tests.Practices
{
    [Flags]
    enum FruitType
    {
        Void = 0,        // Noncompliant
        Banana = 1,
        Orange = 2,
        Strawberry = 4
    }

    [Flags]
    enum Colors
    {
        None = 0,
        Red = 1
    }

    enum NotFlags
    {
        Zero = 0,
        One = 1
    }
}
