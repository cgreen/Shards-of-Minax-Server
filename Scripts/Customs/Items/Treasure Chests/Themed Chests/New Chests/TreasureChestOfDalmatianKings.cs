using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfDalmatianKings : WoodenChest
    {
        [Constructable]
        public TreasureChestOfDalmatianKings()
        {
            Name = "Treasure Chest of the Dalmatian Kings";
            Hue = 1165; // Deep Adriatic Blue

            // Decorative & consumable treasures
            AddItem(CreateNamedItem<ArtifactLargeVase>("Vase of Ancient Illyria", 1153), 0.14);
            AddItem(CreateNamedItem<ArtifactBookshelf>("Bookshelf of Diocletian", 1190), 0.12);
            AddItem(CreateNamedItem<BakeKitsuneStatue>("Silver Wolf of Gorski Kotar", 1157), 0.08);
            AddItem(CreateNamedItem<FancyPainting>("Painting of Dubrovnik Walls", 2101), 0.16);
            AddItem(CreateNamedItem<SwordDisplay1NorthArtifact>("Display: Swords of Knin", 2418), 0.11);
            AddItem(CreateNamedItem<DecorativeShield3>("Aegis of Zadar", 1266), 0.15);
            AddItem(CreateNamedItem<SilverSteedZooStatuette>("Golden Lipizzaner of Lipik", 2413), 0.09);
            AddItem(CreateNamedItem<Bottle>("Wine of Pelješac Vineyards", 38), 0.18);
            AddItem(CreateNamedItem<BentoBox>("Royal Burek Platter", 44), 0.19);
            AddItem(CreateNamedItem<CheeseWheel>("Paški Cheese", 63), 0.16);
            AddItem(CreateNamedItem<RedHangingLantern>("Lantern of St. Blaise", 1925), 0.10);
            AddItem(CreateNamedItem<FancyCrystalSkull>("Skull of Velebit Bandit", 1171), 0.10);

            // Powerful unique equipment
            AddItem(CreateCrown(), 0.13);
            AddItem(CreateSword(), 0.13);
            AddItem(CreateCloak(), 0.14);
            AddItem(CreateShield(), 0.11);
            AddItem(CreateBoots(), 0.16);
            AddItem(CreateAmulet(), 0.12);

            // Lore book
            AddItem(new ChroniclesOfDalmatianKings(), 1.0);

            // Currency/Gold
            AddItem(CreateGoldItem("Kuna Tribute"), 0.13);

            // Map to treasure site (famous Croatian landmark)
            AddItem(CreateMap(), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

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
            gold.Amount = Utility.RandomMinMax(1500, 8000);
            return gold;
        }

        private Item CreateCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of King Tomislav";
            crown.Hue = 1154; // Rich gold
            crown.Attributes.BonusHits = 20;
            crown.Attributes.BonusInt = 15;
            crown.Attributes.Luck = 80;
            crown.SkillBonuses.SetValues(0, SkillName.Tactics, 20.0);
            crown.SkillBonuses.SetValues(1, SkillName.Swords, 10.0);
            crown.ArmorAttributes.MageArmor = 1;
            crown.ArmorAttributes.LowerStatReq = 25;
            crown.ColdBonus = 10;
            crown.FireBonus = 10;
            crown.PhysicalBonus = 15;
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Sword of Vukovar";
            sword.Hue = 1175;
            sword.MinDamage = 28;
            sword.MaxDamage = 61;
            sword.Attributes.AttackChance = 18;
            sword.Attributes.DefendChance = 16;
            sword.Attributes.WeaponSpeed = 22;
            sword.Attributes.SpellChanneling = 1;
            sword.WeaponAttributes.HitLightning = 18;
            sword.WeaponAttributes.HitFireball = 12;
            sword.WeaponAttributes.SelfRepair = 4;
            sword.SkillBonuses.SetValues(0, SkillName.Tactics, 18.0);
            sword.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Ragusa";
            cloak.Hue = 1153;
            cloak.Attributes.BonusDex = 15;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.RegenMana = 2;
            cloak.Attributes.Luck = 55;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of Zrinski";
            shield.Hue = 1169;
            shield.Attributes.DefendChance = 22;
            shield.ArmorAttributes.SelfRepair = 3;
            shield.Attributes.LowerManaCost = 5;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 22.0);
            shield.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Dalmatian Coast";
            boots.Hue = 1160;
            boots.Attributes.BonusStam = 16;
            boots.Attributes.Luck = 35;
            boots.Attributes.RegenStam = 2;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 18.0);
            boots.SkillBonuses.SetValues(1, SkillName.Fishing, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateAmulet()
        {
            GoldBeadNecklace amulet = new GoldBeadNecklace();
            amulet.Name = "Illyrian Amulet";
            amulet.Hue = 1171;
            amulet.Attributes.SpellDamage = 18;
            amulet.Attributes.CastRecovery = 2;
            amulet.Attributes.CastSpeed = 2;
            amulet.SkillBonuses.SetValues(0, SkillName.Magery, 20.0);
            amulet.SkillBonuses.SetValues(1, SkillName.MagicResist, 15.0);
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Diocletian’s Palace";
            map.Bounds = new Rectangle2D(1600, 3600, 200, 200); // Customize for your world
            map.NewPin = new Point2D(1695, 3722);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfDalmatianKings(Serial serial) : base(serial) { }

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

    public class ChroniclesOfDalmatianKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Dalmatian Kings", "Mislav the Scribe",
            new BookPageInfo
            (
                "From the ancient stones of Illyria",
                "to the sunlit shores of the Adriatic,",
                "our land has endured war, empire,",
                "and legend. Here, in these pages,",
                "is woven the tapestry of Croatia.",
                "",
                "May you remember our glory."
            ),
            new BookPageInfo
            (
                "Long before Rome, the Illyrian tribes",
                "roamed wild—brave in battle, fierce in",
                "spirit. When Caesar's legions marched,",
                "they met their match upon our hills,",
                "but at last the eagle’s shadow fell.",
                "",
                "Yet our fire did not die."
            ),
            new BookPageInfo
            (
                "Under Byzantine and Frank, we were",
                "forged in foreign courts. But it was",
                "Tomislav, crowned upon the plains,",
                "who united the land. Under his banner,",
                "the Kingdom of Croatia rose strong.",
                "",
                "We defied invaders on every side."
            ),
            new BookPageInfo
            (
                "Venetian ships brought trade and intrigue,",
                "while Ottoman swords brought ruin. From",
                "Dubrovnik’s walls, the Republic of Ragusa",
                "shone, free and proud, a beacon on the sea.",
                "",
                "Zrinski and Frankopan bled for freedom."
            ),
            new BookPageInfo
            (
                "In modern times, our struggles endured.",
                "From the rivers of Vukovar to the stone",
                "streets of Split, our people rose once more.",
                "Independence was won, dearly bought.",
                "",
                "And so, our story goes on."
            ),
            new BookPageInfo
            (
                "Whoever holds this chest, remember:",
                "You carry the pride of the Dalmatian kings,",
                "the wisdom of Ragusa, the courage of",
                "our warriors, and the hope of a nation",
                "that has never truly fallen.",
                "",
                "For Croatia, for freedom, for tomorrow."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfDalmatianKings() : base(false)
        {
            Hue = 1165; // Deep blue of the Adriatic
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Dalmatian Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Dalmatian Kings");
        }

        public ChroniclesOfDalmatianKings(Serial serial) : base(serial) { }

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
