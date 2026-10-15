using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Tests.Azure
{
    public static class HttpExample
    {
        private static readonly int port = 2000;
        private static int numOfRequests = 1;

        [FunctionName("HttpExample")]
        public static async Task<IActionResult> Run(HttpRequest request, ILogger log)
        {
            numOfRequests += 1; // Noncompliant
            log.LogInformation($"Number of POST requests is {numOfRequests}.");
            string responseMessage = $"HttpRequest was made on port {port}.";
            await Task.Yield();
            return new OkObjectResult(responseMessage);
        }
    }
}
