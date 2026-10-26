namespace Tests.Style
{
    class MyClass { }

    class Checks
    {
        void M(object x)
        {
            if (x != null && x is MyClass) { } // Noncompliant
            if (x == null || !(x is MyClass)) { } // Noncompliant
            if (x is MyClass) { }
        }
    }
}
