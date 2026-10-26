namespace Tests.Bugs
{
    class Shifts
    {
        void M(dynamic d)
        {
            var x = d >> 5.4; // Noncompliant
            var y = d << null; // Noncompliant
            var z = d << 4;
        }
    }
}
