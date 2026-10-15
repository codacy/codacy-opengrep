using System.IO;

namespace Tests.Bugs
{
    class Disposables
    {
        public FileStream WriteToFile(string path, string text)
        {
            using (var fs = File.Create(path))
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
                return fs; // Noncompliant
            }
        }

        public FileStream Other(string path)
        {
            using var fs = File.Create(path);
            return fs; // Noncompliant
        }

        public FileStream Fine(string path)
        {
            var fs = File.Create(path);
            return fs;
        }
    }
}
