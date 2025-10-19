using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheUnitedKingdom : MetalChest
    {
        [Constructable]
        public TreasureChestOfTheUnitedKingdom()
        {
            Name = "Treasure Chest of the United Kingdom";
            Hue = 1109; // Deep royal blue

            // Add decorative and thematic items
            AddItem(CreateDecorative<ArtifactLargeVase>("Crown of Albion", 2413), 0.12);
            AddItem(CreateDecorative<Sculpture1Artifact>("Stone of Scone", 902), 0.08);
            AddItem(CreateDecorative<RandomFancyBanner>("Union Jack Banner", 1157), 0.10);
            AddItem(CreateDecorative<ArtifactBookshelf>("Shakespeare’s Folio", 2125), 0.10);
            AddItem(CreateDecorative<RandomTrophy>("Windsor Candleabra", 1175), 0.11);
            AddItem(CreateDecorative<CrystalBallStatuette>("Crystal Ball of the Druids", 92), 0.13);
            AddItem(CreateDecorative<QuagmireStatue>("Loch Ness Idol", 2052), 0.08);
            AddItem(CreateDecorative<SwordDisplay2NorthArtifact>("Knight’s Oath Sword Display", 2418), 0.09);
            AddItem(CreateDecorative<Painting1WestArtifact>("Coronation Portrait", 1154), 0.08);
            AddItem(CreateDecorative<RandomFancyPottery>("Holy Grail Replica", 1281), 0.06);

            // Add consumables and treasures
            AddItem(CreateConsumable<GreaterHealPotion>("Elixir of Britannia", 1266), 0.15);
            AddItem(CreateConsumable<BentoBox>("Royal Picnic Box", 1152), 0.14);
            AddItem(CreateConsumable<GreenTea>("King’s Tea", 1153), 0.17);
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Royal Biscuit", 1157), 0.16);
            AddItem(CreateGoldItem("Sovereign Coin", 1177), 0.18);
            AddItem(new Gold(Utility.Random(3000, 8000)), 0.15);

            // Add legendary equipment
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateCloak(), 0.20);
            AddItem(CreateBoots(), 0.19);
            AddItem(CreateRing(), 0.15);

            // Add the book of lore
            AddItem(new ChronicleOfBritannia(), 1.0);

            // Add map to a legendary location
            AddItem(CreateMap(), 0.05);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name, int hue)
        {
            Gold gold = new Gold(Utility.Random(200, 700));
            gold.Name = name;
            gold.Hue = hue;
            return gold;
        }

        private Item CreateWeapon()
        {
            Broadsword excalibur = new Broadsword();
            excalibur.Name = "Excalibur, Sword of Arthur";
            excalibur.Hue = 1150; // Silver-blue
            excalibur.Attributes.WeaponDamage = 45;
            excalibur.Attributes.AttackChance = 15;
            excalibur.Attributes.DefendChance = 10;
            excalibur.WeaponAttributes.HitLightning = 20;
            excalibur.WeaponAttributes.HitLeechHits = 12;
            excalibur.WeaponAttributes.SelfRepair = 5;
            excalibur.Attributes.CastSpeed = 2;
            excalibur.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            excalibur.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(excalibur, new XmlLevelItem());
            return excalibur;
        }

        private Item CreateArmor()
        {
            PlateChest royalGuard = new PlateChest();
            royalGuard.Name = "Royal Guard’s Breastplate";
            royalGuard.Hue = 1157; // Royal blue
            royalGuard.BaseArmorRating = 55;
            royalGuard.Attributes.BonusHits = 25;
            royalGuard.Attributes.BonusStr = 10;
            royalGuard.Attributes.Luck = 75;
            royalGuard.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            royalGuard.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(royalGuard, new XmlLevelItem());
            return royalGuard;
        }

        private Item CreateCloak()
        {
            Cloak queensCloak = new Cloak();
            queensCloak.Name = "Queen’s Cloak of Sovereignty";
            queensCloak.Hue = 2117; // Royal purple
            queensCloak.Attributes.BonusMana = 20;
            queensCloak.Attributes.SpellDamage = 18;
            queensCloak.Attributes.Luck = 60;
            queensCloak.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            queensCloak.SkillBonuses.SetValues(1, SkillName.Magery, 12.0);
            XmlAttach.AttachTo(queensCloak, new XmlLevelItem());
            return queensCloak;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Highlander";
            boots.Hue = 2101; // Dark green
            boots.Attributes.BonusDex = 18;
            boots.Attributes.BonusStam = 15;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Windsor Legacy";
            ring.Hue = 1161;
            ring.Attributes.RegenHits = 5;
            ring.Attributes.RegenMana = 5;
            ring.Attributes.BonusInt = 8;
            ring.Attributes.CastRecovery = 2;
            ring.Attributes.SpellDamage = 8;
            ring.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 8.0);
            ring.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Avalon";
            map.Bounds = new Rectangle2D(2500, 1200, 400, 400);
            map.NewPin = new Point2D(2600, 1400);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheUnitedKingdom(Serial serial) : base(serial) { }

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

    public class ChronicleOfBritannia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Britannia", "The Royal Scribe",
            new BookPageInfo
            (
                "From misty isles and",
                "ancient stones, the tale",
                "of Britannia unfolds.",
                "From Celts to Saxons,",
                "from Romans to Normans,",
                "nations forged in iron",
                "and fire, under many a",
                "crown and banner."
            ),
            new BookPageInfo
            (
                "Arthur drew forth the",
                "blade and legends grew.",
                "Castles rose, kings and",
                "queens ruled and fell.",
                "Great battles echoed",
                "from Hastings’ field to",
                "Agincourt’s mud and",
                "Trafalgar’s seas."
            ),
            new BookPageInfo
            (
                "In London’s heart, the",
                "Thames bore witness to",
                "empire’s rise. Elizabeth’s",
                "reign, the sun that never",
                "set, and the shadowed",
                "age of smoke and steam—",
                "industry and invention.",
                ""
            ),
            new BookPageInfo
            (
                "The Scots highland and",
                "the Welsh hills, Ireland’s",
                "emerald isles—all threads",
                "in the tapestry of union,",
                "sometimes frayed, but",
                "ever entwined."
            ),
            new BookPageInfo
            (
                "Through war and peace,",
                "from Magna Carta to",
                "Parliament’s voice, the",
                "dream of freedom grew.",
                "The king and the people—",
                "two hands upon the helm",
                "of destiny."
            ),
            new BookPageInfo
            (
                "In modern times, a",
                "kingdom stands united",
                "by memory, hope, and",
                "song. The bells of Big Ben,",
                "the roar of Wembley,",
                "the quiet fields of",
                "Somerset and Skye."
            ),
            new BookPageInfo
            (
                "So let all who seek",
                "treasure in these isles",
                "remember the legends,",
                "the trials, and the",
                "splendors of Britannia.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "For this chest holds not",
                "only gold, but the story",
                "of a kingdom, written in",
                "stone, steel, and dream.",
                "",
                "- The Royal Scribe",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfBritannia() : base(false)
        {
            Hue = 1109; // Deep royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Britannia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Britannia");
        }

        public ChronicleOfBritannia(Serial serial) : base(serial) { }

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
