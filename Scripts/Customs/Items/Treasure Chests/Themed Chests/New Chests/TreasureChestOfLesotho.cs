using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLesotho : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLesotho()
        {
            Name = "Treasure Chest of Lesotho";
            Hue = 2065; // A sky-blue shade for the "Kingdom in the Sky"

            // Add items to the chest
            AddItem(CreateDecorativeBlanket(), 0.16);
            AddItem(CreateDecorativeHat(), 0.15);
            AddItem(CreateBasothoSpear(), 0.12);
            AddItem(CreateMountainKingCape(), 0.14);
            AddItem(CreateHealerHerbBundle(), 0.17);
            AddItem(CreateNamedItem<GreaterHealPotion>("Mountain Elixir of Endurance"), 0.22);
            AddItem(new ChroniclesOfTheMountainKingdom(), 1.0);
            AddItem(new Gold(Utility.Random(500, 3000)), 0.18);
            AddItem(CreateGoldItem("Basotho Gold Coin"), 0.14);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ceremonial Water Vessel", 1367), 0.11);
            AddItem(CreateDecorativeItem<QuarterStaff>("Staff of the Rainmaker", 1153), 0.15);
            AddItem(CreateBasothoShield(), 0.13);
            AddItem(CreateMountainArmor(), 0.19);
            AddItem(CreateMountainBoots(), 0.21);
            AddItem(CreateMountainRing(), 0.13);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateSongBook(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeBlanket()
        {
            Robe blanket = new Robe();
            blanket.Name = "Basotho Heritage Blanket";
            blanket.Hue = 2101; // Rich blue
            blanket.Attributes.BonusHits = 10;
            blanket.Attributes.LowerRegCost = 8;
            blanket.SkillBonuses.SetValues(0, SkillName.Tailoring, 12.0);
            return blanket;
        }

        private Item CreateDecorativeHat()
        {
            StrawHat hat = new StrawHat();
            hat.Name = "Mokorotlo Woven Hat";
            hat.Hue = 2238; // Tan
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Camping, 15.0);
            return hat;
        }

        private Item CreateBasothoSpear()
        {
            ShortSpear spear = new ShortSpear();
            spear.Name = "Basotho Warrior’s Spear";
            spear.Hue = 1931; // Dark iron
            spear.MinDamage = 25;
            spear.MaxDamage = 58;
            spear.WeaponAttributes.HitFireball = 25;
            spear.Attributes.BonusStr = 12;
            spear.Slayer = SlayerName.ReptilianDeath;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateMountainKingCape()
        {
            Cloak cape = new Cloak();
            cape.Name = "Mountain King’s Cape";
            cape.Hue = 1171; // Royal purple
            cape.Attributes.Luck = 50;
            cape.Attributes.BonusInt = 7;
            cape.Attributes.DefendChance = 10;
            XmlAttach.AttachTo(cape, new XmlLevelItem());
            return cape;
        }

        private Item CreateHealerHerbBundle()
        {
            Bag bag = new Bag();
            bag.Name = "Bundle of Healer’s Mountain Herbs";
            bag.Hue = 1422;
            bag.DropItem(new GreaterCurePotion());
            bag.DropItem(new GreaterHealPotion());
            bag.DropItem(new GreaterStrengthPotion());
            return bag;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateBasothoShield()
        {
            MetalKiteShield shield = new MetalKiteShield();
            shield.Name = "Shield of Thaba Bosiu";
            shield.Hue = 1923;
            shield.Attributes.DefendChance = 13;
            shield.ArmorAttributes.LowerStatReq = 20;
            shield.Attributes.RegenHits = 3;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 17.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateMountainArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm()
            );
            armor.Name = "Armor of the Maloti Ridges";
            armor.Hue = Utility.RandomList(1109, 1307, 1508); // Stone/grey hues
            armor.BaseArmorRating = Utility.Random(45, 72);
            armor.ArmorAttributes.SelfRepair = 5;
            armor.Attributes.BonusStam = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMountainBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Mountain Pass";
            boots.Hue = 1815;
            boots.Attributes.BonusDex = 8;
            boots.Attributes.LowerManaCost = 8;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 14.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateMountainRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Moshoeshoe’s Wisdom";
            ring.Hue = 1172;
            ring.Attributes.BonusInt = 12;
            ring.Attributes.LowerRegCost = 14;
            ring.SkillBonuses.SetValues(0, SkillName.Meditation, 16.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Maloti Highlands";
            map.Bounds = new Rectangle2D(1750, 1100, 500, 400);
            map.NewPin = new Point2D(1925, 1234);
            map.Protected = true;
            return map;
        }

        private Item CreateSongBook()
        {
            SimpleNote note = new SimpleNote();
            note.NoteString = "‘Lesotho Fatše La Bo-Ntat’a Rona’\n\nLand of our Fathers, O beloved country!\nThe hills and rivers, strong and true,\nThrough hardship and through storm,\nThe mountain hearts endure and rise anew.\n— Basotho Anthem";
            note.TitleString = "Song of Lesotho";
            return note;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        public TreasureChestOfLesotho(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheMountainKingdom : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Mountain Kingdom", "King Moshoeshoe I",
            new BookPageInfo
            (
                "In the land where the sky",
                "meets the mountains, the",
                "Basotho have long endured.",
                "Our story is carved in the",
                "cliffs of Thaba Bosiu, our",
                "fortress against the storm.",
                "Here, Moshoeshoe the Great",
                "forged a nation from many."
            ),
            new BookPageInfo
            (
                "Rivers cut the valleys deep,",
                "but the people stand taller",
                "still. From the ashes of",
                "war, unity grew. Zulu,",
                "Boer, Briton—none broke the",
                "mountain spirit. The blanket",
                "became our shield, the",
                "spear our hope."
            ),
            new BookPageInfo
            (
                "The heavens rain hardship,",
                "yet bring life anew. Cattle",
                "are wealth; wisdom, the",
                "true treasure. Moshoeshoe",
                "gathered clans, gave them",
                "peace, and made this",
                "mountain realm a home.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let it be known: Lesotho",
                "is more than stone and",
                "snow. Her heart beats in",
                "every valley, her song",
                "echoes in every cave. The",
                "mountains remember. The",
                "Basotho endure.",
                ""
            ),
            new BookPageInfo
            (
                "He who climbs the heights",
                "with courage, wisdom, and",
                "respect, will always find",
                "refuge here.",
                "",
                "- King Moshoeshoe I",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheMountainKingdom() : base(false)
        {
            Hue = 2065; // Sky-blue for Lesotho
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Mountain Kingdom");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Mountain Kingdom");
        }

        public ChroniclesOfTheMountainKingdom(Serial serial) : base(serial) { }

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
