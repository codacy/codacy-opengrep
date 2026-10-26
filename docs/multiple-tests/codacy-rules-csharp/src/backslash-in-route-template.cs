using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    [Route(@"Something\[controller]")] // Noncompliant
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet("good/{id}")]
        public ActionResult Get(int id) => View();
    }
}
