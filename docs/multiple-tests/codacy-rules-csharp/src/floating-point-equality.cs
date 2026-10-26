namespace Tests.Bugs
{
    class Floats
    {
        void M(double d, int i)
        {
            float myNumber = 3.146f;
            if (myNumber == 3.146f) { } // Noncompliant
            if (d != 0.1) { } // Noncompliant
            if (i == 3) { }
            if (d < 0.1) { }
            if (d != d) { }
        }
    }
}
