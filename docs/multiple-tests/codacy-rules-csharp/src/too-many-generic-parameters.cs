namespace Tests.Complexity
{
    public class Pair<T, U>
    {
    }

    public class Triple<S, T, U> // Noncompliant
    {
    }

    public class Methods
    {
        public void Foo<S, T, U, V>() { } // Noncompliant
        public void Bar<S, T, U>() { }
    }
}
