using System;

namespace Tests.Practices
{
    class Exceptions
    {
        void DoSomething(int someParameter, string anotherParam)
        {
            if (someParameter < 0)
            {
                throw new ArgumentException("Bad argument", "someParameter"); // Noncompliant
            }
            if (anotherParam == null)
            {
                throw new ArgumentNullException(nameof(anotherParam));
            }
        }
    }
}
