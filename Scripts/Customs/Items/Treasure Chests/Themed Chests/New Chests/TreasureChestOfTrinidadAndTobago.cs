using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTrinidadAndTobago : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTrinidadAndTobago()
        {
            Name = "Treasure Chest of Trinidad and Tobago";
            Hue = 1172; // Vibrant Caribbean blue

            // Add items to the chest
            AddItem(new CalypsoCarnivalMask(), 0.25);
            AddItem(CreateColoredItem<RandomFancyInstrument>("Steelpan of Port of Spain", 1365), 0.15);
            AddItem(CreateColoredItem<RandomFancyPotion>("Elixir of Carnival Spirit", 2075), 0.17);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Hummingbird", 0), 0.12);
            AddItem(CreateNamedItem<RandomFruitBasket>("Bounty of the Twin Isles", 0), 0.22);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateNamedItem<RandomFancyBanner>("Banner of Unity", 0), 0.10);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Silk Cotton Tree", 0), 0.18);
            AddItem(new ChroniclesOfTheTwinIsles2(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7500)), 0.10);
            AddItem(CreateColoredItem<Sandals>("Pitch Lake Boots", 1802), 0.18);
            AddItem(CreateNamedItem<GreaterHealPotion>("Rum of Buccoo Reef"), 0.16);
            AddItem(CreateDecorativeStatue(), 0.11);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateHat(), 0.18);
            AddItem(CreateLongPants(), 0.18);
            AddItem(CreateUniqueFood(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0) item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Pirate's Map of Trinidad & Tobago";
            map.Bounds = new Rectangle2D(4300, 3700, 300, 250);
            map.NewPin = new Point2D(4450, 3800);
            map.Protected = true;
            return map;
        }

        private Item CreateDecorativeStatue()
        {
            // Example: A statue representing folklore
            RandomFancyStatue statue = new RandomFancyStatue();
            statue.Name = "Douen Spirit Statuette";
            statue.Hue = 1146;
            return statue;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Scimitar(), new Dagger(), new Scepter(), new MagicWand()
            );
            weapon.Name = Utility.RandomList(
                "Soucouyant's Firebrand",
                "Midnight Robber's Blade",
                "Cutlass of the Caribbean",
                "Douen's Mischief Dagger",
                "Scepter of the Orisha Spirits"
            );
            weapon.Hue = Utility.RandomList(1365, 1802, 1172, 2075);
            weapon.MaxDamage = Utility.Random(30, 80);
            weapon.Attributes.BonusHits = Utility.Random(8, 20);
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Stealth, Utility.Random(5, 15));
            weapon.SkillBonuses.SetValues(1, SkillName.Swords, Utility.Random(5, 15));
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new LeatherArms(), new PlateHelm(), new StuddedGloves(), new PlateLegs()
            );
            armor.Name = Utility.RandomList(
                "Shell of the Leatherback",
                "Armor of the Carnival Guard",
                "Chestplate of Calypso",
                "Gloves of the Limbo Dancer",
                "Leggings of the Tobago Buccaneer"
            );
            armor.Hue = Utility.RandomList(1365, 1802, 1172, 2075);
            armor.BaseArmorRating = Utility.Random(35, 70);
            armor.Attributes.Luck = Utility.Random(25, 75);
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, Utility.Random(10, 20));
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, Utility.Random(10, 20));
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Midnight Robber’s Hat";
            hat.Hue = 1802;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.EvalInt, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Caribbean Pirate’s Trousers";
            pants.Hue = Utility.RandomMinMax(1365, 1802);
            pants.Attributes.Luck = 30;
            pants.Attributes.BonusStam = 7;
            pants.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Snooping, 8.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateUniqueFood()
        {
            // Example: doubles as healing consumable
            CheesePizza doubles = new CheesePizza();
            doubles.Name = "Doubles of Invigoration";
            doubles.Hue = 1153;
            doubles.Stackable = true;
            return doubles;
        }

        public TreasureChestOfTrinidadAndTobago(Serial serial) : base(serial)
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

    public class CalypsoCarnivalMask : JesterHat
    {
        [Constructable]
        public CalypsoCarnivalMask()
        {
            Name = "Calypso Carnival Mask";
            Hue = 1172; // Caribbean blue
            Attributes.BonusDex = 10;
            SkillBonuses.SetValues(0, SkillName.Musicianship, 12.0);
            Attributes.Luck = 50;
        }

        public CalypsoCarnivalMask(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheTwinIsles2 : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Twin Isles", "Old Kaiso the Griot",
            new BookPageInfo
            (
                "Once, beyond the blue horizon,",
                "the Amerindian paddles cut the sea,",
                "Carib and Arawak, shaping isles of",
                "forests and pitch. Spirits dwelled",
                "in silk cotton trees, soucouyants",
                "danced in the dark, and douens",
                "laughed in the mangrove shade."
            ),
            new BookPageInfo
            (
                "Then came the sails, white as clouds.",
                "Conquistadors and pirates, planters,",
                "enslaved from far shores, the blood",
                "of Africa, India, China, Europe, all",
                "mingling in the drumbeats, spices,",
                "and festivals. Calypso was born.",
                ""
            ),
            new BookPageInfo
            (
                "The twin isles—Trinidad and Tobago—",
                "became crossroads of world and myth.",
                "Cocoa and cane, oil and rum, Carnival's",
                "riot of color. But the heart beats deeper:",
                "Here, every tale is alive—robbers and",
                "blue devils, mas men and limbo dancers."
            ),
            new BookPageInfo
            (
                "Beware the silk cotton’s shadow.",
                "The forest knows your name. The",
                "pitch lake swallows secrets, the",
                "Buccoo Reef gleams with lost pearls.",
                "Treasure abounds for those bold",
                "enough to seek. But fortune, like",
                "the ocean, is ever-changing."
            ),
            new BookPageInfo
            (
                "So raise a glass of sweet rum,",
                "taste the fire of pepper sauce,",
                "and heed this warning: respect",
                "the old ways, for in these islands,",
                "the past is never truly gone—",
                "and every shadow may dance."
            ),
            new BookPageInfo
            (
                "- Old Kaiso the Griot",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheTwinIsles2() : base(false)
        {
            Hue = 1172; // Caribbean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Twin Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Twin Isles");
        }

        public ChroniclesOfTheTwinIsles2(Serial serial) : base(serial) { }

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
