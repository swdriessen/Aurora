using Aurora.Data.InMemory.DataProviders;
using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;
using Aurora.Engine.Utilities;

namespace Aurora.Data.InMemory
{
    public sealed class InMemoryDataProvider : IDataProvider
    {
        private readonly ElementIdentifierGenerator identifierGenerator = new();
        private readonly List<IDataProvider> providers = new List<IDataProvider>();

        private readonly List<ElementModel> elements = new();
        private readonly Dictionary<string, List<ElementModel>> typedElements = new();

        /// <summary>
        /// Initialize a new instance of the <see cref="InMemoryDataProvider"/> class used for testing.
        /// </summary>
        public InMemoryDataProvider()
        {
            // system
            providers.Add(new InMemoryAbilitiesDataProvider());
            providers.Add(new InMemorySkillsDataProvider());
            providers.Add(new InMemoryDamageTypeDataProvider());
            providers.Add(new InMemoryCurrenciesDataProvider());

            // spells
            providers.Add(new InMemorySpellsDataProvider());

            // equipment
            providers.Add(new InMemoryWeaponDataProvider());
            providers.Add(new InMemoryMagicItemsDataProvider());
            providers.Add(new InMemoryExtractableItemsDataProvider());

            // load providers
            foreach (var provider in providers)
            {
                elements.AddRange(provider.GetElements());
            }

            elements.ForEach(element =>
            {
                element.Source = new ElementSourceModel() { Name = "System Reference Document" };

                // auto-generate ids for elements that did not get one assigned
                if (string.IsNullOrWhiteSpace(element.Id))
                {
                    element.Id = identifierGenerator.GenerateIdentifier(element.Source.Name, "WOTC", element.Type, element.Name);
                }
            });

            var weapons = GetElements(ElementTypeConstants.Weapon);
            foreach (var weapon in weapons)
            {

            }
        }

        public List<ElementModel> GetElements()
        {
            return elements;
        }
        public List<ElementModel> GetElements(string type)
        {
            if (!typedElements.ContainsKey(type))
            {
                typedElements[type] = new List<ElementModel>(elements.Where(element => element.Type.Equals(type)));
            }

            return typedElements[type];
        }
    }

    public class InMemoryEquipmentDataProvider : IEquipmentDataProvider
    {
        private readonly InMemoryDataProvider provider;

        public InMemoryEquipmentDataProvider(InMemoryDataProvider provider)
        {
            this.provider = provider;
        }


        public ElementModel GetElementModel(string identifier)
        {
            return provider.GetElements().First(x => x.Id.Equals(identifier));
        }

        public IEnumerable<string> GetEquipmentCategories()
        {
            return provider.GetElements("Equipment Category").Select(x => x.Name);
        }

        public IEnumerable<ElementModel> GetItems()
        {
            return provider.GetElements("Item");
        }

        public IEnumerable<ElementModel> GetArmor()
        {
            return provider.GetElements("Armor");
        }

        public IEnumerable<ElementModel> GetWeapons()
        {
            return provider.GetElements("Weapon");
        }

        public IEnumerable<ElementModel> GetMagicItems()
        {
            return provider.GetElements("Magic Item");
        }

        public IEnumerable<ElementModel> GetTrinkets()
        {
            //trinket.number e.g. 5 on d100
            //trinket.source_group Gothic Trinkets
            return provider.GetElements("Trinket");
        }

    }
}