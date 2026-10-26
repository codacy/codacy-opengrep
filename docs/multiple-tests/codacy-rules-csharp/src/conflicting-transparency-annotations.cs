using System.Security;

namespace MyLibrary
{
    [SecuritySafeCritical]
    public class Foo
    {
        [SecurityCritical] // Noncompliant
        public void Bar()
        {
        }
    }
}
