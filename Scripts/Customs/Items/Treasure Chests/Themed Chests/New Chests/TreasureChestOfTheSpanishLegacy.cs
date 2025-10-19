using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSpanishLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheSpanishLegacy()
        {
            Name = "Treasure Chest of the Spanish Legacy";
            Hue = Utility.RandomList(1161, 1153, 1359, 1364); // reds, golds

            // Decorative and consumable items
            AddItem(CreateNamedItem<ArtifactVase>("Vase of Alhambra", 1177), 0.15);
            AddItem(CreateNamedItem<RoyalSpanishBanner>("Royal Banner of Castile", 1153), 0.10);
            AddItem(CreateNamedItem<Goblet>("Goblet of El Cid", 242), 0.14);
            AddItem(CreateNamedItem<BottleArtifact>("Spanish Wine of Rioja", 37), 0.17);
            AddItem(CreateNamedItem<Plate>("Bread of Santiago", 2106), 0.15);
            AddItem(CreateNamedItem<Sculpture1Artifact>("Bust of Queen Isabella", 1281), 0.12);
            AddItem(CreateNamedItem<DecoTarot>("Tarot of the Spanish Mystics", 1976), 0.11);
            AddItem(CreateNamedItem<GoldBricks>("Doubloons from the Treasure Fleet", 2213), 0.14);
            AddItem(CreateNamedItem<WolfStatue>("Iberian Wolf Figurine", 2217), 0.11);
            AddItem(CreateNamedItem<IncenseBurner>("Incense Burner of Toledo", 1897), 0.13);
            AddItem(CreateNamedItem<ExoticFish>("Golden Andalusian Fish", 2124), 0.10);

            // Unique Equipment (Weapons & Armor)
            AddItem(CreateConquistadorArmor(), 0.22);
            AddItem(CreateToledoSteelSword(), 0.18);
            AddItem(CreateInquisitionRobe(), 0.16);
            AddItem(CreateExplorerBoots(), 0.18);
            AddItem(CreateMoorishTurban(), 0.14);

            // Lore book
            AddItem(new ChroniclesOfTheSpanishKings(), 1.0);

            // Currency/gold
            AddItem(CreateGoldItem("Doubloons"), 0.18);
            AddItem(new Gold(Utility.RandomMinMax(2000, 6000)), 0.19);

            // Map to legendary Spanish city
            AddItem(CreateMap(), 0.07);
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
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Unique Equipment Creation

        private Item CreateConquistadorArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Conquistador";
            chest.Hue = 2213; // Gold
            chest.BaseArmorRating = Utility.RandomMinMax(45, 68);
            chest.Attributes.BonusHits = 15;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.Attributes.ReflectPhysical = 10;
            chest.ArmorAttributes.SelfRepair = 5;
            chest.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateToledoSteelSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Sword of Toledo Steel";
            sword.Hue = 2101;
            sword.MaxDamage = Utility.RandomMinMax(45, 65);
            sword.MinDamage = Utility.RandomMinMax(25, 40);
            sword.Attributes.WeaponDamage = 20;
            sword.Attributes.AttackChance = 12;
            sword.Attributes.DefendChance = 10;
            sword.WeaponAttributes.HitLightning = 20;
            sword.WeaponAttributes.HitLeechHits = 12;
            sword.Slayer = SlayerName.DragonSlaying;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateInquisitionRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Spanish Inquisition";
            robe.Hue = 1359; // Deep red
            robe.Attributes.BonusInt = 8;
            robe.Attributes.CastRecovery = 4;
            robe.Attributes.LowerManaCost = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 14.0);
            robe.Resistances.Fire = 12;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateExplorerBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Spanish Explorer";
            boots.Hue = 1801;
            boots.Attributes.BonusStam = 15;
            boots.Attributes.Luck = 30;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 18.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tracking, 14.0);
            boots.Attributes.BonusDex = 8;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateMoorishTurban()
        {
            Bandana turban = new Bandana();
            turban.Name = "Moorish Silk Turban";
            turban.Hue = 1187;
            turban.Attributes.BonusMana = 10;
            turban.Attributes.BonusInt = 6;
            turban.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            turban.SkillBonuses.SetValues(1, SkillName.Inscribe, 8.0);
            XmlAttach.AttachTo(turban, new XmlLevelItem());
            return turban;
        }

        // Decorative map to a Spanish landmark
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Tartessos";
            map.Bounds = new Rectangle2D(1240, 2200, 350, 390);
            map.NewPin = new Point2D(1300, 2350);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheSpanishLegacy(Serial serial) : base(serial)
        {
        }

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

    // Example of a custom banner as a decorative artifact
    public class RoyalSpanishBanner : RandomFancyBanner
    {
        [Constructable]
        public RoyalSpanishBanner()
        {
            Name = "Royal Banner of Castile";
            Hue = 1153;
            Movable = true;
        }

        public RoyalSpanishBanner(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    // Custom Lore Book
    public class ChroniclesOfTheSpanishKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Spanish Kings", "Brother Alonso de Segovia",
            new BookPageInfo
            (
                "From the green hills of Galicia",
                "to the golden plains of Andalusia,",
                "the kingdoms of Spain have risen,",
                "clashed, and united in glorious",
                "conquest and tragic war."
            ),
            new BookPageInfo
            (
                "We recall the Visigoth kings,",
                "who fought the Moors at Covadonga.",
                "Seven centuries of Reconquista,",
                "ending with the banners of Castile",
                "and Aragon over Granada."
            ),
            new BookPageInfo
            (
                "The age of gold dawned as ships",
                "set sail from Seville. The New World",
                "revealed riches and mysteries.",
                "Great explorers: Columbus, Cortés,",
                "Pizarro, Elcano, Magellan."
            ),
            new BookPageInfo
            (
                "Yet the weight of empire is heavy.",
                "Wars with France and England.",
                "Armadas lost to the storms. Faith",
                "tested in fire by Inquisitors,",
                "and by dreams of glory and unity."
            ),
            new BookPageInfo
            (
                "O seeker of treasures, know this:",
                "what you hold is the legacy of",
                "a thousand years—of poets and kings,",
                "knights and scholars, martyrs and",
                "saints. Guard it well."
            ),
            new BookPageInfo
            (
                "For Spain endures not in gold,",
                "but in the soul of its people,",
                "in the music of its language,",
                "and in the courage of those",
                "who remember."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheSpanishKings() : base(false)
        {
            Hue = 1153; // Royal red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Spanish Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Spanish Kings");
        }

        public ChroniclesOfTheSpanishKings(Serial serial) : base(serial) { }

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
