using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBrazilsHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBrazilsHistory()
        {
            Name = "Treasure Chest of Brazil's History";
            Hue = 1425; // Vibrant jungle green

            // Add themed loot!
            AddItem(CreateDecor("ArtifactLargeVase", "Marajoara Pottery", 1277), 0.13);
            AddItem(CreateDecor("TropicalBirdStatue", "Macaw Idol", 1153), 0.09);
            AddItem(CreateNamedItem<Gold>("Gold Nugget from Serra Pelada"), 0.22);
            AddItem(CreateNamedItem<GreaterHealPotion>("Potion of Amazonian Vitality"), 0.16);
            AddItem(CreateNamedItem<SackOfSugar>("Brazilian Sugarcane"), 0.19);
            AddItem(CreateNamedItem<GreenTea>("Cup of Minas Coffee"), 0.18);
            AddItem(CreateNamedItem<RandomFancyBanner>("Flag of the Empire"), 0.14);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateCarnivalCloak(), 0.13);
            AddItem(CreateIndigenousMask(), 0.13);
            AddItem(new ChroniclesOfBrazil(), 1.0);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Rainforest"), 0.16);
            AddItem(CreateNamedItem<GreaterHealPotion>("Elixir of Samba Energy"), 0.10);
            AddItem(CreateNamedItem<FlowerGarland>("Garland of the Amazon"), 0.11);
            AddItem(CreateNamedItem<Banana>("Banana from Bahia"), 0.20);
            AddItem(CreateNamedItem<RandomFancyInstrument>("Berimbau of the Capoeira Master"), 0.10);
            AddItem(CreateNamedItem<StatCapOrb>("Signed Futebol Ball"), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string typeName, string name, int hue)
        {
            Type t = ScriptCompiler.FindTypeByName(typeName);
            if (t == null) return null;
            Item decor = (Item)Activator.CreateInstance(t);
            decor.Name = name;
            decor.Hue = hue;
            return decor;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateCarnivalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Carnival Cloak of Rio";
            cloak.Hue = Utility.RandomList(1165, 1175, 1161, 1167); // Festive colors
            cloak.Attributes.Luck = 75;
            cloak.Attributes.BonusHits = 15;
            cloak.Attributes.BonusStam = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Discordance, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateIndigenousMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mask of Tupinambá Chief";
            mask.Hue = Utility.RandomList(1153, 1160, 1192);
            mask.Attributes.BonusStr = 10;
            mask.Attributes.BonusInt = 10;
            mask.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Bardiche(), new GnarledStaff(), new Katana());
            weapon.Name = Utility.RandomList(
                "Sword of Tiradentes",
                "Lance of Dom Pedro",
                "Staff of Zumbi dos Palmares",
                "Blade of the Amazon"
            );
            weapon.Hue = Utility.RandomMinMax(1366, 1457); // Gold, emerald, or blue
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.WeaponDamage = 35;
            weapon.Attributes.CastSpeed = 1;
            weapon.Attributes.CastRecovery = 2;
            weapon.Attributes.LowerManaCost = 10;
            weapon.Attributes.BonusStam = 10;
            weapon.Slayer = Utility.RandomList(SlayerName.ReptilianDeath, SlayerName.ArachnidDoom);
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new LeatherDo(), new StuddedChest(), new DragonTurtleHideChest());
            armor.Name = Utility.RandomList(
                "Breastplate of Independence",
                "Armor of the Bandeirantes",
                "Hide of the Jaguar",
                "Imperial Parade Armor"
            );
            armor.Hue = Utility.RandomMinMax(1366, 1425); // Earthy or gold
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusMana = 8;
            armor.Attributes.Luck = 30;
            armor.ArmorAttributes.SelfRepair = 3;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Gold";
            map.Bounds = new Rectangle2D(1700, 1800, 600, 600); // Somewhere wild!
            map.NewPin = new Point2D(1950, 1950);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfBrazilsHistory(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBrazil : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Brazil: From Forests to Future", "Narrated by the Jaguar Spirit",
            new BookPageInfo
            (
                "Before the world was mapped,",
                "I roamed the forests and rivers,",
                "with the Tupi and Guarani. The",
                "land was green, wild, alive.",
                "Then came sails, thunder,",
                "and the golden dream.",
                "The people changed. The land",
                "remembered."
            ),
            new BookPageInfo
            (
                "The Portuguese crown claimed",
                "me, trading pau-brasil for steel.",
                "Missions rose, gold gleamed,",
                "and chains bound millions.",
                "Quilombos grew strong, and",
                "heroes like Zumbi fought.",
                "Freedom, always a struggle,",
                "tasted sweet as sugarcane."
            ),
            new BookPageInfo
            (
                "From Rio to Bahia, music bloomed.",
                "Samba's rhythm, carnival's colors.",
                "Empires fell; a nation was born.",
                "Tiradentes dreamed of liberty,",
                "Dom Pedro broke the chains.",
                "Coffee ruled, rubber bled the wild.",
                "Cities soared skyward. Hope remained."
            ),
            new BookPageInfo
            (
                "Through chaos, unity emerged.",
                "Futebol and faith, joy and sorrow.",
                "Rainforest whispers secrets lost,",
                "but the jaguar’s heart beats still.",
                "Now, you hold this history.",
                "Treasure the riches, honor the pain.",
                "Brazil endures in spirit, song,",
                "and the undying forest."
            ),
            new BookPageInfo
            (
                "May this chest remind you:",
                "greatness is struggle, gold is",
                "earned, and no jungle is ever",
                "tamed for long.",
                "",
                "- The Jaguar Spirit"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBrazil() : base(false)
        {
            Hue = 1437; // Jungle green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Brazil: From Forests to Future");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Brazil: From Forests to Future");
        }

        public ChroniclesOfBrazil(Serial serial) : base(serial) { }

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
