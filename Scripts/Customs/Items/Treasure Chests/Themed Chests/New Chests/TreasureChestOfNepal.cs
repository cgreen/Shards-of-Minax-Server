using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNepal : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNepal()
        {
            Name = "Treasure Chest of Nepal's Legends";
            Hue = 1152; // Deep Himalayan blue

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactVase>("Ancient Kathmandu Vase", 2075), 0.18);
            AddItem(CreateDecorativeItem<StatueSouth>("Statue of Swayambhunath Stupa", 2213), 0.14);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Goddess Tara Crane", 1402), 0.13);
            AddItem(CreateDecorativeItem<ZenRock1Artifact>("Sacred Himalayan Rock", 2500), 0.19);
            AddItem(CreateConsumableItem<GreenTea>("Himalayan Green Tea", 1266), 0.16);
            AddItem(CreateConsumableItem<BentoBox>("Sherpa's Rice Box", 1154), 0.12);
            AddItem(CreateNamedItem<SackOfSugar>("Salt of the Silk Road"), 0.08);
            AddItem(CreateBookOfLore(), 1.0);

            AddItem(CreateNepalWeapon(), 0.20);
            AddItem(CreateNepalArmor(), 0.22);
            AddItem(CreateNepalClothing(), 0.18);
            AddItem(CreateNepalJewelry(), 0.16);

            AddItem(CreateNepalMap(), 0.04);
            AddItem(CreateDecorativeItem<FlowersArtifact>("Rhododendron Crown", 1165), 0.12);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Crystal of the Yeti", 2498), 0.07);
            AddItem(CreateGoldItem("Ancient Nepalese Gold Coin"), 0.16);

            AddItem(new Gold(Utility.Random(1000, 7000)), 0.10);
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

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
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
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateNepalWeapon()
        {
            // Custom "Gurkha Kukri Blade"
            Katana kukri = new Katana();
            kukri.Name = "Gurkha Kukri Blade";
            kukri.Hue = 2001;
            kukri.Attributes.WeaponDamage = 35;
            kukri.Attributes.BonusDex = 15;
            kukri.Attributes.BonusHits = 25;
            kukri.WeaponAttributes.HitFireball = 20;
            kukri.WeaponAttributes.HitDispel = 10;
            kukri.WeaponAttributes.SelfRepair = 4;
            kukri.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            kukri.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            kukri.Slayer = SlayerName.Repond; // Slays beasts and monsters
            XmlAttach.AttachTo(kukri, new XmlLevelItem());
            return kukri;
        }

        private Item CreateNepalArmor()
        {
            // "Mail of the Malla Kings" - high defense, magic resist
            PlateChest armor = new PlateChest();
            armor.Name = "Mail of the Malla Kings";
            armor.Hue = 2414;
            armor.BaseArmorRating = 62;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusInt = 10;
            armor.Attributes.SpellChanneling = 1;
            armor.Attributes.ReflectPhysical = 10;
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.SelfRepair = 3;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateNepalClothing()
        {
            // "Robe of Himalayan Wisdom" - magery & meditation boosts
            Robe robe = new Robe();
            robe.Name = "Robe of Himalayan Wisdom";
            robe.Hue = 1152;
            robe.Attributes.LowerManaCost = 20;
            robe.Attributes.LowerRegCost = 15;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.RegenMana = 3;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 25.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateNepalJewelry()
        {
            // "Third Eye Amulet" - spirit speak, resist, spell power
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Third Eye Amulet";
            amulet.Hue = 1153;
            amulet.Attributes.SpellDamage = 16;
            amulet.Attributes.CastRecovery = 2;
            amulet.Attributes.BonusInt = 8;
            amulet.Attributes.NightSight = 1;
            amulet.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 18.0);
            amulet.SkillBonuses.SetValues(1, SkillName.Necromancy, 10.0);
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateNepalMap()
        {
            // Map showing Kathmandu Valley, Everest, Lumbini, etc.
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Ancient Nepal";
            map.Bounds = new Rectangle2D(1500, 2500, 800, 700);
            map.NewPin = new Point2D(1550, 2950);
            map.Protected = true;
            return map;
        }

        private Item CreateBookOfLore()
        {
            return new ChroniclesOfNepal();
        }

        public TreasureChestOfNepal(Serial serial) : base(serial) { }

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

    public class ChroniclesOfNepal : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Himalayas", "Bodhisattva Scribe",
            new BookPageInfo
            (
                "In the shadow of Everest,",
                "where clouds crown the world,",
                "rose the lands of Nepal.",
                "From Lumbini, the Buddha's",
                "birthplace, to Kathmandu’s",
                "valley, ancient kings",
                "wove their fate."
            ),
            new BookPageInfo
            (
                "The Kirats first held",
                "the forested hills,",
                "then the Licchavis carved",
                "temples in stone and gold.",
                "The Malla Kings built cities",
                "of art and learning.",
                "Their pagodas touched the sky."
            ),
            new BookPageInfo
            (
                "Invaders came—Tibetans,",
                "Mughals, Gorkhas. The Gurkha",
                "blades forged a new kingdom,",
                "united by Prithvi Narayan",
                "Shah. The mountain warriors",
                "became legend, their loyalty",
                "unmatched."
            ),
            new BookPageInfo
            (
                "From Swayambhunath’s all-seeing",
                "eyes, to Pashupatinath’s",
                "holy river, prayers flow.",
                "Buddhists and Hindus share",
                "festivals of light, color,",
                "and spirit. Their deities",
                "dance together."
            ),
            new BookPageInfo
            (
                "Yet secrets linger in snow",
                "and stone. The yeti roams,",
                "unseen. Lost gold of the",
                "valleys waits. Wisdom rests",
                "in the silence of mountains.",
                "Treasure-seekers, beware:",
                "not all riches are silver",
                "and gems."
            ),
            new BookPageInfo
            (
                "This chest is a tribute.",
                "A link to timeless stories,",
                "hidden between peaks and",
                "temples. Respect the old",
                "gods. Walk softly. For here,",
                "legends are alive, and",
                "the spirits are always",
                "watching."
            ),
            new BookPageInfo
            (
                "May the wind carry your",
                "quest onward, as the",
                "prayer flags flutter.",
                "",
                "",
                "",
                "- Chronicles of Nepal",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfNepal() : base(false)
        {
            Hue = 1152; // Deep Himalayan blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Himalayas");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Himalayas");
        }

        public ChroniclesOfNepal(Serial serial) : base(serial) { }

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
