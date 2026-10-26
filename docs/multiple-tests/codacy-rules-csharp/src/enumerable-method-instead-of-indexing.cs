using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Indexing
    {
        int GetAt(List<int> data, int index) => data.ElementAt(index); // Noncompliant
        int GetFirst(List<int> data) => data.First(); // Noncompliant
        int GetLast(int[] data) => data.Last(); // Noncompliant
        int GetFirstEnumerable(IEnumerable<int> data) => data.First();
    }
}
