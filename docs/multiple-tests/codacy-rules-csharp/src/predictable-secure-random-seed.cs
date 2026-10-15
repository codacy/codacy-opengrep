using Org.BouncyCastle.Security;

namespace Tests.Security
{
    class Seeds
    {
        void M()
        {
            byte[] random = new byte[8];
            SecureRandom sr = SecureRandom.GetInstance("SHA256PRNG", false); // Noncompliant
            sr.SetSeed(42); // Noncompliant
            sr.NextBytes(random);
            SecureRandom good = SecureRandom.GetInstance("SHA256PRNG");
        }
    }
}
