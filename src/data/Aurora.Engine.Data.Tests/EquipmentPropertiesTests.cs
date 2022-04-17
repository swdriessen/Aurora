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
        public void EquipmentProperties_ShouldReturnCostValue_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCost, 15);

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual(15, equipmentProperties.GetEquipmentCostValue());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDefaultCostValue_WhenNoValueIsProvided()
        {
            // arrange
            // ...

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.IsFalse(properties.ContainsProperty(ElementStrings.Properties.ItemCost));
            Assert.AreEqual(0, equipmentProperties.GetEquipmentCostValue());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnCostCurrency_WhenValueProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCostCurrency, "gp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnTrimmedCostCurrency_WhenValueWithTrailingSpacesProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCostCurrency, " gp ");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCost, 100);
            properties.Add(ElementStrings.Properties.ItemCostCurrency, "cp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("100 cp", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenProvidingACustomDisplayFormat()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCost, 1);
            properties.Add(ElementStrings.Properties.ItemCostCurrency, "gp");
            properties.Add(ElementStrings.Properties.ItemCostFormat, "{{item.cost}} {{item.cost.currency}} for a 10 pack");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("1 gp for a 10 pack", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldThrowException_WhenUnknownDisplayFormatConstantsAreProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.ItemCost, 1);
            properties.Add(ElementStrings.Properties.ItemCostCurrency, "gp");
            properties.Add(ElementStrings.Properties.ItemCostFormat, "{{item.cost.unknown}} format");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.ThrowsException<InvalidOperationException>(equipmentProperties.GetDisplayCost);
        }
    }
}