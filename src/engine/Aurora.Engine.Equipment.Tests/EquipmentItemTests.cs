using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Equipment.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class EquipmentItemTests
    {
        private readonly Mock<ElementModel> weaponElement = new();

        [TestInitialize]
        public void Initialize()
        {
            weaponElement.Object.Name = "Longsword";
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveTheSameDisplayNameAsTheEquipmentComponent_WhenConstructed()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var equipmentItem = new EquipmentItem(component);

            // assert
            Assert.AreEqual("Longsword", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveFormattedDisplayName_WhenEquipmentIsDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var equipmentItem = new EquipmentItem(component);
            var decorator = new Mock<ElementModel>();
            decorator.Object.Properties.AddItemNameFormattingProperty("Silvered {{parent}}");

            // act
            equipmentItem.Decorate(decorator.Object);

            // assert
            Assert.AreEqual("Silvered Longsword", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldHaveFormattedDisplayName_WhenEquipmentIsDecoratedMultipleTimes()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var equipmentItem = new EquipmentItem(component);
            var decorator1 = new Mock<ElementModel>();
            var decorator2 = new Mock<ElementModel>();

            decorator1.Object.Properties.AddItemNameFormattingProperty("Silvered {{parent}}");
            decorator2.Object.Properties.AddItemNameFormattingProperty("{{parent}} of Fire");

            // act
            equipmentItem.Decorate(decorator1.Object);
            equipmentItem.Decorate(decorator2.Object);

            // assert
            Assert.AreEqual("Silvered Longsword of Fire", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldIncludeEnhancementInDisplayName_WhenEquipmentIsEnhancedAndIncludeEnhancementIsEnabled()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var equipmentItem = new EquipmentItem(component);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon"
            };
            magicWeapon.Properties.AddItemNameFormattingProperty("Magic {{parent}}");
            magicWeapon.Properties.AddProperty(ElementStrings.Properties.Enhancement.Value, 1);

            // act
            equipmentItem.Decorate(magicWeapon);

            // assert
            Assert.AreEqual("Magic Longsword, +1", equipmentItem.GetDisplayName());
        }

        [TestMethod]
        public void EquipmentItem_ShouldNotIncludeEnhancementInDisplayName_WhenEquipmentIsEnhancedAndIncludeEnhancementIsDisabled()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var equipmentItem = new EquipmentItem(component);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon"
            };
            magicWeapon.Properties.AddItemNameFormattingProperty("Magic {{parent}}");
            magicWeapon.Properties.AddProperty(ElementStrings.Properties.Enhancement.Value, 1);

            // act
            equipmentItem.Decorate(magicWeapon);
            equipmentItem.IncludeEnhancementBonus = false;

            // assert
            Assert.AreEqual("Magic Longsword", equipmentItem.GetDisplayName());
        }
    }
}