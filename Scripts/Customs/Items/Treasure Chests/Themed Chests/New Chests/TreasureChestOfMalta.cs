using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMalta : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMalta()
        {
            Name = "Treasure Chest of the Maltese Isles";
            Hue = 2125; // Golden sandstone color, reminiscent of Maltese stone

            // Add themed items to the chest
            AddItem(new ChroniclesOfTheMalteseIsles(), 1.0);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Phoenician Urn of Mdina", 2419), 0.18);
            AddItem(CreateNamedItem<Sculpture1Artifact>("Statue of the Sleeping Lady", 2426), 0.13);
            AddItem(CreateNamedItem<SwordDisplay3EastArtifact>("Knight's Sword Display of St. John", 1175), 0.10);
            AddItem(CreateNamedItem<CandelabraOfSouls>("Sanctuary Candelabra", 1161), 0.13);
            AddItem(CreateNamedItem<GoldBricks>("Granite of the Grand Master's Palace", 2101), 0.11);
            AddItem(CreateNamedItem<FancyPainting>("Map of the Maltese Archipelago", 2413), 0.10);
            AddItem(CreateMalteseCrossCloak(), 0.15);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateWeapon(), 0.17);
            AddItem(CreateNamedItem<RandomFancyCoin>("Antique Maltese Tari", 2212), 0.22);
            AddItem(CreateNamedItem<SakeArtifact>("Knights' Festive Mead", 1151), 0.14);
            AddItem(CreateNamedItem<BentoBox>("Feast of St. Paul’s Bay", 2412), 0.12);
            AddItem(CreateNamedItem<RedBottle>("Elixir of the Red Tower", 33), 0.16);
            AddItem(CreateNamedItem<WhitePoinsettia>("Flower of Għar Dalam", 2518), 0.15);
            AddItem(CreateNamedItem<CrabBushel>("Crabs of Marsaxlokk Bay", 2106), 0.10);
            AddItem(CreateNamedItem<WaterRelic>("Sacred Well of Ħal Saflieni", 1266), 0.13);
            AddItem(CreateNamedItem<AncientWeapon1>("Sword of the Order", 1175), 0.13);
            AddItem(CreateNamedItem<DecorativeShield7>("Shield of Valletta", 2417), 0.13);
            AddItem(CreateNamedItem<RandomFancyStatue>("Maltese Temple Guardian", 1152), 0.08);
            AddItem(CreateNamedItem<Sandals>("Pilgrim's Sandals", 1150), 0.13);
            AddItem(CreateNamedItem<Robe>("Grandmaster’s Robe", 1175), 0.12);
            AddItem(CreateRing(), 0.12);
            AddItem(new BookOfSecrets(), 0.06);
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0) item.Hue = hue;
            return item;
        }

        private Item CreateMalteseCrossCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Maltese Cross";
            cloak.Hue = 1157; // Deep red of the Order
            cloak.Attributes.Luck = 150;
            cloak.Attributes.BonusHits = 20;
            cloak.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Hospitaller";
            chest.Hue = 2101; // Weathered steel
            chest.BaseArmorRating = 60;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.LowerManaCost = 10;
            chest.ArmorAttributes.SelfRepair = 3;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.Anatomy, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            chest.SkillBonuses.SetValues(2, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateWeapon()
        {
            Longsword sword = new Longsword();
            sword.Name = "Sword of the Great Siege";
            sword.Hue = 2106;
            sword.MaxDamage = Utility.Random(40, 75);
            sword.WeaponAttributes.HitFireball = 25;
            sword.WeaponAttributes.HitLeechHits = 10;
            sword.WeaponAttributes.UseBestSkill = 1;
            sword.WeaponAttributes.SelfRepair = 3;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.AttackChance = 15;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Mdina Mysteries";
            ring.Hue = 2213;
            ring.Attributes.Luck = 100;
            ring.Attributes.BonusInt = 7;
            ring.Attributes.BonusMana = 15;
            ring.Attributes.SpellDamage = 10;
            ring.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Malta";
            map.Bounds = new Rectangle2D(540, 2200, 800, 800); // Just for flavor
            map.NewPin = new Point2D(950, 2600);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfMalta(Serial serial) : base(serial) { }

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

    public class BookOfSecrets : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Secret Rites of the Knights", "Unknown",
            new BookPageInfo
            (
                "Within these pages lie the",
                "rites and vows of the Order.",
                "Let only those worthy read.",
                "",
                "Let faith, loyalty, and",
                "valor guide your hand."
            ),
            new BookPageInfo
            (
                "The secrets of the Order",
                "are not easily gained.",
                "Those who betray the",
                "trust shall find only",
                "shadows and silence."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfSecrets() : base(false)
        {
            Hue = 1175; // Gold-leafed pages
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Secret Rites of the Knights");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Secret Rites of the Knights");
        }

        public BookOfSecrets(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheMalteseIsles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Maltese Isles", "Archivist of Mdina",
            new BookPageInfo
            (
                "Beneath the golden sun, the",
                "isles of Malta have seen",
                "ages pass, from ancient",
                "temple builders to noble",
                "Knights of St. John.",
                "",
                "Here, the stones remember."
            ),
            new BookPageInfo
            (
                "Once, the Phoenicians sailed",
                "to these shores, bringing",
                "trade and faith. Later,",
                "Romans, Byzantines, and Arabs",
                "laid claim to the land, each",
                "leaving treasures and scars."
            ),
            new BookPageInfo
            (
                "The Knights Hospitaller came,",
                "bearing cross and sword.",
                "Valletta was built upon blood,",
                "hope, and the unbreakable",
                "spirit of the Maltese.",
                "",
                "The Great Siege, 1565."
            ),
            new BookPageInfo
            (
                "Ottoman cannons thundered,",
                "but the Order endured. Faith,",
                "courage, and sacrifice forged",
                "victory. Malta became the",
                "bulwark of Christendom.",
                "",
                "Its relics are many."
            ),
            new BookPageInfo
            (
                "The Hal Saflieni Hypogeum,",
                "a labyrinth of stone, hides",
                "secrets deeper than time.",
                "The Sleeping Lady dreams still,",
                "watched by silent guardians."
            ),
            new BookPageInfo
            (
                "Now, only the worthy may",
                "unlock these treasures. The",
                "isles guard their history well.",
                "",
                "Tread carefully, for every",
                "stone is a memory, and every",
                "memory may hold a curse."
            ),
            new BookPageInfo
            (
                "Let those who open this chest",
                "remember the Knights, the",
                "temples, and the tides that",
                "shaped Malta. Seek wisdom in",
                "the shadows, and valor in",
                "the light.",
                "",
                "- Archivist of Mdina"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheMalteseIsles() : base(false)
        {
            Hue = 1175; // Gold-leafed pages
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Maltese Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Maltese Isles");
        }

        public ChroniclesOfTheMalteseIsles(Serial serial) : base(serial) { }

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
