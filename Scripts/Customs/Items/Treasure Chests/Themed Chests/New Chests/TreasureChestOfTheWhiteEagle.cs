using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheWhiteEagle : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheWhiteEagle()
        {
            Name = "Treasure Chest of the White Eagle";
            Hue = 1153; // deep blue, Serbia flag color

            // Decorative artifacts & relics
            AddItem(CreateNamedItem<ArtifactLargeVase>("Serbian Monastery Vase", 1154), 0.18);
            AddItem(CreateNamedItem<SilverSteedZooStatuette>("White Eagle Statuette", 1150), 0.14);
            AddItem(CreateNamedItem<IncenseBurner>("Orthodox Incense Burner", 1161), 0.15);
            AddItem(CreateNamedItem<BookOfTruthArtifact>("The Kosovo Myth", 1151), 0.10);
            AddItem(CreateNamedItem<Candle>("Candle of Saint Sava", 1174), 0.13);

            // Consumables and treasures
            AddItem(CreateColoredItem<GreaterHealPotion>("Monastic Herbal Elixir", 266), 0.19);
            AddItem(CreateGoldItem("Dinar of the Nemanjic Dynasty"), 0.17);
            AddItem(CreateNamedItem<RandomFancyPotion>("Rakija of the Slavs"), 0.15);
            AddItem(CreateNamedItem<RandomFruitBasket>("Fruits of the Morava Valley"), 0.12);
            AddItem(CreateNamedItem<RandomFancyBanner>("Flag of the Serbian Empire"), 0.08);

            // Unique legendary equipment
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateCloak(), 0.17);
            AddItem(CreateCrown(), 0.11);
            AddItem(CreateBoots(), 0.14);

            // The custom book of lore
            AddItem(new ChronicleOfTheWhiteEagle(), 1.0);

            // Bonus coin
            AddItem(new Gold(Utility.Random(1500, 8000)), 0.21);

            // Epic relic from Kosovo field
            AddItem(CreateColoredItem<DecorativeSwordNorth>("Sword of Kosovo Heroes", 2345), 0.12);

            // Final “blessing relic”
            AddItem(CreateColoredItem<GargishKnowledgeTotemArtifact>("Nemanjic Knowledge Totem", 2007), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
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

        private Item CreateNamedItem<T>(string name, int hue = -1) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0) item.Hue = hue;
            return item;
        }

        // Unique Equipment
        private Item CreateWeapon()
        {
            // Legendary Sword of Stefan Nemanja
            Broadsword sword = new Broadsword();
            sword.Name = "Sword of Stefan Nemanja";
            sword.Hue = 1154; // royal blue
            sword.WeaponAttributes.HitLeechHits = 30;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.UseBestSkill = 1;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusHits = 30;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.DefendChance = 10;
            sword.Attributes.WeaponDamage = 40;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            sword.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // "White Eagle" Plate Chest
            PlateChest chest = new PlateChest();
            chest.Name = "White Eagle Plate Chest";
            chest.Hue = 1150; // silver
            chest.BaseArmorRating = 60;
            chest.ArmorAttributes.MageArmor = 1;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.Attributes.BonusStr = 8;
            chest.Attributes.BonusHits = 15;
            chest.Attributes.Luck = 250;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            chest.ColdBonus = 10;
            chest.FireBonus = 10;
            chest.PhysicalBonus = 15;
            chest.EnergyBonus = 8;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateCloak()
        {
            // "Cloak of Tsar Dusan"
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Tsar Dusan";
            cloak.Hue = 1166; // deep red
            cloak.Attributes.LowerManaCost = 12;
            cloak.Attributes.BonusInt = 7;
            cloak.Attributes.RegenMana = 5;
            cloak.Attributes.Luck = 175;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateCrown()
        {
            // "Crown of Saint Sava"
            Circlet crown = new Circlet();
            crown.Name = "Crown of Saint Sava";
            crown.Hue = 1173; // gold
            crown.Attributes.BonusInt = 10;
            crown.Attributes.BonusMana = 10;
            crown.ArmorAttributes.SelfRepair = 4;
            crown.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 18.0);
            crown.SkillBonuses.SetValues(1, SkillName.Healing, 12.0);
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateBoots()
        {
            // "Boots of the Kosovo Field"
            Boots boots = new Boots();
            boots.Name = "Boots of the Kosovo Field";
            boots.Hue = 1155; // blue
            boots.Attributes.BonusDex = 9;
            boots.Attributes.RegenHits = 3;
            boots.SkillBonuses.SetValues(0, SkillName.Stealth, 14.0);
            boots.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public TreasureChestOfTheWhiteEagle(Serial serial) : base(serial)
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

    // Custom Lore Book
    public class ChronicleOfTheWhiteEagle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the White Eagle", "Monk Danilo",
            new BookPageInfo
            (
                "In the ancient land between rivers,",
                "where the Danube and Morava flow,",
                "rose the kingdom of the Serbs,",
                "proud and unconquered.",
                "From Nemanja the Wise,",
                "to Tsar Dusan the Mighty,",
                "the White Eagle soared above all,",
                "keeper of faith and freedom."
            ),
            new BookPageInfo
            (
                "Beneath monastery domes,",
                "icon lamps burned eternal.",
                "Swords clashed on Kosovo field,",
                "where heroes and saints alike fell.",
                "Their sacrifice became legend,",
                "woven into the tapestry",
                "of a nation that endures,",
                "undaunted by shadow or steel."
            ),
            new BookPageInfo
            (
                "The eagle bears two heads,",
                "gazing to the East and the West.",
                "On its wings, memories of empire,",
                "on its heart, the Orthodox cross.",
                "Through fire, betrayal, and song,",
                "the people remain—",
                "defiant and faithful,",
                "ready to rise again."
            ),
            new BookPageInfo
            (
                "O seeker of treasures,",
                "know that true wealth lies not",
                "in gold or steel, but in memory,",
                "in the spirit of the eagle,",
                "in the tales of the brave.",
                "May you carry this wisdom,",
                "and honor the past,",
                "as you claim the White Eagle's prize."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheWhiteEagle() : base(false)
        {
            Hue = 1150; // White/silver, eagle color
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the White Eagle");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the White Eagle");
        }

        public ChronicleOfTheWhiteEagle(Serial serial) : base(serial) { }

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
