using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheMarshallIslands : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheMarshallIslands()
        {
            Name = "Treasure Chest of the Marshall Islands";
            Hue = 1362; // Aqua-Blue

            // Add themed treasures!
            AddItem(new NavigatorsWaveStone(), 0.08);
            AddItem(CreateColoredItem<ArtifactLargeVase>("Vase of Ancient Ralik", 1367), 0.15);
            AddItem(CreateColoredItem<FlowerGarland>("Lei of Majuro", 2001), 0.10);
            AddItem(CreateUniqueEquipment(), 0.22);
            AddItem(CreateNavigatorStaff(), 0.20);
            AddItem(CreateShellArmor(), 0.16);
            AddItem(CreateCanoeBuildersApron(), 0.13);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateColoredItem<SeahorseStatuette>("Spirit Seahorse of Arno", 93), 0.12);
            AddItem(CreateCoconutPotion(), 0.18);
            AddItem(CreateWaveChart(), 0.05);
            AddItem(CreateNamedItem<Gold>("Rai Stone Coin", 2415), 0.20);
            AddItem(CreateColoredItem<FancyPainting>("Map of Atolls", 1153), 0.11);
            AddItem(CreateNamedItem<AncientDrum>("Drum of the Navigators", 1109), 0.14);
            AddItem(CreateNavigatorBoots(), 0.17);
            AddItem(CreateSailingRobe(), 0.16);
            AddItem(CreateConchHorn(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
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
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateCoconutPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Coconut of Longevity";
            potion.Hue = 1151;
            return potion;
        }

        private Item CreateUniqueEquipment()
        {
            // Customized magical weapon: "Navigator's Shellblade"
            Katana blade = new Katana();
            blade.Name = "Navigator's Shellblade";
            blade.Hue = 1266; // Pearlescent
            blade.Attributes.WeaponSpeed = 30;
            blade.Attributes.WeaponDamage = 40;
            blade.Attributes.BonusDex = 10;
            blade.Attributes.SpellChanneling = 1;
            blade.Attributes.Luck = 60;
            blade.WeaponAttributes.HitLightning = 30;
            blade.WeaponAttributes.HitLeechHits = 20;
            blade.WeaponAttributes.HitColdArea = 15;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            blade.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateNavigatorStaff()
        {
            // Custom GnarledStaff with navigation bonuses
            GnarledStaff staff = new GnarledStaff();
            staff.Name = "Stick Chart of the Navigator";
            staff.Hue = 1360;
            staff.Attributes.SpellDamage = 18;
            staff.Attributes.BonusInt = 8;
            staff.Attributes.CastRecovery = 2;
            staff.WeaponAttributes.HitLeechMana = 25;
            staff.WeaponAttributes.SelfRepair = 4;
            staff.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            staff.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        private Item CreateShellArmor()
        {
            // Custom BoneChest re-imagined as "Breastplate of Cowrie Shells"
            BoneChest armor = new BoneChest();
            armor.Name = "Breastplate of Cowrie Shells";
            armor.Hue = 2101;
            armor.BaseArmorRating = 54;
            armor.Attributes.Luck = 35;
            armor.Attributes.BonusStam = 12;
            armor.Attributes.BonusHits = 8;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.SkillBonuses.SetValues(0, SkillName.Cartography, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 6.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCanoeBuildersApron()
        {
            FullApron apron = new FullApron();
            apron.Name = "Apron of the Canoe Builder";
            apron.Hue = 1276;
            apron.Attributes.BonusStr = 7;
            apron.Attributes.Luck = 20;
            apron.SkillBonuses.SetValues(0, SkillName.Carpentry, 15.0);
            apron.SkillBonuses.SetValues(1, SkillName.Fishing, 10.0);
            XmlAttach.AttachTo(apron, new XmlLevelItem());
            return apron;
        }

        private Item CreateNavigatorBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Wayfinder's Boots";
            boots.Hue = 1358;
            boots.Attributes.NightSight = 1;
            boots.Attributes.BonusDex = 6;
            boots.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateSailingRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Wave-Priest";
            robe.Hue = 1154;
            robe.Attributes.BonusMana = 9;
            robe.Attributes.BonusHits = 4;
            robe.Attributes.CastSpeed = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 8.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 5.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateConchHorn()
        {
            // Decorative but could be used for roleplay or events
            RandomFancyInstrument horn = new RandomFancyInstrument();
            horn.Name = "Sacred Conch Horn";
            horn.Hue = 2105;
            return horn;
        }

        private Item CreateWaveChart()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Navigational Wave Chart";
            map.Bounds = new Rectangle2D(1456, 3692, 340, 265); // Random ocean coordinates
            map.NewPin = new Point2D(1580, 3750);
            map.Protected = true;
            return map;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheWaveNavigators();
        }

        public TreasureChestOfTheMarshallIslands(Serial serial) : base(serial)
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

    public class NavigatorsWaveStone : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Navigator’s Wave Stone", "Old Wavefinder",
            new BookPageInfo
            (
                "This smooth stone, found",
                "on the shores of Majuro,",
                "was passed from navigator",
                "to navigator. When wet, it",
                "is said to shimmer with the",
                "pattern of distant waves.",
                "To hold it is to know the",
                "secrets of the ocean swells."
            ),
            new BookPageInfo
            (
                "The first people who",
                "came to these isles read",
                "the sea and the sky,",
                "carving their paths not",
                "by land but by the rhythm",
                "of tides and the pull of",
                "the moon. This stone",
                "remembers their songs."
            )
        );
        public override BookContent DefaultContent => Content;

        [Constructable]
        public NavigatorsWaveStone() : base(false)
        {
            Hue = 1352;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Navigator’s Wave Stone");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Navigator’s Wave Stone");
        }

        public NavigatorsWaveStone(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheWaveNavigators : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Wave Navigators", "Matowaan the Wavekeeper",
            new BookPageInfo
            (
                "Upon these atolls, land",
                "is a whisper between sky",
                "and sea. Our ancestors",
                "crossed the great blue",
                "deserts not by sight, but",
                "by memory, wave, and",
                "star. Their canoes were",
                "as birds on the endless sea."
            ),
            new BookPageInfo
            (
                "We speak the names:",
                "Ratak, Ralik. Chains of",
                "atolls, guardians of the",
                "Equator. Here, men read",
                "the shape of water. Our",
                "charts are sticks and shells,",
                "telling stories of swells",
                "and the winds of gods."
            ),
            new BookPageInfo
            (
                "When storms came, we",
                "sang for peace. When war",
                "came, we built shelters of",
                "shell and palm. Each island",
                "holds a tale: a lost canoe,",
                "a foreign ship, the coming",
                "of iron, fire, and sorrow.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "But always, the sea",
                "remains our road and",
                "our heart. In our veins,",
                "salt and song. In our",
                "dreams, turtles and",
                "the drifting stars.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May you who find this",
                "chest honor the tides,",
                "the voices of those who",
                "navigated by trust and",
                "courage. The ocean is",
                "never conquered, only",
                "befriended, and feared.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Remember, the greatest",
                "treasure is not gold, but",
                "the knowledge of the waves,",
                "the harmony of island and",
                "sea. Respect the ocean,",
                "for it is both cradle and",
                "judge of the Marshallese.",
                "",
                ""
            )
        );
        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheWaveNavigators() : base(false)
        {
            Hue = 1367;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Wave Navigators");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Wave Navigators");
        }

        public ChroniclesOfTheWaveNavigators(Serial serial) : base(serial) { }

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

    // Add any other helper classes or items here as needed (e.g. HornOfBlasting if it's not in your distro)
}
