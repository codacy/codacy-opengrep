using System.Security.Cryptography;

namespace Tests.Security
{
    class Modes
    {
        public void Encrypt(byte[] dataToEncrypt)
        {
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB; // Noncompliant
            var rsaCsp = new RSACryptoServiceProvider(2048);
            byte[] encryptedData = rsaCsp.Encrypt(dataToEncrypt, false); // Noncompliant
            byte[] good = rsaCsp.Encrypt(dataToEncrypt, true);
            aes.Mode = CipherMode.CBC;
        }
    }
}
