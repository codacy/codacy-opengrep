using System;

namespace Tests.Bugs
{
    public delegate void AlarmEventHandler(object s);
    public delegate void GoodEventHandler(object sender, EventArgs e);

    public class Foo
    {
        public event AlarmEventHandler AlarmEvent; // Noncompliant
        public event GoodEventHandler GoodEvent;
        public event EventHandler Standard;
    }
}
