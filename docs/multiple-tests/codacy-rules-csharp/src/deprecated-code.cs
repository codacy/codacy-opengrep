using System;

namespace Tests.Practices
{
    public class Legacy
    {
        [Obsolete] // Noncompliant
        void Method()
        {
        }

        [Obsolete("Use the new API")] // Noncompliant
        void Other()
        {
        }
    }
}
