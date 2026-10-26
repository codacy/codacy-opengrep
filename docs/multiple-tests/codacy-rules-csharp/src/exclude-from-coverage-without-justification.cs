using System.Diagnostics.CodeAnalysis;

namespace Tests.Practices
{
    public struct Coordinates
    {
        public int X { get; }
        public int Y { get; }

        [ExcludeFromCodeCoverage] // Noncompliant
        public override bool Equals(object obj) => obj is Coordinates;

        [ExcludeFromCodeCoverage(Justification = "Generated equality members")]
        public override int GetHashCode() => X ^ Y;
    }
}
