using System;

namespace Tests.Practices
{
    public class GarbageDisposal
    {
        private int Dispose() // Noncompliant
        {
            return 0;
        }
    }

    public class Proper : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
