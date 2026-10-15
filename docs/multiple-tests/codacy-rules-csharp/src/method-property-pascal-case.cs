using System;
using System.Runtime.InteropServices;

namespace Tests.Naming
{
    public class Sample : BaseSample
    {
        public int doSomething() { return 1; } // Noncompliant
        public int DoSomething() { return 1; }
        void My_method_() { } // Noncompliant
        void _Leading() { } // Noncompliant
        void My_method() { }
        void MyXMethod() { }
        void XM() { } // Noncompliant
        void GetHTMLPage() { } // Noncompliant
        void GetHtmlPage() { }
        int compute() => 42; // Noncompliant
        int Compute() => 42;
        public int myProperty { get; set; } // Noncompliant
        public int MyProperty { get; set; }
        public override string toString() { return ""; }
        [DllImport("user32.dll")]
        static extern int messageBox(IntPtr h, string m, string c, int t);
    }
}
