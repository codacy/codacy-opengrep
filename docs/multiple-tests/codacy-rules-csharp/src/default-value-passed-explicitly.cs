namespace Tests.Style
{
    class Defaults
    {
        public void M(int x, int y = 5)
        {
        }

        void Caller()
        {
            M(1, 5); // Noncompliant
            M(1, 6);
            M(1);
        }
    }
}
