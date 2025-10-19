using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfThePearlOfTheOrient : WoodenChest
    {
        [Constructable]
        public TreasureChestOfThePearlOfTheOrient()
        {
            Name = "Treasure Chest of the Pearl of the Orient";
            Hue = 2607; // Deep pearl-blue

            // Decorative and artifact items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Manunggul Burial Jar", 2100), 0.17);
            AddItem(CreateDecorativeItem<GoldBricks>("Spanish Galleon Gold", 2213), 0.15);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Sultan's Sarimanok Idol", 2001), 0.10);
            AddItem(CreateDecorativeItem<LibraryFriendLantern>("Lantern of Intramuros", 1161), 0.11);
            AddItem(CreateDecorativeItem<Painting3Artifact>("Portrait of José Rizal", 1930), 0.14);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Lapu-Lapu's Monument", 2055), 0.14);
            AddItem(CreateDecorativeItem<AncientWeapon1>("Bolo of the Katipunan", 2106), 0.13);

            // Themed consumables & food
            AddItem(CreateFood<GreenTea>("Barako Coffee Brew", 2413), 0.15);
            AddItem(CreateFood<Cake>("Bibingka of Celebration", 1171), 0.11);
            AddItem(CreateFood<Eggs>("Balut of Bravery", 1192), 0.13);
            AddItem(CreateFood<Banana>("Lakatan Banana", 52), 0.18);

            // Unique coins and currency
            AddItem(CreateGoldItem("Pre-Hispanic Piloncitos"), 0.22);
            AddItem(CreateDecorativeItem<DecoSilverIngot>("Galleon Silver Bar", 2106), 0.16);

            // Custom, powerful equipment
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateClothing(), 0.15);

            // Unique accessories
            AddItem(CreateDecorativeItem<GoldBracelet>("Bracelet of the Datu", 1281), 0.19);
            AddItem(CreateDecorativeItem<GoldEarrings>("Pearl Earring of Manila", 1152), 0.13);

            // Unique map
            AddItem(CreateMap(), 0.07);

            // Lore book
            AddItem(new ChroniclesOfThePearlOfTheOrient(), 1.0);

            // Random loot
            AddItem(new Gold(Utility.Random(1, 6000)), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateFood<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateWeapon()
        {
            // Unique, powerful bolo or kampilan with Filipino warrior flair
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Katana(), new Scimitar(), new Cutlass(), new Longsword());
            weapon.Name = "Kampilan of the Maharlika";
            weapon.Hue = 2075; // Pearly-obsidian
            weapon.MaxDamage = Utility.Random(45, 75);
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.AttackChance = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.SelfRepair = 8;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateLegs(), new PlateHelm(), new LeatherDo());
            armor.Name = "Armor of the Pintados";
            armor.Hue = 2101; // Worn bronze-gold
            armor.BaseArmorRating = Utility.Random(40, 65);
            armor.ArmorAttributes.LowerStatReq = 18;
            armor.Attributes.Luck = 40;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.BonusDex = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Barong Tagalog of Unity";
            robe.Hue = 1151; // Off-white/pineapple fiber
            robe.Attributes.LowerManaCost = 10;
            robe.Attributes.BonusInt = 7;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 8.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Yamashita's Gold";
            map.Bounds = new Rectangle2D(5480, 1578, 250, 180); // fictional coordinates
            map.NewPin = new Point2D(5555, 1675);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfThePearlOfTheOrient(Serial serial) : base(serial)
        {
        }

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

    public class ChroniclesOfThePearlOfTheOrient : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Pearl of the Orient", "Various Chroniclers",
            new BookPageInfo
            (
                "Islands kissed by sunrise,",
                "named for a king far away.",
                "From ancient barangays",
                "and gold-laden shores,",
                "spirits and ancestors watched.",
                "Rajahs and datus ruled,",
                "the balangay sailed seas,",
                "and the rice terraces rose."
            ),
            new BookPageInfo
            (
                "The world came: first traders,",
                "then the cross and sword.",
                "Magellan met Lapu-Lapu's spear.",
                "Centuries of friars and galleons,",
                "revolts in the jungles,",
                "Katipuneros whispering freedom",
                "in the shadow of the moon.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "A nation born in blood and ink:",
                "Rizal, Bonifacio, Mabini, Luna.",
                "The red sun rises over Manila,",
                "heroes fall, seeds of hope grow.",
                "Empires come and go—",
                "Spain, America, Japan—",
                "but the islands remember",
                "their first songs."
            ),
            new BookPageInfo
            (
                "Now the Pearl endures,",
                "divided but never broken,",
                "each wave a new beginning.",
                "The spirit of bayanihan,",
                "of pag-asa, of lakas.",
                "Within this chest are echoes",
                "of centuries, stories waiting",
                "for the next dreamer."
            ),
            new BookPageInfo
            (
                "Beware: not all treasures",
                "can be measured in gold.",
                "Here, history is alive.",
                "Honor it, and you may",
                "find more than you sought.",
                "Forget, and you lose the soul",
                "of the Pearl of the Orient.",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfThePearlOfTheOrient() : base(false)
        {
            Hue = 2101; // Old gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Pearl of the Orient");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Pearl of the Orient");
        }

        public ChroniclesOfThePearlOfTheOrient(Serial serial) : base(serial) { }

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
