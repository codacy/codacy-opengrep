using Microsoft.Extensions.Logging;

namespace Tests.Style
{
    class Logins
    {
        void M(ILogger logger, string firstName)
        {
            logger.LogDebug("User {firstName} logged in", firstName); // Noncompliant
            logger.LogDebug("User {FirstName} logged in", firstName);
            logger.LogDebug("Escaped {{braces}} {0}", firstName);
        }
    }
}
