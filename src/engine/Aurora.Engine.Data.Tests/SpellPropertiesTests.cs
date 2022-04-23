using System.Linq;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class SpellPropertiesTests
    {
        private readonly ElementPropertiesModel elementProperties = new();

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultVerbalComponent_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsFalse(properties.VerbalComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveVerbalComponentSetToTrue_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.VerbalComponent, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsTrue(properties.VerbalComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultSomaticComponent_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsFalse(properties.SomaticComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveSomaticComponentSetToTrue_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.SomaticComponent, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsTrue(properties.SomaticComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultMaterialComponent_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsFalse(properties.MaterialComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveMaterialComponentSetToTrue_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.MaterialComponent, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsTrue(properties.MaterialComponent);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultMaterialComponentDescription_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.MaterialComponentDescription);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveMaterialComponentDescription_WhenPropertyIsSet()
        {
            // arrange
            var description = "a feather";
            elementProperties.Set(ElementConstants.SpellProperties.MaterialComponentDescription, description);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(description, properties.MaterialComponentDescription);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultLevel_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(-1, properties.Level);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveLevel_WhenPropertyIsSet()
        {
            // arrange
            var level = 3;
            elementProperties.Set(ElementConstants.SpellProperties.Level, level);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(level, properties.Level);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultMagicSchool_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.MagicSchool);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveMagicSchool_WhenPropertyIsSet()
        {
            // arrange
            var school = "Evocation";
            elementProperties.Set(ElementConstants.SpellProperties.MagicSchool, school);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(school, properties.MagicSchool);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultCastingTime_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.CastingTime);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveCastingTime_WhenPropertyIsSet()
        {
            // arrange
            var time = "1 minute";
            elementProperties.Set(ElementConstants.SpellProperties.CastingTime, time);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(time, properties.CastingTime);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultDuration_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.Duration);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDuration_WhenPropertyIsSet()
        {
            // arrange
            var duration = "1 minute";
            elementProperties.Set(ElementConstants.SpellProperties.Duration, duration);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(duration, properties.Duration);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultRange_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(string.Empty, properties.Range);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveRange_WhenPropertyIsSet()
        {
            // arrange
            var range = "120 feet";
            elementProperties.Set(ElementConstants.SpellProperties.Range, range);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual(range, properties.Range);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultConcentration_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsFalse(properties.Concentration);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveConcentrationtSetToTrue_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Concentration, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsTrue(properties.Concentration);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveDefaultRitual_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsFalse(properties.Ritual);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveRitualtSetToTrue_WhenPropertyIsSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Ritual, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.IsTrue(properties.Ritual);
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveNoSpellcasters_WhenPropertyIsOmitted()
        {
            // arrange
            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            var spellcasters = properties.GetSpellcasters();
            Assert.AreEqual(0, spellcasters.Count());
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveSpellcasters_WhenPropertyIsSet()
        {
            // arrange
            var casters = "ID_SPELLCASTER_SORCERER;ID_SPELLCASTER_WIZARD;ID_SPELLCASTER_WARLOCK";
            elementProperties.Set(ElementConstants.SpellProperties.Spellcasters, casters);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            var spellcasters = properties.GetSpellcasters();
            Assert.AreEqual(3, spellcasters.Count());
            Assert.IsTrue(spellcasters.Contains("ID_SPELLCASTER_SORCERER"));
            Assert.IsTrue(spellcasters.Contains("ID_SPELLCASTER_WIZARD"));
            Assert.IsTrue(spellcasters.Contains("ID_SPELLCASTER_WARLOCK"));
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveNoDuplicatedSpellcasters_WhenPropertyIsSet()
        {
            // arrange
            var casters = "ID_SPELLCASTER_SORCERER;ID_SPELLCASTER_SORCERER;ID_SPELLCASTER_WARLOCK";
            elementProperties.Set(ElementConstants.SpellProperties.Spellcasters, casters);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            var spellcasters = properties.GetSpellcasters();
            Assert.AreEqual(2, spellcasters.Count(), "Expected no duplicated entries.");
            Assert.IsTrue(spellcasters.Contains("ID_SPELLCASTER_SORCERER"));
            Assert.IsTrue(spellcasters.Contains("ID_SPELLCASTER_WARLOCK"));
        }

        [TestMethod]
        public void SpellProperties_ShouldHaveCantripUnderline_WhenLevelIsZero()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Level, 0);
            elementProperties.Set(ElementConstants.SpellProperties.MagicSchool, "Evocation");

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual("Evocation cantrip", properties.GetUnderline());
        }

        [TestMethod]
        public void SpellProperties_ShouldHave1stLevelEvocationUnderline_WhenPropertiesAreSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Level, 1);
            elementProperties.Set(ElementConstants.SpellProperties.MagicSchool, "Evocation");

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual("1st-level evocation", properties.GetUnderline());
        }

        [TestMethod]
        public void SpellProperties_ShouldHave2rdLevelDivinationWithRitualUnderline_WhenPropertiesAreSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Level, 2);
            elementProperties.Set(ElementConstants.SpellProperties.MagicSchool, "Divination");
            elementProperties.Set(ElementConstants.SpellProperties.Ritual, true);

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual("2nd-level divination (ritual)", properties.GetUnderline());
        }

        [TestMethod]
        public void SpellProperties_ShouldHave3rdLevelEvocationUnderline_WhenPropertiesAreSet()
        {
            // arrange
            elementProperties.Set(ElementConstants.SpellProperties.Level, 3);
            elementProperties.Set(ElementConstants.SpellProperties.MagicSchool, "Evocation");

            // act
            var properties = new SpellProperties(elementProperties);

            // assert
            Assert.AreEqual("3rd-level evocation", properties.GetUnderline());
        }
    }
}