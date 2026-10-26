using FluentAssertions;
using NFluent;

namespace Tests.Bugs
{
    class Assertions
    {
        void M()
        {
            string actual = "Using Fluent Assertions";
            actual.Should(); // Noncompliant
            Check.That(actual); // Noncompliant
            actual.Should().Be("Using Fluent Assertions");
            Check.That(actual).IsEqualTo("x");
        }
    }
}
