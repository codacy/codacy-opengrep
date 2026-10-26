using System;
using System.Diagnostics;

namespace Tests.Security
{
    public class MyClass
    {
        private void DoSomething()
        {
            Console.WriteLine("My Message"); // Noncompliant
            Console.Error.WriteLine("Failure"); // Noncompliant
#if DEBUG
            Console.WriteLine("Debug only");
#endif
        }

        [Conditional("DEBUG")]
        private void Trace(string message)
        {
            Console.WriteLine(message);
        }
    }
}
