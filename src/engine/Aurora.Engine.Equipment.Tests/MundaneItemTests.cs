using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Equipment.Tests
{
    [TestClass]
    public class MundaneItemTests
    {
        [TestMethod]
        public void MundaneItem_ShouldHaveTheSameDisplayNameAsTheProvidedName_WhenConstructed()
        {
            // arrange
            var name = "Wooden Figure of Raven";

            // act
            var item = new MundaneItem(name);

            // assert
            Assert.AreEqual(name, item.GetDisplayName());
        }

        [TestMethod]
        public void MundaneItem_ShouldHaveQuantityOne_WhenConstructed()
        {
            // arrange
            var name = "Wooden Figure of Raven";

            // act
            var item = new MundaneItem(name);

            // assert
            Assert.AreEqual(1, item.Quantity);
        }
    }
}