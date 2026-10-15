namespace MyLibrary
{
    public class Foo
    {
    }

    public static class MyExtensions
    {
        public static void Bar(this Foo a) // Noncompliant
        {
        }

        public static void Baz(this string s)
        {
        }
    }
}
