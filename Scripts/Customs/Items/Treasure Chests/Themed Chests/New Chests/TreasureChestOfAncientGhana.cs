using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientGhana : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientGhana()
        {
            Name = "Treasure Chest of Ancient Ghana";
            Hue = 2213; // Deep gold

            // Add unique treasures with themed probabilities
            AddItem(new GoldMaskOfWagadu(), 0.07);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Carved Jar of the Niger", 2125), 0.18);
            AddItem(CreateDecorativeItem<GoldBricks>("Trade Bar of the Salt Road", 2213), 0.25);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Lion Idol of the Ashanti", 1359), 0.15);
            AddItem(CreateColoredItem<GoldBracelet>("Bracelet of the Sun King", 1167), 0.10);
            AddItem(CreateColoredItem<GoldEarrings>("Earrings of Mande Nobility", 1366), 0.16);
            AddItem(CreateFoodItem("Loaf of Sahel Honey Bread", 247, typeof(Cake)), 0.18);
            AddItem(CreateFoodItem("Calabash of Millet Beer", 1924, typeof(RandomDrink)), 0.20);
            AddItem(CreateGoldNugget(), 0.20);
            AddItem(CreateGoldItem("Cowrie Shell Tribute"), 0.20);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Trade Envoy", 2808), 0.14);
            AddItem(CreateMap(), 0.06);
            AddItem(new ChroniclesOfWagaduKings(), 1.0);

            // Legendary gear
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateWarMask(), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateFoodItem(string name, int hue, Type baseType)
        {
            Item item = (Item)Activator.CreateInstance(baseType);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldNugget()
        {
            Gold gold = new Gold(Utility.Random(1500, 4500));
            gold.Name = "Gold Nugget of Kumbi Saleh";
            return gold;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(100, 500));
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Trans-Saharan Trade";
            map.Bounds = new Rectangle2D(4300, 2850, 400, 400); // Example location
            map.NewPin = new Point2D(4475, 3005);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Spear(), new WarHammer(), new Bow()
            );
            weapon.Name = Utility.RandomList(
                "Sunblade of the Wagadu King",
                "Spear of the Desert Scouts",
                "Hammer of the Ashanti Warrior",
                "Longbow of the Gold Hunters"
            );
            weapon.Hue = 2213; // Gold
            weapon.MaxDamage = Utility.Random(45, 80);
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusHits = 25;
            weapon.Attributes.BonusStam = 15;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.SelfRepair = 8;
            weapon.Slayer = SlayerName.ElementalBan; // Gold (earth) theme
            weapon.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new StuddedLegs(), new PlateHelm(), new PlateArms()
            );
            armor.Name = Utility.RandomList(
                "Gilded Breastplate of Ghana",
                "Salt Road Greaves",
                "Helm of the Rainmaker",
                "Lion-Engraved Armguards"
            );
            armor.Hue = 2213;
            armor.BaseArmorRating = Utility.Random(45, 90);
            armor.Attributes.Luck = 45;
            armor.Attributes.BonusHits = 18;
            armor.ArmorAttributes.SelfRepair = 7;
            armor.AbsorptionAttributes.EaterFire = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Magery, 20.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Mande Diviner";
            robe.Hue = 1172;
            robe.Attributes.RegenMana = 4;
            robe.Attributes.BonusMana = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 8.0);
            robe.Attributes.LowerManaCost = 10;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateWarMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mask of the Soninke Warrior";
            mask.Hue = Utility.RandomList(1161, 1357, 2424);
            mask.Attributes.BonusStr = 8;
            mask.Attributes.BonusDex = 8;
            mask.Attributes.BonusStam = 12;
            mask.SkillBonuses.SetValues(0, SkillName.Anatomy, 12.0);
            mask.SkillBonuses.SetValues(1, SkillName.Swords, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        public TreasureChestOfAncientGhana(Serial serial) : base(serial) { }

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

    public class GoldMaskOfWagadu : NorseHelm
    {
        [Constructable]
        public GoldMaskOfWagadu()
        {
            Name = "Gold Mask of Wagadu";
            Hue = 2213;
            Attributes.BonusInt = 10;
            Attributes.BonusMana = 15;
            Attributes.RegenMana = 2;
            ArmorAttributes.MageArmor = 1;
            SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 15.0);
            XmlAttach.AttachTo(this, new XmlLevelItem());
        }

        public GoldMaskOfWagadu(Serial serial) : base(serial) { }

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

    public class ChroniclesOfWagaduKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Wagadu Kings", "Scribe of the Soninke",
            new BookPageInfo
            (
                "In the Sahel where the",
                "Niger bends, a land of",
                "golden earth and ancient",
                "rivers gave birth to",
                "Ghana—Wagadu, Land of",
                "Gold. The kings sat upon",
                "thrones of ivory, and",
                "gold dust flowed like sand."
            ),
            new BookPageInfo
            (
                "Merchants from distant",
                "lands—Berber, Arab, and",
                "Mandinka—crossed deserts",
                "bearing salt, cloth, and",
                "strange tales. In return,",
                "they found gold, wisdom,",
                "and law. The city of",
                "Kumbi Saleh rose."
            ),
            new BookPageInfo
            (
                "The King, called Ghana,",
                "ruled with divine power.",
                "His court sparkled with",
                "jewels, his word was law,",
                "his warriors loyal and",
                "strong. The lion was his",
                "symbol, and none dared",
                "challenge his might."
            ),
            new BookPageInfo
            (
                "The empire thrived on",
                "trade. Gold for salt,",
                "salt for life. Camels",
                "carried treasures across",
                "endless dunes. The wealth",
                "of Ghana became legend—",
                "even in the far caliphates",
                "of the East."
            ),
            new BookPageInfo
            (
                "Yet, all things change.",
                "Invaders came from the",
                "north, and new faiths",
                "took root. But Wagadu's",
                "legacy remains: the gold,",
                "the wisdom, the stories.",
                "To find this chest is to",
                "touch the spirit of Ghana."
            ),
            new BookPageInfo
            (
                "Let this book recall",
                "the greatness of Wagadu,",
                "and may its treasures",
                "bring you fortune and",
                "respect for the ancient",
                "kings. Guard what you",
                "take, for the spirits of",
                "the savannah watch still."
            ),
            new BookPageInfo
            (
                "",
                "- Scribe of the Soninke",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfWagaduKings() : base(false)
        {
            Hue = 2213;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Wagadu Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Wagadu Kings");
        }

        public ChroniclesOfWagaduKings(Serial serial) : base(serial) { }

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
