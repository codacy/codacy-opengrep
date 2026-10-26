using System;
using System.Globalization;

namespace Tests.Practices
{
    class Formats
    {
        void PrintTime(DateTime date)
        {
            Console.WriteLine(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")); // Noncompliant
            Console.WriteLine(date.ToString("yyyy-MM-dd")); // Noncompliant
            Console.WriteLine(DateTime.UtcNow.ToString("d"));
            Console.WriteLine(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
        }
    }
}
