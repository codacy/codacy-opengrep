namespace Tests.Bugs
{
    class MyClass   // Noncompliant
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    class Hashed    // Noncompliant
    {
        public override int GetHashCode() => 42;
    }

    class Both
    {
        public override bool Equals(object obj) => obj is Both;
        public override int GetHashCode() => 1;
    }

    struct Point    // Noncompliant
    {
        public override bool Equals(object obj) => obj is Point;
    }
}
