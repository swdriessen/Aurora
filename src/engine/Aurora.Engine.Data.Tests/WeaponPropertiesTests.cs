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
            elementProperties.Set(ElementConstants.Properties.WeaponProficiency, proficiency);

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
            elementProperties.Set(ElementConstants.Properties.WeaponProficiency, $"{proficiency1};{proficiency2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var proficiencies = properties.GetWeaponProficiencies();
            Assert.IsTrue(proficiencies.Contains(proficiency1));
            Assert.IsTrue(proficiencies.Contains(proficiency2));
        }

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoDuplicateProficiencies_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var proficiency1 = "ID_PROFICIENCY_LONGSWORD";
            var proficiency2 = "ID_PROFICIENCY_CUSTOM_LONGSWORD";
            elementProperties.Set(ElementConstants.Properties.WeaponProficiency, $"{proficiency1};{proficiency1};{proficiency2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var proficiencies = properties.GetWeaponProficiencies();
            Assert.AreEqual(2, proficiencies.Count());
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
            elementProperties.Set(ElementConstants.Properties.WeaponProperties, property1);

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
            elementProperties.Set(ElementConstants.Properties.WeaponProperties, $"{property1};{property2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponProperties();
            Assert.IsTrue(activeProperties.Contains(property1));
            Assert.IsTrue(activeProperties.Contains(property2));
        }

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoDuplicateProperties_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_VERSATILE";
            var property2 = "ID_WEAPON_PROPERTY_HEAVY";
            elementProperties.Set(ElementConstants.Properties.WeaponProperties, $"{property1};{property1};{property2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponProperties();
            Assert.AreEqual(2, activeProperties.Count());
            Assert.IsTrue(activeProperties.Contains(property1));
            Assert.IsTrue(activeProperties.Contains(property2));
        }

        //special properties

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoSpecialProperties_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var specialProperties = properties.GetSpecialWeaponProperties();
            Assert.AreEqual(0, specialProperties.Count());
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnSpecialProperty_WhenPropertyIsSet()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_SPECIAL";
            elementProperties.Set(ElementConstants.Properties.WeaponPropertiesSpecial, property1);

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var specialProperties = properties.GetSpecialWeaponProperties();
            Assert.IsTrue(specialProperties.Contains(property1));
        }

        [TestMethod]
        public void WeaponProperties_ShouldReturnSpecialProperties_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_SPECIAL_ONE";
            var property2 = "ID_WEAPON_PROPERTY_SPECIAL_TWO";
            elementProperties.Set(ElementConstants.Properties.WeaponPropertiesSpecial, $"{property1};{property2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var specialProperties = properties.GetSpecialWeaponProperties();
            Assert.IsTrue(specialProperties.Contains(property1));
            Assert.IsTrue(specialProperties.Contains(property2));
        }

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoDuplicateSpecialProperties_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var property1 = "ID_WEAPON_PROPERTY_SPECIAL_ONE";
            var property2 = "ID_WEAPON_PROPERTY_SPECIAL_TWO";
            elementProperties.Set(ElementConstants.Properties.WeaponPropertiesSpecial, $"{property1};{property1};{property2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var specialProperties = properties.GetSpecialWeaponProperties();
            Assert.AreEqual(2, specialProperties.Count());
            Assert.IsTrue(specialProperties.Contains(property1));
            Assert.IsTrue(specialProperties.Contains(property2));
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
            elementProperties.Set(ElementConstants.Properties.WeaponGroup, $"{group1};{group2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponGroups();
            Assert.IsTrue(activeProperties.Contains(group1));
            Assert.IsTrue(activeProperties.Contains(group2));
        }

        [TestMethod]
        public void WeaponProperties_ShouldHaveNoDuplicateWeaponGroups_WhenPropertyIsSetMultipleTimes()
        {
            // arrange
            var group1 = "ID_WEAPON_GROUP_SWORDS";
            var group2 = "ID_WEAPON_GROUP_AXES";
            elementProperties.Set(ElementConstants.Properties.WeaponGroup, $"{group1};{group1};{group2}");

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            var activeProperties = properties.GetWeaponGroups();
            Assert.AreEqual(2, activeProperties.Count());
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
            elementProperties.Set(ElementConstants.Properties.WeaponRange, range);

            // act
            var properties = new WeaponProperties(elementProperties);

            // assert
            Assert.AreEqual(range, properties.Range);
        }
    }
}