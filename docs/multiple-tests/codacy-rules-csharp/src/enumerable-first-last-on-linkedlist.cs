using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Linked
    {
        int GetFirst(LinkedList<int> data) =>
            data.First(); // Noncompliant

        int GetLast(LinkedList<int> data) =>
            data.Last(); // Noncompliant

        int GetFirstProperty(LinkedList<int> data) =>
            data.First.Value;
    }
}
