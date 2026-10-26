using System.Net.Mail;

namespace Tests.Security
{
    class Protocols
    {
        void M()
        {
            var urlHttp = "http://example.com";                 // Noncompliant
            var urlFtp = "ftp://anonymous@example.com";         // Noncompliant
            var urlTelnet = "telnet://anonymous@example.com";   // Noncompliant
            var local = "http://localhost:8080/api";
            var ns = "http://www.w3.org/2001/XMLSchema";
            var secure = "https://example.com";
            using var smtp = new SmtpClient("host", 25);
            smtp.EnableSsl = false; // Noncompliant
        }
    }
}
