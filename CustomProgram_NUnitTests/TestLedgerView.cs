using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomProgram;

namespace CustomProgram_NUnitTests
{
    public class TestLedgerView
    {
        private Inventory myInventory;
        private Ledger myLedger;
        private ProductList myProductList;
        private IProduct myBicycle;
        private Purchase myPurchase1;
        private Purchase myPurchase2;
        private Sale mySale;
        private LedgerView myLedgerQuery;

        [SetUp]
        public void SetUp()
        {
            myInventory = new Inventory();
            myLedger = new Ledger();
            myProductList = new ProductList();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myProductList.Put(myBicycle);

            myPurchase1 = new Purchase();
            myPurchase1.Execute(myBicycle, 5, 1900, myInventory, myLedger);

            myPurchase2 = new Purchase();
            myPurchase2.Execute(myBicycle, 5, 2000, myInventory, myLedger);

            mySale = new Sale();
            mySale.Execute(myInventory.Items[0], 7, 2500, myInventory, myLedger);

            myLedgerQuery = new LedgerView(myLedger);
        }

        [Test]
        public void TestLedgerViewResult()
        {
            string line1 = "All transactions";
            string line2 = null;
            string line3 = $"000001 | {StaticMethods.CurrentDateTime()} | BUY G000001 x 5 @ $1,900.00 / unit";
            string line4 = $"000002 | {StaticMethods.CurrentDateTime()} | BUY G000001 x 5 @ $2,000.00 / unit";
            string line5 = $"000003 | {StaticMethods.CurrentDateTime()} | SELL G000001 x 7 @ $2,500.00 / unit";
            List<string> expectedResult;
            expectedResult = new List<string> { line1, line2, line3, line4, line5 };
            Assert.AreEqual(expectedResult, myLedgerQuery.Execute());
        }
    }
}
