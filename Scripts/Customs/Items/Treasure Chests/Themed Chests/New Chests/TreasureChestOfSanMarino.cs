using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSanMarino : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSanMarino()
        {
            Name = "Treasure Chest of San Marino";
            Hue = 2418; // Deep blue (color of San Marino’s flag)

            // Add items to the chest
            AddItem(CreateUniqueCoin(), 0.40);
            AddItem(CreateDecorativeRelic(), 0.22);
            AddItem(CreateWineBottle(), 0.13);
            AddItem(CreateMapOfMountTitano(), 0.18);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Book of the Republic"), 0.11);
            AddItem(new ChronicleOfMountTitano(), 1.0);
            AddItem(CreateFlagCloak(), 0.30);
            AddItem(CreateArmor(), 0.27);
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateLongPants(), 0.16);
            AddItem(CreateUniqueFood(), 0.13);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Liberty"), 0.20);
            AddItem(CreateNamedItem<Sextant>("Navigator’s Sextant of San Marino"), 0.10);
            AddItem(CreateColoredItem<BlueBook>("Codex of Laws", 2101), 0.09);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Mount Freedom"), 0.09);
            AddItem(CreateNamedItem<GreaterHealPotion>("Ancient Elixir of Titano"), 0.15);
            AddItem(CreateNamedItem<BodySash>("Sash of the Grand Captain Regent"), 0.19);
            AddItem(CreateUniqueRing(), 0.13);
            AddItem(new Gold(Utility.Random(2000, 6000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateUniqueCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Scudo of the Republic";
            gold.Stackable = true;
            gold.Amount = Utility.RandomMinMax(2, 7);
            gold.Hue = 1281; // Antique gold
            return gold;
        }

        private Item CreateUniqueRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Three Towers";
            ring.Hue = 2105;
            ring.Attributes.Luck = 75;
            ring.Attributes.BonusMana = 6;
            ring.Attributes.SpellChanneling = 1;
            ring.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateWineBottle()
        {
            BottleArtifact wine = new BottleArtifact();
            wine.Name = "Titano Red Wine";
            wine.Hue = 1157;
            return wine;
        }

        private Item CreateUniqueFood()
        {
            Cake cake = new Cake();
            cake.Name = "Torta Tre Monti";
            cake.Hue = 1152;
            return cake;
        }

        private Item CreateFlagCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of San Marino";
            cloak.Hue = 2101; // Light blue/white flag colors
            cloak.Attributes.Luck = 45;
            cloak.Attributes.BonusHits = 12;
            cloak.Attributes.BonusStam = 10;
            cloak.Attributes.RegenHits = 2;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateDecorativeRelic()
        {
            Sculpture1Artifact relic = new Sculpture1Artifact();
            relic.Name = "Marinus’s Marble Relic";
            relic.Hue = 2107;
            return relic;
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

        private Item CreateMapOfMountTitano()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Mount Titano";
            map.Bounds = new Rectangle2D(400, 950, 100, 100);
            map.NewPin = new Point2D(450, 980);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // San Marino = old knightly/republican: Broadsword or Halberd
            BaseWeapon weapon = Utility.RandomBool() ? (BaseWeapon)new Broadsword() : new Halberd();
            weapon.Name = Utility.RandomBool() ? "Halberd of Freedom" : "Broadsword of the Founders";
            weapon.Hue = 1287; // Antique steel
            weapon.MinDamage = Utility.Random(22, 35);
            weapon.MaxDamage = Utility.Random(40, 60);
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.WeaponDamage = 55;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.AttackChance = 10;
            weapon.WeaponAttributes.HitDispel = 15;
            weapon.WeaponAttributes.HitLowerAttack = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Classic San Marino = knightly, but let’s do PlateChest or PlateHelm with big bonuses
            BaseArmor armor = Utility.RandomBool() ? (BaseArmor)new PlateChest() : new PlateHelm();
            armor.Name = Utility.RandomBool() ? "Armor of the Captains Regent" : "Helm of the Three Towers";
            armor.Hue = 2101;
            armor.BaseArmorRating = Utility.Random(45, 70);
            armor.Attributes.BonusHits = 20;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 13.0);
            armor.SkillBonuses.SetValues(1, SkillName.Focus, 9.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Republican Noble’s Breeches";
            pants.Hue = 1154;
            pants.Attributes.Luck = 25;
            pants.Attributes.BonusMana = 6;
            pants.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Inscribe, 10.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        public TreasureChestOfSanMarino(Serial serial) : base(serial) { }

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

    // Book of lore: The Chronicle of Mount Titano
    public class ChronicleOfMountTitano : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Chronicle of Mount Titano", "Written by Gaius di San Marino",
            new BookPageInfo
            (
                "Upon the mighty Mount Titano,",
                "in the year of 301, a humble",
                "stonemason named Marinus",
                "fled the storms of empire.",
                "He sought not conquest, but",
                "freedom. On this mountain,",
                "he built a chapel, and with",
                "faithful friends, sowed liberty."
            ),
            new BookPageInfo
            (
                "From those first stones rose",
                "a fortress of hope. Through",
                "the centuries, San Marino",
                "endured sieges and storms,",
                "its people standing together.",
                "While kingdoms rose and fell,",
                "the Republic remained,",
                "unchained by tyrants."
            ),
            new BookPageInfo
            (
                "Three towers guard our skies:",
                "Guaita, Cesta, Montale—",
                "symbols of strength, vigilance,",
                "and the enduring spirit.",
                "Each stone remembers the",
                "oath: ‘Libertas.’ Here all",
                "are equals, protected by the",
                "laws we craft together."
            ),
            new BookPageInfo
            (
                "Noble and commoner alike",
                "share council. Captains",
                "Regent lead not as kings, but",
                "as stewards. Justice and",
                "peace are our banners,",
                "and each citizen a guardian",
                "of our sacred hill."
            ),
            new BookPageInfo
            (
                "Through wars and tumults,",
                "from Caesar’s shadow to",
                "Napoleon’s thunder, we stood.",
                "San Marino welcomed exiles,",
                "protected the persecuted, and",
                "gave shelter to Garibaldi.",
                "So has our star endured,",
                "burning bright."
            ),
            new BookPageInfo
            (
                "In these pages, find the",
                "story of a people who chose",
                "freedom over fear, peace",
                "over pride, and unity over",
                "empire. Let our mountain",
                "teach all who seek: liberty",
                "endures where the heart",
                "remembers."
            ),
            new BookPageInfo
            (
                "Let those who open this chest",
                "remember: treasures of",
                "San Marino are not gold,",
                "but the courage of free men",
                "and women. May the spirit",
                "of Titano watch over you.",
                "",
                "- Gaius di San Marino"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfMountTitano() : base(false)
        {
            Hue = 2101; // Blue/white of San Marino flag
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Chronicle of Mount Titano");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Chronicle of Mount Titano");
        }

        public ChronicleOfMountTitano(Serial serial) : base(serial) { }

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
