using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class GrandChestOfLithuanianLegacy : WoodenChest
    {
        [Constructable]
        public GrandChestOfLithuanianLegacy()
        {
            Name = "Grand Chest of Lithuania’s Legacy";
            Hue = 2124; // Deep green, for Lithuania’s forests

            // Add themed items
            AddItem(new BookOfGediminas(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactVase>("Baltic Amber Vase", 1172), 0.25);
            AddItem(CreateDecorativeItem<KingsGildedStatue>("Statue of Vytautas the Great", 241), 0.15);
            AddItem(CreateDecorativeItem<Painting2WestArtifact>("Painting of Vilnius Old Town", 1109), 0.18);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Highlander’s Carved Stool", 2124), 0.17);
            AddItem(CreateDecorativeItem<SilverSteedZooStatuette>("Statuette of the Žemaitukas Horse", 1153), 0.14);
            AddItem(CreateDecorativeItem<IncenseBurner>("Pagan Shrine Incense Burner", 2207), 0.20);
            AddItem(CreateFoodItem<GreenTea>("Baltic Herbal Tea", 1165), 0.12);
            AddItem(CreateFoodItem<BreadLoaf>("Rye Bread of Vilnius", 2017), 0.13);
            AddItem(CreateFoodItem<CheeseWedge>("Zemaitija Farmhouse Cheese", 2012), 0.11);

            // Unique, powerful equipment
            AddItem(CreateLegendarySword(), 0.15);
            AddItem(CreateLegendaryArmor(), 0.15);
            AddItem(CreateGrandCloak(), 0.16);
            AddItem(CreateGrandBoots(), 0.16);

            // Rare coin and special gem
            AddItem(CreateLithuanianCoin(), 0.19);
            AddItem(CreateBalticAmberGem(), 0.19);

            // Consumable: Ancient Mead
            AddItem(CreateFoodItem<RandomDrink>("Ancient Mead of the Gediminids", 0), 0.17);

            // Decorative: Map of the Grand Duchy
            AddItem(CreateMap(), 0.10);

            // Extra gold
            AddItem(new Gold(Utility.Random(1000, 4000)), 0.10);
        }

        // Helper: Adds items with probability
        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative items with name and hue
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Food items with name and optional hue
        private Item CreateFoodItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0) item.Hue = hue;
            return item;
        }

        // Unique coin
        private Item CreateLithuanianCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Ducat of Vytautas";
            return gold;
        }

        // Unique amber gem
        private Item CreateBalticAmberGem()
        {
            Ruby amber = new Ruby();
            amber.Name = "Baltic Amber Gem";
            amber.Hue = 1166; // Amber-orange
            return amber;
        }

        // Decorative map
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Grand Duchy of Lithuania";
            map.Bounds = new Rectangle2D(2200, 1500, 500, 800); // Fictional coords
            map.NewPin = new Point2D(2450, 1900);
            map.Protected = true;
            return map;
        }

        // Legendary Sword: Sword of the Iron Wolf
        private Item CreateLegendarySword()
        {
            Katana sword = new Katana();
            sword.Name = "Sword of the Iron Wolf";
            sword.Hue = 1175;
            sword.MinDamage = 35;
            sword.MaxDamage = 70;
            sword.WeaponAttributes.HitFireball = 25;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.WeaponAttributes.SelfRepair = 6;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusDex = 10;
            sword.Attributes.Luck = 100;
            sword.Attributes.AttackChance = 20;
            sword.Attributes.DefendChance = 20;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.WeaponDamage = 35;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            sword.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Legendary Armor: Armor of the Baltic Crusader
        private Item CreateLegendaryArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of the Baltic Crusader";
            armor.Hue = 1109; // Silver-steel
            armor.BaseArmorRating = 65;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.BonusStam = 15;
            armor.Attributes.NightSight = 1;
            armor.ArmorAttributes.MageArmor = 1;
            armor.AbsorptionAttributes.EaterFire = 15;
            armor.AbsorptionAttributes.EaterCold = 10;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.5);
            armor.SkillBonuses.SetValues(2, SkillName.Healing, 5.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique Cloak
        private Item CreateGrandCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Gediminas’ Dream";
            cloak.Hue = 1153; // Deep red
            cloak.Attributes.Luck = 75;
            cloak.Attributes.RegenMana = 3;
            cloak.Attributes.BonusInt = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Unique Boots
        private Item CreateGrandBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Forest Walkers";
            boots.Hue = 2124; // Green
            boots.Attributes.BonusDex = 12;
            boots.Attributes.RegenStam = 4;
            boots.Attributes.Luck = 45;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public GrandChestOfLithuanianLegacy(Serial serial) : base(serial) { }

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

    // LORE BOOK: “Book of Gediminas”
    public class BookOfGediminas : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Book of Gediminas", "Duke Gediminas",
            new BookPageInfo
            (
                "In the mists of the Baltic,",
                "where the forests whisper,",
                "rose Lithuania. Our land,",
                "where rivers wind and",
                "amber gleams, once knew",
                "no master but sky and",
                "earth. Yet from these",
                "woods, we forged unity."
            ),
            new BookPageInfo
            (
                "The Grand Dukes, from",
                "Mindaugas crowned king,",
                "to Gediminas, dreamer of",
                "Vilnius, led with wisdom.",
                "We welcomed many—Jews,",
                "Ruthenians, Poles—our",
                "strength, diversity. Our",
                "banner held firm."
            ),
            new BookPageInfo
            (
                "Pagans we were, holding",
                "sacred the oak and flame.",
                "Yet, with the Sword",
                "Brothers and Crusaders",
                "at our gates, we turned,",
                "embracing the faith but",
                "never forgetting our roots.",
                "Fire and cross, side by side."
            ),
            new BookPageInfo
            (
                "Our horsemen thundered",
                "across the fields. At",
                "Grunwald, with Polish",
                "allies, we shattered the",
                "Teutonic Knights. Vytautas,",
                "the Great, spread our",
                "borders from Baltic seas",
                "to the Black."
            ),
            new BookPageInfo
            (
                "But glory wanes. Union",
                "with Poland came. Through",
                "storm and partition, our",
                "spirit never died. Songs in",
                "the dark, prayers beneath",
                "the pines. The Iron Wolf",
                "still prowls Vilnius in dream."
            ),
            new BookPageInfo
            (
                "Let this chest be a memory:",
                "Amber, faith, and sword.",
                "Let all who open it",
                "remember Lithuania’s heart.",
                "We are a river; we find",
                "our way.",
                "",
                "- Gediminas"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfGediminas() : base(false)
        {
            Hue = 1153; // Royal red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Book of Gediminas");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Book of Gediminas");
        }

        public BookOfGediminas(Serial serial) : base(serial) { }

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
