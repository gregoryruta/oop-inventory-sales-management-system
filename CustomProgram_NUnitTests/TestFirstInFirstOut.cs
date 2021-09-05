using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomProgram;

namespace CustomProgram_NUnitTests
{
    public class TestFirstInFirstOut
    {
        private ProductList myProductList;
        private Inventory myInventory;
        private Ledger myLedger;
        private IProduct myBicycle;
        private Purchase myPurchase1;
        private Purchase myPurchase2;
        private Sale mySale;

        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            myInventory = new Inventory();
            myLedger = new Ledger();
            
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myProductList.Put(myBicycle);
            
            //buy 5 @ 1900
            myPurchase1 = new Purchase();
            myPurchase1.Execute(myBicycle, 5, 1900, myInventory, myLedger);

            //buy 5 @ 2000
            myPurchase2 = new Purchase();
            myPurchase2.Execute(myBicycle, 5, 2000, myInventory, myLedger);

            //sell 7 @ 2500
            mySale = new Sale();
            mySale.Execute(myInventory.Items[0], 7, 2500, myInventory, myLedger);
        }

        [Test]
        // Check that the bicycles purchased first @ $1900 were sold first
        public void TestInventory()
        {
            //should have 3 items left in inventory
            Assert.AreEqual(3, myInventory.Items.Count());
            
            //each with the latest cost price of 2000
            Assert.AreEqual(2000, myInventory.Items[0].CostPrice);
            Assert.AreEqual(2000, myInventory.Items[1].CostPrice);
            Assert.AreEqual(2000, myInventory.Items[2].CostPrice);
        }

    }
}
