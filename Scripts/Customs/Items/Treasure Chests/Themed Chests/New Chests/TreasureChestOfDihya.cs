using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfDihya : WoodenChest
    {
        [Constructable]
        public TreasureChestOfDihya()
        {
            Name = "Treasure Chest of the Dihya, Queen of the Berbers";
            Hue = 2075; // Sandstone/golden desert hue

            // Add items to the chest
            AddItem(new ChroniclesOfDihya(), 1.0);
            AddItem(CreateBerberAmulet(), 0.35);
            AddItem(CreateColoredItem<SackOfSugar>("Tuareg Date Sugar", 1150), 0.14);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Carthage"), 0.19);
            AddItem(CreateNamedItem<BodySash>("Sash of the Sahara Wanderer"), 0.18);
            AddItem(CreateSandRose(), 0.22);
            AddItem(CreateColoredItem<GreaterHealPotion>("Elixir of the Oasis", 1407), 0.18);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Scrolls of Timgad"), 0.14);
            AddItem(CreateDesertWeapon(), 0.18);
            AddItem(CreateDesertArmor(), 0.18);
            AddItem(CreateNamedItem<Sandals>("Sandals of Tassili Nomad"), 0.18);
            AddItem(CreateAlgerianDelicacy(), 0.17);
            AddItem(CreateAncientDagger(), 0.19);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateColoredItem<IncenseBurner>("Desert Incense Burner", 2418), 0.14);
            AddItem(CreateNamedItem<GoldEarrings>("Queen Dihya’s Earrings"), 0.17);
            AddItem(CreateColoredItem<Ruby>("Ruby of the Aurès Mountains", 1855), 0.11);
            AddItem(CreateRomanMosaic(), 0.13);
            AddItem(CreateGoldItem("Algerian Dinar Coin"), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateBerberAmulet()
        {
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Berber Amulet of Dihya";
            amulet.Hue = 1153; // Jade-like
            amulet.Attributes.Luck = 50;
            amulet.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            amulet.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
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

        private Item CreateSandRose()
        {
            RoseInAVase rose = new RoseInAVase();
            rose.Name = "Desert Sand Rose";
            rose.Hue = 2101; // Sandy
            return rose;
        }

        private Item CreateRomanMosaic()
        {
            Painting1WestArtifact mosaic = new Painting1WestArtifact();
            mosaic.Name = "Roman Mosaic of Timgad";
            mosaic.Hue = 1170;
            return mosaic;
        }

        private Item CreateAlgerianDelicacy()
        {
            Cake cake = new Cake();
            cake.Name = "Makroud (Date Pastry)";
            cake.Hue = 2105;
            return cake;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Numidia";
            map.Bounds = new Rectangle2D(5100, 1350, 400, 400); // Fictional Algeria coords
            map.NewPin = new Point2D(5300, 1550);
            map.Protected = true;
            return map;
        }

        private Item CreateDesertWeapon()
        {
            // Scimitar is the perfect desert weapon!
            Scimitar weapon = new Scimitar();
            weapon.Name = "Scimitar of the Aurès";
            weapon.Hue = 2418; // Bright copper/gold
            weapon.MinDamage = Utility.Random(24, 40);
            weapon.MaxDamage = Utility.Random(40, 70);
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.WeaponAttributes.SelfRepair = 4;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.BonusDex = 8;
            weapon.Attributes.Luck = 40;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            weapon.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateDesertArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Mail of the Desert Warrior";
            armor.Hue = 2213; // Sun-bleached bronze
            armor.BaseArmorRating = Utility.Random(40, 65);
            armor.Attributes.BonusStam = 10;
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.PhysicalBonus = 25;
            armor.FireBonus = 20;
            armor.ColdBonus = 8;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 14.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateAncientDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Numidian Raider";
            dagger.Hue = 2107; // Ancient iron
            dagger.MinDamage = Utility.Random(15, 34);
            dagger.MaxDamage = Utility.Random(33, 60);
            dagger.Attributes.BonusDex = 10;
            dagger.Attributes.AttackChance = 7;
            dagger.WeaponAttributes.HitPoisonArea = 8;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.Slayer = SlayerName.Repond;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 18.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfDihya(Serial serial) : base(serial)
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

    public class ChroniclesOfDihya : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Dihya", "Told by the Fire of Aurès",
            new BookPageInfo
            (
                "In the shadow of the Aurès",
                "mountains, the wind speaks",
                "of Dihya — called Kahina,",
                "seer and queen, fire of",
                "Numidia. She was Berber,",
                "Amazigh, free as the sands.",
                "Her eyes mirrored the",
                "desert sun."
            ),
            new BookPageInfo
            (
                "From Roman roads to",
                "Carthaginian ruins, her",
                "people thrived. When the",
                "crescent banners came from",
                "the east, Dihya rose as",
                "shield and sword, rallying",
                "the tribes, vowing: the",
                "desert would never kneel."
            ),
            new BookPageInfo
            (
                "With swift horses and",
                "keen blades, she harried",
                "the invaders, knowing every",
                "stone and dune. Her name",
                "became legend — to some, a",
                "sorceress; to her people,",
                "mother of freedom."
            ),
            new BookPageInfo
            (
                "Betrayal came, as it",
                "always does, by blood and",
                "coin. Yet Dihya fought to",
                "her last, her fire undimmed.",
                "The Aurès mountains echoed",
                "her cry: 'We are the people",
                "of the wind, the mountain,",
                "the endless sky.'"
            ),
            new BookPageInfo
            (
                "In the centuries since,",
                "cities rose and fell: Timgad,",
                "Algiers, Oran. Pirates, poets,",
                "and conquerors all left their",
                "marks. But the heart of",
                "Algeria — fierce, free,",
                "undaunted — is Dihya’s gift."
            ),
            new BookPageInfo
            (
                "Let this chest be a memory,",
                "not of gold, but of courage.",
                "May you, traveler, carry her",
                "fire wherever you roam. For",
                "the sands still whisper her",
                "name, and her people are not",
                "forgotten.",
                ""
            ),
            new BookPageInfo
            (
                "Queen Dihya, the Kahina,",
                "lives on in every desert wind,",
                "in every song of freedom.",
                "",
                "- The Chronicles of Dihya",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfDihya() : base(false)
        {
            Hue = 2105; // Desert parchment
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Dihya");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Dihya");
        }

        public ChroniclesOfDihya(Serial serial) : base(serial) { }

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
