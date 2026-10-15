using System.Windows.Forms;

namespace MyLibrary
{
    public class Foo
    {
        public void SetHour(int hour, Label label)
        {
            if (hour < 0 || hour > 23)
            {
                MessageBox.Show("The valid range is 0 - 23."); // Noncompliant
            }
            label.Text = "Hour selected"; // Noncompliant
            MessageBox.Show(Resources.Message);
        }
    }

    public static class Resources
    {
        public static string Message => "x";
    }
}
