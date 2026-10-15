using System.Collections.Generic;

namespace Tests.Style
{
    public class Verbose
    {
        void M()
        {
            var l = new List<int>() {}; // Noncompliant
            var o = new object() {}; // Noncompliant
            var ints = new int[3] {1, 2, 3}; // Noncompliant
            int? i = new int?(5); // Noncompliant
            var ok = new List<int> { 1 };
            var arr = new[] { 1, 2, 3 };
        }
    }
}
