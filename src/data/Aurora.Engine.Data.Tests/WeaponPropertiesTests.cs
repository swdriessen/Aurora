using System.Linq;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class WeaponPropertiesTests
    {
        private readonly ElementPropertiesModel elementProperties = new();

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoProficiency_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.Proficiency);
        }

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoProficiencies_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var proficiencies = properties.GetProficiencies();
            Assert.AreEqual(0, proficiencies.Count());
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnProficiency_WhenPropertyIsSet()
        {
            // arrange
            var proficiency = "ID_PROFICIENCY_LONGSWORD";
            elementProperties.Set(ElementStrings.Properties.WeaponProficiency, proficiency);

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            Assert.AreEqual(proficiency, properties.Proficiency);
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnProficiencies_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var proficiency1 = "ID_PROFICIENCY_LONGSWORD";
            var proficiency2 = "ID_PROFICIENCY_CUSTOM_LONGSWORD";
            elementProperties.Set(ElementStrings.Properties.WeaponProficiency, $"{proficiency1};{proficiency2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var proficiencies = properties.GetProficiencies();
            Assert.IsTrue(proficiencies.Contains(proficiency1));
            Assert.IsTrue(proficiencies.Contains(proficiency2));
        }
    }
}