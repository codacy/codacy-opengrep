namespace Tests.Bugs
{
    class Locks
    {
        private readonly object sync = new object();

        void MyLockingMethod()
        {
            lock (this) // Noncompliant
            {
                Work();
            }
            lock (typeof(Locks)) // Noncompliant
            {
                Work();
            }
            lock ("shared") // Noncompliant
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
