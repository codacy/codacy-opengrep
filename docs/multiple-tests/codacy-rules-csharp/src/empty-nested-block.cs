namespace Tests.Style
{
    public class Blocks
    {
        void M(bool c, int n)
        {
            for (int i = 0; i < 42; i++) { } // Noncompliant
            if (c)
            {
            } // Noncompliant@-2
            else
            {
                n++;
            }
            while (n > 0)
            {
                // waiting on purpose
                n--;
            }
            try
            {
                n++;
            }
            catch (System.InvalidOperationException)
            {
                // ignored on purpose
            }
        }
    }
}
