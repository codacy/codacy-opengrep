using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Tests.Security
{
    public class LoginExampleController
    {
        private const string key = "SecretSecretSecretSecretSecretSecret";

        public SymmetricSecurityKey Login()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); // Noncompliant
            var inline = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AnotherSecretAnotherSecret")); // Noncompliant
            return securityKey;
        }

        public SymmetricSecurityKey FromConfig(string configuredKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuredKey));
        }
    }
}
