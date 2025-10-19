using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfArgentina : WoodenChest
    {
        [Constructable]
        public TreasureChestOfArgentina()
        {
            Name = "Treasure Chest of Argentina's History";
            Hue = 1153; // Sky blue, as on the flag

            // Add themed loot
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Inca Pot of Cuzco", 2412), 0.20);
            AddItem(CreateDecorativeItem<GoldBricks>("Plata of the Río de la Plata", 2213), 0.18);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Tango Dancers' Statue", 1369), 0.20);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Painting of the Pampas", 1160), 0.22);
            AddItem(CreateDecorativeItem<WhiteTigerFigurine>("Jaguar Totem of the Guarani", 1150), 0.12);
            AddItem(CreateConsumableItem<GreenTea>("Yerba Mate Gourd", 1170), 0.30);
            AddItem(CreateConsumableItem<Bottle>("Malbec Wine Bottle", 33), 0.18);
            AddItem(CreateConsumableItem<PulledPorkSandwich>("Choripán Sandwich", 0), 0.18);
            AddItem(CreateGoldItem("Old Peso Coin"), 0.17);
            AddItem(CreateSpecialCloak(), 0.15);
            AddItem(CreateGauchoHat(), 0.16);
            AddItem(CreateLiberatorSword(), 0.20);
            AddItem(CreatePampasArmor(), 0.20);
            AddItem(CreateNamedItem<Boots>("Leather Boots of the Pampas"), 0.18);
            AddItem(CreateLegendaryLasso(), 0.14);
            AddItem(CreateFolkGuitar(), 0.13);
            AddItem(new HistoriasDeLaTierraDelPlata(), 1.0);
            AddItem(CreateMap(), 0.10);
            AddItem(new Gold(Utility.Random(1000, 5000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
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
            return gold;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateSpecialCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Flag of Argentina Cloak";
            cloak.Hue = 1153; // Flag blue
            cloak.Attributes.Luck = 77;
            cloak.Attributes.BonusHits = 15;
            cloak.SkillBonuses.SetValues(0, SkillName.Peacemaking, 12.5);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateGauchoHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Gaucho’s Sombrero";
            hat.Hue = 1175; // Earthy brown
            hat.Attributes.BonusDex = 12;
            hat.Attributes.BonusStam = 7;
            hat.SkillBonuses.SetValues(0, SkillName.Herding, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            hat.SkillBonuses.SetValues(2, SkillName.AnimalLore, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateLiberatorSword()
        {
            Katana sword = new Katana();
            sword.Name = "San Martín’s Liberator Blade";
            sword.Hue = 2213; // Shiny silver
            sword.Slayer = SlayerName.DragonSlaying;
            sword.MinDamage = 28;
            sword.MaxDamage = 70;
            sword.WeaponAttributes.HitLightning = 30;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.Attributes.AttackChance = 18;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusStam = 10;
            sword.Attributes.WeaponDamage = 25;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreatePampasArmor()
        {
            LeatherChest armor = new LeatherChest();
            armor.Name = "Pampas Guardian Vest";
            armor.Hue = 2101; // Rich green
            armor.BaseArmorRating = 52;
            armor.Attributes.BonusHits = 18;
            armor.Attributes.BonusStam = 9;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            armor.SkillBonuses.SetValues(2, SkillName.Hiding, 6.0);
            armor.ColdBonus = 9;
            armor.PhysicalBonus = 18;
            armor.FireBonus = 7;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 8;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLegendaryLasso()
        {
            Bow lasso = new Bow();
            lasso.Name = "Lazo Legendario";
            lasso.Hue = 1175;
            lasso.Attributes.WeaponSpeed = 25;
            lasso.Attributes.BonusDex = 15;
            lasso.SkillBonuses.SetValues(0, SkillName.Herding, 18.0);
            lasso.SkillBonuses.SetValues(1, SkillName.Wrestling, 10.0);
            lasso.SkillBonuses.SetValues(2, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(lasso, new XmlLevelItem());
            return lasso;
        }

        private Item CreateFolkGuitar()
        {
            Lute guitar = new Lute();
            guitar.Name = "Guitarra de los Payadores";
            guitar.Hue = 1173; // Warm wood
            return guitar;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Rio de la Plata";
            map.Bounds = new Rectangle2D(3600, 1200, 700, 400);
            map.NewPin = new Point2D(3990, 1450);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfArgentina(Serial serial) : base(serial) { }

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

    // Custom Lore Book
    public class HistoriasDeLaTierraDelPlata : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Historias de la Tierra del Plata", "Escrito por el Cronista de la Pampa",
            new BookPageInfo
            (
                "Where the condor flies above",
                "the snow of the Andes, and the",
                "rivers braid the pampas,",
                "Argentina is born from earth",
                "and dream. Once ruled by",
                "the Incas and Guarani,",
                "the land witnessed conquerors",
                "from far Castile."
            ),
            new BookPageInfo
            (
                "Under the sun of May,",
                "the hearts of patriots burned.",
                "Belgrano raised a sky-blue flag,",
                "and San Martín led the charge",
                "across the mountains—",
                "not just for freedom, but for",
                "all South America.",
                ""
            ),
            new BookPageInfo
            (
                "From colonial towns and",
                "estancias, to cities born of",
                "immigrants—Italian, Spanish,",
                "German, and more—",
                "Argentina became a nation",
                "of many voices, all singing",
                "tango in the midnight air."
            ),
            new BookPageInfo
            (
                "Yet history is not just war",
                "or words. The gaucho rides",
                "still in the mist, guarding",
                "the horizon. The mate",
                "passes from hand to hand,",
                "and the future is written",
                "with every step on cobbled",
                "Buenos Aires streets."
            ),
            new BookPageInfo
            (
                "Remember, adventurer:",
                "in this chest are fragments",
                "of a land where courage and",
                "melancholy dance forever—",
                "from Aconcagua's summit",
                "to Tierra del Fuego’s last",
                "light. Carry these relics,",
                "and honor the spirit of"
            ),
            new BookPageInfo
            (
                "Argentina, land of silver",
                "and song. ¡Viva la patria!",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public HistoriasDeLaTierraDelPlata() : base(false)
        {
            Hue = 1153; // Sky blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Historias de la Tierra del Plata");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Historias de la Tierra del Plata");
        }

        public HistoriasDeLaTierraDelPlata(Serial serial) : base(serial) { }

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
