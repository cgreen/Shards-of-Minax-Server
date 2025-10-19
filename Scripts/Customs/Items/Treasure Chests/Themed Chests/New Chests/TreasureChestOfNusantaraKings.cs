using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNusantaraKings : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNusantaraKings()
        {
            Name = "Treasure Chest of the Nusantara Kings";
            Hue = 2051; // Deep spice-gold

            // Legendary Artifacts & Decor
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Majapahit Royal Vase", 2124), 0.25);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Borobudur Shrine Miniature", 2106), 0.18);
            AddItem(CreateDecorativeItem<JadeSkull>("Jade Skull of Sumatra", 1425), 0.16);
            AddItem(CreateDecorativeItem<StatueSouth>("Garuda Idol of Java", 1359), 0.14);
            AddItem(CreateDecorativeItem<FancyWindChimes>("Wind Chimes of the Monsoon", 1266), 0.15);
            AddItem(CreateDecorativeItem<AncientWeapon1>("Keris Relic of Singhasari", 1175), 0.22);

            // Powerful Equipment
            AddItem(CreateWeapon(), 0.30);
            AddItem(CreateArmor(), 0.28);
            AddItem(CreateClothing(), 0.28);

            // Consumables & Spices
            AddItem(CreateSpicePotion("Potion of Nutmeg and Cloves", 2063), 0.20);
            AddItem(CreateSpicePotion("Balinese Healing Salve", 1170), 0.22);
            AddItem(CreateFood("Sate Ayam Skewer", 1833), 0.19);
            AddItem(CreateFood("Sweet Jamu Elixir", 1155), 0.17);

            // Lore Book
            AddItem(new ChroniclesOfNusantara(), 1.0);

            // Exotic Coins & Gems
            AddItem(CreateUniqueCoin("Gold Rupiah of Majapahit"), 0.22);
            AddItem(CreateUniqueGem("Pearl of Sulawesi", 2598), 0.15);

            // Other
            AddItem(CreateMap(), 0.08);
            AddItem(new Gold(Utility.Random(1, 7000)), 0.12);
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

        private Item CreateUniqueCoin(string name)
        {
            Gold coin = new Gold();
            coin.Name = name;
            coin.Amount = Utility.RandomMinMax(500, 2000);
            return coin;
        }

        private Item CreateUniqueGem(string name, int hue)
        {
            Ruby gem = new Ruby();
            gem.Name = name;
            gem.Hue = hue;
            return gem;
        }

        private Item CreateSpicePotion(string name, int hue)
        {
            GreaterCurePotion potion = new GreaterCurePotion();
            potion.Name = name;
            potion.Hue = hue;
            potion.ItemID = 0xF0B; // Looks like a bottle
            return potion;
        }

        private Item CreateFood(string name, int hue)
        {
            Cake food = new Cake();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateWeapon()
        {
            // Legendary Keris (kris) dagger with massive bonuses
            Kryss kris = new Kryss();
            kris.Name = "Keris of Majapahit Kings";
            kris.Hue = 2949;
            kris.MinDamage = Utility.Random(25, 55);
            kris.MaxDamage = Utility.Random(65, 95);
            kris.WeaponAttributes.HitLightning = 25;
            kris.WeaponAttributes.HitPoisonArea = 15;
            kris.Attributes.AttackChance = 15;
            kris.Attributes.DefendChance = 12;
            kris.Attributes.BonusDex = 10;
            kris.Attributes.SpellChanneling = 1;
            kris.SkillBonuses.SetValues(0, SkillName.Poisoning, 15.0);
            kris.SkillBonuses.SetValues(1, SkillName.Fencing, 15.0);
            kris.SkillBonuses.SetValues(2, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(kris, new XmlLevelItem());
            return kris;
        }

        private Item CreateArmor()
        {
            // Royal Batik Robe
            Robe robe = new Robe();
            robe.Name = "Royal Batik Robe of Yogyakarta";
            robe.Hue = 1247;
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusInt = 12;
            robe.Attributes.RegenMana = 4;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.Tailoring, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateClothing()
        {
            // Sash of the Island Guardian
            BodySash sash = new BodySash();
            sash.Name = "Sash of the Island Guardian";
            sash.Hue = 2587;
            sash.Attributes.NightSight = 1;
            sash.Attributes.BonusHits = 18;
            sash.Attributes.RegenHits = 4;
            sash.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            sash.SkillBonuses.SetValues(2, SkillName.MagicResist, 7.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateMap()
        {
            // Map to Krakatoa's Lost Temple
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Krakatoa’s Lost Temple";
            map.Bounds = new Rectangle2D(4200, 1950, 250, 250);
            map.NewPin = new Point2D(4320, 2000);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfNusantaraKings(Serial serial) : base(serial) { }

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

    // Custom Lore Book: Chronicles of Nusantara
    public class ChroniclesOfNusantara : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Nusantara", "Sri Adityawarman",
            new BookPageInfo
            (
                "Long before the world knew",
                "the name Indonesia, islands",
                "rose like emeralds from the",
                "sea. Kingdoms flourished—",
                "Srivijaya, trading in spices",
                "and gold. Majapahit,",
                "uniting Java and beyond.",
                ""
            ),
            new BookPageInfo
            (
                "Great temples rose at Borobudur,",
                "their stones singing stories",
                "of Buddhas and kings. The Garuda",
                "soared as guardian, while kris",
                "daggers were forged with magic,",
                "their waves shimmering in ritual",
                "smoke. The gods watched from",
                "volcanoes and jungles."
            ),
            new BookPageInfo
            (
                "Mighty sultans sailed from",
                "Makassar, and spice-laden",
                "ships rode the monsoon winds.",
                "Yet, danger followed—pirates,",
                "invaders, foreign traders.",
                "But the spirit of Nusantara,",
                "the unity of islands, endured.",
                ""
            ),
            new BookPageInfo
            (
                "Seek here the treasures of",
                "the old kings: the Keris",
                "of Majapahit, the Batik",
                "of Yogyakarta, pearls from",
                "Sulawesi, and coins stamped",
                "with forgotten dynasties.",
                ""
            ),
            new BookPageInfo
            (
                "Know that some spirits of the",
                "archipelago still guard their",
                "secrets. The mountains sleep,",
                "but their fire is eternal.",
                "Remember Nusantara’s story,",
                "for within these treasures,",
                "it still lives.",
                "",
                "- Sri Adityawarman"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfNusantara() : base(false)
        {
            Hue = 1170; // Tropical blue-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Nusantara");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Nusantara");
        }

        public ChroniclesOfNusantara(Serial serial) : base(serial) { }

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
