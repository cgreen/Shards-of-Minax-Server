using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSouthAfricanLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSouthAfricanLegends()
        {
            Name = "Treasure Chest of South African Legends";
            Hue = 2657; // Gold/green for SA

            // Add themed items to the chest
            AddItem(new MapungubweGoldenRhino(), 0.07);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Protea Flower Vase", 1166), 0.16);
            AddItem(CreateDecorativeItem<WolfStatue>("Lion of the Cape", 2411), 0.10);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Zulu War Drum", 1107), 0.13);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Table Mountain Crystal", 1109), 0.14);
            AddItem(CreateDecorativeItem<BooksWestArtifact>("Diary of a Trekker", 1153), 0.10);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Khoisan Rock Art Sculpture", 2117), 0.11);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Boer Pioneer"), 0.15);
            AddItem(CreateColoredItem<Ruby>("Ruby of Kimberley", 2076), 0.12);
            AddItem(CreateConsumable<GreaterHealPotion>("Elixir of the Drakensberg", 1267), 0.18);
            AddItem(CreateConsumable<RandomFancyFish>("Bushman's Restorative Biltong", 2413), 0.20);
            AddItem(CreateDecorativeItem<Painting4NorthArtifact>("Mandela’s Smile Painting", 1161), 0.09);
            AddItem(CreateColoredItem<Gold>("Krugerrand Coin", 1366), 0.22);
            AddItem(CreateUniqueCape(), 0.14);
            AddItem(CreateUniqueShield(), 0.14);
            AddItem(CreateUniqueBoots(), 0.18);
            AddItem(CreateUniqueWeapon(), 0.18);
            AddItem(CreateUniqueArmor(), 0.15);
            AddItem(new LegendsOfTheRainbowNation(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 7000)), 0.15);
            AddItem(CreateLoreMap(), 0.06);
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
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
            if (item is BasePotion bp) bp.Stackable = true;
            return item;
        }

        private Item CreateLoreMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Gold (Johannesburg)";
            map.Bounds = new Rectangle2D(3300, 1850, 500, 500);
            map.NewPin = new Point2D(3550, 1975);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueCape()
        {
            Cloak cape = new Cloak();
            cape.Name = "Cape of the Cape Lion";
            cape.Hue = 2411;
            cape.Attributes.BonusHits = 20;
            cape.Attributes.BonusStr = 8;
            cape.Attributes.Luck = 250;
            cape.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 15.0);
            cape.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(cape, new XmlLevelItem());
            return cape;
        }

        private Item CreateUniqueShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Zulu King";
            shield.Hue = 1175;
            shield.Attributes.DefendChance = 20;
            shield.ArmorAttributes.SelfRepair = 6;
            shield.Attributes.BonusStam = 15;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            shield.Attributes.SpellChanneling = 1;
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateUniqueBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Khoisan Hunter's Boots";
            boots.Hue = 2208;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.NightSight = 1;
            boots.Attributes.RegenStam = 7;
            boots.SkillBonuses.SetValues(0, SkillName.Tracking, 18.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            boots.Attributes.LowerManaCost = 7;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateUniqueWeapon()
        {
            Spear spear = new Spear();
            spear.Name = "Assegai of Shaka Zulu";
            spear.Hue = 1258;
            spear.MinDamage = 32;
            spear.MaxDamage = 68;
            spear.WeaponAttributes.HitFireball = 18;
            spear.WeaponAttributes.HitLeechStam = 15;
            spear.Attributes.WeaponSpeed = 15;
            spear.Attributes.BonusStr = 7;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of the Voortrekker";
            armor.Hue = 1102;
            armor.BaseArmorRating = 55;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusInt = 5;
            armor.Attributes.ReflectPhysical = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        public TreasureChestOfSouthAfricanLegends(Serial serial) : base(serial) { }

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

    // Unique decorative item: Mapungubwe Golden Rhino (historical artifact!)
    public class MapungubweGoldenRhino : StatueSouth
    {
        [Constructable]
        public MapungubweGoldenRhino()
        {
            Name = "Golden Rhino of Mapungubwe";
            Hue = 1175; // bright gold
            LootType = LootType.Blessed;
        }
        public MapungubweGoldenRhino(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    // Lore Book: Legends of the Rainbow Nation
    public class LegendsOfTheRainbowNation : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of the Rainbow Nation", "E. T. Joubert",
            new BookPageInfo
            (
                "South Africa’s lands bear the",
                "footprints of the Khoisan,",
                "the echoes of the Bantu,",
                "the thunder of Zulu regiments,",
                "the songs of Xhosa chiefs,",
                "and the wanderings of",
                "trekking Voortrekkers.",
                "Each stone tells a tale."
            ),
            new BookPageInfo
            (
                "From Mapungubwe’s golden",
                "rhino to the legacy of",
                "the Boers, from ancient",
                "San hunter’s tracks to",
                "the roar of lions on",
                "the highveld, the land",
                "is alive with myth.",
                "Oceans border hope and strife."
            ),
            new BookPageInfo
            (
                "The Zulu King Shaka rose",
                "in thunder and storm.",
                "Cape Town blossomed at the",
                "world’s tip, Table Mountain",
                "watching over centuries of",
                "change. In Kimberley, fortunes",
                "were won with a spade.",
                "In Johannesburg, gold shaped destiny."
            ),
            new BookPageInfo
            (
                "Apartheid cast its shadow,",
                "yet hope would rise anew.",
                "From Robben Island’s walls,",
                "a lion’s heart dreamed freedom.",
                "The Rainbow Nation’s birth,",
                "not in silence, but in",
                "song: Nkosi Sikelel’ iAfrika,",
                "may peace walk these fields."
            ),
            new BookPageInfo
            (
                "Let this chest be a relic",
                "of unity and memory,",
                "each artifact a thread in",
                "our tapestry. Seek wisdom",
                "in gold, courage in struggle,",
                "and pride in diversity.",
                "For all who open it,",
                "Ubuntu awaits."
            ),
            new BookPageInfo
            (
                "‘I am because we are’—",
                "Let this knowledge guide",
                "your journey onward.",
                "",
                "",
                "",
                "- E. T. Joubert",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LegendsOfTheRainbowNation() : base(false)
        {
            Hue = 2657; // gold/green, SA colors
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of the Rainbow Nation");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of the Rainbow Nation");
        }

        public LegendsOfTheRainbowNation(Serial serial) : base(serial) { }

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
