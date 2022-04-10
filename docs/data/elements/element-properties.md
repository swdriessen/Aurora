# Element Properties

A in-progress collection of properties an element might have. These are currently key/value pairs to think about what is needed, nothing special.

- When properties are missing either throw error right away or depending on the property try to parse other properties to deduce their values and be more forgiving as with old setters?
- Allow duplicate properties when multiple entries can apply?
  - e.g. two weapon damage entries, e.g. one for the primary attack action, another for the bonus action that does less damage

## Element Properties

The properties for elements of all kinds e.g. feats, items, spells.

```xml
<properties>
    <!-- normalized keywords -->
    <property key="element.keywords">fire;ice</property>
</properties>
```

## Item Properties

The properties that are specific to all item types e.g. items, magic items, weapons, and armor. Some of these only make sense on for example a weapon, these will be prefixed with `weapon` for now.

### Category

The category the item can be sorted on when displaying in for example an equipment section.

```xml
<properties>
    <property key="item.category">Weapons</property>
</properties>
```

### Stackable

The stackable property determines if this item allows to be stacked. e.g. a potion of healing or ammunition will be stackable.

```xml
<properties>
    <property key="item.stackable">true</property>
</properties>
```

### Name Formatting

The name of an item may be altered by for example magic items; _e.g. Longsword of Fire_. When you don't provide a name format the name of the magic item will be used instead; _e.g. Flametongue_.

You should surround your replacement property like so; `{{replacement}}`. You can use the following properties in the name formatting:

- `parent` this will take the name of the parent item, including the formatted name of the item if you apply multiple magic items.
- ...

```xml
<properties>
    <property key="item.name_format">Silvered {{parent}}</property>
</properties>
```

Note: at first it will support the basics; _e.g. a __Longsword__ with a __Weapon of Fire__ and a __Weapon of Ice__ will likely result in __Longsword of Fire of Ice___

### Cost

The cost of the item.

```xml
<properties>
    <!-- default display value -->
    <property key="item.cost">15 gp</property>
    <!-- used in the engine for calculation -->
    <property key="item.cost.value">15</property>
    <property key="item.cost.currency">gp</property>
    <!-- when a custom format is provided it will override the default value -->
    <property key="item.cost.displayformat">{{item.cost.value}} {{item.cost.currency}}</property>
    <!-- amount of items added to inventory when getting this item e.g. 10 arrows -->
    <property key="item.cost.bulk">10</property>
</properties>
```

### Weight

The weight of the item.

```xml
<properties>
    <!-- default display value -->
    <property key="item.weight">3 lb.</property>
    <!-- used in the engine for calculation -->
    <property key="item.weight.value">3</property>
    <property key="item.weight.unit">lb.</property>
    <!-- when a custom format is provided it will override the default value -->
    <property key="item.weight.displayformat">{{item.weight.value}} {{item.weight.currency}}</property>
    <!-- allow weight for an item to be ignored in calculation e.g. having a cart or mount in the inventory -->
    <property key="item.weight.ignore">true</property>
</properties>
```

- `item.weight.ignore` is optional and defaults to `false`

### Equippable

Some items like weapons and armor can be equipped, but also common items such as a pair of boots or a feathered hat show be allowed to be equipped.

There can be certains `rules` only apply when an item is equipped instead of just having it in your inventory.

```xml
<properties>
    <!-- allows an item to be equipped -->
    <property key="equippable">true</property>
    <!-- the 'item slot' where the item can be equipped -->
    <property key="equippable.target">twohand</property>
</properties>
```

- `equippable` is optional and defaults to `false`
- `equippable.target` is optional
  - this can be set to `onehand`, `twohand`, or a custom value e.g. `ring`


### Attunement

Some items only work when a character attunes to it. Like `equippable`, there can be certains `rules` only apply when an item is attuned instead of just having it in your inventory.

```xml
<properties>
    <!-- true when the item requires attunement -->
    <property key="attunement">true</property>
    <!-- the optional condition of the attunement e.g. a spellcaster or a specific class -->
    <property key="attunement.target">by a spellcaster</property>
</properties>
```

- `attunement` is optional and defaults to `false`
- `attunement.target` is optional and defaults to `null`

### Enhancement

```xml
<properties>
    <!-- default display value -->
    <property key="enhancement">+1</property>
    <!-- used in the engine for calculation -->
    <property key="enhancement.value">1</property>
</properties>
```

- `enhancement` defaults to `+` combined with whatever value `enhancement.value` is if one is provided
- `enhancement.value` defaults to `0`

### Weapon

