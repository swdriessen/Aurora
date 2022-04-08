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
            var handler = new AggregatedEquipmentComponent(component);

            // assert
            Assert.AreEqual(component, handler.EquipmentComponent);
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnFalse_WhenTheItemIsNotDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var handler = new AggregatedEquipmentComponent(component);

            // assert
            Assert.IsFalse(handler.IsDecorated());
        }

        [TestMethod]
        public void IsDecorated_ShouldReturnTrue_WhenTheItemIsDecorated()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);

            // act
            var handler = new AggregatedEquipmentComponent(component);
            handler.Decorate(weaponElement.Object);

            // assert
            Assert.IsTrue(handler.IsDecorated());
        }

        [TestMethod]
        public void GetAggregatedComponent_ShouldReturnTheLastDecoratedComponent()
        {
            // arrange
            var component = new EquipmentComponent(weaponElement.Object);            

            // act
            var handler = new AggregatedEquipmentComponent(component);
            var decorator = handler.Decorate(decoratorElement.Object);

            // assert
            Assert.IsTrue(handler.IsDecorated());
            Assert.AreEqual(decorator, handler.GetAggregatedComponent());
            Assert.AreEqual("Longsword Decorator", decorator.GetDisplayName());
        }
    }
}