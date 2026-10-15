using System.Collections.Generic;

namespace Tests.Bugs
{
    public class LengthLimitedSingletonCollection<T> where T : new()
    {
        protected const int MaxAllowedLength = 5;
        protected static Dictionary<string, object> instances = new Dictionary<string, object>(); // Noncompliant
        private static Dictionary<string, T> cache = new Dictionary<string, T>();
        private static int counter; // Noncompliant
    }
}
