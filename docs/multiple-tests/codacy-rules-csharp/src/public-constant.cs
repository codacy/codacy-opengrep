namespace Tests.Practices
{
    public class Foo
    {
        public const double Version = 1.0;           // Noncompliant
        private const double Internal = 2.0;
        public static double Version2 => 1.0;
    }
}

namespace Tests.Practices2
{
    public class Bar
    {
        public static readonly double NotConstant = 1.0;
        public readonly int Field = 3;
    }
}
