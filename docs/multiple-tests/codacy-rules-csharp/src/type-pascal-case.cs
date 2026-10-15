namespace Tests.Naming
{
    class my_class { } // Noncompliant
    class SOMEName42 { } // Noncompliant
    class SomeName42 { }
    class MyXClass { }
    class XC { } // Noncompliant
    interface IFoo { }
    interface IXmlParser { }
    interface iFoo { } // Noncompliant
    struct point { } // Noncompliant
    struct Point { }
    enum colors { Red } // Noncompliant
    enum Color { Red }
    record person(string Name); // Noncompliant
    record Person(string Name);
}
