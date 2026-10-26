using Microsoft.Extensions.Logging;

namespace Tests.Practices
{
    class AnotherType { }

    class EnclosingType
    {
        private readonly ILogger logger;

        public EnclosingType(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<AnotherType>(); // Noncompliant
            logger = loggerFactory.CreateLogger<EnclosingType>();
            logger = loggerFactory.CreateLogger("My cross-type logging category");
        }
    }
}
