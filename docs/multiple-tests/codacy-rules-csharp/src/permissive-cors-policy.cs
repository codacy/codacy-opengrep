using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Security
{
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Get()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*"); // Noncompliant
            Response.Headers.Add("Access-Control-Allow-Origin", "https://trusted.example.com");
            return "value";
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin(); // Noncompliant
                });
            });
        }
    }
}
