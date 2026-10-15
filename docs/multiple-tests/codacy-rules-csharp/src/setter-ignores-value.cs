using System;

namespace Tests.Bugs
{
    class Props
    {
        private int count;
        public int Count
        {
            get { return count; }
            set { count = 42; } // Noncompliant
        }

        private int other;
        public int Other
        {
            get { return other; }
            set { other = value; }
        }

        public int ReadOnly
        {
            get { return 1; }
            set { throw new NotSupportedException(); }
        }
    }
}
