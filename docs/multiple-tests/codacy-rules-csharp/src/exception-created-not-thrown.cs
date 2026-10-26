using System;

namespace Tests.Bugs
{
    class Exceptions
    {
        void M(int x)
        {
            if (x < 0)
            {
                new ArgumentException("x must be nonnegative"); // Noncompliant
            }
            if (x > 10)
            {
                throw new ArgumentException("x must be smaller than 10");
            }
            var e = new InvalidOperationException();
            Log(new InvalidOperationException());
        }

        void Log(Exception e) { }
    }
}
