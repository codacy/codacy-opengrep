using System.Collections.Generic;

namespace Tests.Bugs
{
    class Empty
    {
        public void Method()
        {
            var values = new List<string>();
            values.Remove("bar"); // Noncompliant
            if (values.Contains("foo")) { } // Noncompliant
            foreach (var str in values) { } // Noncompliant
        }

        public void Filled()
        {
            var values = new List<string>();
            values.Add("bar");
            values.Remove("bar");
        }
    }
}
