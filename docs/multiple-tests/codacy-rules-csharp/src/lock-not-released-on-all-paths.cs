using System.Threading;

namespace Tests.Bugs
{
    class MyClass
    {
        private readonly object obj = new object();
        private readonly ReaderWriterLockSlim lockObj = new ReaderWriterLockSlim();

        public void DoSomethingWithMonitor(bool condition)
        {
            Monitor.Enter(obj); // Noncompliant
            if (condition)
            {
                Monitor.Exit(obj);
            }
        }

        public void DoSomethingWithReaderWriteLockSlim(bool condition)
        {
            lockObj.EnterReadLock(); // Noncompliant
            if (condition)
            {
                lockObj.ExitReadLock();
            }
        }

        public void Correct()
        {
            Monitor.Enter(obj);
            try
            {
                DoWork();
            }
            finally
            {
                Monitor.Exit(obj);
            }
        }

        public void NeverReleased()
        {
            Monitor.Enter(obj);
        }

        void DoWork() { }
    }
}
