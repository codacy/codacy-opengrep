using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Copies
    {
        private List<string> foo = new List<string> { "a", "b", "c" };
        private string[] bar = new string[] { "a", "b", "c" };

        public IEnumerable<string> Foo => foo.ToList(); // Noncompliant

        public string[] Bar // Noncompliant
        {
            get { return bar.ToArray(); }
        }

        public IEnumerable<string> Fine => foo.AsReadOnly();

        public string[] GetBar() => bar.ToArray();
    }
}
