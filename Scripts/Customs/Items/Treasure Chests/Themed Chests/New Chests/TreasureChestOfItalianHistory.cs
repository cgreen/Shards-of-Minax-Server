using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfItalianHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfItalianHistory()
        {
            Name = "Treasure Chest of Italian History";
            Hue = 2017; // Classic marble-white

            // Decorative & Artifact Items
            AddItem(CreateNamedItem<ArtifactVase>("Ancient Roman Amphora", 2401), 0.18);
            AddItem(CreateNamedItem<Painting3Artifact>("Da Vinci’s Lost Sketch", 1153), 0.12);
            AddItem(CreateNamedItem<CupOfSlime>("Chalice of the Medici", 1175), 0.15);
            AddItem(CreateNamedItem<DecorativeShield2>("Shield of the Venetian Guard", 2213), 0.14);
            AddItem(CreateNamedItem<RandomFancyCoin>("Roman Denarius", 2401), 0.18);
            AddItem(CreateNamedItem<PileOfChains>("Chains of Saint Peter", 2500), 0.08);
            AddItem(CreateNamedItem<StatueSouth>("Miniature Colosseum", 2018), 0.10);
            AddItem(CreateNamedItem<DecoFullJar>("Jar of Sicilian Olive Oil", 1422), 0.12);
            AddItem(CreateNamedItem<RedHangingLantern>("Venetian Carnival Lantern", 1358), 0.09);

            // Themed Consumables
            AddItem(CreateFood("Loaf of Roman Bread", typeof(BreadLoaf), 2101), 0.18);
            AddItem(CreateFood("Bottle of Chianti Wine", typeof(RandomDrink), 1177), 0.15);
            AddItem(CreateFood("Tuscan Olive Oil Flask", typeof(SmallGreenBottle2), 1422), 0.12);
            AddItem(CreateFood("Cup of Espresso", typeof(CoffeeMug), 1109), 0.10);
            AddItem(CreateFood("Neapolitan Pizza Slice", typeof(CheesePizza), 1161), 0.13);

            // Equipment
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateClothing(), 0.21);

            // Currency
            AddItem(CreateGoldItem("Florin Gold Coin"), 0.22);

            // Custom Book of Lore
            AddItem(new CodexItalia());

            // Gold (just for fun)
            AddItem(new Gold(Utility.Random(2500, 5000)), 0.22);

            // Decorative maps
            AddItem(CreateMap(), 0.07);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Helper to make colored, named items
        private Item CreateNamedItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateFood(string name, Type type, int hue)
        {
            Item food = Activator.CreateInstance(type) as Item;
            if (food != null)
            {
                food.Name = name;
                food.Hue = hue;
            }
            return food;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Italia";
            map.Bounds = new Rectangle2D(2000, 1000, 800, 800);
            map.NewPin = new Point2D(2400, 1600);
            map.Protected = true;
            return map;
        }

        // Legendary Weapon: Gladius of Rome
        private Item CreateWeapon()
        {
            Longsword gladius = new Longsword();
            gladius.Name = "Gladius of the Legions";
            gladius.Hue = 2213;
            gladius.MaxDamage = Utility.Random(45, 70);
            gladius.MinDamage = Utility.Random(25, 45);
            gladius.Attributes.BonusStr = 10;
            gladius.Attributes.WeaponSpeed = 20;
            gladius.Attributes.BonusHits = 20;
            gladius.WeaponAttributes.HitFireball = 25;
            gladius.WeaponAttributes.HitLowerAttack = 15;
            gladius.WeaponAttributes.HitLeechHits = 10;
            gladius.WeaponAttributes.SelfRepair = 6;
            gladius.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            gladius.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            gladius.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(gladius, new XmlLevelItem());
            return gladius;
        }

        // Legendary Armor: Milanese Plate
        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Milanese Plate of the Renaissance";
            chest.Hue = 2017;
            chest.BaseArmorRating = 62;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.BonusStr = 10;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.ArmorAttributes.SelfRepair = 7;
            chest.AbsorptionAttributes.EaterFire = 12;
            chest.AbsorptionAttributes.EaterCold = 8;
            chest.SkillBonuses.SetValues(0, SkillName.Chivalry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            chest.FireBonus = 10;
            chest.EnergyBonus = 7;
            chest.PhysicalBonus = 17;
            chest.PoisonBonus = 6;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Legendary Clothing: Venetian Silk Tunic
        private Item CreateClothing()
        {
            Tunic tunic = new Tunic();
            tunic.Name = "Venetian Silk Tunic";
            tunic.Hue = 1153;
            tunic.Attributes.Luck = 30;
            tunic.Attributes.BonusMana = 10;
            tunic.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            tunic.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(tunic, new XmlLevelItem());
            return tunic;
        }

        public TreasureChestOfItalianHistory(Serial serial) : base(serial) { }

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

    // LORE BOOK: Codex Italia
    public class CodexItalia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Codex Italia", "Archivist di Venezia",
            new BookPageInfo
            (
                "From the birth of Rome on",
                "seven hills, to the splendor",
                "of Florence and the power",
                "of Venice, the soul of",
                "Italia is woven from",
                "many ages. Each artifact",
                "in this chest tells a",
                "story of glory and genius."
            ),
            new BookPageInfo
            (
                "Roman Legions marched",
                "across continents, shaping",
                "the ancient world with",
                "discipline and ambition.",
                "They built roads, arches,",
                "and cities that still",
                "stand. Their Gladius,",
                "swift and strong, led them."
            ),
            new BookPageInfo
            (
                "In the shadowed streets",
                "of medieval Siena, intrigue",
                "and devotion mingled.",
                "Warriors wore heavy mail,",
                "while poets penned verses",
                "by candlelight. In dark",
                "cathedrals, art and faith",
                "were forged together."
            ),
            new BookPageInfo
            (
                "The Renaissance dawned",
                "in Florence. Genius awoke.",
                "Painters, sculptors, and",
                "inventors—Da Vinci,",
                "Michelangelo, Galileo—",
                "unlocked the secrets of",
                "beauty, science, and the",
                "human soul."
            ),
            new BookPageInfo
            (
                "Venice, city of water",
                "and masked revelry, ruled",
                "the waves. Silk, spices,",
                "and secrets flowed into",
                "her golden heart. The",
                "mask and lantern here",
                "speak of carnival and",
                "mystery."
            ),
            new BookPageInfo
            (
                "Italy’s story continues:",
                "from Garibaldi’s call for",
                "unity, to modern days of",
                "passion, food, art, and",
                "music. Take these treasures,",
                "but remember—Italy is",
                "eternal. Her history lives",
                "in every stone and song."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public CodexItalia() : base(false)
        {
            Hue = 1175; // Golden like old pages
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Codex Italia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Codex Italia");
        }

        public CodexItalia(Serial serial) : base(serial) { }

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
