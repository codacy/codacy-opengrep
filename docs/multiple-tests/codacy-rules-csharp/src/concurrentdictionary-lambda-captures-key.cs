using System.Collections.Concurrent;

namespace Tests.Performance
{
    class Caches
    {
        int UpdateValue(ConcurrentDictionary<int, int> dict, int key) =>
            dict.GetOrAdd(key, _ => key + 42); // Noncompliant

        int Good(ConcurrentDictionary<int, int> dict, int key) =>
            dict.GetOrAdd(key, x => x + 42);
    }
}
