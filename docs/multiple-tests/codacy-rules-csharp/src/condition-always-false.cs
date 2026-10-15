using System;

namespace Tests.Bugs
{
    class Conditions
    {
        const bool debug = false;

        public void Sample(bool b)
        {
            bool a = false;
            if (a) // Noncompliant
            {
                DoSomething();
            }
            if (debug)
            {
                Console.WriteLine("debug");
            }
            if (false)
            {
                DoSomething();
            }
            if (b)
            {
                DoSomething();
            }
        }

        void DoSomething() { }
    }
}
