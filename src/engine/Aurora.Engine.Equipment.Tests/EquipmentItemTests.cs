using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Equipment.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class EquipmentItemTests
    {
        private readonly ElementModel weaponElement = new() { Name = "Longsword" };
        private readonly ElementModel potionElement = new() { Name = "Potion of Healing" };
        private readonly ElementModel packageElement = new() { Name = "Item Package" };

        [TestInitialize]
        public void Initialize()
        {
            weaponElement.Name = "Longsword";
            potionElement.Name = "Potion of Healing";
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveTheSameDisplayNameAsTheEquipmentComponent_WhenConstructed()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var equipmentItem = new EquipmentItem(component);

            // assert
            Assert.AreEqual("Longsword", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveFormattedDisplayName_WhenEquipmentIsDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);
            var equipmentItem = new EquipmentItem(component);
            var silveredDecorator = new ElementModel();
            silveredDecorator.Properties.Add(ElementConstants.Properties.ItemNameFormat, "Silvered {{parent}}");

            // act
            equipmentItem.Decorate(silveredDecorator);

            // assert
            Assert.AreEqual("Silvered Longsword", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveFormattedDisplayName_WhenEquipmentIsDecoratedMultipleTimes()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);
            var equipmentItem = new EquipmentItem(component);
            var silveredDecorator = new ElementModel();
            var fireDecorator = new ElementModel();

            silveredDecorator.Properties.Add(ElementConstants.Properties.ItemNameFormat, "Silvered {{parent}}");
            fireDecorator.Properties.Add(ElementConstants.Properties.ItemNameFormat, "{{parent}} of Fire");

            // act
            equipmentItem.Decorate(silveredDecorator);
            equipmentItem.Decorate(fireDecorator);

            // assert
            Assert.AreEqual("Silvered Longsword of Fire", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldIncludeEnhancementInDisplayName_WhenEquipmentIsEnhancedAndIncludeEnhancementIsEnabled()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);
            var equipmentItem = new EquipmentItem(component);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon"
            };
            magicWeapon.Properties.Add(ElementConstants.Properties.ItemNameFormat, "Magic {{parent}}");
            magicWeapon.Properties.Add(ElementConstants.Properties.EnhancementValue, 1);

            // act
            equipmentItem.Decorate(magicWeapon);

            // assert
            Assert.AreEqual("Magic Longsword, +1", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldNotIncludeEnhancementInDisplayName_WhenEquipmentIsEnhancedAndIncludeEnhancementIsDisabled()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);
            var equipmentItem = new EquipmentItem(component);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon"
            };
            magicWeapon.Properties.Add(ElementConstants.Properties.ItemNameFormat, "Magic {{parent}}");
            magicWeapon.Properties.Add(ElementConstants.Properties.EnhancementValue, 1);

            // act
            equipmentItem.Decorate(magicWeapon);
            equipmentItem.IncludeEnhancementBonus = false;

            // assert
            Assert.AreEqual("Magic Longsword", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldBeStackable_WhenPropertyIsSet()
        {
            // arrange
            potionElement.AddProperty(ElementConstants.Properties.ItemStackable, true);

            // act
            var equipmentItem = new EquipmentItem(new EquipmentComponent(potionElement));

            // assert
            Assert.IsTrue(equipmentItem.IsStackable);
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveQuantityOne_WhenConstructed()
        {
            // arrange
            // act
            var equipmentItem = new EquipmentItem(new EquipmentComponent(potionElement));

            // assert
            Assert.AreEqual(1, equipmentItem.Quantity);
        }


        [TestMethod]
        public void EquipmentItem_ShouldBeExtractable_WhenPropertyIsSet()
        {
            // arrange
            packageElement.AddProperty(ElementConstants.Properties.ItemExtractable, true);

            // act
            var equipmentItem = new EquipmentItem(new EquipmentComponent(packageElement));

            // assert
            Assert.IsTrue(equipmentItem.IsExtractable);
        }
    }
}