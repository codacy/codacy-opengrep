using log4net;

namespace Tests.Practices
{
    public class Service
    {
        public ILog logger = LogManager.GetLogger(typeof(Service)); // Noncompliant
        private static readonly ILog Log = LogManager.GetLogger(typeof(Service));
    }
}
