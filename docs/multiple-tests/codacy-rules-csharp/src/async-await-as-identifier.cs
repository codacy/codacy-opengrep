using System.Threading.Tasks;

namespace Tests.Practices
{
    public class Keywords
    {
        public async Task M()
        {
            int await = 42; // Noncompliant
            int async = 42; // Noncompliant
            await Task.Delay(await);
            var result = await Compute();
        }

        void N(string await) // Noncompliant
        {
        }

        async Task<int> Compute() { return await Task.FromResult(1); }
    }
}
