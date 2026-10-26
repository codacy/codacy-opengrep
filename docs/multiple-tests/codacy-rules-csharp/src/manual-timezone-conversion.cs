using System;
using TimeZoneConverter;

namespace Tests.Practices
{
    class Zones
    {
        void M()
        {
            var ianaTimeZone = "Asia/Tokyo";
            var windowsTimeZone = TZConvert.IanaToWindows(ianaTimeZone); // Noncompliant
            TimeZoneInfo tokyo = TimeZoneInfo.FindSystemTimeZoneById(ianaTimeZone);
        }
    }
}
