using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMozambiqueHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMozambiqueHistory()
        {
            Name = "Treasure Chest of Mozambique’s History";
            Hue = 1161; // Deep turquoise, reminiscent of Indian Ocean coastline

            // Add items to the chest
            AddItem(CreateColoredItem<ArtifactLargeVase>("Makonde Ancestral Vase", 1369), 0.20);
            AddItem(CreateColoredItem<CrabBushel>("Indian Ocean Crab Basket", 2065), 0.18);
            AddItem(CreateColoredItem<GrapeVine>("Zambezi River Grapevine", 1425), 0.12);
            AddItem(CreateColoredItem<Bananas>("Island Bananas", 340), 0.10);
            AddItem(CreateColoredItem<Gold>("Manica Gold Coin", 2213), 0.22);
            AddItem(CreateNamedItem<IncenseBurner>("Swahili Incense Burner"), 0.16);
            AddItem(CreateColoredItem<Sculpture1Artifact>("Makua Wood Sculpture", 2122), 0.17);
            AddItem(CreateColoredItem<ArtisanHolidayTree>("Baobab Bonsai", 2003), 0.10);
            AddItem(CreateColoredItem<Basket2Artifact>("Basket of Maputo Spices", 2510), 0.21);
            AddItem(CreateColoredItem<GreenTea>("Chá Verde of Ilha de Moçambique", 1269), 0.19);

            // Unique Mozambique-themed gear
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateTribalMask(), 0.15);

            // Consumables
            AddItem(CreateColoredItem<RandomFancyPotion>("Potion of the Limpopo Spirit", 2217), 0.20);
            AddItem(CreateColoredItem<FruitBasket>("Tropical Fruit Basket", 247), 0.16);
            AddItem(CreateColoredItem<RedBeaker>("Beaker of Cassava Brew", 1358), 0.15);
            AddItem(CreateNamedItem<HotCocoaMug>("Matapa Cocoa Mug"), 0.12);

            // Lore book
            AddItem(new ChroniclesOfMozambique(), 1.0);

            // Map to Ilha de Moçambique
            AddItem(CreateMap(), 0.10);

            // Coin
            AddItem(CreateGoldItem("Historic Escudo Coin"), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

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
            map.Name = "Map of Ilha de Moçambique";
            map.Bounds = new Rectangle2D(2900, 1200, 350, 350); // Example coordinates
            map.NewPin = new Point2D(2970, 1280);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Legendary Spear of Ngungunhane
            Spear weapon = new Spear();
            weapon.Name = "Ngungunhane’s Lion Spear";
            weapon.Hue = 1175; // golden
            weapon.MinDamage = 40;
            weapon.MaxDamage = 85;
            weapon.Attributes.BonusStr = 20;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.BonusHits = 30;
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitLeechStam = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Parry, 10.0);
            weapon.Slayer = SlayerName.ReptilianDeath; // For legendary status!
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // PlateChest: Armor of the Ilha Warrior
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Ilha Warrior";
            armor.Hue = 2101; // Copper/bronze
            armor.BaseArmorRating = 65;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusDex = 5;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Macing, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            armor.AbsorptionAttributes.EaterFire = 10;
            armor.AbsorptionAttributes.EaterCold = 10;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Colorful Kilt: Capulana of the Chopi
            FancyKilt kilt = new FancyKilt();
            kilt.Name = "Capulana of the Chopi";
            kilt.Hue = 2520; // Vibrant multicolor
            kilt.Attributes.Luck = 50;
            kilt.Attributes.BonusMana = 10;
            kilt.Attributes.RegenMana = 2;
            kilt.SkillBonuses.SetValues(0, SkillName.Musicianship, 20.0);
            kilt.SkillBonuses.SetValues(1, SkillName.Peacemaking, 15.0);
            XmlAttach.AttachTo(kilt, new XmlLevelItem());
            return kilt;
        }

        private Item CreateTribalMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Makonde Spirit Mask";
            mask.Hue = 1257; // Wood/bone color
            mask.Attributes.BonusInt = 15;
            mask.Attributes.NightSight = 1;
            mask.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            mask.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        public TreasureChestOfMozambiqueHistory(Serial serial) : base(serial)
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

    // Lore Book: Chronicles of Mozambique
    public class ChroniclesOfMozambique : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Mozambique", "Historiador de Sofala",
            new BookPageInfo
            (
                "From the ancient sands",
                "of Sofala to the lush",
                "banks of the Zambezi,",
                "Mozambique’s story is",
                "woven with gold, spice,",
                "and the spirits of",
                "warriors and sailors.",
                "Kingdoms flourished"
            ),
            new BookPageInfo
            (
                "along the coast, trading",
                "ivory and iron with",
                "Persians and Arabs.",
                "In the time of Great",
                "Zimbabwe, the port of",
                "Sofala glittered with",
                "gold, ruled by Swahili",
                "sultans and Makua kings."
            ),
            new BookPageInfo
            (
                "Then came the",
                "Portuguese caravels,",
                "led by Vasco da Gama,",
                "seeking the riches of",
                "India. Forts rose at",
                "Ilha de Moçambique,",
                "and traders from Goa,",
                "Lisbon, and the world."
            ),
            new BookPageInfo
            (
                "Centuries passed in the",
                "shadow of empires.",
                "Nguni migrations swept",
                "south, forging new",
                "dynasties. The Gaza",
                "Empire grew under the",
                "lion king, Ngungunhane.",
                "Rebellion brewed."
            ),
            new BookPageInfo
            (
                "Freedom called from the",
                "forests and rivers.",
                "Resistance flared in",
                "the north and south.",
                "Samora Machel led the",
                "fight, and the flag",
                "rose anew in 1975.",
                "Mozambique was free."
            ),
            new BookPageInfo
            (
                "Today, the baobabs",
                "still stand watch over",
                "the land. The drum and",
                "marimba echo through",
                "the markets of Maputo.",
                "Remember our story:",
                "a tapestry of hope,",
                "struggle, and sea."
            ),
            new BookPageInfo
            (
                "Let those who find",
                "this chest carry these",
                "treasures with respect.",
                "For Mozambique’s spirit",
                "is in every coin, mask,",
                "and page. Ashé!",
                "",
                "- The Scribe of Sofala"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfMozambique() : base(false)
        {
            Hue = 1269; // Green-blue of the Mozambique flag
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Mozambique");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Mozambique");
        }

        public ChroniclesOfMozambique(Serial serial) : base(serial) { }

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
