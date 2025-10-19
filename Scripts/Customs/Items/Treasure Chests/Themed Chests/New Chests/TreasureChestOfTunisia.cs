using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;
using Server.Mobiles;

namespace Server.Items
{
    public class TreasureChestOfTunisia : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfTunisia()
        {
            Name = "Treasure Chest of Tunisia";
            Hue = 2125; // Warm Mediterranean gold

            // Add themed treasures
            AddItem(CreateDecorative<CandelabraOfSouls>("Carthaginian Mask", 1160), 0.15);
            AddItem(CreateDecorative<ArtifactVase>("Desert Mosaic Vase", 2500), 0.20);
            AddItem(CreateDecorative<AncientWeapon2>("Gladius of Roman Africa", 2101), 0.14);
            AddItem(CreateDecorative<FancyCopperSunflower>("Berber Sun Amulet", 2206), 0.18);
            AddItem(CreateDecorative<OrcMask>("Phoenician Painted Mask", 1157), 0.09);
            AddItem(CreateConsumable<Dates>("Bowl of Tunisian Dates", 0), 0.20);
            AddItem(CreateConsumable<RandomFancyMedicine>("Bag of North African Spices", 0), 0.18);
            AddItem(CreateConsumable<ElixirOfTunisia>(), 0.12);

            // Unique, modded gear
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateShield(), 0.17);
            AddItem(CreateTunic(), 0.17);
            AddItem(CreateSandals(), 0.20);
            AddItem(CreateHeadgear(), 0.18);

            // Lore book
            AddItem(new ChroniclesOfTunisia(), 1.0);

            // Gold and other trinkets
            AddItem(new Gold(Utility.Random(1500, 5500)), 0.13);
            AddItem(CreateDecorative<GoldBricks>("Ancient Carthaginian Ingots", 2211), 0.11);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
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

        private Item CreateConsumable<T>() where T : Item, new()
        {
            return new T();
        }

        private Item CreateWeapon()
        {
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Saber of Hannibal";
            scimitar.Hue = 2946;
            scimitar.Attributes.WeaponDamage = 35;
            scimitar.Attributes.BonusStam = 15;
            scimitar.Attributes.BonusStr = 8;
            scimitar.WeaponAttributes.HitFireball = 15;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Berber Shield of the Sahara";
            shield.Hue = 2208;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.BonusHits = 30;
            shield.Attributes.ReflectPhysical = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateTunic()
        {
            Tunic tunic = new Tunic();
            tunic.Name = "Djellaba of the Maghreb";
            tunic.Hue = 1109;
            tunic.Attributes.BonusMana = 15;
            tunic.Attributes.RegenMana = 4;
            tunic.Attributes.LowerManaCost = 12;
            tunic.SkillBonuses.SetValues(0, SkillName.Meditation, 18.0);
            tunic.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(tunic, new XmlLevelItem());
            return tunic;
        }

        private Item CreateSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of Carthage";
            sandals.Hue = 2737;
            sandals.Attributes.Luck = 50;
            sandals.Attributes.BonusDex = 10;
            sandals.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateHeadgear()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Keffiyeh of the Saharan Nomad";
            hat.Hue = 2113;
            hat.Attributes.NightSight = 1;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.RegenHits = 2;
            hat.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Herding, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        // Example unique consumable
		public class ElixirOfTunisia : GreaterHealPotion
		{
			[Constructable]
			public ElixirOfTunisia()
			{
				Name = "Elixir of the Maghreb";
				Hue = 2210;
			}

			public ElixirOfTunisia(Serial serial) : base(serial) { }

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

        public TreasureChestOfTunisia(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTunisia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Tunisia", "Ibn Khaldun",
            new BookPageInfo
            (
                "In the land where the",
                "Mediterranean kisses the",
                "desert, the story of Tunisia",
                "unfolds. From the great city",
                "of Carthage, where Dido",
                "once reigned, to the sands",
                "traveled by Berber kings,",
                "history was forged in sun."
            ),
            new BookPageInfo
            (
                "The Romans came, and their",
                "cities rose: amphitheaters,",
                "temples, mosaics glinting",
                "under the African sky. Then",
                "Byzantium, Vandals, the",
                "march of faith across the",
                "Atlas, the call to prayer in",
                "Kairouan’s halls."
            ),
            new BookPageInfo
            (
                "The olive trees have watched",
                "the centuries roll: Arab",
                "dynasties, Fatimids and",
                "Aghlabids, Ottomans' banners",
                "snapping in the wind, and",
                "ships on the horizon—French",
                "sails, then freedom’s dawn.",
                ""
            ),
            new BookPageInfo
            (
                "Now, in the souks and",
                "medinas, the old ways live:",
                "the taste of harissa, the",
                "sound of oud strings, the",
                "smell of jasmine at dusk.",
                "Tunisia endures, crossroads",
                "of empires, cradle of",
                "stories yet untold."
            ),
            new BookPageInfo
            (
                "Let those who open this chest",
                "remember: its treasures are",
                "woven from the sands and seas,",
                "from battlefields and markets,",
                "from the hearts of poets,",
                "sultans, and dreamers.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May fortune favor the",
                "brave who seek the story",
                "of Tunisia. But know: the",
                "desert keeps its secrets,",
                "and the past is never far.",
                "",
                "",
                "- Ibn Khaldun"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTunisia() : base(false)
        {
            Hue = 2210; // North African blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Tunisia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Tunisia");
        }

        public ChroniclesOfTunisia(Serial serial) : base(serial) { }

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
