using System;

namespace Tests.Bugs
{
    public class MyClass
    {
        [ThreadStatic]  // Noncompliant@+1
        private int count = 0;

        [ThreadStatic]
        private static int staticCount;
    }
}
