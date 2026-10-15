using System;

namespace Tests.Bugs
{
    [Flags]
    enum FruitType    // Noncompliant
    {
        None,
        Banana,
        Orange,
        Strawberry
    }

    [Flags]
    enum Small
    {
        None,
        A,
        B
    }

    [Flags]
    enum Explicit
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4
    }

    enum NotFlags
    {
        A,
        B,
        C,
        D
    }
}
