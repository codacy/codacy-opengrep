namespace Tests.Bugs
{
    class Conditions
    {
        void M(int a, int b, int c)
        {
            if (a == b)
            {
                DoTheThing(b);
            }
            if (a == b) // Noncompliant
            {
                DoTheThing(c);
            }

            if (a == c)
            {
                a = b;
            }
            if (a == c)
            {
                DoTheThing(a);
            }
        }

        void DoTheThing(int x) { }
    }
}
