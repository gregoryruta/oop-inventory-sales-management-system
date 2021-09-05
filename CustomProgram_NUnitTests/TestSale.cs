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
    public class TestSale
    {
        private Inventory myInventory;
        private Ledger myLedger;
        private ProductList myProductList;
        private IProduct myBicycle;
        private Purchase myPurchase;
        private Sale mySale;

        [SetUp]
        public void SetUp()
        {
            myInventory = new Inventory();
            myLedger = new Ledger();
            myProductList = new ProductList();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myProductList.Put(myBicycle);
            myPurchase = new Purchase();
            myPurchase.Execute(myBicycle, 7, 2000, myInventory, myLedger);
            mySale = new Sale();
            mySale.Execute(myInventory.Items[0], 3, 2500, myInventory, myLedger);
        }

        [Test]
        public void TestInventoryItem()
        {
            Assert.AreEqual(4, myInventory.Items.Count());
            Assert.AreEqual(myBicycle.Sku, myInventory.Items[0].Sku);
            Assert.AreEqual(myBicycle.Sku, myInventory.Items[3].Sku);
        }

        [Test]
        public void TestLedgerTransaction()
        {
            Assert.AreEqual(2, myLedger.Transactions.Count());
            Assert.AreEqual("BUY G000001 x 7 @ $2,000.00 / unit", myLedger.Transactions[0].Details);
            Assert.AreEqual("SELL G000001 x 3 @ $2,500.00 / unit", myLedger.Transactions[1].Details);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[1].Date);
        }

        [Test]
        public void TestInventorySellMore()
        {
            mySale = new Sale();
            mySale.Execute(myInventory.Items[0], 2, 2600, myInventory, myLedger);
            Assert.AreEqual(2, myInventory.Items.Count());
            Assert.AreEqual(myBicycle.Sku, myInventory.Items[1].Sku);
        }

        [Test]
        public void TestLedgerSellMore()
        {
            mySale = new Sale();
            mySale.Execute(myInventory.Items[0], 2, 2600, myInventory, myLedger);
            Assert.AreEqual(3, myLedger.Transactions.Count());
            Assert.AreEqual("BUY G000001 x 7 @ $2,000.00 / unit", myLedger.Transactions[0].Details);
            Assert.AreEqual("SELL G000001 x 3 @ $2,500.00 / unit", myLedger.Transactions[1].Details);
            Assert.AreEqual("SELL G000001 x 2 @ $2,600.00 / unit", myLedger.Transactions[2].Details);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[2].Date);
        }
    }
}
