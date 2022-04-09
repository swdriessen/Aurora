using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class AggregatedEquipmentComponentTests
    {
        private readonly Mock<ElementModel> weaponElement = new();
        private readonly Mock<ElementModel> decoratorElement = new();

        [TestInitialize]
        public void Initialize()
        {
            weaponElement.Object.Name = "Longsword";
            decoratorElement.Object.Name = "Longsword Decorator";
        }

        [TestMethod]
        public void GetEquipmentComponent_ShouldReturnComponentPassedInTheConstructer()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);

            // assert
            Assert.AreEqual(component, aggregatedComponent.EquipmentComponent);
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnFalse_WhenTheItemIsNotDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);

            // assert
            Assert.IsFalse(aggregatedComponent.IsDecorated());
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnTrue_WhenTheItemIsDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(weaponElement.Object);

            // assert
            Assert.IsTrue(aggregatedComponent.IsDecorated());
        }

        [TestMethod]
        public void GetAggregatedComponent_ShouldReturnTheLastDecoratedComponent()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            var decorator = aggregatedComponent.Decorate(decoratorElement.Object);

            // assert
            Assert.IsTrue(aggregatedComponent.IsDecorated());
            Assert.AreEqual(decorator, aggregatedComponent.DecoratedComponent);
            Assert.AreEqual("Longsword Decorator", decorator.GetDisplayName());
        }

        [TestMethod]
        public void GetEnhancementBonus_ShouldReturnZero_WhenNoEnhancementIsSet()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(decoratorElement.Object);

            // assert
            Assert.AreEqual(0, aggregatedComponent.GetEnhancementBonus());
        }

        [TestMethod]
        public void GetEnhancementBonus_ShouldReturnOne_WhenItemIsEnhancedWithMagicItem()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon, +1"
            };
            magicWeapon.AddProperty("enhancement", "+1");
            magicWeapon.AddProperty("enhancement.value", 1);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(magicWeapon);

            // assert
            Assert.AreEqual(1, aggregatedComponent.GetEnhancementBonus());
        }

        [TestMethod]
        public void GetEnhancementBonus_ShouldReturnTwo_WhenItemIsEnhancedWithTwoMagicItems()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);
            var magicWeapon = new Mock<ElementModel>();
            magicWeapon.Object.Name = "Magic Weapon, +1";
            magicWeapon.Object.AddProperty("enhancement", "+1");
            magicWeapon.Object.AddProperty("enhancement.value", 1);

            var decoratorElement2 = new Mock<ElementModel>();
            decoratorElement2.Object.Name = "Another Magic Weapon, +1";
            decoratorElement2.Object.AddProperty("enhancement", "+1");
            decoratorElement2.Object.AddProperty("enhancement.value", 1);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(magicWeapon.Object);
            aggregatedComponent.Decorate(decoratorElement2.Object);

            // assert
            Assert.AreEqual(2, aggregatedComponent.GetEnhancementBonus());
        }
    }
}