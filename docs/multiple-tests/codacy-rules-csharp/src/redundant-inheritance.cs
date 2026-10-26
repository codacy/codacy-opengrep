namespace Tests.Style
{
    public class MyClass : object  // Noncompliant
    {
    }

    enum MyEnum : int  // Noncompliant
    {
        A
    }

    enum Small : byte
    {
        B
    }
}
