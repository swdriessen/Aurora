using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class EquipmentPropertiesTests
    {
        private ElementPropertiesModel properties = new();

        [TestMethod]
        public void EquipmentProperties_ShouldReturnCostValue_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Value, 15);
            
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
            Assert.IsFalse(properties.ContainsProperty(ElementStrings.Properties.Item.Cost.Value));
            Assert.AreEqual(0, equipmentProperties.GetEquipmentCostValue());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnCostCurrency_WhenValueProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Currency, "gp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnTrimmedCostCurrency_WhenValueWithTrailingSpacesProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Currency, " gp ");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Value, 100);
            properties.Add(ElementStrings.Properties.Item.Cost.Currency, "cp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("100 cp", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenProvidingACustomDisplayFormat()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Value, 1);
            properties.Add(ElementStrings.Properties.Item.Cost.Currency, "gp");
            properties.Add(ElementStrings.Properties.Item.Cost.DisplayFormat, "{{item.cost.value}} {{item.cost.currency}} for a 10 pack");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("1 gp for a 10 pack", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldThrowException_WhenUnknownDisplayFormatConstantsAreProvided()
        {
            // arrange
            properties.Add(ElementStrings.Properties.Item.Cost.Value, 1);
            properties.Add(ElementStrings.Properties.Item.Cost.Currency, "gp");
            properties.Add(ElementStrings.Properties.Item.Cost.DisplayFormat, "{{item.cost.unknown}} format");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.ThrowsException<InvalidOperationException>(equipmentProperties.GetDisplayCost);
        }
    }
}