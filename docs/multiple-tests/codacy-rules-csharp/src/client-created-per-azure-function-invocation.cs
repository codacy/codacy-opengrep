using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;

namespace Tests.Azure
{
    public class HttpExample
    {
        private static readonly HttpClient shared = new HttpClient();

        [FunctionName("HttpExample")]
        public async Task<IActionResult> Run(HttpRequest req)
        {
            using var client = new HttpClient(); // Noncompliant
            var response = await client.GetAsync("https://example.com");
            var other = await shared.GetAsync("https://example.com");
            return new OkObjectResult(response.StatusCode);
        }
    }
}
