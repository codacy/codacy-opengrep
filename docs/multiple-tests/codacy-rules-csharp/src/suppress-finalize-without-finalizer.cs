using System;

namespace Tests.Practices
{
    sealed class MyClass : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this); //Noncompliant
        }
    }

    sealed class WithFinalizer : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~WithFinalizer() { Dispose(); }
    }
}
