using System.DirectoryServices;

namespace Tests.Security
{
    class Ldap
    {
        void M(string adPath)
        {
            DirectoryEntry myDirectoryEntry = new DirectoryEntry(adPath);
            myDirectoryEntry.AuthenticationType = AuthenticationTypes.None; // Noncompliant
            DirectoryEntry other = new DirectoryEntry(adPath, "u", "p", AuthenticationTypes.None); // Noncompliant
            DirectoryEntry secure = new DirectoryEntry(adPath, "u", "p", AuthenticationTypes.Secure);
        }
    }
}
