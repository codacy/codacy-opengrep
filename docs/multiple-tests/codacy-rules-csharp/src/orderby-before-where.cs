using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Queries
    {
        public IEnumerable<int> GetSortedFilteredList(IEnumerable<int> data) =>
            data.OrderBy(x => x).Where(x => x % 2 == 0); // Noncompliant

        public IEnumerable<int> Good(IEnumerable<int> data) =>
            data.Where(x => x % 2 == 0).OrderBy(x => x);
    }
}
