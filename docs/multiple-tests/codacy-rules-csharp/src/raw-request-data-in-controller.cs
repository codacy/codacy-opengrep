using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    public class PeopleController : Controller
    {
        public IActionResult Post()
        {
            var name = Request.Form["name"]; // Noncompliant
            var birthdate = Request.Query["birthdate"]; // Noncompliant
            return Ok(name + birthdate);
        }

        public IActionResult Bound(string name)
        {
            return Ok(name);
        }
    }
}
