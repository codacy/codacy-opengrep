using System.IO;
using System.Security.AccessControl;

namespace Tests.Security
{
    class Permissions
    {
        void M(FileSecurity fileSecurity)
        {
            var unsafeAccessRule = new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow); // Noncompliant
            fileSecurity.AddAccessRule(unsafeAccessRule);
            var safeRule = new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow);
        }
    }
}
