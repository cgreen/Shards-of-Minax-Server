using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNigerEmpires : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNigerEmpires()
        {
            Name = "Treasure Chest of Niger’s Empires";
            Hue = 2125; // Golden sand

            // Decorative, cultural, and rare treasure
            AddItem(CreateColoredItem<ArtifactVase>("Songhai Gold Urn", 2213), 0.18);
            AddItem(CreateColoredItem<Apple>("Block of Ancient Salt", 1153), 0.15);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Timbuktu Manuscript"), 0.16);
            AddItem(CreateColoredItem<CraneZooStatuette>("Desert Crane Statuette", 1154), 0.13);
            AddItem(CreateNamedItem<RandomFancyInstrument>("Djembe Drum of the Griot"), 0.11);
            AddItem(CreateNamedItem<GoldBricks>("Gold Ingots of Gao"), 0.15);
            AddItem(CreateColoredItem<BambooChair>("Sultan’s Ebony Throne", 1908), 0.13);
            AddItem(CreateNamedItem<RandomFancyPlant>("Desert Rose in a Vase"), 0.15);
            AddItem(CreateNamedItem<RoundPaperLantern>("Tuareg Blue Lantern"), 1272);
            AddItem(CreateNamedItem<RandomFancyStatue>("Statuette of a Camel Caravan"), 0.14);
            AddItem(CreateNamedItem<AncientRunes>("Engraved Stone of the Ancients"), 0.11);

            // Unique consumables
            AddItem(CreateColoredItem<GreaterHealPotion>("Elixir of the Sahara", 2125), 0.19);
            AddItem(CreateNamedItem<BowlOfRotwormStew>("Camel Jerky Bowl"), 0.09);
            AddItem(CreateColoredItem<BottleArtifact>("Desert Wine", 1656), 0.13);
            AddItem(CreateNamedItem<RandomFancyBakedGoods>("Sweet Millet Bread"), 0.15);
            AddItem(CreateNamedItem<RandomFruitBasket>("Basket of Dried Dates"), 0.17);
            AddItem(CreateNamedItem<RandomFancyPotion>("Potion of Sandstorm Sight"), 0.11);

            // Themed equipment
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateLongRobe(), 0.16);
            AddItem(CreateDesertCloak(), 0.16);
            AddItem(CreateTuaregMask(), 0.15);

            // Lore book
            AddItem(new SonghaiChronicles(), 1.0);

            // Currency
            AddItem(CreateGoldItem("Gold Dinar of the Niger Empire"), 0.19);

            // Miscellaneous
            AddItem(new Gold(Utility.Random(1000, 4000)), 0.15);
            AddItem(CreateMap(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Trans-Saharan Trade Route";
            map.Bounds = new Rectangle2D(500, 1500, 600, 600);
            map.NewPin = new Point2D(800, 1800);
            map.Protected = true;
            return map;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(),
                new LeatherDo(),
                new LeafChest(),
                new DragonChest()
            );
            armor.Name = "Mail of the Songhai Guard";
            armor.Hue = 1272; // Blue of the Tuareg veil
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.Attributes.LowerManaCost = 7;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.RegenHits = 3;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            armor.SkillBonuses.SetValues(2, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(),
                new Spear(),
                new CrescentBlade(),
                new Katana()
            );
            weapon.Name = "Blade of the Sahel";
            weapon.Hue = 2125; // Gold sand
            weapon.MaxDamage = Utility.Random(45, 80);
            weapon.Attributes.BonusDex = 15;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.Attributes.AttackChance = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 14.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Cartography, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLongRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Scholar’s Robe of Timbuktu";
            robe.Hue = 1154; // Pale sand
            robe.Attributes.BonusInt = 10;
            robe.Attributes.Luck = 20;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.TasteID, 20.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDesertCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Desert Wind";
            cloak.Hue = 1359; // Rust red
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusMana = 7;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Cartography, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateTuaregMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Veil of the Tuareg";
            mask.Hue = 1272; // Deep blue
            mask.Attributes.BonusDex = 5;
            mask.Attributes.RegenStam = 2;
            mask.SkillBonuses.SetValues(0, SkillName.Cartography, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.Anatomy, 5.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        public TreasureChestOfNigerEmpires(Serial serial) : base(serial)
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

    public class SonghaiChronicles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Niger’s Empires", "by The Griot of Gao",
            new BookPageInfo
            (
                "In the sun-baked valleys,",
                "along the mighty Niger",
                "River, kingdoms were born.",
                "From Nok’s clay to the",
                "golden courts of Mali,",
                "kings ruled over trade,",
                "scholarship, and sand.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Salt and gold flowed,",
                "crossing the dunes in",
                "caravans led by blue-veiled",
                "Tuareg. In Gao, Songhai",
                "rose, wielding blades of",
                "iron and wisdom of the",
                "timbuktu manuscripts.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Here, griots sang of",
                "heroes and empires. The",
                "Sahara was a road, not a",
                "barrier. Sorcerers, scribes,",
                "and soldiers gathered at",
                "the mosque, sharing lore.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "But even rivers change.",
                "Empires faded. Sand crept",
                "in. Yet beneath the dunes,",
                "treasures remain: gold,",
                "wisdom, and the stories",
                "of Niger, waiting to be",
                "unearthed by the bold.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let this chest be a",
                "reminder: the wealth of",
                "Niger is more than gold.",
                "It is in its memory, its",
                "scholarship, its song.",
                "",
                "- The Griot of Gao",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SonghaiChronicles() : base(false)
        {
            Hue = 1272; // Tuareg blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Niger’s Empires");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Niger’s Empires");
        }

        public SonghaiChronicles(Serial serial) : base(serial) { }

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
