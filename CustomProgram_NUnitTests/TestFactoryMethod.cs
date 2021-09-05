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
    public class TestFactoryMethod
    {
        private Creator myBicycleCreator;
        private Creator myPartCreator;
        private Creator myAccessoryCreator;
        private IProduct myBicycle;
        private IProduct myPart;
        private IProduct myAccessory;

        [SetUp]
        public void SetUp()
        {
            myBicycleCreator = new BicycleCreator("Giant", "Propel", "Road", "F", "M", "Blue");
            myBicycle = myBicycleCreator.GetProduct();
            myPartCreator = new PartCreator("Shimano", "Ultegra rear deraileur", "Groupset Components", "Medium cage");
            myPart = myPartCreator.GetProduct();
            myAccessoryCreator = new AccessoryCreator("Giro", "Synthe", "Helmets", "White");
            myAccessory = myAccessoryCreator.GetProduct();
        }

        [Test]
        public void TestMyBicycleDefaults()
        {
            Assert.IsNull((myBicycle as Bicycle).Sku);
            Assert.AreEqual("Bicycles", (myBicycle as Bicycle).Category);
            Assert.AreEqual("Giant", (myBicycle as Bicycle).Brand);
            Assert.AreEqual("Propel", (myBicycle as Bicycle).Name);
            Assert.AreEqual("Road", (myBicycle as Bicycle).Type);
            Assert.AreEqual("F", (myBicycle as Bicycle).Rider);
            Assert.AreEqual("M", (myBicycle as Bicycle).Size);
            Assert.AreEqual("Blue", (myBicycle as Bicycle).Colour);
        }

        [Test]
        public void TestMyPartDefaults()
        {
            Assert.IsNull((myPart as Part).Sku);
            Assert.AreEqual("Parts", (myPart as Part).Category);
            Assert.AreEqual("Shimano", (myPart as Part).Brand);
            Assert.AreEqual("Ultegra rear deraileur", (myPart as Part).Name);
            Assert.AreEqual("Groupset Components", (myPart as Part).Type);
            Assert.AreEqual("Medium cage", (myPart as Part).Variant);
        }

        [Test]
        public void TestMyAccessoryDefaults()
        {
            Assert.IsNull((myAccessory as Accessory).Sku);
            Assert.AreEqual("Accessories", (myAccessory as Accessory).Category);
            Assert.AreEqual("Giro", (myAccessory as Accessory).Brand);
            Assert.AreEqual("Synthe", (myAccessory as Accessory).Name);
            Assert.AreEqual("Helmets", (myAccessory as Accessory).Type);
            Assert.AreEqual("White", (myAccessory as Accessory).Variant);
        }
    }
}
