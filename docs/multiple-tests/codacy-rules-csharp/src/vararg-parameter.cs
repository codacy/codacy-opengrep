using System;
using System.Runtime.InteropServices;

namespace Tests.Compatibility
{
    public class Foo
    {
        public void Bar(__arglist) // Noncompliant
        {
            ArgIterator argumentIterator = new ArgIterator(__arglist);
        }

        [DllImport("msvcrt40.dll")]
        public static extern int printf(string format, __arglist);
    }
}
