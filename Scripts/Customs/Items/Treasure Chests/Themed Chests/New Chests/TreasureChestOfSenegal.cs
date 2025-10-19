using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSenegal : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSenegal()
        {
            Name = "Treasure Chest of the Kingdoms of Senegal";
            Hue = 2213; // Rich golden-brown

            // Add items to the chest
            AddItem(CreateDecorativeItem<GriotDrum>("Griot's Drum of Memory", 1166), 0.15);
            AddItem(CreateDecorativeItem<CarvedMask>("Carved Mask of the Fulani Spirit", 1458), 0.18);
            AddItem(CreateDecorativeItem<ArtifactVase>("Wolof King's Urn", 1367), 0.10);
            AddItem(CreateDecorativeItem<GoldBracelet>("Serer Gold Torque", 2125), 0.18);
            AddItem(CreateConsumable<BaobabFruit>("Baobab Fruit of Vitality", 2130), 0.22);
            AddItem(CreateConsumable<GreaterHealPotion>("Elixir of the Djinn", 288), 0.15);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateShield(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Oracle's Eye of Goree", 1150), 0.09);
            AddItem(new ChroniclesOfTheBaobabKings(), 1.0); // Lore book, always included
            AddItem(new Gold(Utility.Random(1200, 3500)), 0.15);
            AddItem(CreateDecorativeItem<BlueSand>("Sands of the Senegal River", 93), 0.15);
            AddItem(CreateNamedItem<AncientWeapon1>("Sword of the Lion Queen"), 0.11);
            AddItem(CreateNamedItem<Necklace>("Necklace of Dakar’s Stars"), 0.18);
            AddItem(CreateMap(), 0.06);
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

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Niani";
            map.Bounds = new Rectangle2D(2460, 3150, 320, 320);
            map.NewPin = new Point2D(2560, 3240);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Legendary spear inspired by African royalty
            ShortSpear spear = new ShortSpear();
            spear.Name = "Spear of the Wolof Kings";
            spear.Hue = 2125; // Gold
            spear.MinDamage = 32;
            spear.MaxDamage = 75;
            spear.Attributes.BonusStr = 10;
            spear.Attributes.AttackChance = 12;
            spear.Attributes.DefendChance = 10;
            spear.WeaponAttributes.HitLightning = 30;
            spear.Attributes.BonusStam = 15;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 18.0);
            spear.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Lion Queen";
            shield.Hue = 2123;
            shield.ArmorAttributes.SelfRepair = 7;
            shield.ArmorAttributes.LowerStatReq = 20;
            shield.Attributes.BonusHits = 25;
            shield.Attributes.ReflectPhysical = 13;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Baobab Plate of the Griots";
            chest.Hue = 1487; // Deep earthy green
            chest.BaseArmorRating = Utility.Random(45, 65);
            chest.Attributes.BonusMana = 10;
            chest.Attributes.RegenMana = 3;
            chest.Attributes.Luck = 120;
            chest.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Peacemaking, 8.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // A unique, magic robe styled after West African boubous
            Robe robe = new Robe();
            robe.Name = "Griot's Embroidered Boubou";
            robe.Hue = 1175;
            robe.Attributes.BonusInt = 12;
            robe.Attributes.CastSpeed = 1;
            robe.Attributes.RegenHits = 3;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.Inscribe, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfSenegal(Serial serial) : base(serial)
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

    // The custom book of lore
    public class ChroniclesOfTheBaobabKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Baobab Kings", "Djibril the Griot",
            new BookPageInfo
            (
                "Beneath the shade of the",
                "baobab, the kings of the",
                "Senegal watched the",
                "rivers run and the lions",
                "prowl. Long before the",
                "foreign sails, there were",
                "the peoples: Wolof,",
                "Serer, Fulani, Mandinka."
            ),
            new BookPageInfo
            (
                "Great was the kingdom",
                "of Tekrur, oldest of the",
                "Senegal. Gold from its",
                "rivers fed the Mali.",
                "From the sands to the",
                "forest, griots sang of",
                "warriors who never fell.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "In the time of the Lion",
                "Queen, Ndella of the",
                "Jolof, enemies fled at",
                "her roar. Her shield",
                "turned spears. The",
                "drummers summoned",
                "the djinn and thunder",
                "with every battle cry."
            ),
            new BookPageInfo
            (
                "But peace, too, was a",
                "treasure. Griots carried",
                "history from court to",
                "village. Wisdom and",
                "stories wove the land",
                "together, unbroken by",
                "time or conqueror.",
                ""
            ),
            new BookPageInfo
            (
                "The baobab remembers.",
                "The gold, the salt, the",
                "heroes. The river keeps",
                "secrets for those brave",
                "enough to seek them.",
                "",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "If you have opened this",
                "chest, honor the memory",
                "of those who came before.",
                "May you walk with the",
                "strength of the Lion Queen",
                "and the wisdom of the",
                "griots.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Senegal endures, as the",
                "baobab endures—ancient,",
                "unyielding, and filled",
                "with hidden life.",
                "",
                "",
                "",
                "",
                "- Djibril the Griot"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheBaobabKings() : base(false)
        {
            Hue = 1175; // Gold/earthy
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Baobab Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Baobab Kings");
        }

        public ChroniclesOfTheBaobabKings(Serial serial) : base(serial) { }

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

    // Example of a simple new food item
    public class BaobabFruit : Food
    {
        [Constructable]
        public BaobabFruit() : base(Utility.RandomList(0xC77, 0xC78))
        {
            Name = "Baobab Fruit";
            Hue = 2130;
            FillFactor = 6;
        }

        public BaobabFruit(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    // Example: Griot's Drum as a decorative item (reskin)
    public class GriotDrum : Item
    {
        [Constructable]
        public GriotDrum() : base(0xE9C)
        {
            Name = "Griot's Drum";
            Hue = 1166;
            Weight = 3.0;
        }
        public GriotDrum(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    // Example: Carved Mask as a decorative item (reskin)
    public class CarvedMask : Item
    {
        [Constructable]
        public CarvedMask() : base(0x2FB7)
        {
            Name = "Carved Mask";
            Hue = 1458;
            Weight = 2.0;
        }
        public CarvedMask(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }
}
