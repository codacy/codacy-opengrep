using System.Runtime.InteropServices;

namespace MyLibrary
{
    public class Foo
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool RemoveDirectory(string name);  // Noncompliant

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateDirectory(string name, System.IntPtr attributes);
    }
}
