using System.Collections.Generic;

namespace Tests.Bugs
{
    public class Monument
    {
        public static readonly List<Monument> ALL_MONUMENTS = new List<Monument>();
        private readonly string location;

        public Monument(string location, Registry registry)
        {
            ALL_MONUMENTS.Add(this); // Noncompliant
            registry.Owner = this; // Noncompliant
            this.location = location;
        }

        public void Register()
        {
            ALL_MONUMENTS.Add(this);
        }
    }

    public class Registry
    {
        public Monument Owner { get; set; }
    }
}
