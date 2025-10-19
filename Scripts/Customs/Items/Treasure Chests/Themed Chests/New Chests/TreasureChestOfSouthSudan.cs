using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSouthSudan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSouthSudan()
        {
            Name = "Treasure Chest of South Sudan";
            Hue = 2101; // Deep blue, like the Nile on the flag

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Nile River Water Jar", 1266), 0.18);
            AddItem(CreateDecorativeItem<Basket4Artifact>("Carved Cattle Basket", 0), 0.22);
            AddItem(CreateDecorativeItem<Necklace>("Beaded Necklace of Unity", 1435), 0.20);
            AddItem(CreateDecorativeItem<Drums>("Drum of the Tribes", 1801), 0.15);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Dinka Elder’s Wooden Stool", 1195), 0.13);
            AddItem(CreateDecorativeItem<WolfStatue>("Lion of South Sudan", 1154), 0.09);
            AddItem(CreateDecorativeItem<FlowerGarland>("Peace Garland", 1282), 0.11);
            AddItem(CreateConsumable<GreenTea>("Sorghum Ale", 2200), 0.25);
            AddItem(CreateConsumable<CheeseWheel>("Millet Porridge", 2118), 0.23);
            AddItem(CreateConsumable<GreaterHealPotion>("Healing Herb Poultice", 1267), 0.20);
            AddItem(CreateGoldItem("South Sudanese Pound Coin"), 0.16);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.23);
            AddItem(CreateShield(), 0.21);
            AddItem(CreateUniqueRing(), 0.11);
            AddItem(new Gold(Utility.Random(3000, 5000)), 1.0);
            AddItem(new BookOfTheNileKingdoms(), 1.0);
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateDecorativeItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            Spear spear = new Spear();
            spear.Name = "Spear of the White Nile";
            spear.Hue = 2101;
            spear.MinDamage = 32;
            spear.MaxDamage = 64;
            spear.WeaponAttributes.HitLeechHits = 20;
            spear.WeaponAttributes.HitLightning = 30;
            spear.WeaponAttributes.UseBestSkill = 1;
            spear.Attributes.BonusStr = 12;
            spear.Attributes.AttackChance = 18;
            spear.Attributes.DefendChance = 10;
            spear.Attributes.WeaponSpeed = 35;
            spear.Slayer = SlayerName.ReptilianDeath;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            spear.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of Juba";
            shield.Hue = 1436;
            shield.ArmorAttributes.SelfRepair = 5;
            shield.ArmorAttributes.LowerStatReq = 15;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.BonusHits = 12;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateArmor()
        {
            LeatherChest chest = new LeatherChest();
            chest.Name = "Cattleman’s Leather Vest";
            chest.Hue = 1150;
            chest.Attributes.Luck = 55;
            chest.Attributes.BonusHits = 12;
            chest.Attributes.BonusDex = 10;
            chest.ArmorAttributes.SelfRepair = 7;
            chest.SkillBonuses.SetValues(0, SkillName.AnimalLore, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 12.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            BodySash sash = new BodySash();
            sash.Name = "Freedom Sash of Independence";
            sash.Hue = 2075;
            sash.Attributes.RegenHits = 5;
            sash.Attributes.RegenStam = 3;
            sash.Attributes.BonusInt = 5;
            sash.SkillBonuses.SetValues(0, SkillName.Peacemaking, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.Meditation, 7.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateUniqueRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Unity Star";
            ring.Hue = 2213; // Gold
            ring.Attributes.Luck = 77;
            ring.Attributes.BonusMana = 8;
            ring.Attributes.CastRecovery = 2;
            ring.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the White Nile Basin";
            map.Bounds = new Rectangle2D(1700, 2500, 700, 600);
            map.NewPin = new Point2D(1850, 2900);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSouthSudan(Serial serial) : base(serial) { }

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

    public class BookOfTheNileKingdoms : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Book of the Nile Kingdoms", "Anonymous Scribe",
            new BookPageInfo
            (
                "From the lush banks of the Nile,",
                "where hippos and crocodiles dwell,",
                "rose the ancient kingdoms—",
                "Shilluk, Dinka, Azande, and more.",
                "People of cattle, river, and earth.",
                "Guided by the rhythm of the drum,",
                "and the whisper of rain on papyrus."
            ),
            new BookPageInfo
            (
                "Through ages of trade and strife,",
                "came foreign kings and distant gods.",
                "A land divided, yet never broken.",
                "British rule and foreign hands",
                "could not silence the song of the",
                "South. When all seemed lost,",
                "the spirit endured."
            ),
            new BookPageInfo
            (
                "The drums thundered for freedom.",
                "Generations struggled in the swamps",
                "and the grasslands, hearts ablaze.",
                "War claimed the innocent, and rivers",
                "ran red. Yet, hope never drowned.",
                "The cattle returned. The fields healed.",
                "The dream of freedom endured."
            ),
            new BookPageInfo
            (
                "At last, in the year 2011,",
                "the blue star of unity rose.",
                "South Sudan—youngest of nations—",
                "stood beneath a hopeful sky.",
                "New wounds, old wisdom.",
                "We are many peoples, but one dream.",
                "The Nile flows, carrying us onward."
            ),
            new BookPageInfo
            (
                "Let this chest remind you:",
                "Our riches are the spirit of unity,",
                "the courage of our ancestors,",
                "the river’s gift, the drum’s call.",
                "",
                "May the finder walk with peace.",
                "",
                "- The Scribe of the Nile"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfTheNileKingdoms() : base(false)
        {
            Hue = 2101; // Deep Nile blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Book of the Nile Kingdoms");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Book of the Nile Kingdoms");
        }

        public BookOfTheNileKingdoms(Serial serial) : base(serial) { }

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
