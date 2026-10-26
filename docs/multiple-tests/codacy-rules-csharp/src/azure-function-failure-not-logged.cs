using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Tests.Azure
{
    public static class Functions
    {
        [FunctionName("Foo")]
        public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
        {
            try
            {
                await Task.Yield();
            }
            catch (InvalidOperationException ex) // Noncompliant
            {
                log.LogDebug("Something failed");
            }
            try
            {
                await Task.Yield();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Give details that will help investigations");
            }
            return new OkResult();
        }
    }
}
