# Progression

There are certain parts that require some sort of progression. 

Some of them might fall into a generic _milestone_ progression e.g. stages 1, 2, and 3. This kind of progression should also be allowed to changed by the user. You might have a condition that adjusts properties based on item progression for example.

- [Character](#character-progression)
- [Class](#class-progression)
- [Companion](#companion-progression)
- [Features](#features-progression)
- [Items](#item-progression)

## Character Progression

A character progresses by gaining levels.

## Class Progression

A class progresses by gaining levels.

## Companion Progression

A companion progresses might be based on the level of the owner _e.g. character or class_.

## Features Progression

A feature might progress at certain levels or a specific value _e.g. piety_.

## Item Progression

An item might progress by stages _e.g. dorment, awakend_.

## Milestone Progression

A generic implementation of progression that can apply to a number of things, _e.g. magic items_.


```xml
<properties>
    <!-- default progression is 0 -->
    <property name="item.progression">0</property>
<properties>

<rules>
    <!-- increase progression at character level -->
    <adjust target="item.progression" value="1" condition="level == 3" />
    <adjust target="item.progression" value="2" condition="level == 5" />

    <!-- update statistics based on the item progression -->
    <statistic name="strength" value="1" bonus="item.progression" condition="item.progression == 1" />
    <statistic name="strength" value="2" bonus="item.progression" condition="item.progression == 2" />
</rules>

<!-- maybe enhance rules sections by adding requirements -->
<rules progression="2">
    <statistic name="strength" value="2" bonus="item.progression" />
</rules>
```

