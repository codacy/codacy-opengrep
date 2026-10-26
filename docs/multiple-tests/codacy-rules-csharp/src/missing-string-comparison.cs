using System;

namespace Tests.Practices
{
    class Comparisons
    {
        int M(string name1, string name2)
        {
            var a = string.Compare(name1, name2); // Noncompliant
            var b = string.Compare(name1, name2, StringComparison.Ordinal);
            var c = name1.StartsWith("x"); // Noncompliant
            return a + b + (c ? 1 : 0);
        }
    }
}
