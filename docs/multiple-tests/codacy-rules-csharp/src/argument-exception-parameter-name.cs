using System;

namespace Tests.Bugs
{
    class Args
    {
        public void Foo(Bar a, int[] b) // Noncompliant
        {
            throw new ArgumentNullException("c");
        }

        public void Baz(Bar a)
        {
            throw new ArgumentException(); // Noncompliant
        }

        public void Good(Bar a, int[] b)
        {
            throw new ArgumentNullException("b");
        }

        public void Good2(Bar a)
        {
            throw new ArgumentNullException(nameof(a));
        }
    }

    class Bar { }
}
