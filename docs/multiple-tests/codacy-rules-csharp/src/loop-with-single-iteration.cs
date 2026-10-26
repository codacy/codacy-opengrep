using System;
using System.Collections.Generic;

namespace Tests.Practices
{
    class Loops
    {
        public object Method(IEnumerable<object> items)
        {
            for (int i = 0; i < 10; i++) // Noncompliant
            {
                Console.WriteLine(i);
                break;
            }

            foreach (var item in items) // Noncompliant
            {
                return item;
            }

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }
                return item;
            }

            while (items != null)
            {
                if (Check())
                {
                    break;
                }
            }
            return null;
        }

        bool Check() { return true; }
    }
}
