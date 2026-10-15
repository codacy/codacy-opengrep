using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Practices
{
    class Sums
    {
        void Add(List<int> list)
        {
            int total1 = unchecked(list.Sum());  // Noncompliant

            unchecked
            {
                int total2 = list.Sum();  // Noncompliant
                try
                {
                    int total3 = list.Sum();
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
