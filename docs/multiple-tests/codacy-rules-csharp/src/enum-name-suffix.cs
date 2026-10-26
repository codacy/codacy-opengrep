namespace Tests.Naming
{
    enum FooFlags // Noncompliant
    {
        Foo = 1,
        Bar = 2
    }

    enum ColorEnum // Noncompliant
    {
        Red
    }

    enum Color
    {
        Red
    }
}
