namespace Tests.Style
{
    public class Declarations
    {
        private int a, b; // Noncompliant
        private int c;

        public void Method()
        {
            int d, e; // Noncompliant
            int f = 1;
        }
    }
}
