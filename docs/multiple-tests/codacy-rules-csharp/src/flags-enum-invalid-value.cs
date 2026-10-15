using System;

namespace Tests.Bugs
{
    [Flags]
    public enum Color
    {
        None = 0,
        Red = 1,
        Orange = 3, // Noncompliant
        Yellow = 4,
        Mixed = Red | Yellow
    }

    public enum NotFlags
    {
        A = 3,
        B = 5
    }
}
