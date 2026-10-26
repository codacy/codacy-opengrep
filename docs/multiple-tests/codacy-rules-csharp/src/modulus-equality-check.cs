using System.Collections.Generic;

namespace Tests.Bugs
{
    class Modulus
    {
        public bool IsOdd(int x)
        {
            return x % 2 == 1;  // Noncompliant
        }

        public bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        public bool Check(List<int> list, uint u)
        {
            return list.Count % 2 == 1 || u % 2 == 1;
        }

        public bool Third(int x)
        {
            return x % 3 != 2; // Noncompliant
        }
    }
}
