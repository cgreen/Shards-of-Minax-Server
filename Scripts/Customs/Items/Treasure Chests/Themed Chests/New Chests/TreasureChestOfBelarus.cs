using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBelarus : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBelarus()
        {
            Name = "Treasure Chest of Belarus";
            Hue = 1260; // Traditional Belarusian red

            // Add items to the chest
            AddItem(CreateNamedItem<ArtifactVase>("Polotsk Relic Vase", 2600), 0.18);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Vase of the Grand Duchy", 2415), 0.14);
            AddItem(CreateColoredItem<GreaterHealPotion>("Radziwill’s Secret Tincture", 1355), 0.16);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Slavic Unity"), 0.19);
            AddItem(CreateColoredItem<Sandals>("Boots of the Forest Druid", 2745), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Daugava Song"), 0.13);
            AddItem(CreateDecorativeSwordDisplay(), 0.15);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateUniqueBook(), 1.0);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.20);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateUniqueClothing(), 0.18);
            AddItem(CreateBelarusianFood(), 0.22);
            AddItem(CreateNamedItem<GreaterHealPotion>("Bison Milk"), 0.10);
            AddItem(CreateColoredItem<Ruby>("Ruby of Minsk", 1157), 0.12);
            AddItem(CreateNamedItem<GreaterHealPotion>("Cup of Birch Sap"), 0.10);
            AddItem(CreateCustomShield(), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name, int hue = -1) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > -1)
                item.Hue = hue;
            return item;
        }

        private Item CreateDecorativeSwordDisplay()
        {
            DecorativeSwordWest display = new DecorativeSwordWest();
            display.Name = "Sword of Polotsk Display";
            display.Hue = 2600;
            return display;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Ancient Belarus";
            map.Bounds = new Rectangle2D(1800, 3100, 800, 650);
            map.NewPin = new Point2D(2200, 3450);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueBook()
        {
            return new ChronicleOfBelarus();
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Bardiche(), new Scimitar(), new WarHammer(), new Katana()
            );
            weapon.Name = "Sword of the White Rus";
            weapon.Hue = 1150 + Utility.Random(0, 100);
            weapon.MaxDamage = Utility.Random(45, 75);
            weapon.MinDamage = Utility.Random(25, 40);
            weapon.Attributes.AttackChance = 18;
            weapon.Attributes.WeaponDamage = 25;
            weapon.WeaponAttributes.HitHarm = 18;
            weapon.WeaponAttributes.SelfRepair = 7;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new ChainCoif(), new PlateChest(), new PlateLegs(), new StuddedGloves()
            );
            armor.Name = "Lynx-Pattern Armor of Lithuania";
            armor.Hue = 2051 + Utility.Random(0, 100);
            armor.BaseArmorRating = Utility.Random(35, 67);
            armor.Attributes.BonusStam = 10;
            armor.Attributes.BonusHits = 12;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.MageArmor = 1;
            armor.PhysicalBonus = 10;
            armor.FireBonus = 7;
            armor.ColdBonus = 13;
            armor.PoisonBonus = 5;
            armor.EnergyBonus = 9;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 14.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Vyshyvanka Robe of Heritage";
            robe.Hue = 1153; // Traditional Belarusian embroidery color
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusInt = 7;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.RegenMana = 3;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 16.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 9.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateCustomShield()
        {
            ChaosShield shield = new ChaosShield();
            shield.Name = "Pahonia Knight’s Shield";
            shield.Hue = 1260;
            shield.Attributes.DefendChance = 17;
            shield.Attributes.SpellChanneling = 1;
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateBelarusianFood()
        {
            Utility.PushColor(ConsoleColor.Cyan);
            Item food;
            switch (Utility.Random(4))
            {
                case 0:
                    food = new CheeseWedge();
                    food.Name = "Draniki (Potato Pancake)";
                    break;
                case 1:
                    food = new BreadLoaf();
                    food.Name = "Borodinsky Bread";
                    break;
                case 2:
                    food = new JarHoney();
                    food.Name = "Polesia Wildflower Honey";
                    break;
                default:
                    food = new BowlOfBlackrockStew();
                    food.Name = "Sorrel Soup";
                    break;
            }
            Utility.PopColor();
            return food;
        }

        public TreasureChestOfBelarus(Serial serial) : base(serial) { }

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

    public class ChronicleOfBelarus : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Belarus", "Chronicler Mikola Haurylenka",
            new BookPageInfo
            (
                "From ancient Polatsk and",
                "the glistening Dnieper,",
                "Belarus grew from wild",
                "forests, her people the",
                "White Rus’, proud and",
                "unyielding. Here princes",
                "battled knights and time.",
                "Legends were born."
            ),
            new BookPageInfo
            (
                "As the Grand Duchy of",
                "Lithuania rose, so too",
                "did Belarusian might.",
                "Nobles bore the Pahonia,",
                "rushing on horseback into",
                "the pages of glory. In",
                "Vilnius and Navahrudak,",
                "wisdom and sword mingled."
            ),
            new BookPageInfo
            (
                "The forests shielded the",
                "faithful from crusaders,",
                "from Tatar and Teuton,",
                "from fire and iron. The",
                "songs of kupala night",
                "outlived conquerors’ names.",
                "Freedom’s spirit flickered",
                "but never died."
            ),
            new BookPageInfo
            (
                "Centuries brought empires:",
                "Polish kings, tsars of",
                "Russia, armies of the",
                "world. Yet Belarus’s heart",
                "remained whole: a tapestry",
                "of endurance, hope, and",
                "quiet, fierce love for",
                "the land of lakes."
            ),
            new BookPageInfo
            (
                "Now, as the world turns,",
                "may you who find this chest",
                "remember: every artifact,",
                "every rune, every coin—",
                "all are threads in the",
                "cloth of a nation. Seek",
                "honor, not conquest. Bring",
                "peace, not pillage."
            ),
            new BookPageInfo
            (
                "For the history of Belarus",
                "lives on not just in",
                "books, but in deeds, in",
                "songs, and in the hearts",
                "of those who call her",
                "home. May her story find",
                "a place in yours.",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfBelarus() : base(false)
        {
            Hue = 1260; // Belarusian red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Belarus");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Belarus");
        }

        public ChronicleOfBelarus(Serial serial) : base(serial) { }

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
