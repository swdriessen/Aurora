# Internal Elements

This section has some details about elements used internally by the application.

- [System Configuration](#system-configuration)
- [Equipment Configuration](#equipment-configuration)

## System Configuration

`<TBD>`

```xml
<element name="Dungeons &amp; Dragons: 5e" type="System">
    <properties>
        <property name="system.abbreviation">DND5E</property>
    </properties>
</element>
```

## Character


```xml
<!-- default character creation element, the starting point for any character, can be customized for different campaign settings etc -->


<element name="Default Character" type="Character Creation" source="Internal">    
    <properties>
        <property name="system">DND5E</property>
        <property name="sort.order">1.0</property>
    </properties>
    <rules>
        <!-- create default character based on 5e rules, additional changes can be done through character options -->
        <assign type="Rule" id="ID_ASSIGNMENT_LEVEL_PROGRESSION" />
        <assign type="Rule" id="ID_ASSIGNMENT_PROFICIENCY_BONUS" />
    </rules>
</element>
```

## Equipment Configuration

A set of item categories will be loaded based on their elements. This can be customized by homebrew content. When a source is restricted it should be removed from the list of available categories.

```xml
<!-- a collection of internal equipment categories with a sort.order property -->
<element name="Adventuring Gear" type="Equipment Category" id="ID_INTERNAL_EQUIPMENT_CATEGORY_1">
    <properties>
        <property name="sort.order">1.0</property>
    </properties>
</element>
<element name="Armor" type="Equipment Category" id="ID_INTERNAL_EQUIPMENT_CATEGORY_2">
    <properties>
        <property name="sort.order">2.0</property>
    </properties>
</element>
<element name="Weapons" type="Equipment Category" id="ID_INTERNAL_EQUIPMENT_CATEGORY_3">
    <properties>
        <property name="sort.order">3.0</property>
    </properties>
</element>
<element name="Wondrous Items" type="Equipment Category" id="ID_INTERNAL_EQUIPMENT_CATEGORY_4">
    <properties>
        <property name="sort.order">4.0</property>
    </properties>
</element>
<element name="Rings" type="Equipment Category" id="ID_INTERNAL_EQUIPMENT_CATEGORY_41">
    <properties>
        <property name="sort.order">4.1</property>
    </properties>
</element>
```

```xml
<!-- put a homebrew category in order after the internal wondrous items category -->
<element name="Magnificent Items" type="Equipment Category" source="Homebrew Source" id="ID_HOMEBREW_EQUIPMENT_CATEGORY_401">
    <properties>
        <property name="sort.order">4.0.1</property>
    </properties>
</element>
```

