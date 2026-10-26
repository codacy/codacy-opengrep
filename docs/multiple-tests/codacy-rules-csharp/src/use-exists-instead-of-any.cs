using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Lists
    {
        bool ContainsEven(List<int> data) =>
            data.Any(x => x % 2 == 0); // Noncompliant

        bool ContainsEven(int[] data) =>
            data.Any(x => x % 2 == 0); // Noncompliant

        bool ContainsEven(IEnumerable<int> data) =>
            data.Any(x => x % 2 == 0);
    }
}
