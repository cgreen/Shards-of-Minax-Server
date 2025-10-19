using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfKoreanHeritage : WoodenChest
    {
        [Constructable]
        public TreasureChestOfKoreanHeritage()
        {
            Name = "Treasure Chest of Korean Heritage";
            Hue = 1165; // A deep jade-like green, classic for Korean celadon

            // Add themed items with drop probabilities
            AddItem(CreateCeladonVase(), 0.16);
            AddItem(CreateHanbokDisplay(), 0.11);
            AddItem(CreateGoryeoRoyalSword(), 0.13);
            AddItem(CreateSillaTigerArmor(), 0.13);
            AddItem(CreateJoseonScholarHat(), 0.15);
            AddItem(CreateDragonJar(), 0.14);
            AddItem(CreateKoreanFeastPlatter(), 0.15);
            AddItem(CreateSojuBottle(), 0.17);
            AddItem(CreateHwarangBow(), 0.13);
            AddItem(CreateSobanTable(), 0.16);
            AddItem(CreateKimchiJar(), 0.18);
            AddItem(CreateGoblinMask(), 0.10);
            AddItem(CreateGoldenTurtleRing(), 0.12);
            AddItem(CreateRoyalFan(), 0.11);
            AddItem(new ChroniclesOfKorea(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7500)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // === DECORATIVE ITEMS ===
        private Item CreateCeladonVase()
        {
            ArtifactVase vase = new ArtifactVase();
            vase.Name = "Goryeo Celadon Vase";
            vase.Hue = 1260; // Pale jade
            return vase;
        }

        private Item CreateHanbokDisplay()
        {
            FancyShirt hanbok = new FancyShirt();
            hanbok.Name = "Traditional Hanbok Display";
            hanbok.Hue = 1170; // Vivid pastel
            hanbok.Movable = false;
            return hanbok;
        }

        private Item CreateDragonJar()
        {
            LargeVase jar = new LargeVase();
            jar.Name = "Joseon Dragon Jar";
            jar.Hue = 1153; // White porcelain with blue
            return jar;
        }

        private Item CreateSobanTable()
        {
            WoodenBench table = new WoodenBench();
            table.Name = "Antique Soban Table";
            table.Hue = 1819;
            return table;
        }

        private Item CreateKimchiJar()
        {
            LargeEmptyPot jar = new LargeEmptyPot();
            jar.Name = "Earthenware Kimchi Jar";
            jar.Hue = 1847;
            return jar;
        }

        private Item CreateRoyalFan()
        {
            FanWestArtifact fan = new FanWestArtifact();
            fan.Name = "Royal Silk Fan";
            fan.Hue = 1109;
            return fan;
        }

        // === EQUIPMENT ===

        private Item CreateGoryeoRoyalSword()
        {
            Katana sword = new Katana();
            sword.Name = "Goryeo Royal Sword";
            sword.Hue = 1150;
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.CastSpeed = 2;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.Luck = 75;
            sword.WeaponAttributes.HitLeechHits = 25;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateHwarangBow()
        {
            CompositeBow bow = new CompositeBow();
            bow.Name = "Hwarang Spirit Bow";
            bow.Hue = 2052;
            bow.Attributes.WeaponSpeed = 25;
            bow.Attributes.BonusDex = 10;
            bow.Attributes.AttackChance = 20;
            bow.WeaponAttributes.HitFireball = 20;
            bow.SkillBonuses.SetValues(0, SkillName.Archery, 15.0);
            XmlAttach.AttachTo(bow, new XmlLevelItem());
            return bow;
        }

        private Item CreateSillaTigerArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Silla Tiger Armor";
            chest.Hue = 1266;
            chest.BaseArmorRating = 45;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.DefendChance = 20;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateJoseonScholarHat()
        {
            Kasa scholarHat = new Kasa();
            scholarHat.Name = "Joseon Scholar's Hat";
            scholarHat.Hue = 1899;
            scholarHat.Attributes.BonusInt = 15;
            scholarHat.Attributes.SpellDamage = 10;
            scholarHat.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            scholarHat.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(scholarHat, new XmlLevelItem());
            return scholarHat;
        }

        private Item CreateGoblinMask()
        {
            DeerMask mask = new DeerMask();
            mask.Name = "Talchum Goblin Mask";
            mask.Hue = 1157;
            mask.Attributes.BonusDex = 8;
            mask.Attributes.NightSight = 1;
            mask.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            return mask;
        }

        private Item CreateGoldenTurtleRing()
        {
            GoldBracelet ring = new GoldBracelet();
            ring.Name = "Golden Turtle Ring";
            ring.Hue = 1154;
            ring.Attributes.Luck = 100;
            ring.Attributes.BonusHits = 5;
            ring.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            return ring;
        }

        // === CONSUMABLES ===

        private Item CreateKoreanFeastPlatter()
        {
            FruitBasket feast = new FruitBasket();
            feast.Name = "Korean Feast Platter";
            feast.Hue = 2125;
            return feast;
        }

        private Item CreateSojuBottle()
        {
            GreenBottle soju = new GreenBottle();
            soju.Name = "Bottle of Soju";
            soju.Hue = 1167;
            return soju;
        }

        // === LORE BOOK ===

        public class ChroniclesOfKorea : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Korea", "Hwajae, Court Scribe",
                new BookPageInfo
                (
                    "Long ago, in the dawn",
                    "of time, the sun rose",
                    "over the peninsula of",
                    "morning calm. Ancient",
                    "Gojoseon, founded by",
                    "Dangun, laid the first",
                    "stones of Korea's",
                    "enduring story."
                ),
                new BookPageInfo
                (
                    "From the shaman-kings",
                    "of Gojoseon, to the",
                    "iron-willed queens of",
                    "Silla, courage and unity",
                    "forged three kingdoms:",
                    "Goguryeo, Baekje, Silla.",
                    "Silla’s Golden Age",
                    "brought peace and art."
                ),
                new BookPageInfo
                (
                    "Yet all kingdoms rise,",
                    "and all must fall. The",
                    "Goryeo dynasty followed,",
                    "naming the land ‘Korea’.",
                    "Celadon shone in royal",
                    "courts; scholars penned",
                    "poetry as warriors stood",
                    "against invaders."
                ),
                new BookPageInfo
                (
                    "Joseon’s Confucian order",
                    "bloomed for centuries.",
                    "Hangul, the people's",
                    "alphabet, gave voice to",
                    "every tongue. King Sejong",
                    "lit a torch for learning,",
                    "while poets sang of",
                    "mountains and seas."
                ),
                new BookPageInfo
                (
                    "Through storms of war,",
                    "Mongol raids and samurai",
                    "invasions, the tiger",
                    "spirit endured. In",
                    "modern times, new",
                    "struggles forged unity",
                    "from the ashes of",
                    "division."
                ),
                new BookPageInfo
                (
                    "Today, South Korea",
                    "shines in art and",
                    "technology, but honors",
                    "her ancient roots. Every",
                    "festival, song, and dish",
                    "echoes the voices of",
                    "ancestors. In unity and",
                    "resilience, the story"
                ),
                new BookPageInfo
                (
                    "of Korea lives on.",
                    "The dragon of the east",
                    "rises anew each dawn.",
                    "",
                    "- Hwajae, Scribe",
                    "",
                    "",
                    "",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfKorea() : base(false)
            {
                Hue = 1150;
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Korea");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Korea");
            }

            public ChroniclesOfKorea(Serial serial) : base(serial) { }

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

        // Serialization
        public TreasureChestOfKoreanHeritage(Serial serial) : base(serial) { }
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
}
