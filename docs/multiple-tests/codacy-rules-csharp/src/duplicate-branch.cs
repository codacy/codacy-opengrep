namespace Tests.Practices
{
    class Branches
    {
        void M(int a)
        {
            if (a >= 0 && a < 10)
            {
                DoFirst();
                DoTheThing();
            }
            else if (a >= 10 && a < 20)
            {
                DoTheOtherThing();
            }
            else if (a >= 20 && a < 50) // Noncompliant
            {
                DoFirst();
                DoTheThing();
            }

            if (a == 1)
            {
                DoFirst();
            }
            else if (a == 2)
            {
                DoFirst();
            }
        }

        void DoFirst() { }
        void DoTheThing() { }
        void DoTheOtherThing() { }
    }
}
