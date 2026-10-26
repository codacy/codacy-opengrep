using System.Security.Cryptography;

namespace Tests.Security
{
    class Keys
    {
        public void Encrypt()
        {
            var rsaCsp = new RSACryptoServiceProvider(); // Noncompliant
            var dsaCsp = new DSACryptoServiceProvider(); // Noncompliant
            var small = RSA.Create(1024); // Noncompliant
            ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.brainpoolP160t1); // Noncompliant
            var good = RSA.Create(2048);
            ECDsa goodCurve = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        }
    }
}
