namespace Tests.Practices
{
    public class Calculator
    {
        public static Calculator operator +(Calculator a, Calculator b) // Noncompliant
        {
            return a;
        }
    }
}
