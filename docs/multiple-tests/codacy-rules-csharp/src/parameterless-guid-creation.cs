using System;

namespace Tests.Practices
{
    class Guids
    {
        void M()
        {
            var g1 = new Guid(); // Noncompliant
            Guid g2 = new(); // Noncompliant
            var g3 = Guid.NewGuid();
            var g4 = Guid.Empty;
        }
    }
}
