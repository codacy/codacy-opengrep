using System.Diagnostics;

namespace Tests.Security
{
    class Commands
    {
        void M()
        {
            Process p = new Process();
            p.StartInfo.FileName = "binary"; // Noncompliant
            Process.Start("git", "status"); // Noncompliant
            Process.Start("/usr/bin/git", "status");
            var info = new ProcessStartInfo(@"C:\Tools\tool.exe");
        }
    }
}
