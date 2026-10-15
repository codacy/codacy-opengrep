using System;

namespace Tests.Bugs
{
    public class Base : IEquatable<Base> // Noncompliant
    {
        public bool Equals(Base other) => other != null;
    }

    public sealed class Sealed : IEquatable<Sealed>
    {
        public bool Equals(Sealed other) => other != null;
    }

    public class Virtual : IEquatable<Virtual>
    {
        public virtual bool Equals(Virtual other) => other != null;
    }
}
