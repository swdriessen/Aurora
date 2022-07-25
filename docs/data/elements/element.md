# Element

A building block


- [Element Properties](#properties)



All elements....

## Properties

All item properties have additional details and a small example snippet in XML below.

| Property Name                               | Value Type | Required | Default Value      |
| ------------------------------------------- | :--------: | :------: | ------------------ |
| [keywords](#keywords)                       | string     |          | —                  |
| [compendium](#compendium)                   | boolean    |          | `true`             |
| —                                           |            |          |                    |
| [sort.group](#sortgroup)                    | string     |          | —                  |
| [sort.order](#sortorder)                    | string     |          | —                  |
| —                                           |            |          |                    |

### keywords

The `keywords` property specifies a semi-colon separated list of keywords that can be used in search.

```xml
<property name="keywords">fire;ice;armor</property>
```

### compendium

The `compendium` property specifies a semi-colon separated list of compendium that can be used in search.

```xml
<!-- e.g. hide a feature from the compendium search -->
<property name="compendium">false</property>
```

### sort.order

The `sort.order` property specifies the order in which to sort items in selection rules.

When making selections, some elements are better left in order of creation. You should be able to sort a select set of elements to keep the desired sorting order intact.

A good example is a selection of abilities e.g. maintain the order of a _Strength, Dexterity, Charisma, Intelligence, Wisdom, and Charisma_ selection

```xml
<properties>
    <!-- sort on group (optional) and then sort on the order -->
    <property key="sort.group">1</property>
    <property key="sort.order">1</property>
</properties>
```

```xml
<!-- have a flag on the selection rule to enable sorting? -->
<selection sort="true" />
```
