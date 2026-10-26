using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tests.Practices
{
    public class A
    {
        public static string[] strings1 = { "first", "second" };  // Noncompliant
        public static readonly List<string> strings3 = new List<string>(); // Noncompliant
        public static readonly ReadOnlyCollection<string> fine = new ReadOnlyCollection<string>(new List<string>());
        private static string[] hidden = { "a" };
    }
}
