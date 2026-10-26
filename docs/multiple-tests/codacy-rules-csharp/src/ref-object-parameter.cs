namespace Tests.Practices
{
    class Refs
    {
        public void Bar(ref object o1, ref int i) // Noncompliant
        {
        }

        public void Baz<T>(ref T value)
        {
        }
    }
}
