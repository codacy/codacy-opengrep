using System;

namespace Tests.Bugs
{
    class Events
    {
        event EventHandler myEvent;

        void DoWork()
        {
            myEvent += (s, e) => Console.WriteLine($"Event raised with sender {s}");
            myEvent -= (s, e) => Console.WriteLine($"Event raised with sender {s}"); // Noncompliant
            myEvent += Handler;
            myEvent -= Handler;
            myEvent -= delegate (object s, EventArgs e) { }; // Noncompliant
        }

        void Handler(object s, EventArgs e) { }
    }
}
