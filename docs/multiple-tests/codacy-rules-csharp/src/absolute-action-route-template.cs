using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    [Route("[controller]")]
    public class ReviewsController : Controller // Noncompliant
    {
        [HttpGet("/reviews")]
        public ActionResult Index() => View();

        [HttpGet("/reviews/{id}")]
        public ActionResult Get(int id) => View();
    }

    [Route("[controller]")]
    public class MixedController : Controller
    {
        [HttpGet("/legacy")]
        public ActionResult Legacy() => View();

        [HttpGet("{id}")]
        public ActionResult Get(int id) => View();
    }
}
