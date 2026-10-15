namespace Tests.Style
{
    class Bitwise
    {
        void M(int anyValue)
        {
            var a = anyValue & -1; // Noncompliant
            var b = anyValue | 0; // Noncompliant
            var c = anyValue ^ 0; // Noncompliant
            var d = anyValue & 0xFF;
        }
    }
}
