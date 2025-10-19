using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSomalia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSomalia()
        {
            Name = "Treasure Chest of Ancient Somalia";
            Hue = 1266; // Deep blue, reminiscent of the Somali flag

            // Add items to the chest
            AddItem(CreateDecorativeArtifact<ArtifactVase>("Ajuran Dynasty Water Jar", 1160), 0.18);
            AddItem(CreateDecorativeArtifact<IncenseBurner>("Frankincense Burner of Zeila", 2415), 0.20);
            AddItem(CreateDecorativeArtifact<BooksWestArtifact>("Scroll of Somali Poetry", 2101), 0.25);
            AddItem(CreateConsumable<CoffeeMug>("Spiced Somali Coffee", 2652), 0.15);
            AddItem(CreateDecorativeArtifact<BambooStoolArtifact>("Benaadir Craftsman’s Stool", 1152), 0.10);
            AddItem(CreateDecorativeArtifact<Painting1WestArtifact>("Painting of Mogadishu’s Port", 1320), 0.12);
            AddItem(CreateDecorativeArtifact<GoldBricks>("Ingots from the Sultan’s Vault", 1421), 0.11);
            AddItem(CreateDecorativeArtifact<SnakeStatue>("Statue of Queen Araweelo", 1533), 0.08);

            AddItem(CreateWeapon(), 0.28);
            AddItem(CreateArmor(), 0.25);
            AddItem(CreateRobe(), 0.20);
            AddItem(CreateSandals(), 0.18);
            AddItem(CreateShield(), 0.16);

            AddItem(CreateConsumable<Dates>("Rare Boswellia Dates", 2735), 0.20);
            AddItem(CreateConsumable<Banana>("Sweet Jubba Bananas", 2217), 0.14);
            AddItem(CreateConsumable<FruitBasket>("Basket of Somali Delicacies", 2324), 0.13);

            AddItem(new ChroniclesOfTheLandOfPunt(), 1.0);

            AddItem(CreateUniqueGold("Ancient Sultanate Dinar"), 0.22);
            AddItem(CreateTreasureMap(), 0.05);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueGold(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(800, 3400);
            return gold;
        }

        private Item CreateTreasureMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Opone";
            map.Bounds = new Rectangle2D(2000, 3400, 450, 450);
            map.NewPin = new Point2D(2225, 3560);
            map.Protected = true;
            return map;
        }

        // Powerful Somali-themed equipment

        private Item CreateWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Warblade of the Ajuran Sultan";
            weapon.Hue = 1446; // A regal gold/bronze
            weapon.WeaponAttributes.HitLeechMana = 22;
            weapon.WeaponAttributes.HitHarm = 18;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.WeaponAttributes.HitLightning = 16;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.AttackChance = 12;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 14.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Gilded Armor of Mogadishu";
            armor.Hue = 1175;
            armor.BaseArmorRating = 58;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusStr = 14;
            armor.Attributes.RegenHits = 6;
            armor.Attributes.Luck = 40;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 11.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 13.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Poet’s Robe of Hargeisa";
            robe.Hue = 1359;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.BonusMana = 14;
            robe.Attributes.RegenMana = 5;
            robe.Attributes.SpellDamage = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.Inscribe, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Red Sea Explorer";
            sandals.Hue = 1355;
            sandals.Attributes.Luck = 22;
            sandals.Attributes.BonusDex = 7;
            sandals.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Camping, 7.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateShield()
        {
            WoodenShield shield = new WoodenShield();
            shield.Name = "Shield of the Puntland Guard";
            shield.Hue = 1178;
            shield.Attributes.DefendChance = 14;
            shield.Attributes.ReflectPhysical = 8;
            shield.Attributes.SpellChanneling = 1;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 16.0);
            shield.SkillBonuses.SetValues(1, SkillName.Focus, 9.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfSomalia(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheLandOfPunt : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of Punt", "Scribe Nura of Mogadishu",
            new BookPageInfo
            (
                "In the age when the frankincense",
                "trees covered the coast, our",
                "ancestors sailed wooden ships beyond",
                "the horizon. Pharaohs called our",
                "land Punt, 'God’s Land,' seeking",
                "myrrh and gold from our harbors.",
                "Our queens ruled with wisdom and",
                "our warriors rode swift camels."
            ),
            new BookPageInfo
            (
                "Ajuran Sultans commanded the",
                "Shabelle River, raising stone wells",
                "and grand mosques. Somali merchants",
                "traded spices, ivory, and silks with",
                "India, Persia, and Cathay. Our",
                "cities, like Zeila and Mogadishu,",
                "flourished on salt breezes and",
                "the gifts of the sea."
            ),
            new BookPageInfo
            (
                "The land endured. When invaders",
                "came, our poets sang defiance.",
                "When famine struck, the she-camels",
                "were shared. Legends tell of Queen",
                "Araweelo, who ruled her kingdom",
                "with cunning, and of sultans whose",
                "golden coins shimmered in distant",
                "bazaars."
            ),
            new BookPageInfo
            (
                "Our rivers wind like ancient",
                "stories. The horn of Africa stands",
                "as a beacon to sailors and seekers.",
                "This chest, filled with relics of",
                "Somalia, is a tribute to her",
                "enduring spirit. May the wind",
                "carry your story onward, as ours",
                "once rode the monsoon."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheLandOfPunt() : base(false)
        {
            Hue = 1178; // Blue of the Somali flag
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of Punt");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of Punt");
        }

        public ChroniclesOfTheLandOfPunt(Serial serial) : base(serial) { }

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
