using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;

namespace Tests.Azure
{
    public static class Functions
    {
        [FunctionName("HttpExample")]
        public static IActionResult Run(HttpRequest req)
        {
            string requestBody = new StreamReader(req.Body).ReadToEndAsync().Result; // Noncompliant
            return new OkObjectResult(requestBody);
        }
    }
}
