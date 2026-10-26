using System.Collections.Generic;

namespace Tests.Practices
{
    public class MyClass
    {
        public readonly string[] strings1;  // Noncompliant
        public readonly List<string> strings2 = new List<string>(); // Noncompliant
        private readonly string[] hidden;
        public readonly string name;
    }
}
