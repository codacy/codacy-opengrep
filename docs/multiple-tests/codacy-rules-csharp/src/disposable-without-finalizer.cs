using System;

namespace Tests.Bugs
{
    public class Foo : IDisposable // Noncompliant
    {
        private IntPtr myResource;

        public void Dispose() { }
    }

    public class Bar : IDisposable
    {
        private IntPtr myResource;

        public void Dispose() { }

        ~Bar() { }
    }
}
