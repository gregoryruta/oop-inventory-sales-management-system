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
    public class TestInventoryItem
    {
        private ProductList myProductList;
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
        }

        [Test]
        public void TestMyBicycleDefaults()
        {
            Assert.AreEqual("G000001", myInventoryItem1.Sku);
            Assert.AreEqual("Bicycle", myInventoryItem1.Category);
            Assert.AreEqual(2500.55f, myInventoryItem1.CostPrice);
        }

        [Test]
        public void TestMyPartDefaults()
        {
            Assert.AreEqual("S000002", myInventoryItem2.Sku);
            Assert.AreEqual("Part", myInventoryItem2.Category);
            Assert.AreEqual(80.88f, myInventoryItem2.CostPrice);
        }

        [Test]
        public void TestMyAccessoryDefaults()
        {
            Assert.AreEqual("G000003", myInventoryItem3.Sku);
            Assert.AreEqual("Accessory", myInventoryItem3.Category);
            Assert.AreEqual(249.95f, myInventoryItem3.CostPrice);
        }
    }
}
