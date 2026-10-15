using System.Security.Cryptography;

namespace Tests.Security
{
    class Passwords
    {
        void M(string password, byte[] salt)
        {
            var kdf = new Rfc2898DeriveBytes(password, salt); // Noncompliant
            var kdf2 = new Rfc2898DeriveBytes(password, salt, 100, HashAlgorithmName.SHA256); // Noncompliant
            var good = new Rfc2898DeriveBytes(password, salt, 600000, HashAlgorithmName.SHA256);
        }
    }
}
