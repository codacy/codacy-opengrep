using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests.Security
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(logging => // Noncompliant
            {
                logging.SetMinimumLevel(LogLevel.Debug);
            });
        }

        public void Configure(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(); // Noncompliant
        }
    }
}
