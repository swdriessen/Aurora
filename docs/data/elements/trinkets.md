# Trinkets

A trinket is usually a common item with a short description but otherwise unlisted.

You can create an element of the `Trinkets` type to have it generate a list of trinkets that will be available from the equipment section. 

- The `trinkets.group` property indicates the name this trinket will fall under. This is used when randomizing a trinket from a group. It defaults to the name of the `Trinkets` element.
- The `trinkets.dice` property specifies which die will be used to randomize a trinket.
- The `trinkets.generate_elements` property indicates whether to generate separate elements for each trinket entry. The engine will do this for you and add them to the `Trinkets` equipment category so players can add it by choice without having to make a custom entry.

```xml
<element name="Gothic Trinkets" type="Trinkets" source="Curse of Strahd" id="ID_WOTC_COS_TRINKETS_GOTHIC_TRINKETS">
    <properties>
        <!-- defaults to the element name -->
        <property name="trinkets.group">Gothic Trinkets</property>
        <property name="trinkets.dice">d100</property>
        <property name="trinkets.generate_elements">false</property>
    </properties>
    <trinkets>
        <trinket roll="1;2">A picture you drew as a child of your imaginary friend.</trinket>
        <trinket roll="3;4">A lock that opens when blood is dripped in its keyhole.</trinket>
        <trinket roll="5;6">Clothes stolen from a scarecrow.</trinket>
        <trinket roll="7;8">A spinning top carved with four faces: happy, sad, wrathful, and dead.</trinket>
        <trinket roll="9;10">The necklace of a sibling who died on the day you were born.</trinket>
        <trinket roll="11;12">A wig from someone executed by beheading.</trinket>
        <trinket roll="13;14">The unopened letter to you from your dying father.</trinket>
        <trinket roll="15;16">A pocket watch that runs backward for an hour every midnight.</trinket>
        <trinket roll="17;18">A winter coat stolen from a dying soldier.</trinket>
        <trinket roll="19;20">A bottle of invisible ink that can only be read at sunset.</trinket>
        <trinket roll="21;22">A wineskin that refills when interred with a dead person for a night.</trinket>
        <trinket roll="23;24">A set of silverware used by a king for his last meal.</trinket>
        <trinket roll="25;26">A spyglass that always shows the world suffering a terrible storm.</trinket>
        <trinket roll="27;28">A cameo with the profile’s face scratched away.</trinket>
        <trinket roll="29;30">A lantern with a black candle that never runs out and that burns with green flame.</trinket>
        <trinket roll="31;32">A teacup from a child’s tea set, stained with blood.</trinket>
        <trinket roll="33;34">A little black book that records your dreams, and yours alone, when you sleep.</trinket>
        <trinket roll="35;36">A necklace formed of the interlinked holy symbols of a dozen deities.</trinket>
        <trinket roll="37;38">A hangman’s noose that feels heavier than it should.</trinket>
        <trinket roll="39;40">A birdcage into which small birds fly but once inside never eat or leave.</trinket>
        <trinket roll="41;42">A lepidopterist’s box filled dead moths with skull-like patterns on their wings.</trinket>
        <trinket roll="43;44">A jar of pickled ghouls’ tongues.</trinket>
        <trinket roll="45;46">The wooden hand of a notorious pirate.</trinket>
        <trinket roll="47;48">A urn with the ashes of a dead relative.</trinket>
        <trinket roll="49;50">A hand mirror backed with a bronze depiction of a medusa.</trinket>
        <trinket roll="51;52">Pallid leather gloves crafted with ivory fingernails.</trinket>
        <trinket roll="53;54">Dice made from the knuckles of a notorious charlatan.</trinket>
        <trinket roll="55;56">A ring of keys for forgotten locks.</trinket>
        <trinket roll="57;58">Nails from the coffin of a murderer.</trinket>
        <trinket roll="59;60">A key to the family crypt.</trinket>
        <trinket roll="61;62">A bouquet of funerary flowers that always looks and smells fresh.</trinket>
        <trinket roll="63;64">A switch used to discipline you as a child.</trinket>
        <trinket roll="65;66">A music box that plays by itself whenever someone holding it dances.</trinket>
        <trinket roll="67;68">A walking cane with an iron ferule that strikes sparks on stone.</trinket>
        <trinket roll="69;70">A flag from a ship lost at sea.</trinket>
        <trinket roll="71;72">Porcelain doll’s head that always seems to be looking at you.</trinket>
        <trinket roll="73;74">A wolf’s head wrought in silver that is also a whistle.</trinket>
        <trinket roll="75;76">A small mirror that shows a much older version of the viewer.</trinket>
        <trinket roll="77;78">Small, worn book of children’s nursery rhymes.</trinket>
        <trinket roll="79;80">A mummified raven's claw.</trinket>
        <trinket roll="81;82">A broken pendent of a silver dragon that’s always cold to the touch.</trinket>
        <trinket roll="83;84">A small locked box that quietly hums a lovely melody at night but you always forget it in the morning.</trinket>
        <trinket roll="85;86">An inkwell that makes one a little nauseous when staring at it.</trinket>
        <trinket roll="87;88">An old little doll made from a dark, dense wood and missing a hand and a foot.</trinket>
        <trinket roll="89;90">A black executioner’s hood.</trinket>
        <trinket roll="91;92">A pouch made of flesh, with a sinew drawstring.</trinket>
        <trinket roll="93;94">A tiny spool of black thread that never runs out.</trinket>
        <trinket roll="95;96">A tiny clockwork figurine of a dancer that’s missing a gear and doesn’t work.</trinket>
        <trinket roll="97;98">A black wooden pipe that creates puffs of smoke that look like skulls.</trinket>
        <trinket roll="99;100">A vial of perfume, the scent of which only certain creatures can detect.</trinket>
    </trinkets>
</element>


```



```


grant fireball
properties spell.range => adorn spell element

