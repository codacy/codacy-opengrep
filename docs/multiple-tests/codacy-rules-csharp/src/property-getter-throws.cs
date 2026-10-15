using System;

namespace Tests.Practices
{
    class Props
    {
        private int? value;

        public int Foo
        {
            get
            {
                throw new Exception(); // Noncompliant
            }
        }

        public int Value
        {
            get
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Not initialized");
                }
                return value.Value;
            }
        }

        public int Bar => throw new ArgumentException("bar"); // Noncompliant

        public int this[int index]
        {
            get { throw new ArgumentOutOfRangeException(nameof(index)); }
        }
    }
}
