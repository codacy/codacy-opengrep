using System.Collections.Generic;

namespace Tests.Practices
{
    public class Holder
    {
        public List<string> Strings { get; set; } // Noncompliant
        public List<string> ReadOnly { get; private set; }
        public string[] Array { get; set; }
        public IList<int> Numbers { get; } = new List<int>();
    }
}
