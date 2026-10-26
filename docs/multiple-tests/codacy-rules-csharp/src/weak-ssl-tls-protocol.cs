using System.Net;
using System.Net.Http;
using System.Security.Authentication;

namespace Tests.Security
{
    class Tls
    {
        public void Encrypt()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls; // Noncompliant
            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls11 // Noncompliant
            };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
