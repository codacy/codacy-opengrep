using Microsoft.AspNetCore.Mvc;

namespace Tests.Security
{
    public class MyController : Controller
    {
        [HttpPost]
        [DisableRequestSizeLimit] // Noncompliant
        public IActionResult PostRequest() => Ok();

        [HttpPost]
        [RequestSizeLimit(10485760)] // Noncompliant
        public IActionResult PostLarge() => Ok();

        [HttpPost]
        [RequestSizeLimit(8000000)]
        public IActionResult PostSmall() => Ok();
    }
}
