using System.Net;
using System.Net.Http;

namespace Tests.Security
{
    class Certificates
    {
        public static void Connect()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true; // Noncompliant
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; // Noncompliant
            var safe = new HttpClientHandler();
        }
    }
}
