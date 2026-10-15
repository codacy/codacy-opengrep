namespace Tests.Practices
{
    class Outer
    {
        public static int A;

        public class Inner
        {
            public int A; // Noncompliant
            public int B;
        }
    }
}
