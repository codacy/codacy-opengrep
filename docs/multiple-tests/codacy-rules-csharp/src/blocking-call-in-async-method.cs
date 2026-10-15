using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Performance
{
    class Async
    {
        public async Task Examples(Stream stream, string path)
        {
            var array = new byte[1024];
            stream.Read(array, 0, 1024);            // Noncompliant
            var text = File.ReadAllText(path);       // Noncompliant
            Thread.Sleep(10);                        // Noncompliant
            await stream.ReadAsync(array, 0, 1024);
            var good = await File.ReadAllTextAsync(path);
        }

        public void Sync(Stream stream)
        {
            var array = new byte[1024];
            stream.Read(array, 0, 1024);
        }
    }
}
