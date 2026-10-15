namespace Tests.Style
{
    public class Comments
    {
        void M()
        {
            //
            int a = 1; // Noncompliant@-1
            /* */ // Noncompliant
            // First line of a block
            //
            // Third line of a block
            int b = 2;
            /* not empty */
        }
    }
}
