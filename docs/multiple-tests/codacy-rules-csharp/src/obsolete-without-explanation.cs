using System;

namespace Tests.Practices
{
    public class Car
    {
        [Obsolete]  // Noncompliant
        public void CrankEngine(int turnsOfCrank) { }

        [Obsolete("Use Start() instead")]
        public void Crank() { }

        [Serializable, Obsolete()] // Noncompliant
        public class Old { }
    }
}
