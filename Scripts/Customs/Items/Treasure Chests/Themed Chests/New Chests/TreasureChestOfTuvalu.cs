using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTuvalu : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTuvalu()
        {
            Name = "Treasure Chest of Tuvalu";
            Hue = 2075; // Ocean blue

            // Add themed items
            AddItem(CreateColoredItem<ArtifactLargeVase>("Carved Coconut Vase of Nanumea", 2718), 0.18);
            AddItem(CreateTuvaluPearl(), 0.15);
            AddItem(CreateColoredItem<GreenTeaBasket>("Pulaka Feast Basket", 1575), 0.14);
            AddItem(CreateNamedItem<WolfStatue>("Spirit Guardian of Funafuti"), 0.09);
            AddItem(CreateTuvaluDriftwoodStaff(), 0.10);
            AddItem(CreateNavigatorSandals(), 0.16);
            AddItem(CreateLongSash(), 0.13);
            AddItem(CreateTuvaluanShield(), 0.10);
            AddItem(CreateNavigatorTricorneHat(), 0.13);
            AddItem(CreateColoredItem<RandomFancyPotion>("Pacific Sapphire Flask", 1374), 0.11);
            AddItem(CreateTuvaluNecklace(), 0.16);
            AddItem(new Gold(Utility.Random(800, 3500)), 0.18);
            AddItem(CreateColoredItem<SushiPlatter>("Sashimi of the South Seas", 2100), 0.09);
            AddItem(CreateTuvaluFishSpear(), 0.10);
            AddItem(CreateNavigatorCloak(), 0.16);
            AddItem(new TuvaluHistoryBook(), 1.0);
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Custom unique items

        private Item CreateTuvaluPearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "Tuvalu’s Glimmering Lagoon Pearl";
            pearl.Hue = 1153;
            return pearl;
        }

        private Item CreateTuvaluDriftwoodStaff()
        {
            BladedStaff staff = new BladedStaff();
            staff.Name = "Driftwood Staff of Atoll Spirits";
            staff.Hue = 2718; // Driftwood brown
            staff.MinDamage = Utility.Random(18, 28);
            staff.MaxDamage = Utility.Random(44, 65);
            staff.Attributes.SpellChanneling = 1;
            staff.Attributes.BonusMana = 10;
            staff.Attributes.CastSpeed = 2;
            staff.Attributes.RegenMana = 4;
            staff.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            staff.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            staff.WeaponAttributes.HitLeechMana = 18;
            staff.WeaponAttributes.HitLightning = 15;
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        private Item CreateNavigatorSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Navigator’s Reef Sandals";
            sandals.Hue = 1152;
            sandals.Attributes.Luck = 35;
            sandals.Attributes.BonusDex = 7;
            sandals.Attributes.BonusStam = 10;
            sandals.Attributes.NightSight = 1;
            sandals.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            sandals.SkillBonuses.SetValues(2, SkillName.Fishing, 10.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateLongSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of the Island Chiefs";
            sash.Hue = 1356;
            sash.Attributes.Luck = 25;
            sash.Attributes.BonusHits = 15;
            sash.Attributes.RegenHits = 4;
            sash.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            sash.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateTuvaluanShield()
        {
            MetalShield shield = new MetalShield();
            shield.Name = "Shield of the Coral Atolls";
            shield.Hue = 2109;
            shield.Attributes.DefendChance = 16;
            shield.ArmorAttributes.LowerStatReq = 15;
            shield.Attributes.BonusStr = 10;
            shield.Attributes.ReflectPhysical = 10;
            shield.Attributes.RegenStam = 5;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateNavigatorTricorneHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Captain’s Windward Hat";
            hat.Hue = 1154;
            hat.Attributes.BonusInt = 12;
            hat.Attributes.CastRecovery = 2;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            hat.SkillBonuses.SetValues(2, SkillName.Fishing, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateTuvaluNecklace()
        {
            GoldBracelet necklace = new GoldBracelet();
            necklace.Name = "Necklace of Ocean Songs";
            necklace.Hue = 1363;
            necklace.Attributes.Luck = 50;
            necklace.Attributes.RegenMana = 4;
            necklace.SkillBonuses.SetValues(0, SkillName.Musicianship, 20.0);
            necklace.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(necklace, new XmlLevelItem());
            return necklace;
        }

        private Item CreateTuvaluFishSpear()
        {
            ShortSpear spear = new ShortSpear();
            spear.Name = "Pearl-Barbed Fish Spear";
            spear.Hue = 2101;
            spear.MinDamage = Utility.Random(15, 30);
            spear.MaxDamage = Utility.Random(30, 66);
            spear.Attributes.BonusDex = 14;
            spear.Attributes.WeaponSpeed = 20;
            spear.WeaponAttributes.HitLightning = 15;
            spear.WeaponAttributes.HitLeechStam = 8;
            spear.SkillBonuses.SetValues(0, SkillName.Fishing, 22.0);
            spear.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateNavigatorCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Star Navigation";
            cloak.Hue = 1177;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusMana = 8;
            cloak.Attributes.LowerManaCost = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Cartography, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Fishing, 10.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
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
            map.Name = "Navigational Map of Tuvalu";
            map.Bounds = new Rectangle2D(550, 3100, 250, 300);
            map.NewPin = new Point2D(700, 3250);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTuvalu(Serial serial) : base(serial) { }

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

    // Themed Lore Book: "Islands of Tuvalu: Ocean Between Worlds"
    public class TuvaluHistoryBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Islands of Tuvalu: Ocean Between Worlds", "Te Muaafaga, Atoll Historian",
            new BookPageInfo
            (
                "Long ago, our ancestors sailed",
                "from Samoa, Tonga, and distant",
                "lands. Guided by stars and waves,",
                "they found these atolls—",
                "Nanumea, Nui, Nukufetau, and",
                "others—a web across the sea.",
                "Canoes were our lifeline,",
                "the sky our map."
            ),
            new BookPageInfo
            (
                "We built villages on the sand,",
                "planted pulaka in pits, and",
                "fished the blue lagoons.",
                "Chiefs ruled by custom. Songs",
                "told of storms and spirits.",
                "All things—wind, sea, sky—",
                "were sacred. The islands were",
                "our whole world."
            ),
            new BookPageInfo
            (
                "In 1568, a Spanish ship sailed by,",
                "but the world took little notice.",
                "Centuries passed. In 1892, Britain",
                "claimed us as the Ellice Islands.",
                "Church bells rang beside drums.",
                "War, radio, coins, and stamps",
                "followed. But the sea always",
                "remained king."
            ),
            new BookPageInfo
            (
                "In 1978, we cast off colonial",
                "chains. Tuvalu was born, one of",
                "the smallest nations, yet strong.",
                "Flags flew, and the world’s eyes",
                "turned to these fragile shores.",
                "But the waves still come.",
                "Now, we stand between past",
                "and future—between tides."
            ),
            new BookPageInfo
            (
                "Our people are few. Our land",
                "is narrow as a canoe. But the",
                "spirit of Tuvalu is deep as the",
                "ocean. We remember: the stars",
                "are our ancestors, and the",
                "waves bring new stories.",
                "May this chest honor our",
                "islands, our journey, our hope."
            ),
            new BookPageInfo
            (
                "Whoever finds this, know:",
                "treasure is not gold or pearls,",
                "but the memory of islands",
                "enduring among the waves.",
                "",
                "",
                "",
                "",
                "- Te Muaafaga"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public TuvaluHistoryBook() : base(false)
        {
            Hue = 1152; // Sea blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Islands of Tuvalu: Ocean Between Worlds");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Islands of Tuvalu: Ocean Between Worlds");
        }

        public TuvaluHistoryBook(Serial serial) : base(serial) { }

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
