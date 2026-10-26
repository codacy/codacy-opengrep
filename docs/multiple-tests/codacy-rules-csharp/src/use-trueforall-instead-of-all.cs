using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Lists
    {
        public bool AreAllEven(List<int> data) =>
            data.All(x => x % 2 == 0); // Noncompliant

        public bool AreAllEven(IEnumerable<int> data) =>
            data.All(x => x % 2 == 0);
    }
}
