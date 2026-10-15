using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    public class PersonController : Controller // Noncompliant
    {
        public IActionResult Index(int? id) => View();

        [HttpGet(template: "{sortBy}/{direction}")]
        public IActionResult List(string sortBy, string direction) => View();
    }

    [Route("[controller]")]
    public class RoutedController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id) => View();
    }
}
