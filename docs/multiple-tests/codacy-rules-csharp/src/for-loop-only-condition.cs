namespace Tests.Style
{
    public class Loops
    {
        void M(bool condition)
        {
            for (;condition;) // Noncompliant
            {
                condition = Next();
            }
            for (int i = 0; condition; i++)
            {
                condition = Next();
            }
            while (condition)
            {
                condition = Next();
            }
        }

        bool Next() { return false; }
    }
}
