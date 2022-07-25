# Element

The element is still the building block to build up content. It will have a number of sections that serve a specific function.

- [Header](#header)
- [Properties](#properties)
- [Descriptions](#description)
- Equipment
- Rules

## Header

The 'header' of the element will contains the basics to identify the specific element.

- Name
- Type
- Source
- Id

The `source` _might_ still be on part of the header but it will have a dedicated section or a set of additional properties.

```xml
<!-- example source properties -->
<properties>
    <property name="source.id">ID_SOURCE_1</property>
    <property name="source.url">https://github.com/swdriessen/Aurora</property>
    <property name="source.page">42</property>
</properties>
````

## Properties

This will be a list that can set any information required by the engine to do it's thing. The more information provided, the more flexibility it can provide. It is also a lot less error prone when it doesn't have to parse content such as `1d8 piercing` and allows to alter individual properties at runtime e.g. increase `<property name="damage.dice.amount">1</property>` by 1 using a conditional rule.

## Description

There are several types of descriptions that will be needed, mainly the description that holds information for the element and the description that will be displayed on the sheet. Different languages are not taken into account here yet as to not over complicate it.

All descriptions will be provided in encoded HTML, with some exceptions for _short_ descriptions.

- Element Descriptions
    - Information Section
    - Rules Section
- Equipment
- Sheet
- Additional Effects
- Properties

```xml
<!-- example of a sheet description entry -->
<sheet>
    <descriptions>
        <description>&lt;p&gt;This is the first description.&lt;/p&gt;</description>
    </descriptions>
</sheet>
```

## Element Description

The description is the primary description section that will be displayed when viewing the item for selection or from the compendium. You can separate the description in sections so the user can customize the way the information/lore is displayed in combination with the rules section.

```xml
<!-- example of a sheet description entry -->
<description lang="en-US" target="description.information">
    <content lang="en-US">&lt;p&gt;This is the description that has the information.&lt;/p&gt;</content>
</description>
<description lang="en-US" target="description.rules">
    <section id="information">
        <content>&lt;p&gt;This is the first description for the information part.&lt;/p&gt;</content>
    </section>
    <section id="rules">
        <content>&lt;p&gt;This is the description for the rules part.&lt;/p&gt;</content>
    </section>
</description>
```

The layout can be customized and the user can for example hide the information section when they are only interested in the rules section.

The default layout of an element is as follows:

- header (defaults to the name of the element)
- content
    - information
    - rules
- footer (defaults to the source uri of the element)

You can override sections by setting an id with this name on the description section.

```html
<div>
    <section id="header">
        <!-- section for the name of the element -->        
        <!-- e.g. the name and type of a magic item -->
    </section>
    <section id="content">
        <section id="information">
            <!-- this div will be populated with the information description -->
            <!-- e.g. lore about the dwarven race -->
        </section>
        <section id="rules">
            <!-- this div will be populated with the rules description -->
            <!-- racial traits for the dwarven race -->
        </section>
    </section>    
    <section id="footer">
        <!--  -->
        <!-- e.g. System Reference Document -->
    </section>
</div>
```


## Export

The export note will contain version of the element that will be used when exporting it, for example to a character sheet (document) or card.

```xml
<!-- example of a sheet description section -->
<document>
    <section target="export.features">
        <properties>
            <property name="description.alternative_name"></property>
            <property name="description.action"></property>
            <property name="description.usage"></property>
            <property name="description.display">false</property>
        </properties>
        <description>
            <properties>
                <property name="description.alternative_name"></property>
                <property name="description.action"></property>
                <property name="description.usage"></property>
                <property name="description.display">false</property>
                <property name="description.level">4</property>
            </properties>
            <content>&lt;p&gt;This is the first description.&lt;/p&gt;</content>
        </description>
    </section>
    <section target="spell.short">
        <properties>
            <property name="description.alternative_name"></property>
            <property name="description.action"></property>
            <property name="description.usage"></property>
            <property name="description.display">false</property>
        </properties>
        <description>
            <properties>
                <property name="description.alternative_name"></property>
                <property name="description.action"></property>
                <property name="description.usage"></property>
                <property name="description.display">false</property>
                <property name="description.level">4</property>
            </properties>
            <content>&lt;p&gt;This is the first description.&lt;/p&gt;</content>
        </description>
    </section>
</document>
```
