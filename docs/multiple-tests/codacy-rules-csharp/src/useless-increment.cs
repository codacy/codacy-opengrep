namespace Tests.Bugs
{
    class Increments
    {
        private int counter;

        int PickNumber()
        {
            int i = 0;
            int j = 0;
            i = i++; // Noncompliant
            return j--; // Noncompliant
        }

        int Next()
        {
            return counter++;
        }
    }
}
