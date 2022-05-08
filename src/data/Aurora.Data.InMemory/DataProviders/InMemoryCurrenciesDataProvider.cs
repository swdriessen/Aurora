using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemoryCurrenciesDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateCurrencies());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateCurrencies()
        {
            var elements = new List<ElementModel>();

            var currencyTypes = new List<ElementModel>();

            var copper = new ElementModel()
            {
                Name = "Copper",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "cp" },
                    { "currency.rate", 0.01 }
                }
            };
            var silver = new ElementModel()
            {
                Name = "Silver",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "sp" },
                    { "currency.rate", 0.1 }
                }
            };
            var gold = new ElementModel()
            {
                Name = "Gold",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "gp" },
                    { "currency.rate", 1 }
                }
            };
            var platinum = new ElementModel()
            {
                Name = "Platinum",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "pp" },
                    { "currency.rate", 10 }
                }
            };
            var electrum = new ElementModel()
            {
                Name = "Electrum",
                Properties = new()
                {
                    { ElementConstants.Properties.Abbreviation, "ep" },
                    { "currency.rate", 0.5 }
                }
            };

            currencyTypes.Add(copper);

            currencyTypes.ForEach(e =>
            {
                e.Type = "Currency";
                e.Properties.Add("weight", 0.02);
                e.Properties.Add("weight.unit", "lb.");
            });

            elements.AddRange(currencyTypes);

            return elements;
        }
    }
}