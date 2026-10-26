using System;

namespace Tests.Bugs
{
    class Unexpected : IDisposable
    {
        public string Name { get; set; }

        static Unexpected()
        {
            throw new InvalidOperationException(); // Noncompliant
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException(nameof(Name));  // Noncompliant
            }
            return Name;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is Unexpected;
        }

        public void Dispose()
        {
            throw new InvalidOperationException(); // Noncompliant
        }

        private EventHandler handlers;
        public event EventHandler Changed
        {
            add { throw new NotSupportedException(); }
            remove { handlers -= value; }
        }
    }
}
