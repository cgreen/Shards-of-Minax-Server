using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCameroonLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCameroonLegacy()
        {
            Name = "Treasure Chest of Cameroon's Legacy";
            Hue = 2117; // Deep forest green, for Cameroon's jungles

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecor("Bamoun Royal Mask", typeof(SkullCandleArtifact), 2955), 0.20);
            AddItem(CreateDecor("Rainforest Spirit Idol", typeof(ChangelingStatue), 2207), 0.15);
            AddItem(CreateDecor("Mount Cameroon Lava Stone", typeof(SacredLavaRock), 1150), 0.15);
            AddItem(CreateDecor("Ngondo Festival Drum", typeof(AncientDrum), 1877), 0.13);
            AddItem(CreateConsumable("Honey of the Forest Bee", typeof(JarHoney), 2006), 0.15);
            AddItem(CreateConsumable("Mandara Mountain Herb Tea", typeof(GreenTea), 1196), 0.13);
            AddItem(CreateConsumable("Bamileke Secret Wine", typeof(RandomDrink), 133), 0.12);
            AddItem(CreateDecor("Bronze Elephant Figurine", typeof(DevourerStatuette), 2410), 0.09);

            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.19);

            AddItem(CreateCoin("CFA Franc Tribute", 1701), 0.17);
            AddItem(CreateDecor("Ebony Carving", typeof(CarvedMyrmydexGlyph), 1109), 0.14);
            AddItem(CreateConsumable("Fumban Spicy Stew", typeof(WoodenBowlOfStew), 54), 0.13);

            AddItem(CreateMap(), 0.05);
            AddItem(new Gold(Utility.Random(2000, 4000)), 0.22);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string name, Type type, int hue)
        {
            Item deco = (Item)Activator.CreateInstance(type);
            deco.Name = name;
            deco.Hue = hue;
            return deco;
        }

        private Item CreateConsumable(string name, Type type, int hue)
        {
            Item consumable = (Item)Activator.CreateInstance(type);
            consumable.Name = name;
            consumable.Hue = hue;
            return consumable;
        }

        private Item CreateCoin(string name, int hue)
        {
            Gold gold = new Gold(Utility.Random(100, 400));
            gold.Name = name;
            gold.Hue = hue;
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Cameroon";
            map.Bounds = new Rectangle2D(1500, 1900, 450, 350);
            map.NewPin = new Point2D(1625, 2075); // Randomized
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Scimitar(), new Spear(), new MagicWand(), new QuarterStaff());
            weapon.Name = "Fang of the Ekang Warrior";
            weapon.Hue = 2107; // Deep green
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.MinDamage = Utility.Random(15, 32);
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLightning = 10;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.Attributes.BonusStr = 7;
            weapon.Attributes.BonusDex = 7;
            weapon.Attributes.BonusStam = 7;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.Luck = 75;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(new LeafChest(), new DragonHelm(), new StuddedLegs(), new PlateGloves());
            armor.Name = "Royal Regalia of Grassfields";
            armor.Hue = Utility.RandomMinMax(1350, 1400); // Gold/Bronze hues
            armor.BaseArmorRating = Utility.Random(35, 72);
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.Luck = 100;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            armor.ColdBonus = 8;
            armor.FireBonus = 8;
            armor.EnergyBonus = 8;
            armor.PoisonBonus = 8;
            armor.PhysicalBonus = 8;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Bamileke Chief’s Patterned Robe";
            robe.Hue = 2505; // Vivid traditional colors
            robe.Attributes.BonusInt = 15;
            robe.Attributes.RegenMana = 5;
            robe.Attributes.LowerRegCost = 12;
            robe.Attributes.SpellDamage = 8;
            robe.Attributes.Luck = 60;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLoreBook()
        {
            return new CameroonLegacyBook();
        }

        public TreasureChestOfCameroonLegacy(Serial serial) : base(serial) { }

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

    public class CameroonLegacyBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of Cameroon: A Tapestry of Kingdoms", "Nkoulou, Historian-Scribe",
            new BookPageInfo
            (
                "Before the world knew borders,",
                "mighty kingdoms rose in the",
                "heart of Africa’s jungles and",
                "savannas. The Sao built walls",
                "of earth, the Bamoun forged",
                "bronze, and the Bamileke",
                "wove stories in thread and",
                "bead. Spirits watched from"
            ),
            new BookPageInfo
            (
                "the forest, and Mount Cameroon",
                "smoked over all.",
                "",
                "When strangers arrived by sea,",
                "they called the great river",
                "\"Rio dos Camarões\" for the",
                "myriad shrimps it teemed with.",
                "So was Cameroon named."
            ),
            new BookPageInfo
            (
                "Centuries passed. Kingdoms",
                "prospered and faltered.",
                "Colonizers claimed and divided,",
                "yet the spirit of the people",
                "endured—through song, dance,",
                "ritual, and war.",
                "",
                "The drums of Ngondo beat on."
            ),
            new BookPageInfo
            (
                "In time, the land shook off",
                "its foreign chains. Cameroon",
                "stood tall, a land of many",
                "tongues and traditions, united",
                "yet diverse.",
                "",
                "It is said that those who",
                "bear the gifts of Cameroon’s"
            ),
            new BookPageInfo
            (
                "ancient kings will know the",
                "strength of the jungle, the",
                "wisdom of the elders, and the",
                "fire of the mountain. May",
                "this chest bring fortune, and",
                "may you honor the ancestors.",
                "",
                "- Nkoulou"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public CameroonLegacyBook() : base(false)
        {
            Hue = 2117; // Forest green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of Cameroon: A Tapestry of Kingdoms");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of Cameroon: A Tapestry of Kingdoms");
        }

        public CameroonLegacyBook(Serial serial) : base(serial) { }

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
