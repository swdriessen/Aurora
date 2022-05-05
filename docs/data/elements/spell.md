# Spell

All spells and cantrips are of the `Spell` type.

## Properties

| Property Name                                                    | Type       | Required | Default Value      |
| ---------------------------------------------------------------- | :--------: | :------: | ------------------ |
| [spell.level](#spelllevel)                                       | integer    | _true_   |                    |
| [spell.magic_school](#spellmagic_school)                         | string     | _true_   |                    |
| [spell.casting_time](#spellcasting_time)                         | string     | _true_   |                    |
| [spell.range](#spellrange)                                       | string     | _true_   |                    |
| [spell.duration](#spellduration)                                 | string     | _true_   |                    |
| [component.verbal](#componentverbal)                             | boolean    |          | _false_            |
| [component.somatic](#componentsomatic)                           | boolean    |          | _false_            |
| [component.material](#componentmaterial)                         | boolean    |          | _false_            |
| [component.material_description](#componentmaterial_description) | string     |          | —                  |
| [spell.concentration](#spellconcentration)                       | boolean    |          | _false_            |
| [spell.ritual](#spellritual)                                     | boolean    |          | _false_            |
| [spell.spellcasters](#spellspellcasters)                         | string     |          | —                  |

_TODO: add additional flags for specifics, e.g. attack, saving throw, etc_

### spell.level

The `spell.level` property specifies the level of the spell. When set to `0`, the spell will be considered to be a _Cantrip_.

```xml
<!-- e.g. set the level to 3 for the fireball spell -->
<property name="spell.level">3</property>
```

```xml
<!-- e.g. set the level to 0 for the eldritch blast cantrip -->
<property name="spell.level">0</property>
```

### spell.magic_school

The `spell.magic_school` property specifies the magic school this spell belongs to.

The possible values are: 

- `Abjuration`
- `Conjuration`
- `Divination`
- `Enchantment`
- `Evocation`
- `Illusion`
- `Necromancy`
- `Transmutation`

In addition to the possible values custom elements of the `Magic School` type can be created and its name can then be used here.

```xml
<property name="spell.magic_school">Evocation</property>
```

### spell.casting_time

The `spell.casting_time` property specifies the time it takes to cast the spell.

The most common values are:

- `1 action`
- `1 bonus action`
- `1 reaction`
- `1 minute`

```xml
<property name="spell.casting_time">1 action</property>
```

### spell.range

The `spell.range` property specifies the range of the spell.

These are some examples of spell ranges:

- `15 feet`
- `30 feet`
- `60 feet`
- `Self (15-foot cone)`
- `Self (30-foot radius)`
- `Self (60-foot line)`
- `Touch`

```xml
<property name="spell.range">30 feet</property>
```

### spell.duration

The `spell.duration` property specifies duration of the spell.

The most common values are:

- `1 round`
- `1 minute`
- `10 minutes`
- `Concentration, up to 1 minute`
- `Concentration, up to 10 minutes`
- `Instantaneous`

```xml
<property name="spell.duration">Instantaneous</property>
```

### component.verbal

The `component.verbal` property specifies whether the spell requires a verbal component to cast.

```xml
<property name="component.verbal">true</property>
```

### component.somatic

The `component.somatic` property specifies whether the spell requires a somatic component to cast.

```xml
<property name="component.somatic">true</property>
```

### component.material

The `component.material` property specifies whether the spell requires a material component to cast. This may be set to true automatically when `component.material_description` has an entry.

```xml
<property name="component.material">true</property>
```

### component.material_description

The `component.material_description` specifies the material component required to cast the spell. There are some spells that comesume the components when cast.

```xml
<property name="component.material_description">a handful of sand, a dab of ink, and a writing quill plucked from a sleeping bird</property>
```

### spell.concentration

The `spell.concentration` property specifies whether the spell requires concentration. This may be set to true when the `spell.duration` entry contains the word `concentration`.

```xml
<property name="spell.concentration">true</property>
```

### spell.ritual

The `spell.ritual` property specifies whether the spell can be cast as a ritual.

```xml
<property name="spell.ritual">true</property>
```

### spell.spellcasters

The `spell.spellcasters` property specifies the _semi-colon_ separated list of spellcaster that have this spell on their spelllist.

_Note: this example is not final, there is a good chance that this will be omitted and done differently (handled automatically by the engine)._

```xml
<!-- e.g. the spell is on the spelllist of the sorcerer, wizard, and warlock classes -->
<property name="spell.spellcasters">Sorcerer;Wizard;Warlock;</property>
```
