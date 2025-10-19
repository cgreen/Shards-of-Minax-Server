using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfComoros : WoodenChest
    {
        [Constructable]
        public TreasureChestOfComoros()
        {
            Name = "Lost Treasure Chest of Comoros";
            Hue = 1346; // Turquoise blue (ocean theme)

            // Add themed items to the chest
            AddItem(CreateDecorativeMask(), 0.18);
            AddItem(CreateSpiceBasket(), 0.14);
            AddItem(CreatePearlOfTheMoon(), 0.15);
            AddItem(CreateNamedItem<GreaterCurePotion>("Sultan’s Perfumed Elixir"), 0.15);
            AddItem(CreateMap(), 0.10);
            AddItem(CreatePirateSabre(), 0.21);
            AddItem(CreateExplorerBoots(), 0.19);
            AddItem(CreateRoyalSultanRobe(), 0.12);
            AddItem(CreateVolcanicAmulet(), 0.14);
            AddItem(CreateShellBracelet(), 0.20);
            AddItem(new ChroniclesOfThePerfumeIsles(), 1.0);
            AddItem(CreateGoldItem("Comorian Dinar"), 0.18);
            AddItem(CreateTropicalFruitBasket(), 0.17);
            AddItem(CreateNamedItem<GreenTea>("Island Green Tea"), 0.18);
            AddItem(CreateScentedIncense(), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Mask (reflecting African/Comorian art)
        private Item CreateDecorativeMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mahorais Ceremonial Mask";
            mask.Hue = 2101;
            mask.Attributes.BonusStr = 5;
            mask.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            return mask;
        }

        // Basket of Comorian spices
        private Item CreateSpiceBasket()
        {
            Basket1Artifact basket = new Basket1Artifact();
            basket.Name = "Basket of Ylang-Ylang & Cloves";
            basket.Hue = 2534;
            return basket;
        }

        // Unique gem
        private Item CreatePearlOfTheMoon()
        {
            Ruby pearl = new Ruby();
            pearl.Name = "Pearl of the Moon Islands";
            pearl.Hue = 1153;
            return pearl;
        }

        // Gold (Comorian Dinar)
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Custom colored/renamed item
        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        // Volcanic amulet with unique mods
        private Item CreateVolcanicAmulet()
        {
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Amulet of Karthala";
            amulet.Hue = 1326;
            amulet.Attributes.SpellDamage = 15;
            amulet.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            return amulet;
        }

        // Shell bracelet
        private Item CreateShellBracelet()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of Cowrie Shells";
            bracelet.Hue = 2413;
            bracelet.Attributes.Luck = 25;
            bracelet.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            return bracelet;
        }

        // Pirate Sabre (unique weapon)
        private Item CreatePirateSabre()
        {
            Cutlass sabre = new Cutlass();
            sabre.Name = "Sabre of the Zanzibar Pirates";
            sabre.Hue = 1156;
            sabre.MinDamage = Utility.Random(18, 34);
            sabre.MaxDamage = Utility.Random(45, 60);
            sabre.WeaponAttributes.HitHarm = 15;
            sabre.Attributes.AttackChance = 10;
            sabre.Attributes.BonusDex = 10;
            sabre.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(sabre, new XmlLevelItem());
            return sabre;
        }

        // Explorer's boots (equipment)
        private Item CreateExplorerBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Explorer’s Salt-Stained Boots";
            boots.Hue = 2208;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.RegenStam = 2;
            boots.SkillBonuses.SetValues(0, SkillName.Camping, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        // Royal robe
        private Item CreateRoyalSultanRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Comorian Sultan";
            robe.Hue = 2941;
            robe.Attributes.LowerRegCost = 18;
            robe.Attributes.BonusHits = 20;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Map to Karthala volcano
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Mount Karthala";
            map.Bounds = new Rectangle2D(1200, 2400, 500, 400);
            map.NewPin = new Point2D(1440, 2610);
            map.Protected = true;
            return map;
        }

        // Tropical fruit basket
        private Item CreateTropicalFruitBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Sultana’s Mangoes";
            basket.Hue = 1401;
            return basket;
        }

        // Scented incense
        private Item CreateScentedIncense()
        {
            IncenseBurner incense = new IncenseBurner();
            incense.Name = "Incense of the Isles";
            incense.Hue = 1358;
            return incense;
        }

        public TreasureChestOfComoros(Serial serial) : base(serial)
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

    // Custom lore book for Comoros
    public class ChroniclesOfThePerfumeIsles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Perfume Isles", "A Scribe of Nzwani",
            new BookPageInfo
            (
                "In the heart of the Indian Ocean,",
                "between the coasts of Africa and",
                "Madagascar, lie the four Perfume Isles.",
                "The world knows them as Comoros:",
                "Ngazidja, Nzwani, Mwali, and Mahore.",
                "Emerald peaks rise from the sea,",
                "fragrant with ylang-ylang, cloves, and spice."
            ),
            new BookPageInfo
            (
                "Sultans, sailors, and pirates",
                "have all claimed these shores.",
                "Arab dhows, Swahili traders,",
                "and Malagasy warriors mingled here,",
                "founding kingdoms, forging legends.",
                "In stone ruins, echoes of Shirazi sultans",
                "whisper of gold and rebellion."
            ),
            new BookPageInfo
            (
                "The Great Volcano Karthala stirs,",
                "its black earth feeding the islanders.",
                "Coconut palms sway over coral reefs.",
                "Pearls lie deep in blue lagoons,",
                "and storms bring treasures—",
                "and shipwrecks—each year."
            ),
            new BookPageInfo
            (
                "The isles were crossroads for many:",
                "Portuguese sailors, French colonists,",
                "Arab merchants, Bantu settlers.",
                "Languages blended, cultures entwined.",
                "Even now, ancient songs of the shikomori",
                "echo in village squares at dusk."
            ),
            new BookPageInfo
            (
                "Beware the ghostly pirates of Zanzibar,",
                "who once buried their loot here.",
                "Beware the wrath of the sultans,",
                "and the magic of old island shamans.",
                "To find the treasure of Comoros",
                "is to find its story—",
                "and to honor the Perfume Isles."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfThePerfumeIsles() : base(false)
        {
            Hue = 1260; // Blue-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Perfume Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Perfume Isles");
        }

        public ChroniclesOfThePerfumeIsles(Serial serial) : base(serial) { }

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
