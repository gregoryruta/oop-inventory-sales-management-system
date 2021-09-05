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
    public class TestStaticMethods
    {
        private Inventory myInventory;
        private Ledger myLedger;
        private ProductList myProductList;
        private IProduct myBicycle;
        private Purchase myPurchase1;
        private Purchase myPurchase2;

        [SetUp]
        public void SetUp()
        {
            myInventory = new Inventory();
            myLedger = new Ledger();
            myProductList = new ProductList();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myProductList.Put(myBicycle);
            myPurchase1 = new Purchase();
            myPurchase1.Execute(myBicycle, 5, 2000, myInventory, myLedger);
            myPurchase2 = new Purchase();
            myPurchase2.Execute(myBicycle, 2, 2500, myInventory, myLedger);
        }

        [Test]
        public void TestGetInventoryItemCount()
        {
            Assert.AreEqual(7, StaticMethods.GetInventoryItemCount(myInventory.Items[0].Sku, myInventory));
        }

        [Test]
        public void TestGetProductFromSku()
        {
            Assert.AreEqual(myBicycle, StaticMethods.GetProductFromSku("G000001", myProductList));
            Assert.IsNull(StaticMethods.GetProductFromSku("RandomSKU", myProductList));
        }
    }
}
