using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Utilities.Tests
{
    [TestClass]
    public class OrdinalNumeralTests
    {
        [TestMethod]
        public void ToOrdinalNumeral_ShouldNotChangeInput_WhenInputIsZero()
        {
            // arrange
            var input = 0;

            // act
            var output = input.ToOrdinalNumeral();

            // assert
            Assert.AreEqual("0", output);
        }

        [TestMethod]
        public void ToOrdinalNumeral_ShouldNotChangeInput_WhenInputIsNegative()
        {
            // arrange
            var input = -3;

            // act
            var output = input.ToOrdinalNumeral();

            // assert
            Assert.AreEqual("-3", output);
        }

        [TestMethod]
        public void ToOrdinalNumeral_ShouldHaveOutputCorrectOutput_WhenInputIsPositive()
        {
            // arrange
            var inputRange = Enumerable.Range(1, 25);
            var expectedOutputRange = new[] {
                "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th",
                "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th",
                "21st", "22nd", "23rd", "24th", "25th"
            };

            // act
            var outputRange = inputRange.Select(x => x.ToOrdinalNumeral());

            // assert
            Assert.AreEqual(expectedOutputRange.Count(), outputRange.Count());
            Assert.AreEqual(string.Join(", ", expectedOutputRange), string.Join(", ", outputRange));
        }

        [TestMethod]
        public void ToOrdinalNumeral_ShouldHaveOutputCorrectOutput_WhenInputIsAbove100()
        {
            // arrange
            var inputRange = Enumerable.Range(100, 21);
            var expectedOutputRange = new[] {
                "100th", "101st", "102nd", "103rd", "104th", "105th", "106th", "107th", "108th", "109th", "110th",
                "111th", "112th", "113th", "114th", "115th", "116th", "117th", "118th", "119th", "120th",
            };

            // act
            var outputRange = inputRange.Select(x => x.ToOrdinalNumeral());

            // assert
            Assert.AreEqual(expectedOutputRange.Count(), outputRange.Count());
            Assert.AreEqual(string.Join(", ", expectedOutputRange), string.Join(", ", outputRange));
        }
    }
}