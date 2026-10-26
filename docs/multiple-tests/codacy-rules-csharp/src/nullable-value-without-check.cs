using System;

namespace Tests.Bugs
{
    class Nullables
    {
        void Sample(bool condition)
        {
            int? nullableValue = condition ? 42 : null;
            Console.WriteLine(nullableValue.Value); // Noncompliant
        }

        void Checked(bool condition)
        {
            int? nullableValue = condition ? 42 : null;
            if (nullableValue.HasValue)
            {
                Console.WriteLine(nullableValue.Value);
            }
        }

        void Direct()
        {
            int? empty = null;
            Console.WriteLine(empty.Value); // Noncompliant
        }
    }
}
