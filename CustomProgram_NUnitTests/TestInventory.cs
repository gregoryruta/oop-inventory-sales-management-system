using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomProgram;

namespace CustomProgram_NUnitTests
{
    public class TestInventory
    {
        private ProductList myProductList;
        private Inventory myInventory;
        private IProduct myBicycle;
        private IProduct myPart;
        private IProduct myAccessory;
        private InventoryItem myInventoryItem1;
        private InventoryItem myInventoryItem2;
        private InventoryItem myInventoryItem3;

        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myPart = new Part("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myAccessory = new Accessory("Giro", "Synthe", "Helmets", "White");

            // "Putting" products to the product list generates their Skus
            myProductList.Put(myBicycle);
            myProductList.Put(myPart);
            myProductList.Put(myAccessory);

            // And we need their Skus to create inventory items of those products
            myInventoryItem1 = new InventoryItem(myBicycle.Sku, myBicycle.GetType().Name, 2500.55f);
            myInventoryItem2 = new InventoryItem(myPart.Sku, myPart.GetType().Name, 80.88f);
            myInventoryItem3 = new InventoryItem(myAccessory.Sku, myAccessory.GetType().Name, 249.95f);

            myInventory = new Inventory();

            myInventory.Put(myInventoryItem1);
            myInventory.Put(myInventoryItem2);
            myInventory.Put(myInventoryItem3);
        }

        [Test]
        public void TestInventoryElements()
        {
            List<InventoryItem> expectedResult = new List<InventoryItem>() { myInventoryItem1, myInventoryItem2, myInventoryItem3 };
            Assert.AreEqual(expectedResult, myInventory.Items);
        }

        [Test]
        public void TestInventoryRemove()
        {
            myInventory.Remove(myInventoryItem1);
            myInventory.Remove(myInventoryItem2);
            myInventory.Remove(myInventoryItem3);
            Assert.IsFalse(myInventory.Items.Any());
        }

        [Test]
        public void TestInventoryItemCount()
        {
            Assert.AreEqual(3, myInventory.Items.Count());
        }
    }
}
