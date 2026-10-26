using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bugs
{
    [TestClass]
    public class Signatures
    {
        [TestMethod]
        void TestNullArg()  // Noncompliant
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async void MyIgnoredTestMethod()  // Noncompliant
        {
            await Task.Delay(1);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Fine()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task FineAsync()
        {
            await Task.Delay(1);
            Assert.IsTrue(true);
        }
    }
}
