namespace Tests.Practices
{
    internal class MyClass
    {
        public static decimal PI = 3.14m;  // Noncompliant

        public int GetOne() // Noncompliant
        {
            return 1;
        }

        internal int GetTwo()
        {
            return 2;
        }
    }

    internal class Implementer : System.IDisposable
    {
        public void Dispose() { }
    }
}
