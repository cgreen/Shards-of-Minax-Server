using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNorthMacedonia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNorthMacedonia()
        {
            Name = "Treasure Chest of North Macedonia";
            Hue = 1153; // Deep blue, like Lake Ohrid

            // Decorative and artifact items
            AddItem(CreateNamedItem<ArtifactLargeVase>("Ohrid Lake Amphora", 1366), 0.18);
            AddItem(CreateNamedItem<GoldBricks>("Treasures of Skopje Fortress", 2125), 0.12);
            AddItem(CreateNamedItem<AncientShipModelOfTheHMSCape>("Ship of Ancient Lyncestis", 1266), 0.10);
            AddItem(CreateNamedItem<MedusaStatue>("Head of the Paeonian Gorgon", 1178), 0.07);
            AddItem(CreateNamedItem<CrystalBallStatuette>("Oracle of Pelagonia", 94), 0.13);

            // Unique consumables
            AddItem(CreateNamedItem<BottleArtifact>("Tikveshian Vintage Wine", 1461), 0.18);
            AddItem(CreateNamedItem<FruitBasket>("Ohrid’s Sacred Figs", 91), 0.16);
            AddItem(CreateNamedItem<SackOfSugar>("Sweet of Struga", 1150), 0.13);

            // Unique equipment and gear
            AddItem(CreateSunHelmet(), 0.21);
            AddItem(CreateAlexanderSword(), 0.15);
            AddItem(CreateOhridCloak(), 0.17);
            AddItem(CreateMacedonianBoots(), 0.17);
            AddItem(CreatePaeonianArmor(), 0.13);

            // Decorative map
            AddItem(CreateMap(), 0.10);

            // Lore Book
            AddItem(new LegendsOfNorthMacedonia(), 1.0);

            // Treasure
            AddItem(CreateGoldItem("Ancient Macedonian Denarii"), 0.20);
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
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(2000, 6500);
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Kingdom of Macedonia";
            map.Bounds = new Rectangle2D(2100, 1000, 600, 550);
            map.NewPin = new Point2D(2450, 1250); // Location for Lake Ohrid
            map.Protected = true;
            return map;
        }

        // Unique Equipment
        private Item CreateSunHelmet()
        {
            PlateHelm helm = new PlateHelm();
            helm.Name = "Helm of the Vergina Sun";
            helm.Hue = 2125; // Gold
            helm.BaseArmorRating = 60;
            helm.Attributes.BonusHits = 18;
            helm.Attributes.Luck = 90;
            helm.Attributes.BonusStr = 7;
            helm.ArmorAttributes.LowerStatReq = 40;
            helm.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 9.0);
            helm.ColdBonus = 10;
            helm.PhysicalBonus = 13;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateAlexanderSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Blade of Alexander";
            sword.Hue = 1160; // Royal blue steel
            sword.MinDamage = 40;
            sword.MaxDamage = 65;
            sword.Attributes.BonusDex = 12;
            sword.Attributes.WeaponSpeed = 25;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitFireball = 17;
            sword.WeaponAttributes.SelfRepair = 7;
            sword.Slayer = SlayerName.DragonSlaying;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateOhridCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Lakeside Oracle";
            cloak.Hue = 95; // Deep blue
            cloak.Attributes.BonusMana = 15;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.CastSpeed = 1;
            cloak.Attributes.LowerManaCost = 13;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 13.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateMacedonianBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Mountain Tribes";
            boots.Hue = 2708; // Earthy brown
            boots.Attributes.BonusStam = 10;
            boots.Attributes.BonusStr = 6;
            boots.Attributes.Luck = 25;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 11.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tracking, 13.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreatePaeonianArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Chestplate of Paeonian Kings";
            chest.Hue = 1367; // Silvered steel
            chest.BaseArmorRating = 66;
            chest.Attributes.BonusHits = 22;
            chest.Attributes.BonusStr = 8;
            chest.ArmorAttributes.LowerStatReq = 30;
            chest.Attributes.Luck = 75;
            chest.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            chest.ColdBonus = 9;
            chest.FireBonus = 7;
            chest.PhysicalBonus = 17;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        public TreasureChestOfNorthMacedonia(Serial serial) : base(serial) { }

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

    public class LegendsOfNorthMacedonia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of North Macedonia", "Told by the Fires of Ohrid",
            new BookPageInfo
            (
                "Long before the empire",
                "of Alexander, the valleys",
                "of Macedonia echoed with",
                "the songs of Paeonian",
                "kings and the river",
                "gods of Axios. The land",
                "was shaped by Illyrians,",
                "Thracians, and bold settlers."
            ),
            new BookPageInfo
            (
                "The sun, emblem of",
                "Vergina, blazed on the",
                "battle banners of Philip",
                "II and Alexander the",
                "Great. Their armies marched",
                "from the city of Pella,",
                "bringing Hellenic light",
                "to the farthest east."
            ),
            new BookPageInfo
            (
                "Legends whisper of the",
                "sacred lake of Ohrid,",
                "whose waters see all. The",
                "saints of Byzantium built",
                "churches here, their walls",
                "etched with golden icons.",
                "In Skopje’s shadow, empires",
                "rose and fell."
            ),
            new BookPageInfo
            (
                "Ottoman sultans ruled",
                "from stone fortresses, yet",
                "rebels gathered in mountain",
                "caves, keeping their old",
                "tongue and dreams of",
                "freedom alive. Heroes like",
                "Goce Delchev rode beneath",
                "the red and gold banner."
            ),
            new BookPageInfo
            (
                "After centuries, a new",
                "nation was born—its name",
                "disputed, but its heart",
                "undivided. Macedonians",
                "built a bridge between",
                "ancient and modern, their",
                "music a blend of east",
                "and west, of hope and sorrow."
            ),
            new BookPageInfo
            (
                "The land remembers all:",
                "the voices of saints,",
                "the steps of conquerors,",
                "the silent stones of",
                "ruined cities. To open",
                "this chest is to touch",
                "the long, living memory",
                "of North Macedonia."
            ),
            new BookPageInfo
            (
                "Beware: some treasures are",
                "guarded by spirits of",
                "the past. Treat them with",
                "respect, and the Sun will",
                "shine on you. Defile them,",
                "and shadows will follow.",
                "",
                "- The Fires of Ohrid"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LegendsOfNorthMacedonia() : base(false)
        {
            Hue = 1153; // Deep blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of North Macedonia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of North Macedonia");
        }

        public LegendsOfNorthMacedonia(Serial serial) : base(serial) { }

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
