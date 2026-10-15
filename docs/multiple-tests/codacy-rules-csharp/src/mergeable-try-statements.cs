using System;

namespace Tests.Style
{
    class Tries
    {
        void M(int a, int b)
        {
            try
            {
                DoTheFirstThing(a, b);
            }
            catch (InvalidOperationException ex)
            {
                HandleException(ex);
            }

            DoSomeOtherStuff();

            try
            {
                DoTheSecondThing(); // Noncompliant@+2
            }
            catch (InvalidOperationException ex)
            {
                HandleException(ex);
            }
        }

        void DoTheFirstThing(int a, int b) { }
        void DoTheSecondThing() { }
        void DoSomeOtherStuff() { }
        void HandleException(Exception ex) { }
    }
}
