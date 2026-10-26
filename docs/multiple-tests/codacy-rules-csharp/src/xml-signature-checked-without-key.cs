using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Tests.Security
{
    class Signatures
    {
        bool M(XmlDocument xmlDoc, X509Certificate2 trusted)
        {
            SignedXml signedXml = new SignedXml(xmlDoc);
            bool valid = signedXml.CheckSignature(); // Noncompliant
            bool good = signedXml.CheckSignature(trusted, true);
            return valid && good;
        }
    }
}
