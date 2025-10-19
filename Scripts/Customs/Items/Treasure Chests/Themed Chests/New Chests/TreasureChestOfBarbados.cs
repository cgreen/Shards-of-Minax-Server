using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBarbados : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBarbados()
        {
            Name = "Treasure Chest of Barbados";
            Hue = 1176; // A blue-gold reminiscent of the Barbados flag

            // Add items to the chest
            AddItem(new PirateCaptainHat(), 0.16);
            AddItem(CreateColoredItem<WoodenBowlOfStew>("Barbadian Spiced Fish Stew", 2101), 0.15);
            AddItem(CreateRumBottle(), 0.18);
            AddItem(CreateColoredItem<Coconut>("Tropical Coconut", 2106), 0.15);
            AddItem(CreateGoldItem("Barbadian Sovereigns"), 0.25);
            AddItem(new BookOfBarbados(), 1.0);
            AddItem(CreateNamedItem<Spyglass>("Navigator's Spyglass"), 0.10);
            AddItem(CreateNamedItem<Sextant>("Old Sea Sextant"), 0.08);
            AddItem(CreateDecorativeItem(), 0.19);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateFood("King Sugar's Delicacy", 2508), 0.12);
            AddItem(CreateShell("Pink Conch Shell", 1230), 0.11);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Island Luck"), 0.12);
            AddItem(CreateGoldItem("Colonial Doubloons"), 0.17);
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
            gold.Amount = Utility.Random(1500, 4000);
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

        private Item CreateDecorativeItem()
        {
            // Use artifact deco items to make it feel "colonial/nautical"
            Item[] decos = new Item[]
            {
                CreateColoredItem<ArtifactLargeVase>("Sugar Planter's Vase", 2107),
                CreateNamedItem<BambooStoolArtifact>("Planter's Bamboo Stool"),
                CreateColoredItem<Painting1WestArtifact>("Painting of a Sugar Mill", 2501),
                CreateNamedItem<MedusaStatue>("Rumrunner's Idol"),
                CreateNamedItem<GoldBricks>("Sugarcane Gold Bars"),
                CreateColoredItem<CrabBushel>("Bushel of Barbados Crabs", 2067)
            };
            return decos[Utility.Random(decos.Length)];
        }

        private Item CreateFood(string name, int hue)
        {
            // Use food and give unique Caribbean style name
            Item[] foods = new Item[]
            {
                CreateColoredItem<Banana>(name, hue),
                CreateColoredItem<FruitPie>(name, hue),
                CreateColoredItem<CheeseWheel>(name, hue)
            };
            return foods[Utility.Random(foods.Length)];
        }

        private Item CreateRumBottle()
        {
            SmallBrownBottle bottle = new SmallBrownBottle();
            bottle.Name = "Bottle of Mount Gay Rum";
            bottle.Hue = 1175;
            // If your server supports it, could add "Drunkenness" effect here.
            return bottle;
        }

        private Item CreateShell(string name, int hue)
        {
            // Use an artifact or existing deco as "seashell"
            return CreateColoredItem<QuagmireZooStatuette>(name, hue);
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Scimitar(), new Katana(), new Dagger()
            );
            weapon.Name = "Pirate's Reaver";
            weapon.Hue = 1230; // Pinkish seashell
            weapon.MaxDamage = Utility.Random(40, 70);
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.Attributes.Luck = 80;
            weapon.Attributes.BonusStam = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Parry, 8.0);
            weapon.WeaponAttributes.SelfRepair = 6;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new LeatherChest(), new PlateHelm(), new LeatherGloves(), new StuddedLegs()
            );
            armor.Name = "Colonial Guard's Plate";
            armor.Hue = 1169; // Brass/gold
            armor.BaseArmorRating = Utility.Random(35, 60);
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.Luck = 50;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Clothing with Caribbean flair
            Item[] clothes = new Item[]
            {
                CreateColoredItem<TricorneHat>("Pirate Captain's Tricorne", 1171),
                CreateColoredItem<Robe>("Blue Sargassum Robe", 1176),
                CreateColoredItem<ShortPants>("Sugar Cane Planter's Breeches", 1153),
                CreateColoredItem<BodySash>("Sash of the Sea", 1175),
                CreateColoredItem<Boots>("Coral Reef Boots", 1167)
            };

            // Add cool mods
            BaseClothing clothing = (BaseClothing)clothes[Utility.Random(clothes.Length)];
            clothing.Attributes.Luck = 40;
            clothing.Attributes.BonusMana = 10;
            clothing.Attributes.NightSight = 1;
            clothing.SkillBonuses.SetValues(0, SkillName.Fishing, 12.0);
            clothing.SkillBonuses.SetValues(1, SkillName.Cooking, 10.0);
            XmlAttach.AttachTo(clothing, new XmlLevelItem());
            return clothing;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Hidden Barbados Grotto";
            map.Bounds = new Rectangle2D(5500, 2000, 400, 400);
            map.NewPin = new Point2D(5600, 2300);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfBarbados(Serial serial) : base(serial) { }

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

    // Example custom wearable
    public class PirateCaptainHat : TricorneHat
    {
        [Constructable]
        public PirateCaptainHat()
        {
            Name = "Pirate Captain's Feathered Tricorne";
            Hue = 1171;
            Attributes.BonusDex = 10;
            Attributes.Luck = 20;
            SkillBonuses.SetValues(0, SkillName.Stealth, 8.0);
            SkillBonuses.SetValues(1, SkillName.Snooping, 8.0);
            XmlAttach.AttachTo(this, new XmlLevelItem());
        }

        public PirateCaptainHat(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    // Lore Book
    public class BookOfBarbados : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Isle of the Flying Fish: The History of Barbados", "Sir Geoffrey Downes",
            new BookPageInfo
            (
                "Barbados, jewel of the",
                "Caribbean Sea. First seen",
                "by Spanish sailors in 1492,",
                "her shores were soon",
                "marked by Englishmen in",
                "1627. They found a land",
                "of lush forests and wild",
                "boars."
            ),
            new BookPageInfo
            (
                "Sugar would make her rich,",
                "and slaves, poor. The cane",
                "fields rolled like green",
                "waves. Ships came from",
                "Africa, men in chains.",
                "The island grew wealthy,",
                "but sorrow haunted the",
                "song of the wind."
            ),
            new BookPageInfo
            (
                "Pirates prowled the blue,",
                "smuggling molasses and rum.",
                "The boldest, Sam Lord,",
                "lit lanterns to lure ships",
                "onto his reefs. Treasure",
                "hidden, legends made.",
                "Rum, gold, and glory."
            ),
            new BookPageInfo
            (
                "The British ruled with",
                "iron and tea. In 1834,",
                "the chains broke. Free",
                "men danced as the sun",
                "rose over the cane fields.",
                "The Union Jack came down",
                "in 1966. Independence—",
                "a new dawn."
            ),
            new BookPageInfo
            (
                "Barbados now sings its",
                "own song. Flying fish leap",
                "in the surf. Crop Over",
                "celebrates sweet harvests.",
                "Waves lap on platinum",
                "sand. The ghosts of",
                "pirates, planters, and",
                "heroes walk at night."
            ),
            new BookPageInfo
            (
                "To all who find this chest:",
                "May fortune favor you.",
                "May the island winds",
                "bless your journey.",
                "",
                "",
                "",
                "- Sir Geoffrey Downes",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfBarbados() : base(false)
        {
            Hue = 1176; // Blue-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Isle of the Flying Fish: The History of Barbados");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Isle of the Flying Fish: The History of Barbados");
        }

        public BookOfBarbados(Serial serial) : base(serial) { }

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
