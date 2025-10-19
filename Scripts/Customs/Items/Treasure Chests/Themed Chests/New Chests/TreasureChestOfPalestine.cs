using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPalestine : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPalestine()
        {
            Name = "Treasure Chest of Palestine";
            Hue = 1425; // Olive green

            // Add items to the chest
            AddItem(new OliveBranchRelic(), 0.18);
            AddItem(CreateColoredItem<ArtifactVase>("Mosaic Vase of Jericho", 2118), 0.13);
            AddItem(CreateColoredItem<IncenseBurner>("Incense Burner of Jerusalem", 2407), 0.10);
            AddItem(CreateNamedItem<BowlOfRotwormStew>("Bowl of Maqluba"), 0.13);
            AddItem(CreateOliveOil(), 0.15);
            AddItem(CreateBread(), 0.16);
            AddItem(new ChroniclesOfTheOliveLand(), 1.0);
            AddItem(CreateNamedItem<Gold>("Byzantine Gold Coin"), 0.18);
            AddItem(CreateColoredItem<Ruby>("Red Carnelian of Hebron", 33), 0.12);
            AddItem(CreateMap(), 0.09);
            AddItem(CreateSandals(), 0.17);
            AddItem(CreateKeffiyeh(), 0.14);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateLongPants(), 0.15);
            AddItem(CreateRobe(), 0.14);
            AddItem(CreateDagger(), 0.13);
            AddItem(CreateArtifact("Ancient Mosaic Tile", 2413), 0.20);
            AddItem(CreateArtifact("Prayer Beads of Safed", 2003), 0.13);
            AddItem(CreateArtifact("Key of the Old City", 2223), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
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

        private Item CreateArtifact(string name, int hue)
        {
            ArtifactLargeVase artifact = new ArtifactLargeVase();
            artifact.Name = name;
            artifact.Hue = hue;
            return artifact;
        }

        private Item CreateOliveOil()
        {
            GreenBottle bottle = new GreenBottle();
            bottle.Name = "Olive Oil of Healing";
            bottle.Hue = 1425;
            bottle.LootType = LootType.Blessed;
            return bottle;
        }

        private Item CreateBread()
        {
            BreadLoaf bread = new BreadLoaf();
            bread.Name = "Bread of Resilience";
            bread.Hue = 2207;
            bread.LootType = LootType.Blessed;
            return bread;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Palestine";
            map.Bounds = new Rectangle2D(100, 100, 600, 600);
            map.NewPin = new Point2D(370, 420);
            map.Protected = true;
            return map;
        }

        private Item CreateSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Desert Walker";
            sandals.Hue = 2118;
            sandals.Attributes.Luck = 40;
            sandals.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateKeffiyeh()
        {
            Bandana keffiyeh = new Bandana();
            keffiyeh.Name = "Keffiyeh of the Shepherd";
            keffiyeh.Hue = 1150;
            keffiyeh.Attributes.BonusHits = 15;
            keffiyeh.Attributes.RegenHits = 2;
            keffiyeh.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            keffiyeh.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 7.0);
            keffiyeh.SkillBonuses.SetValues(2, SkillName.Herding, 12.0);
            XmlAttach.AttachTo(keffiyeh, new XmlLevelItem());
            return keffiyeh;
        }

        private Item CreateWeapon()
        {
            Scimitar sword = new Scimitar();
            sword.Name = "Scimitar of the Canaanite Hero";
            sword.Hue = 2208;
            sword.MinDamage = 32;
            sword.MaxDamage = 68;
            sword.Attributes.BonusStam = 10;
            sword.Attributes.SpellChanneling = 1;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.DefendChance = 10;
            sword.WeaponAttributes.HitLightning = 25;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            sword.WeaponAttributes.SelfRepair = 5;
            sword.WeaponAttributes.UseBestSkill = 1;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Eternal Wall";
            armor.Hue = 2223;
            armor.BaseArmorRating = 65;
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.BonusStr = 12;
            armor.Attributes.BonusHits = 25;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Weaver’s Striped Trousers";
            pants.Hue = 2116;
            pants.Attributes.Luck = 22;
            pants.Attributes.BonusMana = 7;
            pants.SkillBonuses.SetValues(0, SkillName.Tailoring, 15.0);
            pants.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Pilgrim’s Robe of Bethlehem";
            robe.Hue = 1175;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.NightSight = 1;
            robe.Attributes.LowerRegCost = 12;
            robe.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Focus, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Jambiya of the Freedom Fighter";
            dagger.Hue = 2209;
            dagger.MinDamage = 22;
            dagger.MaxDamage = 54;
            dagger.Attributes.BonusDex = 12;
            dagger.Attributes.ReflectPhysical = 8;
            dagger.WeaponAttributes.HitFireball = 10;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfPalestine(Serial serial) : base(serial)
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

    // Decorative artifact: Olive branch symbol of peace and resistance
    public class OliveBranchRelic : ArtifactLargeVase
    {
        [Constructable]
        public OliveBranchRelic()
        {
            Name = "Relic: Olive Branch of Peace";
            Hue = 1425;
        }

        public OliveBranchRelic(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    // Custom lore book: "Chronicles of the Olive Land"
    public class ChroniclesOfTheOliveLand : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Olive Land", "A Voice of Palestine",
            new BookPageInfo
            (
                "From the time of Canaan",
                "and the walls of Jericho,",
                "this land has known",
                "both harvest and war.",
                "Its olive trees root deep",
                "in memory and sorrow,",
                "leaves glinting silver,",
                "bearing hope eternal."
            ),
            new BookPageInfo
            (
                "Through Roman stone and",
                "Byzantine hymn, across",
                "Umayyad courts, Crusader",
                "shadows, and Ottoman call,",
                "the land endures: its",
                "cities ancient—Jerusalem,",
                "Hebron, Gaza—echoing the",
                "footsteps of prophets."
            ),
            new BookPageInfo
            (
                "Empires pass. Walls fall.",
                "Yet in the alleys of",
                "Bethlehem, the bells ring,",
                "and children play. Every",
                "stone is a story; every",
                "song a prayer; every meal",
                "shared a promise of return."
            ),
            new BookPageInfo
            (
                "Remember the olive harvest,",
                "the bread baked at dawn,",
                "the call to prayer, the",
                "sound of oud and drum.",
                "In sorrow and in laughter,",
                "the land remembers.",
                "Even when torn by struggle,",
                "the people rise anew."
            ),
            new BookPageInfo
            (
                "This chest carries relics",
                "of memory—mosaic, oil,",
                "jambiya, robe—each a token",
                "of resilience and love.",
                "Guard them, traveler. Let",
                "no conqueror erase the",
                "roots of the olive land.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "To hold this book is to",
                "hold history: bitter and",
                "sweet, written in stone,",
                "song, and steadfast will.",
                "",
                "- May Palestine Endure",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheOliveLand() : base(false)
        {
            Hue = 1425; // Olive green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Olive Land");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Olive Land");
        }

        public ChroniclesOfTheOliveLand(Serial serial) : base(serial) { }

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
