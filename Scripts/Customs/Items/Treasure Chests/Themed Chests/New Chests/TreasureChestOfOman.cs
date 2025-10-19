using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfOman : WoodenChest
    {
        [Constructable]
        public TreasureChestOfOman()
        {
            Name = "Treasure Chest of Oman's Legacy";
            Hue = 2415; // Sand-gold

            // Add themed items to the chest
            AddItem(new ChroniclesOfOman(), 1.0);
            AddItem(CreateColoredItem<ArtifactLargeVase>("Frankincense Burner of Sohar", 2932), 0.15);
            AddItem(CreateColoredItem<IncenseBurner>("Ancient Incense Burner", 1175), 0.10);
            AddItem(CreateColoredItem<Gold>("Omani Sultanate Coin", 2424), 0.30);
            AddItem(CreateNamedItem<Sextant>("Astrolabe of the Dhows"), 0.10);
            AddItem(CreateColoredItem<BottleArtifact>("Perfumed Vial of Frankincense", 1260), 0.20);
            AddItem(CreateNamedItem<BentoBox>("Dates of the Desert Caravan"), 0.15);
            AddItem(CreateColoredItem<GreenTea>("Spiced Omani Coffee", 1437), 0.12);
            AddItem(CreateDhowModel(), 0.10);
            AddItem(CreateTradeContracts(), 0.09);
            AddItem(CreateOmaniKhanjar(), 0.15);
            AddItem(CreateSultansRobe(), 0.17);
            AddItem(CreateNavigatorsCloak(), 0.13);
            AddItem(CreateWarriorArmor(), 0.20);
            AddItem(CreateSultansScepter(), 0.09);
            AddItem(CreateSongOfTheSeaLute(), 0.09);
            AddItem(CreateMapToSalalah(), 0.07);
            AddItem(new Gold(Utility.Random(2500, 7000)), 0.22);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateDhowModel()
        {
            AncientShipModelOfTheHMSCape model = new AncientShipModelOfTheHMSCape();
            model.Name = "Miniature Omani Dhow Model";
            model.Hue = 2210;
            return model;
        }

        private Item CreateTradeContracts()
        {
            SimpleNote note = new SimpleNote();
            note.TitleString = "Silk Road Trade Contracts";
            note.NoteString = "Bound in ancient script, these contracts reveal Oman's trading prowess linking east and west—spices, silk, gold, and incense exchanged by sea and desert caravan.";
            return note;
        }

        private Item CreateOmaniKhanjar()
        {
            Dagger khanjar = new Dagger();
            khanjar.Name = "Khanjar of the Sultan";
            khanjar.Hue = 2413; // Ivory-gold
            khanjar.MinDamage = 34;
            khanjar.MaxDamage = 76;
            khanjar.Attributes.BonusDex = 12;
            khanjar.Attributes.BonusStam = 8;
            khanjar.Attributes.Luck = 150;
            khanjar.WeaponAttributes.HitHarm = 20;
            khanjar.WeaponAttributes.HitLowerAttack = 15;
            khanjar.WeaponAttributes.SelfRepair = 5;
            khanjar.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            khanjar.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            khanjar.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(khanjar, new XmlLevelItem());
            return khanjar;
        }

        private Item CreateSultansRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Sultans";
            robe.Hue = 1150; // Deep blue
            robe.Attributes.BonusInt = 15;
            robe.Attributes.BonusMana = 12;
            robe.Attributes.LowerManaCost = 8;
            robe.Attributes.LowerRegCost = 10;
            robe.Attributes.Luck = 80;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateNavigatorsCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Navigator’s Cloak of Muscat";
            cloak.Hue = 2067; // Sea green
            cloak.Attributes.BonusDex = 10;
            cloak.Attributes.BonusStam = 10;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.RegenStam = 2;
            cloak.Attributes.Luck = 40;
            cloak.SkillBonuses.SetValues(0, SkillName.TasteID, 18.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Fishing, 16.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Cartography, 16.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateWarriorArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Mail of the Bahla Warrior";
            armor.Hue = 1987; // Sandstone bronze
            armor.BaseArmorRating = 63;
            armor.Attributes.BonusStr = 12;
            armor.Attributes.RegenHits = 4;
            armor.Attributes.ReflectPhysical = 10;
            armor.Attributes.BonusHits = 25;
            armor.SkillBonuses.SetValues(0, SkillName.Swords, 14.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateSultansScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Scepter of the Sultan’s Wisdom";
            scepter.Hue = 1171; // White-gold
            scepter.MinDamage = 24;
            scepter.MaxDamage = 55;
            scepter.Attributes.SpellChanneling = 1;
            scepter.Attributes.BonusInt = 18;
            scepter.Attributes.BonusMana = 20;
            scepter.Attributes.LowerManaCost = 12;
            scepter.Attributes.SpellDamage = 20;
            scepter.SkillBonuses.SetValues(0, SkillName.Magery, 17.0);
            scepter.SkillBonuses.SetValues(1, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        private Item CreateSongOfTheSeaLute()
        {
            Lute lute = new Lute();
            lute.Name = "Lute of the Arabian Sea";
            lute.Hue = 1152; // Deep turquoise
            return lute;
        }

        private Item CreateMapToSalalah()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map to Salalah Port";
            map.Bounds = new Rectangle2D(3450, 1270, 500, 400);
            map.NewPin = new Point2D(3540, 1450);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfOman(Serial serial) : base(serial)
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

    public class ChroniclesOfOman : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Sultanate: The History of Oman", "Sultan’s Court Scribe",
            new BookPageInfo
            (
                "From the dawn of the copper",
                "trade in Magan, Oman's sands",
                "bore the footfalls of ancient",
                "peoples. Here, the incense",
                "roads met the sea—frankincense",
                "scented winds guiding dhows to",
                "distant shores."
            ),
            new BookPageInfo
            (
                "The mighty city of Sohar",
                "became the heart of Arabian",
                "maritime trade, its harbors",
                "echoing with the songs of",
                "merchants and sailors. Gold,",
                "silks, and spices passed through",
                "her bustling ports."
            ),
            new BookPageInfo
            (
                "Invaders came: Persians,",
                "Portuguese, Ottomans. Yet the",
                "tribes endured, united at last",
                "under the banner of Al Bu Said.",
                "The forts of Nizwa, Bahla, and",
                "Jalali guarded their sovereignty."
            ),
            new BookPageInfo
            (
                "In the age of Sultans, Oman’s",
                "reach spanned from Zanzibar’s",
                "spice islands to the sands of",
                "Balochistan. The world knew the",
                "Omani dhow—swift as a falcon,",
                "bearing treasures, carrying tales."
            ),
            new BookPageInfo
            (
                "As empires waned, the nation",
                "renewed its soul: taming",
                "desert, reclaiming sea, reviving",
                "the fragrance of frankincense,",
                "and sharing it anew. Oman endures,",
                "her spirit as unyielding as",
                "the mountain and the wave."
            ),
            new BookPageInfo
            (
                "Let this chest hold echoes",
                "of Oman’s past. To those who",
                "open it: may you carry forth",
                "the wisdom of the Sultanate,",
                "and the courage of her seafarers.",
                "",
                "—The Court Scribe"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfOman() : base(false)
        {
            Hue = 2415; // Gold-sand
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Sultanate: The History of Oman");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Sultanate: The History of Oman");
        }

        public ChroniclesOfOman(Serial serial) : base(serial) { }

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
