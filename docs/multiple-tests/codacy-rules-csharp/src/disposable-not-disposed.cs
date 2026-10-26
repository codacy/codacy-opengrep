using System.IO;

namespace Tests.Bugs
{
    public class ResourceUser
    {
        public void Leak(string path)
        {
            var fs = new FileStream(path, FileMode.Open); // Noncompliant
            fs.ReadByte();
        }

        public void LeakReader(string path)
        {
            var reader = new StreamReader(path); // Noncompliant
            reader.ReadLine();
        }

        public void Disposed(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            fs.ReadByte();
            fs.Dispose();
        }

        public void Using(string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            fs.ReadByte();
        }

        public Stream Returned(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            return fs;
        }

        public void Wrapped(Stream s)
        {
            var sr = new StreamReader(s);
            sr.ReadLine();
        }

        public void Passed(string path)
        {
            var fs = File.Create(path);
            Consume(fs);
        }

        void Consume(Stream s) { }
    }
}
