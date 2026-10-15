using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Tests.Security
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage(); // Noncompliant
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
            }
        }
    }
}
