using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLusitanianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLusitanianLegends()
        {
            Name = "Treasure Chest of Lusitanian Legends";
            Hue = 1173; // Blue & white, for Azulejo tiles

            AddItem(CreateDecorativeItem<ArtifactVase>("Azulejo Tile Shard", 1153), 0.18);
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Model of the Nau São Gabriel", 1286), 0.13);
            AddItem(CreateDecorativeItem<MedusaStatue>("Statue of Viriathus", 1109), 0.12);
            AddItem(CreateNamedItem<GreaterCurePotion>("Elixir of Sagres"), 0.15);
            AddItem(CreateNamedItem<RandomFancyPotion>("Royal Ginja Bottle"), 0.16);
            AddItem(CreateGem<StarSapphire>("Star Sapphire of Belém", 88), 0.15);
            AddItem(CreateGoldItem("Manueline Escudo"), 0.21);
            AddItem(CreateDecorativeItem<Sextant>("Navigator’s Astrolabe", 1173), 0.18);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateClothing(), 0.17);
            AddItem(CreateRing(), 0.17);
            AddItem(CreateNecklace(), 0.15);
            AddItem(CreateFoodItem("Pastel de Nata"), 0.15);
            AddItem(CreateFoodItem("Bolo de Mel"), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Fado's Whisper"), 0.12);
            AddItem(CreateMap(), 0.04);
            AddItem(new Gold(Utility.Random(1200, 4000)), 0.19);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Items
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Gems
        private Item CreateGem<T>(string name, int hue) where T : Item, new()
        {
            T gem = new T();
            gem.Name = name;
            gem.Hue = hue;
            return gem;
        }

        // Custom Gold/Coins
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Consumables
        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        // Themed Food
        private Item CreateFoodItem(string name)
        {
            Cake food = new Cake();
            food.Name = name;
            food.Hue = Utility.RandomList(200, 1001);
            return food;
        }

        // Equipment: Armor (Explorers, Knights, Mystics)
        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm(),
                new ChainCoif(), new StuddedGloves()
            );
            armor.Name = Utility.RandomList(
                "Armor of the Order of Christ",
                "Cuirass of Vasco da Gama",
                "Lusitanian Explorer’s Mail",
                "Mystic Mantle of Fátima"
            );
            armor.Hue = Utility.RandomList(1286, 1153, 1173, 1109);
            armor.BaseArmorRating = Utility.Random(35, 75);
            armor.Attributes.BonusHits = 10;
            armor.Attributes.BonusStam = 5;
            armor.Attributes.SpellChanneling = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Equipment: Weapon
        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Katana(), new Broadsword(), new Pike(), new Scimitar()
            );
            weapon.Name = Utility.RandomList(
                "Sword of Viriathus",
                "Cutlass of the Navigators",
                "Lance of Sagres",
                "Scimitar of the Algarve"
            );
            weapon.Hue = Utility.RandomList(1286, 1173, 1153, 1109);
            weapon.MinDamage = Utility.Random(22, 38);
            weapon.MaxDamage = Utility.Random(54, 81);
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.BonusStr = 9;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.WeaponDamage = 25;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitLeechHits = 8;
            weapon.SkillBonuses.SetValues(0, SkillName.Parry, 13.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 16.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Equipment: Clothing
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = Utility.RandomList(
                "Cloak of the Discoverers",
                "Fado Singer’s Robe",
                "Cape of Belem’s Winds"
            );
            robe.Hue = Utility.RandomList(1153, 1286, 1173);
            robe.Attributes.LowerManaCost = 12;
            robe.Attributes.BonusMana = 8;
            robe.Attributes.BonusInt = 7;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.Musicianship, 11.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Equipment: Jewelry
        private Item CreateRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Navigator";
            ring.Hue = 1173;
            ring.Attributes.Luck = 55;
            ring.Attributes.BonusStam = 10;
            ring.SkillBonuses.SetValues(0, SkillName.Cartography, 16.0);
            ring.SkillBonuses.SetValues(1, SkillName.Fishing, 12.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateNecklace()
        {
            GoldNecklace neck = new GoldNecklace();
            neck.Name = "Necklace of Fátima’s Miracle";
            neck.Hue = 1153;
            neck.Attributes.CastRecovery = 3;
            neck.Attributes.SpellDamage = 11;
            neck.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 12.0);
            neck.SkillBonuses.SetValues(1, SkillName.MagicResist, 9.0);
            XmlAttach.AttachTo(neck, new XmlLevelItem());
            return neck;
        }

        // Custom Lore Book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfLusitania();
        }

        // Themed Map
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Tower of Belém";
            map.Bounds = new Rectangle2D(1500, 1800, 200, 200);
            map.NewPin = new Point2D(1580, 1895);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfLusitanianLegends(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class ChroniclesOfLusitania : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Lusitania: A Voyage Through Time", "Infante D. Henrique",
            new BookPageInfo
            (
                "From the wild hills of",
                "Lusitania to the roaring",
                "Atlantic, our land has",
                "seen heroes rise and empires",
                "fall. We are Viriathus’",
                "warriors and Sagres’ explorers.",
                "Our sails kissed the horizon.",
                ""
            ),
            new BookPageInfo
            (
                "We found new worlds in",
                "uncharted waters—da Gama",
                "to India, Magellan around",
                "the globe. The Order of",
                "Christ blessed our quest.",
                "Lisbon’s towers shone bright,",
                "golden with discovery.",
                ""
            ),
            new BookPageInfo
            (
                "Yet the Fado echoes loss.",
                "Through earthquake and",
                "exile, our spirit endured.",
                "Poets and singers carried",
                "our saudade, a longing",
                "older than time. Through",
                "faith and fire, we remained."
            ),
            new BookPageInfo
            (
                "Let this chest bear our",
                "memory: The sapphire sea,",
                "the Manueline gold, the",
                "Azulejo’s blue story. May",
                "the brave heart of Portugal",
                "guide any who find these",
                "relics to their own horizon.",
                ""
            ),
            new BookPageInfo
            (
                "Remember: To be Portuguese",
                "is to seek, to sing, to",
                "sail. May you too discover,",
                "and never forget.",
                "",
                "- Infante D. Henrique",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfLusitania() : base(false)
        {
            Hue = 1173; // Blue for Azulejos
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Lusitania: A Voyage Through Time");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Lusitania");
        }

        public ChroniclesOfLusitania(Serial serial) : base(serial) { }
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
