using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class EquipmentManagerTests
    {
        [TestMethod]
        public void EquipmentManager_ShouldContainNoItems_WhenInstantiated()
        {
            // arrange
            // act
            var equipmentManager = new EquipmentManager();

            // assert
            Assert.AreEqual(0, equipmentManager.Items.Count);
        }
    }
}