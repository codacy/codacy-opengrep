using System;

namespace Tests.Bugs
{
    abstract class Car
    {
        public virtual event EventHandler OnRefuel; // Noncompliant
        public event EventHandler OnStart;

        private EventHandler stopHandlers;
        public virtual event EventHandler OnStop
        {
            add { stopHandlers += value; }
            remove { stopHandlers -= value; }
        }
    }
}
