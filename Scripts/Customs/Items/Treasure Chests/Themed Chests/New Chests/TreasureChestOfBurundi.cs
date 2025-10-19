using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBurundi : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfBurundi()
        {
            Name = "Treasure Chest of Burundi’s Royal Legacy";
            Hue = 2125; // Deep regal purple

            // Add decorative and unique items
            AddItem(CreateNamedItem<ArtifactLargeVase>("Urn of the Mwami", 2515), 0.20);
            AddItem(CreateNamedItem<BambooStoolArtifact>("Royal Drum Throne", 2120), 0.17);
            AddItem(CreateNamedItem<ArtifactBookshelf>("Library of Gitega", 1157), 0.13);
            AddItem(CreateNamedItem<Sculpture1Artifact>("Sacred Intore Drum", 2129), 0.22);
            AddItem(CreateNamedItem<Painting2WestArtifact>("The Great Lakes Tapestry", 1772), 0.13);
            AddItem(CreateNamedItem<Basket5WestArtifact>("Imigongo Basket", 1899), 0.16);
            AddItem(CreateColoredItem<FloweredDress>("Robes of the Queen Mother", 2414), 0.16);
            AddItem(CreateNamedItem<GoldBracelet>("Ibwami Cattle Talisman", 1287), 0.13);
            AddItem(CreateColoredItem<RedBeaker>("Royal Palm Wine Gourd", 1635), 0.18);
            AddItem(CreateNamedItem<RandomFruitBasket>("Harvest of Burundi", 0), 0.22);
            AddItem(CreateNamedItem<RandomFancyBanner>("Drum Circle Banner", 2120), 0.10);

            // Consumables
            AddItem(CreateNamedItem<GreaterHealPotion>("Potion of the Sacred Cow", 1538), 0.15);
            AddItem(CreateNamedItem<BowlOfRotwormStew>("Stew of Kirundo", 2448), 0.12);
            AddItem(CreateNamedItem<GreenTea>("Tea of the Highlands", 1268), 0.14);
            AddItem(CreateNamedItem<CheeseWedge>("Royal Cattle Cheese", 1155), 0.14);

            // Equipment
            AddItem(CreateMwamiCrown(), 0.12);
            AddItem(CreateSpearOfMwami(), 0.14);
            AddItem(CreateImigongoRobe(), 0.16);
            AddItem(CreateDrummerBoots(), 0.17);
            AddItem(CreateShieldOfGitega(), 0.12);

            // Lore book
            AddItem(new ChroniclesOfBurundi(), 1.0);

            // Gold and map
            AddItem(new Gold(Utility.Random(2000, 5000)), 0.22);
            AddItem(CreateMap(), 0.04);
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

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Legendary gear
        private Item CreateMwamiCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of the Mwami";
            crown.Hue = 2515;
            crown.Attributes.BonusInt = 15;
            crown.Attributes.BonusMana = 15;
            crown.Attributes.CastSpeed = 1;
            crown.Attributes.CastRecovery = 2;
            crown.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            crown.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            crown.ArmorAttributes.LowerStatReq = 15;
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateSpearOfMwami()
        {
            Spear spear = new Spear();
            spear.Name = "Spear of the Mwami";
            spear.Hue = 2120;
            spear.MinDamage = 30;
            spear.MaxDamage = 65;
            spear.WeaponAttributes.HitFireArea = 20;
            spear.WeaponAttributes.HitLeechHits = 12;
            spear.WeaponAttributes.HitLowerAttack = 18;
            spear.Attributes.BonusStr = 8;
            spear.Attributes.BonusHits = 20;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            spear.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateImigongoRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Imigongo Ritual Robe";
            robe.Hue = 1899;
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.SpellDamage = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDrummerBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Drummers of Gishora";
            boots.Hue = 2128;
            boots.Attributes.BonusDex = 15;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.RegenStam = 4;
            boots.Attributes.LowerManaCost = 8;
            boots.SkillBonuses.SetValues(0, SkillName.Musicianship, 18.0);
            boots.SkillBonuses.SetValues(1, SkillName.Provocation, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateShieldOfGitega()
        {
            HeaterShield shield = new HeaterShield();
            shield.Name = "Shield of Gitega";
            shield.Hue = 1157;
            shield.Attributes.BonusHits = 18;
            shield.Attributes.DefendChance = 13;
            shield.Attributes.ReflectPhysical = 10;
            shield.Attributes.SpellChanneling = 1;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Royal Tombs of Burundi";
            map.Bounds = new Rectangle2D(2250, 1300, 250, 250);
            map.NewPin = new Point2D(2350, 1350);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfBurundi(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBurundi : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Burundi: From the Mwami to Modernity", "Unknown Griot",
            new BookPageInfo
            (
                "In the heart of Africa, where",
                "the drumbeat is a heartbeat,",
                "Burundi rose, a kingdom of",
                "hills and sacred cows. The",
                "Mwami’s word was law; his",
                "cattle grazed the highlands,",
                "the drummers of Gishora sang",
                "history into the wind."
            ),
            new BookPageInfo
            (
                "Imigongo swirls adorned",
                "the royal palaces, painted in",
                "cow dung and hope. The",
                "people, Hutu, Tutsi, and Twa,",
                "tilled the land, drank the",
                "sweet sorghum beer, danced",
                "in the shadow of kings."
            ),
            new BookPageInfo
            (
                "Centuries turned; the German",
                "flag came, then the Belgian,",
                "stamping borders on memory.",
                "Independence in 1962 brought",
                "hope, and pain. The Mwami’s",
                "throne toppled, replaced by",
                "uncertain peace, and bitter",
                "strife."
            ),
            new BookPageInfo
            (
                "The drums did not cease.",
                "Even as war scarred the",
                "land, the drummers gathered,",
                "beating out the rhythm of",
                "resilience. The sacred cows",
                "wandered, survivors of kings",
                "and colonels, the spirit of",
                "Burundi enduring."
            ),
            new BookPageInfo
            (
                "May this chest preserve a",
                "legacy: of the Mwami’s crown,",
                "the drums of Gitega, the",
                "sacred lakes, the unity of",
                "many peoples. The past is",
                "pain, and pride. The future—",
                "still unwritten, but hopeful.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let the finder remember:",
                "The real treasure is peace.",
                "And the sound of the drum",
                "is the heart of Burundi.",
                "",
                "",
                "",
                "- The Griot"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBurundi() : base(false)
        {
            Hue = 2125; // Royal purple
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Burundi: From the Mwami to Modernity");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Burundi: From the Mwami to Modernity");
        }

        public ChroniclesOfBurundi(Serial serial) : base(serial) { }

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
