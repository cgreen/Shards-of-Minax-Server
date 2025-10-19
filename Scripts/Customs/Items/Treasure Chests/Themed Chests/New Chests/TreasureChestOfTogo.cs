using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTogo : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTogo()
        {
            Name = "Treasure Chest of Togo's Legacy";
            Hue = 2109; // deep gold

            // Add items to the chest
            AddItem(CreateKenteCloth(), 0.15);
            AddItem(CreateVodunIdol(), 0.10);
            AddItem(CreateColonialCoin(), 0.25);
            AddItem(CreateNamedItem<BodySash>("Sash of Lomé Royalty"), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Ewe Queen"), 0.16);
            AddItem(CreateColoredItem<BowlArtifact>("Ceremonial Bowl of the Ancestors", 2212), 0.18);
            AddItem(CreateNamedItem<RandomFancyPottery>("Goblet of Sacred Palm Wine"), 0.13);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Warrior King"), 0.20);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Oracle"), 0.14);
            AddItem(CreateColoredItem<WolfStatue>("Guardian Lion-Dog of Togo", 2500), 0.11);
            AddItem(CreateNamedItem<GreaterCurePotion>("Togo Herbal Remedy"), 0.19);
            AddItem(CreateNamedItem<GreaterHealPotion>("Elixir of the Savannah"), 0.17);
            AddItem(CreateNamedItem<Banana>("Bunch of Wild Togo Bananas"), 0.20);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateRoyalKenteRobe(), 0.16);
            AddItem(CreateVodunTalisman(), 0.15);
            AddItem(CreateLomeMap(), 0.06);
            AddItem(new ChroniclesOfTogo(), 1.0);
            AddItem(new Gold(Utility.Random(1, 5000)), 0.12);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateKenteCloth()
        {
            BodySash kente = new BodySash();
            kente.Name = "Handwoven Kente Sash";
            kente.Hue = 1358; // Vibrant Kente colors
            kente.Attributes.Luck = 30;
            kente.SkillBonuses.SetValues(0, SkillName.Tailoring, 10.0);
            return kente;
        }

        private Item CreateVodunIdol()
        {
            EvilIdolSkull idol = new EvilIdolSkull();
            idol.Name = "Vodun Spirit Idol";
            idol.Hue = 1109;
            return idol;
        }

        private Item CreateColonialCoin()
        {
            Gold coin = new Gold();
            coin.Name = "Colonial Franc of Togoland";
            coin.Amount = Utility.Random(500, 1500);
            return coin;
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

        private Item CreateRoyalKenteRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Robe of Kente";
            robe.Hue = 1358;
            robe.Attributes.LowerManaCost = 12;
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusHits = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateVodunTalisman()
        {
            RandomFancyCrystal talisman = new RandomFancyCrystal();
            talisman.Name = "Vodun Protection Talisman";
            talisman.Hue = 1109;
            return talisman;
        }

        private Item CreateLomeMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Lomé";
            map.Bounds = new Rectangle2D(1200, 3400, 500, 300);
            map.NewPin = new Point2D(1300, 3550);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // African-themed unique sword (Scimitar or Katana as base)
            BaseWeapon weapon = Utility.RandomBool() ? (BaseWeapon)new Scimitar() : new Katana();
            weapon.Name = "Sword of the Togo King";
            weapon.Hue = 2109;
            weapon.MaxDamage = Utility.Random(35, 70);
            weapon.Attributes.BonusStr = 8;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.WeaponAttributes.HitLightning = 22;
            weapon.WeaponAttributes.HitLeechHits = 18;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Themed plate or leaf chest
            BaseArmor armor = Utility.RandomBool() ? (BaseArmor)new PlateChest() : new LeafChest();
            armor.Name = "Armor of the Ewe Warriors";
            armor.Hue = 2109;
            armor.BaseArmorRating = Utility.Random(40, 65);
            armor.Attributes.BonusHits = 18;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 8.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            armor.ColdBonus = 8;
            armor.EnergyBonus = 10;
            armor.PhysicalBonus = 15;
            armor.FireBonus = 12;
            armor.PoisonBonus = 10;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        public TreasureChestOfTogo(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTogo : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Togo", "The Griot of the Land",
            new BookPageInfo
            (
                "From the ancient forests",
                "of Atakora, to the waves",
                "that kiss the Gulf of",
                "Guinea, Togo's story",
                "is woven with kings,",
                "mystics, and traders."
            ),
            new BookPageInfo
            (
                "Long before the Europeans,",
                "the Ewe, Mina, and Kabye",
                "people forged alliances.",
                "Notsé’s walls rose to guard",
                "the people from raids and",
                "the world beyond."
            ),
            new BookPageInfo
            (
                "Kente cloths adorned",
                "royalty and priests.",
                "Palm wine flowed in",
                "sacred rites. The land",
                "echoed with drums and",
                "chants to the Vodun spirits."
            ),
            new BookPageInfo
            (
                "Colonial shadows arrived.",
                "Germany first called it",
                "Togoland. Later, British",
                "and French divided the",
                "land, but the soul of Togo",
                "remained unbroken."
            ),
            new BookPageInfo
            (
                "The spirit of the Ewe",
                "Kings endured. Farmers,",
                "fishermen, and artisans",
                "kept their stories alive.",
                "The sacred forests",
                "whispered the old ways."
            ),
            new BookPageInfo
            (
                "In 1960, Togo stood free.",
                "Flags rose in Lomé, and",
                "the voices of ancestors",
                "rejoiced. Yet, the journey",
                "of the nation continued,",
                "with dreams and struggle."
            ),
            new BookPageInfo
            (
                "May this chest be a",
                "reminder: Togo’s legacy",
                "is endurance, faith, and",
                "hope. The lion’s heart",
                "still beats in the West",
                "African sun."
            ),
            new BookPageInfo
            (
                "Let all who open this",
                "chest know: The spirit",
                "of Togo cannot be",
                "conquered. Treasure",
                "the wisdom and the",
                "pride within.",
                "",
                "- The Griot"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTogo() : base(false)
        {
            Hue = 2109; // golden
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Togo");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Togo");
        }

        public ChroniclesOfTogo(Serial serial) : base(serial) { }

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
