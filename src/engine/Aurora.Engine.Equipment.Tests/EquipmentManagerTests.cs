using System.Linq;
using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class EquipmentManagerTests
    {
        private readonly Mock<IEquipmentDataProvider> equipmentDataProvider = new();
        private EquipmentManager equipmentManager = default!;

        [TestInitialize]
        public void Initialize()
        {
            equipmentManager = new EquipmentManager(new EquipmentExtractor(equipmentDataProvider.Object));
        }

        [TestMethod]
        public void EquipmentManager_ShouldContainNoItems_WhenConstructed()
        {
            // arrange
            // act
            // assert
            Assert.AreEqual(0, equipmentManager.Items.Count);
        }

        [TestMethod]
        public void EquipmentManager_ShouldContainOneItem_WhenElementModelIsAdded()
        {
            // arrange
            var element = CreateAdventuringPack();

            // act
            var item = equipmentManager.Add(element);

            // assert
            Assert.AreEqual(1, equipmentManager.Items.Count);
            Assert.AreSame(item, equipmentManager.Items.First());
        }

        [TestMethod]
        public void EquipmentManager_ShouldContainOneOtherItem_WhenExtractableItemIsExtracted()
        {
            // arrange
            var element = CreateAdventuringPack();
            var expectedName = element.ExtractableItems.Items.First().Item;
            var expectedQuantity = element.ExtractableItems.Items.First().Quantity;

            // act
            var addedItem = equipmentManager.Add(element);
            var isExtracted = equipmentManager.Extract(addedItem);

            // assert
            Assert.IsTrue(isExtracted);
            Assert.AreEqual(1, equipmentManager.Items.Count);

            var extractedItem = equipmentManager.Items.First();
            Assert.AreEqual(expectedName, extractedItem.GetDisplayName());
            Assert.AreEqual(expectedQuantity, extractedItem.Quantity);
        }

        private ElementModel CreateAdventuringPack()
        {
            var element = new ElementModel
            {
                Name = "Baldur's Gate Adventuring Pack"
            };

            element.Properties.Set(ElementConstants.Properties.ItemExtractable, true);

            element.ExtractableItems.Items.AddRange(new[] {
                new ExtractableItem("Map of Baldur's Gate"),
            });

            return element;
        }
    }
}