using System;
using System.IO;

namespace Tests.Bugs
{
    public class ResourceHolder   // Noncompliant
    {
        private FileStream fs;

        public void OpenResource(string path)
        {
            this.fs = new FileStream(path, FileMode.Open);
        }
    }

    public class DisposableHolder : IDisposable
    {
        private FileStream fs = new FileStream("a", FileMode.Open);

        public void Dispose()
        {
            fs.Dispose();
        }
    }

    public class NotOwner
    {
        private readonly Stream stream;

        public NotOwner(Stream stream)
        {
            this.stream = stream;
        }
    }
}
