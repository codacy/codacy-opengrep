using System.IO;
using System.Security.Cryptography;

namespace Tests.Security
{
    class Encryption
    {
        public void Encrypt(byte[] key, byte[] dataToEncrypt, MemoryStream target)
        {
            var aes = Aes.Create();
            byte[] iv = new byte[16];
            var encryptor = aes.CreateEncryptor(key, iv); // Noncompliant

            var safe = Aes.Create();
            safe.GenerateIV();
            var good = safe.CreateEncryptor(key, safe.IV);
        }
    }
}
