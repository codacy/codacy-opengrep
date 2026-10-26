using System.Collections.Generic;

namespace Tests.Bugs
{
    class Sizes
    {
        void M(List<int> collection, int[] array)
        {
            if (collection.Count >= 0) { } // Noncompliant
            if (array.Length >= 0) { } // Noncompliant
            if (array.Length < 0) { } // Noncompliant
            if (collection.Count > 0) { }
        }
    }
}
