using System;

namespace Tests.Bugs
{
    static class Refs
    {
        public static void Method(int a, int b, object c, object d)
        {
            if (Object.ReferenceEquals(a, b)) // Noncompliant
            {
                Console.WriteLine("never");
            }
            if (ReferenceEquals(c, d))
            {
                Console.WriteLine("same");
            }
        }
    }
}
