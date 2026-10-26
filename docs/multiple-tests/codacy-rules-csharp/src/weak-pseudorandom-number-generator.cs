using System;
using System.Security.Cryptography;

namespace Tests.Security
{
    class Tokens
    {
        string M()
        {
            var random = new Random(); // Noncompliant
            byte[] data = new byte[16];
            random.NextBytes(data);
            var secure = RandomNumberGenerator.GetBytes(16);
            return BitConverter.ToString(data) + BitConverter.ToString(secure);
        }
    }
}
