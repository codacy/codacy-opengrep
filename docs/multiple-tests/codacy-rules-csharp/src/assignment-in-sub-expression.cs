using System;

namespace Tests.Style
{
    public class Assignments
    {
        private object instance;
        public object Instance => instance ?? (instance = new object());

        string M(string str, int index, int length, Func<int> f)
        {
            string result;
            int a, b, c;
            if (string.IsNullOrEmpty(result = str.Substring(index, length))) // Noncompliant
            {
                Use(a = 1); // Noncompliant
            }
            while ((index = Next()) > 0)
            {
                index--;
            }
            if ((c = Next()) != 0)
            {
                c++;
            }
            a = b = c = 10;
            var d = Use(() => { int x = 1; x = 2; return x; });
            return result = str; // Noncompliant
        }

        int Next() { return 0; }
        int Use(object o) { return 0; }
    }
}
