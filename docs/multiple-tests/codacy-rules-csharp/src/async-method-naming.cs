using System.Threading;
using System.Threading.Tasks;

namespace Tests.Naming
{
    public class Reader : BaseReader
    {
        public Task Read(byte[] buffer, int offset, int count, CancellationToken cancellationToken) // Noncompliant
        {
            return Task.CompletedTask;
        }

        public Task ReadAsync(byte[] buffer)
        {
            return Task.CompletedTask;
        }

        public async Task<int> Compute() // Noncompliant
        {
            return await Task.FromResult(1);
        }

        public void SaveAsync() // Noncompliant
        {
        }

        public override Task Flush()
        {
            return Task.CompletedTask;
        }

        public static async Task Main(string[] args)
        {
            await Task.Delay(1);
        }
    }
}
