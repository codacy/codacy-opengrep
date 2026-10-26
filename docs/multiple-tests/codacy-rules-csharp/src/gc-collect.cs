using System;

namespace Tests.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            GC.Collect();                              // Noncompliant
            GC.Collect(2, GCCollectionMode.Optimized); // Noncompliant
            var before = GC.GetTotalMemory(false);
        }
    }
}
