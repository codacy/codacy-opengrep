namespace Tests.Bugs
{
    class Infinite
    {
        public int Sum()
        {
            var i = 0;
            var result = 0;
            while (true) // Noncompliant
            {
                result += i;
                i++;
            }
        }

        public int Bounded()
        {
            var i = 0;
            while (true)
            {
                if (i > 10)
                {
                    break;
                }
                i++;
            }
            for (;;)
            {
                if (i++ > 20)
                {
                    return i;
                }
            }
        }

        public int Recurse() // Noncompliant
        {
            return Recurse();
        }

        public int Value => Value; // Noncompliant

        public int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
