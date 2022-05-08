using System;
using System.Linq;
using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Equipment.Components;
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
            element.Name = "Abyssal Map Case";
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

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractBothMundaneAndExistingItem_WhenExtracted()
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
                new ExtractableItem(longbowIdentifier),
                new ExtractableItem("Map of Hunting Grounds")
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem);

            // assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(x => x is EquipmentItem), "Expected one equipment item.");
            Assert.AreEqual(1, result.Count(x => x is MundaneItem), "Expected one mundane item.");
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractNoStackableMundaneItemWithQuantityIndividually_WhenExtracted()
        {
            // arrange
            var bottles = new ExtractableItem("Bottle of Wine", 5);

            element.Name = "Box of Wine";
            element.ExtractableItems.Items.AddRange(new[] {
                bottles
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem).ToList();

            // assert
            Assert.AreEqual(5, result.Count);
            Assert.AreNotSame(result[0], result[1], "Expected the items to not be the same object reference.");
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractStackableItemOnceWithQuantitySet_WhenExtracted()
        {
            // arrange
            var expectedName = "Bottle of Wine";
            var expectedQuantity = 5;
            var bottles = new ExtractableItem(expectedName, expectedQuantity);
            bottles.Properties.Set("item.stackable", true);

            element.Name = "Box of Wine";
            element.ExtractableItems.Items.AddRange(new[] {
                bottles
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem);

            // assert
            Assert.AreEqual(1, result.Count(), "Expected 1 stackable item, not 5 items.");
            var item = result.First();

            Assert.AreEqual(expectedName, item.GetDisplayName());
            Assert.AreEqual(expectedQuantity, item.Quantity);
        }

        [TestMethod]
        public void EquipmentExtractor_ShouldExtractStackableExistingItemOnceWithQuantitySet_WhenExtracted()
        {
            // arrange
            var expectedName = "Potion of Healing";
            var expectedQuantity = 5;
            equipmentDataProvider.Setup(x => x.GetElementModel(It.Is<string>(x => x.Equals("ID_ITEM_POTION_OF_HEALING"))))
                .Returns(() =>
                {
                    var element = new ElementModel()
                    {
                        Id = "ID_ITEM_POTION_OF_HEALING",
                        Name = "Potion of Healing",
                        Type = "Item"
                    };

                    element.Properties.Add("item.stackable", true);

                    return element;
                });

            element.Name = "Box of Potions";
            element.ExtractableItems.Items.AddRange(new[] {
                new ExtractableItem("ID_ITEM_POTION_OF_HEALING", expectedQuantity)
            });

            var extractableItem = new EquipmentItem(new EquipmentComponent(element));

            // act
            var result = equipmentExtractor.Extract(extractableItem);

            // assert
            Assert.AreEqual(1, result.Count(), "Expected 1 stackable item, not 5 items.");
            var item = result.First();

            Assert.AreEqual(expectedName, item.GetDisplayName());
            Assert.AreEqual(expectedQuantity, item.Quantity);
        }

    }
}