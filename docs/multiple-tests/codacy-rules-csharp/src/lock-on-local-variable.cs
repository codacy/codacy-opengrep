namespace Tests.Bugs
{
    class Locks
    {
        private readonly object sync = new object();

        private void DoSomething()
        {
            object local = new object();
            lock (local) // Noncompliant
            {
                Work();
            }
            lock (sync)
            {
                Work();
            }
        }

        void Work() { }
    }
}
