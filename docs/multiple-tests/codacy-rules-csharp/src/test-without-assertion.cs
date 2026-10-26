using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_SingleNumber_ReturnsSameNumber() // Noncompliant
        {
            var stringCalculator = new StringCalculator();
            var actual = stringCalculator.Add("0");
        }

        [TestMethod]
        public void Add_WithAssert()
        {
            var stringCalculator = new StringCalculator();
            var actual = stringCalculator.Add("0");
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Add_Nested()
        {
            var calculator = new StringCalculator();
            foreach (var input in new[] { "0", "1" })
            {
                Assert.IsTrue(calculator.Add(input) >= 0);
            }
        }
    }

    public class StringCalculator
    {
        public int Add(string s) => 0;
    }
}
