namespace Tests.Style
{
    public class Jumps
    {
        void Foo(bool condition1, bool condition2)
        {
            goto A; // Noncompliant
        A:
            while (condition1)
            {
                DoTheThing();
                continue; // Noncompliant
            }
            if (condition2)
            {
                return;
            }
            DoTheThing();
            return; // Noncompliant
        }

        void Bar(bool condition)
        {
            while (condition)
            {
                if (condition)
                {
                    continue;
                }
                DoTheThing();
            }
            if (condition)
            {
                return;
            }
            DoTheThing();
        }

        int Baz()
        {
            return 1;
        }

        void DoTheThing() { }
    }
}
