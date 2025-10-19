using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTonga : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTonga()
        {
            Name = "Treasure Chest of Tonga";
            Hue = 2120; // Deep ocean blue, adjust as desired

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Lapita Pottery Fragment", 2601), 0.25);
            AddItem(CreateDecorativeItem<FancyPainting>("Polynesian Star Map", 1166), 0.18);
            AddItem(CreateDecorativeItem<AncientDrum>("Fākaʻahu Drum of Welcome", 2413), 0.15);
            AddItem(CreateDecorativeItem<FancyCopperWings>("Royal Cloak Pin of Tu'i Tonga", 2308), 0.10);
            AddItem(CreateDecorativeItem<DecorativeShield4>("Shield of the Sea People", 1277), 0.16);

            AddItem(CreateConsumable<GreenTea>("Coconut & Breadfruit Brew", 1151), 0.17);
            AddItem(CreateConsumable<Banana>("Sun-Ripened Banana", 1161), 0.15);
            AddItem(CreateConsumable<PulledPorkPlatter>("Feast Platter of ʻUmu", 2413), 0.08);

            AddItem(CreateGoldItem("Kau Tongan Gold"), 0.19);
            AddItem(CreatePearl(), 0.14);
            AddItem(CreateUniqueJewelry(), 0.16);

            AddItem(CreateTonganWeapon(), 0.25);
            AddItem(CreateTonganArmor(), 0.23);
            AddItem(CreateTonganClothing(), 0.22);

            AddItem(CreateMap(), 0.06);
            AddItem(new ChroniclesOfTonga(), 1.0);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumables (food, drink)
        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Currency
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Unique Pearl (jewel)
        private Item CreatePearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "South Sea Pearl";
            pearl.Hue = 1153; // White/silver
            return pearl;
        }

        // Unique Jewelry
        private Item CreateUniqueJewelry()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of the Moana Navigator";
            bracelet.Hue = 2413;
            bracelet.Attributes.BonusInt = 10;
            bracelet.Attributes.Luck = 40;
            bracelet.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            bracelet.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        // Tongan Weapon: "War Club of the Sea King"
        private Item CreateTonganWeapon()
        {
            WarHammer club = new WarHammer();
            club.Name = "War Club of the Sea King";
            club.Hue = 1166;
            club.WeaponAttributes.HitLightning = 30;
            club.WeaponAttributes.HitLeechStam = 10;
            club.WeaponAttributes.SelfRepair = 4;
            club.Attributes.BonusStr = 10;
            club.Attributes.BonusStam = 15;
            club.Attributes.AttackChance = 10;
            club.Attributes.WeaponSpeed = 25;
            club.SkillBonuses.SetValues(0, SkillName.Macing, 18.0);
            club.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(club, new XmlLevelItem());
            return club;
        }

        // Tongan Armor: "Breastplate of the Tu'i Tonga"
        private Item CreateTonganArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Tu'i Tonga";
            chest.Hue = 1277;
            chest.BaseArmorRating = 50;
            chest.ArmorAttributes.SelfRepair = 5;
            chest.Attributes.BonusHits = 20;
            chest.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Tongan Clothing: "Royal Tapa Robe"
        private Item CreateTonganClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Tapa Robe";
            robe.Hue = 2308;
            robe.Attributes.BonusMana = 15;
            robe.Attributes.BonusInt = 8;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Map to Tonga’s Royal Tomb
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Royal Tombs of Muʻa";
            map.Bounds = new Rectangle2D(3400, 2700, 350, 250);
            map.NewPin = new Point2D(3560, 2850);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTonga(Serial serial) : base(serial) { }

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

    // The Lore Book: Chronicles of Tonga
    public class ChroniclesOfTonga : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Tonga", "Mele Siuʻilikutapu",
            new BookPageInfo
            (
                "In the beginning, the gods",
                "cast their nets upon the sea.",
                "From the foam rose islands,",
                "bathed in sun, cradled in wind.",
                "Tonga, the Heart of Polynesia,",
                "was born in the embrace of",
                "Tangaloa the creator."
            ),
            new BookPageInfo
            (
                "The Tuʻi Tonga line rose:",
                "sacred kings, sea-lords,",
                "navigators bold. Their vaka",
                "sailed as far as the distant",
                "horizons, guided by stars",
                "etched in memory and bone."
            ),
            new BookPageInfo
            (
                "Lapita potters shaped earth,",
                "ancestors sang of ‘Umu feasts,",
                "and kava roots shared wisdom",
                "from mouth to mouth.",
                "Great stone tombs rose at Muʻa.",
                "Orators kept the past alive."
            ),
            new BookPageInfo
            (
                "Through storms, through centuries,",
                "Tonga's people stood firm.",
                "From Maui's trickster laughter",
                "to the wisdom of Lo'au,",
                "our islands echoed with",
                "legends of the blue world."
            ),
            new BookPageInfo
            (
                "Beware, seeker! Not all",
                "treasures are gold. The mana",
                "of Tonga lies in story and",
                "spirit, in the dance of the",
                "Lakalaka, in tapa cloth and",
                "star-lit nights."
            ),
            new BookPageInfo
            (
                "Should you bear this chest,",
                "remember: you carry the voice",
                "of kings, the dreams of",
                "voyagers, the salt of our sea.",
                "",
                "",
                "",
                "",
                "- End -"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTonga() : base(false)
        {
            Hue = 1166; // Deep blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Tonga");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Tonga");
        }

        public ChroniclesOfTonga(Serial serial) : base(serial) { }

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
