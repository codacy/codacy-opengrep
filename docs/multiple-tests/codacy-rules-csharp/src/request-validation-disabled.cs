using System.Web.Mvc;

namespace Tests.Security
{
    public class HomeController : Controller
    {
        [ValidateInput(false)] // Noncompliant
        public ActionResult Welcome(string name)
        {
            return View();
        }

        [ValidateInput(true)]
        public ActionResult Safe(string name)
        {
            return View();
        }
    }
}
