using System;
using System.Globalization;

namespace Tests.Bugs
{
    class Parsing
    {
        void M(string dateTimeString)
        {
            var dateTimeObject = DateTime.Parse(dateTimeString); // Noncompliant
            var exact = DateTime.ParseExact(dateTimeString, "yyyy-MM-dd", null); // Noncompliant
            var span = TimeSpan.Parse(dateTimeString); // Noncompliant
            var ok = DateTime.Parse(dateTimeString, CultureInfo.InvariantCulture);
            var ok2 = DateTime.ParseExact(dateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var number = int.Parse(dateTimeString);
        }
    }
}
