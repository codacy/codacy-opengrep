using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Contains
    {
        bool ValueExists(HashSet<int> data) =>
            data.Any(x => x == 42); // Noncompliant

        bool ValueExists(List<int> data, int value) =>
            data.Any(x => value == x); // Noncompliant

        bool Other(List<int> data) =>
            data.Any(x => x == x * 2);

        bool Fine(List<int> data) =>
            data.Contains(42);
    }
}
