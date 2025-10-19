using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSudaneseHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSudaneseHistory()
        {
            Name = "Treasure Chest of Sudanese History";
            Hue = 2107; // Deep sand gold

            // Add themed items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Kushite Burial Urn", 2413), 0.25);
            AddItem(CreateDecorativeItem<GoldBricks>("Gold of Napata", 1428), 0.20);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Oracle of Meroe", 2052), 0.18);
            AddItem(CreateDecorativeItem<AncientDrum>("Royal Drum of Sennar", 1167), 0.17);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Brazier of the Desert Kings", 1270), 0.16);
            AddItem(CreateDecorativeItem<SnakeStatue>("Serpent Idol of Gebel Barkal", 1267), 0.16);
            AddItem(CreateDecorativeItem<WaterRelic>("Nile River Relic", 92), 0.13);
            AddItem(CreateNamedConsumable<GreaterHealPotion>("Nubian Healing Balm", 1438), 0.22);
            AddItem(CreateNamedConsumable<BottleArtifact>("Ancient Date Wine", 2424), 0.12);
            AddItem(CreateNamedConsumable<BowlOfRotwormStew>("Sorghum Stew", 1447), 0.10);
            AddItem(CreateNamedConsumable<BreadLoaf>("Kisra Bread", 1102), 0.18);

            // Unique equipment
            AddItem(CreateWarriorHelm(), 0.20);
            AddItem(CreateRoyalArmor(), 0.18);
            AddItem(CreatePriestRobe(), 0.18);
            AddItem(CreateDesertCloak(), 0.20);
            AddItem(CreatePharaohScepter(), 0.20);
            AddItem(CreateAncientShield(), 0.14);

            // Miscellaneous riches
            AddItem(new Gold(Utility.Random(2500, 3500)), 0.20);
            AddItem(CreateNamedGem<StarSapphire>("Star Sapphire of Kush", 2066), 0.11);
            AddItem(CreateNamedGem<Ruby>("Ruby of the Nubian Queen", 1782), 0.10);

            // Map to an ancient tomb
            AddItem(CreateAncientMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedGem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Equipment
        private Item CreateWarriorHelm()
        {
            Bascinet helm = new Bascinet();
            helm.Name = "Helm of the Black Pharaoh";
            helm.Hue = 1175; // Gold
            helm.BaseArmorRating = 55;
            helm.Attributes.BonusStr = 8;
            helm.Attributes.BonusHits = 15;
            helm.Attributes.Luck = 35;
            helm.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateRoyalArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Napatan Royal Chestplate";
            armor.Hue = 2413;
            armor.BaseArmorRating = 65;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.DefendChance = 12;
            armor.Attributes.ReflectPhysical = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreatePriestRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Nubian Priest";
            robe.Hue = 2066;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.SpellDamage = 16;
            robe.Attributes.LowerManaCost = 14;
            robe.Attributes.LowerRegCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDesertCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Desert Nomad's Cloak";
            cloak.Hue = 1453;
            cloak.Attributes.BonusDex = 12;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.Luck = 20;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 14.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreatePharaohScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Scepter of Taharqa";
            scepter.Hue = 1270;
            scepter.MinDamage = 24;
            scepter.MaxDamage = 40;
            scepter.WeaponAttributes.HitFireball = 20;
            scepter.WeaponAttributes.HitLightning = 15;
            scepter.WeaponAttributes.UseBestSkill = 1;
            scepter.Attributes.SpellChanneling = 1;
            scepter.Attributes.BonusMana = 10;
            scepter.Attributes.SpellDamage = 15;
            scepter.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        private Item CreateAncientShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Kushite Vanguard";
            shield.Hue = 2213;
            shield.Attributes.DefendChance = 16;
            shield.Attributes.Luck = 30;
            shield.Attributes.BonusStam = 8;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Map to a tomb
        private Item CreateAncientMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Black Pyramid";
            map.Bounds = new Rectangle2D(5300, 850, 500, 500);
            map.NewPin = new Point2D(5450, 1100);
            map.Protected = true;
            return map;
        }

        // Lore book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheBlackPharaohs();
        }

        public TreasureChestOfSudaneseHistory(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheBlackPharaohs : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Black Pharaohs", "Scribe of Napata",
            new BookPageInfo
            (
                "Long before the rise of Rome,",
                "on the southern banks of the",
                "Nile, the kingdoms of Kush",
                "and Nubia flourished. These",
                "were the Black Pharaohs,",
                "rulers of gold, sand, and stone.",
                "",
                "The city of Kerma was the first"
            ),
            new BookPageInfo
            (
                "great capital. Traders, priests,",
                "and kings passed its gates.",
                "Soon Napata and Meroe would",
                "rise, their pyramids reaching",
                "toward the sun, their armies",
                "marching across the deserts.",
                "",
                "For centuries, Kush challenged"
            ),
            new BookPageInfo
            (
                "Egypt for supremacy. Taharqa,",
                "the most legendary Pharaoh,",
                "became Lord of the Two Lands,",
                "ruling both Egypt and Nubia.",
                "His reign brought peace and",
                "prosperity to the Nile.",
                "",
                "But the sands shift, and"
            ),
            new BookPageInfo
            (
                "empires fall. The Funj Sultanate",
                "rose where the old pyramids",
                "crumbled. Sultans and kings",
                "built palaces and mosques in",
                "the heart of Africa, their",
                "legacy woven into the land.",
                "",
                "Yet in every tomb, every city,"
            ),
            new BookPageInfo
            (
                "the treasures of Sudan's past",
                "wait to be uncovered. Beware",
                "the curse of the Black Pharaohs,",
                "for they protect their secrets,",
                "and the sands remember all.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let he who seeks this chest",
                "know: You hold in your hands",
                "the wealth of a thousand years,",
                "and the story of a people who",
                "rose, fell, and rose again, ever",
                "bound to the Nile.",
                "",
                "- Scribe of Napata"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheBlackPharaohs() : base(false)
        {
            Hue = 2107; // deep sand gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Black Pharaohs");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Black Pharaohs");
        }

        public ChroniclesOfTheBlackPharaohs(Serial serial) : base(serial) { }

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
