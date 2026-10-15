namespace Tests.Bugs
{
    class Shifts
    {
        void M(int i, long lg, byte[] bytes)
        {
            int intShift = i << 33; // Noncompliant
            long longShift2 = lg << 65; // Noncompliant
            int zero = i >> 0; // Noncompliant
            int ok = i << 4;
            int literal = 1 << 0;
            long longOk = lg << 40;
        }
    }
}
