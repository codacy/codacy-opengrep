namespace Tests.Practices
{
    class Loops
    {
        void M()
        {
            int sum = 0;
            for (int i = 0; i < 10; sum++) // Noncompliant
            {
                i++;
            }
            for (int j = 0; j < 10; j++)
            {
                sum += j;
            }
        }
    }
}
