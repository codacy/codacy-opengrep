using System;

namespace Tests.Bugs
{
    class Loops
    {
        void M(bool condition)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                if (condition)
                {
                    i = 20; // Noncompliant
                }
            }
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(j);
            }
        }
    }
}
