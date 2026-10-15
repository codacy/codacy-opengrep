using System;

namespace Tests.Bugs
{
    public class Foo1 : IDisposable // Noncompliant
    {
        public void Dispose()
        {
        }
    }

    public sealed class Foo2 : IDisposable
    {
        public void Dispose()
        {
        }
    }

    public class Foo3 : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
