using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheHolySee : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheHolySee()
        {
            Name = "Treasure Chest of the Holy See";
            Hue = 1153; // Papal gold/white

            // Add themed items to the chest
            AddItem(CreateHolyRelic(), 0.10);
            AddItem(CreateNamedDeco<ArtifactVase>("Sanctified Chalice of St. Peter", 1150), 0.14);
            AddItem(CreateNamedDeco<BookOfTruthArtifact>("Codex of Papal Secrets", 1152), 0.10);
            AddItem(CreateNamedDeco<GoldBricks>("Gilded Reliquary Bricks", 1175), 0.12);
            AddItem(CreateHolyWine(), 0.18);
            AddItem(CreateBlessedBread(), 0.16);
            AddItem(CreateNamedDeco<Painting1NorthArtifact>("Portrait of the Lost Pope", 1153), 0.12);
            AddItem(CreateNamedDeco<Sculpture1Artifact>("Angel of Benediction", 1154), 0.10);
            AddItem(CreateNamedDeco<CandelabraOfSouls>("Candelabra of the Pontiff", 1153), 0.13);
            AddItem(CreateNamedDeco<GargishKnowledgeTotemArtifact>("Sacred Knowledge Totem", 1174), 0.11);
            AddItem(new ChronicleOfTheHolySee(), 1.0);

            // Epic unique equipment
            AddItem(CreatePapalMiter(), 0.20);
            AddItem(CreateSacredRobe(), 0.18);
            AddItem(CreateSanctifiedSword(), 0.17);
            AddItem(CreateInquisitorShield(), 0.16);
            AddItem(CreatePaladinBoots(), 0.15);
            AddItem(CreateScholarsRing(), 0.15);

            // Rare currency & valuables
            AddItem(CreateHolyCoin(), 0.19);
            AddItem(CreateNamedDeco<GoldEarrings>("Earrings of the Vestal Choir", 1177), 0.13);

            // Rare map (leads to a secret catacomb)
            AddItem(CreateMap(), 0.05);

            // Some gold
            AddItem(new Gold(Utility.Random(2000, 6000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative/Artifact items
        private Item CreateNamedDeco<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateHolyRelic()
        {
            Diamond relic = new Diamond();
            relic.Name = "Fragment of the True Cross";
            relic.Hue = 1153;
            return relic;
        }

        private Item CreateHolyWine()
        {
            BottleOfWine wine = new BottleOfWine();
            wine.Name = "Sacramental Wine";
            wine.Hue = 1157;
            wine.Stackable = false;
            wine.Weight = 2.0;
            return wine;
        }

        private Item CreateBlessedBread()
        {
            BreadLoaf bread = new BreadLoaf();
            bread.Name = "Blessed Bread";
            bread.Hue = 1152;
            return bread;
        }

        private Item CreateHolyCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Papal Ducat";
            gold.Amount = Utility.Random(1, 50);
            gold.Hue = 1175;
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Secret Map to the Papal Catacombs";
            map.Bounds = new Rectangle2D(1600, 2050, 120, 120);
            map.NewPin = new Point2D(1620, 2100);
            map.Protected = true;
            return map;
        }

        // Unique Equipment
        private Item CreatePapalMiter()
        {
            FeatheredHat miter = new FeatheredHat();
            miter.Name = "Miter of the Supreme Pontiff";
            miter.Hue = 1153;
            miter.Attributes.BonusInt = 15;
            miter.Attributes.BonusMana = 10;
            miter.Attributes.CastRecovery = 2;
            miter.Attributes.LowerManaCost = 10;
            miter.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            miter.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            miter.SkillBonuses.SetValues(2, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(miter, new XmlLevelItem());
            return miter;
        }

        private Item CreateSacredRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of Celestial Authority";
            robe.Hue = 1152;
            robe.Attributes.BonusHits = 20;
            robe.Attributes.Luck = 100;
            robe.Attributes.LowerRegCost = 20;
            robe.Attributes.BonusMana = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSanctifiedSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Sword of St. Michael";
            sword.Hue = 1157;
            sword.MinDamage = 25;
            sword.MaxDamage = 55;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.WeaponDamage = 35;
            sword.Attributes.BonusStr = 8;
            sword.Attributes.BonusHits = 20;
            sword.WeaponAttributes.HitFireArea = 20;
            sword.WeaponAttributes.HitLeechHits = 15;
            sword.Slayer = SlayerName.Exorcism;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateInquisitorShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Inquisitor's Shield";
            shield.Hue = 1154;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusDex = 10;
            shield.Attributes.RegenStam = 6;
            shield.ArmorAttributes.MageArmor = 1;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreatePaladinBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Paladin’s Crusader Boots";
            boots.Hue = 1175;
            boots.Attributes.BonusStr = 7;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.RegenHits = 4;
            boots.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateScholarsRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Papal Librarian";
            ring.Hue = 1150;
            ring.Attributes.BonusInt = 10;
            ring.Attributes.RegenMana = 5;
            ring.Attributes.CastSpeed = 1;
            ring.SkillBonuses.SetValues(0, SkillName.Inscribe, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        public TreasureChestOfTheHolySee(Serial serial) : base(serial)
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

    public class ChronicleOfTheHolySee : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Holy See", "Secretarius Apostolicus",
            new BookPageInfo
            (
                "In the shadowed halls of",
                "the Eternal City, secrets",
                "are written not just on",
                "parchment, but upon the",
                "very stones. From the",
                "Fisherman’s Ring to the",
                "triple tiara, each relic",
                "tells the tale of a faith"
            ),
            new BookPageInfo
            (
                "tested by time and flame.",
                "Here lies the power of",
                "keys and crowns: The",
                "Papal Seal, the Lapis",
                "Excommunicatus, the true",
                "bones of the saints, and",
                "the Grail itself—hidden",
                "beneath marble floors."
            ),
            new BookPageInfo
            (
                "Within the sacred vaults,",
                "popes and princes have",
                "whispered bargains. The",
                "Holy See endures not by",
                "sword, but by wisdom,",
                "shadow, and the unseen",
                "hand that guides empires.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Beware the secrets found",
                "in these sanctums. Not",
                "all miracles are kind.",
                "Not all saints are silent.",
                "Let the finder of this",
                "chest remember: Power",
                "is the servant of faith,",
                "but faith is the master."
            ),
            new BookPageInfo
            (
                "May the light of the",
                "Holy See guide, shelter,",
                "and test you, as it has",
                "all who walk the hidden",
                "corridors of history.",
                "",
                "",
                "- Archivum Secretum"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheHolySee() : base(false)
        {
            Hue = 1152; // Papal white-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Holy See");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Holy See");
        }

        public ChronicleOfTheHolySee(Serial serial) : base(serial) { }

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
