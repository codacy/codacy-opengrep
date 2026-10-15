namespace Tests.Style
{
    class Apple { }

    class TypeChecks
    {
        void M(object f)
        {
            if (f as Apple != null) { } // Noncompliant
            if (typeof(Apple).IsInstanceOfType(f)) { } // Noncompliant
            if (f is Apple) { }
        }
    }
}
