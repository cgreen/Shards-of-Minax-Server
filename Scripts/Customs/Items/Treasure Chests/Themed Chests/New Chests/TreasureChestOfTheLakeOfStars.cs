using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheLakeOfStars : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheLakeOfStars()
        {
            Name = "Treasure Chest of the Lake of Stars";
            Hue = 1359; // A watery blue

            // Decorative & Consumable Items
            AddItem(CreateDecorativeMask(), 0.20);
            AddItem(CreateDecorativeDrum(), 0.15);
            AddItem(CreateDecorativeBoat(), 0.10);
            AddItem(CreateColoredItem<RandomFancyPotion>("Potion of the Shire Highlands", 1153), 0.10);
            AddItem(CreateColoredItem<RandomFancyFish>("Chambo of Lake Malawi", 1167), 0.16);
            AddItem(CreateNamedItem<SackFlour>("Bag of Nsima Flour"), 0.14);
            AddItem(CreateNamedItem<BasketOfGreenTeaMug>("Mbewa Herbal Tea"), 0.10);
            AddItem(CreateDecorativeStatue(), 0.12);
            AddItem(CreateNamedItem<Pear>("Sweet Baobab Fruit"), 0.12);
            AddItem(CreateColoredItem<Gold>("Ancient Malawian Kwacha", 1271), 0.18);

            // Unique Equipment
            AddItem(CreateLegendarySpear(), 0.15);
            AddItem(CreateChieftainHelm(), 0.13);
            AddItem(CreateHealerRobe(), 0.12);
            AddItem(CreateLakeSandals(), 0.16);

            // Custom Lore Book
            AddItem(new ChroniclesOfNyasaland(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Gule Wamkulu Ritual Mask";
            mask.Hue = 2125;
            return mask;
        }

        private Item CreateDecorativeDrum()
        {
            Drums drum = new Drums();
            drum.Name = "Ngoma Drum of the Chewa";
            drum.Hue = 2101;
            return drum;
        }

        private Item CreateDecorativeBoat()
        {
            AncientShipModelOfTheHMSCape boat = new AncientShipModelOfTheHMSCape();
            boat.Name = "Fishing Canoe of Lake Malawi";
            boat.Hue = 1359;
            return boat;
        }

        private Item CreateDecorativeStatue()
        {
            SnowStatuePegasus statue = new SnowStatuePegasus();
            statue.Name = "Statue of Nyami Nyami, River Spirit";
            statue.Hue = 2515;
            return statue;
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

        // Unique Equipment

        private Item CreateLegendarySpear()
        {
            Spear spear = new Spear();
            spear.Name = "Spear of Chief Mwase";
            spear.Hue = 2213; // Gold/Bronze
            spear.MinDamage = 30;
            spear.MaxDamage = 55;
            spear.Attributes.BonusStr = 10;
            spear.Attributes.WeaponSpeed = 30;
            spear.Attributes.WeaponDamage = 40;
            spear.WeaponAttributes.HitLeechHits = 20;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            spear.Slayer = SlayerName.ReptilianDeath;
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateChieftainHelm()
        {
            HornedTribalMask helm = new HornedTribalMask();
            helm.Name = "Chieftain's Crown of Mzimba";
            helm.Hue = 2118;
            helm.Attributes.BonusHits = 20;
            helm.Attributes.BonusInt = 5;
            helm.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 15.0);
            helm.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateHealerRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Healer’s Robe of Likoma";
            robe.Hue = 1167;
            robe.Attributes.BonusMana = 25;
            robe.Attributes.RegenMana = 8;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.LowerManaCost = 20;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLakeSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Lake Spirit";
            sandals.Hue = 1153;
            sandals.Attributes.Luck = 60;
            sandals.Attributes.BonusDex = 15;
            sandals.Attributes.NightSight = 1;
            sandals.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Cartography, 15.0); // If Swimming is custom
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        // Custom Lore Book
        public class ChroniclesOfNyasaland : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Nyasaland", "Written by the Lake",
                new BookPageInfo
                (
                    "Long before the world knew",
                    "her name, Malawi's lands",
                    "were walked by the Chewa,",
                    "the Maravi, the Yao and",
                    "the Tumbuka. Their drums,",
                    "their laughter, echoed",
                    "across endless savanna."
                ),
                new BookPageInfo
                (
                    "The great Maravi Kingdom",
                    "arose, its people fishing",
                    "the sparkling waters of",
                    "the Lake of Stars, forging",
                    "iron, and trading salt and",
                    "gold with distant lands.",
                    "",
                    ""
                ),
                new BookPageInfo
                (
                    "Arab traders came from the",
                    "east, Portuguese from the",
                    "sea. In time, new powers",
                    "arrived: first missionaries,",
                    "then the British flag. The",
                    "land was renamed Nyasaland,",
                    "a pawn in empire's game."
                ),
                new BookPageInfo
                (
                    "Yet the people endured.",
                    "The spirits of the lake,",
                    "the voices of ancestors,",
                    "carried hope. In 1964, the",
                    "Malawi sun rose over a free",
                    "nation. The Lion of Malawi,",
                    "Dr. Hastings Banda, became",
                    "her first leader."
                ),
                new BookPageInfo
                (
                    "Today, Malawi is a land of",
                    "smiles and songs, her future",
                    "as bright as dawn over",
                    "Lake Malawi. Her treasures:",
                    "unity, resilience, and the",
                    "promise of the warm heart",
                    "of Africa.",
                    ""
                ),
                new BookPageInfo
                (
                    "May those who find this",
                    "chest remember the journey",
                    "of a proud people—from",
                    "lake, to kingdom, to",
                    "nation. May you carry the",
                    "warmth of Malawi with you,",
                    "wherever you roam.",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfNyasaland() : base(false)
            {
                Hue = 1359; // Lake blue
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Nyasaland");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Nyasaland");
            }

            public ChroniclesOfNyasaland(Serial serial) : base(serial) { }

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

        public TreasureChestOfTheLakeOfStars(Serial serial) : base(serial) { }

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
}
