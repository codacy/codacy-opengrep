using System;

namespace Tests.Style
{
    class X
    {
        public int field = 0; // Noncompliant
        public object o = null; // Noncompliant
        public bool flag = false; // Noncompliant
        public double d = 0.0; // Noncompliant
        public int field2 = 1;
        public const int Zero = 0;
        public object MyProperty { get; set; } = null; // Noncompliant
        public int? nullable = 0;

        void M()
        {
            int local = 0;
            object other = null;
        }
    }
}
