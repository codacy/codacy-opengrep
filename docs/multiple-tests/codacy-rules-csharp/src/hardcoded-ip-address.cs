using System.Net;

namespace Tests.Security
{
    class Addresses
    {
        void M()
        {
            var ip = "192.168.12.42"; // Noncompliant
            var address = IPAddress.Parse(ip);
            var withPort = "10.0.0.5:8080"; // Noncompliant
            var loopback = "127.0.0.1";
            var doc = "192.0.2.10";
            var oid = "2.5.4.3";
            var version = "1.2";
        }
    }
}
