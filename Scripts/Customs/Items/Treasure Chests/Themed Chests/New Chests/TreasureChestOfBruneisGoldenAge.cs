using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBruneisGoldenAge : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBruneisGoldenAge()
        {
            Name = "Treasure Chest of Brunei's Golden Age";
            Hue = 1266; // Royal gold-green hue

            // Add items to the chest
            AddItem(CreateDecorativeItem<GoldBricks>("Royal Ingots of Brunei", 1270), 0.20);
            AddItem(CreateDecorativeItem<KingsGildedStatue>("Statue of Sultan Bolkiah", 1425), 0.13);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vase of Bandar Seri Begawan", 1160), 0.18);
            AddItem(CreateDecorativeItem<GoldWire>("Intricate Gold Wirework", 2213), 0.14);
            AddItem(CreateDecorativeItem<IncenseBurner>("Sultanate Incense Burner", 1445), 0.16);
            AddItem(CreateNamedItem<GreaterHealPotion>("Sacred Oil of Kampong Ayer"), 0.12);
            AddItem(CreateUniqueWeapon(), 0.18);
            AddItem(CreateUniqueArmor(), 0.17);
            AddItem(CreateRoyalCloak(), 0.18);
            AddItem(CreateRoyalSandals(), 0.17);
            AddItem(CreateRoyalSash(), 0.14);
            AddItem(CreateUniqueDagger(), 0.13);
            AddItem(new ChroniclesOfBrunei(), 1.0);
            AddItem(CreateDecorativeItem<SacredLavaRock>("Mystic Stone of Mount Kinabalu", 1367), 0.10);
            AddItem(CreateDecorativeItem<GoldEarrings>("Golden Ear Ornaments", 2213), 0.10);
            AddItem(new BookOfBruneianPoetry(), 0.12);
            AddItem(new Gold(Utility.Random(3000, 8000)), 0.16);
            AddItem(CreateUniqueMap(), 0.06);
            AddItem(CreateDecorativeItem<OrderShield>("Shield of Royal Guard", 1270), 0.15);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Statuette of the White Crane", 1150), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateRoyalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Sultan";
            cloak.Hue = 1266; // Royal gold-green
            cloak.Attributes.Luck = 70;
            cloak.Attributes.BonusHits = 20;
            cloak.Attributes.BonusMana = 15;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateRoyalSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Golden Palace";
            sandals.Hue = 1270;
            sandals.Attributes.BonusDex = 15;
            sandals.Attributes.LowerManaCost = 8;
            sandals.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateRoyalSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of Bruneian Nobility";
            sash.Hue = 1445;
            sash.Attributes.Luck = 35;
            sash.Attributes.BonusStam = 12;
            sash.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateUniqueWeapon()
        {
            Katana kris = new Katana();
            kris.Name = "Kris of the Golden Age";
            kris.Hue = 1270;
            kris.MinDamage = 40;
            kris.MaxDamage = 75;
            kris.WeaponAttributes.HitLightning = 25;
            kris.WeaponAttributes.SelfRepair = 7;
            kris.WeaponAttributes.HitLeechHits = 12;
            kris.WeaponAttributes.HitMagicArrow = 10;
            kris.Attributes.AttackChance = 10;
            kris.Attributes.BonusHits = 20;
            kris.Attributes.Luck = 50;
            kris.Slayer = SlayerName.ElementalBan;
            kris.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(kris, new XmlLevelItem());
            return kris;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of Sultan Bolkiah";
            chest.Hue = 1266;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.BonusStr = 15;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueDagger()
        {
            Dagger keris = new Dagger();
            keris.Name = "Royal Keris of Brunei";
            keris.Hue = 1153;
            keris.MinDamage = 30;
            keris.MaxDamage = 60;
            keris.WeaponAttributes.HitHarm = 18;
            keris.WeaponAttributes.SelfRepair = 5;
            keris.WeaponAttributes.UseBestSkill = 1;
            keris.Slayer = SlayerName.Repond;
            keris.Attributes.BonusDex = 15;
            keris.Attributes.SpellChanneling = 1;
            keris.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            XmlAttach.AttachTo(keris, new XmlLevelItem());
            return keris;
        }


        private Item CreateUniqueMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Chart of the Brunei Empire";
            map.Bounds = new Rectangle2D(2200, 2800, 400, 400);
            map.NewPin = new Point2D(2350, 2950);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfBruneisGoldenAge(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBrunei : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Brunei", "Royal Scribe of the Sultan",
            new BookPageInfo
            (
                "In ancient times, Borneo's",
                "coasts teemed with traders.",
                "Brunei, jewel of the north,",
                "grew from humble fishing",
                "villages to a sultanate rich",
                "in gold, pepper, and silk."
            ),
            new BookPageInfo
            (
                "Under Sultan Bolkiah, the",
                "fifth ruler, the empire",
                "reached its zenith. Armadas",
                "sailed from Manila to Borneo,",
                "and all islands paid tribute.",
                "Royal domes gleamed above",
                "Bandar Seri Begawan."
            ),
            new BookPageInfo
            (
                "Legends say the Sultan's",
                "kris never dulled, and his",
                "palace shone with emerald",
                "tiles. The water village",
                "thrived, wooden houses",
                "floating in golden light."
            ),
            new BookPageInfo
            (
                "Islam arrived with learned",
                "men from the west, bringing",
                "script and mosque. Scholars",
                "wrote tales of Brunei’s gold,",
                "its peace, and its mighty",
                "navy guarding the seas."
            ),
            new BookPageInfo
            (
                "As centuries passed, pirates",
                "prowled, rival sultanates rose,",
                "and distant empires cast long",
                "shadows. But Brunei’s spirit",
                "remained: a kingdom of rivers,",
                "rainforest, and faith."
            ),
            new BookPageInfo
            (
                "This chest holds relics",
                "from those golden days.",
                "May its finder honor the",
                "sultans, respect the spirits,",
                "and remember Brunei's",
                "enduring grace."
            ),
            new BookPageInfo
            (
                "",
                "- Royal Scribe, Bandar Seri Begawan",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );


        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBrunei() : base(false)
        {
            Hue = 1266; // Royal gold-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Brunei");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Brunei");
        }

        public ChroniclesOfBrunei(Serial serial) : base(serial) { }

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
	
	
    public class BookOfBruneianPoetry : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Book of Bruneian Poetry", "Royal Poet",
            new BookPageInfo
            (
                "Verses of the Water Village",
                "Sails upon the Brunei River,",
                "Golden domes beneath the sky,",
                "Sultans crowned with ancient power."

            ),
            new BookPageInfo
            (
                "Spices drift from bustling harbors,",
                "Silver fishes leap and gleam.",
                "Bolkiah's legacy remembered,",
                "Brunei Darussalam's dream."
            )

        );


        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfBruneianPoetry() : base(false)
        {
            Hue = 1266; // Royal gold-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Book Of Bruneian Poetry");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Book Of Bruneian Poetry");
        }

        public BookOfBruneianPoetry(Serial serial) : base(serial) { }

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