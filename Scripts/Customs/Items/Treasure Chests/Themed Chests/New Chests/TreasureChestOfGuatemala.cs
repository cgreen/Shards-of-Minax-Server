using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGuatemala : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGuatemala()
        {
            Name = "Treasure Chest of the History of Guatemala";
            Hue = 1272; // Jade-green (Mayan Jade)

            // Add items to the chest
            AddItem(CreateArtifact<JadeSkull>("Mayan Jade Skull of Kings", 1272), 0.17);
            AddItem(CreateArtifact<ObsidianSkull>("Obsidian Idol of Tikal", 1109), 0.17);
            AddItem(CreateArtifact<GoldBricks>("Spanish Conquistador’s Gold Bar", 1420), 0.18);
            AddItem(CreateArtifact<AncientDrum>("Sacred Drum of Quetzalcoatl", 1166), 0.13);
            AddItem(CreateArtifact<RandomFancyBanner>("Handwoven Huipil of Lake Atitlán", 1356), 0.16);
            AddItem(CreateArtifact<CrystalBallStatuette>("Crystal Ball of Ixchel", 1157), 0.15);
            AddItem(new AnnalsOfGuatemala(), 1.0);
            AddItem(CreateConsumable<ChocolateNutcracker>("Ancient Cacao of the Highlands", 1472), 0.22);
            AddItem(CreateConsumable<BreadLoaf>("Sacred Tamale", 1357), 0.19);
            AddItem(CreatePotion("Potion of Eternal Spring", 1277), 0.13);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateClothing(), 0.22);
            AddItem(CreateGoldItem("Quetzal Plume Coin"), 0.19);
            AddItem(CreateDecorative<AncientRunes>("Tablet of the Popol Vuh", 1175), 0.11);
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreatePotion(string name, int hue)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            return potion;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Ruins of El Mirador";
            map.Bounds = new Rectangle2D(4400, 1160, 350, 350);
            map.NewPin = new Point2D(4550, 1340);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Katana(), new Scimitar(), new Dagger(), new BladedStaff(), new Scepter());
            weapon.Name = "Obsidian Blade of the Maya";
            weapon.Hue = 1109; // Obsidian black
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.Attributes.BonusDex = 8;
            weapon.Attributes.Luck = 200;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            weapon.Attributes.SpellChanneling = 1;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(new PlateChest(), new LeatherDo(), new ChainCoif(), new DragonTurtleHideLegs());
            armor.Name = "Vestments of the Quetzal Priest";
            armor.Hue = Utility.RandomList(1272, 1356, 1416);
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.Attributes.BonusMana = 10;
            armor.Attributes.BonusInt = 6;
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.LowerStatReq = 30;
            armor.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Cartography, 10.0);
            armor.SkillBonuses.SetValues(2, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Huipil of the Lake Spirits";
            robe.Hue = Utility.RandomMinMax(1350, 1400); // Bright blues and greens
            robe.Attributes.Luck = 250;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.AnimalLore, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.TasteID, 7.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfGuatemala(Serial serial) : base(serial) { }

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

    public class AnnalsOfGuatemala : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Annals of Guatemala", "Chronicler of the Highlands",
            new BookPageInfo
            (
                "Long before the volcanoes",
                "and jungles heard Spanish,",
                "the land called Guatemala",
                "bloomed with the wisdom of",
                "the Maya. From Tikal's",
                "temples, astronomers",
                "watched the sun and moon,",
                "scribes wrote glyphs."
            ),
            new BookPageInfo
            (
                "Jade and obsidian flowed",
                "in the markets of Copán.",
                "Priests danced for Ixchel.",
                "Kings ruled and fell. The",
                "Popol Vuh was sung. The",
                "sacred ceiba tree rose,",
                "linking the worlds."
            ),
            new BookPageInfo
            (
                "But then came the ships,",
                "carrying men of steel and",
                "fire. The Spanish sought",
                "the land's gold, but found",
                "resistance. The K’iche’,",
                "the Kaqchikel, the Maya",
                "stood defiant, fighting",
                "for their home."
            ),
            new BookPageInfo
            (
                "The centuries churned.",
                "Colonial cities rose,",
                "stones taken from Maya",
                "ruins. Volcanoes rumbled.",
                "The people endured, in",
                "forest and market, in",
                "mountain and city, in",
                "weaving and memory."
            ),
            new BookPageInfo
            (
                "Guatemala is the land of",
                "eternal spring. Its rivers",
                "run with history. May its",
                "stories be remembered, and",
                "its treasures never lost.",
                "",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Seek not just gold,",
                "adventurer, but wisdom.",
                "Within these relics lies",
                "the spirit of a people:",
                "resilient, radiant, and",
                "eternal as the jungle’s",
                "heart.",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public AnnalsOfGuatemala() : base(false)
        {
            Hue = 1272; // Jade-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Annals of Guatemala");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Annals of Guatemala");
        }

        public AnnalsOfGuatemala(Serial serial) : base(serial) { }

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
