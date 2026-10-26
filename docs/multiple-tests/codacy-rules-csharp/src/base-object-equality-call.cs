namespace Tests.Bugs
{
    class MyClass
    {
        private readonly int x;
        public MyClass(int x) => this.x = x;

        public override bool Equals(object obj) =>
            base.Equals(obj); // Noncompliant

        public override int GetHashCode() =>
            x.GetHashCode() ^ base.GetHashCode(); // Noncompliant
    }

    class Guarded
    {
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode() => 1;
    }

    class Derived : MyClass
    {
        public Derived() : base(1) { }
        public override int GetHashCode() => base.GetHashCode();
        public override bool Equals(object obj) => obj is Derived;
    }
}
