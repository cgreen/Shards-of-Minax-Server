using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNewZealandHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNewZealandHistory()
        {
            Name = "Treasure Chest of New Zealand History";
            Hue = 2051; // Lush green

            // Add unique themed items to the chest
            AddItem(new MoaFeatherArtifact(), 0.20);
            AddItem(CreateColoredItem<ArtifactLargeVase>("Polynesian Navigators' Vase", 1366), 0.15);
            AddItem(CreateNamedItem<FancyShirt>("Māori Woven Shirt"), 0.18);
            AddItem(CreateColoredItem<Apple>("Enchanted Kiwi Fruit", 1177), 0.23);
            AddItem(new TalesOfAotearoa(), 1.0); // The lore book
            AddItem(CreateMap(), 0.07);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateColoredItem<SilverSteedZooStatuette>("Silver Kiwi Statuette", 2498), 0.13);
            AddItem(CreateColoredItem<BambooStoolArtifact>("Explorer's Camp Stool", 2419), 0.20);
            AddItem(CreateGoldItem("Trade Tokens of Aotearoa"), 0.25);
            AddItem(CreateUniqueConsumable(), 0.20);
            AddItem(CreateColoredItem<OrcMask>("Mask of Kupe", 1109), 0.11);
            AddItem(CreateNamedItem<WoodenBowl>("Poi Bowl"), 0.22);
            AddItem(CreateNamedItem<FlowerGarland>("Cloak of the Tui"), 0.16);
            AddItem(CreateColoredItem<Robe>("Cape of the Long White Cloud", 1150), 0.12);
            AddItem(CreateArmor2(), 0.14);
            AddItem(CreateWeapon2(), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(200, 1800);
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

        // Special consumable, e.g., Hangi Feast
        private Item CreateUniqueConsumable()
        {
            Cake feast = new Cake();
            feast.Name = "Hāngi Feast";
            feast.Hue = 2725;
            feast.Stackable = false;
            feast.Weight = 2.0;
            return feast;
        }

        // Themed Map: Shows legendary Aotearoa locations
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Aotearoa";
            map.Bounds = new Rectangle2D(1800, 2000, 800, 600);
            map.NewPin = new Point2D(2100, 2300);
            map.Protected = true;
            return map;
        }

        // Unique animal feather decorative
        public class MoaFeatherArtifact : Feather
        {
            [Constructable]
            public MoaFeatherArtifact()
            {
                Name = "Giant Moa Feather";
                Hue = 1844;
                Stackable = false;
                Weight = 1.0;
            }

            public MoaFeatherArtifact(Serial serial) : base(serial) { }

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

        // Weapon themed: Taiaha of Kupe (NZ warrior's spear)
        private Item CreateWeapon()
        {
            Bardiche taiaha = new Bardiche();
            taiaha.Name = "Taiaha of Kupe";
            taiaha.Hue = 2051;
            taiaha.Attributes.BonusStam = 15;
            taiaha.Attributes.BonusHits = 10;
            taiaha.Attributes.AttackChance = 10;
            taiaha.WeaponAttributes.HitDispel = 25;
            taiaha.WeaponAttributes.HitLowerAttack = 25;
            taiaha.WeaponAttributes.SelfRepair = 7;
            taiaha.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            taiaha.SkillBonuses.SetValues(1, SkillName.Macing, 10.0);
            XmlAttach.AttachTo(taiaha, new XmlLevelItem());
            return taiaha;
        }

        // Armor themed: Kākahu of the Tohunga (priest's cloak)
        private Item CreateArmor()
        {
            Robe robe = new Robe();
            robe.Name = "Kākahu of the Tohunga";
            robe.Hue = 1376;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.LowerRegCost = 12;
            robe.Attributes.CastSpeed = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Second unique armor: Helm of Maui
        private Item CreateArmor2()
        {
            PlateHelm helm = new PlateHelm();
            helm.Name = "Helm of Māui";
            helm.Hue = 1233;
            helm.BaseArmorRating = 50;
            helm.ArmorAttributes.LowerStatReq = 18;
            helm.Attributes.BonusStr = 7;
            helm.Attributes.RegenHits = 4;
            helm.SkillBonuses.SetValues(0, SkillName.Fishing, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Swords, 8.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        // Second unique weapon: Captain Cook’s Navigational Sword
        private Item CreateWeapon2()
        {
            Longsword sword = new Longsword();
            sword.Name = "Captain Cook’s Navigational Sword";
            sword.Hue = 2101;
            sword.WeaponAttributes.HitLightning = 18;
            sword.WeaponAttributes.HitMagicArrow = 15;
            sword.WeaponAttributes.UseBestSkill = 1;
            sword.Attributes.BonusInt = 7;
            sword.Attributes.BonusDex = 5;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 14.0);
            sword.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        public TreasureChestOfNewZealandHistory(Serial serial) : base(serial) { }

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

    // Unique Lore Book: "Tales of Aotearoa"
    public class TalesOfAotearoa : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Tales of Aotearoa", "Ngā Kōrero o Aotearoa",
            new BookPageInfo(
                "Long ago, great canoes",
                "crossed the vast Pacific,",
                "guided by the stars. Brave",
                "Polynesian navigators first",
                "beheld Aotearoa, the Land",
                "of the Long White Cloud."
            ),
            new BookPageInfo(
                "Here, the Māori people",
                "flourished. Whakapapa—",
                "ancestral lineage—wove",
                "their tribes together.",
                "The forests teemed with",
                "giant moa and huia birds."
            ),
            new BookPageInfo(
                "Centuries passed. The",
                "taniwha guarded rivers,",
                "and legends grew. Then",
                "came sails upon the sea:",
                "Abel Tasman, then James",
                "Cook, explorers seeking new"
            ),
            new BookPageInfo(
                "worlds. Their maps traced",
                "strange shores. New",
                "stories, new peoples,",
                "new hopes—and conflict.",
                "Treaties were made and",
                "broken. The land changed."
            ),
            new BookPageInfo(
                "Now Aotearoa is many",
                "peoples, many voices.",
                "Kiwi ingenuity shapes",
                "the future, yet the spirit",
                "of the land and the stories",
                "of the ancestors remain."
            ),
            new BookPageInfo(
                "Let these treasures of the",
                "chest remind you: from",
                "star voyagers to today's",
                "nation, Aotearoa’s tale",
                "is written by every soul",
                "who calls her home."
            ),
            new BookPageInfo(
                "He aha te mea nui o te ao?",
                "He tangata, he tangata,",
                "he tangata.",
                "What is the most important",
                "thing in the world? It is",
                "the people, the people,",
                "the people.",
                "",
                "Kia ora."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public TalesOfAotearoa() : base(false)
        {
            Hue = 2051; // Fern green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Tales of Aotearoa");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Tales of Aotearoa");
        }

        public TalesOfAotearoa(Serial serial) : base(serial) { }

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
