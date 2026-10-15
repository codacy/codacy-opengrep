using System.Collections.Generic;

namespace Tests.Complexity
{
    public class Generics
    {
        public void DoSomething(ICollection<ICollection<int>> outerCollect) // Noncompliant
        {
        }

        public void Simple(ICollection<int> values)
        {
        }
    }
}
