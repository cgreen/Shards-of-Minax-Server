using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSiam : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSiam()
        {
            Name = "Treasure Chest of Siam";
            Hue = 2125; // Rich golden hue for a royal look

            // Add items to the chest
            AddItem(new RandomFancyStatue(), 0.12);
            AddItem(CreateColoredItem<IncenseBurner>("Sacred Temple Incense Burner", 2411), 0.10);
            AddItem(CreateColoredItem<Robe>("Royal Siamese Silk Robe", 1166), 0.18);
            AddItem(CreateElephantFigurine(), 0.15);
            AddItem(CreateSpiceBox(), 0.16);
            AddItem(CreateColoredItem<GoldBracelet>("Bracelet of the White Elephant", 1178), 0.20);
            AddItem(CreateNagaBlade(), 0.19);
            AddItem(CreateGildedArmor(), 0.18);
            AddItem(CreatePhraMaeKhongkhaCloak(), 0.16);
            AddItem(CreateThaiFruitBasket(), 0.14);
            AddItem(CreateGarudaFeatherAmulet(), 0.13);
            AddItem(CreateColoredItem<RandomFancyPlant>("Lotus of Enlightenment", 1153), 0.15);
            AddItem(CreateMap(), 0.04);
            AddItem(new ChroniclesOfTheKingsOfSiam(), 1.0);
            AddItem(new Gold(Utility.Random(1, 6000)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative: Golden Buddha Statue
        private Item GoldenBuddhaStatue()
        {
            StatueSouth statue = new StatueSouth();
            statue.Name = "Golden Buddha Statue";
            statue.Hue = 2125;
            return statue;
        }

        // Decorative: Elephant Figurine
        private Item CreateElephantFigurine()
        {
            PolarBearZooStatuette elephant = new PolarBearZooStatuette();
            elephant.Name = "Sculpted Elephant of Ayutthaya";
            elephant.Hue = 1109;
            return elephant;
        }

        // Decorative: Box of Rare Siamese Spices
        private Item CreateSpiceBox()
        {
            Basket1Artifact spiceBox = new Basket1Artifact();
            spiceBox.Name = "Box of Ancient Siamese Spices";
            spiceBox.Hue = 0x486; // Subtle brown
            return spiceBox;
        }

        // Decorative: Thai Fruit Basket
        private Item CreateThaiFruitBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Tropical Thai Fruit";
            basket.Hue = 0;
            return basket;
        }

        // Consumable: Lotus Flower
        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Decorative: Garuda Feather Amulet
        private Item CreateGarudaFeatherAmulet()
        {
            GoldEarrings amulet = new GoldEarrings();
            amulet.Name = "Garuda Feather Amulet";
            amulet.Hue = 2418;
            amulet.Attributes.Luck = 20;
            amulet.Attributes.BonusHits = 10;
            amulet.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            return amulet;
        }

        // Equipment: Royal Silk Robe
        private Item CreateColoredItem<T>(string name, int hue, bool silk = false) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            if (silk && item is Robe robe)
            {
                robe.Attributes.Luck = 30;
                robe.Attributes.RegenMana = 2;
                robe.Attributes.SpellDamage = 8;
            }
            return item;
        }
        private Item SilkRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Siamese Silk Robe";
            robe.Hue = 1166;
            robe.Attributes.Luck = 30;
            robe.Attributes.RegenMana = 2;
            robe.Attributes.SpellDamage = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Focus, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Equipment: Naga Blade
        private Item CreateNagaBlade()
        {
            Katana nagaBlade = new Katana();
            nagaBlade.Name = "Blade of the Naga King";
            nagaBlade.Hue = 1266;
            nagaBlade.MinDamage = 45;
            nagaBlade.MaxDamage = 78;
            nagaBlade.Attributes.BonusStam = 12;
            nagaBlade.WeaponAttributes.HitPoisonArea = 25;
            nagaBlade.WeaponAttributes.HitHarm = 18;
            nagaBlade.WeaponAttributes.SelfRepair = 7;
            nagaBlade.SkillBonuses.SetValues(0, SkillName.Poisoning, 10.0);
            nagaBlade.SkillBonuses.SetValues(1, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(nagaBlade, new XmlLevelItem());
            return nagaBlade;
        }

        // Equipment: Gilded Armor of Sukhothai
        private Item CreateGildedArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Gilded Armor of Sukhothai";
            armor.Hue = 2125;
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusStr = 8;
            armor.Attributes.BonusHits = 25;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.ColdBonus = 10;
            armor.FireBonus = 15;
            armor.EnergyBonus = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Equipment: Cloak of Phra Mae Khongkha (Water Goddess)
        private Item CreatePhraMaeKhongkhaCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Phra Mae Khongkha";
            cloak.Hue = 1267; // Aqua-blue
            cloak.Attributes.RegenStam = 3;
            cloak.Attributes.BonusDex = 8;
            cloak.Attributes.BonusMana = 8;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Book of Lore: Chronicles of the Kings of Siam
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Royal Palace of Ayutthaya";
            map.Bounds = new Rectangle2D(1800, 1600, 300, 300);
            map.NewPin = new Point2D(1922, 1752);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSiam(Serial serial) : base(serial) { }

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

    // ---- Book of Lore ----

    public class ChroniclesOfTheKingsOfSiam : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Kings of Siam", "Somdej Phra Maha Chakri",
            new BookPageInfo
            (
                "In the days when rivers",
                "were the lifeblood of",
                "kingdoms, the Land of",
                "Siam rose beneath the",
                "monsoon sky. From the",
                "fertile banks of the Chao",
                "Phraya, kings built",
                "palaces of gold."
            ),
            new BookPageInfo
            (
                "The Sukhothai dawned",
                "first, where wise",
                "Ramkhamhaeng ruled and",
                "the script of Siam was",
                "born. Temples shone in",
                "the sun, monks carried",
                "teachings, and all paid",
                "homage to the Buddha."
            ),
            new BookPageInfo
            (
                "In Ayutthaya’s glory,",
                "white elephants walked",
                "the palace courts. Kings",
                "held the chakri, the",
                "royal discus, and Siam’s",
                "merchants sailed to all",
                "corners of the world.",
                "Legends grew, and so did"
            ),
            new BookPageInfo
            (
                "rival empires. The naga",
                "guarded river gates. The",
                "Garuda soared above.",
                "Enemies came: warriors of",
                "Burma, Portugal, and",
                "distant lands, but the",
                "spirit of Siam endured."
            ),
            new BookPageInfo
            (
                "In the city of angels,",
                "Bangkok, the Grand",
                "Palace rose like a lotus.",
                "Kings, from Taksin to",
                "Rama, guided their people",
                "with wisdom and strength.",
                "The land endured change,",
                "from rice fields to steel."
            ),
            new BookPageInfo
            (
                "Siam is a land of",
                "miracles, where monks",
                "walk morning roads, where",
                "the naga slumbers in the",
                "Mekong, and where golden",
                "pagodas touch the sky.",
                "May these chronicles",
                "bring honor to the past."
            ),
            new BookPageInfo
            (
                "Heed the teachings of",
                "compassion. Respect the",
                "ancestors, the king, and",
                "the monks who bless the",
                "land. Let the treasures of",
                "Siam inspire the wise, the",
                "brave, and the kind.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Fortune smiles upon those",
                "who seek wisdom, not gold.",
                "This chest is my gift—",
                "for those who honor the",
                "Land of the Free.",
                "",
                "- Somdej Phra Maha Chakri",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheKingsOfSiam() : base(false)
        {
            Hue = 2125; // Gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Kings of Siam");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Kings of Siam");
        }

        public ChroniclesOfTheKingsOfSiam(Serial serial) : base(serial) { }

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
