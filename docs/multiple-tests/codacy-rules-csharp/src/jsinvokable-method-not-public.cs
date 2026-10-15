using Microsoft.JSInterop;

namespace Tests.Bugs
{
    public class Interop
    {
        [JSInvokable]
        private static void MyStaticMethod() { } // Noncompliant

        [JSInvokable]
        internal void MyMethod() { } // Noncompliant

        [JSInvokable]
        public void Fine() { }
    }
}
