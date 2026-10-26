using System;

namespace Tests.Practices
{
    public class MyEventArgs : EventArgs { }

    public delegate void MyEventHandler(object sender, MyEventArgs e); // Noncompliant

    public class EventProducer
    {
        public event MyEventHandler OnSomething;
        public event EventHandler<MyEventArgs> OnOther;
    }
}
