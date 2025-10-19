using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfJordan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfJordan()
        {
            Name = "Treasure Chest of the Rose-Red Land";
            Hue = 2116; // Petra pink-red sandstone

            // Add themed items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Nabataean Water Jar", 2636), 0.25);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Desert Night Firebowl", 1161), 0.17);
            AddItem(CreateDecorativeItem<GoldBricks>("Gold from the King's Highway", 1366), 0.12);
            AddItem(CreateDecorativeItem<IncenseBurner>("Petra's Incense Burner", 1364), 0.17);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Oracle's Crystal of Ammon", 1153), 0.10);
            AddItem(CreateDecorativeItem<GargishLuckTotemArtifact>("Totem of Fortune, Wadi Rum", 2212), 0.14);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Lion of Umm Qais", 2408), 0.13);
            AddItem(CreateDecorativeItem<ZenRock2Artifact>("Stone of the Rift Valley", 2425), 0.09);
            AddItem(CreateDecorativeItem<StretchedHideArtifact>("Bedouin Hide Rug", 2422), 0.20);
            AddItem(CreateConsumableItem<GreenTea>("Mint Tea of Madaba", 2118), 0.18);
            AddItem(CreateConsumableItem<Dates>("Royal Medjool Dates", 2732), 0.21);
            AddItem(CreateConsumableItem<SackOfSugar>("Dead Sea Salt Pouch", 1152), 0.18);
            AddItem(CreateArmorPiece(), 0.21);
            AddItem(CreateClothingPiece(), 0.22);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateUniqueJewelry(), 0.25);
            AddItem(CreateUniqueMap(), 0.07);
            AddItem(CreateUniqueCoin(), 0.18);
            AddItem(new Gold(Utility.RandomMinMax(2000, 6000)), 0.18);
        }

        // Utility for probability
        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative artifacts and food
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }
        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique Jewelry
        private Item CreateUniqueJewelry()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of Petra’s Echo";
            bracelet.Hue = 2636;
            bracelet.Attributes.BonusHits = 15;
            bracelet.Attributes.Luck = 200;
            bracelet.Attributes.BonusDex = 5;
            bracelet.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            bracelet.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        // Unique Coin
        private Item CreateUniqueCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Dinar of the Nabataean Kings";
            gold.Hue = 1366;
            return gold;
        }

        // Custom Map
        private Item CreateUniqueMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Lost City (Petra)";
            map.Bounds = new Rectangle2D(1600, 3300, 700, 700);
            map.NewPin = new Point2D(1950, 3750);
            map.Protected = true;
            return map;
        }

        // Randomized themed weapon
        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Katana(), new Spear(), new Bow(), new MagicWand()
            );
            weapon.Name = Utility.RandomList(
                "Blade of the Desert King",
                "Moabite War Scimitar",
                "Spear of Wadi Rum",
                "Wand of Lot’s Pillar",
                "Bow of Petra’s Watchers"
            );
            weapon.Hue = Utility.RandomMinMax(2114, 2636);
            weapon.MaxDamage = Utility.Random(30, 75);
            weapon.MinDamage = Utility.Random(12, 36);
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.CastSpeed = Utility.Random(1, 2);
            weapon.Attributes.BonusStr = Utility.Random(5, 12);
            weapon.Attributes.BonusHits = Utility.Random(10, 25);
            weapon.Attributes.Luck = Utility.Random(50, 180);
            weapon.SkillBonuses.SetValues(0, SkillName.Parry, Utility.Random(5, 15));
            weapon.WeaponAttributes.HitFireball = Utility.Random(10, 30);
            weapon.WeaponAttributes.HitHarm = Utility.Random(5, 20);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Themed armor piece
        private Item CreateArmorPiece()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateHelm(), new PlateLegs(), new LeatherGorget()
            );
            armor.Name = Utility.RandomList(
                "Ajloun Defender's Plate",
                "Crusader's Helm of Karak",
                "Desert Nomad’s Leggings",
                "Moabite Leather Gorget"
            );
            armor.Hue = Utility.RandomMinMax(1366, 2116);
            armor.BaseArmorRating = Utility.Random(34, 62);
            armor.Attributes.BonusHits = Utility.Random(10, 25);
            armor.Attributes.LowerManaCost = Utility.Random(2, 10);
            armor.Attributes.NightSight = 1;
            armor.Attributes.Luck = Utility.Random(25, 120);
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, Utility.Random(5, 14));
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, Utility.Random(4, 10));
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Themed clothing piece
        private Item CreateClothingPiece()
        {
            Robe robe = new Robe();
            robe.Name = "Bedouin Traveler’s Robe";
            robe.Hue = Utility.RandomMinMax(1100, 2120);
            robe.Attributes.Luck = 80;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.BonusInt = 6;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 8.0);
            robe.SkillBonuses.SetValues(1, SkillName.Hiding, 11.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Lore Book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheRoseRedLand();
        }

        public TreasureChestOfJordan(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheRoseRedLand : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Rose-Red Land", "Scribe of Petra",
            new BookPageInfo
            (
                "In ancient days, the rose-red",
                "city of Petra stood proud,",
                "carved into stone by Nabataean",
                "hands. Merchants walked the",
                "King’s Highway. Caravan bells",
                "rang in the shadowed Siq. Gold",
                "and frankincense, wisdom and",
                "war, all met beneath desert sky."
            ),
            new BookPageInfo
            (
                "Rome claimed the land, leaving",
                "columns and mosaics. Crusaders",
                "raised castles on rocky heights.",
                "The Bedouin tribes, eternal as",
                "the sands, guarded secret springs",
                "and whispered legends beneath",
                "the stars. Every stone holds a",
                "story; every breeze, a secret."
            ),
            new BookPageInfo
            (
                "In Wadi Rum’s red canyons,",
                "the wind speaks of Lawrence,",
                "rebellion, and freedom. By the",
                "Dead Sea, nothing floats but",
                "memory. In Jerash, chariot wheels",
                "echo through broken marble halls.",
                "In Amman, the ancient citadel",
                "watches new days unfold."
            ),
            new BookPageInfo
            (
                "If you hold this chest,",
                "remember: the heart of Jordan",
                "is not its gold, but its stories.",
                "Guard them, as the desert guards",
                "its secrets. For the Rose-Red",
                "Land endures, timeless as stone,",
                "ever waiting for the curious",
                "and the bold."
            ),
            new BookPageInfo
            (
                "‘Every grain of sand is a",
                "history. Every river, a memory.",
                "May your fortune be found not",
                "just in treasure, but in the",
                "wonder of the journey.’",
                "",
                "- Scribe of Petra",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheRoseRedLand() : base(false)
        {
            Hue = 2636; // Rose-red, Petra hue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Rose-Red Land");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Rose-Red Land");
        }

        public ChroniclesOfTheRoseRedLand(Serial serial) : base(serial) { }

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
