using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheGambia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheGambia()
        {
            Name = "Treasure Chest of The Gambia";
            Hue = 2502; // Deep blue for the river

            // Add unique Gambian treasures
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Baobab Vase of Kunta Kinte", 2007), 0.15);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Sacred River Bird Statuette", 273), 0.12);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Mandinka Drum Stool", 1367), 0.13);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Jufureh Library Shelf", 1931), 0.10);
            AddItem(CreateDecorativeItem<SnakeStatue>("Ninki Nanka Idol", 1645), 0.11);

            AddItem(CreateConsumableItem<BowlOfRotwormStew>("Bowl of Benachin (Jollof Rice)", 1167), 0.17);
            AddItem(CreateConsumableItem<GreenTea>("Calabash of Baobab Juice", 1266), 0.20);
            AddItem(CreateConsumableItem<BreadLoaf>("Kanja Bread", 2115), 0.13);

            AddItem(CreateGoldItem("Cowrie Shell Currency"), 0.19);

            // Unique equipment
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.22);

            // Custom lore book
            AddItem(new ChroniclesOfTheRiverGambia(), 1.0);

            // Misc
            AddItem(CreateDecorativeItem<RandomFancyBanner>("Banner of Kunta Kinteh Island", 1157), 0.07);
            AddItem(CreateDecorativeItem<Painting3Artifact>("Painting of the River Gambia", 1160), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.Stackable = true;
            item.Amount = Utility.RandomMinMax(1, 3);
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(200, 1200);
            return gold;
        }

        private Item CreateWeapon()
        {
            // Legendary "Mandinka Warrior's Scimitar"
            Scimitar weapon = new Scimitar();
            weapon.Name = "Mandinka Warrior's Scimitar";
            weapon.Hue = 2101; // Gold-accented blade
            weapon.MinDamage = 32;
            weapon.MaxDamage = 69;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.BonusHits = 35;
            weapon.Attributes.BonusStam = 15;
            weapon.Attributes.WeaponDamage = 35;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Legendary "Jufureh River Plate"
            PlateChest armor = new PlateChest();
            armor.Name = "Jufureh River Plate";
            armor.Hue = 1186; // River blue
            armor.BaseArmorRating = 54;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.RegenHits = 4;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.AbsorptionAttributes.EaterFire = 10;
            armor.EnergyBonus = 10;
            armor.ColdBonus = 8;
            armor.PhysicalBonus = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // "Kora Player's Robe" (Kora = Gambian harp-lute)
            Robe robe = new Robe();
            robe.Name = "Kora Player's Robe";
            robe.Hue = 2717; // Rich indigo
            robe.Attributes.Luck = 30;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Musicianship, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            robe.Attributes.NightSight = 1;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfTheGambia(Serial serial) : base(serial) { }

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

    // ---- LORE BOOK ----

    public class ChroniclesOfTheRiverGambia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the River Gambia", "Alhaji Jali Musa",
            new BookPageInfo
            (
                "In the shadow of the baobab,",
                "where the River Gambia winds,",
                "the Mandinka warriors once",
                "defended their people, and",
                "the griots sang the tales of",
                "Jufureh, of kings and of Kinte.",
                "The river is the bloodline, the",
                "source of all life."
            ),
            new BookPageInfo
            (
                "Long before the ships of foreign",
                "lands appeared, villages prospered,",
                "trading salt and gold by the water.",
                "From Banjul to Janjanbureh,",
                "every village had its story,",
                "and every story, a lesson."
            ),
            new BookPageInfo
            (
                "Then came the age of traders,",
                "of sorrow and chains. The name",
                "of Kunta Kinte endures,",
                "and the songs of suffering have",
                "become the roots of hope.",
                "Through hardship, the spirit of",
                "the river people only grew stronger."
            ),
            new BookPageInfo
            (
                "Today, the river remains,",
                "wide and deep as memory.",
                "Drums still echo in the night,",
                "and the griots remember:",
                "\"No river can forget its source.\"",
                "",
                "To those who find this chest,",
                "honor the story of the Gambia."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheRiverGambia() : base(false)
        {
            Hue = 1170; // River blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the River Gambia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the River Gambia");
        }

        public ChroniclesOfTheRiverGambia(Serial serial) : base(serial) { }

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
