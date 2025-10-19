using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientGeorgia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientGeorgia()
        {
            Name = "Treasure Chest of Ancient Georgia";
            Hue = 1153; // Deep red - color of Georgian wine

            // Add items to the chest
            AddItem(new ChroniclesOfTheGoldenKingdom(), 1.0);
            AddItem(CreateDecorativeArtifact("Colchian Golden Fleece", typeof(FancyCopperWings), 2125), 0.12);
            AddItem(CreateDecorativeArtifact("Statue of Queen Tamar", typeof(KingsGildedStatue), 1150), 0.18);
            AddItem(CreateDecorativeArtifact("Kartlis Deda (Mother Georgia)", typeof(ManStatuetteSouthArtifact), 2500), 0.10);
            AddItem(CreateDecorativeArtifact("Ivory Drinking Horn", typeof(FancyHornOfPlenty), 2301), 0.20);
            AddItem(CreateConsumable("Ancient Qvevri Wine", typeof(GlassMug), 1645), 0.30);
            AddItem(CreateConsumable("Khachapuri (Cheese Bread)", typeof(BreadLoaf), 2023), 0.25);
            AddItem(CreateConsumable("Churchkhela (Georgian Candy)", typeof(JellyBeans), 2055), 0.22);
            AddItem(CreateGoldItem("Colchian Darics"), 0.19);
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.23);
            AddItem(CreateShield(), 0.18);
            AddItem(new Gold(Utility.Random(2000, 6000)), 0.30);
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative artifact with name and hue
        private Item CreateDecorativeArtifact(string name, Type baseType, int hue)
        {
            Item item = (Item)Activator.CreateInstance(baseType);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumable item with name and hue
        private Item CreateConsumable(string name, Type baseType, int hue)
        {
            Item item = (Item)Activator.CreateInstance(baseType);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Special gold
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Map to ancient Colchis
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Ruins of Colchis";
            map.Bounds = new Rectangle2D(3300, 1800, 300, 300);
            map.NewPin = new Point2D(3450, 1920);
            map.Protected = true;
            return map;
        }

        // Unique mythic weapon
        private Item CreateWeapon()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Sword of the Argonaut";
            sword.Hue = 2207;
            sword.Attributes.BonusStr = 20;
            sword.Attributes.BonusInt = 10;
            sword.Attributes.BonusDex = 10;
            sword.Attributes.AttackChance = 12;
            sword.WeaponAttributes.HitFireball = 20;
            sword.WeaponAttributes.HitDispel = 10;
            sword.WeaponAttributes.UseBestSkill = 1;
            sword.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            sword.WeaponAttributes.SelfRepair = 5;
            sword.LootType = LootType.Blessed;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Unique mythic armor piece
        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of Iberian Kings";
            chest.Hue = 1150;
            chest.BaseArmorRating = Utility.Random(45, 80);
            chest.ArmorAttributes.LowerStatReq = 20;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.Luck = 35;
            chest.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.MagicResist, 15.0);
            chest.ColdBonus = 10;
            chest.EnergyBonus = 15;
            chest.FireBonus = 10;
            chest.PhysicalBonus = 20;
            chest.PoisonBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Unique themed clothing
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Chokha of Tbilisi";
            robe.Hue = 1257;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.LowerRegCost = 8;
            robe.Attributes.SpellDamage = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 12.0);
            robe.LootType = LootType.Blessed;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Unique shield
        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Golden Fleece";
            shield.Hue = 2212;
            shield.ArmorAttributes.SelfRepair = 6;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.ReflectPhysical = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfAncientGeorgia(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheGoldenKingdom : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Golden Kingdom", "Priest of Colchis",
            new BookPageInfo
            (
                "Beyond the snowcapped peaks of the Caucasus,",
                "lies the ancient land of Georgia.",
                "Here, the Argonauts sailed in quest of the",
                "Golden Fleece, and the sacred forests",
                "whisper with the voices of gods and kings.",
                "Colchis, Iberia, Lazica — kingdoms crowned",
                "in gold, wine, and war.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Queen Tamar, Lion of the East,",
                "forged a realm that dazzled the world.",
                "Monasteries cling to mountains, their",
                "bells echoing faith since time immemorial.",
                "Knights rode in silken chokhas, blades flashing,",
                "defending these valleys from all invaders.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "In stone and song, the story endures.",
                "The qvevri holds the blood of the earth;",
                "churchkhela sweetens every feast.",
                "In Tbilisi’s winding streets, old magic stirs.",
                "Here, every traveler may find treasure —",
                "if they heed the ancient words:",
                "",
                "\"Peace to those who cherish this land.\""
            ),
            new BookPageInfo
            (
                "But beware: the spirits of the ancestors",
                "guard the riches of Georgia.",
                "Disturb not the slumber of kings,",
                "nor the wrath of Medea.",
                "",
                "May you journey with wisdom,",
                "and may the Golden Kingdom’s legacy endure.",
                "",
                "- Written by the Priest of Colchis"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheGoldenKingdom() : base(false)
        {
            Hue = 1153; // Deep red for Georgian wine
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Golden Kingdom");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Golden Kingdom");
        }

        public ChroniclesOfTheGoldenKingdom(Serial serial) : base(serial) { }

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
