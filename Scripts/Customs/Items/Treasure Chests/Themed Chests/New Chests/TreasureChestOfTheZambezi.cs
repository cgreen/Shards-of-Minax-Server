using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheZambezi : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheZambezi()
        {
            Name = "Treasure Chest of the Zambezi";
            Hue = 2065; // Deep blue-green for the river

            // Unique Decorative Items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vase of the Great River", 2065), 0.20);
            AddItem(CreateDecorativeItem<SnakeStatue>("Statue of Nyami Nyami", 2735), 0.15); // River god
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Portrait of King Lewanika", 1153), 0.10);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Shelf of Ancient Wisdom", 1840), 0.18);
            AddItem(CreateDecorativeItem<GoldBricks>("Copper Ingots of Zambia", 2120), 0.16);
            AddItem(CreateDecorativeItem<BambooChair>("Throne of the Lozi", 1733), 0.13);
            AddItem(CreateDecorativeItem<FancyWindChimes>("Chimes of the Victoria Falls", 2309), 0.14);
            AddItem(CreateDecorativeItem<WhiteTigerFigurine>("Spirit of the Luangwa", 1150), 0.09);
            AddItem(CreateDecorativeItem<WaterWell>("Well of the Savannah", 2075), 0.16);

            // Consumables and food
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Nsima Bread Loaf", 245), 0.12);
            AddItem(CreateConsumable<GreenTea>("Zambian Rooibos Tea", 1282), 0.15);
            AddItem(CreateConsumable<BottleArtifact>("Maheu Energy Drink", 1181), 0.13);
            AddItem(CreateConsumable<CheeseWedge>("Village Cheese", 1102), 0.09);

            // Unique "Zambian Emerald" gem
            AddItem(CreateGem("Zambian Emerald", 1418), 0.08);

            // Powerful Equipment
            AddItem(CreateWeapon(), 0.24);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateClothing(), 0.21);
            AddItem(CreateShield(), 0.14);

            // Lore Book
            AddItem(new BookOfZambianHistory(), 1.0);

            // Unique Gold/Currency
            AddItem(CreateZambianKwacha(), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGem(string name, int hue)
        {
            Ruby emerald = new Ruby();
            emerald.Name = name;
            emerald.Hue = hue;
            return emerald;
        }

        private Item CreateZambianKwacha()
        {
            Gold gold = new Gold(Utility.Random(1500, 5500));
            gold.Name = "Zambian Kwacha";
            return gold;
        }

        // Powerfully modded equipment

        private Item CreateWeapon()
        {
            // "Spear of the Great Rift" - Powerful tribal spear
            ShortSpear spear = new ShortSpear();
            spear.Name = "Spear of the Great Rift";
            spear.Hue = 2045;
            spear.MinDamage = 42;
            spear.MaxDamage = 85;
            spear.WeaponAttributes.HitFireball = 25;
            spear.WeaponAttributes.HitLightning = 20;
            spear.WeaponAttributes.HitLowerDefend = 18;
            spear.Attributes.BonusStam = 15;
            spear.Attributes.AttackChance = 14;
            spear.Attributes.DefendChance = 10;
            spear.Slayer = SlayerName.ReptilianDeath;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 18.0);
            spear.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateArmor()
        {
            // "Copperplate Chest of Kalambo" - Ancient copper armor with magical properties
            PlateChest chest = new PlateChest();
            chest.Name = "Copperplate Chest of Kalambo";
            chest.Hue = 2412; // coppery color
            chest.BaseArmorRating = 65;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.LowerManaCost = 12;
            chest.Attributes.LowerRegCost = 12;
            chest.ColdBonus = 10;
            chest.FireBonus = 14;
            chest.PoisonBonus = 15;
            chest.PhysicalBonus = 18;
            chest.SkillBonuses.SetValues(0, SkillName.Mining, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 9.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // "Robe of the Victoria Mist" - Mystical blue robe
            Robe robe = new Robe();
            robe.Name = "Robe of the Victoria Mist";
            robe.Hue = 2075;
            robe.Attributes.Luck = 35;
            robe.Attributes.BonusMana = 14;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 17.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateShield()
        {
            // "Mbala Tribal Shield" - Traditional, highly defensive
            WoodenShield shield = new WoodenShield();
            shield.Name = "Mbala Tribal Shield";
            shield.Hue = 2733;
            shield.ArmorAttributes.SelfRepair = 8;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.BonusStr = 8;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 19.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 11.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Lore Book
        public class BookOfZambianHistory : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Zambia", "by The River Scribe",
                new BookPageInfo(
                    "Long before borders,",
                    "the land of Zambia",
                    "was home to ancient",
                    "peoples: the Khoisan,",
                    "the Tonga, the Bemba,",
                    "the Lozi, and more.",
                    "Their kingdoms rose",
                    "along the great rivers."
                ),
                new BookPageInfo(
                    "In the west, the",
                    "Lozi ruled the Barotse",
                    "Floodplains. In the",
                    "north, the Bemba",
                    "built strongholds.",
                    "Copper was mined in",
                    "the soil, traded with",
                    "Arab and Portuguese."
                ),
                new BookPageInfo(
                    "The Zambezi, lifeblood,",
                    "fed Victoria Falls —",
                    "Mosi-oa-Tunya, the",
                    "'Smoke That Thunders.'",
                    "Spirits, legends, and",
                    "the river god Nyami Nyami",
                    "watched over the people.",
                    ""
                ),
                new BookPageInfo(
                    "In the 1800s, explorers",
                    "and missionaries arrived.",
                    "David Livingstone gazed",
                    "upon the Falls and spoke",
                    "of their majesty.",
                    "Colonial rule followed,",
                    "first by the British South",
                    "Africa Company, then the Crown."
                ),
                new BookPageInfo(
                    "Mines grew, cities rose.",
                    "Copper became Zambia’s",
                    "treasure. But the people",
                    "yearned for freedom.",
                    "In 1964, under Kenneth",
                    "Kaunda, Zambia declared",
                    "her independence. A",
                    "new dawn shone bright."
                ),
                new BookPageInfo(
                    "Since then, Zambia",
                    "has been shaped by",
                    "struggle and hope —",
                    "by emerald fields,",
                    "the Great Rift, the",
                    "enduring strength",
                    "of its peoples, and",
                    "the spirit of unity."
                ),
                new BookPageInfo(
                    "May these treasures",
                    "remind you of the",
                    "beauty, resilience,",
                    "and song of Zambia.",
                    "",
                    "- The River Scribe",
                    "",
                    "",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public BookOfZambianHistory() : base(false)
            {
                Hue = 2075; // Deep blue, river color
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Zambia");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Zambia");
            }

            public BookOfZambianHistory(Serial serial) : base(serial) { }

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

        public TreasureChestOfTheZambezi(Serial serial) : base(serial)
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
