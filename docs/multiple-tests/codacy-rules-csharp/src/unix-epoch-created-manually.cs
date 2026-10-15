using System;

namespace Tests.Practices
{
    class Epoch
    {
        void GetEpochTime()
        {
            var epochTime = new DateTime(1970, 1, 1); // Noncompliant
            var utcEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // Noncompliant
            var other = new DateTime(1971, 1, 1);
            var good = DateTime.UnixEpoch;
        }
    }
}
