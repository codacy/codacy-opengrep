using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Security
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => options.Filters.Add(new IgnoreAntiforgeryTokenAttribute())); // Noncompliant
        }
    }

    [IgnoreAntiforgeryToken] // Noncompliant
    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save() => Ok();
    }
}
