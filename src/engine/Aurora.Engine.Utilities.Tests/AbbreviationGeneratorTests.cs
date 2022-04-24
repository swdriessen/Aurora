using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Utilities.Tests
{
    [TestClass]
    public class AbbreviationGeneratorTests
    {
        private AbbreviationGenerator generator = new();

        [TestMethod]
        public void Abbreviation_ShouldContainsTwoCharacters_WhenOneWordInputIsProvided()
        {
            // arrange
            var input = "Source";

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("SO", output);
        }

        [TestMethod]
        public void Abbreviation_ShouldContainsTwoCharacters_WhenTwoWordInputIsProvided()
        {
            // arrange
            var input = "Monster Manual";

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("MM", output);
        }

        [TestMethod]
        public void Abbreviation_ShouldContainsThreeCharacters_WhenThreeWordInputIsProvided()
        {
            // arrange
            var input = "System Reference Document";

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("SRD", output);
        }

        [TestMethod]
        public void Abbreviation_ShouldContainsSixCharacters_WhenSixWordInputIsProvided()
        {
            // arrange
            var input = "One Two Three Four Five Six";

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("OTTFFS", output);
        }

        [TestMethod]
        public void Abbreviation_ShouldContainsFourCharacters_WhenMaximumLengthIsSet()
        {
            // arrange
            var input = "One Two Three Four Five Six";
            generator = new AbbreviationGenerator(options => { options.MaximumLength = 4; });

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual(4, output.Length);
        }

        [TestMethod]
        public void Abbreviation_ShouldAbbreviateCorrectly_WhenInputWithSpecialCharactersProvided()
        {
            // arrange
            var input1 = "Dungeon Master's Guide";
            var input2 = "Baldur's Gate: Descent into Avernus";
            var input3 = "One-Two Source";

            // act
            var output1 = generator.Generate(input1);
            var output2 = generator.Generate(input2);
            var output3 = generator.Generate(input3);

            // assert
            Assert.AreEqual("DMG", output1);
            Assert.AreEqual("BGDIA", output2);
            Assert.AreEqual("OTS", output3);
        }

        [TestMethod]
        public void Abbreviation_ShouldNotAbbreviate_WhenListedInExceptions()
        {
            // arrange
            var input = "Internal";
            generator = new AbbreviationGenerator(options =>
            {
                options.MaximumLength = 4;
                options.Exceptions.Add("Internal");
            });

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("INTERNAL", output);
        }

        [TestMethod]
        public void Abbreviation_ShouldAbbreviateToPresetInsteadOfGenerating_WhenListedInPresets()
        {
            // arrange
            var input = "Player's Handbook";
            generator = new AbbreviationGenerator(options =>
            {
                options.Presets.Add("Player's Handbook", "PHB");
            });

            // act
            var output = generator.Generate(input);

            // assert
            Assert.AreEqual("PHB", output);
        }
    }
}