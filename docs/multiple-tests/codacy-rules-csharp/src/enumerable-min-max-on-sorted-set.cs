using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Sets
    {
        int GetMax(SortedSet<int> data) =>
            data.Max(); // Noncompliant

        int GetMin(SortedSet<int> data) =>
            data.Min(); // Noncompliant

        int GetMaxProperty(SortedSet<int> data) =>
            data.Max;
    }
}
