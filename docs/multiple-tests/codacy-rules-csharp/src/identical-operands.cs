namespace Tests.Bugs
{
    class Operands
    {
        void M(int a, int b, bool c)
        {
            if (a == a) { } // Noncompliant
            if (a != a) { } // Noncompliant
            if (a == b && a == b) { } // Noncompliant
            var d = a - a; // Noncompliant
            var e = a + a;
            var f = a * a;
            var g = 1 << 1;
            if (a == b) { }
        }
    }
}
