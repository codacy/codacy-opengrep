namespace Tests.Bugs
{
    class Comparisons
    {
        void M(float f, int i, byte b, double d)
        {
            if (f <= double.MaxValue) { } // Noncompliant
            if (f > double.MaxValue) { } // Noncompliant
            if (i < long.MinValue) { } // Noncompliant
            if (b < -1) { } // Noncompliant
            if (d <= double.MaxValue) { }
            if (f <= float.MaxValue) { }
        }
    }
}
