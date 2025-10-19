using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfElSalvadorHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfElSalvadorHistory()
        {
            Name = "Treasure Chest of El Salvador's History";
            Hue = 2101; // Rich volcanic earth color

            // Add unique items
            AddItem(new RandomFancyStatue(), 0.13);
            AddItem(CreateColoredItem<AcademicBooksArtifact>("Ancient Codex of Cuzcatlán", 1175), 0.15);
            AddItem(CreateNamedItem<BottleArtifact>("Bottle of Volcanic Elixir"), 0.12);
            AddItem(CreateColoredItem<BasketOfGreenTeaMug>("Cup of Salvadoran Café", 2716), 0.10);
            AddItem(CreateNamedItem<GoldBracelet>("Revolutionary's Gold Cuff"), 0.14);
            AddItem(CreateMap(), 0.05);
            AddItem(new ChroniclesOfElSalvador(), 1.0);
            AddItem(CreateGoldItem("Colón Coin"), 0.20);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Maya Warrior", 263), 0.18);
            AddItem(CreateNamedItem<FeatheredHat>("Indigo Indigo Feathery Hat"), 0.08);
            AddItem(CreateColoredItem<WolfStatue>("Statue of El Cadejo", 902), 0.10);
            AddItem(CreateNamedItem<Sextant>("Navigator's Sextant of La Libertad"), 0.14);
            AddItem(CreateNamedItem<GreaterHealPotion>("Flor de Izote Potion"), 0.13);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.17);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateShield(), 0.15);
            AddItem(CreateLegendaryCornTamale(), 0.12);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Unique decorative item
        private Item JadeJaguarStatue()
        {
            ArtifactVase jaguar = new ArtifactVase();
            jaguar.Name = "Jade Jaguar of the Maya";
            jaguar.Hue = 1427;
            return jaguar;
        }

        // Generic colored/named item helpers
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Ancient Cuzcatlán";
            map.Bounds = new Rectangle2D(1500, 1100, 300, 320);
            map.NewPin = new Point2D(1625, 1210);
            map.Protected = true;
            return map;
        }

        // Unique Clothing
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Cloak of the Lenca Priestess";
            robe.Hue = 1369;
            robe.Attributes.Luck = 30;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.RegenMana = 3;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Unique Armor
        private Item CreateArmor()
        {
            DragonChest armor = new DragonChest();
            armor.Name = "Volcanic Scale Breastplate";
            armor.Hue = 1175;
            armor.BaseArmorRating = 54;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.ReflectPhysical = 8;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.FireBonus = 15;
            armor.PhysicalBonus = 7;
            armor.EnergyBonus = 8;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique Shield
        private Item CreateShield()
        {
            OrderShield shield = new OrderShield();
            shield.Name = "Shield of the Volcano God";
            shield.Hue = 2117;
            shield.Attributes.DefendChance = 10;
            shield.Attributes.RegenHits = 5;
            shield.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Unique Weapon
        private Item CreateWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Blade of the Pipil Warlord";
            weapon.Hue = 2525;
            weapon.MinDamage = 38;
            weapon.MaxDamage = 63;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.WeaponDamage = 25;
            weapon.Attributes.BonusDex = 10;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.WeaponAttributes.HitFireball = 18;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Unique Legendary Food
        private Item CreateLegendaryCornTamale()
        {
            Cake tamale = new Cake();
            tamale.Name = "Legendary Corn Tamale";
            tamale.Hue = 1190;
            return tamale;
        }

        public TreasureChestOfElSalvadorHistory(Serial serial) : base(serial) { }

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
    public class ChroniclesOfElSalvador : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of El Salvador", "Historian of Cuzcatlán",
            new BookPageInfo
            (
                "Land of volcanoes, rivers, and",
                "ancient voices—this is",
                "El Salvador. Before the",
                "Spaniards came, Cuzcatlán,",
                "the 'Place of Jewels', was",
                "ruled by the Pipil and",
                "Lenca peoples. Their pyramids",
                "still rise in the dawn mist."
            ),
            new BookPageInfo
            (
                "The Maya called it 'home of",
                "the jaguar.' Their stone",
                "cities once echoed with ritual,",
                "commerce, and war. The land",
                "was fertile, fed by fire and",
                "flood, by the ash of mighty",
                "volcanoes.",
                ""
            ),
            new BookPageInfo
            (
                "In 1524, Pedro de Alvarado",
                "invaded. The Pipil resisted",
                "with obsidian blades and iron",
                "will, but Cuzcatlán fell.",
                "A new age began, marked by",
                "gold and conquest, and the",
                "cry for freedom never ceased.",
                ""
            ),
            new BookPageInfo
            (
                "Through centuries, the people",
                "fought for their land: the",
                "revolt of 1832, the rebellion",
                "of 1932, the long civil war.",
                "El Salvador endured.",
                "",
                "The land is small, but the",
                "spirit is vast."
            ),
            new BookPageInfo
            (
                "From jaguar to volcano,",
                "from cacao to coffee,",
                "from ancient pyramids",
                "to modern cities—El Salvador",
                "remembers, survives,",
                "and dreams anew.",
                "",
                "- Custodian of History",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfElSalvador() : base(false)
        {
            Hue = 1426; // Lush green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of El Salvador");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of El Salvador");
        }

        public ChroniclesOfElSalvador(Serial serial) : base(serial) { }

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
