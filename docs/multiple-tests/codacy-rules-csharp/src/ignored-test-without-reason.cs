using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class Tests
    {
        [TestMethod] // Noncompliant@+1
        [Ignore]
        public void Test_DoTheThing()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Ignore] // Flaky on CI, see ticket 123
        public void Test_Explained()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Ignore]
        [WorkItem(1234)]
        public void Test_Tracked()
        {
            Assert.IsTrue(true);
        }
    }
}
