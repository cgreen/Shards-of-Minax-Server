using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPolishHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPolishHistory()
        {
            Name = "Treasure Chest of Polish History";
            Hue = 1157; // Deep Red, Polish Flag

            // Decorative and themed items
            AddItem(CreateDecorativeItem<ArtifactVase>("Piast Dynasty Vase", 1161), 0.18);
            AddItem(CreateDecorativeItem<KingsPainting1>("Portrait of King Casimir III", 1153), 0.16);
            AddItem(CreateDecorativeItem<SilverSteedZooStatuette>("Silver Steed of Legend", 1150), 0.10);
            AddItem(CreateDecorativeItem<ArcaneTable>("Sarmatian Scholar’s Table", 2213), 0.08);

            // Themed consumables
            AddItem(CreateConsumable<GreaterHealPotion>("Elixir of Sobieski", 137), 0.18);
            AddItem(CreateConsumable<RandomFancyDinner>("Feast of the Winged Hussar", 1877), 0.15);
            AddItem(CreateConsumable<BottleArtifact>("Royal Mead of Wawel", 1001), 0.17);

            // Custom weapons and armor
            AddItem(CreateHussarSaber(), 0.21);
            AddItem(CreateEagleCrestArmor(), 0.19);
            AddItem(CreateCrimsonSash(), 0.17);

            // Themed clothing
            AddItem(CreatePolishCloak(), 0.22);
            AddItem(CreatePolishHat(), 0.13);
            AddItem(CreatePolishBoots(), 0.13);

            // Lore book
            AddItem(new ChroniclesOfThePolishCrown(), 1.0);

            // Gold and coin
            AddItem(CreateGoldItem("Polish Ducat"), 0.18);
            AddItem(new Gold(Utility.Random(1, 5500)), 0.13);

            // Other themed items
            AddItem(CreateDecorativeItem<WindChimes>("Carillon of Kraków", 1151), 0.12);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Replica Sword of Grunwald", 1109), 0.14);
            AddItem(CreateMap(), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative Item Generator
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumable Item Generator
        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Gold with custom name
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Unique Hussar Saber Weapon
        private Item CreateHussarSaber()
        {
            Katana saber = new Katana();
            saber.Name = "Winged Hussar Saber";
            saber.Hue = 1177; // Silver
            saber.MinDamage = 36;
            saber.MaxDamage = 69;
            saber.Attributes.BonusStam = 15;
            saber.Attributes.WeaponSpeed = 20;
            saber.Attributes.AttackChance = 15;
            saber.Attributes.DefendChance = 8;
            saber.Attributes.BonusStr = 7;
            saber.WeaponAttributes.HitLightning = 25;
            saber.WeaponAttributes.HitLeechHits = 12;
            saber.Slayer = SlayerName.DragonSlaying;
            saber.SkillBonuses.SetValues(0, SkillName.Swords, 17.0);
            saber.SkillBonuses.SetValues(1, SkillName.Tactics, 14.0);
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        // Unique Eagle Crest Armor
        private Item CreateEagleCrestArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Eagle Crest Armor";
            armor.Hue = 1153; // White/Silver
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusHits = 35;
            armor.Attributes.BonusDex = 10;
            armor.Attributes.Luck = 40;
            armor.Attributes.NightSight = 1;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Crimson Sash for mages or dexers
        private Item CreateCrimsonSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Crimson Sash of the Vistula";
            sash.Hue = 33; // Deep crimson
            sash.Attributes.SpellDamage = 12;
            sash.Attributes.CastSpeed = 1;
            sash.Attributes.CastRecovery = 1;
            sash.Attributes.BonusInt = 8;
            sash.SkillBonuses.SetValues(0, SkillName.Magery, 14.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        // Unique Clothing
        private Item CreatePolishCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Polish Knight";
            cloak.Hue = 1157; // Polish Red
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.Luck = 22;
            cloak.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreatePolishHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Szlachta’s Feathered Cap";
            hat.Hue = 1002; // Blue accent
            hat.Attributes.BonusInt = 6;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Macing, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreatePolishBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Great March";
            boots.Hue = 2406; // Dark brown/black
            boots.Attributes.BonusStam = 10;
            boots.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Polish-Lithuanian Commonwealth";
            map.Bounds = new Rectangle2D(1500, 1500, 600, 400);
            map.NewPin = new Point2D(1650, 1650);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfPolishHistory(Serial serial) : base(serial) { }

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

    // --- Custom Lore Book ---
    public class ChroniclesOfThePolishCrown : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Polish Crown", "Jan of Wawel",
            new BookPageInfo
            (
                "From the mists of the Vistula,",
                "the Piast kings forged a realm,",
                "A land of knights and scholars,",
                "crimson banners against the dawn.",
                "Here stood the lionhearted,",
                "defiant at Grunwald’s field,",
                "And the eagle soared, unbroken,",
                "when storms gathered from the West."
            ),
            new BookPageInfo
            (
                "Through golden ages, the Sejm",
                "echoed with proud debate.",
                "Winged Hussars thundered",
                "across Vienna’s plains,",
                "breaking the siege and",
                "turning the tide of Europe.",
                "From Wawel’s halls to the Baltic,",
                "Poland’s song endured."
            ),
            new BookPageInfo
            (
                "Yet darkness fell—partitions,",
                "iron chains, and foreign rule.",
                "But the Polish spirit kindled,",
                "hidden in verse, in faith, in heart.",
                "Insurrection after insurrection,",
                "echoed with the cry:",
                "\"Jeszcze Polska nie zginęła!\"",
                "Poland is not yet lost."
            ),
            new BookPageInfo
            (
                "Warsaw rose from ashes,",
                "the red and white flown high.",
                "Solidarity whispered in the night,",
                "and freedom’s bells rang once more.",
                "The eagle, crowned anew,",
                "took flight to the sunrise,",
                "bearing scars, but never bowed.",
                "This is the legacy within this chest."
            ),
            new BookPageInfo
            (
                "To the seeker of legend:",
                "May you remember the cost",
                "of liberty, the beauty of hope,",
                "the power of faith.",
                "For in every coin, every blade,",
                "every piece of gold—",
                "the Polish heart beats,",
                "undaunted, eternal."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfThePolishCrown() : base(false)
        {
            Hue = 1153; // Polish White/Silver
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Polish Crown");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Polish Crown");
        }

        public ChroniclesOfThePolishCrown(Serial serial) : base(serial) { }

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
