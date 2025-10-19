using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPanama : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPanama()
        {
            Name = "Treasure Chest of Panama's Legacy";
            Hue = 2125; // Deep gold

            // Add items
            AddItem(new GoldenSunIdol(), 0.10);
            AddItem(CreateNamedDeco<ArtifactVase>("Vase of the Chagres", 1177), 0.15);
            AddItem(CreateNamedDeco<BambooStoolArtifact>("Stool from a Canal Worker’s Hut", 1160), 0.12);
            AddItem(CreateNamedDeco<AncientWeapon2>("Sword of Vasco Núñez", 1367), 0.10);
            AddItem(CreateNamedDeco<GoldBricks>("Spanish Gold Ingot", 2213), 0.14);
            AddItem(CreateNamedDeco<MapOfTheKnownWorld>("Pirate Map of Panama", 2101), 0.13);
            AddItem(CreateNamedDeco<Painting1WestArtifact>("Portrait of Balboa", 1645), 0.10);
            AddItem(CreateNamedDeco<CupOfSlime>("Jungle Water Gourd", 1372), 0.08);
            AddItem(CreateNamedDeco<RandomFancyBanner>("Flag of Independence", 2117), 0.13);
            AddItem(CreateNamedDeco<Sextant>("Navigator’s Old Sextant", 1123), 0.08);
            AddItem(CreateNamedDeco<BlueSand>("Isthmus Blue Sand", 1266), 0.12);
            AddItem(new ChroniclesOfTheIsthmus(), 1.0);
            AddItem(CreatePirateSword(), 0.22);
            AddItem(CreateExplorerArmor(), 0.18);
            AddItem(CreateCanalBoots(), 0.19);
            AddItem(CreateConquistadorHat(), 0.14);
            AddItem(CreateJungleCloak(), 0.17);
            AddItem(CreateUniquePotion(), 0.16);
            AddItem(CreateNamedFood<BentoBox>("Plantain and Fish Bento", 1290), 0.16);
            AddItem(new Gold(Utility.Random(3000, 7000)), 0.12);
            AddItem(CreateMapToPanamaCanal(), 0.07);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedDeco<T>(string name, int hue) where T : Item, new()
        {
            T deco = new T();
            deco.Name = name;
            deco.Hue = hue;
            return deco;
        }

        private Item CreatePirateSword()
        {
            Cutlass sword = new Cutlass();
            sword.Name = "Morgan's Crimson Cutlass";
            sword.Hue = 1157; // Deep red
            sword.MinDamage = 28;
            sword.MaxDamage = 63;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusHits = 25;
            sword.Attributes.AttackChance = 12;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.WeaponAttributes.HitFireball = 20;
            sword.WeaponAttributes.SelfRepair = 8;
            sword.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            sword.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateExplorerArmor()
        {
            LeatherChest armor = new LeatherChest();
            armor.Name = "Armor of the Gold Road Explorer";
            armor.Hue = 2513; // Jungle green
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusDex = 12;
            armor.Attributes.LowerManaCost = 8;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.SelfRepair = 6;
            armor.SkillBonuses.SetValues(0, SkillName.Camping, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Cartography, 20.0);
            armor.ColdBonus = 12;
            armor.EnergyBonus = 8;
            armor.PhysicalBonus = 15;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCanalBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Canal Builder’s Mud Boots";
            boots.Hue = 1109; // Muddy brown
            boots.Attributes.BonusStam = 15;
            boots.Attributes.BonusHits = 10;
            boots.Attributes.NightSight = 1;
            boots.Attributes.RegenStam = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Mining, 20.0);
            boots.SkillBonuses.SetValues(1, SkillName.Carpentry, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateConquistadorHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Balboa’s Plumed Helm";
            hat.Hue = 1153; // Blue feather
            hat.Attributes.BonusInt = 8;
            hat.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateJungleCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Darien Jungle";
            cloak.Hue = 1435; // Jungle green
            cloak.Attributes.Luck = 25;
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.RegenMana = 2;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Stealth, 14.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateUniquePotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Brew of the Golden Isthmus";
            potion.Hue = 2125;
            return potion;
        }

        private Item CreateNamedFood<T>(string name, int hue) where T : Item, new()
        {
            T food = new T();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateMapToPanamaCanal()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost Locks of the Canal";
            map.Bounds = new Rectangle2D(2350, 3650, 400, 400); // Example coords
            map.NewPin = new Point2D(2450, 3750);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfPanama(Serial serial) : base(serial) { }

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

    public class GoldenSunIdol : GoldBrick
    {
        [Constructable]
        public GoldenSunIdol()
        {
            Name = "Golden Sun Idol of Panama";
            Hue = 2213;
            LootType = LootType.Blessed;
        }

        public GoldenSunIdol(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheIsthmus : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Isthmus", "By 'El Historiador'",
            new BookPageInfo
            (
                "From the dawn of green jungles,",
                "when Guna, Emberá, and Ngäbe",
                "walked the winding rivers—before",
                "the thunder of ships and gold.",
                "",
                "Panama, land of passage, land of",
                "storm and sun. The sea called to",
                "pirates and dreamers alike."
            ),
            new BookPageInfo
            (
                "Balboa waded the waters,",
                "gazing at the endless South Sea.",
                "Morgan burned Panamá Viejo,",
                "chasing gold across bloodied stone.",
                "",
                "Gold Road, Camino Real, packed",
                "with mule trains and conquistadors."
            ),
            new BookPageInfo
            (
                "Spanish rule crumbled, pirates",
                "plundered and vanished, but",
                "Panama endured. Empires fell,",
                "but the isthmus stood firm.",
                "",
                "Rebellion’s fire, Colombian yoke,",
                "and the dream of freedom."
            ),
            new BookPageInfo
            (
                "Then, men and machines tore",
                "the land, chasing the miracle:",
                "a path between oceans.",
                "",
                "Fever, jungle, sweat, and loss—",
                "but at last, the canal."
            ),
            new BookPageInfo
            (
                "Now ships ride the silver path,",
                "and the world bends around it.",
                "",
                "Panama, bridge of the world,",
                "heart of the universe.",
                "",
                "Here is your story, seeker."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheIsthmus() : base(false)
        {
            Hue = 1170; // Canal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Isthmus");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Isthmus");
        }

        public ChroniclesOfTheIsthmus(Serial serial) : base(serial) { }

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
