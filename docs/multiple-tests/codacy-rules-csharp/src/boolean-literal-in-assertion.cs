using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class Asserts
    {
        [TestMethod]
        public void M()
        {
            bool someResult = Compute();
            Assert.AreEqual(false, someResult); // Noncompliant
            Assert.AreEqual(true, someResult); // Noncompliant
            Assert.IsFalse(someResult);
        }

        bool Compute() => true;
    }
}
