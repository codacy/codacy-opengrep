namespace Tests.Practices
{
    public class Fixmes
    {
        private int Divide(int numerator, int denominator)
        {
            return numerator / denominator; // FIXME denominator value might be 0 // Noncompliant
        }

        /* fixme: handle overflow */ // Noncompliant
        private int Prefix() { return 0; }
    }
}
