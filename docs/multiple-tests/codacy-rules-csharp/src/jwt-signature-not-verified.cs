using JWT;
using JWT.Builder;

namespace Tests.Security
{
    class Tokens
    {
        public static void Decode(IJwtDecoder decoder, string token, string secret)
        {
            decoder.Decode(token, secret, verify: false); // Noncompliant
            decoder.Decode(token, secret, verify: true);
            var json = new JwtBuilder()
                .WithSecret(secret)
                .Decode(token); // Noncompliant
            var verified = new JwtBuilder()
                .WithSecret(secret)
                .MustVerifySignature()
                .Decode(token);
        }
    }
}
