using System.Collections.Generic;
using System.Diagnostics;

namespace Tests.Bugs
{
    class Asserts
    {
        void M(List<string> list, int i)
        {
            Debug.Assert(list.Remove("dog")); // Noncompliant
            Debug.Assert(i++ > 0); // Noncompliant
            Debug.Assert(list.Contains("dog"));
            bool removed = list.Remove("cat");
            Debug.Assert(removed);
        }
    }
}
