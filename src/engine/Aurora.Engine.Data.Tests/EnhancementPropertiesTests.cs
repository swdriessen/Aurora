using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class EnhancementPropertiesTests
    {
        private readonly ElementPropertiesModel elementProperties = new();

        [TestMethod]
        public void EnhancementProperties_ShouldHaveNoEnhancementValue_WhenPopulatedWithEmptyElementProperties()
        {
            // arrange
            var defaultEnhancementValue = 0;

            // act
            var enhancementProperties = new EnhancementProperties(elementProperties);

            // assert
            Assert.AreEqual(defaultEnhancementValue, enhancementProperties.EnhancementValue);
        }

        [TestMethod]
        public void EnhancementProperties_ShouldHaveEnhancementValueOfOne_WhenPopulatedWithElementProperties()
        {
            // arrange
            var enhancementValue = 2;
            elementProperties.Add(ElementConstants.Properties.EnhancementValue, enhancementValue);

            // act
            var enhancementProperties = new EnhancementProperties(elementProperties);

            // assert
            Assert.AreEqual(enhancementValue, enhancementProperties.EnhancementValue);
        }

        [TestMethod]
        public void EnhancementProperties_ShouldHaveEmptyFormattedEnhancementWhenPopulatedWithEmptyElementProperties()
        {
            // arrange
            // act
            var enhancementProperties = new EnhancementProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, enhancementProperties.GetFormattedEnhancement());
        }

        [TestMethod]
        public void EnhancementProperties_ShouldHaveFormattedEnhancement_WhenPopulatedWithElementProperties()
        {
            // arrange
            var enhancementValue = 2;
            elementProperties.Add(ElementConstants.Properties.EnhancementValue, enhancementValue);

            // act
            var enhancementProperties = new EnhancementProperties(elementProperties);

            // assert
            Assert.AreEqual($"+{enhancementValue}", enhancementProperties.GetFormattedEnhancement());
        }
    }
}