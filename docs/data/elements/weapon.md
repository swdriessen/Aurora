# Weapon

All basic weapons are of the `Weapon` type.

_TODO: generic element doc_

## Properties

All properties have additional details and a small example snippet in XML below. A weapon can also include most, if not all, of the [item properties](#./item.md) that are available.

_Note: The given examples below may have placeholder IDs and do not reflect any actual IDs of elements._

| Property Name                                             | Value Type | Required | Default Value                          |
| --------------------------------------------------------- | :--------: | :------: | -------------------------------------- |
| [weapon.category](#weaponcategory)                        | string     | true     | —                                     |
| [weapon.melee](#weaponmelee)                              | boolean    | —        | `false`                                |
| [weapon.melee.ability](#weaponmeleeability)               | string     | —        | `Strength`                             |
| [weapon.ranged](#weaponranged)                            | boolean    | —        | `false`                                |
| [weapon.ranged.ability](#weaponrangedability)             | string     | —        | `Dexterity`                            |
| [weapon.range](#weaponrange)                              | string     | —        | —                                      |
| [weapon.range.min](#weaponrangemin)                       | integer    | —        | `0`                                    |
| [weapon.range.max](#weaponrangemax)                       | integer    | —        | `0`                                    |
| [weapon.group](#weapongroup)                              | string     | —        | —                                      |
| [weapon.proficiency](#weaponproficiency)                  | string     | true     | —                                      |
| [weapon.proficiency.included](#weaponproficiencyincluded) | boolean    | —        | `false`                                |
| [weapon.properties](#weaponproperties)                    | string     | —        | —                                      |
| [weapon.properties.special](#weaponpropertiesspecial)     | string     | —        | —                                      |

### weapon.category

The `weapon.category` property specifies the weapon category the weapons belongs to.

The possible values are: 

- `ID_WEAPON_CATEGORY_SIMPLE_MELEE` for a simple melee weapon
- `ID_WEAPON_CATEGORY_MARTIAL_MELEE` for a martial melee weapon
- `ID_WEAPON_CATEGORY_SIMPLE_RANGED` for a simple ranged weapon
- `ID_WEAPON_CATEGORY_MARTIAL_RANGED` for a martial ranged weapon
- `ID_WEAPON_CATEGORY_FIREARM` for firearm weapon

In addition to the possible values custom elements of the `Weapon Category` type can be created and its `id` can then be used here.

```xml
<!-- e.g. the category of a longsword -->
<property name="weapon.category">ID_WEAPON_CATEGORY_MARTIAL_MELEE</property>
```

### weapon.melee

The `weapon.melee` property specifies whether the weapon is a melee weapon.

```xml
<!-- e.g. for a longsword -->
<property name="weapon.melee">true</property>
```

### weapon.melee.ability

The `weapon.melee.ability` property specifies the ability to use for the attack and damage bonus. This defaults to `Strength` for a melee weapon and can be omitted when it is not altered.

The possible values are: 

- `Strength`
- `Dexterity`
- `Constitution`
- `Intelligence`
- `Wisdom`
- `Charisma`

In addition to the possible values custom elements of the `Ability` type can be created and its `name` can then be used here.

```xml
<!-- e.g. set to dexterity for a dagger -->
<property name="weapon.melee.ability">Dexterity</property>
```

### weapon.ranged

The `weapon.ranged` property specifies whether the weapon is a ranged weapon.

```xml
<!-- e.g. for a longbow -->
<property name="weapon.ranged">true</property>
```

### weapon.ranged.ability

The `weapon.ranged.ability` property specifies the ability to use for the attack and damage bonus. This defaults to `Dexterity` for a ranged weapon and can be omitted when it is not altered.

The possible values are: 

- `Strength`
- `Dexterity`
- `Constitution`
- `Intelligence`
- `Wisdom`
- `Charisma`

In addition to the possible values custom elements of the `Ability` type can be created and its `name` can then be used here.

```xml
<!-- e.g. for some reason this weapon uses charisma instead of dexterity -->
<property name="weapon.ranged.ability">Charisma</property>
```

### weapon.range

The `weapon.range` property specifies the display range for this weapon. This can be the range for a ranged weapon but also for a weapon with the thrown property.

```xml
<!-- e.g. the range of the weapon is 20 for the short range and 60 for the long range -->
<property name="weapon.range">20/60</property>
```

### weapon.range.min

The `weapon.range.min` property specifies the short range of the weapon.

```xml
<!-- e.g. short range for a weapon with a range of 20/60 -->
<property name="weapon.range.min">20</property>
```

### weapon.range.max

The `weapon.range.max` property specifies the long range of the weapon.

```xml
<!-- e.g. long range for a weapon with a range of 20/60 -->
<property name="weapon.range.max">60</property>
```

### weapon.group

The `weapon.group` property specifies an optional group that the weapon belongs to.

The possible values are: 

- `ID_WEAPON_GROUP_SWORDS`
- `ID_WEAPON_GROUP_AXES`
- `ID_WEAPON_GROUP_BOWS`
- `ID_WEAPON_GROUP_FIREARMS`
- etc

In addition to the possible values custom elements of the `Weapon Group` type can be created and its `id` can then be used here.

```xml
<!-- e.g. the weapon group for a longsword -->
<property name="weapon.group">ID_WEAPON_GROUP_SWORDS</property>
```

### weapon.proficiency

The `weapon.proficiency` property specifies the id of the proficiency element for this weapon. When creating a weapon you should also create a accompanying [proficiency](#./proficiency.md) for it.

```xml
<!-- e.g. the proficiency id for a longsword -->
<property name="weapon.proficiency">ID_PROFICIENCY_WEAPON_LONGSWORD</property>
```

### weapon.proficiency.included

The `weapon.proficiency.included` property specifies whether the proficiency for the weapon is included automatically when you wield it.

```xml
<!-- e.g. when you are automatically proficienct with this weapon -->
<property name="weapon.proficiency.included">true</property>
```

### weapon.properties

The `weapon.properties` property specifies a semi-colon separated list of weapon properties.

```xml
<!-- e.g. a weapon that has the slashing and versatile weapon properties -->
<property name="weapon.properties">ID_PROPERTY_SLASHING;ID_PROPERTY_VERSATILE</property>
```

### weapon.properties.special

The `weapon.properties.special` property specifies a semi-colon separated list of special weapon properties. This is in addition to the normal weapon properties for now to allow rendering them last in the list, regardless of the order. Later, a [weapon property element](#weapon-property.md) might have a property that classifies them as special instead.

```xml
<!-- e.g. a weapon that has a special glow property -->
<property name="weapon.properties.special">ID_PROPERTY_SPECIAL_GLOW</property>
```
