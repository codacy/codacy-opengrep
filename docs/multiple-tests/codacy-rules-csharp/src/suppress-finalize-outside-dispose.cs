using System;

namespace Tests.Bugs
{
    class Resource : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Close()
        {
            GC.SuppressFinalize(this); // Noncompliant
        }
    }

    class Explicit : IDisposable
    {
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
