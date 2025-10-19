using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTajikistan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTajikistan()
        {
            Name = "Treasure Chest of Tajikistan";
            Hue = 2662; // Rich lapis blue, reminiscent of Central Asian tiles

            // Add themed items with probabilities
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Sogdian Gold Lion", 1287), 0.18);
            AddItem(CreateDecorativeItem<IncenseBurner>("Zoroastrian Fire Urn", 1356), 0.22);
            AddItem(CreateDecorativeItem<ZenRock1Artifact>("Stone of the Pamirs", 2417), 0.20);
            AddItem(CreateDecorativeItem<FancyCopperSunflower>("Silk Road Caravan Medallion", 2125), 0.15);
            AddItem(CreateDecorativeItem<DecorativeBowWest>("Persian Archer’s Bow Display", 1258), 0.12);
            AddItem(CreateDecorativeItem<BambooChair>("Pamir Wool-Cushioned Seat", 2707), 0.16);
            AddItem(CreateNamedItem<SackOfSugar>("Fergana Valley Apricots"), 0.10);
            AddItem(CreateNamedItem<MountainHoney>("Pamir Mountain Honey"), 0.18);

            // Unique equipment
            AddItem(CreateWeapon(), 0.30);
            AddItem(CreateArmor(), 0.30);
            AddItem(CreateClothing(), 0.30);

            // Special magical consumables
            AddItem(CreatePotion("Snowmelt of Iskanderkul", 1234, 50, SkillName.Healing, 15.0), 0.10);

            // Gold coins themed as ancient Sogdian drachma
            AddItem(CreateGoldItem("Sogdian Drachma"), 0.20);

            // Lore book
            AddItem(new ChronicleOfTajikistan(), 1.0);

            // Map to the legendary city of Penjikent
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(1500, 5000));
            gold.Name = name;
            return gold;
        }

        private Item CreatePotion(string name, int hue, int value, SkillName skill, double skillBonus)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;

            return potion;
        }

        private Item CreateWeapon()
        {
            // Legendary scimitar of Rustam
            Scimitar sword = new Scimitar();
            sword.Name = "Scimitar of Rustam";
            sword.Hue = 1175; // Bright golden
            sword.WeaponAttributes.HitLeechHits = 30;
            sword.WeaponAttributes.HitLightning = 25;
            sword.Attributes.BonusStr = 15;
            sword.Attributes.BonusDex = 8;
            sword.Attributes.AttackChance = 18;
            sword.Attributes.WeaponDamage = 22;
            sword.Attributes.ReflectPhysical = 8;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // Silk-and-steel armor of the Sogdian Guard
            PlateChest chest = new PlateChest();
            chest.Name = "Sogdian Guard’s Silksteel Vest";
            chest.Hue = 2401; // Deep blue
            chest.BaseArmorRating = Utility.Random(40, 60);
            chest.ArmorAttributes.MageArmor = 1;
            chest.ArmorAttributes.SelfRepair = 4;
            chest.Attributes.BonusInt = 10;
            chest.Attributes.BonusMana = 8;
            chest.Attributes.LowerManaCost = 10;
            chest.Attributes.Luck = 45;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.MagicResist, 7.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // Poetic Robe of Rudaki
            Robe robe = new Robe();
            robe.Name = "Robe of the Poet Rudaki";
            robe.Hue = 2214; // Vibrant green
            robe.Attributes.LowerRegCost = 15;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.Luck = 55;
            robe.Attributes.BonusInt = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Ancient Penjikent";
            map.Bounds = new Rectangle2D(4352, 1736, 512, 512);
            map.NewPin = new Point2D(4500, 1900);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTajikistan(Serial serial) : base(serial) { }

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

    // Lore Book: ChronicleOfTajikistan
    public class ChronicleOfTajikistan : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Tajikistan", "The Wise Wanderer",
            new BookPageInfo
            (
                "Upon the roof of the world,",
                "in the shadow of the Pamir,",
                "lies Tajikistan: land of ancient",
                "kings, poets, and mountain",
                "legends. The Oxus River",
                "winds through valleys, carrying",
                "the memories of Sogdian gold",
                "and Silk Road caravans."
            ),
            new BookPageInfo
            (
                "For millennia, traders and",
                "warriors crossed the passes,",
                "bringing Persian words and",
                "Chinese silks, Buddhist scrolls",
                "and Zoroastrian flame.",
                "Here, the ancient city of",
                "Penjikent flourished, walls",
                "painted with epic tales."
            ),
            new BookPageInfo
            (
                "Sogdian merchants grew rich,",
                "and fire-temples lit the night.",
                "When the Arabs came, the",
                "ancient faiths gave way to",
                "Islam, but the spirit of the",
                "old gods lingered, hidden in",
                "mountain shrines and village",
                "songs."
            ),
            new BookPageInfo
            (
                "In time, poets like Rudaki",
                "sang in Persian, weaving",
                "words of love and longing.",
                "The Empire of Timur rose,",
                "and later the silk banners of",
                "the Great Game fluttered.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Soviet banners flew in",
                "the valleys, yet the peaks",
                "remained free. The people",
                "endured, as they had for",
                "ages: weavers, herders,",
                "scholars, warriors.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Today, Tajikistan stands,",
                "proud and enduring,",
                "guarding its memories.",
                "From the singing Pamir winds",
                "to the laughter of its children,",
                "the story continues,",
                "woven in silk and stone.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May those who open this chest",
                "carry a piece of Tajikistan’s",
                "legacy with them: courage,",
                "wisdom, and the spirit of the",
                "mountains.",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTajikistan() : base(false)
        {
            Hue = 2662; // Deep blue, to match the chest
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Tajikistan");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Tajikistan");
        }

        public ChronicleOfTajikistan(Serial serial) : base(serial) { }

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

    // Custom consumable for mountain honey
    public class MountainHoney : JarHoney
    {
        [Constructable]
        public MountainHoney()
        {
            Name = "Pamir Mountain Honey";
            Hue = 2125;
            Stackable = false;
        }

        public MountainHoney(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
