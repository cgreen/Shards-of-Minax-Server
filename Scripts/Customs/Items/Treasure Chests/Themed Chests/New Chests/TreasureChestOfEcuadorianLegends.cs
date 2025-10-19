using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfEcuadorianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfEcuadorianLegends()
        {
            Name = "Treasure Chest of Ecuadorian Legends";
            Hue = 2075; // Emerald green, evokes Amazon and Andes

            // Add themed items
            AddItem(CreateBookOfLore(), 1.0);
            AddItem(CreateColoredItem<ArtifactVase>("Quito Gold Vase", 2213), 0.20);
            AddItem(CreateNamedItem<Gold>("Lost Sun Gold Coins"), 0.18);
            AddItem(CreateDecorativeItem<RandomFancyStatue>("Jaguar Idol of the Cañari", 1109), 0.14);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Amazon Shaman", 2002), 0.19);
            AddItem(CreateColoredItem<WolfStatue>("Statue of El Lobo de los Andes", 1152), 0.12);
            AddItem(CreateConsumablePotion(), 0.20);
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateClothing(), 0.22);
            AddItem(CreateMap(), 0.10);
            AddItem(CreateUniqueDecor(), 0.16);
            AddItem(CreateNamedItem<GreenTea>("Chimborazo Herbal Infusion"), 0.14);
            AddItem(CreateNamedItem<RandomFancyBanner>("Banner of Guayaquil Independence"), 0.10);
            AddItem(CreateColoredItem<Ruby>("Ruby of Pichincha", 2338), 0.14);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Inca Princess"), 0.17);
            AddItem(CreateUniqueConsumable(), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Book of lore: Custom Ecuadorian history
        private Item CreateBookOfLore()
        {
            return new ChroniclesOfEcuador();
        }

        // Themed map to a lost treasure site
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Atahualpa’s Hidden Tomb";
            map.Bounds = new Rectangle2D(4200, 1400, 350, 400); // Fictitious in-game coords
            map.NewPin = new Point2D(4375, 1522);
            map.Protected = true;
            return map;
        }

        // Unique weapon with spicy mods
        private Item CreateWeapon()
        {
            BaseWeapon weapon = new Scimitar();
            weapon.Name = "Crescent Blade of Chimborazo";
            weapon.Hue = 2987; // Lively volcanic red
            weapon.MaxDamage = Utility.RandomMinMax(50, 80);
            weapon.MinDamage = Utility.RandomMinMax(20, 35);
            weapon.Attributes.AttackChance = 20;
            weapon.Attributes.WeaponSpeed = 35;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusDex = 10;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.HitLowerAttack = 20;
            weapon.Slayer = SlayerName.DragonSlaying;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Unique armor, Andes theme, with magical defense
        private Item CreateArmor()
        {
            BaseArmor armor = new PlateChest();
            armor.Name = "Pectoral of the Andes";
            armor.Hue = 1153; // Misty blue
            armor.BaseArmorRating = 55;
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.ReflectPhysical = 10;
            armor.Attributes.BonusStr = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.5);
            armor.EnergyBonus = 18;
            armor.ColdBonus = 7;
            armor.PhysicalBonus = 10;
            armor.FireBonus = 7;
            armor.PoisonBonus = 13;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique clothing: magical robe, Inca style
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Sunwoven Robe of Inti";
            robe.Hue = 2120; // Bright golden yellow
            robe.Attributes.Luck = 75;
            robe.Attributes.RegenMana = 5;
            robe.Attributes.BonusInt = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            robe.Attributes.NightSight = 1;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Unique consumable: a “potion” from Amazon lore
        private Item CreateConsumablePotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Sacred Brew of Ayahuasca";
            potion.Hue = 2757;
            potion.Stackable = true;
            return potion;
        }

        // Unique powerful consumable
        private Item CreateUniqueConsumable()
        {
            GreaterCurePotion potion = new GreaterCurePotion();
            potion.Name = "Guayusa Leaf Tonic";
            potion.Hue = 1272;
            potion.Stackable = true;
            return potion;
        }

        // Generic colored item creator
        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Generic named item creator
        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        // Example decorative with unique name/hue
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique rare decorative
        private Item CreateUniqueDecor()
        {
            ArtifactVase vase = new ArtifactVase();
            vase.Name = "Huaca of the Cañari";
            vase.Hue = 2207;
            return vase;
        }

        public TreasureChestOfEcuadorianLegends(Serial serial) : base(serial) { }
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

    // Lore Book: Chronicles the history and myth of Ecuador
    public class ChroniclesOfEcuador : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Ecuador", "Taita Imbabura",
            new BookPageInfo
            (
                "In the beginning, the high",
                "Andes rose, veiled in mist,",
                "home to the Cañari and",
                "Quitu peoples. Jaguars and",
                "condors watched from the",
                "cloud forests, guardians of",
                "a land alive with power."
            ),
            new BookPageInfo
            (
                "Legends whisper of the",
                "Amazon’s endless rivers,",
                "and the fire beneath",
                "Chimborazo. The Incas",
                "came, weaving gold and",
                "blood into the soil, their",
                "king Atahualpa born of",
                "Quito’s royal line."
            ),
            new BookPageInfo
            (
                "The Spanish crossed seas,",
                "bearing iron and crosses.",
                "Cities of stone rose beside",
                "temples of the Sun. Quito",
                "was crowned with churches,",
                "Guayaquil with sails.",
                "Freedom kindled in these",
                "mountains, fierce and bright."
            ),
            new BookPageInfo
            (
                "Yet the land remembers.",
                "The Galápagos guard secrets",
                "of time. The Amazon’s",
                "breath heals and haunts.",
                "In every stone, story, and",
                "river, the old spirits endure,",
                "calling the brave to seek",
                "their treasures."
            ),
            new BookPageInfo
            (
                "May you who open this",
                "chest honor the past, and",
                "carry its magic into the",
                "world anew.",
                "",
                "- Taita Imbabura"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfEcuador() : base(false)
        {
            Hue = 2075; // Green, for the land
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Ecuador");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Ecuador");
        }

        public ChroniclesOfEcuador(Serial serial) : base(serial) { }
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
