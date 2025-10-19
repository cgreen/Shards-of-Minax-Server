using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfJamaica : WoodenChest
    {
        [Constructable]
        public TreasureChestOfJamaica()
        {
            Name = "Treasure Chest of Jamaica’s Golden Age";
            Hue = 2125; // A rich golden-brown

            // Decorative artifacts
            AddItem(CreateDecorativeItem<BottleArtifact>("Captain Morgan's Rum", 2115), 0.23);
            AddItem(CreateDecorativeItem<GoldBricks>("Spanish Doubloons of Port Royal", 2213), 0.19);
            AddItem(CreateDecorativeItem<TreasureLevel2>("Ancient Maroon Drum", 2007), 0.15);
            AddItem(CreateDecorativeItem<SkullCandleArtifact>("Obeah Ritual Skull Candle", 1161), 0.16);
            AddItem(CreateDecorativeItem<FancyPainting>("Pirate Map of the Caribbean", 2118), 0.13);
            AddItem(CreateDecorativeItem<IncenseBurner>("Incense of the Sugar Barons", 2000), 0.13);

            // Consumables / unique food
            AddItem(CreateNamedFood<Bottle>("Healing Tonic of the Blue Mountains", 1802), 0.16);
            AddItem(CreateNamedFood<BentoBox>("Maroon Survival Bento", 2117), 0.14);
            AddItem(CreateNamedFood<GreenTea>("Jamaican Bush Tea", 1416), 0.14);
            AddItem(CreateNamedFood<Cake>("Rum Cake of Port Royal", 2008), 0.11);

            // Equipment: unique armor/clothing
            AddItem(CreateJamaicaHat(), 0.16);
            AddItem(CreateMaroonBoots(), 0.14);
            AddItem(CreatePirateSash(), 0.12);

            // Unique weapons
            AddItem(CreatePirateCutlass(), 0.18);
            AddItem(CreateCaribbeanMusket(), 0.09);
            AddItem(CreateFishermansNet(), 0.10);

            // Legendary Equipment
            AddItem(CreateLegendaryJamaicanCloak(), 0.09);

            // Gold coins (unique name)
            AddItem(CreateGoldItem("Pieces of Eight"), 0.20);

            // Lore book
            AddItem(new HeartOfTheCaribbean(), 1.0);

            // Treasure map
            AddItem(CreateJamaicaMap(), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedFood<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(1000, 6000);
            return gold;
        }

        private Item CreateJamaicaHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Pirate Captain's Feathered Hat";
            hat.Hue = 1109; // deep sea blue
            hat.Attributes.BonusInt = 12;
            hat.Attributes.LowerManaCost = 15;
            hat.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMaroonBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Maroon Pathfinder Boots";
            boots.Hue = 2120;
            boots.Attributes.Luck = 25;
            boots.Attributes.BonusDex = 8;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 18.0);
            boots.Attributes.NightSight = 1;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreatePirateSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of the Buccaneer";
            sash.Hue = 1154; // blood red
            sash.Attributes.RegenHits = 2;
            sash.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            sash.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreatePirateCutlass()
        {
            Cutlass cutlass = new Cutlass();
            cutlass.Name = "Blackbeard’s Razor";
            cutlass.Hue = 1175;
            cutlass.MinDamage = Utility.Random(22, 32);
            cutlass.MaxDamage = Utility.Random(40, 55);
            cutlass.Attributes.WeaponSpeed = 20;
            cutlass.WeaponAttributes.HitLeechHits = 18;
            cutlass.WeaponAttributes.HitLightning = 22;
            cutlass.WeaponAttributes.SelfRepair = 6;
            cutlass.Attributes.BonusStr = 10;
            cutlass.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(cutlass, new XmlLevelItem());
            return cutlass;
        }

        private Item CreateCaribbeanMusket()
        {
            HeavyCrossbow musket = new HeavyCrossbow();
            musket.Name = "Caribbean Musket of the Redcoats";
            musket.Hue = 1191;
            musket.Attributes.WeaponDamage = 32;
            musket.Attributes.AttackChance = 12;
            musket.WeaponAttributes.HitFireball = 28;
            musket.SkillBonuses.SetValues(0, SkillName.Archery, 18.0);
            XmlAttach.AttachTo(musket, new XmlLevelItem());
            return musket;
        }

        private Item CreateFishermansNet()
        {
            LargeFishingNet net = new LargeFishingNet();
            net.Name = "Mystic Net of the Fisher King";
            net.Hue = 1267;

            return net;
        }

        private Item CreateLegendaryJamaicanCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Island Spirit";
            cloak.Hue = 2216; // iridescent green/gold
            cloak.Attributes.RegenMana = 5;
            cloak.Attributes.LowerRegCost = 12;
            cloak.Attributes.Luck = 35;
            cloak.Attributes.BonusInt = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Musicianship, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateJamaicaMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost Caves of Bluefields";
            map.Bounds = new Rectangle2D(2123, 1544, 400, 400);
            map.NewPin = new Point2D(2244, 1688);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfJamaica(Serial serial) : base(serial) { }

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

    // Custom Lore Book
    public class HeartOfTheCaribbean : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Heart of the Caribbean: Tales from Jamaica’s Golden Age", "Port Royal Scribe",
            new BookPageInfo(
                "Welcome to the island of",
                "Jamaica, jewel of the",
                "Caribbean Sea. Here,",
                "pirates and planters,",
                "Maroon warriors and",
                "colonists all fought for",
                "riches and freedom."
            ),
            new BookPageInfo(
                "Port Royal, the wickedest",
                "city on earth, teemed",
                "with gold and vice. Here,",
                "Blackbeard and Calico Jack",
                "drank rum beneath the palm",
                "trees, plotting their next",
                "conquests."
            ),
            new BookPageInfo(
                "The Maroons—escaped slaves—",
                "vanished into the blue",
                "mountains, striking at the",
                "colonists by night. Their",
                "drums echoed through the",
                "jungle, a call to liberty."
            ),
            new BookPageInfo(
                "In sugar fields and hidden",
                "bays, treasures were",
                "buried by those fleeing",
                "the Spanish, the British,",
                "and the storm. Curses and",
                "blessings sleep beneath",
                "the island’s soil."
            ),
            new BookPageInfo(
                "Let every adventurer take",
                "heed: Jamaica’s fortunes",
                "are not only gold, but the",
                "spirit of rebellion and",
                "survival. Raise a cup of",
                "rum and toast the old",
                "Caribbean ways!"
            ),
            new BookPageInfo(
                "For in these golden isles,",
                "the brave and the bold",
                "find their destiny.",
                "",
                "",
                "- Port Royal Scribe",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public HeartOfTheCaribbean() : base(false)
        {
            Hue = 2125;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Heart of the Caribbean");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Heart of the Caribbean: Tales from Jamaica’s Golden Age");
        }

        public HeartOfTheCaribbean(Serial serial) : base(serial) { }

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
