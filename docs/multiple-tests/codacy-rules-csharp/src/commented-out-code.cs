namespace Tests.Style
{
    public class Comments
    {
        // This method computes the total amount for the given order.
        int Compute(int a)
        {
            // int b = a * 2; // Noncompliant
            // a = a + 1; // Noncompliant
            // DoSomething(a); // Noncompliant
            // if (a > 3) { // Noncompliant
            // } // Noncompliant
            // return a; // Noncompliant
            // Note that the value is never negative
            /// <summary>XML documentation is ignored</summary>
            return a;
        }
    }
}
