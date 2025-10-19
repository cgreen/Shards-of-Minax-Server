using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;
using Server.Engines.Quests.Doom;

namespace Server.Items
{
    public class TreasureChestOfTheUnitedStates : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheUnitedStates()
        {
            Name = "Treasure Chest of the United States";
            Hue = Utility.RandomList(1157, 1153, 1161); // blue/red/white

            // Add items to the chest
            AddItem(new ChroniclesOfLiberty(), 1.0);
            AddItem(CreateNamedItem<LibertyBellArtifact>("The Liberty Bell", 1150), 0.12);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Colonial Flower Vase", 1001), 0.13);
            AddItem(CreateNamedItem<DecorativeShield2>("Stars and Stripes Shield", 1153), 0.15);
            AddItem(CreateNamedItem<Sculpture1Artifact>("Statue of Liberty Miniature", 1150), 0.10);
            AddItem(CreateNamedItem<GoldBricks>("Gold Bar of the Federal Reserve", 2213), 0.18);
            AddItem(CreateNamedItem<BooksWestArtifact>("Declaration of Independence (Replica)", 0), 0.13);
            AddItem(CreateNamedItem<MapOfTheKnownWorld>("Map of the Oregon Trail", 2002), 0.10);
            AddItem(CreateNamedItem<WeaponEngravingTool>("Railroad Spike (Transcontinental Relic)", 1109), 0.08);
            AddItem(CreateNamedItem<AncientWeapon1>("Civil War Bayonet", 1102), 0.10);
            AddItem(CreateNamedItem<ExoticFish>("Boston Tea Chest", 2125), 0.09);
            AddItem(CreateNamedItem<ArtifactBookshelf>("Smithsonian Display Shelf", 1109), 0.07);
            AddItem(CreateNamedItem<LargePainting>("Portrait of a Founding Father", 1150), 0.12);

            // Unique Equipment
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateHat(), 0.18);
            AddItem(CreateBoots(), 0.18);
            AddItem(CreateCloak(), 0.16);

            // Unique Consumables
            AddItem(CreateNamedItem<ApplePie>("Colonial Apple Pie"), 0.13);
            AddItem(CreateNamedItem<BottleArtifact>("Elixir of Manifest Destiny", 1154), 0.12);
            AddItem(CreateNamedItem<RandomFancyCheese>("Lewis & Clark Trail Rations", 0), 0.09);
            AddItem(CreateNamedItem<RandomDrink>("Whiskey of the Wild West", 1093), 0.10);
            AddItem(CreateNamedItem<CoffeeMug>("Soldier's Coffee", 2001), 0.13);

            // Misc. Riches
            AddItem(new Gold(Utility.Random(1, 10000)), 0.19);
            AddItem(CreateNamedItem<Gold>("American Eagle Coin"), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        // Unique Weapon: Washington's Saber
        private Item CreateWeapon()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Washington's Saber";
            sword.Hue = 1153; // Blue
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.BonusDex = 15;
            sword.Attributes.BonusStam = 10;
            sword.Attributes.BonusHits = 10;
            sword.Attributes.ReflectPhysical = 12;
            sword.Attributes.Luck = 75;
            sword.Slayer = SlayerName.Repond;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitLowerAttack = 10;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Unique Armor: Lincoln's Resolve Cloak
        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Lincoln's Resolve Cloak";
            cloak.Hue = 2213; // Gold
            cloak.Attributes.LowerManaCost = 10;
            cloak.Attributes.BonusInt = 20;
            cloak.Attributes.RegenMana = 5;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            cloak.Attributes.Luck = 100;
            cloak.Attributes.NightSight = 1;
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Unique Armor: General's Battlefield Chestplate
        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "General's Battlefield Chestplate";
            armor.Hue = 1109; // Silver/Gray
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.Attributes.BonusStr = 18;
            armor.Attributes.RegenHits = 7;
            armor.ArmorAttributes.SelfRepair = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            armor.ColdBonus = 5;
            armor.EnergyBonus = 8;
            armor.FireBonus = 7;
            armor.PhysicalBonus = 25;
            armor.PoisonBonus = 12;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique Hat: Franklin’s Inventor’s Cap
        private Item CreateHat()
        {
            WizardsHat hat = new WizardsHat();
            hat.Name = "Franklin's Inventor's Cap";
            hat.Hue = 2001; // Electric blue
            hat.Attributes.CastRecovery = 2;
            hat.Attributes.CastSpeed = 2;
            hat.Attributes.BonusInt = 15;
            hat.Attributes.RegenMana = 6;
            hat.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Inscribe, 14.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        // Unique Boots: Lewis & Clark Pathfinder Boots
        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Lewis & Clark Pathfinder Boots";
            boots.Hue = 1266; // Brown/tan
            boots.Attributes.BonusDex = 12;
            boots.Attributes.BonusStam = 8;
            boots.Attributes.Luck = 50;
            boots.SkillBonuses.SetValues(0, SkillName.Camping, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Cartography, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public TreasureChestOfTheUnitedStates(Serial serial) : base(serial) { }

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

    // Book of Lore: Chronicles of Liberty
    public class ChroniclesOfLiberty : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Liberty", "Anonymous Chronicler",
            new BookPageInfo
            (
                "In 1776, voices rang out for freedom.",
                "Colonists gathered in Philadelphia,",
                "declaring a new nation’s birth.",
                "Let the world know: America rises.",
                "From thirteen embattled colonies,",
                "the struggle began—revolution,",
                "hope, sacrifice, unity."
            ),
            new BookPageInfo
            (
                "Liberty’s bell tolled. A flag of stars",
                "and stripes lifted above battlefields.",
                "Winter in Valley Forge. Dawn at Yorktown.",
                "Against the world’s might, they endured.",
                "The union was forged in flame, and",
                "from the ashes, a new experiment.",
                "A land where all are created equal."
            ),
            new BookPageInfo
            (
                "Westward, pioneers wandered. Frontier",
                "and forest, prairie and peak. Rivers",
                "crossed. Cities built. Dreams chased.",
                "Yet the price was dear: war and sorrow,",
                "division North and South. Brother",
                "fought brother. Yet again, the nation",
                "stood—‘a new birth of freedom.’"
            ),
            new BookPageInfo
            (
                "Inventors lit the night with lamps and",
                "ideas. From cotton gin to telegraph,",
                "steamship to airplane, ambition soared.",
                "The world’s tired masses found harbor here,",
                "statues promising liberty at the gate.",
                "In peace and in hardship, in war and",
                "in victory, the dream pressed on."
            ),
            new BookPageInfo
            (
                "Two centuries on, the American story",
                "remains unfinished—still written daily.",
                "A history built on struggle, courage, and",
                "the belief that liberty is not a gift,",
                "but a challenge for each generation.",
                "May these chronicles inspire those who",
                "seek, who strive, who remember."
            ),
            new BookPageInfo
            (
                "From sea to shining sea—",
                "Let freedom ring.",
                "",
                "- The Chronicler",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfLiberty() : base(false)
        {
            Hue = 1153; // Deep blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Liberty");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Liberty");
        }

        public ChroniclesOfLiberty(Serial serial) : base(serial) { }

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

    // Decorative Artifact Example: Liberty Bell
    public class LibertyBellArtifact : BellOfTheDead
    {
        [Constructable]
        public LibertyBellArtifact()
        {
            Name = "Liberty Bell";
            Hue = 1150;
            Movable = true;
            Weight = 3.0;
        }

        public LibertyBellArtifact(Serial serial) : base(serial) { }
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
}
