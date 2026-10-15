using System.IO;
using System.Threading.Tasks;

namespace Tests.Bugs
{
    class Reads
    {
        public byte[] ReadFile(string fileName)
        {
            using var stream = File.Open(fileName, FileMode.Open);
            var result = new byte[stream.Length];
            stream.Read(result, 0, (int)stream.Length); // Noncompliant
            return result;
        }

        public async Task<byte[]> ReadAsync(Stream stream)
        {
            var buffer = new byte[16];
            await stream.ReadAsync(buffer, 0, 16); // Noncompliant
            int read = stream.Read(buffer, 0, 16);
            return buffer;
        }
    }
}
