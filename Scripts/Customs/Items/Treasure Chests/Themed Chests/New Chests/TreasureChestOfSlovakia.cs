using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSlovakia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSlovakia()
        {
            Name = "Treasure Chest of the Slovak Realms";
            Hue = 1266; // A blue from the Slovak flag

            // Add themed loot to the chest
            AddItem(CreateDecorativeItem<ArtifactVase>("Bratislava Castle Miniature", 1109), 0.18);
            AddItem(CreateDecorativeItem<LibraryFriendLantern>("Lantern of the Tatra Spirits", 2101), 0.17);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Moravian Sword Relic", 1157), 0.15);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Krakonoš' Divination Orb", 1161), 0.11);
            AddItem(CreateDecorativeItem<AncientDrum>("Fujara Drum of the Shepherds", 1271), 0.13);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Carved Slovak Stool", 2211), 0.12);
            AddItem(CreateDecorativeItem<OrigamiDragon>("Drak Slovenských Povestí", 1153), 0.11);

            AddItem(CreateUniqueClothing(), 0.22);
            AddItem(CreateUniqueArmor(), 0.20);
            AddItem(CreateUniqueWeapon(), 0.20);

            AddItem(CreateUniqueFood("Bryndzové Halušky Stew", 268), 0.13);
            AddItem(CreateUniqueDrink("Tatranský Čaj Flask", 1191), 0.10);
            AddItem(CreateUniqueDrink("Kofola Bottle", 1102), 0.09);

            AddItem(CreateNamedGold("Ducat of Great Moravia"), 0.14);

            AddItem(new Gold(Utility.Random(2000, 6000)), 0.13);
            AddItem(new LegendsOfSlovakiaBook(), 1.0);

            AddItem(CreateSlovakMap(), 0.08);

            // Extra rare, fun: "Vlkolínec Spirit" statuette
            AddItem(CreateDecorativeItem<SnowLadyStatuette>("Vlkolínec Spirit", 2500), 0.03);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedGold(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateUniqueClothing()
        {
            // "Tatra Shepherd's Wool Cloak"
            Cloak cloak = new Cloak();
            cloak.Name = "Tatra Shepherd's Wool Cloak";
            cloak.Hue = 1153;
            cloak.Attributes.Luck = 75;
            cloak.Attributes.BonusHits = 15;
            cloak.SkillBonuses.SetValues(0, SkillName.Herding, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateUniqueArmor()
        {
            // "Knight's Breastplate of Devín"
            PlateChest chest = new PlateChest();
            chest.Name = "Knight's Breastplate of Devín";
            chest.Hue = 1157;
            chest.BaseArmorRating = Utility.Random(38, 60);
            chest.Attributes.BonusStr = 12;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.ReflectPhysical = 10;
            chest.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            chest.PhysicalBonus = 25;
            chest.FireBonus = 10;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueWeapon()
        {
            // "Slovakian Moravian Blade"
            Longsword sword = new Longsword();
            sword.Name = "Slovakian Moravian Blade";
            sword.Hue = 1109;
            sword.MinDamage = 35;
            sword.MaxDamage = 68;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.WeaponDamage = 30;
            sword.Attributes.BonusStam = 10;
            sword.WeaponAttributes.HitLeechHits = 15;
            sword.WeaponAttributes.HitFireArea = 12;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateUniqueFood(string name, int hue)
        {
            BowlOfRotwormStew stew = new BowlOfRotwormStew();
            stew.Name = name;
            stew.Hue = hue;
            return stew;
        }

        private Item CreateUniqueDrink(string name, int hue)
        {
            BottleArtifact drink = new BottleArtifact();
            drink.Name = name;
            drink.Hue = hue;
            return drink;
        }

        private Item CreateSlovakMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Carpathian Heartlands";
            map.Bounds = new Rectangle2D(2200, 1200, 700, 700);
            map.NewPin = new Point2D(2550, 1450);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSlovakia(Serial serial) : base(serial) { }

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

    public class LegendsOfSlovakiaBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of Slovakia", "Vladislav the Chronicler",
            new BookPageInfo
            (
                "Hear now the tale of the",
                "Slovak lands, where the",
                "Carpathians cradle valleys,",
                "and the rivers Morava, Váh,",
                "and Danube flow with stories",
                "older than memory. These hills",
                "have seen the Great Moravian",
                "Empire rise and fade."
            ),
            new BookPageInfo
            (
                "Upon Devín’s stone ramparts,",
                "kings and princes guarded",
                "the realms from east and west.",
                "The Magyar horsemen thundered,",
                "the Ottoman banners fluttered,",
                "but Slovak resolve stood tall,",
                "a mountain against the storm."
            ),
            new BookPageInfo
            (
                "In the forests, shepherds played",
                "the haunting fujara, calling",
                "to their flocks and spirits.",
                "Legends say dragons slumber",
                "in caves beneath Spiš, and",
                "the Tatras hold the secrets",
                "of ancient giants and lost gold."
            ),
            new BookPageInfo
            (
                "Centuries of kingdoms and",
                "invasions forged a nation",
                "of poets, warriors, and",
                "inventors. Castles crown",
                "the high hills—Trenčín, Bojnice,",
                "Orava—each with its ghost,",
                "its treasure, its legend."
            ),
            new BookPageInfo
            (
                "Slovak hands built with stone,",
                "wove with flax, brewed the",
                "spirit Tatranský Čaj, and",
                "created bryndzové halušky,",
                "food fit for kings and kin.",
                "In every village, stories thrive.",
                "In every heart, pride abides."
            ),
            new BookPageInfo
            (
                "May the finder of this chest",
                "know the spirit of Slovakia:",
                "resilient, clever, welcoming,",
                "but fierce when tested. Carry",
                "these treasures, and remember—",
                "as long as the mountains stand,",
                "so too endures the Slovak soul."
            ),
            new BookPageInfo
            (
                "",
                "",
                "",
                "- Vladislav the Chronicler",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LegendsOfSlovakiaBook() : base(false)
        {
            Hue = 1266; // National blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of Slovakia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of Slovakia");
        }

        public LegendsOfSlovakiaBook(Serial serial) : base(serial) { }

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
