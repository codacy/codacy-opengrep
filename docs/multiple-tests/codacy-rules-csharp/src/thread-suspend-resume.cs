using System.Threading;

namespace Tests.Bugs
{
    class Threads
    {
        void M(Thread thread)
        {
            thread.Suspend(); // Noncompliant
            thread.Resume(); // Noncompliant
            thread.Join();
        }
    }
}
