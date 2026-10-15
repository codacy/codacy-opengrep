namespace Tests.Style
{
    public class Groups
    {
        int thousand = 100_0; // Noncompliant
        int tenThousand = 100_00; // Noncompliant
        int million = 1_000_000;
        int hundred = 1_00;
        long hex = 0x7fff_ffff;
        int bin = 0b0110_1001_01; // Noncompliant
    }
}
