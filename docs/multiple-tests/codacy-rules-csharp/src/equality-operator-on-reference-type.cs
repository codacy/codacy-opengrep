using System;

namespace Tests.Practices
{
    public class MyType // Noncompliant
    {
        public static bool operator ==(MyType x, MyType y) => ReferenceEquals(x, y);
        public static bool operator !=(MyType x, MyType y) => !(x == y);
    }

    public class Money : IEquatable<Money>
    {
        public bool Equals(Money other) => true;
        public static bool operator ==(Money x, Money y) => true;
        public static bool operator !=(Money x, Money y) => false;
    }

    public class Vector
    {
        public static Vector operator +(Vector a, Vector b) => a;
        public static bool operator ==(Vector x, Vector y) => true;
        public static bool operator !=(Vector x, Vector y) => false;
    }
}
