using System;
using System.Runtime.InteropServices;

namespace Tests.Bugs
{
    class MyClass
    {
        public void DoStuff([Optional] ref int i) // Noncompliant
        {
            Console.WriteLine(i);
        }

        public void Fine([Optional] int i)
        {
            Console.WriteLine(i);
        }
    }
}
