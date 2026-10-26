using System.Collections.Generic;
using System.Linq;

namespace Tests.Style
{
    class Casts
    {
        public int Example(int i)
        {
            return (int)i; // Noncompliant
        }

        public IEnumerable<int> ExampleCollection(IEnumerable<int> coll)
        {
            return coll.Cast<int>(); // Noncompliant
        }

        public int Narrow(long l)
        {
            return (int)l;
        }
    }
}
