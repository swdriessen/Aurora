using Aurora.Engine.Data.Extensions;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class AggregatedEquipmentComponentTests
    {
        private readonly ElementModel weaponElement = new();
        private readonly ElementModel decoratorElement = new();

        [TestInitialize]
        public void Initialize()
        {
            weaponElement.Name = "Longsword";
            decoratorElement.Name = "Longsword Decorator";
        }

        [TestMethod]
        public void GetEquipmentComponent_ShouldReturnComponentPassedInTheConstructer()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);

            // assert
            Assert.AreEqual(component, aggregatedComponent.EquipmentComponent);
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnFalse_WhenTheItemIsNotDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);

            // assert
            Assert.IsFalse(aggregatedComponent.IsDecorated());
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnTrue_WhenTheItemIsDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(weaponElement);

            // assert
            Assert.IsTrue(aggregatedComponent.IsDecorated());
        }

        [TestMethod]
        public void GetAggregatedComponent_ShouldReturnTheLastDecoratedComponent()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            var decorator = aggregatedComponent.Decorate(decoratorElement);

            // assert
            Assert.IsTrue(aggregatedComponent.IsDecorated());
            Assert.AreEqual(decorator, aggregatedComponent.DecoratedComponent);
            Assert.AreEqual("Longsword Decorator", decorator.GetDisplayName());
        }

        [TestMethod]
        public void GetEnhancementBonus_ShouldReturnZero_WhenNoEnhancementIsSet()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(decoratorElement);

            // assert
            Assert.AreEqual(0, aggregatedComponent.GetEnhancementBonus());
        }

        [TestMethod]
        public void GetEnhancementBonus_ShouldReturnOne_WhenItemIsEnhancedWithMagicItem()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon, +1"
            };
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
            var component = new EquipmentComponent(weaponElement);
            var magicWeapon = new ElementModel
            {
                Name = "Magic Weapon, +1"
            };
            magicWeapon.AddProperty("enhancement.value", 1);

            var anotherMagicWeapon = new ElementModel
            {
                Name = "Another Magic Weapon, +1"
            };
            anotherMagicWeapon.AddProperty("enhancement.value", 1);

            // act
            var aggregatedComponent = new AggregatedEquipmentComponent(component);
            aggregatedComponent.Decorate(magicWeapon);
            aggregatedComponent.Decorate(anotherMagicWeapon);

            // assert
            Assert.AreEqual(2, aggregatedComponent.GetEnhancementBonus());
        }
    }
}