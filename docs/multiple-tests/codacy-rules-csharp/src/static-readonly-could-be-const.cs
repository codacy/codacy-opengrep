namespace Tests.Performance
{
    public class Foo
    {
        static readonly int x = 1;  // Noncompliant
        static readonly string name = "x"; // Noncompliant
        static readonly int y = x + 4;
        static readonly object sync = new object();
    }
}
