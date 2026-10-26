using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Tests.Azure
{
    public static class Functions
    {
        [FunctionName("HttpExample")]
        public static async Task<IActionResult> Run(HttpRequest req) // Noncompliant
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return new OkObjectResult(requestBody);
        }

        [FunctionName("Safe")]
        public static async Task<IActionResult> Safe(HttpRequest req, ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                return new OkObjectResult(requestBody);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Failed");
                throw;
            }
        }
    }
}
