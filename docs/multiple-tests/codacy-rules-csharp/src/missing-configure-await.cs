using System.Net.Http;
using System.Threading.Tasks;

namespace Tests.Performance
{
    class Client
    {
        async Task<string> Get(HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url); // Noncompliant
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            await Task.Yield();
            return body;
        }
    }
}
