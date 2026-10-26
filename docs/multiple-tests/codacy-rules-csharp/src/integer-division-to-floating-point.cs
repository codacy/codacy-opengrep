namespace Tests.Bugs
{
    class Divisions
    {
        void M(int a, int b, double x)
        {
            decimal dec = 3 / 2; // Noncompliant
            double d = a / b; // Noncompliant
            double ok = 3.0 / 2;
            double ok2 = x / b;
            int i = a / b;
        }
    }
}
