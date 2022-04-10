using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class ItemPropertiesTests
    {
        private readonly ElementPropertiesModel elementProperties = new();

        [TestMethod]
        public void ItemProperties_ShouldHaveItemStackableSetToFalse_WhenPopulatedWithEmptyElementProperties()
        {
            // arrange
            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.IsFalse(itemProperties.IsStackable, "Expected the default value of stackable to be false");
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveItemStackableSetToTrue_WhenPopulatedCorrectElementProperties()
        {
            // arrange
            elementProperties.Add(ElementStrings.Properties.Item.Stackable, true);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.IsTrue(itemProperties.IsStackable);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveWeightValueSet_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Add(ElementStrings.Properties.Item.Weight.Value, 3);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(3, itemProperties.WeightValue);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveDefaultWeightUnit_WhenPropertyIsNotSet()
        {
            // arrange
            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, itemProperties.WeightUnit);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveWeightUnitSet_WhenPropertyIsSet()
        {
            // arrange
            var poundsUnit = "lb.";
            elementProperties.Add(ElementStrings.Properties.Item.Weight.Unit, poundsUnit);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(poundsUnit, itemProperties.WeightUnit);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveDefaultWeightIgnore_WhenPropertyIsNotSet()
        {
            // arrange
            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.IsFalse(itemProperties.WeightIgnore);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveWeightIgnoreSet_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Add(ElementStrings.Properties.Item.Weight.Ignore, true);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.IsTrue(itemProperties.WeightIgnore);
        }
    }
}