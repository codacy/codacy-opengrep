using Microsoft.Extensions.Logging;

namespace Tests.Naming
{
    public class Service
    {
        private readonly ILogger myLogger; // Noncompliant
        private readonly ILogger<Service> _logger;
        public ILogger MyLogger { get; set; } // Noncompliant
        private static readonly ILog Log = null;
    }
}
