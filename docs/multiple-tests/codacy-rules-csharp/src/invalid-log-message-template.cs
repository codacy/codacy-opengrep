using Microsoft.Extensions.Logging;

namespace Tests.Bugs
{
    class Logging
    {
        private readonly ILogger logger;

        void M(int cnt, string user)
        {
            logger.LogDebug("Retry attempt {Cnt,r}", cnt); // Noncompliant
            logger.LogError("Login failed for {User-Name}", user); // Noncompliant
            logger.LogError("Login failed for {UserName}", user);
            logger.LogDebug("Retry attempt {Cnt,5:N0} {{escaped}}", cnt);
        }
    }
}
