namespace Tests.Style
{
    public class Chains
    {
        void M(int x)
        {
            if (x == 0)
            {
                DoSomething();
            }
            else if (x == 1) // Noncompliant
            {
                DoSomethingElse();
            }

            if (x == 0)
            {
                DoSomething();
            }
            else if (x == 1)
            {
                DoSomethingElse();
            }
            else if (x == 2) // Noncompliant
            {
                DoSomethingElse();
            }

            if (x == 0)
            {
                DoSomething();
            }
            else if (x == 1)
            {
                DoSomethingElse();
            }
            else
            {
                throw new System.InvalidOperationException();
            }

            if (x == 3)
            {
                DoSomething();
            }
        }

        void DoSomething() { }
        void DoSomethingElse() { }
    }
}
