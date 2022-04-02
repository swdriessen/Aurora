# Element Properties

A in-progress collection of properties an element might have.

| Properties                           | Type       | Example                                              |
| ------------------------------------ | ---------- | ---------------------------------------------------- |
| equipment.cost.value                 | `integer`  | 15                                                   |
| equipment.cost.currency              | `string`   | gp                                                   |
| equipment.cost.display               | `string`   | 15 gp                                                |
| equipment.cost.displayformat         | `string`   | `{{equipment.cost.value}} {{equipment.cost.currency}}` |
| equipment.weight.value               | `decimal`  | 3                                                    |
| equipment.weight.unit                | `string`   | lb.                                                  |
| equipment.weight.display             | `string`   | 3 lb.                                                |
| —                                    |            |                                                      |
| equippable                           | `boolean`  | true                                                 |
| equippable.target                    | `string`   | twohand                                              |
| —                                    |            |                                                      |
| attunable                            | `boolean`  | true                                                 |
| attunable.target                     | `string`   | by a wizard                                          |
| —                                    |            |                                                      |
| enhancement.value                    | `integer`  | 2                                                    |
| —                                    |            |                                                      |
| weapon.category                      | `string`   | Martial Melee                                        |
| weapon.melee                         | `boolean`  | true                                                 |
| weapon.melee.ability                 | `string`   | Strength                                             |
| weapon.ranged                        | `boolean`  | false                                                |
| weapon.ranged.ability                | `string`   | —                                                    |
| weapon.group                         | `string`   | Swords                                               |
| weapon.proficiency                   | `string`   | Longsword                                            |
| weapon.properties                    | `string[]` | Slashing, Versatile                                  |
| weapon.properties.special            | `string[]` | —                                                    |
| —                                    |            |                                                      |
| weapon.range.display                 | `string`   |                                                      |
| weapon.range.short                   | `string`   |                                                      |
| weapon.range.long                    | `string`   |                                                      |
| —                                    |            |                                                      |
| damage.ability                       | `string`   | Strength                                             |
| —                                    |            |                                                      |
| damage.display                       | `string`   | 1d8 slashing                                         |
| damage.dice                          | `string`   | 1d8                                                  |
| damage.dice.amount                   | `string`   | 1                                                    |
| damage.dice.size                     | `string`   | 8                                                    |
| damage.type                          | `string`   | slashing                                             |
| —                                    |            |                                                      |
| versatile.damage.display             | `string`   | 1d10 slashing                                        |
| versatile.damage.dice                | `string`   | 1d10                                                 |
| versatile.damage.dice.amount         | `string`   | 1                                                    |
| versatile.damage.dice.size           | `string`   | 10                                                   |
| versatile.damage.type                | `string`   | slashing                                             |
