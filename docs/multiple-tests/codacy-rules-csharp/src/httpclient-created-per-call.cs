using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    [ApiController]
    [Route("controller")]
    public class FooController : ControllerBase
    {
        private static readonly HttpClient Shared = new HttpClient();

        [HttpGet]
        public async Task<string> Foo()
        {
            using var client = new HttpClient(); // Noncompliant
            return await client.GetStringAsync("https://example.com");
        }
    }
}
