using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Practices
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]  // Noncompliant
        public void Method_NullParam()
        {
            var sut = new MyService();
            sut.Method(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingleLine()
        {
            new MyService().Method(null);
        }
    }

    public class MyService
    {
        public void Method(string s) { }
    }
}
