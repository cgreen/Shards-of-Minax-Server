using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGaboneseHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGaboneseHistory()
        {
            Name = "Treasure Chest of Gabonese History";
            Hue = 2125; // Deep forest green

            // Add items to the chest
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Eboga Spirit Crane", 2052), 0.15);
            AddItem(CreateDecorativeItem<AncientDrum>("Bwiti Ritual Drum", 1272), 0.18);
            AddItem(CreateConsumable<GreenTea>("Rainforest Herbal Tea", 1412), 0.20);
            AddItem(CreateDecorativeItem<FancyPainting>("Mask of the Fang People", 2100), 0.18);
            AddItem(CreateUniqueWeapon(), 0.20);
            AddItem(CreateUniqueArmor(), 0.20);
            AddItem(CreateUniqueClothing(), 0.18);
            AddItem(CreateDecorativeItem<StatueSouth>("Okoumé Tree Idol", 2730), 0.17);
            AddItem(CreateGoldItem("French Colonial Francs"), 0.15);
            AddItem(CreateDecorativeItem<GargoyleVase>("Vase of Libreville", 1289), 0.16);
            AddItem(CreateDecorativeItem<WolfStatue>("Spirit of Loango Wolf", 2301), 0.10);
            AddItem(CreateDecorativeItem<FancyCopperSunflower>("Sun of Independence", 1266), 0.14);
            AddItem(CreateConsumable<Banana>("Wild Banana Bunch", 71), 0.22);
            AddItem(CreateUniqueBook(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
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

        // Unique powerful weapon: The Fang Warrior’s Spear
        private Item CreateUniqueWeapon()
        {
            Spear spear = new Spear();
            spear.Name = "Fang Warrior’s Spear";
            spear.Hue = 1281; // Ebony/iron
            spear.WeaponAttributes.HitLeechStam = 30;
            spear.WeaponAttributes.HitPoisonArea = 25;
            spear.WeaponAttributes.HitLowerAttack = 20;
            spear.Attributes.BonusDex = 10;
            spear.Attributes.BonusStam = 15;
            spear.Attributes.AttackChance = 12;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 18.0);
            spear.SkillBonuses.SetValues(1, SkillName.Parry, 7.0);
            spear.Slayer = SlayerName.ReptilianDeath;
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        // Unique powerful armor: Bwiti Ceremonial Chest
        private Item CreateUniqueArmor()
        {
            StuddedChest chest = new StuddedChest();
            chest.Name = "Bwiti Ceremonial Chest";
            chest.Hue = 2113; // Vivid ochre/yellow
            chest.ArmorAttributes.MageArmor = 1;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.LowerManaCost = 8;
            chest.Attributes.RegenHits = 4;
            chest.ArmorAttributes.SelfRepair = 6;
            chest.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Unique powerful clothing: Rainforest Shaman’s Sash
        private Item CreateUniqueClothing()
        {
            BodySash sash = new BodySash();
            sash.Name = "Rainforest Shaman’s Sash";
            sash.Hue = 1277; // Vivid green
            sash.Attributes.Luck = 50;
            sash.Attributes.BonusMana = 10;
            sash.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            sash.SkillBonuses.SetValues(1, SkillName.Healing, 15.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        // Custom Lore Book: “Echoes of the Rainforest: A History of Gabon”
        private Item CreateUniqueBook()
        {
            return new EchoesOfTheRainforest();
        }

        public TreasureChestOfGaboneseHistory(Serial serial) : base(serial) { }

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

    public class EchoesOfTheRainforest : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Echoes of the Rainforest", "Gabonese Elder",
            new BookPageInfo
            (
                "From the lush banks of the",
                "Ogooué River, our story rises.",
                "The peoples of Gabon—Fang,",
                "Mpongwe, Punu, Myene—have",
                "walked the emerald forests for",
                "centuries. Their spirits linger",
                "where the iboga grows, where",
                "the forest drums still echo."
            ),
            new BookPageInfo
            (
                "For thousands of years, the",
                "Fang and their neighbors lived",
                "from the land, weaving tales",
                "of ancestors, spirits, and",
                "animals. The Bwiti faith",
                "emerged, binding music and",
                "vision, roots and sky."
            ),
            new BookPageInfo
            (
                "In the 15th century, strangers",
                "came in ships—Portuguese",
                "sailors first, then traders",
                "seeking ivory and riches.",
                "Colonial shadows fell. By the",
                "1800s, France claimed these",
                "lands. Libreville rose upon the",
                "ruins of ancient villages."
            ),
            new BookPageInfo
            (
                "Independence came in 1960,",
                "bringing hope and pride.",
                "Gabon’s emerald canopy,",
                "rich in oil and rare beasts,",
                "called to the world. Yet the",
                "old ways endure, in song, in",
                "ritual, in the green embrace of",
                "the rainforest."
            ),
            new BookPageInfo
            (
                "Beware, traveler: the spirits",
                "of Gabon sleep lightly. The",
                "iboga root holds dreams and",
                "truth. The drums of the Fang",
                "still thunder beneath the",
                "trees. Treasure what you",
                "find, but honor those who",
                "came before you."
            ),
            new BookPageInfo
            (
                "This chest contains gifts from",
                "the forests, rivers, and hearts",
                "of Gabon. May you carry their",
                "story wherever you roam."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public EchoesOfTheRainforest() : base(false)
        {
            Hue = 2125; // Deep forest green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Echoes of the Rainforest");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Echoes of the Rainforest");
        }

        public EchoesOfTheRainforest(Serial serial) : base(serial) { }

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
