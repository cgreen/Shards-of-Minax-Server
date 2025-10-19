using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfQatar : WoodenChest
    {
        [Constructable]
        public TreasureChestOfQatar()
        {
            Name = "Treasure Chest of Qatari Legends";
            Hue = 1153; // Sand-gold color

            // Add items to the chest
            AddItem(CreateDecorativePearl(), 0.25);
            AddItem(CreateColoredItem<ArtifactVase>("Ancient Qatari Vase", 1160), 0.18);
            AddItem(CreateNamedItem<Gold>("Sack of Riyals"), 0.17);
            AddItem(CreateColoredItem<IncenseBurner>("Desert Incense Burner", 1165), 0.17);
            AddItem(CreateDecorativeDhow(), 0.09);
            AddItem(CreateQatariFalconStatuette(), 0.14);
            AddItem(CreateConsumableCoffee(), 0.20);
            AddItem(CreateConsumableDates(), 0.22);
            AddItem(CreateColoredItem<BodySash>("Sash of the Emir", 2949), 0.21);
            AddItem(CreateDesertRobe(), 0.19);
            AddItem(CreateFalconersHood(), 0.18);
            AddItem(CreatePearledDagger(), 0.14);
            AddItem(CreateScimitarOfTheSheikh(), 0.13);
            AddItem(CreateOilTycoonsRing(), 0.08);
            AddItem(CreateMap(), 0.07);
            AddItem(new ChroniclesOfQatar(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative/Consumable Creators

        private Item CreateDecorativePearl()
        {
            Ruby pearl = new Ruby();
            pearl.Name = "Pearl of the Arabian Gulf";
            pearl.Hue = 1150; // Pearl white
            return pearl;
        }

        private Item CreateDecorativeDhow()
        {
            AncientShipModelOfTheHMSCape dhow = new AncientShipModelOfTheHMSCape();
            dhow.Name = "Model Dhow of Old Qatar";
            dhow.Hue = 2101;
            return dhow;
        }

        private Item CreateQatariFalconStatuette()
        {
            ChangelingStatue falcon = new ChangelingStatue();
            falcon.Name = "Falcon Statuette of Al Thani";
            falcon.Hue = 1109;
            return falcon;
        }

        private Item CreateConsumableCoffee()
        {
            CoffeeMug coffee = new CoffeeMug();
            coffee.Name = "Qatari Arabian Coffee";
            coffee.Hue = 2412;
            return coffee;
        }

        private Item CreateConsumableDates()
        {
            FruitBasket dates = new FruitBasket();
            dates.Name = "Royal Basket of Dates";
            dates.Hue = 2201;
            return dates;
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
            map.Name = "Map to the Pearl Coast";
            map.Bounds = new Rectangle2D(4400, 1250, 500, 400);
            map.NewPin = new Point2D(4620, 1400);
            map.Protected = true;
            return map;
        }

        // Unique Equipment Creators

        private Item CreateDesertRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Desert Winds";
            robe.Hue = 1153;
            robe.Attributes.Luck = 50;
            robe.Attributes.RegenMana = 6;
            robe.Attributes.RegenStam = 7;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            robe.Attributes.CastSpeed = 1;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateFalconersHood()
        {
            LeatherCap cap = new LeatherCap();
            cap.Name = "Falconer's Hood";
            cap.Hue = 2100;
            cap.BaseArmorRating = 32;
            cap.Attributes.BonusDex = 18;
            cap.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 18.0);
            cap.SkillBonuses.SetValues(1, SkillName.AnimalLore, 15.0);
            cap.SkillBonuses.SetValues(2, SkillName.Archery, 10.0);
            cap.ArmorAttributes.MageArmor = 1;
            cap.Attributes.NightSight = 1;
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreatePearledDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Pearled Dagger of Lusail";
            dagger.Hue = 1150;
            dagger.MinDamage = 25;
            dagger.MaxDamage = 60;
            dagger.Attributes.BonusHits = 15;
            dagger.Attributes.ReflectPhysical = 14;
            dagger.Slayer = SlayerName.Silver;
            dagger.WeaponAttributes.HitMagicArrow = 25;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.WeaponAttributes.SelfRepair = 7;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Poisoning, 7.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateScimitarOfTheSheikh()
        {
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Scimitar of the Sheikh";
            scimitar.Hue = 1170;
            scimitar.MinDamage = 35;
            scimitar.MaxDamage = 75;
            scimitar.Attributes.BonusStr = 10;
            scimitar.Attributes.BonusHits = 20;
            scimitar.WeaponAttributes.HitFireball = 18;
            scimitar.WeaponAttributes.HitHarm = 15;
            scimitar.WeaponAttributes.SelfRepair = 6;
            scimitar.WeaponAttributes.HitLeechHits = 10;
            scimitar.Attributes.AttackChance = 10;
            scimitar.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateOilTycoonsRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Oil Tycoon's Ring";
            ring.Hue = 2415;
            ring.Attributes.BonusInt = 10;
            ring.Attributes.BonusMana = 12;
            ring.Attributes.RegenMana = 8;
            ring.Attributes.Luck = 55;
            ring.Attributes.CastRecovery = 1;
            ring.SkillBonuses.SetValues(0, SkillName.ItemID, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.Mining, 18.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        public TreasureChestOfQatar(Serial serial) : base(serial) { }

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

    public class ChroniclesOfQatar : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Qatari Peninsula", "Hakim al-Thani",
            new BookPageInfo
            (
                "Long before towers of glass,",
                "before black gold and riches,",
                "the land of Qatar was shaped",
                "by desert winds and the sea’s",
                "endless tides. Bedouins crossed",
                "the dunes, and pearl divers",
                "braved the depths in search",
                "of fortune’s gleam."
            ),
            new BookPageInfo
            (
                "For centuries, the tribes",
                "lived by the rhythm of the",
                "desert—falcon on arm, fire",
                "in the camp, tales sung",
                "beneath the stars. Pearls",
                "were the prize, and the",
                "sea the giver and taker",
                "of all."
            ),
            new BookPageInfo
            (
                "When the oil was found,",
                "everything changed. In the",
                "blink of a single generation,",
                "tents gave way to palaces,",
                "and camels to cars. The world",
                "came to Doha, and the desert",
                "learned the taste of power."
            ),
            new BookPageInfo
            (
                "Yet, the soul of Qatar endures:",
                "in the coffee shared with a",
                "guest, the majlis of the elders,",
                "the soaring falcons, the",
                "deep wells, and the memory of",
                "those who shaped the sand.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "If you find this chest,",
                "you hold the treasures",
                "of the old and the new:",
                "pearls of the sea, gold of",
                "the desert, and the story",
                "of a people who rose from",
                "nothing to stand at the",
                "crossroads of the world."
            ),
            new BookPageInfo
            (
                "Honor the past, seek your",
                "own fortune, but never forget:",
                "true wealth lies not in gold,",
                "but in the spirit that survives",
                "every storm. This, the people",
                "of Qatar, have always known.",
                "",
                "- Hakim al-Thani"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfQatar() : base(false)
        {
            Hue = 1153; // Sand-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Qatari Peninsula");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Qatari Peninsula");
        }

        public ChroniclesOfQatar(Serial serial) : base(serial) { }

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
