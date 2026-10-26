using System;

namespace Tests.Bugs
{
    class NaNs
    {
        void M(double a, float f)
        {
            if (a == double.NaN) // Noncompliant
            {
                Console.WriteLine("a is not a number");
            }
            if (f != float.NaN) { } // Noncompliant
            if (double.IsNaN(a)) { }
        }
    }
}
