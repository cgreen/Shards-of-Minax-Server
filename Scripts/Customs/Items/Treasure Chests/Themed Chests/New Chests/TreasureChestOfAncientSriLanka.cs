using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientSriLanka : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientSriLanka()
        {
            Name = "Treasure Chest of Ancient Sri Lanka";
            Hue = 2125; // Sapphire Blue

            // Add themed items
            AddItem(new CeylonSapphireGem(), 0.20);
            AddItem(CreateNamedItem<IncenseBurner>("Sacred Temple Incense Burner"), 0.15);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Vase of Sigiriya"), 0.17);
            AddItem(CreateNamedItem<CraneZooStatuette>("Elephant of Anuradhapura"), 0.17);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of King Dutugemunu"), 0.18);
            AddItem(CreateNamedItem<SakeArtifact>("Cinnamon-Infused Arrack"), 0.15);
            AddItem(new ChroniclesOfTheIslandKings(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7000)), 0.15);
            AddItem(CreateColoredItem<Sapphire>("Gem of Ceylon", 2125), 0.15);
            AddItem(CreateUniqueFood(), 0.12);
            AddItem(CreateGoldItem("Ancient Lankapura Coin"), 0.18);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Lotus Path", 2515), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Queen Viharamahadevi"), 0.16);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateNamedItem<Sextant>("Mariner’s Compass of Taprobane"), 0.12);
            AddItem(CreateNamedItem<GreaterHealPotion>("Herbal Draught of Mihintale"), 0.17);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateRobes(), 0.15);
            AddItem(CreateLeatherCap(), 0.15);
            AddItem(CreateDagger(), 0.15);
            AddItem(CreateDecorativeArtifact(), 0.16);
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

        private Item CreateUniqueFood()
        {
            Cake cake = new Cake();
            cake.Name = "Lamprais of Royal Banquet";
            cake.Hue = 1807; // Rich brown
            return cake;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Ruins of Sigiriya";
            map.Bounds = new Rectangle2D(4500, 1700, 350, 380);
            map.NewPin = new Point2D(4685, 1820);
            map.Protected = true;
            return map;
        }

        private Item CreateDecorativeArtifact()
        {
            ArtifactLargeVase vase = new ArtifactLargeVase();
            vase.Name = "Moonstone Carving of Polonnaruwa";
            vase.Hue = 2500;
            return vase;
        }

        private Item CreateWeapon()
        {
            Scimitar sword = new Scimitar();
            sword.Name = "Scimitar of the Lion Throne";
            sword.Hue = 2517;
            sword.MaxDamage = Utility.Random(50, 90);
            sword.MinDamage = Utility.Random(20, 45);
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 50;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusDex = 10;
            sword.Attributes.SpellChanneling = 1;
            sword.WeaponAttributes.HitLightning = 20;
            sword.WeaponAttributes.HitLeechHits = 10;
            sword.SkillBonuses.SetValues(0, SkillName.Bushido, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Breastplate of King Vijayabahu";
            armor.Hue = 2408;
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.BonusHits = 20;
            armor.Attributes.BonusMana = 10;
            armor.Attributes.BonusStam = 15;
            armor.Attributes.NightSight = 1;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Wrestling, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRobes()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Buddhist Sage";
            robe.Hue = 1161; // Saffron yellow
            robe.Attributes.LowerManaCost = 15;
            robe.Attributes.BonusInt = 12;
            robe.Attributes.Luck = 40;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLeatherCap()
        {
            LeatherCap cap = new LeatherCap();
            cap.Name = "Headwrap of the Spice Merchant";
            cap.Hue = 1845; // Cinnamon brown
            cap.BaseArmorRating = Utility.Random(20, 35);
            cap.ArmorAttributes.LowerStatReq = 15;
            cap.Attributes.BonusDex = 10;
            cap.Attributes.BonusInt = 6;
            cap.SkillBonuses.SetValues(0, SkillName.ItemID, 12.0);
            cap.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Kastane of the Kandyan Guards";
            dagger.Hue = 1150;
            dagger.MinDamage = Utility.Random(18, 36);
            dagger.MaxDamage = Utility.Random(40, 67);
            dagger.Attributes.BonusHits = 8;
            dagger.Attributes.ReflectPhysical = 12;
            dagger.WeaponAttributes.HitHarm = 17;
            dagger.WeaponAttributes.SelfRepair = 4;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 18.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfAncientSriLanka(Serial serial) : base(serial)
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

    // Custom Gem Item
    public class CeylonSapphireGem : Sapphire
    {
        [Constructable]
        public CeylonSapphireGem()
        {
            Name = "Star of Ceylon (Legendary Sapphire)";
            Hue = 2125;
        }

        public CeylonSapphireGem(Serial serial) : base(serial) { }

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

    // Custom Lore Book
    public class ChroniclesOfTheIslandKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Island Kings", "Sanghamitta, Daughter of Ashoka",
            new BookPageInfo
            (
                "Long before distant empires",
                "sailed the seas, Lanka was an",
                "isle of kings and legend.",
                "From the golden city of Anuradhapura,",
                "to the rock fortress of Sigiriya,",
                "its treasures are veiled in",
                "jungle and mist."
            ),
            new BookPageInfo
            (
                "The Lion Kings ruled with",
                "power and wisdom. Elephants",
                "marched in royal pageantry.",
                "Buddhist monks carried relics",
                "to the Mountain of Sacred Footprint.",
                "Cinnamon and gems flowed to",
                "distant worlds."
            ),
            new BookPageInfo
            (
                "Here, the mighty King Dutugemunu",
                "united warring clans, building",
                "stupas that still kiss the sky.",
                "Viharamahadevi, the lion-hearted",
                "queen, braved the sea for her land.",
                "Legends whisper through",
                "ancient stone and banyan roots."
            ),
            new BookPageInfo
            (
                "Let seekers of fortune heed",
                "the warnings of the old gods.",
                "In these chests lie relics of",
                "devotion, conquest, and wisdom.",
                "May the island's spirit guide",
                "the worthy and humble the proud.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Drink of the sacred well.",
                "Gaze upon the sapphire star.",
                "Remember the kings and queens",
                "whose echoes live in jungle ruins.",
                "Lanka endures, a jeweled tear",
                "upon the cheek of the world.",
                "",
                "- Sanghamitta"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheIslandKings() : base(false)
        {
            Hue = 2125; // Sapphire blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Island Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Island Kings");
        }

        public ChroniclesOfTheIslandKings(Serial serial) : base(serial) { }

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
