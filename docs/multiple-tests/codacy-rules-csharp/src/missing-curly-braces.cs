using System.Collections.Generic;

namespace Tests.Style
{
    public class Braces
    {
        void M(bool condition, List<int> items, int n)
        {
            if (condition) // Noncompliant
                ExecuteSomething();
            if (condition) { ExecuteSomething(); }
            if (condition)
            {
                ExecuteSomething();
            }
            else if (n > 2)
            {
                ExecuteSomething();
            }
            else
                ExecuteSomething(); // Noncompliant
            while (n-- > 0) // Noncompliant
                ExecuteSomething();
            while (n++ < 3)
            {
                ExecuteSomething();
            }
            foreach (var item in items) // Noncompliant
                ExecuteSomething();
            foreach (var item in items)
            {
                ExecuteSomething();
            }
            for (int i = 0; i < n; i++) ExecuteSomething(); // Noncompliant
            for (int i = 0; i < n; i++)
            {
                ExecuteSomething();
            }
            do // Noncompliant
                ExecuteSomething();
            while (condition);
            do
            {
                ExecuteSomething();
            } while (condition);
        }

        void ExecuteSomething() { }
    }
}
