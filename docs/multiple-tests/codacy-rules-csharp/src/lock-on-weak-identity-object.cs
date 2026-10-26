using System;
using System.Threading;

namespace Tests.Bugs
{
    public class Sample
    {
        private readonly StackOverflowException myLock = new StackOverflowException();
        private readonly Thread thread = new Thread(() => { });
        private readonly object sync = new object();

        public void Go()
        {
            lock (myLock) // Noncompliant
            {
                Work();
            }
            lock (thread) // Noncompliant
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
