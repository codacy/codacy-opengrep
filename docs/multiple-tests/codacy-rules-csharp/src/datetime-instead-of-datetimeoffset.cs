using System;

namespace Tests.Practices
{
    class Dates
    {
        void M()
        {
            DateTime myDate = new DateTime(2008, 6, 19, 7, 0, 0, DateTimeKind.Local); // Noncompliant
            var now = DateTime.Now; // Noncompliant
            var offset = DateTimeOffset.Now;
        }
    }
}
