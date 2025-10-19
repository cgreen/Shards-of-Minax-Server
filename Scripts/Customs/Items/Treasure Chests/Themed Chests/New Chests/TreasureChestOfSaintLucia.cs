using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSaintLucia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSaintLucia()
        {
            Name = "Treasure Chest of Saint Lucia";
            Hue = 1260 + Utility.Random(1, 200); // Azure-blue like the Caribbean sea

            // Add themed treasures!
            AddItem(CreateNamedItem<BakeKitsuneStatue>("Pitons Guardian Statuette", 1368), 0.15);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Vase of Soufrière Ash", 1150), 0.11);
            AddItem(CreateNamedItem<GreenTea>("Calabash Tea of the Elders", 1287), 0.15);
            AddItem(CreateNamedItem<Apple>("Golden Cashew Fruit", 1402), 0.12);
            AddItem(CreateNamedItem<QuarterStaff>("Sugarcane Staff of Prosperity", 1426), 0.09);
            AddItem(CreateNamedItem<Gold>("Ancient Pirate Doubloons", 1171), 0.19);
            AddItem(CreateNamedItem<BottleArtifact>("Rum Bottle of Gros Islet", 1207), 0.15);
            AddItem(CreateNamedItem<RandomFancyCoin>("French Colonial Écu", 1191), 0.11);
            AddItem(CreateNamedItem<RandomFancyBanner>("Banner of the Pitons", 1368), 0.08);
            AddItem(CreateNamedItem<JewelryBox>("Jewelry Box of Voodoo Relics", 1400), 0.10);
            AddItem(CreateNamedItem<CrystalBallStatuette>("Caribbean Diviner's Orb", 1269), 0.09);
            AddItem(CreateNamedItem<WhiteTigerFigurine>("Lucian Wildcat Figurine", 1177), 0.06);
            AddItem(new ChroniclesOfSaintLucia(), 1.0);

            // Equipment
            AddItem(CreateHat(), 0.18);
            AddItem(CreatePirateSaber(), 0.16);
            AddItem(CreateNavigatorCloak(), 0.15);
            AddItem(CreateSpiritCharm(), 0.14);
            AddItem(CreateSeaBoots(), 0.18);
            AddItem(CreateVoodooRobe(), 0.11);

            // Consumables & Food
            AddItem(CreateNamedItem<SackOfSugar>("Sack of Lucian Cane Sugar", 1302), 0.15);
            AddItem(CreateNamedItem<GreenTea>("Herbal Elixir of the Rainforest", 1372), 0.14);
            AddItem(CreateNamedItem<FruitBasket>("Exotic Island Fruit Basket", 1267), 0.14);
            AddItem(CreateNamedItem<BottleArtifact>("Potion of the Sulphur Springs", 1365), 0.08);

            // Map to Treasure (bonus item)
            AddItem(CreateTreasureMap(), 0.08);
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

        // Equipment methods

        private Item CreateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Buccaneer's Tricorne of the Windward Coast";
            hat.Hue = 1175; // Deep blue
            hat.Attributes.Luck = 40;
            hat.Attributes.BonusDex = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Cartography, 20.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreatePirateSaber()
        {
            Cutlass saber = new Cutlass();
            saber.Name = "Pirate Sabre of Marigot Bay";
            saber.Hue = 1278; // Oceanic steel
            saber.MinDamage = Utility.Random(25, 40);
            saber.MaxDamage = Utility.Random(45, 60);
            saber.Attributes.WeaponDamage = 20;
            saber.Attributes.AttackChance = 15;
            saber.WeaponAttributes.HitLeechHits = 15;
            saber.WeaponAttributes.HitLightning = 20;
            saber.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            saber.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        private Item CreateNavigatorCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Navigator’s Cloak of the Azure Isles";
            cloak.Hue = 1367; // Vivid sea-blue
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusInt = 10;
            cloak.Attributes.LowerManaCost = 15;
            cloak.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateSpiritCharm()
        {
            GoldBracelet charm = new GoldBracelet();
            charm.Name = "Voodoo Charm of the Ancestors";
            charm.Hue = 1407;
            charm.Attributes.CastRecovery = 2;
            charm.Attributes.SpellChanneling = 1;
            charm.Attributes.BonusMana = 8;
            charm.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            charm.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(charm, new XmlLevelItem());
            return charm;
        }

        private Item CreateSeaBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Salt-Stained Sea Boots";
            boots.Hue = 1209;
            boots.Attributes.BonusStam = 12;
            boots.Attributes.LowerRegCost = 10;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            boots.SkillBonuses.SetValues(1, SkillName.Fishing, 15.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateVoodooRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Lucian Obeah";
            robe.Hue = 1345; // Mystic purple
            robe.Attributes.LowerManaCost = 18;
            robe.Attributes.LowerRegCost = 10;
            robe.Attributes.BonusMana = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Special Treasure Map
        private Item CreateTreasureMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Hidden Bay of Diamonds";
            map.Bounds = new Rectangle2D(5100, 1150, 300, 300);
            map.NewPin = new Point2D(5232, 1289);
            map.Protected = true;
            return map;
        }

        // Lore Book
        public class ChroniclesOfSaintLucia : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of the Jewel of the Caribbean", "Capt. Lucille Dubois",
                new BookPageInfo
                (
                    "I have sailed the blue waters",
                    "of Saint Lucia, a land of",
                    "untamed beauty and stormy",
                    "past. The twin Pitons rise",
                    "above emerald rainforests,",
                    "home to parrots and spirits",
                    "of the old Kalinago tribes."
                ),
                new BookPageInfo
                (
                    "Once the Kalinago fished",
                    "these bays, then French",
                    "and English flags flew,",
                    "each trying to claim her.",
                    "Pirates hid treasures in",
                    "her coves, voodoo priests",
                    "whispered to volcano gods."
                ),
                new BookPageInfo
                (
                    "Sugar cane fields, sweet",
                    "and bitter, fueled gold",
                    "and pain. From Castries to",
                    "Soufrière, the winds carried",
                    "songs of rebellion and",
                    "hope, and the stories of",
                    "freedom-seekers, bold as fire."
                ),
                new BookPageInfo
                (
                    "In secret, maroon bands",
                    "hid in the hills, guarding",
                    "amulets of bone and gold.",
                    "Sailors feared the 'Lucian",
                    "Lights'—ghosts dancing on",
                    "the surf—said to lead lost",
                    "ships to hidden bays."
                ),
                new BookPageInfo
                (
                    "If you read this, you",
                    "hold the wealth of an",
                    "island born in flame and",
                    "battle. Tread lightly, for",
                    "not all spirits rest, and",
                    "the heart of Saint Lucia",
                    "never truly yields."
                ),
                new BookPageInfo
                (
                    "May the wind favor you.",
                    "—Capt. Lucille Dubois"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfSaintLucia() : base(false)
            {
                Hue = 1175; // Gold-embossed cover
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of the Jewel of the Caribbean");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of the Jewel of the Caribbean");
            }

            public ChroniclesOfSaintLucia(Serial serial) : base(serial) { }

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

        public TreasureChestOfSaintLucia(Serial serial) : base(serial)
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
}
