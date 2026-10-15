using System;
using System.Runtime.InteropServices;

namespace Tests.Practices
{
    public class Foo
    {
        public int InstanceData = 32; // Noncompliant
        public int AnotherInstanceData; // Noncompliant
        public readonly int ReadOnlyData = 1;
        public const int Constant = 2;
        public static readonly int Shared = 3;
        public event EventHandler Changed;
        private int hidden;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Native
    {
        public int Value;
    }
}
