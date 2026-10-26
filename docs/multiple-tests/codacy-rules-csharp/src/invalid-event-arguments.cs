using System;

namespace Tests.Bugs
{
    class Foo
    {
        public event EventHandler ThresholdReached;
        public static event EventHandler StaticEvent;

        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(null, e); // Noncompliant
            ThresholdReached?.Invoke(this, null); // Noncompliant
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }

        static void OnStatic()
        {
            StaticEvent?.Invoke(null, EventArgs.Empty);
        }
    }
}
