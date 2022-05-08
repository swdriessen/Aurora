# Equipment

- [Inventory](#inventory)

## Inventory

The inventory should store all of your belongings.

- Items
    - Mundane Items
    - Weapons
    - Armor
    - Magic Items
- Valuables
    - Coins
    - Treasure
    - Trade Goods
- Storage Containers
    - Store items in other items _e.g. bag of holding_
    - Store items in external locations _e.g. a chest, cart, or town_
- Quest Items

Besides items, the inventory may convey additional information related to the items you have.

- Active Equipment
- Attunement
- Charges
- Weight
    - Individual Weight
    - Carry Capacity
    - Weight calculators allow ignoring certain type of items based on character settings _e.g. ignore weight of coins_

Additional idea's and features the inventory might support.

- Adornment
    - Adorn existing items without having to pick a new item _e.g. put a 'Weapon of Fire' on an existing mundaine Longsword_
    - Adorn an item with multiple items _e.g. turn a Longsword into a Silvered Longsword, and then into a Silvered Longsword of Fire_
    - Allow to enable/disable adorners in the chain
    - Allow adorning mundane items _e.g. adorn a lava rock into a Lava Rock of Fire Resistance_
- Stackable enhancement bonus _e.g. apply a +1 Magic Item to an existing magic item that already has a +1 enhancement, making it a +2 Item_ 
- Stackable damage bonus _e.g. two +1d6 fire damage should stack to +2d6 fire damage_
- Extract items _e.g. Explorer's Pack_
    - Support generating mundane items" _e.g. 'Letter of Recommendation', 'Wooden Figure of a Raven'_
- Allow an element to give equipment _e.g. starting gold and equipment based on class, background, feat_
- Allow hiding details about cursed items by default
- Stack or group non-stackable non-equipped items _e.g. 5 daggers_

## Required Test Items

The first tests should include some straightforward items variations.

- Adorning (Weapon)
    - Longsword (Weapon) `Longsword`
    - Silvered Weapon (Mundane) `Silvered Longsword`
    - Weapon of Fire (Magic) `Silvered Longsword of Fire`
    - Magic Weapon, +1 (Magic) `Silvered Longsword of Fire, +1`
- Adorning (Armor)
    - Leather Armor (Armor) `Leather Armor`
    - Embroidered Armor (Mundane) `Embroidered Leather Armor`
    - Armor of Fire Resistance (Magic) `Embroidered Leather Armor of Fire Resistance`
    - Magic Armor, +2 (Magic) `Embroidered Leather Armor of Fire Resistance, +2`
- Adorner (Mundane)
    - Spyglass (Mundane) `Spyglass`
    - Item of True Sight (Magic) `Spyglass of True Sight`
- Containers / Weight Override
    - Bag of Holding (Container, Weightless)
- Extracting
    - Item Pack ('readonly' Container)

## Extracting

Extractable items are marked with `item.extractable` and will be removed once extracted. You can extract a preset item (an item with an identifier) or a mundate item that can be generated on the spot.

You can also add some properties to these mundane items such as cost, weight, stackable, or whether they are a valuable item such as treasure.

## Equipment Data Provider

The `IEquipmentDataProvider` is responsible for providing all elements related to equipment. This can be used to either fill a store or retrieve items that need to be obtained by another component.
 
- Elements
    - Items
    - Armor
    - Weapons
    - Magic Items

The provider should have a filtered list based on for example source restrictions. This way there is no need to filter it everywhere the interface is used. There should be something like an `ISourceRestriction` interface that can hook into the provider and act like some sort of middleware.

## Equipment Extractor

The `IEquipmentExtractor` is responsible for extracting item packs into a collection individual items.

## Equipment Store

The equipment store is responsible for providing all that is needed to a store front from which to retrieve items. The `IEquipmentDataProvider` is used to provide the content for the store.
