using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientPersia : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientPersia()
        {
            Name = "Treasure Chest of Ancient Persia";
            Hue = 1281; // Persian royal purple

            // Add items to the chest
            AddItem(new MaxxiaScroll(), 0.04);
            AddItem(CreatePersianArtifact(), 0.18);
            AddItem(CreatePersianCarpet(), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Elixir of the Immortal Shahs", 1277), 0.13);
            AddItem(CreateNamedItem<TreasureLevel2>("Lion of the Empire Statuette"), 0.13);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Peacock Throne"), 0.32);
            AddItem(new ChroniclesOfTheLionAndTheSun(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7500)), 0.16);
            AddItem(CreateColoredItem<Ruby>("Fire Ruby of Persepolis", 1359), 0.10);
            AddItem(CreateNamedItem<Pitcher>("Persian Pomegranate Wine"), 0.10);
            AddItem(CreateGoldItem("Darik Coin of Darius"), 0.13);
            AddItem(CreateColoredItem<ThighBoots>("Boots of the Royal Messenger", 1151), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Scheherazade"), 0.13);
            AddItem(CreateMap(), 0.03);
            AddItem(CreateNamedItem<Sextant>("Astrolabe of the Magi"), 0.11);
            AddItem(CreateNamedItem<BentoBox>("Persian Saffron Rice Platter"), 0.13);
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateRoyalRobe(), 0.18);
            AddItem(CreateCrown(), 0.15);
            AddItem(CreateDagger(), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative artifact (custom)
        private Item CreatePersianArtifact()
        {
            ArtifactLargeVase vase = new ArtifactLargeVase();
            vase.Name = "Cyrus's Eternal Vase";
            vase.Hue = 1155;
            return vase;
        }

        // Persian carpet
        private Item CreatePersianCarpet()
        {
            Tapestry4N carpet = new Tapestry4N();
            carpet.Name = "Flying Carpet of Nishapur";
            carpet.Hue = 1163;
            return carpet;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Persepolis";
            map.Bounds = new Rectangle2D(2000, 2100, 450, 450);
            map.NewPin = new Point2D(2222, 2222);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Legendary Persian weapon
            Scimitar weapon = new Scimitar();
            weapon.Name = "Scimitar of Rostam";
            weapon.Hue = 1278;
            weapon.MinDamage = Utility.Random(30, 60);
            weapon.MaxDamage = Utility.Random(70, 110);
            weapon.Attributes.BonusStr = 15;
            weapon.Attributes.AttackChance = 20;
            weapon.WeaponAttributes.HitFireArea = 35;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.WeaponAttributes.SelfRepair = 7;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 25.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            weapon.WeaponAttributes.MageWeapon = 2;
            weapon.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of the Achaemenids";
            armor.Hue = 1366;
            armor.BaseArmorRating = Utility.Random(45, 80);
            armor.Attributes.RegenHits = 5;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.Luck = 250;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            armor.ColdBonus = 10;
            armor.FireBonus = 10;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 10;
            armor.PhysicalBonus = 20;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRoyalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Zoroastrian Magi";
            robe.Hue = 1153;
            robe.Attributes.SpellDamage = 20;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.NightSight = 1;
            robe.Attributes.LowerManaCost = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 25.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 20.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of Cyrus the Great";
            crown.Hue = 1289;
            crown.Attributes.BonusMana = 15;
            crown.Attributes.Luck = 100;
            crown.ArmorAttributes.LowerStatReq = 20;
            crown.SkillBonuses.SetValues(0, SkillName.Magery, 30.0);
            crown.SkillBonuses.SetValues(1, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Hashshashin";
            dagger.Hue = 1194;
            dagger.MinDamage = Utility.Random(15, 40);
            dagger.MaxDamage = Utility.Random(40, 75);
            dagger.Attributes.BonusDex = 12;
            dagger.Attributes.ReflectPhysical = 18;
            dagger.WeaponAttributes.HitPoisonArea = 22;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Poisoning, 18.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfAncientPersia(Serial serial) : base(serial)
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

    // Custom lore book: Chronicles of the Lion and the Sun
    public class ChroniclesOfTheLionAndTheSun : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Lion and the Sun", "Scribe of Persepolis",
            new BookPageInfo
            (
                "In the dawn of the world,",
                "the Land of the Aryans",
                "rose, kissed by the Sun.",
                "Here the Lion roared—",
                "kings forged empires,",
                "poets sang, and magi",
                "wove the flames of wisdom.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Cyrus, Father of Kings,",
                "built an empire of mercy.",
                "His decree freed slaves,",
                "welcomed every faith.",
                "The Darics gleamed,",
                "Persepolis shone, and",
                "the world whispered,",
                "‘Persia Eternal.’"
            ),
            new BookPageInfo
            (
                "The Zoroastrian magi",
                "tended the sacred fire,",
                "seeking truth and order.",
                "The Silk Road wove its",
                "tapestry across Persia,",
                "bearing knowledge,",
                "gems, and the perfumes",
                "of far-off Cathay."
            ),
            new BookPageInfo
            (
                "Rostam, the mighty hero,",
                "guarded kings and legends.",
                "The Hashshashin struck from",
                "the shadows. Scheherazade",
                "spun tales as old as the stars.",
                "Even as empires fell, the",
                "spirit of Persia endured,",
                "a lion beneath the sun."
            ),
            new BookPageInfo
            (
                "Let the seeker remember:",
                "in every cup of wine,",
                "every thread of silk,",
                "every stone of Persepolis,",
                "a piece of eternity lingers.",
                "The Lion and the Sun",
                "are never truly gone—",
                "their light is within you."
            ),
            new BookPageInfo
            (
                "To the one who opens this",
                "chest: You are heir to",
                "the wonders and sorrows",
                "of Persia. Guard its memory,",
                "honor its tales, and",
                "walk in the fire of wisdom.",
                "",
                "- Scribe of Persepolis"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheLionAndTheSun() : base(false)
        {
            Hue = 1281; // Persian purple
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Lion and the Sun");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Lion and the Sun");
        }

        public ChroniclesOfTheLionAndTheSun(Serial serial) : base(serial) { }

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
