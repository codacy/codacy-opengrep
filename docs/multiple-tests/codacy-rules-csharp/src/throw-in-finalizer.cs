using System;

namespace Tests.Bugs
{
    class MyClass
    {
        ~MyClass()
        {
            Cleanup();
            throw new NotImplementedException(); // Noncompliant
        }

        void Cleanup()
        {
            throw new InvalidOperationException();
        }
    }
}
