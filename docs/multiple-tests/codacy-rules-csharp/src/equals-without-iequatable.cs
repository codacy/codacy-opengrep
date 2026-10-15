using System;

namespace Tests.Practices
{
    class MyClass  // Noncompliant
    {
        public bool Equals(MyClass other)
        {
            return other != null;
        }
    }

    class Proper : IEquatable<Proper>
    {
        public bool Equals(Proper other)
        {
            return other != null;
        }
    }
}
