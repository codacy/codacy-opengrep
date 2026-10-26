using System;

namespace Tests.Bugs
{
    class Nulls
    {
        public void Method()
        {
            object myObject = null;
            Console.WriteLine(myObject.ToString()); // Noncompliant
        }

        public void Checked(object input)
        {
            if (input is null)
            {
                Console.WriteLine("null input");
            }
            Console.WriteLine(input.ToString()); // Noncompliant
        }

        public void Guarded(object input)
        {
            if (input == null)
            {
                return;
            }
            Console.WriteLine(input.ToString());
        }

        public void Reassigned()
        {
            object o = null;
            o = new object();
            Console.WriteLine(o.ToString());
        }

        public void Conditional()
        {
            string s = null;
            if (s != null)
            {
                Console.WriteLine(s.Length);
            }
        }
    }
}
