using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    [ApiController]
    public class MyController : Controller // Noncompliant
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }

    [ApiController]
    public class ViewController : Controller
    {
        [HttpGet]
        public IActionResult Get() => View();
    }

    [ApiController]
    public class GoodController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
