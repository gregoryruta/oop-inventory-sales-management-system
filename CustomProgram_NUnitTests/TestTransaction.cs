using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomProgram;

namespace CustomProgram_NUnitTests
{
    [TestFixture]
    public class TestTransaction
    {
        private Transaction myTransaction;

        [SetUp]
        public void SetUp()
        {
            myTransaction = new Transaction(StaticMethods.CurrentDateTime(), "This is a test transaction");
        }

        [Test]
        public void TestDefaults()
        {
            Assert.AreEqual("This is a test transaction", myTransaction.Details);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myTransaction.Date);
        }
    }
}
