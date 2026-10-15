using System.Security.Cryptography;

namespace Tests.Security
{
    public class CustomHash : HashAlgorithm // Noncompliant
    {
        private byte[] result;

        public override void Initialize() => result = null;
        protected override byte[] HashFinal() => result;
        protected override void HashCore(byte[] array, int ibStart, int cbSize) => result = array;
    }

    public class Wrapper
    {
        private readonly SHA256 sha = SHA256.Create();
    }
}
