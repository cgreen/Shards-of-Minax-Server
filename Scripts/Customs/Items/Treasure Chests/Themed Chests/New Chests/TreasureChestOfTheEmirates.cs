using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheEmirates : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheEmirates()
        {
            Name = "Treasure Chest of the Emirates";
            Hue = 2405; // Sand-gold hue

            // Add items to the chest
            AddItem(new RandomFancyInstrument(), 0.20);
            AddItem(CreateColoredItem<Gold>("Gold Dinar of the Emirates", 2213), 0.25);
            AddItem(CreateColoredItem<Diamond>("Lustre Pearl of the Gulf", 1153), 0.15);
            AddItem(CreateNamedItem<IncenseBurner>("Oud Incense Burner"), 0.10);
            AddItem(CreateNamedItem<RedBottle>("Qahwa Elixir"), 0.12);
            AddItem(CreateDecorativeFalconStatue(), 0.14);
            AddItem(CreateBedouinDates(), 0.20);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Empty Quarter", 2418), 0.10);
            AddItem(CreateNamedItem<Sextant>("Navigator's Astrolabe"), 0.11);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateRobe(), 0.16);
            AddItem(CreateHeaddress(), 0.14);
            AddItem(CreateDagger(), 0.19);
            AddItem(new PearlsOfHeritage(), 1.0);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateBedouinDates()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Bedouin Dates";
            basket.Hue = 0x674;
            return basket;
        }

        private Item CreateDecorativeFalconStatue()
        {
            SilverSteedZooStatuette falcon = new SilverSteedZooStatuette();
            falcon.Name = "Falcon Statuette of the Emirates";
            falcon.Hue = 2411; // Silvered bronze
            return falcon;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Trucial Coast";
            map.Bounds = new Rectangle2D(5250, 3750, 320, 420);
            map.NewPin = new Point2D(5325, 3860);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Scimitar(), new Cutlass(), new Katana());
            weapon.Name = "Sands of Zayed";
            weapon.Hue = 2415; // Sand-gold
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.MinDamage = Utility.Random(20, 35);
            weapon.Attributes.BonusHits = 20;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.SpellChanneling = 1;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.SelfRepair = 5;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm(),
                new DragonChest(), new DragonHelm());
            armor.Name = "Armor of the Seven Sheikhs";
            armor.Hue = 2417;
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStr = 15;
            armor.AbsorptionAttributes.EaterFire = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            armor.FireBonus = 18;
            armor.PhysicalBonus = 20;
            armor.EnergyBonus = 12;
            armor.PoisonBonus = 7;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Emirates";
            robe.Hue = 2402; // White with gold trim
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusMana = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateHeaddress()
        {
            Bandana bandana = new Bandana();
            bandana.Name = "Ghutra of the Founders";
            bandana.Hue = 2413; // Red and white
            bandana.Attributes.BonusInt = 10;
            bandana.Attributes.NightSight = 1;
            bandana.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 10.0);
            bandana.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            bandana.SkillBonuses.SetValues(2, SkillName.Herding, 5.0);
            XmlAttach.AttachTo(bandana, new XmlLevelItem());
            return bandana;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Khanjar of Unity";
            dagger.Hue = 2218; // Ornate steel
            dagger.MinDamage = Utility.Random(18, 40);
            dagger.MaxDamage = Utility.Random(50, 85);
            dagger.Attributes.BonusStam = 15;
            dagger.Attributes.ReflectPhysical = 15;
            dagger.Slayer = SlayerName.Repond;
            dagger.WeaponAttributes.HitFireball = 20;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.WeaponAttributes.SelfRepair = 6;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfTheEmirates(Serial serial) : base(serial)
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

    public class PearlsOfHeritage : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Pearls of Heritage", "Chronicler of the Emirates",
            new BookPageInfo
            (
                "Before the towers, before",
                "the oil, the Emirates were",
                "pearls upon the desert’s",
                "edge. Bedouin tribes",
                "wandered the shifting",
                "sands, guided by stars,",
                "wind, and faith."
            ),
            new BookPageInfo
            (
                "The Trucial Coast saw",
                "fortress and dhow, market",
                "and mosque. For centuries,",
                "the sea gave pearls, the",
                "land gave dates, and the",
                "sun gave strength."
            ),
            new BookPageInfo
            (
                "From Abu Dhabi’s oases,",
                "to Dubai’s bustling creek,",
                "to Sharjah’s learning halls,",
                "to the Hajar mountains,",
                "unity was a dream sung",
                "in campfire tales."
            ),
            new BookPageInfo
            (
                "In 1971, seven Emirates",
                "joined hands. Under Sheikh",
                "Zayed, they forged a union",
                "where heritage meets",
                "horizon. Cities soared,",
                "palms blossomed, and",
                "the world gazed in wonder."
            ),
            new BookPageInfo
            (
                "Yet even among glass",
                "and gold, falcons still fly,",
                "majlis still welcome, and",
                "the sands still remember.",
                "O, traveler: May you carry",
                "forward the spirit of the",
                "Emirates, where the past",
                "shapes tomorrow."
            ),
            new BookPageInfo
            (
                "For in every grain of sand,",
                "every wave, every star,",
                "there is a story—",
                "and unity shines brighter",
                "than any pearl.",
                "",
                "- Chronicler of the Emirates",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public PearlsOfHeritage() : base(false)
        {
            Hue = 1153; // Pearl white
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Pearls of Heritage");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Pearls of Heritage");
        }

        public PearlsOfHeritage(Serial serial) : base(serial) { }

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
