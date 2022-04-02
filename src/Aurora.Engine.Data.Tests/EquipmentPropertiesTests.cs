using Aurora.Engine.Data.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class EquipmentPropertiesTests
    {
        private ElementProperties properties = new();

        [TestMethod]
        public void EquipmentProperties_ShouldReturnCostValue_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Value, 15);

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
            Assert.IsFalse(properties.ContainsProperty(PropertyNames.Equipment.Cost.Value));
            Assert.AreEqual(0, equipmentProperties.GetEquipmentCostValue());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnCostCurrency_WhenValueProvided()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Currency, "gp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnTrimmedCostCurrency_WhenValueWithTrailingSpacesProvided()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Currency, " gp ");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("gp", equipmentProperties.GetEquipmentCostCurrency());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenPopulatedWithElementProperties()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Value, 100);
            properties.Add(PropertyNames.Equipment.Cost.Currency, "cp");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("100 cp", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldReturnDisplayCost_WhenProvidingACustomDisplayFormat()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Value, 1);
            properties.Add(PropertyNames.Equipment.Cost.Currency, "gp");
            properties.Add(PropertyNames.Equipment.Cost.DisplayFormat, "{{equipment.cost.value}} {{equipment.cost.currency}} for a 10 pack");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.AreEqual("1 gp for a 10 pack", equipmentProperties.GetDisplayCost());
        }

        [TestMethod]
        public void EquipmentProperties_ShouldThrowException_WhenUnknownDisplayFormatConstantsAreProvided()
        {
            // arrange
            properties.Add(PropertyNames.Equipment.Cost.Value, 1);
            properties.Add(PropertyNames.Equipment.Cost.Currency, "gp");
            properties.Add(PropertyNames.Equipment.Cost.DisplayFormat, "{{equipment.cost.unknown}} format");

            // act
            var equipmentProperties = new EquipmentProperties(properties);

            // assert
            Assert.ThrowsException<InvalidOperationException>(equipmentProperties.GetDisplayCost);
        }
    }
}