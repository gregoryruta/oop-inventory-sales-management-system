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
    public class TestProductListView
    {
        private ProductList myProductList;
        private Inventory myInventory;
        private IProduct myBicycle;
        private IProduct myPart1;
        private IProduct myPart2;
        private IProduct myAccessory;
        private ProductListView productListView;

        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            myInventory = new Inventory();
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myPart1 = new Part("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myPart2 = new Part("Campagnolo", "Chorus cassette", "Groupset Components", "11spd 12-29");
            myAccessory = new Accessory("Giro", "Synthe", "Helmets", "White");
            productListView = new ProductListView(myProductList, myInventory);

            myProductList.Put(myBicycle);
            myProductList.Put(myPart1);
            myProductList.Put(myPart2);
            myProductList.Put(myAccessory);
        }

        [Test]
        public void TestProductListViewResult()
        {   
            string line1 = "All registered products";
            string line2 = null;
            string line3 = "BICYCLES";
            string line4 = "G000001 | BRAND: Giant | NAME: Propel | TYPE: Road | RIDER: F | SIZE: M | COLOUR: Blue | STOCK COUNT: 0";
            string line5 = null;
            string line6 = "PARTS";
            string line7 = "S000002 | BRAND: Shimano | NAME: Ultegra rear deraileur | TYPE: Groupset Components | VARIANT: Medium cage | STOCK COUNT: 0";
            string line8 = "C000003 | BRAND: Campagnolo | NAME: Chorus cassette | TYPE: Groupset Components | VARIANT: 11spd 12-29 | STOCK COUNT: 0";
            string line9 = null;
            string line10 = "ACCESSORIES";
            string line11 = "G000004 | BRAND: Giro | NAME: Synthe | TYPE: Helmets | VARIANT: White | STOCK COUNT: 0";
            List<string> expectedResult;
            expectedResult = new List<string> { line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11 };
            Assert.AreEqual(expectedResult, productListView.Execute());
        }
    }
}