```xml
<properties>
    <!-- display -->
    <!-- used in the engine -->
    <property key="weapon.category">ID_WEAPON_CATEGORY_MARTIAL_MELEE</property>
    <!-- set to true when the weapons is a melee weapon -->
    <property key="weapon.melee">true</property>
    <!-- the key ability used in calculating melee attacks with the weapon -->
    <property key="weapon.melee.ability">Strength</property>
    <!-- set to true when the weapons is a ranged weapon -->
    <property key="weapon.ranged">true</property>
    <!-- the key ability used in calculating ranged attacks with the weapon -->
    <property key="weapon.ranged.ability">Dexterity</property>
    <!-- the range of the weapon, can be either for melee (thrown) and ranged weapons -->
    <property key="weapon.range">20/60</property>
    <property key="weapon.range.min">20</property>
    <property key="weapon.range.max">60</property>
    <!-- the weapon group the item belongs to e.g. Swords -->
    <property key="weapon.group">ID_WEAPON_GROUP_SWORDS</property>
    <!-- the proficiency required to properly use the weapon -->
    <property key="weapon.proficiency">ID_PROFICIENCY_LONGSWORD</property>
    <!-- some weapons or special attacks created as weapons assume you are proficienct with them automatically -->
    <!-- when this is set to true you are considered to be proficient with this weapon -->
    <property key="weapon.proficiency.included">false</property>
    <!-- a list of weapon properties -->
    <property key="weapon.properties">ID_PROPERTY_SLASHING;ID_PROPERTY_VERSATILE</property>
    <!-- a list of special weapon properties, displayed at the end of the list of normal properties -->
    <property key="weapon.properties.special">ID_PROPERTY_SPECIAL</property>
    <!-- xxxxxxxxxxxxxxxxx -->
    <property key="weapon.xxxxxxxxxxxxxx">xxxxxxxxxx</property>
</properties>
```

- `weapon` keys that allow you to set an id, allow you to set a `;` separated range of ids to include multiple

### Damage

This is an example of a property that might occurr multiple times, e.g. a weapon that does an extra 1d6 fire and 1d6 radiant damage. Will need some thought on how to best handle this, maybe some way to group properties e.g. `<property key="damage" group="fire">1d6 fire</property>` and `<property key="damage" group="radiant">1d6 radiant</property>`. A key can still be accessed by using `{{damage.radiant}}` though this defeats the purpose of a simple key/value pair list.

Also needs properties to allow fixed/static damage e.g. `<property key="damage">1 piercing</property>`

```xml
<properties>
    <!-- default display value -->
    <property key="damage">1d8 slashing</property>
    <!-- used in the engine for calculation -->
    <property key="damage.dice">1d8</property>
    <property key="damage.dice.amount">1</property>
    <property key="damage.dice.size">8</property>
    <property key="damage.type">slashing</property>
</properties>
```

example of a magic item e.g. `Weapon of Fire` applied to a `Longsword` e.g. `Longsword of Fire`

```xml
<properties>
    <!-- default display value -->
    <property key="damage">1d6 fire</property>
    <!-- used in the engine for calculation -->
    <property key="damage.dice">1d6</property>
    <property key="damage.dice.amount">1</property>
    <property key="damage.dice.size">6</property>
    <property key="damage.type">fire</property>
</properties>
```

- `damage.type` in combination with `damage.dice.size` can for example be used to combined damage bonus from two different sources e.g. `1d6 fire` and `3d6 fire` can be combined into `4d6 fire` for the final description of the item on the sheet

### Versatile

A weapon can be versatile, e.g. wielded with one or two hands. It can add damage by prefixing the above damage properties with `versatile`. It will then be used when wielding the weapon with two hands.

```xml
<properties>
    <!-- default display value -->
    <property key="versatile.damage">1d10 slashing</property>
    <!-- used in the engine for calculation -->
    <property key="versatile.damage.dice">1d10</property>
    <property key="versatile.damage.dice.amount">1</property>
    <property key="versatile.damage.dice.size">10</property>
    <property key="versatile.damage.type">slashing</property>
</properties>
```

### Sorting Properties

When making selections, some elements are better left in order of creation. You should be able to sort a select set of elements to keep the desired sorting order intact.

A good example is a selection of abilities e.g. maintain the order of a _Strength, Dexterity, Charisma, Intelligence, Wisdom, and Charisma_ selection

```xml
<properties>
    <!-- sort on group (optional) and then sort on the order -->
    <property key="sort.group">1</property>
    <property key="sort.order">1</property>
</properties>

<!-- have a flag on the selection rule to enable sorting? -->
<selection sort="true" />
```
