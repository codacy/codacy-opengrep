using System;

namespace Tests.Naming
{
    class AttributeOne : Attribute // Noncompliant
    {
    }

    class Timeout : Exception // Noncompliant
    {
    }

    class ExtendedTimeout : Timeout
    {
    }

    class MyEventArgs : EventArgs
    {
    }

    class Changed : EventArgs, IDisposable // Noncompliant
    {
        public void Dispose() { }
    }

    class TimeoutException : Exception
    {
    }
}
