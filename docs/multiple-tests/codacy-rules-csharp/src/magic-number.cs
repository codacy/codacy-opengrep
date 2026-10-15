using System;

namespace Tests.Style
{
    public class Numbers
    {
        private const int Max = 4;
        private int field = 42;

        [Obsolete("x", false)]
        public void DoSomething(int retries = 3)
        {
            for (int i = 0; i < 4; i++)  // Noncompliant
            {
                Console.Write(i * 1000); // Noncompliant
            }
            var size = 16;
            var ts = new TimeSpan(0, 5, 0);
            Use(count: 7);
            if (field > Max || retries == 0 || size == 1)
            {
                return;
            }
        }

        void Use(int count) { }

        public override int GetHashCode() => 31 * field;
    }
}
