using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAzerbaijan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAzerbaijan()
        {
            Name = "Treasure Chest of Ancient Azerbaijan";
            Hue = 1871; // A rich red, inspired by Azerbaijani carpets

            // Add themed items to the chest
            AddItem(new FireTempleIncenseBurner(), 0.15);
            AddItem(CreateNamedItem<Fur>("Sheki Silk Carpet", 1173), 0.20);
            AddItem(CreateNamedItem<RandomFancyCoin>("Silk Road Coin"), 0.20);
            AddItem(CreateNamedItem<GreaterCurePotion>("Pomegranate Elixir of Baku", 1443), 0.12);
            AddItem(CreateNamedItem<GreaterStrengthPotion>("Pilaf of the Khans"), 0.15);
            AddItem(CreateNamedItem<RandomFancyStatue>("Maiden Tower Miniature", 1945), 0.13);
            AddItem(CreateNamedItem<RandomFancyLightSource>("Sacred Flame Lantern", 1359), 0.16);
            AddItem(new ChroniclesOfTheLandOfFire(), 1.0);
            AddItem(CreateNamedItem<RandomFancyPainting>("Caspian Seascape Painting"), 0.18);
            AddItem(CreateNamedItem<RandomFancyPlant>("Saffron Crocus"), 0.18);
            AddItem(CreateNamedItem<RandomFancyCrystal>("Khazar’s Crystal"), 0.10);
            AddItem(CreateGoldItem("Caspian Ducat"), 0.18);
            AddItem(CreateColoredItem<Sandals>("Traveler’s Silk Slippers", 1173), 0.14);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateClothing(), 0.21);
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

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
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
            map.Name = "Map of the Silk Road to Baku";
            map.Bounds = new Rectangle2D(2000, 3400, 300, 300);
            map.NewPin = new Point2D(2150, 3550);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Karabakh’s Scimitar: custom stats & skill boosts
            Scimitar weapon = new Scimitar();
            weapon.Name = "Scimitar of Karabakh";
            weapon.Hue = 1931;
            weapon.MinDamage = Utility.Random(24, 37);
            weapon.MaxDamage = Utility.Random(46, 74);
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.Attributes.BonusStr = 12;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.CastSpeed = 1;
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Girdle of the Fire Guardian: cloth armor, magical resists and bonuses
            LeatherChest armor = new LeatherChest();
            armor.Name = "Girdle of the Fire Guardian";
            armor.Hue = 1157;
            armor.BaseArmorRating = Utility.Random(38, 61);
            armor.Attributes.BonusHits = 15;
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.BonusDex = 10;
            armor.Attributes.NightSight = 1;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Merchant's Silk Robe: luck, magery, healing, and charisma!
            Robe robe = new Robe();
            robe.Name = "Merchant's Silk Robe";
            robe.Hue = Utility.RandomList(1173, 1153, 1109); // deep reds, golds, blues
            robe.Attributes.Luck = 75;
            robe.Attributes.BonusInt = 7;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.ItemID, 10.0);
            robe.Attributes.RegenMana = 3;
            robe.Attributes.RegenHits = 2;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Unique deco: Fire Temple Incense Burner (example)
        public class FireTempleIncenseBurner : IncenseBurner
        {
            [Constructable]
            public FireTempleIncenseBurner()
            {
                Name = "Ateshgah Incense Burner";
                Hue = 1359;
                Movable = true;
            }
            public FireTempleIncenseBurner(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public TreasureChestOfAzerbaijan(Serial serial) : base(serial) { }

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

    // Themed lore book!
    public class ChroniclesOfTheLandOfFire : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of Fire", "Scribe of Shirvanshah",
            new BookPageInfo
            (
                "In the ancient shadows of",
                "the Caucasus, on the edge",
                "of the Caspian, lies Azer-",
                "baijan – the Land of Fire.",
                "Here, Zoroastrian flames",
                "have burned for millennia.",
                "Kings and caravans alike",
                "crossed the Silk Road."
            ),
            new BookPageInfo
            (
                "Through Baku’s stone gates,",
                "spices, silks, and tales flowed.",
                "The Maiden Tower watched",
                "as conquerors came and went:",
                "Persians, Khazars, Mongols,",
                "Russians. Yet the land endures,",
                "its carpets woven with stories,",
                "its music echoing east and west."
            ),
            new BookPageInfo
            (
                "From the highland castles of",
                "Sheki, to the fires of Ateshgah,",
                "to the gardens of Ganja, this",
                "is a realm of poets, traders,",
                "and warriors. Pomegranates",
                "grow sweet, and saffron gold",
                "colors pilaf on Nowruz tables.",
                ""
            ),
            new BookPageInfo
            (
                "Legends tell of Dede Korkut,",
                "of Rustam’s heroics, of oil that",
                "bled from the earth and turned",
                "villages to metropolises.",
                "Yet always, the sacred fire burns,",
                "promising warmth, renewal, and",
                "the eternal spirit of the land.",
                ""
            ),
            new BookPageInfo
            (
                "May those who open this chest",
                "honor the past: cherish the flame,",
                "rejoice in the music, and find",
                "fortune on the Silk Road.",
                "",
                "– Inscribed by the Scribe",
                "of Shirvanshah’s Court",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheLandOfFire() : base(false)
        {
            Hue = 1173; // Traditional red of Azerbaijani carpets
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of Fire");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of Fire");
        }

        public ChroniclesOfTheLandOfFire(Serial serial) : base(serial) { }

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
