using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfChad : WoodenChest
    {
        [Constructable]
        public TreasureChestOfChad()
        {
            Name = "Treasure Chest of Chad";
            Hue = 2651; // Desert gold

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Kanem-Bornu Gold Idol", 2413), 0.18);
            AddItem(CreateDecorativeItem<BakeKitsuneStatue>("Desert Fox Idol", 2012), 0.15);
            AddItem(CreateDecorativeItem<WolfStatue>("Lion of the Sahel", 2224), 0.10);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Mystic Orb of Lake Chad", 88), 0.12);
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Fisherman's Relic", 2408), 0.08);
            AddItem(CreateDecorativeItem<AcademicBooksArtifact>("History of Chad - Ancient Scripts", 1150), 0.20);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Griot's Story Sculpture", 1153), 0.13);

            AddItem(CreateConsumableItem<GreenTea>("Water of the Great Lake", 1170), 0.25);
            AddItem(CreateConsumableItem<HotCocoaMug>("Griot’s Story Wine", 1366), 0.20);
            AddItem(CreateConsumableItem<BentoBox>("Nomad’s Desert Survival Kit", 2710), 0.20);

            AddItem(CreateEquipment(), 0.30);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);

            AddItem(CreateNamedClothing(), 0.20);
            AddItem(CreateBook(), 1.0);

            AddItem(new Gold(Utility.Random(2500, 3500)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedClothing()
        {
            // Example: A richly adorned robe reflecting Sahelian royalty
            Robe robe = new Robe();
            robe.Name = "Robe of the Kanem Kings";
            robe.Hue = 2117; // Rich blue
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusHits = 15;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            robe.Resistances.Fire = 5;
            robe.Resistances.Cold = 5;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateEquipment()
        {
            // Example: Unique boots for desert travel
            Boots boots = new Boots();
            boots.Name = "Sahel Nomad's Sandals";
            boots.Hue = 1165; // Sandy color
            boots.Attributes.BonusDex = 10;
            boots.Attributes.RegenStam = 4;
            boots.Attributes.LowerManaCost = 8;
            boots.Attributes.NightSight = 1;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Tracking, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateWeapon()
        {
            // Unique scimitar reflecting ancient Saharan blades
            Scimitar sword = new Scimitar();
            sword.Name = "Sword of Sao Warrior";
            sword.Hue = 2407; // Metallic bronze
            sword.WeaponAttributes.HitLightning = 20;
            sword.WeaponAttributes.HitFireball = 10;
            sword.WeaponAttributes.HitLeechHits = 8;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.Attributes.AttackChance = 8;
            sword.Attributes.BonusStr = 7;
            sword.Attributes.SpellChanneling = 1;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.Slayer = SlayerName.Repond;
            sword.MinDamage = 24;
            sword.MaxDamage = 45;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // Unique helm referencing desert warlords
            PlateHelm helm = new PlateHelm();
            helm.Name = "Helm of the Daza Warlord";
            helm.Hue = 1152; // Gold
            helm.ArmorAttributes.MageArmor = 1;
            helm.Attributes.BonusInt = 10;
            helm.Attributes.LowerRegCost = 10;
            helm.Attributes.BonusMana = 6;
            helm.SkillBonuses.SetValues(0, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateBook()
        {
            return new TomeOfChadianLegends();
        }

        public TreasureChestOfChad(Serial serial) : base(serial) { }

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

    public class TomeOfChadianLegends : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Tome of Chadian Legends", "Griot Issa Mahamat",
            new BookPageInfo
            (
                "In the dawn before the",
                "sands, before kings rose,",
                "there was the great lake:",
                "the Heart of Chad. Around",
                "it, peoples gathered: Sao",
                "builders, Kanem riders,",
                "and the spirits of the",
                "desert winds."
            ),
            new BookPageInfo
            (
                "The Sao, first of Chad,",
                "wrought mighty walls and",
                "cast idols in bronze.",
                "The Kanem-Bornu kings",
                "came riding camels,",
                "trading salt for gold.",
                "Empires rose, fell, and",
                "rose anew with every tide."
            ),
            new BookPageInfo
            (
                "In the shadows of the",
                "Sahara, the Toubou and",
                "the Zaghawa trekked,",
                "tracing the ways of the",
                "stars. Nomads wandered,",
                "storytellers spun tales,",
                "and the desert kept its",
                "ancient secrets safe."
            ),
            new BookPageInfo
            (
                "The French came with",
                "guns and flags, but the",
                "Sahel endures. Its people",
                "are stone and river: proud,",
                "resilient, and bold.",
                "",
                "The Heart of Chad still",
                "beats beneath the sand."
            ),
            new BookPageInfo
            (
                "From empires lost to",
                "colonies born, from",
                "warriors of the past to",
                "dreamers of today, Chad",
                "remains. Seek this chest",
                "and find the echoes of a",
                "land as old as memory,",
                "as vast as the desert sky."
            ),
            new BookPageInfo
            (
                "May its treasures inspire",
                "the courage of the kings,",
                "the wisdom of the griots,",
                "and the endurance of all",
                "who wander the endless",
                "roads of history.",
                "",
                "- Griot Issa Mahamat"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public TomeOfChadianLegends() : base(false)
        {
            Hue = 1154; // Sand/gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Tome of Chadian Legends");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Tome of Chadian Legends");
        }

        public TomeOfChadianLegends(Serial serial) : base(serial) { }

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
