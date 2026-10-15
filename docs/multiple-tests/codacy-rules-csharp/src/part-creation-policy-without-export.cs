using System.ComponentModel.Composition;

namespace Tests.Bugs
{
    public interface IFooBar { }

    [PartCreationPolicy(CreationPolicy.Any)]
    public class FooBar : IFooBar // Noncompliant
    {
    }

    [Export(typeof(IFooBar))]
    [PartCreationPolicy(CreationPolicy.Any)]
    public class Exported : IFooBar
    {
    }
}
