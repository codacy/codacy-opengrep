using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Emptiness
    {
        private static bool HasContent(IEnumerable<string> strings)
        {
            return strings.Count() > 0;  // Noncompliant
        }

        private static bool IsEmpty(IEnumerable<string> strings)
        {
            return strings.Count() == 0; // Noncompliant
        }

        private static bool HasMany(IEnumerable<string> strings)
        {
            return strings.Count() > 1 || strings.Any();
        }
    }
}
