using System.Collections.Generic;

namespace Tests.Bugs
{
    class IndexOfs
    {
        void M(List<string> strings, string color)
        {
            if (strings.IndexOf(color) > 0) { } // Noncompliant
            if (color.IndexOf("b") > 0) { } // Noncompliant
            if (strings.IndexOf(color) >= 0) { }
            if (strings.IndexOf(color) > -1) { }
        }
    }
}
