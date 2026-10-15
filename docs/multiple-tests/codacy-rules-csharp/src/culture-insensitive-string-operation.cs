using System;
using System.Globalization;

namespace Tests.Bugs
{
    class Strings
    {
        void M(string someString, string other)
        {
            var lowered = someString.ToLower(); // Noncompliant
            var upper = someString.ToUpperInvariant();
            var cmp = string.Compare(someString, other); // Noncompliant
            var starts = someString.StartsWith("abc"); // Noncompliant
            var ok = someString.StartsWith("abc", StringComparison.Ordinal);
            var ok2 = someString.ToLower(CultureInfo.InvariantCulture);
        }
    }
}
