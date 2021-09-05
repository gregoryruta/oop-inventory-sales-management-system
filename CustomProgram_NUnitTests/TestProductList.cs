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
    public class TestProductList
    {
        private ProductList myProductList;
        private IProduct myBicycle;
        private IProduct myPart;
        private IProduct myAccessory;

        [SetUp]
        public void SetUp()
        {
            myProductList = new ProductList();
            //not using factory method pattern here. it has it's own test.
            myBicycle = new Bicycle("Giant", "Propel", "Road", "F", "M", "Blue");
            myPart = new Part("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myAccessory = new Accessory("Giro", "Synthe", "Helmets", "White");
            myProductList.Put(myBicycle);
            myProductList.Put(myPart);
            myProductList.Put(myAccessory);
        }

        [Test]
        public void TestProductListElements()
        {
            List<IProduct> expectedResult;
            expectedResult = new List<IProduct> { myBicycle, myPart, myAccessory };
            Assert.AreEqual(expectedResult, myProductList.Products);
        }

        [Test]
        public void TestProductCount()
        {
            Assert.AreEqual(3, myProductList.Products.Count());
        }

        [Test]
        public void TestProductSkus()
        {
            Assert.AreEqual("G000001", myBicycle.Sku);
            Assert.AreEqual("S000002", myPart.Sku);
            Assert.AreEqual("G000003", myAccessory.Sku);
        }
    }
}
