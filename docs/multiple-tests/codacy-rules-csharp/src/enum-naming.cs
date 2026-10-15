using System;

namespace Tests.Naming
{
    public enum foo // Noncompliant
    {
        FooValue = 0
    }

    public enum Color
    {
        Red
    }

    [Flags]
    public enum Option // Noncompliant
    {
        None = 0,
        Option1 = 1,
        Option2 = 2
    }

    [Flags]
    public enum Options
    {
        None = 0,
        Option1 = 1
    }
}
