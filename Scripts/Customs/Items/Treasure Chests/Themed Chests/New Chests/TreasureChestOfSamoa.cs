using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSamoa : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSamoa()
        {
            Name = "Treasure Chest of Samoa";
            Hue = 1365; // Deep Pacific Blue

            // Add items to the chest
            AddItem(CreateKavaBowl(), 0.16);
            AddItem(CreateDecorativeShellNecklace(), 0.20);
            AddItem(CreateColoredItem<FruitBasket>("Samoan Fruit Basket", 1265), 0.15);
            AddItem(CreateNamedItem<WolfStatue>("Tatau Guardian Statuette"), 0.10);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Tui Manu'a"), 0.18);
            AddItem(new ChroniclesOfSamoa(), 1.0);
            AddItem(new Gold(Utility.Random(1, 4500)), 0.18);
            AddItem(CreateColoredItem<Apple>("Breadfruit of Fitiuta", 212), 0.11);
            AddItem(CreateKavaCup(), 0.14);
            AddItem(CreateGoldItem("Samoan Shell Currency"), 0.18);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Wayfinder", 2052), 0.13);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Matai"), 0.11);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateNamedItem<Sextant>("Navigator's Sextant of Samoa"), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Herbal Healing Tonic"), 0.22);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateLavalava(), 0.19);
            AddItem(CreateWarriorCap(), 0.17);
            AddItem(CreateTikiDagger(), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Custom decorative items
        private Item CreateKavaBowl()
        {
            BowlArtifact bowl = new BowlArtifact();
            bowl.Name = "Ceremonial Kava Bowl";
            bowl.Hue = 1109; // Polished wood
            return bowl;
        }

        private Item CreateKavaCup()
        {
            Goblet cup = new Goblet();
            cup.Name = "Cup of Kava";
            cup.Hue = 2101; // Earthenware
            cup.Stackable = false;
            return cup;
        }

        private Item CreateDecorativeShellNecklace()
        {
            Necklace necklace = new Necklace();
            necklace.Name = "Shell Lei of the Chiefs";
            necklace.Hue = 1965;
            return necklace;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
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
            map.Name = "Map of the Manu'a Islands";
            map.Bounds = new Rectangle2D(5200, 900, 250, 300); // (fictional coords)
            map.NewPin = new Point2D(5325, 1050);
            map.Protected = true;
            return map;
        }

        // Custom Equipment
        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Club(), new WarHammer(), new Spear(), new ShortSpear(), new QuarterStaff()
            );
            weapon.Name = "Nifo'Oti of the Tui";
            weapon.Hue = Utility.RandomList(1365, 1359, 1965, 2096); // Ocean/wood/sunset hues
            weapon.MaxDamage = Utility.Random(38, 68);
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.BonusHits = 15;
            weapon.WeaponAttributes.HitLeechStam = 20;
            weapon.WeaponAttributes.HitHarm = 18;
            weapon.WeaponAttributes.HitDispel = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new LeatherChest(), new PlateHelm(), new StuddedArms(), new PlateLegs()
            );
            armor.Name = "Coralplate Armor of Samoa";
            armor.Hue = Utility.RandomList(1359, 1965, 2503); // Coral/reef/bronze
            armor.BaseArmorRating = Utility.Random(33, 60);
            armor.Attributes.BonusStr = 10;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.SelfRepair = 7;
            armor.AbsorptionAttributes.EaterFire = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Fishing, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLavalava()
        {
            Kilt kilt = new Kilt();
            kilt.Name = "Lavalava of the Warrior Chief";
            kilt.Hue = Utility.RandomList(1365, 2052, 1509, 2110); // Sea, green, red, sunset
            kilt.Attributes.Luck = 35;
            kilt.Attributes.BonusStam = 12;
            kilt.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            kilt.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(kilt, new XmlLevelItem());
            return kilt;
        }

        private Item CreateWarriorCap()
        {
            FeatheredHat cap = new FeatheredHat();
            cap.Name = "Taualuga Dancer's Headdress";
            cap.Hue = Utility.RandomList(1965, 1359, 2110, 1509);
            cap.Attributes.BonusDex = 20;
            cap.Attributes.NightSight = 1;
            cap.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            cap.SkillBonuses.SetValues(1, SkillName.Musicianship, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateTikiDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Shark Tooth Tiki Dagger";
            dagger.Hue = Utility.RandomList(2052, 1365, 2110, 1965);
            dagger.MinDamage = Utility.Random(20, 38);
            dagger.MaxDamage = Utility.Random(48, 76);
            dagger.Attributes.BonusDex = 10;
            dagger.WeaponAttributes.HitPoisonArea = 12;
            dagger.WeaponAttributes.HitLightning = 10;
            dagger.Slayer = SlayerName.ReptilianDeath;
            dagger.SkillBonuses.SetValues(0, SkillName.Poisoning, 15.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfSamoa(Serial serial) : base(serial) { }

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

    // Themed Lore Book
    public class ChroniclesOfSamoa : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Samoa: The Islands of Chiefs and Navigators", "High Chief Tagaloa",
            new BookPageInfo
            (
                "Long before memory,",
                "Tagaloa shaped the islands.",
                "He lifted Savai'i from the",
                "deep, cast the coral, raised",
                "Upolu. The gods wove",
                "coconut palms and breadfruit,",
                "and taught the people to",
                "fish and sail the sea."
            ),
            new BookPageInfo
            (
                "Chiefs, or 'Matai', ruled",
                "the villages, their word",
                "carried with shells and",
                "tattooed skin. The tatau",
                "told stories of bravery,",
                "of journeys across salt",
                "roads, and the feasts",
                "beneath banyan trees."
            ),
            new BookPageInfo
            (
                "In ages past, warriors",
                "stood strong at the shore,",
                "fending off raiders and",
                "storm spirits. Canoes cut",
                "the waves to distant isles,",
                "guided by stars, wind, and",
                "the silent song of the sea.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "The Great Kava Ceremony",
                "united chief and villager,",
                "binding all in peace. The",
                "bowl passes from hand to",
                "hand, ancient words echo",
                "on salt air. All are family",
                "under the eye of Tagaloa.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let these treasures remind",
                "you: Samoa endures. The",
                "strength of the chiefs, the",
                "wisdom of navigators, the",
                "beauty of the islands live",
                "on in every wave, every",
                "song, every heart.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May those who open this",
                "chest do so with respect,",
                "for the spirits of Samoa",
                "watch and wait. Malamalama,",
                "the light, will bless or",
                "curse, as you choose.",
                "",
                "- High Chief Tagaloa"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfSamoa() : base(false)
        {
            Hue = 1365; // Deep Pacific Blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Samoa: The Islands of Chiefs and Navigators");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Samoa: The Islands of Chiefs and Navigators");
        }

        public ChroniclesOfSamoa(Serial serial) : base(serial) { }

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
