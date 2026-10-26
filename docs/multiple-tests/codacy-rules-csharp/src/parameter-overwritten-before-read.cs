using System;
using System.Collections.Generic;

namespace Tests.Bugs
{
    class Params
    {
        public void DoTheThing(string str, int i, List<string> strings)
        {
            str = i.ToString(i);  // Noncompliant
            Console.WriteLine(str);
        }

        public void Read(string str)
        {
            str = str.Trim();
            Console.WriteLine(str);
        }

        public void Out(out int value)
        {
            value = 1;
        }

        public void Catch()
        {
            try
            {
                Console.WriteLine();
            }
            catch (Exception e)
            {
                e = new Exception("x"); // Noncompliant
                throw e;
            }
        }
    }
}
