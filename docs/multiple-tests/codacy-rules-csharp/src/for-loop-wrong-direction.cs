namespace Tests.Bugs
{
    class Loops
    {
        void M(int maximum)
        {
            for (int i = 0; i < maximum; i--)  // Noncompliant
            {
            }
            for (int i = maximum; i >= maximum; i++)  // Noncompliant
            {
            }
            for (int i = 0; i < maximum; i++)
            {
            }
            for (int i = maximum; i >= 0; i--)
            {
            }
        }
    }
}
