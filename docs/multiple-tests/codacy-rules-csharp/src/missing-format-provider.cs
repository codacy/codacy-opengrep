using System;
using System.Globalization;

namespace MyLibrary
{
    public class Foo
    {
        public void Example(string input, decimal amount)
        {
            int number = int.Parse(input); // Noncompliant
            int other = int.Parse(input, CultureInfo.InvariantCulture);
            string text = amount.ToString("N2"); // Noncompliant
            string good = amount.ToString("N2", CultureInfo.InvariantCulture);
            Console.WriteLine(number + other + text + good);
        }
    }
}
