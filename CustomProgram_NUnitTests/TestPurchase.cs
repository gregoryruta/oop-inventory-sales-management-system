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
    public class TestPurchase
    {
        private ProductList myProductList;
        private Inventory myInventory;
        private Ledger myLedger;
        private IProduct myBicycle;
        private IProduct myPart;
        private IProduct myAccessory;
        private Purchase myPurchase1;
        private Purchase myPurchase2;
        private Purchase myPurchase3;
        private Purchase myPurchase4;

        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            myInventory = new Inventory();
            myLedger = new Ledger();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myPart = new Part("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myAccessory = new Accessory("Giro", "Synthe", "Helmets", "White");

            myProductList.Put(myBicycle);
            myProductList.Put(myPart);
            myProductList.Put(myAccessory);

            myPurchase1 = new Purchase();
            myPurchase1.Execute(myBicycle, 5, 1995.67f, myInventory, myLedger);

            myPurchase2 = new Purchase();
            myPurchase2.Execute(myPart, 3, 50.55f, myInventory, myLedger);

            myPurchase3 = new Purchase();
            myPurchase3.Execute(myAccessory, 2, 19.95f, myInventory, myLedger);
        }

        [Test]
        public void TestInventoryItem()
        {
            Assert.AreEqual(10, myInventory.Items.Count());
            Assert.AreEqual(myBicycle.Sku, myInventory.Items[0].Sku);
            Assert.AreEqual(myPart.Sku, myInventory.Items[5].Sku);
            Assert.AreEqual(myAccessory.Sku, myInventory.Items[8].Sku);
            Assert.AreEqual(1995.67f, myInventory.Items[0].CostPrice);
            Assert.AreEqual(50.55f, myInventory.Items[5].CostPrice);
            Assert.AreEqual(19.95f, myInventory.Items[8].CostPrice);
        }

        [Test]
        public void TestLedgerTransaction()
        {
            Assert.AreEqual(3, myLedger.Transactions.Count());
            Assert.AreEqual("BUY G000001 x 5 @ $1,995.67 / unit", myLedger.Transactions[0].Details);
            Assert.AreEqual("BUY S000002 x 3 @ $50.55 / unit", myLedger.Transactions[1].Details);
            Assert.AreEqual("BUY G000003 x 2 @ $19.95 / unit", myLedger.Transactions[2].Details);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[0].Date);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[1].Date);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[2].Date);
        }

        [Test]
        public void TestInventoryPurchaseMore()
        {
            myPurchase4 = new Purchase();
            myPurchase4.Execute(myBicycle, 2, 2100.05f, myInventory, myLedger);
            Assert.AreEqual(12, myInventory.Items.Count());
            Assert.AreEqual(myBicycle.Sku, myInventory.Items[10].Sku);
            Assert.AreEqual(2100.05f, myInventory.Items[10].CostPrice);
        }

        [Test]
        public void TestLedgerPurchaseMore()
        {
            myPurchase4 = new Purchase();
            myPurchase4.Execute(myBicycle, 2, 2100.05f, myInventory, myLedger);
            Assert.AreEqual(4, myLedger.Transactions.Count());
            Assert.AreEqual("BUY G000001 x 2 @ $2,100.05 / unit", myLedger.Transactions[3].Details);
            Assert.AreEqual(StaticMethods.CurrentDateTime(), myLedger.Transactions[3].Date);
        }
    }
}
