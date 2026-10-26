namespace Tests.Style
{
    public class Literals
    {
        const long b = 0l; // Noncompliant
        const long c = 0L;
        const uint d = 1u;
        const ulong e = 1UL;
        const ulong f = 1ul; // Noncompliant
        const int hex = 0xff;
        const decimal m = 1.5M;
    }
}
