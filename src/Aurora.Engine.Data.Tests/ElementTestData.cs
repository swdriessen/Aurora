using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Engine.Data.Tests
{
    internal static class ElementTestData
    {
        public static string GetLongswordJson()
        {
            return @"{
  ""name"": ""Longsword"",
  ""type"": ""Weapon"",
  ""id"": ""1"",
  ""source"": {
    ""name"": ""Player\u0027s Handbook""
  },
  ""properties"": {
    ""item.category"": ""Weapons"",
    ""item.cost.value"": 15,
    ""item.cost.currency"": ""gp""
  }
}";
        }
    }
}
