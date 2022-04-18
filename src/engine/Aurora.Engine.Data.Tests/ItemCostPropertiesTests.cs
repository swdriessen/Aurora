using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class ItemCostPropertiesTests
    {
        private readonly ElementPropertiesModel elementProperties = new();

        [TestMethod]
        public void ItemProperties_ShouldHaveDefaultCostSet_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(0, itemProperties.Cost);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveCostSet_WhenPropertyIsSet()
        {
            // arrange
            var cost = 15;
            elementProperties.Add(ElementStrings.Properties.ItemCost, cost);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(cost, itemProperties.Cost);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveDefaultCostCurrency_WhenPropertyIsOmitted()
        {
            // arrange
            var defaultCurrency = "gp";

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(defaultCurrency, itemProperties.CostCurrency);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveCostCurrencySet_WhenPropertyIsSet()
        {
            // arrange
            var currency = "sp"; //non-default currency
            elementProperties.Add(ElementStrings.Properties.ItemCostCurrency, currency);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual(currency, itemProperties.CostCurrency);
        }

        [TestMethod]
        public void ItemProperties_ShouldHaveTrimmedCostCurrencySet_WhenPropertyWithTrailingSpacesIsSet()
        {
            // arrange
            var currency = " gp ";
            elementProperties.Add(ElementStrings.Properties.ItemCostCurrency, currency);

            // act
            var itemProperties = new ItemProperties(elementProperties);

            // assert
            Assert.AreEqual("gp", itemProperties.CostCurrency);
        }
    }
}