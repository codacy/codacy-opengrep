using System;
using Microsoft.Extensions.Logging;

namespace Tests.Practices
{
    class Service
    {
        private readonly ILogger logger;

        void M()
        {
            try
            {
                Work();
            }
            catch (Exception ex) // Noncompliant
            {
                logger.LogError(ex.Message);
                throw;
            }

            try
            {
                Work();
            }
            catch (Exception ex)
            {
                logger.LogError("Failed");
                throw;
            }

            try
            {
                Work();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed");
                throw new InvalidOperationException("Work failed", ex);
            }
        }

        void Work() { }
    }
}
