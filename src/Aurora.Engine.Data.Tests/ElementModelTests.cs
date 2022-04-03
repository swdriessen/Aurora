using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Serialization;
using Aurora.Engine.Data.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;
using Aurora.Engine.Data.Strings;

namespace Aurora.Engine.Data.Tests
{
    [TestClass]
    public class ElementModelTests
    {
        private readonly IDataSerializer<ElementModel> serializer;

        public ElementModelTests()
        {
            serializer = new ElementModelSerializer( options =>
            {
                options.WriteIndented = true;
            });
        }

        [TestMethod]
        public void ElementModel_ShouldSerialize()
        {
            // arrange
            var model = new ElementModel
            {
                Name = "Longsword",
                Type = "Weapon",
                ID = "1"
            };
            model.Source.Name = "Player's Handbook";
            
            model.AddProperty(ElementStrings.Properties.Item.Category, "Weapons");
            model.AddProperty(ElementStrings.Properties.Item.Cost.Value, 15);
            model.AddProperty(ElementStrings.Properties.Item.Cost.Currency, "gp");

            // act
            var data = serializer.Serialize(model);

            // assert
            Assert.AreEqual(ElementTestData.GetLongswordJson(), data);
        }
    }
}