using System.Diagnostics.CodeAnalysis;

namespace Tests.Practices
{
    public class Suppressions
    {
        [SuppressMessage("Usage", "CA1801")] // Noncompliant
        void M()
        {
#pragma warning disable CS0168 // Noncompliant
            int unused;
#pragma warning restore CS0168
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060")] // Noncompliant
        void N(int x) { }
    }
}
