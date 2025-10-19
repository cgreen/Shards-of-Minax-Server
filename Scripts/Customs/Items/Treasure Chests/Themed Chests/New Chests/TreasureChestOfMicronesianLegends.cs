using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMicronesianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMicronesianLegends()
        {
            Name = "Treasure Chest of Micronesian Legends";
            Hue = 2057; // Ocean blue

            // Add items to the chest
            AddItem(CreateDecorativeCanoe(), 0.18);
            AddItem(CreateNavigatorShell(), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Potion of Pacific Renewal", 1266), 0.13);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Star Maps"), 0.20);
            AddItem(new ChronicleOfTheIslandNavigators(), 1.0);
            AddItem(new Gold(Utility.Random(1000, 4000)), 0.15);
            AddItem(CreateColoredItem<Diamond>("Sacred Lagoon Pearl", 1153), 0.12);
            AddItem(CreateNamedItem<GreaterCurePotion>("Sea Turtle Essence"), 0.09);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateNamedItem<Necklace>("Navigation Talisman of Nan Madol"), 0.16);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Breadfruit Voyager", 1875), 0.14);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Island Whispers"), 0.18);
            AddItem(CreateOceanicWeapon(), 0.22);
            AddItem(CreateNavigatorArmor(), 0.20);
            AddItem(CreateVoyagerRobe(), 0.16);
            AddItem(CreateNavigatorCap(), 0.16);
            AddItem(CreateOceanicDagger(), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeCanoe()
        {
            ArtifactLargeVase canoe = new ArtifactLargeVase();
            canoe.Name = "Carved Canoe of Satawal";
            canoe.Hue = 1109; // Driftwood brown
            return canoe;
        }

        private Item CreateNavigatorShell()
        {
            BowlArtifact shell = new BowlArtifact();
            shell.Name = "Navigator’s Shell Compass";
            shell.Hue = 1150; // Pearl white
            return shell;
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
            map.Name = "Map of Lost Micronesian Atolls";
            map.Bounds = new Rectangle2D(400, 3400, 250, 250);
            map.NewPin = new Point2D(520, 3540);
            map.Protected = true;
            return map;
        }

        private Item CreateOceanicWeapon()
        {
            // A tribal weapon, let's make it a Scythe with custom mods and flavor
            Scythe weapon = new Scythe();
            weapon.Name = "Shark-Tooth War Scythe";
            weapon.Hue = 1157; // Deep blue
            weapon.MinDamage = Utility.Random(30, 50);
            weapon.MaxDamage = Utility.Random(65, 95);
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitLeechHits = 18;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateNavigatorArmor()
        {
            // PlateChest themed to a navigator
            PlateChest chest = new PlateChest();
            chest.Name = "Chestplate of the Star Navigator";
            chest.Hue = 1287; // Star silver
            chest.BaseArmorRating = Utility.Random(40, 65);
            chest.Attributes.BonusDex = 10;
            chest.Attributes.NightSight = 1;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Fishing, 10.0);
            chest.ColdBonus = 8;
            chest.EnergyBonus = 14;
            chest.PhysicalBonus = 14;
            chest.PoisonBonus = 7;
            chest.FireBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateVoyagerRobe()
        {
            // Robe for magical or shamanic flavor
            Robe robe = new Robe();
            robe.Name = "Robe of the Breadfruit Shaman";
            robe.Hue = 2212; // Leaf green
            robe.Attributes.BonusInt = 15;
            robe.Attributes.Luck = 35;
            robe.Attributes.RegenMana = 3;
            robe.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateNavigatorCap()
        {
            FeatheredHat cap = new FeatheredHat();
            cap.Name = "Navigator’s Feathered Cap";
            cap.Hue = 1281; // Sky blue
            cap.Attributes.BonusDex = 7;
            cap.Attributes.NightSight = 1;
            cap.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            cap.SkillBonuses.SetValues(1, SkillName.Tracking, 12.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateOceanicDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Coral Blade of Lelu";
            dagger.Hue = 1167; // Coral pink
            dagger.MinDamage = 18;
            dagger.MaxDamage = 44;
            dagger.Attributes.BonusHits = 15;
            dagger.Attributes.BonusStam = 10;
            dagger.WeaponAttributes.HitFireball = 15;
            dagger.WeaponAttributes.HitPoisonArea = 15;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 18.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfMicronesianLegends(Serial serial) : base(serial) { }

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

    public class ChronicleOfTheIslandNavigators : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Island Navigators", "Old Navigator",
            new BookPageInfo
            (
                "Micronesia, the sea of",
                "islands: For a thousand",
                "years, our canoes have",
                "crossed vast blue deserts.",
                "",
                "We read the stars, the waves,",
                "the flight of birds, the",
                "currents beneath the moon."
            ),
            new BookPageInfo
            (
                "Each island, a world,",
                "each atoll, a story. From",
                "Nan Madol’s lost stones,",
                "to Satawal’s master pilots,",
                "our ancestors charted",
                "paths no map could hold."
            ),
            new BookPageInfo
            (
                "We learned to fish the",
                "reef and hunt the sky.",
                "We built stone cities on",
                "Pohnpei, and shrines on",
                "Yap, where stones walked",
                "as money and legends."
            ),
            new BookPageInfo
            (
                "Strangers came: first",
                "from the East, then the",
                "West. Spanish galleons,",
                "Japanese warlords, German",
                "merchants, American",
                "sailors. We endured,",
                "keeping the songs alive."
            ),
            new BookPageInfo
            (
                "The breadfruit ripens,",
                "the navigator’s shell",
                "whispers secrets. The",
                "constellations change,",
                "but Micronesia remembers.",
                "",
                "The sea is our road.",
                "The stars, our ancestors."
            ),
            new BookPageInfo
            (
                "When you open this chest,",
                "know: you hold the hope",
                "of islanders who dared",
                "to cross the unknown.",
                "",
                "- The Old Navigator"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheIslandNavigators() : base(false)
        {
            Hue = 2057; // Ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Island Navigators");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Island Navigators");
        }

        public ChronicleOfTheIslandNavigators(Serial serial) : base(serial) { }

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
