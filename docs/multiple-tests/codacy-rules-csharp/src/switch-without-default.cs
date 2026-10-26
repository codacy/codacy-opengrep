using System;

namespace Tests.Bugs
{
    public class Switches
    {
        void M(int foo)
        {
            switch (foo) // Noncompliant
            {
                case 0:
                    Console.WriteLine("foo = 0");
                    break;
                case 42:
                    Console.WriteLine("foo = 42");
                    break;
            }

            switch (foo)
            {
                case 0:
                    Console.WriteLine("foo = 0");
                    break;
                default:
                    throw new InvalidOperationException("Unexpected value");
            }
        }
    }
}
