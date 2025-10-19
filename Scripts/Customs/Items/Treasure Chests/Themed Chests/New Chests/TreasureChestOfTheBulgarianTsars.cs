using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheBulgarianTsars : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheBulgarianTsars()
        {
            Name = "Treasure Chest of the Bulgarian Tsars";
            Hue = 1276; // Gold-emerald, reminiscent of Bulgarian regalia

            // Add items to the chest
            AddItem(CreateRoseOilElixir(), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Asen", 0x8A5), 0.20);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vessel of Pliska", 2720), 0.10);
            AddItem(CreateColoredItem<SilverSteedZooStatuette>("Silver Horse of Khan Krum", 2101), 0.10);
            AddItem(CreateNamedItem<AncientDrum>("Drum of Kukeri", 2117), 0.09);
            AddItem(CreateNamedItem<Bottle>("Thracian Ritual Wine", 38), 0.12);
            AddItem(CreateGoldItem("Golden Lev"), 0.13);
            AddItem(CreateColoredItem<Ruby>("Ruby of Tarnovo", 1167), 0.14);
            AddItem(CreateNamedItem<GreaterHealPotion>("Vial of Rhodope Healing", 1495), 0.13);
            AddItem(CreateDecorativeItem<IncenseBurner>("Byzantine Incense Burner", 2122), 0.08);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Bogatyr", 1184), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Saint Sofia", 2105), 0.17);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.20);
            AddItem(new ChroniclesOfTheGoldenAge(), 1.0);
            AddItem(new Gold(Utility.Random(1, 6500)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateRoseOilElixir()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Rose Oil Elixir of Kazanlak";
            potion.Hue = 38; // Light pink
            XmlAttach.AttachTo(potion, new XmlLevelItem());
            return potion;
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

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateDecorativeItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Treasure of Veliko Tarnovo";
            map.Bounds = new Rectangle2D(3400, 3100, 300, 200);
            map.NewPin = new Point2D(3500, 3180);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = new Scimitar();
            weapon.Name = "Sword of Tsar Simeon";
            weapon.Hue = 1157; // Regal violet
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.WeaponDamage = 45;
            weapon.Attributes.BonusStr = 8;
            weapon.Attributes.AttackChance = 18;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = new PlateChest();
            armor.Name = "Byzantine Plate of Tarnovo";
            armor.Hue = 2101;
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.Attributes.BonusHits = 10;
            armor.Attributes.ReflectPhysical = 12;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.ColdBonus = 10;
            armor.EnergyBonus = 8;
            armor.FireBonus = 8;
            armor.PhysicalBonus = 18;
            armor.PoisonBonus = 6;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Priestly Vestments of Preslav";
            robe.Hue = 1109;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.LowerRegCost = 18;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfTheBulgarianTsars(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheGoldenAge : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Golden Age", "Petar of Preslav",
            new BookPageInfo
            (
                "In the year 893, crowned",
                "beneath the sacred domes",
                "of Pliska, we, the sons",
                "of Asparukh, bear the",
                "legacy of the horsemen.",
                "",
                "The rivers Iskar and Maritsa",
                "flow red with the tales",
                "of our victories."
            ),
            new BookPageInfo
            (
                "Tsar Simeon, the wise,",
                "stood against the might",
                "of Byzantium, and our",
                "war banners cast shadows",
                "over Constantinople.",
                "",
                "The Cyrillic script,",
                "born in Preslav, gives",
                "voice to our prayers."
            ),
            new BookPageInfo
            (
                "Rose fields bloom in",
                "the Valley of Kazanlak,",
                "fragrant as our faith.",
                "The monks of Rila guard",
                "ancient wisdom, and the",
                "thunder of hooves echoes",
                "from the Rhodope peaks.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Beware the khan's curse:",
                "no invader leaves these",
                "lands unchanged. Let the",
                "brave who seek the chest",
                "honor the spirits of",
                "Pliska, Preslav, and Tarnovo.",
                "",
                "- Petar, Chronicler"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheGoldenAge() : base(false)
        {
            Hue = 1276; // Green-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Golden Age");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Golden Age");
        }

        public ChroniclesOfTheGoldenAge(Serial serial) : base(serial) { }

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
