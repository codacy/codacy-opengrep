using System.Security.Cryptography;

namespace Tests.Security
{
    class Hashes
    {
        void M()
        {
            var hashProvider1 = new MD5CryptoServiceProvider(); // Noncompliant
            var hashProvider2 = (HashAlgorithm)CryptoConfig.CreateFromName("MD5"); // Noncompliant
            var hashProvider3 = SHA1.Create(); // Noncompliant
            var good = SHA256.Create();
        }
    }
}
