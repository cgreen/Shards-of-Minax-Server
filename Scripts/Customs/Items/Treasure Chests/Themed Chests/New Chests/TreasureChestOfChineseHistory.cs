using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfChineseHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfChineseHistory()
        {
            Name = "Chest of the Celestial Empire";
            Hue = 2117; // Imperial red-gold

            // Add themed treasures
            AddItem(CreateColoredItem<ArtifactVase>("Ming Dynasty Porcelain Vase", 1152), 0.20);
            AddItem(CreateColoredItem<IncenseBurner>("Confucian Incense Burner", 2724), 0.18);
            AddItem(CreateColoredItem<GoldBricks>("Great Wall Stone Relic", 242), 0.15);
            AddItem(CreateNamedItem<MaxxiaScroll>("Scroll of the Dao"), 0.09);
            AddItem(CreateNamedItem<PhilosophersHat>("Hat of Laozi"), 0.06);
            AddItem(CreateNamedItem<GoldBracelet>("Empress Dowager’s Jade Bracelet"), 0.14);
            AddItem(CreateColoredItem<FanWestArtifact>("Fan of the Four Beauties", 1272), 0.19);
            AddItem(CreateNamedItem<BentoBox>("Imperial Dragon Bento Box"), 0.11);
            AddItem(CreateNamedItem<BowlOfRotwormStew>("Han Dynasty Feast Bowl"), 0.10);
            AddItem(CreateNamedItem<RandomFancyCoin>("Song Dynasty Copper Coin"), 0.22);
            AddItem(CreateColoredItem<SavageMask>("Mask of the Beijing Opera", 1870), 0.13);
            AddItem(CreateColoredItem<DragonLamp>("Dragon Lantern of the Tang", 1160), 0.15);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateCloak(), 0.22);
            AddItem(CreateKasa(), 0.18);
            AddItem(CreateSkillCloth(), 0.21);
            AddItem(CreateConsumable(), 0.20);
            AddItem(CreateMap(), 0.06);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative/themed
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

        // Book of lore
        private Item CreateLoreBook()
        {
            return new CelestialChronicle();
        }

        // Map to a legendary site
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Imperial Palace";
            map.Bounds = new Rectangle2D(1320, 1780, 800, 800);
            map.NewPin = new Point2D(1550, 1980);
            map.Protected = true;
            return map;
        }

        // Unique consumable (elixir/tea)
        private Item CreateConsumable()
        {
            GreaterHealPotion tea = new GreaterHealPotion();
            tea.Name = "Sage’s Longevity Tea";
            tea.Hue = 2968; // Emerald
            tea.Stackable = true;
            return tea;
        }

        // Epic weapon: “Sword of Yellow Emperor”
        private Item CreateWeapon()
        {
            Katana sword = new Katana();
            sword.Name = "Xuanyuan’s Blade";
            sword.Hue = 1154; // Jade
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusHits = 20;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitLowerDefend = 15;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Epic armor: “Armor of the Terracotta General”
        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Terracotta General";
            armor.Hue = 1821; // Terracotta orange-brown
            armor.Attributes.BonusHits = 25;
            armor.Attributes.DefendChance = 10;
            armor.Attributes.LowerManaCost = 10;
            armor.BaseArmorRating = 50;
            armor.PhysicalBonus = 15;
            armor.FireBonus = 10;
            armor.ColdBonus = 8;
            armor.PoisonBonus = 8;
            armor.EnergyBonus = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Themed cloak
        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Silk Road";
            cloak.Hue = 1370; // Silky golden-red
            cloak.Attributes.Luck = 35;
            cloak.Attributes.RegenStam = 3;
            cloak.Attributes.BonusDex = 5;
            cloak.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Themed kasa (scholar’s hat)
        private Item CreateKasa()
        {
            Kasa kasa = new Kasa();
            kasa.Name = "Scholar’s Bamboo Kasa";
            kasa.Hue = 1844;
            kasa.Attributes.BonusInt = 10;
            kasa.Attributes.RegenMana = 3;
            kasa.SkillBonuses.SetValues(0, SkillName.Inscribe, 12.0);
            kasa.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            XmlAttach.AttachTo(kasa, new XmlLevelItem());
            return kasa;
        }

        // Themed cloth: “Robe of Han Alchemy”
        private Item CreateSkillCloth()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of Han Alchemy";
            robe.Hue = 1150;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.CastSpeed = 2;
            robe.SkillBonuses.SetValues(0, SkillName.Alchemy, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Required constructor and serialization
        public TreasureChestOfChineseHistory(Serial serial) : base(serial) { }

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

    // Book of Lore
    public class CelestialChronicle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Celestial Empire", "Anonymous Historian",
            new BookPageInfo
            (
                "To open this chest is to touch",
                "the living history of China.",
                "From the Yellow Emperor's mythic",
                "battles on the plains, to the",
                "towering walls and silent armies",
                "of Qin, to the scrolls of wise",
                "philosophers and the silk of",
                "a thousand caravans, you hold it all."
            ),
            new BookPageInfo
            (
                "In the dawn of ages, Xuanyuan",
                "the Yellow Emperor forged the",
                "first tribes into a nation. From",
                "him descended rulers of bronze,",
                "iron, jade, and blood. Through",
                "famine and flood, the people",
                "endured, learning the secrets",
                "of silk, of tea, of writing."
            ),
            new BookPageInfo
            (
                "Zhou kings knelt before Heaven,",
                "proclaiming the Mandate that would",
                "outlast even dynasties. Great",
                "Confucius spoke of virtue and",
                "order. Laozi wrote of the Dao,",
                "the flowing Way. Armies clashed,",
                "unifying and breaking the land,",
                "as cycles turned eternal."
            ),
            new BookPageInfo
            (
                "The First Emperor, relentless,",
                "unified the realm and built walls",
                "so vast they rival clouds. Terracotta",
                "soldiers sleep beneath the earth,",
                "and their emperor’s shadow falls",
                "still across time.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Dynasties rose and fell—Han’s golden",
                "age of invention, Tang’s silk-robed",
                "splendor, Song’s cities of poets and",
                "merchants, Ming’s voyages beyond the",
                "horizon, Qing’s dragon banners in the",
                "wind.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Yet always, beneath emperors and",
                "soldiers, the people toiled and dreamed:",
                "farmers beneath rice moons, scholars at",
                "ink-stained desks, travelers on the",
                "Silk Road, seeking wisdom, fortune,",
                "or peace.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "If you read this, know that the",
                "spirit of the Celestial Empire is",
                "not held in stone, or gold, or silk,",
                "but in memory, and hope, and the",
                "echoes of all who called this land",
                "home.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let the treasures within inspire you,",
                "and may you walk your own path of",
                "heaven and earth.",
                "",
                "- The Historian"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public CelestialChronicle() : base(false)
        {
            Hue = 1152; // Elegant jade-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Celestial Empire");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Celestial Empire");
        }

        public CelestialChronicle(Serial serial) : base(serial) { }

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
