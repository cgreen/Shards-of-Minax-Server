using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSaoTomeAndPrincipe : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSaoTomeAndPrincipe()
        {
            Name = "Treasure Chest of São Tomé and Príncipe";
            Hue = 2125; // Lush island green

            // Add decorative and unique items
            AddItem(CreateNamedItem<ArtifactLargeVase>("Vase of the Cocoa Coast", 2212), 0.20);
            AddItem(CreateNamedItem<ArtifactVase>("Sugar Planter’s Urn", 2413), 0.18);
            AddItem(CreateNamedItem<BambooStoolArtifact>("Planter's Bamboo Stool", 1266), 0.17);
            AddItem(CreateNamedItem<AncientShipModelOfTheHMSCape>("Explorer’s Ship Model", 1150), 0.14);
            AddItem(CreateNamedItem<Gold>("Pirate Doubloon", 53), 0.28);
            AddItem(CreateNamedItem<DecorativeSwordWest>("Cutlass of Captain Amador", 1109), 0.15);
            AddItem(CreateNamedItem<Sculpture1Artifact>("Stone Idol of the Island Spirits", 2105), 0.11);
            AddItem(CreateNamedItem<RandomFancyCoin>("Obsolete Escudo Coin", 2418), 0.17);
            AddItem(CreateNamedItem<SeahorseStatuette>("Seahorse of the Gulf", 1287), 0.15);
            AddItem(CreateMap(), 0.06);

            // Unique consumables and foods
            AddItem(CreateNamedItem<CoffeeMug>("Colonial Coffee Cup", 2406), 0.17);
            AddItem(CreateNamedItem<GreenTea>("Island Herbal Tonic", 1572), 0.12);
            AddItem(CreateNamedItem<FruitBasket>("Tropical Fruit Basket", 1417), 0.15);
            AddItem(CreateNamedItem<Cake>("Cocoa Bean Cake", 1271), 0.08);
            AddItem(CreateNamedItem<RandomDrink>("Bottle of Rum of São Tomé", 1191), 0.12);

            // Unique and powerful equipment
            AddItem(CreateExplorerHat(), 0.18);
            AddItem(CreateNavigatorBoots(), 0.14);
            AddItem(CreatePlanterApron(), 0.16);
            AddItem(CreateIslandBlade(), 0.15);
            AddItem(CreateShellBuckler(), 0.13);

            // Unique lore book
            AddItem(new JournalOfTheIslands(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Old Navigator's Map of São Tomé";
            map.Bounds = new Rectangle2D(2100, 2500, 800, 500); // imaginary coordinates
            map.NewPin = new Point2D(2350, 2730);
            map.Protected = true;
            return map;
        }

        private Item CreateExplorerHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Explorer's Feathered Hat";
            hat.Hue = 2101;
            hat.Attributes.Luck = 35;
            hat.Attributes.BonusInt = 8;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalLore, 15.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateNavigatorBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Navigator's Boots";
            boots.Hue = 1175;
            boots.Attributes.NightSight = 1;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.RegenStam = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0); // Use a suitable skill if Seafaring doesn't exist
            boots.SkillBonuses.SetValues(1, SkillName.Fishing, 12.0);
            boots.LootType = LootType.Blessed;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreatePlanterApron()
        {
            HalfApron apron = new HalfApron();
            apron.Name = "Planter's Work Apron";
            apron.Hue = 2449;
            apron.Attributes.BonusStr = 12;
            apron.Attributes.LowerRegCost = 20;
            apron.SkillBonuses.SetValues(0, SkillName.Cooking, 15.0);
            apron.SkillBonuses.SetValues(1, SkillName.TasteID, 15.0);
            apron.SkillBonuses.SetValues(2, SkillName.Alchemy, 10.0);
            XmlAttach.AttachTo(apron, new XmlLevelItem());
            return apron;
        }

        private Item CreateIslandBlade()
        {
            Cutlass cutlass = new Cutlass();
            cutlass.Name = "Blade of the Cocoa Coast";
            cutlass.Hue = 1281;
            cutlass.MinDamage = Utility.Random(25, 45);
            cutlass.MaxDamage = Utility.Random(50, 75);
            cutlass.WeaponAttributes.HitLeechHits = 20;
            cutlass.WeaponAttributes.HitLightning = 18;
            cutlass.WeaponAttributes.UseBestSkill = 1;
            cutlass.Attributes.BonusHits = 18;
            cutlass.Attributes.AttackChance = 10;
            cutlass.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            cutlass.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(cutlass, new XmlLevelItem());
            return cutlass;
        }

        private Item CreateShellBuckler()
        {
            WoodenShield shield = new WoodenShield();
            shield.Name = "Buckler of the Sea Shell";
            shield.Hue = 2220;
            shield.ArmorAttributes.SelfRepair = 5;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusStam = 7;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            shield.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfSaoTomeAndPrincipe(Serial serial) : base(serial) { }

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

    public class JournalOfTheIslands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Journal of the Islands", "Gaspar, Explorer of Portugal",
            new BookPageInfo
            (
                "Year of Our Lord 1485,",
                "Upon the emerald waves,",
                "we first glimpsed São Tomé—",
                "a land shrouded in mist,",
                "ringed by black volcanic",
                "stone, fragrant with spice,",
                "cocoa, and hope. Here, we",
                "set foot, and history began."
            ),
            new BookPageInfo
            (
                "Sugar was the first gold;",
                "fields swept the hills. Slaves",
                "from distant coasts wept in",
                "chains beneath the sun,",
                "and the Portuguese built",
                "their fortunes on tears.",
                "The land changed hands—",
                "explorers, pirates, kings."
            ),
            new BookPageInfo
            (
                "The cocoa trees rose",
                "from volcanic soil,",
                "dark pods rich as dreams.",
                "Pirates haunted the shores,",
                "and whispers of freedom",
                "echoed from the forests,",
                "led by Amador the brave.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Now, as dawn gilds these",
                "islands, the wounds of the",
                "past slowly heal. São Tomé",
                "and Príncipe stand together—",
                "a tapestry of peoples,",
                "winds, waves, and cocoa.",
                "May this chest serve as",
                "reminder: every treasure"
            ),
            new BookPageInfo
            (
                "is born of struggle and hope.",
                "May you carry the memory",
                "of these islands wherever",
                "the tide may take you.",
                "",
                "",
                "- Gaspar",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public JournalOfTheIslands() : base(false)
        {
            Hue = 1570; // Deep ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Journal of the Islands");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Journal of the Islands");
        }

        public JournalOfTheIslands(Serial serial) : base(serial) { }

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
