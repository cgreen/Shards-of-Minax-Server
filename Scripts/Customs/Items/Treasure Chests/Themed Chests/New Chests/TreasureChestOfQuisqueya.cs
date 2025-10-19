using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfQuisqueya : WoodenChest
    {
        [Constructable]
        public TreasureChestOfQuisqueya()
        {
            Name = "Treasure Chest of Quisqueya";
            Hue = 2101; // A lush green, tropical hue

            // Add items to the chest
            AddItem(CreateColoredItem<ArtifactLargeVase>("Taíno Ceremonial Vessel", 2053), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Ciguayo Gold"), 0.15);
            AddItem(CreateNamedItem<MerchantsShotgun>("Pirate's Blunderbuss of Hispaniola"), 0.10);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateColoredItem<CrabBushel>("Fresh Caribbean Crab Bushel", 2212), 0.14);
            AddItem(CreateColoredItem<Cloak>("Cape of the Conquistador", 273), 0.12);
            AddItem(CreateColoredItem<Robe>("Robes of the Chief Cacique", 2019), 0.12);
            AddItem(CreateColoredItem<FeatheredHat>("Carnival Mask of Santo Domingo", 2110), 0.10);
            AddItem(CreateNamedItem<ObsidianSkull>("Taíno Stone Skull"), 0.13);
            AddItem(CreateRum(), 0.11);
            AddItem(CreateColoredItem<BowlOfBlackrockStew>("Sancocho Stew", 2125), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Colonial Splendor"), 0.14);
            AddItem(CreateWeapon(), 0.15);
            AddItem(CreateArmor(), 0.15);
            AddItem(CreateAmulet(), 0.10);
            AddItem(CreateMusicalInstrument(), 0.09);
            AddItem(CreateCustomBook(), 1.0);
            AddItem(new Gold(Utility.Random(1000, 5000)), 0.15);
            AddItem(CreateFruitBasket(), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateRum()
        {
            SmallBrownBottle rum = new SmallBrownBottle();
            rum.Name = "Aged Caribbean Rum";
            rum.Hue = 2107;
            return rum;
        }

        private Item CreateFruitBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Hispaniola Fruits";
            basket.Hue = 68;
            return basket;
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
            map.Name = "Map to the Pirate Bay of Samaná";
            map.Bounds = new Rectangle2D(2000, 2500, 600, 600);
            map.NewPin = new Point2D(2200, 2700);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Scimitar(), new Broadsword(), new Dagger());
            weapon.Name = Utility.RandomList("Cutlass of the Black Corsairs", "Blade of Enriquillo", "Sword of the Caribbean Wind", "Dagger of Hidden Gold");
            weapon.Hue = Utility.RandomMinMax(1100, 2150);
            weapon.MinDamage = Utility.Random(18, 30);
            weapon.MaxDamage = Utility.Random(40, 65);
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.Luck = 75;
            weapon.Attributes.BonusHits = 15;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateHelm(), new PlateLegs(), new PlateGloves());
            armor.Name = Utility.RandomList("Breastplate of Santo Domingo", "Conquistador's Helm", "Pirate's Plate Leggings", "Colonial Gauntlets");
            armor.Hue = Utility.RandomMinMax(2300, 2400);
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.Attributes.BonusHits = 10;
            armor.Attributes.BonusStam = 10;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateAmulet()
        {
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Amulet of Atabey (Taíno Earth Mother)";
            amulet.Hue = 1467;
            amulet.Attributes.BonusMana = 12;
            amulet.Attributes.RegenMana = 2;
            amulet.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            amulet.Attributes.CastRecovery = 2;
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateMusicalInstrument()
        {
            Drums drums = new Drums();
            drums.Name = "Tambora of Merengue";
            drums.Hue = 2015;
            return drums;
        }

        private Item CreateCustomBook()
        {
            return new ChroniclesOfQuisqueya();
        }

        public TreasureChestOfQuisqueya(Serial serial) : base(serial) { }

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

    public class ChroniclesOfQuisqueya : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Quisqueya", "Historian of Hispaniola",
            new BookPageInfo
            (
                "Before the sails of Spain,",
                "Quisqueya was green and free.",
                "Taíno villages danced under",
                "the sun, spirits in the hills,",
                "rivers and ceibas whispering",
                "old secrets. Their gold was",
                "peace, their shield the sea."
            ),
            new BookPageInfo
            (
                "Columbus came on hungry wind.",
                "The world split on a single beach,",
                "cross and sword on fertile land.",
                "Stone towers rose in Santo Domingo,",
                "and Taíno drums beat a new,",
                "sorrowful rhythm. Hope fled to",
                "mountain caves and deep forests."
            ),
            new BookPageInfo
            (
                "Pirates circled the island,",
                "treasure-hungry and wild.",
                "Samaná and Monte Cristi",
                "echoed with gunfire and laughter.",
                "Freedom fighters like Enriquillo",
                "and Anacaona sparked flames",
                "that never died."
            ),
            new BookPageInfo
            (
                "Sugarcane bent in hot fields,",
                "and Africa's children sang",
                "in a tongue the island learned",
                "to call its own. Drums, dance,",
                "and prayers grew roots—",
                "merengue born from struggle,",
                "and laughter from loss."
            ),
            new BookPageInfo
            (
                "Through conquest and rebellion,",
                "Quisqueya endured. The first",
                "free city in the New World,",
                "the proud banners of Duarte,",
                "Mella, and Sánchez rising.",
                "Marching to independence,",
                "rivers of courage running deep."
            ),
            new BookPageInfo
            (
                "Today, palm and mangrove guard",
                "the coasts. Merengue and bachata",
                "echo from every street. Those",
                "who hold this chest hold history:",
                "gold and bone, drum and song,",
                "the heart of a people who",
                "refused to vanish."
            ),
            new BookPageInfo
            (
                "Remember Quisqueya: her",
                "pain, her joy, her endless",
                "beauty. Seek the hidden",
                "gems, but honor the memory",
                "of those who came before.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let no one call this land poor.",
                "Her riches are carved in stone,",
                "sung by waves, and guarded by",
                "the spirits of Cibao and Ozama.",
                "",
                "- The Historian of Hispaniola",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfQuisqueya() : base(false)
        {
            Hue = 2063; // Turquoise blue for Caribbean waters
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Quisqueya");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Quisqueya");
        }

        public ChroniclesOfQuisqueya(Serial serial) : base(serial) { }

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
