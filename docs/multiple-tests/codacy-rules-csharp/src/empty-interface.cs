using System;

namespace Tests.Practices
{
    public interface IFoo // Noncompliant
    {
    }

    public interface IAggregate : IComparable, IFormattable { }

    public interface IStringEquatable : IEquatable<string> { }

    [Obsolete]
    public interface ISorted { }

    public interface IFull
    {
        void Do();
    }
}
