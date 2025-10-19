using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfUganda : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfUganda()
        {
            Name = "Treasure Chest of Uganda's Kings";
            Hue = 2213; // Deep, royal purple

            // Decorative and consumable treasures
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Royal Buganda Drum Stool", 1175), 0.20);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Ankole Cattle Carving", 2001), 0.14);
            AddItem(CreateDecorativeItem<ArtifactVase>("Pot of the Nile", 1360), 0.10);
            AddItem(CreateDecorativeItem<FancyHornOfPlenty>("Ivory Horn of the Kingdom", 2941), 0.13);
            AddItem(CreateDecorativeItem<QuagmireZooStatuette>("Crested Crane Figurine", 2407), 0.15);
            AddItem(CreateDecorativeItem<Basket3WestArtifact>("Basket of Matoke", 1701), 0.13);
            AddItem(CreateDecorativeItem<TribalMask>("Mask of the Spirits", 1405), 0.10);
            AddItem(CreateDecorativeItem<ObsidianSkull>("Skull of the Nile Sorcerer", 1109), 0.08);

            // Consumable/food
            AddItem(CreateNamedItem<BentoBox>("Feast of the Lake Tribes"), 0.10);
            AddItem(CreateNamedItem<GreenTea>("Herbal Infusion of Buganda"), 0.16);
            AddItem(CreateNamedItem<BowlOfRotwormStew>("Bowl of Groundnut Stew"), 0.14);

            // Unique coins
            AddItem(CreateGoldItem("Cowrie Shell Coin"), 0.15);

            // Unique equipment
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.18);

            // The Lore Book
            AddItem(new ChroniclesOfUganda(), 1.0);

            // Some gold
            AddItem(new Gold(Utility.Random(1200, 6800)), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumables and simple named items
        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        // Special gold/currency
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Weapons with flavorful, powerful stats
        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Spear(), new Broadsword(), new Katana(), new Scimitar(), new WarHammer()
            );
            weapon.Name = Utility.RandomList(
                "Spear of the Kabaka",
                "Sword of Mutesa",
                "Blade of the Nile Spirits",
                "Hammer of the Rwenzori Giants"
            );
            weapon.Hue = Utility.RandomList(2001, 1175, 1109, 2941, 2407);
            weapon.Attributes.WeaponDamage = 55;
            weapon.Attributes.BonusHits = 25;
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.CastSpeed = 1;
            weapon.Attributes.AttackChance = 12;
            weapon.Attributes.ReflectPhysical = 15;
            weapon.WeaponAttributes.HitHarm = 18;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Macing, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Armor with unique bonuses
        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateHelm(), new LeatherArms(), new StuddedGorget()
            );
            armor.Name = Utility.RandomList(
                "Barkcloth Armor of the Bunyoro",
                "Crown Helm of Toro",
                "Shoulders of the Lake Kingdom",
                "Spirit Gorget of Ankole"
            );
            armor.Hue = Utility.RandomList(1175, 1109, 2407, 2941);
            armor.BaseArmorRating = Utility.Random(35, 75);
            armor.Attributes.BonusStr = 15;
            armor.Attributes.RegenHits = 6;
            armor.Attributes.RegenStam = 8;
            armor.Attributes.Luck = 50;
            armor.ArmorAttributes.MageArmor = 1;
            armor.AbsorptionAttributes.EaterFire = 10;
            armor.AbsorptionAttributes.EaterCold = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Clothing with cultural and useful bonuses
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Kanzu of Buganda";
            robe.Hue = 2213;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.LowerManaCost = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            robe.SkillBonuses.SetValues(2, SkillName.Healing, 8.0);
            robe.Attributes.Luck = 30;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfUganda(Serial serial) : base(serial) { }

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

    // Lore book
    public class ChroniclesOfUganda : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Pearl of Africa", "Scribe of Buganda",
            new BookPageInfo
            (
                "In the dawn before iron,",
                "the earth rose in gentle",
                "hills, and the lakes held",
                "the moon. Here, the",
                "Kingdoms of Buganda,",
                "Bunyoro, Ankole, and Toro",
                "flourished, their drums",
                "echoing beneath the rains."
            ),
            new BookPageInfo
            (
                "The Nile wandered south,",
                "carrying secrets and",
                "traders, and cattle with",
                "horns like the crescent",
                "moon grazed the vast",
                "grasslands. The kings,",
                "called Kabaka and Omukama,",
                "ruled from reed palaces."
            ),
            new BookPageInfo
            (
                "In the forests, spirits",
                "walked as men, and great",
                "lakes sang with storms.",
                "Drums of barkcloth called",
                "warriors to defend the land.",
                "Sorcerers whispered to",
                "the mountain, and the",
                "Rwenzori hid its snow."
            ),
            new BookPageInfo
            (
                "Yet peace was fragile.",
                "Borders shifted as cattle",
                "were claimed, and kingdoms",
                "rose and fell like storms.",
                "But the people endured—",
                "makers of barkcloth,",
                "keepers of the drum,",
                "dancers beneath the moon."
            ),
            new BookPageInfo
            (
                "When strangers from the",
                "north came with iron,",
                "gunpowder, and distant gods,",
                "the kingdoms changed.",
                "Some kings made pacts;",
                "others fought as lions.",
                "But the soul of Uganda,",
                "the spirit of her lakes,",
                "remained ever strong."
            ),
            new BookPageInfo
            (
                "Know then, seeker, that",
                "within this chest lies the",
                "echo of old kingdoms—",
                "cattle's bell, drumbeat,",
                "moon’s blessing, and the",
                "enduring heart of the",
                "Pearl of Africa."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfUganda() : base(false)
        {
            Hue = 2213; // Royal purple
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Pearl of Africa");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Pearl of Africa");
        }

        public ChroniclesOfUganda(Serial serial) : base(serial) { }

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
