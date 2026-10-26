using System;
using System.Diagnostics;

namespace Tests.Performance
{
    class Timing
    {
        void M()
        {
            var start = DateTime.Now;
            MethodToBeBenchmarked();
            Console.WriteLine($"{(DateTime.Now - start).TotalMilliseconds} ms"); // Noncompliant

            var watch = Stopwatch.StartNew();
            MethodToBeBenchmarked();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        void MethodToBeBenchmarked() { }
    }
}
