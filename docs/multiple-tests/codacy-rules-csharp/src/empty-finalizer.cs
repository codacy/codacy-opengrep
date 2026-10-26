namespace Tests.Performance
{
    public class Foo
    {
        ~Foo() // Noncompliant
        {
        }
    }

    public class Bar
    {
        ~Bar()
        {
            System.Console.WriteLine("finalized");
        }
    }
}
