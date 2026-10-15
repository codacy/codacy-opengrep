namespace Tests.Performance
{
    class Constants
    {
        int GetBestNumber() // Noncompliant
        {
            return 12;
        }

        string Name() => "name"; // Noncompliant

        public override string ToString() => "constant";

        int Compute(int x)
        {
            return x * 2;
        }
    }
}
