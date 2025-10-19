using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheMaldives : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheMaldives()
        {
            Name = "Treasure Chest of the Maldives";
            Hue = 1266; // Tropical blue

            // Add items to the chest
            AddItem(new ChroniclesOfTheAtollKings(), 1.0);
            AddItem(CreateColoredItem<RandomFancyPotion>("Pearl Elixir of the Coral Queen", 1153), 0.25);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateMaldivianCloak(), 0.16);
            AddItem(CreateMaldivianTrident(), 0.18);
            AddItem(CreateDecorativeCoral(), 0.35);
            AddItem(CreateColoredItem<RandomFancyFish>("Glowing Parrotfish", 1370), 0.14);
            AddItem(CreatePearlNecklace(), 0.15);
            AddItem(CreateAncientCoin(), 0.22);
            AddItem(CreateMaldivianSandals(), 0.20);
            AddItem(CreateNamedItem<RandomFancyBakedGoods>("Coconut Sweetbread"), 0.09);
            AddItem(CreateMaldivianCap(), 0.18);
            AddItem(CreateSuncloak(), 0.12);
            AddItem(CreateSpicedTea(), 0.13);
            AddItem(CreateDecorativeShells(), 0.24);
            AddItem(CreateMaldivianRobe(), 0.13);
            AddItem(CreateMaldivianArmor(), 0.16);
            AddItem(CreateGoldenFishingRod(), 0.10);
            AddItem(CreateSpicedRum(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Helper methods for unique items

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

        private Item CreateDecorativeCoral()
        {
            ArtifactLargeVase coral = new ArtifactLargeVase();
            coral.Name = "Branch of Living Coral";
            coral.Hue = 1265;
            return coral;
        }

        private Item CreatePearlNecklace()
        {
            GoldBracelet necklace = new GoldBracelet();
            necklace.Name = "Necklace of the Ocean’s Pearl";
            necklace.Hue = 1150;
            necklace.Attributes.Luck = 50;
            necklace.Attributes.BonusMana = 10;
            necklace.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            necklace.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(necklace, new XmlLevelItem());
            return necklace;
        }

        private Item CreateAncientCoin()
        {
            Gold coin = new Gold();
            coin.Name = "Ancient Maldive Rufiyaa";
            coin.Amount = Utility.RandomMinMax(500, 2500);
            return coin;
        }

        private Item CreateMaldivianSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Atoll Nomad";
            sandals.Hue = 1365;
            sandals.Attributes.Luck = 30;
            sandals.Attributes.BonusDex = 7;
            sandals.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Fishing, 7.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateMaldivianCap()
        {
            SkullCap cap = new SkullCap();
            cap.Name = "Pearl-Dyed Mariner’s Cap";
            cap.Hue = 1153;
            cap.Attributes.BonusInt = 8;
            cap.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            cap.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 6.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateMaldivianCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Coral Cloak of the South Winds";
            cloak.Hue = 1269;
            cloak.Attributes.LowerRegCost = 15;
            cloak.Attributes.SpellDamage = 7;
            cloak.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateSuncloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Suncloak of the Sea-Kings";
            cloak.Hue = 1161; // golden
            cloak.Attributes.RegenHits = 2;
            cloak.Attributes.BonusHits = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateSpicedTea()
        {
            GreenTea tea = new GreenTea();
            tea.Name = "Spiced Maldivian Tea";
            tea.Hue = 2209;
            return tea;
        }

        private Item CreateSpicedRum()
        {
            RandomDrink rum = new RandomDrink();
            rum.Name = "Sailor’s Spiced Rum";
            rum.Hue = 2101;
            return rum;
        }

        private Item CreateDecorativeShells()
        {
            RandomFancyStatue shells = new RandomFancyStatue();
            shells.Name = "Set of Shimmering Shells";
            shells.Hue = 1152;
            return shells;
        }

        private Item CreateMaldivianRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Ancient Navigator";
            robe.Hue = 1154;
            robe.Attributes.LowerManaCost = 10;
            robe.Attributes.LowerRegCost = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Fishing, 10.0);
            robe.Attributes.RegenMana = 2;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMaldivianTrident()
        {
            Pike trident = new Pike();
            trident.Name = "Trident of the Coral Kings";
            trident.Hue = 1152;
            trident.MinDamage = Utility.Random(20, 50);
            trident.MaxDamage = Utility.Random(60, 90);
            trident.WeaponAttributes.HitLightning = 25;
            trident.WeaponAttributes.HitLowerAttack = 15;
            trident.Attributes.BonusStam = 15;
            trident.Attributes.AttackChance = 12;
            trident.SkillBonuses.SetValues(0, SkillName.Fishing, 18.0);
            XmlAttach.AttachTo(trident, new XmlLevelItem());
            return trident;
        }

        private Item CreateGoldenFishingRod()
        {
            FishingPole rod = new FishingPole();
            rod.Name = "Golden Rod of the Sultan";
            rod.Hue = 2213;
            rod.Attributes.Luck = 50;
            rod.SkillBonuses.SetValues(0, SkillName.Fishing, 25.0);
            XmlAttach.AttachTo(rod, new XmlLevelItem());
            return rod;
        }

        private Item CreateMaldivianArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateLegs(), new PlateArms(), new PlateHelm(), new PlateGloves()
            );
            armor.Name = "Breastplate of the Atoll Defender";
            armor.Hue = Utility.RandomList(1150, 1151, 1152, 1153, 1154);
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.Attributes.BonusHits = 10;
            armor.Attributes.RegenHits = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Sunken Temples";
            map.Bounds = new Rectangle2D(3300, 3700, 400, 400);
            map.NewPin = new Point2D(3450, 3850);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheMaldives(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheAtollKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Atoll Kings", "Naladhu Sultana",
            new BookPageInfo
            (
                "In the days when the",
                "sea whispered secrets,",
                "the first of the Atoll",
                "Kings arrived upon",
                "drifting boats, guided",
                "by the starlit sky and",
                "the call of coral reefs."
            ),
            new BookPageInfo
            (
                "They tamed the salt winds",
                "and taught the land to",
                "yield coconuts, spices,",
                "and pearls of rarest hue.",
                "Each island was a jewel,",
                "each lagoon a hidden trove",
                "of ancient wonders."
            ),
            new BookPageInfo
            (
                "Dynasties rose and fell as",
                "the tides, from the house",
                "of Koimala the Wise to",
                "the golden Sultans of",
                "Mulee’aage. Traders sailed",
                "from far Cathay, from Oman,",
                "bearing silk and gold."
            ),
            new BookPageInfo
            (
                "Legends tell of the Sunken",
                "Temples, lost to the sea,",
                "where coral kings slumber.",
                "Pearl divers vanished in",
                "the deep, only to return",
                "with the gift of prophecy,",
                "or not at all."
            ),
            new BookPageInfo
            (
                "When the monsoon raged,",
                "the people trusted in",
                "the Atoll Kings to calm",
                "the waters with prayers",
                "to the sea spirits, and",
                "banish the wrath of storms.",
                "The isles endured."
            ),
            new BookPageInfo
            (
                "Through conquest and peace,",
                "the Maldives became a",
                "haven for all sailors.",
                "Even the dragons of the",
                "deep dare not cross the",
                "Atoll Kings. They slumber,",
                "but their treasures remain."
            ),
            new BookPageInfo
            (
                "To those who find this",
                "chest: you hold the legacy",
                "of the sea. May the spirits",
                "of the atolls grant you",
                "safe harbor, fair winds,",
                "and fortune upon these",
                "coral shores."
            ),
            new BookPageInfo
            (
                "But heed this warning:",
                "the ocean forgets nothing.",
                "What you take from her,",
                "you must someday return.",
                "",
                "",
                "- Naladhu Sultana"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheAtollKings() : base(false)
        {
            Hue = 1153; // Sea blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Atoll Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Atoll Kings");
        }

        public ChroniclesOfTheAtollKings(Serial serial) : base(serial) { }

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
