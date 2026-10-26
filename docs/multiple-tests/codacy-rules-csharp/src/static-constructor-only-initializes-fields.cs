namespace Tests.Performance
{
    public class Foo
    {
        static int i;
        static string s;

        static Foo() // Noncompliant
        {
            i = 3;
            s = "x";
        }
    }

    public class Bar
    {
        static int i;

        static Bar()
        {
            if (System.Environment.ProcessorCount > 2)
            {
                i = 1;
            }
        }
    }
}
