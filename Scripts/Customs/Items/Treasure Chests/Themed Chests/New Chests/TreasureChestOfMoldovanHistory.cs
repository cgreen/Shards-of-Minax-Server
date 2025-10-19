using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMoldovanHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMoldovanHistory()
        {
            Name = "Treasure Chest of Moldovan History";
            Hue = 1172; // Rich royal blue

            // Decorative & Lore Items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ancient Moldovan Vase", 1175), 0.15);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Sculpture of Ștefan cel Mare", 1359), 0.10);
            AddItem(CreateDecorativeItem<Painting1NorthArtifact>("Painting of Soroca Fortress", 1109), 0.12);
            AddItem(CreateDecorativeItem<WineRack>("Vintage Moldovan Wine Rack", 2117), 0.14);
            AddItem(new ChronicleOfMoldova(), 1.0);

            // Unique Equipment
            AddItem(CreateCloak(), 0.25);
            AddItem(CreateLeatherCap(), 0.18);
            AddItem(CreateBoots(), 0.17);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateShield(), 0.16);
            AddItem(CreateArmor(), 0.21);

            // Consumables & Currency
            AddItem(CreateFood("Mămăligă", 1172), 0.15);
            AddItem(CreateFood("Plăcintă cu Brânză", 2217), 0.11);
            AddItem(CreateWine(), 0.14);
            AddItem(CreateGoldItem("Ducat of Moldavia"), 0.16);
            AddItem(new Gold(Utility.Random(500, 3000)), 0.19);

            // Special Relics
            AddItem(CreateDecorativeItem<AncientWeapon1>("Sword Relic of Bessarabia", 1150), 0.11);
            AddItem(CreateDecorativeItem<GrapeVine>("Noble Grape Vine", 1496), 0.10);
            AddItem(CreateMap(), 0.06);
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

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(200, 900);
            return gold;
        }

        private Item CreateFood(string name, int hue)
        {
            Cookies food = new Cookies(); // Just as a placeholder item, can swap for custom food
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateWine()
        {
            BottleOfWine wine = new BottleOfWine();
            wine.Name = "Vintage Purcari Red";
            wine.Hue = 1153;
            return wine;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Dniester";
            cloak.Hue = 1366;
            cloak.Attributes.Luck = 35;
            cloak.Attributes.BonusHits = 10;
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.SpellDamage = 7;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateLeatherCap()
        {
            LeatherCap cap = new LeatherCap();
            cap.Name = "Cap of Moldovan Shepherds";
            cap.Hue = 1172;
            cap.BaseArmorRating = Utility.Random(20, 45);
            cap.Attributes.BonusDex = 18;
            cap.Attributes.NightSight = 1;
            cap.SkillBonuses.SetValues(0, SkillName.Herding, 20.0);
            cap.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            cap.EnergyBonus = 12;
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Steppe Wanderer's Boots";
            boots.Hue = 1878;
            boots.Attributes.LowerManaCost = 10;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.Luck = 15;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateWeapon()
        {
            Longsword sword = new Longsword();
            sword.Name = "Blade of Ștefan cel Mare";
            sword.Hue = 1365;
            sword.MinDamage = 25;
            sword.MaxDamage = 60;
            sword.Attributes.BonusHits = 25;
            sword.Attributes.BonusStr = 15;
            sword.Attributes.WeaponSpeed = 20;
            sword.WeaponAttributes.HitLeechHits = 10;
            sword.WeaponAttributes.HitLeechMana = 10;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            sword.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Prut Defender Shield";
            shield.Hue = 1364;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusHits = 10;
            shield.Attributes.ReflectPhysical = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of Moldovan Nobility";
            armor.Hue = 1367;
            armor.BaseArmorRating = Utility.Random(38, 60);
            armor.Attributes.BonusStr = 10;
            armor.Attributes.CastRecovery = 3;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Orheiul Vechi Monastery";
            map.Bounds = new Rectangle2D(2300, 2150, 300, 300);
            map.NewPin = new Point2D(2435, 2237);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfMoldovanHistory(Serial serial) : base(serial) { }

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

    public class ChronicleOfMoldova : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Moldova", "Historian Ion Drăgușan",
            new BookPageInfo
            (
                "Land of rolling hills,",
                "rivers and vineyards,",
                "Moldova’s story winds",
                "through centuries of",
                "war, culture, and",
                "resilience. From the",
                "first Voivodes to",
                "the modern republic."
            ),
            new BookPageInfo
            (
                "Founded in the 14th",
                "century, Moldova rose",
                "under rulers like Dragoș,",
                "Bogdan I, and Ștefan",
                "cel Mare. The fortresses",
                "of Soroca, Suceava, and",
                "Orhei protected its heart.",
                ""
            ),
            new BookPageInfo
            (
                "Invaders came and went:",
                "Ottoman Turks, Polish,",
                "Hungarian and Russian",
                "armies. Yet Moldova",
                "remained, its fields",
                "lush, its people proud,",
                "its language and song",
                "undiminished."
            ),
            new BookPageInfo
            (
                "The grape harvest—",
                "crucial to Moldovan",
                "identity—yields wines",
                "famed from Purcari to",
                "Milestii Mici. Ancient",
                "traditions mingle with",
                "Roman, Slav, and Turkic",
                "roots."
            ),
            new BookPageInfo
            (
                "In the 20th century,",
                "the land saw new",
                "borders and upheaval.",
                "Moldova’s voice survived",
                "partition, war, Soviet",
                "rule, and rebirth.",
                ""
            ),
            new BookPageInfo
            (
                "Today, Moldova",
                "celebrates its heritage,",
                "from Hora folk dances",
                "to medieval monasteries,",
                "from resilient villages",
                "to vibrant Chisinau,",
                "and dreams of unity",
                "and peace."
            ),
            new BookPageInfo
            (
                "Let this chest preserve",
                "Moldova’s memory—a",
                "testament to those who",
                "endured, created, and",
                "loved this beautiful land.",
                "",
                "- Ion Drăgușan",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfMoldova() : base(false)
        {
            Hue = 1172; // Rich blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Moldova");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Moldova");
        }

        public ChronicleOfMoldova(Serial serial) : base(serial) { }

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
