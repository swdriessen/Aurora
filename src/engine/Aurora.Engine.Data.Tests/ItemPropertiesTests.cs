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
            elementProperties.Add(ElementStrings.Properties.ItemStackable, true);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.IsTrue(itemProperties.IsStackable);
        }

        [TestMethod]
        public void ItemProperties_ShouldReturnDefaultRarity_WhenNotSet()
        {
            // arrange            
            // act
            var properties = new ItemProperties(elementProperties);

            // assert
            Assert.IsFalse(elementProperties.Contains("item.rarity"));
            Assert.AreEqual(string.Empty, properties.Rarity, "Expected the rarity to default to an empty string.");
        }

        [TestMethod]
        public void ItemProperties_ShouldReturnExpectedRarity_WhenValueProvided()
        {
            // arrange
            var rarity = "Very Rare";
            elementProperties.Add(ElementStrings.Properties.ItemRarity, rarity);

            // act
            var properties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(rarity, properties.Rarity);
        }

    }
}