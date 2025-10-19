using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfUruguay : WoodenChest
    {
        [Constructable]
        public TreasureChestOfUruguay()
        {
            Name = "Treasure Chest of Uruguay";
            Hue = 1153; // blue from the flag

            // Decorative, unique artifacts
            AddItem(CreateColoredItem<ArtifactLargeVase>("Vase of Montevideo", 1175), 0.30);
            AddItem(CreateColoredItem<Candelabra>("Candelabra of Carnaval", 1369), 0.25);
            AddItem(CreateColoredItem<Painting1WestArtifact>("Portrait of Artigas", 1150), 0.20);
            AddItem(CreateNamedItem<WolfStatue>("Statue of the Pampas Wolf"), 0.15);
            AddItem(CreateColoredItem<FancyMirror>("Mirror of the Río de la Plata", 1152), 0.10);
            AddItem(CreateColoredItem<FlowersArtifact>("Bouquet of Ceibo Blossoms", 46), 0.12);

            // Unique consumables/food
            AddItem(CreateColoredItem<GreenTea>("Yerba Mate Gourd", 68), 0.18);
            AddItem(CreateNamedItem<Cake>("Dulce de Leche Cake"), 0.15);
            AddItem(CreateColoredItem<RandomFancyFish>("River Fish Platter", 94), 0.12);
            AddItem(CreateColoredItem<RandomDrink>("Uruguayan Tannat Wine", 1641), 0.09);
            AddItem(CreateColoredItem<RandomFancyCheese>("Queso Colonia", 1141), 0.08);

            // Lore/Map
            AddItem(new LibroDeLaOrientalRepública(), 1.0);
            AddItem(CreateMap(), 0.10);

            // Themed gear: Clothing
            AddItem(CreateNationalCloak(), 0.18);
            AddItem(CreateCarnavalMask(), 0.14);

            // Themed gear: Armor
            AddItem(CreateHistoricArmor(), 0.15);

            // Themed gear: Weapons
            AddItem(CreateArtigasSaber(), 0.13);
            AddItem(CreateGauchoLazo(), 0.14);

            // Bonus: gold, special coin
            AddItem(CreateGoldItem("Uruguayan Sun Coin"), 0.13);
            AddItem(new Gold(Utility.Random(500, 3500)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
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
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Eastern Republic";
            map.Bounds = new Rectangle2D(1000, 2500, 500, 400);
            map.NewPin = new Point2D(1250, 2750);
            map.Protected = true;
            return map;
        }

        // Powerful, themed equipment:

        private Item CreateNationalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Oriental Sun";
            cloak.Hue = 1153; // Sky blue
            cloak.Attributes.Luck = 80;
            cloak.Attributes.BonusHits = 20;
            cloak.Attributes.RegenStam = 3;
            cloak.Attributes.RegenMana = 2;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateCarnavalMask()
        {
            HornedTribalMask mask = new HornedTribalMask();
            mask.Name = "Carnaval Mask of Montevideo";
            mask.Hue = Utility.RandomList(1365, 1369, 1153, 1141, 46);
            mask.Attributes.BonusDex = 15;
            mask.Attributes.NightSight = 1;
            mask.Attributes.LowerManaCost = 8;
            mask.SkillBonuses.SetValues(0, SkillName.Provocation, 15.0);
            mask.SkillBonuses.SetValues(1, SkillName.Musicianship, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateHistoricArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Armor of the Charrúa Spirit";
            chest.Hue = 1175;
            chest.Attributes.BonusStr = 15;
            chest.Attributes.DefendChance = 8;
            chest.ArmorAttributes.SelfRepair = 5;
            chest.Attributes.RegenHits = 3;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateArtigasSaber()
        {
            Broadsword saber = new Broadsword();
            saber.Name = "General Artigas’ Saber";
            saber.Hue = 1152;
            saber.Attributes.AttackChance = 15;
            saber.Attributes.WeaponSpeed = 18;
            saber.Attributes.WeaponDamage = 28;
            saber.Attributes.LowerRegCost = 10;
            saber.WeaponAttributes.HitLeechHits = 20;
            saber.WeaponAttributes.HitFireball = 15;
            saber.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            saber.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0); // Custom skill if you have it!
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        private Item CreateGauchoLazo()
        {
            Whip lazo = new Whip();
            lazo.Name = "Gaucho’s Silver Lazo";
            lazo.Hue = 1141;
            return lazo;
        }

        public TreasureChestOfUruguay(Serial serial) : base(serial) { }

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

    // Custom Lore Book for Uruguay
    public class LibroDeLaOrientalRepública : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Libro de la Oriental República", "Anónimo",
            new BookPageInfo
            (
                "In the land between rivers,",
                "where the silver flows to",
                "the sea, arose the nation",
                "of Uruguay. Its soil,",
                "once walked by Charrúa",
                "warriors, would see",
                "empires come and go."
            ),
            new BookPageInfo
            (
                "Here, the Spanish built",
                "Montevideo as a fortress,",
                "while across the water",
                "Buenos Aires watched.",
                "Smugglers and rebels",
                "traded beneath the flag",
                "of the Sun."
            ),
            new BookPageInfo
            (
                "From the plains rode",
                "Gauchos, wild and free.",
                "Artigas, father of the",
                "nation, dreamed of a",
                "land for all—farmers,",
                "freed slaves, and",
                "wanderers alike."
            ),
            new BookPageInfo
            (
                "Through wars for",
                "independence, the",
                "Eastern Republic stood.",
                "Her colors—sky blue,",
                "white, and the golden",
                "sun—were stitched with",
                "hope, unity, and courage."
            ),
            new BookPageInfo
            (
                "From the tango halls",
                "of Montevideo to the",
                "carnival streets, Uruguay",
                "sings with pride. Football,",
                "mate, and the ceibo bloom",
                "are woven into the story",
                "of her people."
            ),
            new BookPageInfo
            (
                "Let this chest hold",
                "treasures of history and",
                "memory—of ancient",
                "spirits, bold leaders, and",
                "the enduring light of the",
                "Oriental Sun."
            ),
            new BookPageInfo
            (
                "To those who open this,",
                "remember: the heart of",
                "Uruguay beats on the",
                "pampas, and in all who",
                "cherish liberty and joy.",
                "",
                "- Written in Montevideo",
                "in the year of the Sun."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LibroDeLaOrientalRepública() : base(false)
        {
            Hue = 1153;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Libro de la Oriental República");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Libro de la Oriental República");
        }

        public LibroDeLaOrientalRepública(Serial serial) : base(serial) { }

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
