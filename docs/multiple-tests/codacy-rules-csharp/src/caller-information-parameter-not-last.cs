using System.Runtime.CompilerServices;

namespace Tests.Practices
{
    class Tracing
    {
        void TraceMessage([CallerFilePath] string filePath = "", // Noncompliant
            string message = null)
        {
        }

        void Fine(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0)
        {
        }
    }
}
