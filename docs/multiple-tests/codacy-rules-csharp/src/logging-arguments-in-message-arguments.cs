using System;
using Microsoft.Extensions.Logging;

namespace Tests.Bugs
{
    class Logging
    {
        private readonly ILogger logger;

        void M()
        {
            try
            {
                Work();
            }
            catch (Exception ex)
            {
                logger.LogDebug("An exception occured {Exception}.", ex); // Noncompliant
                logger.LogError(ex, "An exception occured.");
            }
        }

        void Work() { }
    }
}
