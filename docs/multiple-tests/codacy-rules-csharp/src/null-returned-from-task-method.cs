using System.Threading.Tasks;

namespace Tests.Bugs
{
    class Tasks
    {
        public Task DoFooAsync()
        {
            return null; // Noncompliant
        }

        public Task<object> GetFooAsync()
        {
            return null; // Noncompliant
        }

        public async Task<object> GetBarAsync()
        {
            await Task.Delay(1);
            return null;
        }

        public Task Fine()
        {
            return Task.CompletedTask;
        }
    }
}
