using System.IO;

namespace Tests.Security
{
    class Temp
    {
        public void Example()
        {
            var tempPath = Path.GetTempFileName();  // Noncompliant
            var random = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }
    }
}
