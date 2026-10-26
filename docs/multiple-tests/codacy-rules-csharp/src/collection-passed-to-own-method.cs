using System.Collections.Generic;
using System.Linq;

namespace Tests.Bugs
{
    class Collections
    {
        void M()
        {
            var list = new List<int>();
            list.AddRange(list); // Noncompliant
            var u = list.Union(list); // Noncompliant
            var other = new List<int>();
            list.AddRange(other);
        }
    }
}
