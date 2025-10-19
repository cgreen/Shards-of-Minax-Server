using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMexicosLegacy : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfMexicosLegacy()
        {
            Name = "Treasure Chest of Mexico’s Legacy";
            Hue = 2125; // Deep green

            // Add unique items with probabilities
            AddItem(CreateDecorativeItem<AztecCalendarStone>("Sun Stone of Tenochtitlán", 2124), 0.12);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Maya Jade Vase", 1359), 0.16);
            AddItem(CreateDecorativeItem<GoldenEagleStatuette>("Golden Eagle of the Mexica", 2213), 0.10);
            AddItem(CreateDecorativeItem<Painting2WestArtifact>("La Lucha de la Independencia", 2125), 0.14);
            AddItem(CreateDecorativeItem<DecorativeShield8>("Shield of the Jaguar Warrior", 1151), 0.10);
            AddItem(CreateDecorativeItem<Bandana>("Revolutionary Bandana", 1358), 0.18);
            AddItem(CreateDecorativeItem<RandomFancyPlant>("Cactus of the Nopal", 1417), 0.20);
            AddItem(CreateDecorativeItem<SugarSkullArtifact>("Calavera de Azúcar", 1170), 0.18);

            // Food/Consumables
            AddItem(CreateConsumableItem<GreenTea>("Cup of Ancient Cacao", 1278), 0.13);
            AddItem(CreateConsumableItem<BottleArtifact>("Flask of Pulque", 1148), 0.15);
            AddItem(CreateConsumableItem<Muffins>("Sweet Pan de Muerto", 1173), 0.18);
            AddItem(CreateConsumableItem<CoffeeMug>("Revolutionary Coffee", 1175), 0.10);

            // Powerful unique equipment
            AddItem(CreateUniqueWeapon(), 0.19);
            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateUniqueClothing(), 0.19);

            // Decorative gold
            AddItem(new Gold(Utility.Random(2500, 4000)), 0.22);

            // Lore book
            AddItem(new ChroniclesOfTheEagleAndSerpent(), 1.0);

            // Rare items
            AddItem(CreateDecorativeItem<FeatheredHat>("Hat of the Mariachi", 2309), 0.11);
            AddItem(CreateDecorativeItem<FlowerGarland>("Garland of Xochitl", 1177), 0.13);
        }

        // Utility method to add with probability
        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative items
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumables
        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.LootType = LootType.Blessed;
            return item;
        }

        // Unique Weapon: "Macuahuitl of the Sun"
        private Item CreateUniqueWeapon()
        {
            Katana macuahuitl = new Katana();
            macuahuitl.Name = "Macuahuitl of the Sun";
            macuahuitl.Hue = 2121; // Deep amber
            macuahuitl.MinDamage = 30;
            macuahuitl.MaxDamage = 70;
            macuahuitl.WeaponAttributes.HitFireArea = 30;
            macuahuitl.WeaponAttributes.HitLeechHits = 20;
            macuahuitl.WeaponAttributes.SelfRepair = 10;
            macuahuitl.Attributes.BonusStr = 10;
            macuahuitl.Attributes.BonusHits = 25;
            macuahuitl.Attributes.AttackChance = 10;
            macuahuitl.Slayer = SlayerName.ReptilianDeath;
            macuahuitl.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(macuahuitl, new XmlLevelItem());
            return macuahuitl;
        }

        // Unique Armor: "Serpent Scale Armor"
        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Serpent Scale Armor";
            armor.Hue = 1417; // Greenish
            armor.BaseArmorRating = 55;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.BonusDex = 15;
            armor.Attributes.ReflectPhysical = 10;
            armor.Attributes.BonusMana = 10;
            armor.ArmorAttributes.SelfRepair = 7;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique Clothing: "Guadalupana Cloak"
        private Item CreateUniqueClothing()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Guadalupana Cloak";
            cloak.Hue = 2125; // Green
            cloak.Attributes.Luck = 50;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.RegenHits = 5;
            cloak.Attributes.RegenMana = 3;
            cloak.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Special Statuette
        private class GoldenEagleStatuette : SilverSteedZooStatuette
        {
            [Constructable]
            public GoldenEagleStatuette()
            {
                Name = "Golden Eagle of the Mexica";
                Hue = 2213;
            }

            public GoldenEagleStatuette(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        // Sugar Skull Statuette
        private class SugarSkullArtifact : Sculpture1Artifact
        {
            [Constructable]
            public SugarSkullArtifact()
            {
                Name = "Calavera de Azúcar";
                Hue = 1170;
            }

            public SugarSkullArtifact(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        // Aztec Sun Stone (Calendar Stone)
        private class AztecCalendarStone : DecoRock
        {
            [Constructable]
            public AztecCalendarStone()
            {
                Name = "Sun Stone of Tenochtitlán";
                Hue = 2124;
            }

            public AztecCalendarStone(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public TreasureChestOfMexicosLegacy(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    // Lore Book
    public class ChroniclesOfTheEagleAndSerpent : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Eagle and the Serpent", "Anonymous Scribe",
            new BookPageInfo
            (
                "From the dawn of the",
                "Olmec, Maya, and Aztec,",
                "Mexico’s lands have sung",
                "with the voices of gods,",
                "jaguar, and maize. Here,",
                "Quetzalcoatl flew, and the",
                "Sun Stone spun time’s",
                "circle in Tenochtitlán."
            ),
            new BookPageInfo
            (
                "The Eagle devoured the",
                "serpent upon the cactus,",
                "founding a city of wonders.",
                "Empires rose and fell,",
                "stones and feathers built",
                "pyramids, and gold called",
                "to distant lands beyond",
                "the sea."
            ),
            new BookPageInfo
            (
                "Conquest thundered in",
                "armor and fire. Yet the",
                "spirit endured, mixing blood,",
                "song, and prayer. New gods",
                "danced with old. Hidalgo’s",
                "cry shattered silence,",
                "as freedom’s wind swept",
                "the land."
            ),
            new BookPageInfo
            (
                "Through revolution and",
                "rebirth, the people wove",
                "colorful banners. The sun",
                "rose on painters, poets,",
                "heroes, and dreamers.",
                "Mexico became more than",
                "its wounds: it became",
                "fiesta, memory, hope."
            ),
            new BookPageInfo
            (
                "Now, beneath the agave,",
                "where ancient bones sleep,",
                "the eagle’s wings rise again.",
                "The serpent whispers wisdom,",
                "and the cactus blooms red.",
                "This chest holds the legacy:",
                "history, struggle, and the",
                "spirit of México eterno."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheEagleAndSerpent() : base(false)
        {
            Hue = 2125;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Eagle and the Serpent");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Eagle and the Serpent");
        }

        public ChroniclesOfTheEagleAndSerpent(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadEncodedInt();
        }
    }
}
