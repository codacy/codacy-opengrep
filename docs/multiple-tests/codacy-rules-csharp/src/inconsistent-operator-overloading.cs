namespace Tests.Practices
{
    public class Foo // Noncompliant
    {
        private int left;

        public Foo(int l)
        {
            this.left = l;
        }

        public static Foo operator +(Foo a, Foo b)
        {
            return new Foo(a.left + b.left);
        }
    }

    public class Bar
    {
        public static Bar operator +(Bar a, Bar b) => a;
        public static bool operator ==(Bar a, Bar b) => true;
        public static bool operator !=(Bar a, Bar b) => false;
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => 0;
    }
}
