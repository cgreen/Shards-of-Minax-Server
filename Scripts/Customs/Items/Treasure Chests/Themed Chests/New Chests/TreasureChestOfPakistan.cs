using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPakistan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPakistan()
        {
            Name = "Treasure Chest of Pakistan";
            Hue = 1155; // Unique green, like the flag

            // Add themed items to the chest
            AddItem(CreateDecorative<MohenjoDaroRelic>("Mohenjo-Daro Relic", 1266), 0.20);
            AddItem(CreateDecorative<GandharaBuddhaStatue>("Gandhara Buddha Statuette", 241), 0.14);
            AddItem(CreateNamedItem<Gold>("Mughal Dynasty Coin"), 0.22);
            AddItem(CreateColoredItem<GreaterHealPotion>("Chai of Wisdom", 1161), 0.18);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Iqbal's Poetry Book"), 0.16);
            AddItem(CreateConsumable<GreenTea>("Sindh Fruit Basket", 1225), 0.13);
            AddItem(CreateColoredItem<Diamond>("Indus Sapphire", 1282), 0.15);
            AddItem(CreateDecorative<JinnahsPen>("Jinnah's Fountain Pen", 2306), 0.10);
            AddItem(CreateColoredItem<BentoBox>("Healing Samosa", 1270), 0.08);
            AddItem(CreateEquipment(), 0.18);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateClothing(), 0.17);
            AddItem(CreateShield(), 0.14);
            AddItem(CreateWeapon(), 0.17);
            AddItem(CreateColoredItem<Bandana>("Bandana of the Lahore Saint", 1177), 0.17);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(new Gold(Utility.Random(1, 6000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.Movable = true;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateEquipment()
        {
            // Unique Sword with heavy mods
            Longsword sword = new Longsword();
            sword.Name = "Sword of the Ghaznavid";
            sword.Hue = 1357;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusHits = 30;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.WeaponDamage = 25;
            sword.Attributes.ReflectPhysical = 10;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Mughal Emperor's Breastplate";
            chest.Hue = 1157;
            chest.Attributes.BonusHits = 20;
            chest.ArmorAttributes.LowerStatReq = 25;
            chest.Attributes.RegenHits = 4;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Iqbal's Inspiration Cloak";
            robe.Hue = 1175;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.Luck = 45;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateShield()
        {
            HeaterShield shield = new HeaterShield();
            shield.Name = "Shield of the Indus";
            shield.Hue = 1283;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.BonusStam = 8;
            shield.SkillBonuses.SetValues(0, SkillName.Tactics, 14.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Blade of the Sufi";
            weapon.Hue = 2101;
            weapon.Attributes.BonusMana = 18;
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitLeechMana = 18;
            weapon.WeaponAttributes.HitLowerAttack = 14;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 17.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfPakistan();
        }

        public TreasureChestOfPakistan(Serial serial) : base(serial) { }

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

    // ---- Lore Book ----
    public class ChroniclesOfPakistan : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Pakistan", "Various Scribes",
            new BookPageInfo
            (
                "From the mists of ages,",
                "where the mighty Indus",
                "river carved civilization,",
                "rose the cities of Harappa",
                "and Mohenjo-Daro. Trade,",
                "script, and order flourished,",
                "echoing the dawn of man."
            ),
            new BookPageInfo
            (
                "Buddhist Gandhara shone,",
                "sculpting serenity in stone.",
                "Emperors came and went:",
                "Maurya, Kushan, Ghaznavid,",
                "Mughal. Each left legacy,",
                "ruins, wisdom, beauty, and",
                "tales in every grain of soil."
            ),
            new BookPageInfo
            (
                "The call to freedom rang.",
                "Muhammad Ali Jinnah, the",
                "Quaid-e-Azam, led a dream.",
                "From Lahore's green fields,",
                "to the deserts of Sindh, a",
                "nation was born: Pakistan.",
                "Land of the pure."
            ),
            new BookPageInfo
            (
                "From partition's pain and",
                "refugee trails, to Minar-e-",
                "Pakistan's promise, the story",
                "unfolds—of poetry and struggle,",
                "of faith and resilience, from",
                "Iqbal's verses to Sufi songs."
            ),
            new BookPageInfo
            (
                "Let this chest hold memory,",
                "as rivers hold reflection.",
                "May its treasures honor the",
                "past and inspire the seeker.",
                "For the soul of Pakistan is",
                "not in gold, but in history,",
                "in unity, in hope."
            ),
            new BookPageInfo
            (
                "He who opens this chest",
                "is a witness to centuries.",
                "Cherish what you find. For",
                "history, once uncovered, is",
                "the true treasure.",
                "",
                "- Chronicles of Pakistan"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfPakistan() : base(false)
        {
            Hue = 1153; // Deep flag green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Pakistan");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Pakistan");
        }

        public ChroniclesOfPakistan(Serial serial) : base(serial) { }

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

    // --- Decorative item stubs ---

    public class MohenjoDaroRelic : ArtifactLargeVase
    {
        [Constructable]
        public MohenjoDaroRelic()
        {
            Name = "Mohenjo-Daro Relic";
        }
        public MohenjoDaroRelic(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    public class GandharaBuddhaStatue : ChangelingStatue
    {
        [Constructable]
        public GandharaBuddhaStatue()
        {
            Name = "Gandhara Buddha Statuette";
        }
        public GandharaBuddhaStatue(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    public class JinnahsPen : PenAndInk
    {
        [Constructable]
        public JinnahsPen()
        {
            Name = "Jinnah's Fountain Pen";
        }
        public JinnahsPen(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }
}

