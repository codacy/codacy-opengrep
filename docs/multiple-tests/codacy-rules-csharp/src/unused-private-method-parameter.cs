using System;

namespace Tests.Practices
{
    public class Parameters
    {
        private void DoSomething(int a, int b) // Noncompliant
        {
            Compute(a);
        }

        private void DoSomething2(int a) // Noncompliant
        {
            var a2 = 10;
            Compute(a2);
        }

        public void Visible(int unused)
        {
            Compute(1);
        }

        private void Used(int a, int b)
        {
            if (a > 0)
            {
                Compute(b);
            }
        }

        private void NotImplemented(int a)
        {
            throw new NotImplementedException();
        }

        private void Compute(int x) { Console.WriteLine(x); }
    }
}
