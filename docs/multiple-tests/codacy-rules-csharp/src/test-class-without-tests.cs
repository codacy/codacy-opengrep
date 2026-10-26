using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class SomeOtherClassTest // Noncompliant
    {
    }

    [TestClass]
    public class RealTest
    {
        [TestMethod]
        public void Works()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public abstract class BaseTest
    {
    }

    [TestClass]
    public class Setup
    {
        [AssemblyInitialize]
        public static void Init(TestContext context) { }
    }
}
