namespace Tests.Bugs
{
    class Loops
    {
        void M()
        {
            for (int i = 0; i < 0; i++)  // Noncompliant
            {
            }
            for (int i = 10; i <= 5; i++) // Noncompliant
            {
            }
            for (int i = 0; i > 5; i--) // Noncompliant
            {
            }
            for (int i = 0; i < 5; i++)
            {
            }
            for (int i = 5; i >= 0; i--)
            {
            }
        }
    }
}
