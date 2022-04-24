using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Utilities.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsElementIdentifier_ShouldReturnTrue_WhenElementIdEvaluated()
        {
            // arrange
            var input = "ID_INTERNAL_IDENTIFIER";

            // act
            var output = input.IsElementIdentifier();

            // assert
            Assert.IsTrue(output);
        }
    }
}