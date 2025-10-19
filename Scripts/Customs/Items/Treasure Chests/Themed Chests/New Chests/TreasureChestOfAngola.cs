using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAngola : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAngola()
        {
            Name = "Treasure Chest of the Kingdom of Angola";
            Hue = 2107; // deep red ochre

            // Add items to the chest
            AddItem(CreateDecorativeArtifact("Royal Mask of Ndongo", typeof(HornedTribalMask), 2948), 0.20);
            AddItem(CreateDecorativeArtifact("Ivory Scepter of M'banza-Kongo", typeof(DecorativeBowNorth), 1153), 0.13);
            AddItem(CreateDecorativeArtifact("Benben Royal Stool", typeof(BambooStoolArtifact), 2307), 0.13);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Nzinga", 1172), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Matamba Queen", 2420), 0.15);
            AddItem(CreateNamedItem<Necklace>("Chain of Kongo Kings", 2001), 0.14);
            AddItem(CreateColoredItem<Ruby>("Blood Ruby of Cassanje", 1777), 0.10);
            AddItem(CreateColoredItem<Sapphire>("Sapphire of the Luanda Coast", 1365), 0.09);
            AddItem(CreateMap(), 0.08);
            AddItem(new ChroniclesOfTheSableQueen(), 1.0);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.19);
            AddItem(CreateSpecialConsumable(), 0.16);
            AddItem(CreateGoldItem("Nzinga Coin"), 0.18);
            AddItem(CreateFood(), 0.12);
            AddItem(CreateDecorativeArtifact("Leopard Figurine", typeof(CrystalBallStatuette), 2412), 0.13);
            AddItem(CreateDecorativeArtifact("Bronze Chieftain Statue", typeof(KingsGildedStatue), 2418), 0.13);
            AddItem(CreateDecorativeArtifact("Mask of the Mbundu", typeof(HornedTribalMask), 2989), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorativeArtifact(string name, Type type, int hue = 0)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(1000, 4000));
            gold.Name = name;
            return gold;
        }

        private Item CreateSpecialConsumable()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Calabash of Marula Spirits";
            potion.Hue = 1153;
            return potion;
        }

        private Item CreateFood()
        {
            FruitPie pie = new FruitPie();
            pie.Name = "Angolan Baobab Fruit Pie";
            pie.Hue = 1410;
            return pie;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Longsword(), new Spear(), new Katana(), new BattleAxe());
            weapon.Name = "Blade of Queen Nzinga";
            weapon.Hue = 2107;
            weapon.MaxDamage = Utility.Random(35, 80);
            weapon.WeaponAttributes.HitLeechHits = 20;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.WeaponAttributes.HitFireball = 10;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.AttackChance = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new LeatherChest(), new PlateHelm(), new StuddedLegs(), new PlateArms(), new RingmailGloves());
            armor.Name = "Armor of the Leopard Guard";
            armor.Hue = 1985;
            armor.BaseArmorRating = Utility.Random(35, 60);
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.Luck = 25;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Macing, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Robe of M'banza-Kongo";
            robe.Hue = 2412;
            robe.Attributes.BonusInt = 12;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.Luck = 30;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Ancient Kingdoms of Angola";
            map.Bounds = new Rectangle2D(3800, 1100, 300, 300);
            map.NewPin = new Point2D(3950, 1250);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAngola(Serial serial) : base(serial)
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

    // LORE BOOK CLASS
    public class ChroniclesOfTheSableQueen : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Sable Queen", "Queen Nzinga of Ndongo",
            new BookPageInfo
            (
                "I, Nzinga Mbande, Sable",
                "Queen of Ndongo and Matamba,",
                "write these words for those",
                "who seek the truth of Angola.",
                "Mine is a land of rivers,",
                "savannas, ancient cities,",
                "and iron-hearted people."
            ),
            new BookPageInfo
            (
                "When strangers from across",
                "the sea came, bringing",
                "guns and chains, our kings",
                "resisted and bargained.",
                "The Kingdom of Kongo, the",
                "Empire of Lunda, the proud",
                "Mbundu and Chokwe—none",
                "bowed easily."
            ),
            new BookPageInfo
            (
                "I ruled with cunning and",
                "fury, meeting the Portuguese",
                "in their own courts. I donned",
                "the garb of a man to rule,",
                "and drank from the skull of",
                "my enemies. I made peace,",
                "then broke it, for my people's",
                "freedom was never for sale."
            ),
            new BookPageInfo
            (
                "War raged. The lands burned.",
                "Yet we endured. The drums",
                "beat, and the ancestors",
                "answered. Slaves were taken",
                "across the great water, yet",
                "their spirit remains in the",
                "earth and the wind."
            ),
            new BookPageInfo
            (
                "In time, the colonizers fell.",
                "My people rose in revolt—",
                "Agostinho Neto, the poet,",
                "called us to independence.",
                "Blood and hope mingled in",
                "Luanda's streets, until at",
                "last, Angola stood free."
            ),
            new BookPageInfo
            (
                "To you who open this chest,",
                "know that Angola is more",
                "than sorrow or war. She is",
                "song, and mask, and leopard's",
                "courage. Carry her story,",
                "and be bold as Nzinga. The",
                "land remembers. So shall you."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheSableQueen() : base(false)
        {
            Hue = 2107; // Deep red ochre
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Sable Queen");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Sable Queen");
        }

        public ChroniclesOfTheSableQueen(Serial serial) : base(serial) { }

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
