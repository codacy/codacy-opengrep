using System;

namespace Tests.Bugs
{
    public class Foo
    {
        [ThreadStatic]
        public static object PerThreadObject = new object(); // Noncompliant

        [ThreadStatic]
        private static object lazy;

        public static object Lazy => lazy ??= new object();
    }
}
