using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBelizeanLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBelizeanLegends()
        {
            Name = "Treasure Chest of Belizean Legends";
            Hue = 1266; // Deep jungle green

            // Add themed items to the chest
            AddItem(new AncientMayanAmulet(), 0.12);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ceremonial Maya Vase", 2117), 0.14);
            AddItem(CreateNamedItem<GreenTea>("Garifuna Healing Tea"), 0.20);
            AddItem(CreateNamedItem<BottleArtifact>("Old Sugar Rum", 2017), 0.16);
            AddItem(CreateUniqueWeapon(), 0.22);
            AddItem(CreateUniqueArmor(), 0.22);
            AddItem(CreateBelizeanCloak(), 0.18);
            AddItem(CreateBelizeanFishingPole(), 0.11);
            AddItem(CreateJaguarSpiritBrew(), 0.10);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Carved Creole Stool", 1980), 0.13);
            AddItem(CreateMayanCoin(), 0.21);
            AddItem(new ChroniclesOfTheJewel(), 1.0);
            AddItem(CreateMapToXunantunich(), 0.08);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Blue Hole"), 0.15);
            AddItem(CreateNamedItem<LeatherNinjaHood>("Mask of the Jungle Watcher"), 0.15);
            AddItem(CreateNamedItem<RandomFancyFish>("Glowing Barrier Reef Fish"), 0.11);
            AddItem(CreateNamedItem<CheeseWheel>("Wheel of Maya Honey Cheese"), 0.10);
            AddItem(new Gold(Utility.Random(800, 2700)), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateJaguarSpiritBrew()
        {
            RandomFancyPotion potion = new RandomFancyPotion();
            potion.Name = "Jaguar Spirit Brew";
            potion.Hue = 1801;
            potion.LootType = LootType.Blessed;
            return potion;
        }

        private Item CreateMayanCoin()
        {
            Gold gold = new Gold(Utility.Random(50, 200));
            gold.Name = "Ancient Maya Jade Coin";
            return gold;
        }

        private Item CreateUniqueWeapon()
        {
            BaseWeapon weapon = new Cutlass();
            weapon.Name = "Pirate's Legacy – Saber of the Baymen";
            weapon.Hue = 1372;
            weapon.WeaponAttributes.HitLeechHits = 20;
            weapon.WeaponAttributes.HitLightning = 30;
            weapon.WeaponAttributes.UseBestSkill = 1;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.DefendChance = 10;
            weapon.Attributes.BonusStam = 8;
            weapon.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Swords, 15.0);
            weapon.LootType = LootType.Blessed;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Chestplate of the Jaguar Shaman";
            chest.Hue = 1176;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.RegenHits = 5;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            chest.PhysicalBonus = 20;
            chest.FireBonus = 10;
            chest.ColdBonus = 10;
            chest.PoisonBonus = 20;
            chest.EnergyBonus = 15;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateBelizeanCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Rainforest";
            cloak.Hue = 1266;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.BonusDex = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Tracking, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateBelizeanFishingPole()
        {
            FishingPole pole = new FishingPole();
            pole.Name = "Reef Fisher’s Mystic Rod";
            pole.Hue = 2068;
            pole.Attributes.BonusStam = 8;
            pole.Attributes.Luck = 35;
            pole.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            pole.LootType = LootType.Blessed;
            XmlAttach.AttachTo(pole, new XmlLevelItem());
            return pole;
        }

        private Item CreateMapToXunantunich()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Xunantunich";
            map.Bounds = new Rectangle2D(1320, 2370, 300, 300);
            map.NewPin = new Point2D(1385, 2480);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfBelizeanLegends(Serial serial) : base(serial) { }

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

    public class AncientMayanAmulet : GoldBracelet
    {
        [Constructable]
        public AncientMayanAmulet()
        {
            Name = "Ancient Mayan Amulet";
            Hue = 1779;
            Attributes.BonusMana = 10;
            Attributes.CastRecovery = 2;
            Attributes.SpellDamage = 15;
            SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(this, new XmlLevelItem());
        }

        public AncientMayanAmulet(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheJewel : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Jewel – The Story of Belize", "Scribe Ishpaya, Keeper of Lore",
            new BookPageInfo
            (
                "In the shadowed jungles",
                "and emerald coastlines,",
                "the Maya built their",
                "stone cities – Altun Ha,",
                "Caracol, Xunantunich.",
                "They watched the stars,",
                "crafted jade and gold,",
                "and called this land 'The Jewel'."
            ),
            new BookPageInfo
            (
                "Centuries passed. The",
                "Garifuna arrived by sea,",
                "bringing drumming spirits,",
                "sacred cassava, and songs.",
                "Creole voices mixed with",
                "the wind; the Baymen",
                "fought pirates and claimed",
                "the river mouths."
            ),
            new BookPageInfo
            (
                "British flags fluttered",
                "above logwood camps.",
                "The colony grew, and",
                "so did the stories:",
                "the Jaguar God of the",
                "underworld, the legends",
                "of La Llorona, the",
                "howler monkeys at dawn."
            ),
            new BookPageInfo
            (
                "Now, Belize is many",
                "peoples woven as one.",
                "Rainforest whispers,",
                "reef glimmers blue,",
                "the great Barrier Reef",
                "shelters a thousand",
                "secrets beneath turquoise",
                "waves."
            ),
            new BookPageInfo
            (
                "Heed these treasures,",
                "o wanderer. Drink the",
                "spirit of the Jaguar,",
                "read the stones of Maya,",
                "taste the honey of",
                "forest and reef.",
                "",
                "All stories begin anew."
            ),
            new BookPageInfo
            (
                "Here, every river",
                "flows to the sea,",
                "and every legend",
                "waits to be found.",
                "",
                "- Scribe Ishpaya"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheJewel() : base(false)
        {
            Hue = 1266; // Deep jungle green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Jewel – The Story of Belize");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Jewel – The Story of Belize");
        }

        public ChroniclesOfTheJewel(Serial serial) : base(serial) { }

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
