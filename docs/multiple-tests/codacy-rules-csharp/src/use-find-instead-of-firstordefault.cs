using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Lists
    {
        int GetValue(List<int> data) =>
            data.FirstOrDefault(x => x % 2 == 0); // Noncompliant

        int GetValue(int[] data) =>
            data.FirstOrDefault(x => x % 2 == 0); // Noncompliant

        int GetValue(IEnumerable<int> data) =>
            data.FirstOrDefault(x => x % 2 == 0);
    }
}
