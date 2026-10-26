using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bugs
{
    [TestClass]
    public class Asserts
    {
        [TestMethod]
        public void Exit()
        {
            var runner = new Runner();
            Assert.AreEqual(runner.ExitCode, 0, "Unexpected exit code"); // Noncompliant
            Assert.AreEqual(0, runner.ExitCode, "Unexpected exit code");
            Assert.AreEqual(runner.Name, "main"); // Noncompliant
        }
    }

    public class Runner
    {
        public int ExitCode { get; set; }
        public string Name { get; set; }
    }
}
