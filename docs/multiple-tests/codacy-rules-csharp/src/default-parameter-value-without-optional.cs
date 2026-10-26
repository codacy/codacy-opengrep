using System;
using System.Runtime.InteropServices;

namespace Tests.Practices
{
    class Params
    {
        public void MyMethod([DefaultParameterValue(5)] int j) //Noncompliant
        {
            Console.WriteLine(j);
        }

        public void Fine([Optional, DefaultParameterValue(5)] int j)
        {
            Console.WriteLine(j);
        }
    }
}
