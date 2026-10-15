using System;
using System.IO;

namespace Tests.Practices
{
    class Logs
    {
        void LogDateTime()
        {
            using var streamWriter = new StreamWriter("logs.txt", true);
            streamWriter.WriteLine($"DateTime:{DateTime.Now:o}"); // Noncompliant
            streamWriter.WriteLine($"DateTime:{DateTime.UtcNow:o}");
        }
    }
}
