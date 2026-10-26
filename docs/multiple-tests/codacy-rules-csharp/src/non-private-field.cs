namespace Tests.Practices
{
    public class Foo
    {
        public int MagicNumber = 42; // Noncompliant
        public readonly int Answer = 42; // Noncompliant
        public static int Shared = 1;
        public const int Constant = 1;
        private int hidden;
    }

    public struct Point
    {
        public int X;
    }
}
