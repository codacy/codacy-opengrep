using System.ComponentModel.Composition;

namespace Tests.Bugs
{
    public interface ISomeType { }

    [Export(typeof(ISomeType))]
    public class SomeType // Noncompliant
    {
    }

    [Export(typeof(ISomeType))]
    public class Implementer : ISomeType
    {
    }
}
