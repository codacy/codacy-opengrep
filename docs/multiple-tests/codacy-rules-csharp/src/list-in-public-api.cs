using System.Collections.Generic;

namespace Foo
{
    public class Bar
    {
        public List<T> Method1<T>(T arg) // Noncompliant
        {
            return null;
        }

        public void Method2(List<int> items) // Noncompliant
        {
        }

        private List<int> internalList = new List<int>();

        public IList<int> Fine() => internalList;
    }
}
