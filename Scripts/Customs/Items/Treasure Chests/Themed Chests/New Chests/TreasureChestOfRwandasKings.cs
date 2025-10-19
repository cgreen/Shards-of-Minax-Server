using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfRwandasKings : WoodenChest
    {
        [Constructable]
        public TreasureChestOfRwandasKings()
        {
            Name = "Treasure Chest of Rwanda’s Kings";
            Hue = 2125; // Deep green for the land of a thousand hills

            AddItem(CreateNamedItem<AcademicBooksArtifact>("Royal Drum Chronicles", 2453), 0.20);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Inyambo Vase", 1164), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Mwami", 1173), 0.17);
            AddItem(CreateNamedItem<IncenseBurner>("Sacred Hills Incense Burner", 2125), 0.12);
            AddItem(CreateColoredItem<RandomFancyPlant>("Imigongo Pattern Pot", 2707), 0.17);
            AddItem(CreateNamedItem<GreaterHealPotion>("Honeyed Banana Beer", 2428), 0.22);
            AddItem(CreateNamedItem<RandomFancyCoin>("Royal Cowrie Coin", 2508), 0.18);
            AddItem(CreateColoredItem<RandomFancyStatue>("Statue of the Sacred Cow (Inyambo)", 1140), 0.12);
            AddItem(CreateNamedItem<RandomFancyBakedGoods>("Sweet Cassava Cake", 1190), 0.11);
            AddItem(CreateMap(), 0.04);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateRoyalRobe(), 0.20);
            AddItem(CreateElderScepter(), 0.18);
            AddItem(CreateNamedItem<Sextant>("Explorer’s Brass Sextant", 1193), 0.14);
            AddItem(new ChroniclesOfTheThousandHills(), 1.0);
            AddItem(new Gold(Utility.Random(1, 6000)), 0.14);
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
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of the Thousand Hills";
            map.Bounds = new Rectangle2D(2000, 2200, 300, 300);
            map.NewPin = new Point2D(2100, 2350);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Scepter or spear of the king with strong bonuses
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scepter(), new Spear(), new Katana()
            );
            weapon.Name = "Umuheto - Royal Scepter";
            weapon.Hue = 1161; // Royal gold
            weapon.MaxDamage = Utility.Random(45, 80);
            weapon.Attributes.BonusStr = 15;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.SelfRepair = 7;
            weapon.SkillBonuses.SetValues(0, SkillName.Macing, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Shield or chestpiece of the royal guard
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new LeatherChest(), new PlateArms(), new PlateLegs()
            );
            armor.Name = "Amasunzu Guard’s Plate";
            armor.Hue = 2116; // Earthy red, Rwanda soil
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.Attributes.Luck = 35;
            armor.Attributes.BonusHits = 20;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRoyalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Mwami";
            robe.Hue = 2502; // Deep blue, for Lake Kivu
            robe.Attributes.BonusInt = 12;
            robe.Attributes.BonusMana = 18;
            robe.Attributes.LowerManaCost = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            robe.Attributes.CastSpeed = 2;
            robe.Attributes.CastRecovery = 3;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateElderScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Scepter of the Wise Elder";
            scepter.Hue = 2055; // Dark green
            scepter.Attributes.BonusInt = 15;
            scepter.Attributes.SpellChanneling = 1;
            scepter.Attributes.LowerRegCost = 25;
            scepter.WeaponAttributes.HitMagicArrow = 20;
            scepter.SkillBonuses.SetValues(0, SkillName.EvalInt, 15.0);
            scepter.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            scepter.SkillBonuses.SetValues(2, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        public TreasureChestOfRwandasKings(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheThousandHills : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Kingdom of a Thousand Hills", "Mwami Rwabugiri",
            new BookPageInfo
            (
                "In the dawn mist of Rwanda,",
                "among the rolling thousand",
                "hills, a kingdom was born.",
                "The sacred Inyambo cattle",
                "grazed under royal drums,",
                "and our people gathered",
                "in peace and song."
            ),
            new BookPageInfo
            (
                "I, Mwami Rwabugiri, record",
                "our lineage, our trials, our",
                "victories. We ruled not by",
                "fear, but wisdom. From the",
                "volcano’s shadow to Lake",
                "Kivu’s blue, all lands were",
                "united under the drum."
            ),
            new BookPageInfo
            (
                "Let those who seek these",
                "treasures remember: Our",
                "strength is not in gold, but",
                "in the spirit that endures.",
                "The hills whisper tales of",
                "ancient battles, of cows with",
                "horns curved to the sky."
            ),
            new BookPageInfo
            (
                "Here, in this chest, are",
                "fragments of our story:",
                "drums carved by wise hands,",
                "robes dyed in indigo lakes,",
                "scepters of elders, coins of",
                "cowrie and banana beer",
                "sweet as the honeyed dawn."
            ),
            new BookPageInfo
            (
                "May those who open this",
                "find respect for our land.",
                "For the kingdom of the",
                "thousand hills endures,",
                "not in memory alone,",
                "but in every green valley,",
                "in every song sung at dusk.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Go gently, traveler.",
                "Ubumwe, Umurimo, Gukunda",
                "igihugu—Unity, Work, Patriotism.",
                "So speaks the heart of Rwanda.",
                "",
                "- Mwami Rwabugiri",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheThousandHills() : base(false)
        {
            Hue = 2502; // Blue for lakes and peace
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Kingdom of a Thousand Hills");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Kingdom of a Thousand Hills");
        }

        public ChroniclesOfTheThousandHills(Serial serial) : base(serial) { }

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
