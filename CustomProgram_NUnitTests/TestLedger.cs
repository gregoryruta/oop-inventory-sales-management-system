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
    public class TestLedger
    {
        private Ledger myLedger;
        private Transaction myTransaction1;
        private Transaction myTransaction2;
        private Transaction myTransaction3;

        [SetUp]
        public void SetUp()
        {
            myLedger = new Ledger();
            myTransaction1 = new Transaction(StaticMethods.CurrentDateTime(), "This is my first transaction");
            myTransaction2 = new Transaction(StaticMethods.CurrentDateTime(), "This is my second transaction");
            myTransaction3 = new Transaction(StaticMethods.CurrentDateTime(), "This is my third transaction");
            myLedger.Put(myTransaction1);
            myLedger.Put(myTransaction2);
            myLedger.Put(myTransaction3);
        }

        [Test]
        public void TestLedgerElements()
        {
            List<Transaction> expectedResult;
            expectedResult = new List<Transaction> { myTransaction1, myTransaction2, myTransaction3 };
            Assert.AreEqual(expectedResult, myLedger.Transactions);
        }

        [Test]
        public void TestTransactionCount()
        {
            Assert.AreEqual(3, myLedger.Transactions.Count);
        }

        [Test]
        public void TestTransactionIds()
        {
            Assert.AreEqual("000001", myTransaction1.Id);
            Assert.AreEqual("000002", myTransaction2.Id);
            Assert.AreEqual("000003", myTransaction3.Id);
        }

        [Test]
        public void TestTransactionDates()
        {
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myTransaction1.Date);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myTransaction2.Date);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myTransaction3.Date);
        }
    }
}
