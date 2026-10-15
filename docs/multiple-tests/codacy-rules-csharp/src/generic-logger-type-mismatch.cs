using Microsoft.Extensions.Logging;

namespace Tests.Practices
{
    class AnotherType { }

    class EnclosingType
    {
        public EnclosingType(ILogger<AnotherType> logger) // Noncompliant
        {
        }
    }

    class Proper
    {
        public Proper(ILogger<Proper> logger)
        {
        }
    }
}
