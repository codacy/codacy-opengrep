namespace Tests.Practices
{
    public static class MyExtensions
    {
        public static void SomeExtension(this object obj) // Noncompliant
        {
        }

        public static void StringExtension(this string s)
        {
        }
    }
}
