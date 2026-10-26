using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tests.Bugs
{
    class MyClass
    {
        [DefaultValue(5)]
        public int Size { get; set; }

        public void DoStuff([Optional][DefaultValue(4)] int i, int j = 5)  // Noncompliant
        {
            Console.WriteLine(i);
        }

        public void Fine([Optional][DefaultParameterValue(4)] int i)
        {
            Console.WriteLine(i);
        }
    }
}
