using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheKhmerEmpire : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheKhmerEmpire()
        {
            Name = "Treasure Chest of the Khmer Empire";
            Hue = 2213; // Deep gold, evoking Angkor

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Angkorian Lotus Urn", 2053), 0.17);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Carved Vishnu Statue", 2413), 0.16);
            AddItem(CreateDecorativeItem<Painting3Artifact>("Bas-Relief of Bayon", 1207), 0.18);
            AddItem(CreateNamedItem<GreaterHealPotion>("Naga's Sacred Water", 2066), 0.22);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Suryavarman", 1367), 0.24);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateDecorativeItem<IncenseBurner>("Temple Incense Burner", 2118), 0.20);
            AddItem(CreateDecorativeItem<AncientDrum>("Royal Court Drum", 2106), 0.12);
            AddItem(CreateDecorativeItem<WhiteTigerFigurine>("White Tiger of the Jungle", 1150), 0.13);
            AddItem(CreateNamedItem<Sandals>("Sandals of the River Kingdom", 1167), 0.19);
            AddItem(CreateDecorativeItem<BowlArtifact>("Offering Bowl of Apsaras", 1171), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Mekong", 1271), 0.14);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateLoreBook(), 1.0); // Always add the book!
            AddItem(CreateSimpleNote(), 0.08);
            AddItem(new Gold(Utility.Random(1000, 7000)), 0.18);
            AddItem(CreateConsumableItem<SushiPlatter>("Imperial Fish Platter", 268), 0.09);
            AddItem(CreateConsumableItem<GreenTea>("Jade Lotus Tea", 2109), 0.11);
            AddItem(CreateClothing(), 0.15);
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

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0) item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0) item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            // Unique, powerful Khmer-themed weapon
            Katana khopesh = new Katana();
            khopesh.Name = "Blade of Jayavarman";
            khopesh.Hue = 2101;
            khopesh.MaxDamage = Utility.Random(55, 80);
            khopesh.MinDamage = Utility.Random(35, 54);
            khopesh.WeaponAttributes.HitLeechHits = 20;
            khopesh.WeaponAttributes.HitLeechMana = 10;
            khopesh.WeaponAttributes.HitLightning = 25;
            khopesh.WeaponAttributes.SelfRepair = 6;
            khopesh.WeaponAttributes.HitLowerAttack = 20;
            khopesh.Attributes.WeaponSpeed = 25;
            khopesh.Attributes.WeaponDamage = 35;
            khopesh.Attributes.BonusStr = 10;
            khopesh.Attributes.BonusHits = 15;
            khopesh.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            khopesh.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(khopesh, new XmlLevelItem());
            return khopesh;
        }

        private Item CreateArmor()
        {
            // Unique chest armor, themed for Khmer kings
            PlateChest chest = new PlateChest();
            chest.Name = "Ornate Breastplate of Angkor";
            chest.Hue = 2213;
            chest.BaseArmorRating = Utility.Random(50, 80);
            chest.Attributes.BonusHits = 20;
            chest.Attributes.LowerManaCost = 8;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.Luck = 50;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            chest.ArmorAttributes.LowerStatReq = 30;
            chest.AbsorptionAttributes.EaterFire = 15;
            chest.ColdBonus = 5;
            chest.EnergyBonus = 10;
            chest.FireBonus = 15;
            chest.PhysicalBonus = 15;
            chest.PoisonBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // Unique robe, for flavor and utility
            Robe robe = new Robe();
            robe.Name = "Silken Robe of Apsara";
            robe.Hue = 1173;
            robe.Attributes.Luck = 35;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.BonusInt = 6;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSimpleNote()
        {
            SimpleNote note = new SimpleNote();
            note.NoteString = "O traveler, within this chest you find the legacy of a thousand years: the splendor of Angkor, the echoes of Khmer kings, and the sacred waters of the Mekong. May you honor what was lost and guard what you have found.";
            note.TitleString = "Legacy of Cambodia";
            return note;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Angkor Wat";
            map.Bounds = new Rectangle2D(4300, 800, 300, 300); // Example coords, adjust to your shard!
            map.NewPin = new Point2D(4450, 950);
            map.Protected = true;
            return map;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheKhmerKings();
        }

        public TreasureChestOfTheKhmerEmpire(Serial serial) : base(serial)
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

    // Lore Book: Chronicles of the Khmer Kings
    public class ChroniclesOfTheKhmerKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Khmer Kings", "Scribe of Angkor",
            new BookPageInfo
            (
                "In the year of the sacred Naga,",
                "the great Jayavarman II",
                "proclaimed himself",
                "Chakravartin — Universal King.",
                "Upon the summit of Phnom Kulen,",
                "the empire was born.",
                "From jungle to sea,",
                "his word was law."
            ),
            new BookPageInfo
            (
                "Temples rose from the",
                "earth as lotus blossoms:",
                "Angkor Wat, vast as",
                "the heavens; Bayon,",
                "smiling with stone faces.",
                "The waters of Tonlé Sap",
                "nourished the land, and",
                "the gods watched."
            ),
            new BookPageInfo
            (
                "In the courts of kings,",
                "Apsaras danced, their",
                "fingers weaving blessings.",
                "The white tiger stalked",
                "the jungle’s edge.",
                "The artisans carved legends",
                "in sandstone, never to fade.",
                ""
            ),
            new BookPageInfo
            (
                "Yet empires rise and fall.",
                "The thundering war-elephant,",
                "the march of the Chams,",
                "the shadow of new faiths,",
                "and the ceaseless",
                "embrace of the jungle.",
                "Time humbles all,",
                "but memory endures."
            ),
            new BookPageInfo
            (
                "The Mekong flows as it",
                "always has. The faces of",
                "the kings fade, but their",
                "glory sleeps in stone.",
                "O seeker, hold these tales,",
                "and let the spirits guide you,",
                "from ancient Angkor to",
                "the world beyond."
            ),
            new BookPageInfo
            (
                "Let the lotus rise anew.",
                "Let the naga guard this land.",
                "The empire may crumble,",
                "but the heart of Cambodia",
                "beats eternal.",
                "",
                "- Scribe of Angkor",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheKhmerKings() : base(false)
        {
            Hue = 2213; // Deep gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Khmer Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Khmer Kings");
        }

        public ChroniclesOfTheKhmerKings(Serial serial) : base(serial) { }

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
