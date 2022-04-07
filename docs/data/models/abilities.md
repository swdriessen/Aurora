# Abilities

A character, npc, companion, or familiar will have a set of abilities. You can create data elements of type `Ability Score` to create the desired list of abilities. You will provide the `name`, `abbreviation` (first three characters of the name can be used as default), a short HTML `description` or a linked HTML asset document, and a `maximum` value. You can also provide whether they are `enabled` or not, which they are by default.

## Ability Score

An ability score has a `base` value, and `additional` value, and `override` value, a `maximum` value, and a `total` value. The modifier is calculated based on the final score.

### **AbilityItem** _class_
| Type | Name | Description |
| - | - | - |
| `string` | Name | The name of the ability score. |
| `string` | Abbreviation | The abbreviation of the ability score. |
| `string` | Description | The description of the ability score. |
| `int` | BaseValue | The base value of the ability score. |
| `int` | AdditionalValue | The additional value of the ability score. |
| `int` | OverrideValue | The value to set the ability score to override the caluclated final score. |
| `bool` | IsOverrideValueEnabled | Whether the override value should be taken into account. |
| `int` | MaximumScore | The maximum allowed value for the score. |
| `bool` | IsMaximumScoreEnabled | Whether the maximum score should be taken into account. |
| `int` | GetScore() | Gets the final calculated score for the ability. |
| `int` | GetModifier() | Gets the modifier for the ability. |

&nbsp;

## Modifier

A calulator that can be used to get the modifier associated with a provided value. A default implementation is used but a custom one can be registered in the service provider to override the calculation behavior.

### **IModifierCalculator** _interface_
| Type | Name | Description |
| - | - | - |
| `int` | CalculateModifier(int score) | Calculates the modifier associated with the score. |

```cs
public interface IModifierCalculator
{
    int CalculateModifier(int score);
}
```

&nbsp;

## Pseudo Example

```cs
//register the IModifierCalculator
services.Add<IModifierCalculator, DefaultModifierCalculator>();

//parse ability score from data to populate a list of abilities
var elements = elementsProvider.GetAbilityScoreElements();
var abilities = AbilitiesFactory.CreateCollection(elements);

//ability
var strength = list.First();
strength.BaseValue = 10;
strength.AdditionalValue = 8;

//modifier calculated with the provided IModifierCalculator
var score = strength.GetScore(); //18
var modifier = strength.GetModifier(); //4
```

## Custom Abilities

Besides the normal abilities you may want additional abilities for your character or want to replace the set of default abilities all together (heavy customization may cause serious issues).

```xml
<element name="Strength" type="Ability" id="ID_ABILITY_STRENGTH">
    <properties>
        <property key="sort.order">1</property>
    </properties>
</element>
<element name="Dexterity" type="Ability" id="ID_ABILITY_DEXTERITY">
    <properties>
        <property key="sort.order">2</property>
    </properties>
</element>
<element name="Constitution" type="Ability" id="ID_ABILITY_CONSTITUTION">
    <properties>
        <property key="sort.order">3</property>
    </properties>
</element>
<element name="Intelligence" type="Ability" id="ID_ABILITY_INTELLIGENCE">
    <properties>
        <property key="sort.order">4</property>
    </properties>
</element>
<element name="Wisdom" type="Ability" id="ID_ABILITY_WISDOM">
    <properties>
        <property key="sort.order">5</property>
    </properties>
</element>
<element name="Charisma" type="Ability" id="ID_ABILITY_CHARISMA">
    <properties>
        <property key="sort.order">6</property>
    </properties>
</element>
```

```xml
<element name="Honor" type="Ability" id="ID_ABILITY_HONOR">
    <properties>
        <property key="sort.order">7</property>
        <property key="ability.enabled">false</property>
    </properties>
</element>
<element name="Sanity" type="Ability" id="ID_ABILITY_SANITY">
    <properties>
        <property key="sort.order">8</property>
        <property key="ability.enabled">false</property>
    </properties>
</element>
```




