using System;
using System.Collections.Generic;

namespace Tests.Bugs
{
    static class Iterators
    {
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); } // Noncompliant
            foreach (var element in source)
            {
                if (!predicate(element)) break;
                yield return element;
            }
        }

        public static List<int> NotIterator(List<int> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            return source;
        }
    }
}
