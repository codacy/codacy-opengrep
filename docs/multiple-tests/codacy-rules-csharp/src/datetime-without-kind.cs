using System;

namespace Tests.Bugs
{
    class Dates
    {
        void CreateNewTime()
        {
            var birthDate = new DateTime(1994, 7, 5, 16, 23, 42); // Noncompliant
            var day = new DateTime(1994, 7, 5); // Noncompliant
            var utc = new DateTime(1994, 7, 5, 16, 23, 42, DateTimeKind.Utc);
        }
    }
}
