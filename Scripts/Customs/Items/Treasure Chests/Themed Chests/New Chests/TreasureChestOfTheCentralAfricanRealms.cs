using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheCentralAfricanRealms : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheCentralAfricanRealms()
        {
            Name = "Treasure Chest of the Central African Realms";
            Hue = 2213; // earthy deep red, suggestive of the soil

            // Add items to the chest with themed names and hues
            AddItem(CreateDiamond("Blood Diamond of Mbaïki"), 0.20);
            AddItem(CreateNamedItem<Gold>("Ivory Coast Tribute"), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Sango Shaman's Remedy", 1266), 0.17);
            AddItem(CreateDecorativeMask(), 0.13);
            AddItem(CreateNamedItem<WolfStatue>("Mbaka Spirit Wolf Statue"), 0.11);
            AddItem(new ChroniclesOfUbangiShari(), 1.0); // Custom lore book
            AddItem(CreateColoredItem<RandomFancyCoin>("Central African Franc", 2597), 0.23);
            AddItem(CreateNamedItem<SilverMirror>("Mirror of the Ubangi River"), 0.12);
            AddItem(CreateColoredItem<Robe>("Robes of the Banda Griot", 2115), 0.19);
            AddItem(CreateNamedItem<CrystalBallStatuette>("Oracle of the Savannah"), 0.13);
            AddItem(CreateFoodBasket(), 0.18);
            AddItem(CreateDrum(), 0.16);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateBoots(), 0.21);
            AddItem(CreateShield(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDiamond(string name)
        {
            Diamond diamond = new Diamond();
            diamond.Name = name;
            diamond.Hue = 1150; // Rich, blood-red diamond
            return diamond;
        }

        private Item CreateDecorativeMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mask of the Spirit Dancers";
            mask.Hue = 1424; // Vibrant African color
            mask.Attributes.Luck = 40;
            mask.SkillBonuses.SetValues(0, SkillName.Musicianship, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.Provocation, 10.0);
            mask.Attributes.NightSight = 1;
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
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

        private Item CreateFoodBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Harvest Basket of the Ubangi";
            basket.Hue = 2112; // Rich green
            return basket;
        }

        private Item CreateDrum()
        {
            AncientDrum drum = new AncientDrum();
            drum.Name = "Griot's Talking Drum";
            drum.Hue = 1800;
            return drum;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Spear(), new Scimitar(), new WarAxe(), new QuarterStaff()
            );
            weapon.Name = "Blade of the Banda King";
            weapon.Hue = 1155;
            weapon.MaxDamage = Utility.Random(35, 75);
            weapon.Attributes.BonusStam = 10;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.WeaponAttributes.HitLightning = 12;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new BoneChest(), new PlateHelm(), new StuddedArms()
            );
            armor.Name = "Savannah Warrior's Plate";
            armor.Hue = 1852;
            armor.BaseArmorRating = Utility.Random(33, 60);
            armor.Attributes.BonusStr = 12;
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBoots()
        {
            Sandals boots = new Sandals();
            boots.Name = "Sandals of the Rainforest Scout";
            boots.Hue = 1439;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.LowerManaCost = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Sango's Bulwark";
            shield.Hue = 2109;
            shield.Attributes.DefendChance = 15;
            shield.ArmorAttributes.LowerStatReq = 20;
            shield.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        public TreasureChestOfTheCentralAfricanRealms(Serial serial) : base(serial) { }

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

    public class ChroniclesOfUbangiShari : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Ubangi-Shari: The Heart of Africa", "M'Boma, Griot of the Realms",
            new BookPageInfo
            (
                "In the lands where the rivers",
                "Sangha and Ubangi meet,",
                "the Banda, the Gbaya,",
                "the Zande, and the Mandjia",
                "wove their kingdoms from",
                "the endless green.",
                "Elephants walked with kings,",
                "and the drums spoke wisdom."
            ),
            new BookPageInfo
            (
                "Then came the strangers:",
                "Arabs with ivory and salt,",
                "then the French with iron",
                "and fire. The lands of gold,",
                "diamond, and mahogany",
                "became Ubangi-Shari,",
                "a name not of our tongue.",
                "Yet the spirits watched."
            ),
            new BookPageInfo
            (
                "Through blood and labor,",
                "the people endured.",
                "Beneath the tricolor flag,",
                "Barthélemy Boganda dreamt",
                "of unity, of a song",
                "for all peoples. His words",
                "still echo in the wind,",
                "beyond the war drums."
            ),
            new BookPageInfo
            (
                "Now the rivers run free,",
                "but turmoil lingers.",
                "Diamonds glint beneath",
                "red soil, and the jungle",
                "still hides its secrets.",
                "Yet, the heart of Africa",
                "beats strong and proud—",
                "unbroken, undying."
            ),
            new BookPageInfo
            (
                "Let those who open this chest",
                "remember: Our story is",
                "not of conquerors, but of",
                "survivors, dreamers, and",
                "spirits that will not fade.",
                "In the shade of the baobab,",
                "the ancestors gather still.",
                "Ndoye, the song never ends."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfUbangiShari() : base(false)
        {
            Hue = 2109; // Deep green, jungle-inspired
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Ubangi-Shari");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Ubangi-Shari");
        }

        public ChroniclesOfUbangiShari(Serial serial) : base(serial) { }

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
