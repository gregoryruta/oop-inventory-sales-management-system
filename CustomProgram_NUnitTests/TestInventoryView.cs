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
    public class TestInventoryView
    {
        private ProductList myProductList;
        private Inventory myInventory;
        private IProduct myBicycle;
        private IProduct myPart1;
        private IProduct myPart2;
        private IProduct myAccessory;
        private InventoryItem myInventoryItem1;
        private InventoryItem myInventoryItem2;
        private InventoryItem myInventoryItem3;
        private InventoryItem myInventoryItem4;
        private InventoryView myInventoryView;


        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myPart1 = new Part("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myPart2 = new Part("Campagnolo", "Chorus cassette", "Groupset Components", "11spd 12-29");
            myAccessory = new Accessory("Giro", "Synthe", "Helmets", "White");

            // "Putting" products to the product list generates their Skus
            myProductList.Put(myBicycle);
            myProductList.Put(myPart1);
            myProductList.Put(myPart2);
            myProductList.Put(myAccessory);

            // And we need their Skus to create inventory items of those products
            myInventoryItem1 = new InventoryItem(myBicycle.Sku, myBicycle.Category, 2500.55f);
            myInventoryItem2 = new InventoryItem(myPart1.Sku, myPart1.Category, 80.88f);
            myInventoryItem3 = new InventoryItem(myPart2.Sku, myPart2.Category, 103.99f);
            myInventoryItem4 = new InventoryItem(myAccessory.Sku, myAccessory.Category, 249.95f);

            myInventory = new Inventory();

            myInventory.Put(myInventoryItem1);
            myInventory.Put(myInventoryItem2);
            myInventory.Put(myInventoryItem3);
            myInventory.Put(myInventoryItem4);

            myInventoryView = new InventoryView(myProductList, myInventory);
        }

        [Test]
        public void TestInventoryViewResult()
        {
            string line1 = "All inventory items";
            string line2 = null;
            string line3 = "BICYCLES";
            string line4 = "G000001 | BRAND: Giant | NAME: Propel | TYPE: Road | RIDER: F | SIZE: M | COLOUR: Blue | STOCK COUNT: 1";
            string line5 = null;
            string line6 = "PARTS";
            string line7 = "S000002 | BRAND: Shimano | NAME: Ultegra rear deraileur | TYPE: Groupset Components | VARIANT: Medium cage | STOCK COUNT: 1";
            string line8 = "C000003 | BRAND: Campagnolo | NAME: Chorus cassette | TYPE: Groupset Components | VARIANT: 11spd 12-29 | STOCK COUNT: 1";
            string line9 = null;
            string line10 = "ACCESSORIES";
            string line11 = "G000004 | BRAND: Giro | NAME: Synthe | TYPE: Helmets | VARIANT: White | STOCK COUNT: 1";
            List<string> expectedResult;
            expectedResult = new List<string> { line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11 };
            Assert.AreEqual(expectedResult, myInventoryView.Execute());
        }
    }
}
