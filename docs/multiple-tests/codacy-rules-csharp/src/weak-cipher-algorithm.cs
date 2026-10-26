using System.Security.Cryptography;

namespace Tests.Security
{
    class Ciphers
    {
        public void Encrypt()
        {
            var simpleDES = new DESCryptoServiceProvider(); // Noncompliant
            var tripleDes = TripleDES.Create(); // Noncompliant
            var aes = Aes.Create();
        }
    }
}
