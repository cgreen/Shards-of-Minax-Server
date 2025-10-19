using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNaurusForgottenKings : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNaurusForgottenKings()
        {
            Name = "Treasure Chest of Nauru's Forgotten Kings";
            Hue = 1365; // Phosphate green

            // Add items to the chest
            AddItem(CreatePhosphateCrystal(), 0.25);
            AddItem(CreateColoredItem<GoldBricks>("Gold of the Ocean Kings", 1177), 0.18);
            AddItem(CreateRoyalCrown(), 0.13);
            AddItem(CreateShellArmor(), 0.19);
            AddItem(CreateTribalScepter(), 0.17);
            AddItem(CreateNamedItem<LargeVase>("Ancient Tribal Urn"), 0.22);
            AddItem(CreateColoredItem<RandomFancyBanner>("Banner of the Eamwit Tribe", 1164), 0.22);
            AddItem(CreateDecorativeTuna(), 0.15);
            AddItem(CreateColoredItem<RandomFruitBasket>("Basket of Tropical Fruits", 1426), 0.18);
            AddItem(CreateNamedItem<GreenTea>("Nauruan Seaweed Tea"), 0.09);
            AddItem(CreateColoredItem<BentoBox>("Banaba Island Bento", 1109), 0.13);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateNamedItem<Sextant>("Navigator's Coral Sextant"), 0.10);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateRoyalRobe(), 0.16);
            AddItem(CreateSandals(), 0.13);
            AddItem(new ChroniclesOfTheKingsOfNauru(), 1.0);
            AddItem(new Gold(Utility.Random(1, 5500)), 0.11);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreatePhosphateCrystal()
        {
            Diamond crystal = new Diamond();
            crystal.Name = "Phosphate Crystal of Nauru";
            crystal.Hue = 1365;
            return crystal;
        }

        private Item CreateRoyalCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of the Last King";
            crown.Hue = 1177;
            crown.Attributes.Luck = 88;
            crown.Attributes.BonusHits = 15;
            crown.Attributes.BonusInt = 10;
            crown.SkillBonuses.SetValues(0, SkillName.Meditation, 18.0);
            crown.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            crown.ColdBonus = 7;
            crown.FireBonus = 7;
            crown.EnergyBonus = 7;
            crown.PhysicalBonus = 12;
            crown.PoisonBonus = 7;
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateShellArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Ocean Shell";
            chest.Hue = 1267;
            chest.BaseArmorRating = 44;
            chest.Attributes.DefendChance = 10;
            chest.Attributes.BonusStr = 8;
            chest.Attributes.BonusStam = 12;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            chest.PhysicalBonus = 18;
            chest.ColdBonus = 8;
            chest.FireBonus = 8;
            chest.EnergyBonus = 8;
            chest.PoisonBonus = 8;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateTribalScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Scepter of Chief Aweida";
            scepter.Hue = 2501;
            scepter.MinDamage = 29;
            scepter.MaxDamage = 65;
            scepter.Attributes.CastSpeed = 1;
            scepter.Attributes.CastRecovery = 2;
            scepter.WeaponAttributes.HitLightning = 16;
            scepter.WeaponAttributes.HitHarm = 11;
            scepter.SkillBonuses.SetValues(0, SkillName.Tactics, 14.0);
            scepter.SkillBonuses.SetValues(1, SkillName.Macing, 17.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        private Item CreateDecorativeTuna()
        {
            RandomFancyStatue tuna = new RandomFancyStatue();
            tuna.Name = "Sculpted Tuna of Plenty";
            tuna.Hue = 1160;
            return tuna;
        }

        private Item CreateRoyalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of Nauru's Royalty";
            robe.Hue = 1388;
            robe.Attributes.Luck = 38;
            robe.Attributes.BonusMana = 14;
            robe.SkillBonuses.SetValues(0, SkillName.AnimalLore, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            robe.SkillBonuses.SetValues(2, SkillName.MagicResist, 5.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Lagoon Walkers";
            sandals.Hue = 1369;
            sandals.Attributes.BonusDex = 12;
            sandals.Attributes.NightSight = 1;
            sandals.SkillBonuses.SetValues(0, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Spear(), new QuarterStaff(), new Katana(), new BeggersStick(), new Nunchaku());
            weapon.Name = "King's Coral Weapon";
            weapon.Hue = Utility.RandomList(1172, 1177, 1367, 1267);
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.Attributes.BonusStam = 12;
            weapon.Attributes.BonusHits = 10;
            weapon.WeaponAttributes.HitDispel = 18;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateLegs(), new PlateGloves(), new PlateHelm(), new LeafArms());
            armor.Name = "Raiment of the Oceanic Guardians";
            armor.Hue = Utility.RandomList(1365, 1267, 1177, 1172);
            armor.BaseArmorRating = Utility.Random(25, 55);
            armor.Attributes.RegenHits = 3;
            armor.Attributes.BonusStr = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.Fishing, 13.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Nauru";
            map.Bounds = new Rectangle2D(1600, 2450, 50, 50); // arbitrary
            map.NewPin = new Point2D(1625, 2475);
            map.Protected = true;
            return map;
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

        public TreasureChestOfNaurusForgottenKings(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheKingsOfNauru : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Kings of Nauru", "Historian Denigomodu",
            new BookPageInfo
            (
                "Upon the windswept reef of",
                "the Central Pacific, there",
                "rose a green island: Nauru.",
                "Its people, born of Eamwit",
                "and Eamwid, worshipped the",
                "sea and the spirits within.",
                "",
                "Long before outsiders came,"
            ),
            new BookPageInfo
            (
                "twelve tribes flourished,",
                "each led by a king or chief.",
                "Legends tell of Aweida,",
                "the great King who united",
                "the island, forging peace",
                "and abundance. The kings",
                "guarded secrets in coral",
                "caves and in sacred pools."
            ),
            new BookPageInfo
            (
                "Phosphate, the white gold,",
                "lay hidden beneath palm",
                "roots. It brought fortune,",
                "but also the gaze of distant",
                "empires. Foreign ships came,",
                "bearing trade, guns, and",
                "disease. The line of kings",
                "waned, but stories remain."
            ),
            new BookPageInfo
            (
                "To hold this chest is to",
                "touch the vanished glory",
                "of the island kings: their",
                "treasures, their wisdom,",
                "their warning. Prosperity",
                "is fleeting as the tides.",
                "",
                "Let the stories endure."
            ),
            new BookPageInfo
            (
                "Guard the treasures of",
                "Nauru well, traveler.",
                "",
                "- Denigomodu, Royal Scribe"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheKingsOfNauru() : base(false)
        {
            Hue = 1365; // Phosphate green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Kings of Nauru");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Kings of Nauru");
        }

        public ChroniclesOfTheKingsOfNauru(Serial serial) : base(serial) { }

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
