using System.Runtime.InteropServices;

namespace MyLibrary
{
    class Foo
    {
        [DllImport("mynativelib")]
        extern public static void Bar(string s, int x); // Noncompliant

        [DllImport("mynativelib")]
        extern private static void Baz(string s, int x);

        public void SafeBaz(string s)
        {
            if (s != null)
            {
                Baz(s, 1);
            }
        }
    }
}
