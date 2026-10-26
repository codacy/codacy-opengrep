namespace Tests.Style
{
    public class Numbers
    {
        int i = 10000000; // Noncompliant
        int i2 = 10_000_000;
        int small = 99999;
        int j = 0b01101001010011011110010101011110; // Noncompliant
        int j2 = 0b01101001_01001101_11100101_01011110;
        long l = 0x7fffffffffffffffL; // Noncompliant
        long l2 = 0x7fff_ffff_ffff_ffffL;
        int k = 0xFF;
    }
}
