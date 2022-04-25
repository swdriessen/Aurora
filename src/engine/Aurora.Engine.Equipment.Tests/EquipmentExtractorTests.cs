using System;
using System.Linq;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;
using Aurora.Engine.Equipment.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class EquipmentExtractorTests
    {
        private readonly Mock<IEquipmentDataProvider> equipmentDataProvider = new();
        private readonly EquipmentExtractor equipmentExtractor;
        private readonly ElementModel element;

        public EquipmentExtractorTests()
        {
            equipmentExtractor = new(equipmentDataProvider.Object);

            element = new ElementModel
            {
                Name = "Item Pack"
            };
            element.Properties.Set("item.extractable", true);
        }

        [TestMethod]
        public void EquipmentExtractorCanExtract_ShouldReturnFalse_WhenItemIsNotExtractable()
        {
            // arrange
            element.Properties.Set("item.extractable", false);
            var item = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.CanExtract(item);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EquipmentExtractorCanExtract_ShouldReturnTrue_WhenItemIsExtractable()
        {
            // arrange
            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.CanExtract(extractableItem);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldThrowException_WhenItemIsNotExtractable()
        {
            // arrange
            var item = new EquipmentItem(new EquipmentComponent(new ElementModel()));

            // act
            // assert
            Assert.ThrowsException<InvalidOperationException>(() => { equipmentExtractor.Extract(item); });
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractMundaneItemAsAnInventoryItem_WhenExtracted()
        {
            // arrange
            var name = "Map of Baldur's Gate";
            element.ExtractableItems.Items.AddRange(new[] {
                new ExtractableItem(name),
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem);

            // assert
            var item = result.FirstOrDefault();
            Assert.IsNotNull(item, "Expected an item to be extracted.");

            Assert.AreEqual(name, item.GetDisplayName());
            Assert.AreEqual(1, item.Quantity);
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractExistingItemAsAnEquipmentItem_WhenExtracted()
        {
            // arrange
            var longbowIdentifier = "ID_WEAPON_LONGBOW";
            equipmentDataProvider.Setup(x => x.GetElementModel(It.Is<string>(x => x.Equals(longbowIdentifier))))
                .Returns(() =>
                 {
                     return new ElementModel()
                     {
                         Id = longbowIdentifier,
                         Name = "Longbow",
                         Type = "Weapon"
                     };
                 });

            element.Name = "Archer Starters Pack";
            element.ExtractableItems.Items.AddRange(new[] {
                new ExtractableItem(longbowIdentifier)
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem);

            // assert
            var item = result.FirstOrDefault();
            Assert.IsNotNull(item, "Expected an item to be extracted.");
            Assert.IsTrue(item is EquipmentItem);
            Assert.AreEqual("Longbow", item.GetDisplayName());
        }
    }
}