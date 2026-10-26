using System;
using System.Windows.Forms;

namespace Tests.Bugs
{
    public class MyForm : Form
    {
        static void Main() // Noncompliant
        {
            Application.Run(new MyForm());
        }
    }

    public class OtherForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new OtherForm());
        }
    }
}
