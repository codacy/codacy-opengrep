using System;
using System.Runtime.InteropServices;

namespace Tests.Security
{
    class Handles
    {
        void M(SafeHandle handle)
        {
            IntPtr dangerousHandle = handle.DangerousGetHandle(); // Noncompliant
            bool closed = handle.IsClosed;
        }
    }
}
