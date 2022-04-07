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
