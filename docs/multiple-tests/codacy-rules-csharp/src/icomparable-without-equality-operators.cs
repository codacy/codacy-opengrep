using System;

namespace Tests.Bugs
{
    public class Foo : IComparable  // Noncompliant
    {
        public int CompareTo(object obj) { return 0; }
    }

    public class Bar : IComparable<Bar>
    {
        public int CompareTo(Bar other) { return 0; }
        public override bool Equals(object obj) => obj is Bar b && CompareTo(b) == 0;
        public override int GetHashCode() => 0;
        public static bool operator ==(Bar l, Bar r) => l.Equals(r);
        public static bool operator !=(Bar l, Bar r) => !l.Equals(r);
        public static bool operator <(Bar l, Bar r) => l.CompareTo(r) < 0;
        public static bool operator >(Bar l, Bar r) => l.CompareTo(r) > 0;
        public static bool operator <=(Bar l, Bar r) => l.CompareTo(r) <= 0;
        public static bool operator >=(Bar l, Bar r) => l.CompareTo(r) >= 0;
    }

    public class Baz : Base, IComparable<Baz> // Noncompliant
    {
        public int CompareTo(Baz other) { return 0; }
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }
}
