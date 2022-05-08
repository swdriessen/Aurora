using Aurora.Engine.Data.Interfaces;
using Aurora.Engine.Data.Models;
using Aurora.Engine.Data.Strings;

namespace Aurora.Data.InMemory.DataProviders
{
    internal class InMemorySkillsDataProvider : IDataProvider
    {
        public List<ElementModel> GetElements()
        {
            return new List<ElementModel>(CreateSkills());
        }

        public List<ElementModel> GetElements(string type)
        {
            return GetElements().Where(x => x.Type.Equals(type)).ToList();
        }

        private static List<ElementModel> CreateSkills()
        {
            var elements = new List<ElementModel>();

            var skills = new List<ElementModel>
            {
                new ElementModel()
                {
                    Name = "Athletics",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Strength" },
                    }
                },
                new ElementModel()
                {
                    Name = "Acrobatics",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Sleight of Hand",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Stealth",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Dexterity" },
                    }
                },
                new ElementModel()
                {
                    Name = "Arcana",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "History",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Investigation",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Nature",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Religion",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Intelligence" },
                    }
                },
                new ElementModel()
                {
                    Name = "Animal Handling",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Insight",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Medicine",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Perception",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Survival",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Wisdom" },
                    }
                },
                new ElementModel()
                {
                    Name = "Deception",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Intimidation",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Performance",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                },
                new ElementModel()
                {
                    Name = "Persuasion",
                    Properties = new()
                    {
                        { ElementConstants.Properties.Ability, "Charisma" },
                    }
                }
            };

            var order = 1;
            skills.ForEach(element =>
            {
                element.Type = ElementTypeConstants.Skill;
                element.Properties.Add(ElementConstants.Properties.SortingOrder, order);
                order++;
            });

            elements.AddRange(skills);

            return elements;
        }
    }
}