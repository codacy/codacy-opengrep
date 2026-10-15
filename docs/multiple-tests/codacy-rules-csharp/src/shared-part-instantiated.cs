using System.ComponentModel.Composition;

namespace Tests.Bugs
{
    [Export(typeof(IFooBar))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class FooBar : IFooBar
    {
    }

    public interface IFooBar { }

    public class Program
    {
        public static void Main()
        {
            var fooBar = new FooBar(); // Noncompliant
        }
    }
}
