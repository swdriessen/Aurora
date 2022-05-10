# Item

All basic items are of the `Item` type.

_TODO: generic element doc_

## Properties

All item properties have additional details and a small example snippet in XML below. Most of these properties are currently prefixed with `item.`, this may change in the future when it is clear what is needed or how it will be structured in the end.

| Property Name                                   | Value Type | Required | Default Value                          |
| ----------------------------------------------- | :--------: | :------: | -------------------------------------- |
| [item.category](#itemcategory)                  | string     | —        | `Adventuring Gear`                     |
| [item.cost](#itemcost)                          | integer    | —        | `0`                                    |
| [item.cost.currency](#itemcostcurrency)         | string     | —        | `gp`                                   |
| [item.display_cost](#itemdisplaycost)           | string     | —        | `{{item.cost}} {{item.cost.currency}}` |
| [item.weight](#itemweight)                      | decimal    | —        | `0`                                    |
| [item.weight.unit](#itemweightunit)             | string     | —        | `lb.`                                  |
| [item.weight.ignore](#itemweightignore)         | boolean    | —        | `false`                                |
| [item.display_weight](#itemdisplayweight)       | string     | —        | `{{item.weight}} {{item.weight.unit}}` |
| [item.quantity](#itemquantity)                  | integer    | —        | `1`                                    |
| [item.stackable](#itemstackable)                | boolean    | —        | `false`                                |
| [item.valuable](#itemvaluable)                  | boolean    | —        | `false`                                |
| [item.extractable](#itemextractable)            | boolean    | —        | `false`                                |
| [item.rarity](#itemrarity)                      | string     | —        | —                                      |
| [item.name_format](#itemnameformat)             | string     | —        | —                                      |
| [item.equippable](#itemequippable)              | boolean    | —        | `false`                                |
| [item.equippable.target](#itemequippabletarget) | string     | —        | —                                      |
| [item.attunement](#itemattunement)              | boolean    | —        | `false`                                |
| [item.attunement.target](#itemattunementtarget) | string     | —        | —                                      |
| [item.enhancement](#itemenhancement)            | integer    | —        | `0`                                    |

### item.category

The `item.category` property specifies in which equipment category the item should be placed.

```xml
<property name="item.category">Adventuring Gear</property>
```

### item.cost

The `item.cost` property specifies the cost of the item in the given `item.cost.currency`.

```xml
<!-- e.g. a cost of 25, defaults to 25 gp when the item.cost.currency property is omitted -->
<property name="item.cost">25</property>
```

### item.cost.currency

The `item.cost.currency` property specifies which currency should be used for this item.

The possible values are: 

- `cp` for copper
- `sp` for silver
- `ep` for electrum
- `gp` for gold
- `pp` for platinum

```xml
<property name="item.cost.currency">gp</property>
```

### item.display_cost

The `item.display_cost` property specifies a custom way to display the cost of the item. When this property is omitted the `item.cost` and `item.cost.currency` are concatinated to create the display cost.

```xml
<!-- e.g. perhaps you want to indicate a cost / quantity -->
<property name="item.display_cost">1 gp / 20 Arrows</property>
```

### item.weight

The `item.weight` property specifies the weight of the item in decimals which is used in the calculations. The weight should be in the given `item.weight.unit`.

```xml
<!-- e.g. a weight of 2, defaults to 2 lb. when the item.weight.unit property is omitted -->
<property name="item.weight">2</property>
```

### item.weight.unit

The `item.weight.unit` property specifies the unit in which to display the item.

```xml
<property name="item.weight.unit">lb.</property>
```

### item.display_weight

The `item.display_weight` property specifies a custom way to display the weight of the item. When this property is omitted the `item.weight` and `item.weight.unit` are concatinated to create the display weight.

```xml
<!-- e.g. a way to display a weight of 0.25 lb. -->
<property name="item.display_weight">1/4 lb.</property>
```

### item.weight.ignore

The `item.weight.ignore` property specifies whether or not to ignore the weight of the item in the weight calculation

```xml
<!-- e.g. a bag of holding will have the property set to true -->
<property name="item.weight.ignore">true</property>
```

### item.quantity

The `item.quantity` property specifies the quantity that should be added when this item is added. The quantity defaults to 1 and is only considered a bulk purchase when greater than 1.

```xml
<!-- e.g. 20 arrows from a single purchase -->
<property name="item.quantity">20</property>
```

### item.stackable

The `item.stackable` property specifies that multiple quantities of the item can be stacked on a single instance of the item.

```xml
<!-- e.g. a potion or arrows would be allowed to be stacked -->
<property name="item.stackable">true</property>
```

### item.valuable

The `item.valuable` property specifies if this item is consired to be a valuable item. These items are usually sold for 100% of their cost and might appear in a different section on the sheet.

```xml
<!-- e.g. a treasure object such as a gemstone or an art object  -->
<property name="item.valuable">true</property>
```

### item.extractable

The `item.extractable` property specifies that it can be extracted into multiple different items that will then be added to the inventory.

```xml
<!-- e.g. an explorer's pack -->
<property name="item.extractable">true</property>
```

This requires the extractable items to be defined in the element.

```xml
<!-- e.g. adds a longbow, 20 arrows, and a mundane item 'Map of the Wilderness' when extracted -->
<extractable>
    <extract id="ID_WEAPON_LONGBOW" />
    <extract id="ID_ITEM_ARROW" quantity="20" />
    <!-- when no id is provided, a custom item is created by the engine -->
    <extract name="Map of the Wilderness" />
</extractable>
```

_TODO: allow slightly more complex extractions_

### item.rarity

The `item.rarity` property, which is optional, specifies the rarity of the item.

The possible values are: 

- `Common`
- `Uncommon`
- `Rare`
- `Very Rare`
- `Legendary`
- `Artifact`
- `Unique`

```xml
<!-- e.g. a rarity of a wand of polymorph  -->
<property name="item.rarity">Very Rare</property>
```

### item.name_format

The `item.name_format` property specifies the display name of the item where you can use inline replacements to format the result. This is used in items that enhance, enchant, or otherwise _decorate_ an existing item.

You should surround your replacement property like so; `{{replacement}}` and you can use the following variables to replace:

- `parent` will be replaced with the display name of the item you decorate
- ...

```xml
<!-- e.g. a Silvered Weapon that when applied on a Longsword would result in a Silvered Longsword -->
<property name="item.name_format">Silvered {{parent}}</property>
```

### item.equippable

The `item.equippable` property specifies whether the item can be equipped. Some items like weapons and armor can be equipped, but also common items such as a pair of boots or a feathered hat show be allowed to be equipped.

The `rules` of an item only apply when an item is equipped or attuned instead of just having it in your inventory.

```xml
<property name="item.equippable">true</property>
```

### item.equippable.target

The `item.equippable.target` property specifies what equipment slot the item can be equipped in. It can be omitted for anything other than a weapon, armor, or shield for which a limited combination of equipment can be equipped. You can also use it for items such as musical instruments, wands, or orbs etc.

The possible values are currently: 

- `onehand` for a one-handed item that can be wielded anyway you like
- `twohand` for a two-handed item
- `onehand;secondary` for a one-handed item that can only be wielded in the secondary hand (off-hand)
- `primary` for an item that can only be wielded in the primary hand (main-hand)
- `secondary` for an item that can only be wielded in the secondary hand (off-hand)
- in the future you may see a use for equipment slots, then you would for example specify `ring` for a ring, or `feet` for a pair of boots

```xml
<!-- e.g. a longsword -->
<property name="item.equippable.target">onehand</property>
```

### item.attunement

The `item.attunement` property specifies the requirement for an item to require attunement.

The `rules` of an item only apply when an item is equipped or attuned instead of just having it in your inventory.

```xml
<!-- e.g. a wand of wonder -->
<property name="item.attunement">true</property>
```

### item.attunement.target

The `item.attunement.target` property specifies a requirement on top of the attunement. This often comes in the form of a class (or spellcaster), alignment, or race.

This entry is pure for display purposes. The actual requirement will be enforced when a character wants to attune to the item, it does not prevent it from appearing in the inventory; e.g. in a backpack or bag of holding.

```xml
<!-- e.g. a wand of wonder -->
<property name="item.attunement.target">by a spellcaster</property>
```

### item.enhancement

The `item.enhancement` property specifies a value of the enhancement that will be applied to the item or the parent item if it's an item that decorates one, such as a _+1 Magic Weapon_. 

```xml
<!-- e.g. +2 Magic Weapon -->
<property name="item.enhancement">2</property>
```
