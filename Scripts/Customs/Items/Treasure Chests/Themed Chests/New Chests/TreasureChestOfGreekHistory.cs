using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGreekHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGreekHistory()
        {
            Name = "Treasure Chest of Greek History";
            Hue = 1153; // White marble

            // Add unique themed items
            AddItem(CreateDecorative("Parthenon Marble Fragment", typeof(ArtifactLargeVase), 1153), 0.25);
            AddItem(CreateDecorative("Oracle of Delphi’s Incense Burner", typeof(IncenseBurner), 1289), 0.18);
            AddItem(CreateDecorative("Statue of Athena Parthenos", typeof(ManStatuetteSouthArtifact), 1175), 0.15);
            AddItem(CreateDecorative("Golden Laurel Wreath", typeof(FancyCopperSunflower), 2213), 0.10);
            AddItem(CreateDecorative("Scroll of Plato’s Dialogues", typeof(AcademicBooksArtifact), 1150), 0.17);
            AddItem(CreateDecorative("Athenian Hoplite Shield", typeof(DecorativeShield5), 1271), 0.20);
            AddItem(CreateDecorative("Spartan Training Spear", typeof(Bardiche), 2949), 0.14);

            // Legendary consumables
            AddItem(CreateConsumable("Nectar of the Gods", typeof(GreenTea), 1169), 0.17);
            AddItem(CreateConsumable("Ambrosia Cake", typeof(Cake), 1151), 0.12);
            AddItem(CreateConsumable("Oracle’s Red Wine", typeof(BottleArtifact), 1157), 0.13);
            AddItem(CreateConsumable("Spartan Rye Bread", typeof(BreadLoaf), 1150), 0.18);

            // Unique Equipment
            AddItem(CreateArmor("Leonidas' Hoplite Shield", typeof(HeaterShield), 1271), 0.20);
            AddItem(CreateArmor("Athenian Philosopher’s Robe", typeof(Robe), 1153), 0.18);
            AddItem(CreateWeapon("Odysseus’ Cunning Dagger", typeof(Dagger), 1159), 0.17);
            AddItem(CreateWeapon("Zeus' Thunderbolt", typeof(MagicWand), 1161), 0.13);
            AddItem(CreateArmor("Helm of Hades", typeof(CloseHelm), 1175), 0.11);
            AddItem(CreateClothing("Sandals of Hermes", typeof(Sandals), 1170), 0.17);

            // Lore Book
            AddItem(new BookOfGreekHistory(), 1.0);

            // Extra gold, gems, map, etc.
            AddItem(new Gold(Utility.Random(1500, 7000)), 0.18);
            AddItem(CreateDecorative("Aegean Sapphire", typeof(Ruby), 1139), 0.11);
            AddItem(CreateMap(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative artifact creator
        private Item CreateDecorative(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumable creator
        private Item CreateConsumable(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            if (item is BasePotion potion)
                potion.Stackable = true;
            return item;
        }

        // Unique Clothing
        private Item CreateClothing(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            if (item is BaseClothing c)
            {
                c.Attributes.Luck = 35;
                c.Attributes.NightSight = 1;
                c.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
                c.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            }
            XmlAttach.AttachTo(item, new XmlLevelItem());
            return item;
        }

        // Unique Armor
        private Item CreateArmor(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            if (item is BaseArmor a)
            {
                a.Attributes.BonusStr = 10;
                a.Attributes.BonusHits = 20;
                a.ArmorAttributes.SelfRepair = 4;
                a.ArmorAttributes.LowerStatReq = 30;
                a.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
                a.SkillBonuses.SetValues(1, SkillName.Swords, 10.0);
            }
            XmlAttach.AttachTo(item, new XmlLevelItem());
            return item;
        }

        // Unique Weapon
        private Item CreateWeapon(string name, Type t, int hue)
        {
            Item item = (Item)Activator.CreateInstance(t);
            item.Name = name;
            item.Hue = hue;
            if (item is BaseWeapon w)
            {
                w.MinDamage = Utility.Random(20, 45);
                w.MaxDamage = Utility.Random(50, 90);
                w.Attributes.BonusDex = 7;
                w.Attributes.CastSpeed = 2;
                w.Attributes.SpellChanneling = 1;
                w.WeaponAttributes.HitLightning = 25;
                w.SkillBonuses.SetValues(0, SkillName.Fencing, 12.0);
            }
            XmlAttach.AttachTo(item, new XmlLevelItem());
            return item;
        }

        // Special Greek Lore Map
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost Labyrinth of Crete";
            map.Bounds = new Rectangle2D(1200, 2200, 350, 350);
            map.NewPin = new Point2D(1400, 2400);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfGreekHistory(Serial serial) : base(serial) { }
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

    public class BookOfGreekHistory : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Greece", "Herodotus the Historian",
            new BookPageInfo
            (
                "In the dawn of the world,",
                "the gods walked among men.",
                "Mount Olympus ruled above,",
                "while mortals strove for glory",
                "and the favor of fate.",
                "",
                "The city-states—Athens,",
                "Sparta, Corinth—rose from"
            ),
            new BookPageInfo
            (
                "sea and stone. Warriors",
                "battled for honor at Troy,",
                "and philosophers searched",
                "for truth beneath olive",
                "trees. The Olympic Games",
                "echoed the strength of",
                "heroes, and poets sang",
                "of love, war, and wonder."
            ),
            new BookPageInfo
            (
                "The Persians came as a wave,",
                "but were turned at Marathon,",
                "Thermopylae, and Salamis.",
                "Leonidas and his Spartans",
                "stood defiant at the pass.",
                "Athens built temples of",
                "marble and wisdom, while",
                "Oracles whispered fate."
            ),
            new BookPageInfo
            (
                "Yet pride brings downfall.",
                "Athens fell to Sparta. Then",
                "came Alexander, the Great,",
                "uniting Greece and marching",
                "to the ends of the earth.",
                "The gods grew silent.",
                "Philosophers questioned all.",
                "The old world faded."
            ),
            new BookPageInfo
            (
                "But their stories endure.",
                "Let he who finds this chest",
                "remember: greatness springs",
                "from struggle, wisdom from",
                "debate, and heroism from",
                "the hearts of mortals.",
                "",
                "- Herodotus"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfGreekHistory() : base(false)
        {
            Hue = 1175; // Classic parchment
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Greece");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Greece");
        }

        public BookOfGreekHistory(Serial serial) : base(serial) { }

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
