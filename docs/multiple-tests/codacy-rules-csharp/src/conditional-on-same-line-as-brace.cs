namespace Tests.Style
{
    public class Conditions
    {
        void M(bool condition1, bool condition2)
        {
            if (condition1)
            {
                DoSomething();
            } if (condition2) // Noncompliant
            {
                DoSomething();
            }

            if (condition1)
            {
                DoSomething();
            }
            else if (condition2)
            {
                DoSomething();
            }
        }

        void DoSomething() { }
    }
}
