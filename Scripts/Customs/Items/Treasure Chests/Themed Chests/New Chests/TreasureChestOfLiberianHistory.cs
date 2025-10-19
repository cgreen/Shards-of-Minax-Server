using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLiberianHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLiberianHistory()
        {
            Name = "Treasure Chest of Liberian History";
            Hue = 2101; // Deep blue - symbolic of the Liberian flag

            // Add themed treasure items
            AddItem(CreateColoredItem<ArtifactVase>("Kpelle Clay Pot of Heritage", 1195), 0.22);
            AddItem(CreateColoredItem<AcademicBooksArtifact>("Founders’ Compendium", 1258), 0.12);
            AddItem(CreateNamedItem<GoldBracelet>("Freedom’s Gold Bracelet"), 0.22);
            AddItem(CreateColoredItem<BottleArtifact>("Elixir of the Pepper Coast", 1372), 0.15);
            AddItem(CreateColoredItem<WolfStatue>("Lion of the Rainforest", 2415), 0.15);
            AddItem(CreateColoredItem<Painting2WestArtifact>("Painting: Arrival of the Mayflower of Liberia", 1153), 0.16);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateGoldItem("Liberian Dollar Coin"), 0.20);
            AddItem(CreateFoodItem(), 0.10);
            AddItem(new ChroniclesOfTheLandOfLiberty(), 1.0);

            // Unique, powerful equipment
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateHat(), 0.13);

            // Extra: symbolic item
            AddItem(CreateColoredItem<RandomFancyBanner>("Flag of Unity", 1153), 0.11); // Imaginary artifact, swap for a fitting deco if needed
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
            gold.Amount = Utility.Random(400, 3500);
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
            map.Name = "Map to Providence Island";
            map.Bounds = new Rectangle2D(1450, 1350, 320, 250);
            map.NewPin = new Point2D(1577, 1462);
            map.Protected = true;
            return map;
        }

        private Item CreateFoodItem()
        {
            // Rice is central to Liberia; let's use a custom "Rice Bowl"
            BentoBox rice = new BentoBox();
            rice.Name = "Bowl of Liberian Jollof Rice";
            rice.Hue = 1805; // Orange-Red, like spicy Jollof
            rice.Stackable = true;
            rice.Amount = Utility.RandomMinMax(1, 3);
            return rice;
        }

        private Item CreateWeapon()
        {
            // “Cutlass of Redemption”: a powerful weapon, themed to Liberia's farmers and founders
            Cutlass weapon = new Cutlass();
            weapon.Name = "Cutlass of Redemption";
            weapon.Hue = 1171; // Silver-blue
            weapon.MinDamage = 25;
            weapon.MaxDamage = 65;
            weapon.Attributes.BonusHits = 30;
            weapon.Attributes.BonusDex = 8;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.ReflectPhysical = 12;
            weapon.WeaponAttributes.HitHarm = 20;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.WeaponAttributes.HitLeechMana = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // “Pan-African Plate Chest” with defensive and unifying bonuses
            PlateChest armor = new PlateChest();
            armor.Name = "Pan-African Plate Chest";
            armor.Hue = 1317; // Greenish, for the land
            armor.BaseArmorRating = Utility.Random(45, 75);
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.RegenHits = 3;
            armor.Attributes.NightSight = 1;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // “Settler’s Monrovia Robe”
            Robe robe = new Robe();
            robe.Name = "Settler’s Monrovia Robe";
            robe.Hue = 1153; // Blue like the Liberian flag
            robe.Attributes.BonusInt = 7;
            robe.Attributes.RegenMana = 2;
            robe.Attributes.LowerManaCost = 8;
            robe.Attributes.Luck = 40;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateHat()
        {
            // “Kpelle Feathered Hat” - tribal pride and wisdom
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Kpelle Feathered Hat";
            hat.Hue = 2208; // Vibrant
            hat.Attributes.BonusInt = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.AnimalLore, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        public TreasureChestOfLiberianHistory(Serial serial) : base(serial)
        {
        }

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

    // LORE BOOK: "Chronicles of the Land of Liberty"
    public class ChroniclesOfTheLandOfLiberty : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of Liberty", "Matilda Freeman",
            new BookPageInfo
            (
                "Long ago, on Africa’s west coast,",
                "a new hope was kindled. Freed souls",
                "from distant lands set sail,",
                "their hearts heavy with memory,",
                "yet light with dreams of liberty."
            ),
            new BookPageInfo
            (
                "From Providence Island, the",
                "city of Monrovia rose. Settlers",
                "and tribes met—sometimes in",
                "struggle, sometimes in shared",
                "purpose. Together, they planted",
                "the seeds of a nation."
            ),
            new BookPageInfo
            (
                "The Lone Star flew overhead,",
                "its white blazing hope on blue.",
                "Americo-Liberian and indigenous,",
                "Grebo and Kpelle, Bassa and Kru:",
                "a tapestry woven from many threads."
            ),
            new BookPageInfo
            (
                "Peace was hard-won, unity fragile.",
                "Yet in rice fields and rainforests,",
                "in port towns and upland villages,",
                "the spirit of freedom endured."
            ),
            new BookPageInfo
            (
                "Through wars, through storms,",
                "through loss and healing, the",
                "land endured. Names like Roberts,",
                "Tubman, and Sirleaf echoed—",
                "echoes of struggle, courage, and hope."
            ),
            new BookPageInfo
            (
                "Let this chest remind you: liberty",
                "is never a gift; it is earned and",
                "guarded. May you honor those",
                "who came before, and may the",
                "Lone Star guide you always."
            ),
            new BookPageInfo
            (
                "For in every heart, in every home,",
                "in Liberia’s green hills and crowded",
                "markets, the promise endures—",
                "that all people are born free,",
                "and together, may rise."
            ),
            new BookPageInfo
            (
                "- Matilda Freeman, chronicler",
                "and daughter of Providence",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheLandOfLiberty() : base(false)
        {
            Hue = 1153; // Blue, like the flag
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of Liberty");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of Liberty");
        }

        public ChroniclesOfTheLandOfLiberty(Serial serial) : base(serial) { }

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
