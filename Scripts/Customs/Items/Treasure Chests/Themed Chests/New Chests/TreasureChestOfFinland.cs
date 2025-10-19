using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfFinland : WoodenChest
    {
        [Constructable]
        public TreasureChestOfFinland()
        {
            Name = "Treasure Chest of Finland";
            Hue = 1153; // Icy blue

            // Add items to the chest
            AddItem(new MaxxiaScroll(), 0.06);
            AddItem(CreateDecorativeItem<SnowStatuePegasus>("Sampo Relic", 0x482, 1150), 0.15); // Sampo from Kalevala
            AddItem(CreateDecorativeItem<MagicCrystalBall>("Runestone of Väinämöinen", 0xE2D, 0x4B6), 0.18);
            AddItem(CreateConsumable<FrenchBread>("Rune Pulla (Sweet Bread)", 1153), 0.17);
            AddItem(CreateConsumable<Bottle>("Sauna Brew", 1150), 0.13);
            AddItem(CreateUniqueMap(), 0.07);
            AddItem(new SagaOfTheNorthBook(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 5000)), 0.15);

            // Unique Equipment
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.19);
            AddItem(CreateShield(), 0.14);

            // Thematic extras
            AddItem(CreateDecorativeItem<DecorativeVines>("Northern Lights Vine", 0x47F, 1266), 0.12);
            AddItem(CreateDecorativeItem<BlueSnowflake>("Winter's Emblem", 0x1C18, 1153), 0.18);
            AddItem(CreateDecorativeItem<GargishKnowledgeTotemArtifact>("Totem of Sisu", 0x1421, 1175), 0.10);
            AddItem(CreateDecorativeItem<BasketOfGreenTeaMug>("Mug of Cloudberry Tea", 0x9AC, 53), 0.14);
            AddItem(CreateDecorativeItem<WolfStatue>("Kalevala Wolf", 0x20E1, 1109), 0.12);

            // More themed consumables
            AddItem(CreateConsumable<WhiteChocolate>("Snowdrift Chocolate", 1152), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int itemID, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.ItemID = itemID;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Sampo’s Rest";
            map.Bounds = new Rectangle2D(5100, 1000, 400, 400); // Fictitious northern coordinates
            map.NewPin = new Point2D(5200, 1150);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            Broadsword weapon = new Broadsword();
            weapon.Name = "Kullervo’s Frostblade";
            weapon.Hue = 1153;
            weapon.MinDamage = 40;
            weapon.MaxDamage = 75;
            weapon.WeaponAttributes.HitColdArea = 50;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitMagicArrow = 20;
            weapon.Attributes.BonusStr = 15;
            weapon.Attributes.AttackChance = 12;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Bearskin Plate of Väinämöinen";
            armor.Hue = 1109; // Deep blue
            armor.BaseArmorRating = 55;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.Luck = 50;
            armor.Attributes.DefendChance = 10;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Northern Aurora";
            cloak.Hue = 1266; // Ethereal aurora color
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusMana = 15;
            cloak.Attributes.LowerManaCost = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 8.0);
            cloak.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateShield()
        {
            MetalShield shield = new MetalShield();
            shield.Name = "Sisu Shield";
            shield.Hue = 1175;
            shield.Attributes.BonusDex = 10;
            shield.Attributes.Luck = 40;
            shield.Attributes.DefendChance = 15;
            shield.ArmorAttributes.SelfRepair = 3;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfFinland(Serial serial) : base(serial)
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

    public class SagaOfTheNorthBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Saga of the North: Chronicles of Suomi", "Elias Lönnrot",
            new BookPageInfo
            (
                "In the lands of lakes and snow,",
                "the song of Finland rises. Here,",
                "ancient pines guard secrets old as",
                "ice. The land endures, shaped by",
                "frost, by forest, by silent courage.",
                "This is Suomi, where the North Wind",
                "speaks in runes."
            ),
            new BookPageInfo
            (
                "Väinämöinen, wise and eternal sage,",
                "sang creation into being, his voice",
                "a bridge between worlds. The Sampo,",
                "mystic mill of plenty, was forged",
                "in struggle and stolen by the",
                "bold. Myths are marrow here."
            ),
            new BookPageInfo
            (
                "Through ages of Swedish and Russian",
                "rule, Finns held fast to the spirit",
                "of Sisu: grit, resilience, and quiet",
                "defiance. Through war, famine, and",
                "endless winter, a nation endured."
            ),
            new BookPageInfo
            (
                "In forests deep, runes were carved,",
                "and songs were sung. Heroes rose:",
                "Lemminkäinen, fierce wanderer;",
                "Kullervo, tragic avenger; Ilmarinen,",
                "the smith who shaped stars."
            ),
            new BookPageInfo
            (
                "The fires of independence in 1917",
                "brought hope and hardship. Winter",
                "War’s white silence was shattered by",
                "invaders, but in the cold, the heart",
                "of Finland burned ever brighter."
            ),
            new BookPageInfo
            (
                "Now, Finland stands proud and free,",
                "its people woven from story and stone,",
                "from sauna smoke and shimmering lakes.",
                "May the Sisu within these lands pass",
                "to all who seek their fortune here."
            ),
            new BookPageInfo
            (
                "Let this chest, and all it holds,",
                "remind you: The North remembers.",
                "Honor the wisdom of ages and the",
                "beauty of resilience. Glory to",
                "Suomi. Glory to the North."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SagaOfTheNorthBook() : base(false)
        {
            Hue = 1153; // Icy blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Saga of the North: Chronicles of Suomi");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Saga of the North: Chronicles of Suomi");
        }

        public SagaOfTheNorthBook(Serial serial) : base(serial) { }

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
