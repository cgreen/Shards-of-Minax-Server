using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMesopotamianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMesopotamianLegends()
        {
            Name = "Treasure Chest of Mesopotamian Legends";
            Hue = 1851; // Rich gold-brown, evocative of ancient Mesopotamian earth

            // Decorative artifacts and relics
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Royal Vase of Babylon", 2419), 0.20);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Sacred Flame of Uruk", 1359), 0.12);
            AddItem(CreateDecorativeItem<AncientWeapon1>("Cuneiform Tablet of Destiny", 0), 0.10);
            AddItem(CreateDecorativeItem<ArcaneTable>("Ziggurat Miniature", 2412), 0.10);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Statue of the Lamassu", 1109), 0.14);
            AddItem(CreateDecorativeItem<TarotCardsArtifact>("Enuma Elish Divination Cards", 1150), 0.07);

            // Unique food and consumables
            AddItem(CreateNamedItem<Dates>("Royal Dates of Kish"), 0.15);
            AddItem(CreateNamedItem<BreadLoaf>("Loaf of Sacred Bread"), 0.15);
            AddItem(CreateNamedItem<RandomDrink>("Sumerian Beer Jug"), 0.12);
            AddItem(CreateNamedItem<BentoBox>("Box of Babylonian Spices"), 0.08);

            // Powerful equipment and apparel
            AddItem(CreateEpicWeapon(), 0.18);
            AddItem(CreateEpicArmor(), 0.18);
            AddItem(CreateEpicClothing(), 0.22);

            // Decorative/rare artifacts
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Boat of the Tigris", 1152), 0.07);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Oracle of Ishtar", 1289), 0.13);

            // Lore and maps
            AddItem(new ChroniclesOfTheTwoRivers(), 1.0);
            AddItem(CreateMap(), 0.09);

            // Currency and gems
            AddItem(CreateGoldItem("Shekel of Ur"), 0.25);
            AddItem(CreateColoredItem<Ruby>("Ruby of Babylon", 1357), 0.11);
            AddItem(CreateColoredItem<Diamond>("Lapis Lazuli of the Ziggurat", 1277), 0.13);

            // Bonus loot
            AddItem(CreateEpicAccessory(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
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
            gold.Amount = Utility.Random(100, 3000);
            return gold;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateEpicWeapon()
        {
            // Gilgamesh’s Scepter: a mighty staff with powerful bonuses
            BladedStaff weapon = new BladedStaff();
            weapon.Name = "Scepter of Gilgamesh";
            weapon.Hue = 2418;
            weapon.MinDamage = 30;
            weapon.MaxDamage = 60;
            weapon.Attributes.BonusStr = 15;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.BonusHits = 25;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.SkillBonuses.SetValues(0, SkillName.Macing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateEpicArmor()
        {
            // Hammurabi’s Lawplate: powerful chest with resists and bonuses
            PlateChest chest = new PlateChest();
            chest.Name = "Hammurabi’s Lawplate";
            chest.Hue = 1850;
            chest.BaseArmorRating = 65;
            chest.Attributes.BonusInt = 12;
            chest.Attributes.LowerManaCost = 8;
            chest.ArmorAttributes.SelfRepair = 4;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            chest.ColdBonus = 8;
            chest.EnergyBonus = 10;
            chest.PhysicalBonus = 12;
            chest.FireBonus = 8;
            chest.PoisonBonus = 7;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateEpicClothing()
        {
            // Robes of Nebuchadnezzar: buffs, magic, and charisma
            Robe robe = new Robe();
            robe.Name = "Robe of Nebuchadnezzar";
            robe.Hue = 1167;
            robe.Attributes.BonusMana = 18;
            robe.Attributes.RegenMana = 4;
            robe.Attributes.Luck = 100;
            robe.SkillBonuses.SetValues(0, SkillName.Begging, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateEpicAccessory()
        {
            // The Ring of Sargon
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Sargon the Great";
            ring.Hue = 2474;
            ring.Attributes.BonusDex = 10;
            ring.Attributes.BonusStam = 15;
            ring.Attributes.LowerRegCost = 15;
            ring.Attributes.DefendChance = 10;
            ring.Attributes.SpellDamage = 12;
            ring.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.Swords, 10.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Two Rivers";
            map.Bounds = new Rectangle2D(2500, 3400, 600, 400); // Random example coords
            map.NewPin = new Point2D(2750, 3600);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfMesopotamianLegends(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class ChroniclesOfTheTwoRivers : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Two Rivers", "High Priest of Enki",
            new BookPageInfo
            (
                "In the Land Between Rivers,",
                "where Tigris and Euphrates",
                "kiss the fertile earth, rose",
                "the city-states of old: Ur,",
                "Lagash, Kish, Babylon, Nineveh.",
                "Here men became kings, gods",
                "walked among mortals, and",
                "writing was born in clay."
            ),
            new BookPageInfo
            (
                "From Sumer’s first scribes,",
                "to Hammurabi’s law, to",
                "Assyrian might and Babylon’s",
                "hanging gardens, the land",
                "flourished with learning,",
                "war, and wonder. Here",
                "Gilgamesh sought immortality,",
                "and Ishtar watched from above."
            ),
            new BookPageInfo
            (
                "Empires rose, fell, and",
                "rose again—Akkad, Assur,",
                "Babylon, Baghdad. The words",
                "of poets and priests shaped",
                "destiny as much as the swords",
                "of conquerors. The gods—Enlil,",
                "Marduk, Inanna—demanded",
                "temples, stories, and blood."
            ),
            new BookPageInfo
            (
                "Let these treasures bear",
                "witness: Each coin, a city;",
                "each jewel, a god’s favor;",
                "each tablet, a prayer. Drink",
                "the beer of Ninkasi, read",
                "the code of kings, wear the",
                "regalia of rulers long dust.",
                "Guard what you take."
            ),
            new BookPageInfo
            (
                "For every gift here lies a",
                "curse, as old as Babel’s",
                "tower. Honor the rivers,",
                "and the spirits within.",
                "Disturb not the dead kings,",
                "lest their dreams trouble",
                "your sleep. Remember:",
                "All is writ in clay."
            ),
            new BookPageInfo
            (
                "May the wisdom of the",
                "Two Rivers guide your",
                "journey. May Enki grant",
                "insight, and Ishtar mercy.",
                "Carry these tales beyond",
                "the desert winds. This chest",
                "is a doorway, not an end.",
                "",
                "- Written in Ur, year unknown."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheTwoRivers() : base(false)
        {
            Hue = 1167; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Two Rivers");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Two Rivers");
        }

        public ChroniclesOfTheTwoRivers(Serial serial) : base(serial) { }

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
