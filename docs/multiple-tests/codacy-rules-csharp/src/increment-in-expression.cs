namespace Tests.Practices
{
    class Increments
    {
        void M(int u8b, int u8c, int bar)
        {
            int u8a = ++u8b + u8c--; // Noncompliant
            int foo = bar++ / 4; // Noncompliant
            Use(bar++); // Noncompliant
            bar++;
            u8a = u8b + u8c;
        }

        void Use(int x) { }
    }
}
