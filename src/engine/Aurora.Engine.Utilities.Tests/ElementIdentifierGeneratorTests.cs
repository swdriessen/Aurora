using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Utilities.Tests
{
    [TestClass]
    public class ElementIdentifierGeneratorTests
    {
        private readonly ElementIdentifierGenerator generator;
        private readonly string source = "Player's Handbook";
        private readonly string author = "Wizards of the Coast";

        public ElementIdentifierGeneratorTests()
        {
            generator = new ElementIdentifierGenerator(options =>
            {
                options.IncludeSourceAbbreviation = true;
                options.IncludeAuthorAbbreviation = true;
            });
        }

        [TestMethod]
        public void Generator_ShouldGenerateCompleteIdentifier_WhenAllParametersAreProvided()
        {
            // arrange
            var type = "Class Feature";
            var name = "Rage";
            var parent = "Barbarian";

            // act
            var identifier = generator.GenerateIdentifier(source, author, type, name, parent);

            // assert
            Assert.AreEqual("ID_PHB_WOTC_CLASS_FEATURE_BARBARIAN_RAGE", identifier);
        }

        [TestMethod]
        public void Generator_ShouldIgnoreParent_WhenItIsEmptyOrNull()
        {
            // arrange
            var type = "Class Feature";
            var name = "Rage";
            var parent = string.Empty;

            // act
            var identifier = generator.GenerateIdentifier(source, author, type, name, parent);

            // assert
            Assert.AreEqual("ID_PHB_WOTC_CLASS_FEATURE_RAGE", identifier);
        }

        [TestMethod]
        public void Generator_ShouldThrowException_WhenNameIsOmitted()
        {
            // arrange
            // act
            var type = "Class Feature";
            var name = string.Empty;
            var parent = "Barbarian";

            // assert
            Assert.ThrowsException<ArgumentException>(() => { generator.GenerateIdentifier(source, author, type, name, parent); }, "Expected an exception as the name is required.");
        }

        [TestMethod]
        public void Generator_ShouldThrowException_WhenTypeIsOmitted()
        {
            // arrange
            // act
            var type = string.Empty;
            var name = "Rage";
            var parent = "Barbarian";

            // assert
            Assert.ThrowsException<ArgumentException>(() => { generator.GenerateIdentifier(source, author, type, name, parent); }, "Expected an exception as the type is required.");
        }

        [TestMethod]
        public void Generator_ShouldGenerateCompleteIdentifier_WhenParametersWithSpecialCharactersAreProvided()
        {
            // arrange
            var source = "Baldur's Gate: Descent into Avernus";
            var author = "Asmodeus, Lord of Nessus";
            var type = "Class Feature";
            var name = "Barbarian's Rage";
            var parent = "Abyssal Barbarian";

            // act
            var identifier = generator.GenerateIdentifier(source, author, type, name, parent);

            // assert
            Assert.AreEqual("ID_BGDIA_ALON_CLASS_FEATURE_ABYSSAL_BARBARIAN_BARBARIANS_RAGE", identifier);
        }
    }
}