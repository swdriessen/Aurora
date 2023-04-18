using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aurora.Engine.Utilities.Tests
{
    [TestClass]
    public class InlineReplacementExtensionsTests
    {
        [TestMethod]
        public void InlineReplacementExtensions_ShouldReplaceInputWithProvidedKeyAndValue()
        {
            // arrange
            var input = "Hello {{key}}!";

            // act
            var output = input.ReplaceInline("key", "World");

            // assert
            Assert.AreEqual("Hello World!", output);
        }

        [TestMethod]
        public void InlineReplacementExtensions_ShouldNotReplaceKeyWhenValueIsNull()
        {
            // arrange
            const string input = "Hello {{key}}!";

            // act
            string output = input.ReplaceInline("key", null!);

            // assert
            Assert.AreEqual(input, output);
        }

        [TestMethod]
        public void InlineReplacementExtensions_ShouldReplaceInputWithProvidedReplacementPairs()
        {
            // arrange
            var input = "Hello {{key}}!";
            var pairs = new Dictionary<string, string>
            {
                { "key", "World" }
            };

            // act
            var output = input.ReplaceInline(pairs);

            // assert
            Assert.AreEqual("Hello World!", output);
        }

        [TestMethod]
        public void InlineReplacementExtensions_ShouldReplaceInputWithProvidedReplacementPairs_WhenStringObjectDictionaryIsProvided()
        {
            // arrange
            var input = "int={{int}} and string={{string}}";
            var pairs = new Dictionary<string, object>
            {
                { "int", 42 },
                { "string", "value" },
            };

            // act
            var output = input.ReplaceInline(pairs);

            // assert
            Assert.AreEqual("int=42 and string=value", output);
        }
    }
}