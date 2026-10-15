using System;
using System.IO;

namespace Tests.Security
{
    class Directories
    {
        void M()
        {
            using var writer = new StreamWriter("/tmp/f"); // Noncompliant
            var tmp = Environment.GetEnvironmentVariable("TMP"); // Noncompliant
            var home = Environment.GetEnvironmentVariable("HOME");
            var app = "/var/lib/app/data";
        }
    }
}
