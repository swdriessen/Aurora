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

        //proficiency

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
            var proficiencies = properties.GetWeaponProficiencies();
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
            var proficiencies = properties.GetWeaponProficiencies();
            Assert.IsTrue(proficiencies.Contains(proficiency1));
            Assert.IsTrue(proficiencies.Contains(proficiency2));
        }

        //properties

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoProperties_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponProperties();
            Assert.AreEqual(0, activeProperties.Count());
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnProperty_WhenPropertyIsSet()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_VERSATILE";
            elementProperties.Set(ElementStrings.Properties.WeaponProperties, property1);

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponProperties();
            Assert.IsTrue(activeProperties.Contains(property1));
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnProperties_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_VERSATILE";
            var property2 = "ID_WEAPON_PROPERTY_HEAVY";
            elementProperties.Set(ElementStrings.Properties.WeaponProperties, $"{property1};{property2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponProperties();
            Assert.IsTrue(activeProperties.Contains(property1));
            Assert.IsTrue(activeProperties.Contains(property2));
        }

        //groups

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoWeaponGroups_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var groups = properties.GetWeaponGroups();
            Assert.AreEqual(0, groups.Count());
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnWeaponGroups_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var group1 = "ID_WEAPON_GROUP_SWORDS";
            var group2 = "ID_WEAPON_GROUP_AXES";
            elementProperties.Set(ElementStrings.Properties.WeaponGroup, $"{group1};{group2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponGroups();
            Assert.IsTrue(activeProperties.Contains(group1));
            Assert.IsTrue(activeProperties.Contains(group2));
        }

        //range

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoRange_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.Range);
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnRange_WhenPropertyIsSet()
        {
            // arrange
            var range = "150/600";
            elementProperties.Set(ElementStrings.Properties.WeaponRange, range);

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            Assert.AreEqual(range, properties.Range);
        }
    }
}