using System;
using System.IO;

namespace Tests.Bugs
{
    public class ResourceHolder : IDisposable
    {
        private FileStream fs;
        private StreamWriter writer = new StreamWriter("log.txt");

        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open); // Noncompliant
        }

        public void Dispose()
        {
            writer.Dispose();
        }
    }
}
