using System;

namespace Tests.Style
{
    public class Loops
    {
        void M(int x)
        {
            int i = 0;
            while (true)
            {
                if (i == 10)
                {
                    break;      // Noncompliant
                }
                Console.WriteLine(i);
                i++;
            }
            switch (x)
            {
                case 1:
                    Console.WriteLine(x);
                    break;
                default:
                    break;
            }
        }
    }
}
