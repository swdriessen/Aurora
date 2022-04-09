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
    }
}