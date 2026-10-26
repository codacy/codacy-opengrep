using System;

namespace Tests.Unused
{
    class UninvokedEventSample
    {
        private event Action<object, EventArgs> Happened; // Noncompliant
        public event EventHandler Raised;

        public void RegisterEventHandler(Action<object, EventArgs> handler)
        {
            Happened += handler;
        }

        public void Fire()
        {
            Raised?.Invoke(this, EventArgs.Empty);
        }
    }
}
