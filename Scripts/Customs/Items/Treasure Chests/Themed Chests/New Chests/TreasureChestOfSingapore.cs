using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSingapore : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSingapore()
        {
            Name = "Treasure Chest of Singapore’s Legacy";
            Hue = 2125; // A regal red, reminiscent of Singapore’s flag

            // Add themed items to the chest
            AddItem(CreateColoredItem<ArtifactLargeVase>("Merlion Vase", 1153), 0.12);
            AddItem(CreateColoredItem<LibraryFriendLantern>("Lantern of Chinatown", 1161), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Raffles' Visionary Bracelet"), 0.15);
            AddItem(CreateNamedItem<SakeArtifact>("Tiger Beer of Prosperity"), 0.18);
            AddItem(CreateNamedItem<ChroniclesOfSingapore>("Chronicles of the Lion City"), 1.0); // The lore book
            AddItem(CreateGoldItem("Straits Settlements Coin"), 0.15);
            AddItem(CreateColoredItem<Sandals>("Sultan’s Regal Sandals", 1266), 0.14);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Annals of Temasek"), 0.10);
            AddItem(CreateNamedItem<RandomFancyFish>("Orchid-Garnished Chilli Crab"), 0.10);
            AddItem(CreateNamedItem<GreenTea>("Cup of Kaya Toast Tea"), 0.18);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateClothing(), 0.17);
            AddItem(CreateHeadgear(), 0.13);
            AddItem(CreateDagger(), 0.12);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(2500, 9000);
            return gold;
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
            map.Name = "Map of Old Temasek";
            map.Bounds = new Rectangle2D(2000, 1600, 200, 220);
            map.NewPin = new Point2D(2100, 1700);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // A modern weapon with a twist—The Kris of the Lion City!
            BaseWeapon weapon = new Kryss();
            weapon.Name = "Kris of the Lion City";
            weapon.Hue = 1154; // Silver-blue
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.MinDamage = Utility.Random(25, 50);
            weapon.Attributes.BonusHits = 35;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitLeechStam = 12;
            weapon.WeaponAttributes.HitLeechMana = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // “PlateChest” but with a Singaporean flair!
            BaseArmor armor = new PlateChest();
            armor.Name = "Dragon Guard of Sentosa";
            armor.Hue = 2075; // A deep green for Sentosa’s lushness
            armor.BaseArmorRating = Utility.Random(45, 80);
            armor.Attributes.BonusStr = 12;
            armor.Attributes.LowerManaCost = 8;
            armor.Attributes.Luck = 50;
            armor.ColdBonus = 8;
            armor.FireBonus = 10;
            armor.PoisonBonus = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 7.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 7.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Sarong-style pants with modern flavor
            LongPants pants = new LongPants();
            pants.Name = "Peranakan Silk Trousers";
            pants.Hue = Utility.RandomMinMax(1300, 1750); // Vibrant batik hues
            pants.Attributes.BonusMana = 10;
            pants.Attributes.Luck = 30;
            pants.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Tailoring, 8.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateHeadgear()
        {
            // A hat representing the colonial era with unique modifiers
            TricorneHat hat = new TricorneHat();
            hat.Name = "Stamford’s Explorer Hat";
            hat.Hue = 2051; // Elegant white
            hat.Attributes.BonusInt = 15;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Mining, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateDagger()
        {
            // WWII era—“Dagger of Fort Siloso”
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of Fort Siloso";
            dagger.Hue = 1109; // Steel-grey
            dagger.MinDamage = Utility.Random(20, 35);
            dagger.MaxDamage = Utility.Random(50, 75);
            dagger.Attributes.ReflectPhysical = 12;
            dagger.Attributes.BonusDex = 7;
            dagger.WeaponAttributes.HitLightning = 12;
            dagger.WeaponAttributes.SelfRepair = 6;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 12.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        // Lore Book: Chronicles of the Lion City
        public class ChroniclesOfSingapore : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of the Lion City", "Historian of the Straits",
                new BookPageInfo
                (
                    "In the mists of time,",
                    "a humble fishing village",
                    "called Temasek sat where",
                    "mighty ships now sail.",
                    "Here, trade winds met,",
                    "and merchants from lands",
                    "afar mingled on her shores."
                ),
                new BookPageInfo
                (
                    "From Srivijaya to",
                    "Majapahit, empires rose",
                    "and fell, leaving echoes",
                    "in the sand. Legends",
                    "speak of Sang Nila Utama,",
                    "who, upon seeing a lion,",
                    "named this isle Singaporea:"
                ),
                new BookPageInfo
                (
                    "\"Singapura, Lion City.\"",
                    "Centuries passed; storms",
                    "and war came with the tides.",
                    "In 1819, Sir Stamford",
                    "Raffles arrived, a dreamer",
                    "with parchment and plans.",
                    "Colonial hands shaped a new dawn."
                ),
                new BookPageInfo
                (
                    "Port and people flourished.",
                    "Chinese, Malays, Indians,",
                    "Eurasians, and all walks",
                    "of life called this island",
                    "home. Mosques, temples,",
                    "and churches rose beside",
                    "modern towers of glass."
                ),
                new BookPageInfo
                (
                    "World War II brought fire.",
                    "The city endured the darkness",
                    "of occupation, but hope was",
                    "never lost. Out of suffering",
                    "came unity, resolve, and",
                    "the unbreakable will to thrive."
                ),
                new BookPageInfo
                (
                    "Independence came in 1965.",
                    "Singapore, small but fierce,",
                    "became a lion among nations.",
                    "Innovation, discipline, and",
                    "multicultural harmony built",
                    "her into a city of wonders."
                ),
                new BookPageInfo
                (
                    "Today, the Merlion guards",
                    "the bay, gardens bloom in",
                    "the sky, and the world’s",
                    "travellers gather beneath",
                    "her red and white flag.",
                    "From kampongs to skyscrapers,",
                    "her story is one of courage.",
                    "",
                    ""
                ),
                new BookPageInfo
                (
                    "Open this chest, and",
                    "discover the spirit of",
                    "Singapore: a tale of",
                    "resilience, diversity,",
                    "and endless renewal.",
                    "",
                    "- The Historian of the Straits",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfSingapore() : base(false)
            {
                Hue = 2125; // Same as the chest
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of the Lion City");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of the Lion City");
            }

            public ChroniclesOfSingapore(Serial serial) : base(serial) { }

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

        public TreasureChestOfSingapore(Serial serial) : base(serial)
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
}
