using System;

namespace MyLibrary
{
    public class MyClass
    {
        public IntPtr myPointer;  // Noncompliant
        protected UIntPtr myOtherPointer; // Noncompliant
        public readonly IntPtr fixedPointer;
        private IntPtr hidden;
    }
}
