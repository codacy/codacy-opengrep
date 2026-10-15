using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class SleepTests
    {
        [TestMethod]
        public void SomeTest()
        {
            Thread.Sleep(500); // Noncompliant
            Assert.IsTrue(true);
        }

        public void Helper()
        {
            Thread.Sleep(10);
        }
    }
}
