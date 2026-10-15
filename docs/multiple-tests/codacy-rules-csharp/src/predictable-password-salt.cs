using System.Security.Cryptography;
using System.Text;

namespace Tests.Security
{
    class Salts
    {
        public static void Hash(string password)
        {
            var salt = Encoding.UTF8.GetBytes("salty");
            var hashed = new Rfc2898DeriveBytes(password, salt, 600000, HashAlgorithmName.SHA256); // Noncompliant
        }

        public static void Good(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(32);
            var hashed = new Rfc2898DeriveBytes(password, salt, 600000, HashAlgorithmName.SHA256);
        }
    }
}
