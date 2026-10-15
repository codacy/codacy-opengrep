using System;

namespace Tests.Style
{
    public class Foo
    {
        public DateTime Date
        {
            get { return DateTime.Today; }
        }

        public string GetDate() // Noncompliant
        {
            return this.Date.ToString();
        }

        public string GetOther() => "x";
    }
}
