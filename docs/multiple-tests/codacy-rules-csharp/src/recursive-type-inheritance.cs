namespace Tests.Bugs
{
    class C2<T> : C2<T> // Noncompliant
    {
    }

    class C3<T> : C3<C3<T>> // Noncompliant
    {
    }

    class Fine<T> : System.Collections.Generic.List<T>
    {
    }
}
