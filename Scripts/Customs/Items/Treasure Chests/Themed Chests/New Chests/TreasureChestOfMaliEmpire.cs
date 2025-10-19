using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMaliEmpire : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMaliEmpire()
        {
            Name = "Treasure Chest of the Mali Empire";
            Hue = 1281; // Gold-like hue for wealth

            // Add items to the chest
            AddItem(CreateDecorativeItem<GoldBricks>("Golden Ingot of Mansa Musa", 1281), 0.20);
            AddItem(CreateDecorativeItem<Basket3WestArtifact>("Timbuktu Scholar's Basket", 2125), 0.18);
            AddItem(CreateDecorativeItem<Painting2WestArtifact>("Portrait of the Lion King Sundiata", 1175), 0.10);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Camel Caravan Statuette", 2411), 0.13);
            AddItem(CreateDecorativeItem<IncenseBurner>("Jenne’s Sacred Incense Burner", 1847), 0.15);
            AddItem(CreateDecorativeItem<AncientRunes>("Ancient Songhai Runes", 1150), 0.10);

            AddItem(CreateDecorativeItem<GrapeVine>("Desert Date Palm", 1269), 0.12);
            AddItem(CreateFoodItem<BreadLoaf>("Millet Loaf", 242), 0.12);
            AddItem(CreateFoodItem<Dates>("Dates from the Niger", 2676), 0.12);
            AddItem(CreateFoodItem<GreenTea>("Desert Mint Tea", 207), 0.10);

            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Sahel Queens"), 0.17);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Mali Nobility"), 0.15);

            AddItem(CreatePowerfulWeapon(), 0.22);
            AddItem(CreatePowerfulArmor(), 0.22);
            AddItem(CreatePowerfulClothing(), 0.22);

            AddItem(CreateMaliLoreBook(), 1.0);

            AddItem(new Gold(Utility.Random(2000, 8000)), 0.22);
            AddItem(CreateSpecialCoin(), 0.20);
            AddItem(CreateMap(), 0.07);
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

        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateSpecialCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Mali Dinar";
            gold.Hue = 2213; // Shimmering gold hue
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Timbuktu";
            map.Bounds = new Rectangle2D(5400, 1450, 400, 400);
            map.NewPin = new Point2D(5550, 1675);
            map.Protected = true;
            return map;
        }

        private Item CreatePowerfulWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Katana(), new QuarterStaff(), new Spear(), new Bardiche());

            weapon.Name = "Blade of Sundiata";
            weapon.Hue = 2125;
            weapon.MaxDamage = Utility.Random(40, 75);
            weapon.Attributes.BonusDex = 5;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.WeaponDamage = 35;
            weapon.WeaponAttributes.HitLightning = 18;
            weapon.WeaponAttributes.HitLeechHits = 12;
            weapon.WeaponAttributes.SelfRepair = 4;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreatePowerfulArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateLegs(), new PlateArms(), new PlateHelm(), new PlateGloves());
            armor.Name = "Armor of the Mali Lion";
            armor.Hue = 1281;
            armor.BaseArmorRating = Utility.Random(35, 72);
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStam = 15;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreatePowerfulClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Timbuktu Scholar";
            robe.Hue = 2125;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.LowerManaCost = 12;
            robe.Attributes.LowerRegCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.Inscribe, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMaliLoreBook()
        {
            return new ChroniclesOfMaliEmpire();
        }

        public TreasureChestOfMaliEmpire(Serial serial) : base(serial) { }

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

    public class ChroniclesOfMaliEmpire : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Mali Empire", "Griot Jali Musa",
            new BookPageInfo
            (
                "From the red dunes of the Sahara",
                "to the green banks of the Niger,",
                "arose the empire of Mali. Its kings",
                "were lions, its land was gold,",
                "its word—legend.",
                "",
                "I sing of Sundiata, the Lion King,",
                "who forged unity from tribal sands."
            ),
            new BookPageInfo
            (
                "Mansa Musa, Lord of Wealth, rode",
                "to Mecca bearing rivers of gold.",
                "The world marveled at his caravan,",
                "countless camels, each draped in",
                "silk and gold. Mali's fame spread",
                "from Cairo to Cordoba, from desert",
                "to distant seas."
            ),
            new BookPageInfo
            (
                "Timbuktu, jewel of learning, where",
                "scribes bent over ancient texts.",
                "Mosques rose as towers of faith.",
                "Caravans brought salt, cloth, stories.",
                "Scholars taught wisdom to all.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Yet riches bred envy, and envy",
                "breeds war. Songhai's shadow",
                "grew as Mali's power waned.",
                "But still, our music echoes in",
                "the river’s song. Our gold gleams",
                "in memory. The empire fell, but",
                "our stories endure."
            ),
            new BookPageInfo
            (
                "Heed these words, wanderer:",
                "Gold may fill a chest, but wisdom",
                "fills the soul. Seek not only",
                "treasure, but the tale behind it.",
                "",
                "May the Lion’s courage be yours.",
                "",
                "- Jali Musa"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfMaliEmpire() : base(false)
        {
            Hue = 2125; // Rich purple
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Mali Empire");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Mali Empire");
        }

        public ChroniclesOfMaliEmpire(Serial serial) : base(serial) { }

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
