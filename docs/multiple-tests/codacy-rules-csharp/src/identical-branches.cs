namespace Tests.Practices
{
    class Branches
    {
        void M(int a, int b)
        {
            if (b == 0)  // Noncompliant
            {
                DoTheThing();
            }
            else
            {
                DoTheThing();
            }

            int c = a > 12 ? 4 : 4;  // Noncompliant

            if (b == 0)
            {
                DoTheThing();
            }
            else if (b == 1)
            {
                DoTheThing();
            }
        }

        void DoTheThing() { }
    }
}
