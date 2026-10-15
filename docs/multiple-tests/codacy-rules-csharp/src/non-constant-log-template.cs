using Microsoft.Extensions.Logging;

namespace Tests.Performance
{
    class Logging
    {
        private readonly ILogger logger;

        void M(int parameter)
        {
            logger.LogDebug($"The value of the parameter is: {parameter}."); // Noncompliant
            logger.LogInformation("Value: " + parameter); // Noncompliant
            logger.LogDebug("The value of the parameter is: {Parameter}.", parameter);
        }
    }
}
