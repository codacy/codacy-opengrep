namespace Tests.Bugs
{
    public class Indentation
    {
        void M(bool condition)
        {
            if (condition)  // Noncompliant
            DoTheThing();
            DoTheOtherThing();

            if (condition)
                DoTheThing();
            DoTheOtherThing();

            if (condition)
            {
                DoTheThing();
            }
        }

        void DoTheThing() { }
        void DoTheOtherThing() { }
    }
}
