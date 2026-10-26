using System;
using System.Text;

namespace Tests.Bugs
{
    class Formats
    {
        void M(object arg0, object arg1, StringBuilder sb)
        {
            var s = string.Format("{0}}", arg0); // Noncompliant
            s = string.Format("{0} {1}", arg0); // Noncompliant
            s = string.Format("{0} {1}", arg0, arg1);
            s = string.Format("{{0}} {0}", arg0);
            s = string.Format("{0,-10:N2}", arg0);
            sb.AppendFormat("{1}", arg0); // Noncompliant
            s = string.Format("{0}"); // Noncompliant
            Console.WriteLine("{0}");
            Console.WriteLine("{2}", arg0, arg1); // Noncompliant
        }
    }
}
