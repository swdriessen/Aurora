using System;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class EquipmentPropertiesTests
    {
        private readonly ElementPropertiesModel properties = new();

        [TestMethod]
        public void ItemProperties_ShouldReturnDisplayCost_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(ElementConstants.Properties.ItemCost, 100);
            properties.Add(ElementConstants.Properties.ItemCostCurrency, "cp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("100 cp", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void ItemProperties_ShouldReturnDisplayCost_WhenProvidingACustomDisplayFormat()
        {
            // arrange
            properties.Add(ElementConstants.Properties.ItemCost, 1);
            properties.Add(ElementConstants.Properties.ItemCostCurrency, "gp");
            properties.Add(ElementConstants.Properties.ItemCostFormat, "{{item.cost}} {{item.cost.currency}} for a 10 pack");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("1 gp for a 10 pack", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void ItemProperties_ShouldThrowException_WhenUnknownDisplayFormatConstantsAreProvided()
        {
            // arrange
            properties.Add(ElementConstants.Properties.ItemCost, 1);
            properties.Add(ElementConstants.Properties.ItemCostCurrency, "gp");
            properties.Add(ElementConstants.Properties.ItemCostFormat, "{{item.cost.unknown}} format");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.ThrowsException<InvalidOperationException>(equipmentProperties.GetDisplayCost);
        }
    }
}