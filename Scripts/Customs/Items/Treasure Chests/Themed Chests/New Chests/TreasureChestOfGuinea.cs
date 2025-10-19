using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGuinea : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfGuinea()
        {
            Name = "Treasure Chest of the Ancient Lands of Guinea";
            Hue = 2651; // Rich, earthy gold

            // Add decorative items reflecting Guinea's culture and history
            AddItem(CreateColoredArtifact<ArtifactLargeVase>("Ancient Malinke Pottery", 2419), 0.17);
            AddItem(CreateNamedArtifact<IncenseBurner>("Fula Spirit Incense Burner"), 0.13);
            AddItem(CreateNamedArtifact<BambooStoolArtifact>("Storyteller’s Bamboo Stool"), 0.18);
            AddItem(CreateNamedArtifact<GoldBricks>("Nuggets of Bambouk Gold"), 0.22);
            AddItem(CreateColoredArtifact<CraneZooStatuette>("Susu River Crane Idol", 2413), 0.13);
            AddItem(CreateNamedArtifact<Painting3Artifact>("Portrait of Samory Touré"), 0.11);
            AddItem(CreateColoredArtifact<FancyCopperSunflower>("Sun of the Highlands", 2418), 0.09);
            AddItem(CreateNamedArtifact<AncientRunes>("Runestone of the Blacksmiths’ Guild"), 0.12);
            AddItem(new BookOfGuineanLegends(), 1.0); // Always add the lore book

            // Add unique consumables (Guinean cuisine-inspired!)
            AddItem(CreateNamedFood<Quiche>("Jollof Rice Bowl"), 0.18);
            AddItem(CreateNamedFood<CoffeeMug>("Fouta Djallon Coffee"), 0.16);
            AddItem(CreateNamedFood<GreenTea>("Forest Herb Tea"), 0.13);
            AddItem(CreateNamedFood<Cake>("Celebration Cassava Cake"), 0.08);
            AddItem(CreateNamedFood<Bananas>("Bananas of Kindia"), 0.18);

            // Add unique gold coins
            AddItem(CreateGuineaGold(), 0.16);

            // Add powerful equipment themed to Guinea's history
            AddItem(CreateEpicSword(), 0.19);
            AddItem(CreateEpicShield(), 0.15);
            AddItem(CreateEpicArmor(), 0.17);
            AddItem(CreateEpicRobe(), 0.15);
            AddItem(CreateEpicHat(), 0.13);

            // Miscellaneous rare treasure
            AddItem(CreateColoredArtifact<TreasureLevel2>("Tomb Relic of the Mandingue", 2417), 0.06);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedArtifact<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedFood<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateGuineaGold()
        {
            Gold gold = new Gold(Utility.RandomMinMax(3500, 7000));
            gold.Name = "Ancient Guinea Gold Coins";
            gold.Hue = 2419; // Deep yellow-gold
            return gold;
        }

        // --- Epic Equipment ---
        private Item CreateEpicSword()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Sword of the Malinke King";
            sword.Hue = 1160;
            sword.WeaponAttributes.HitLightning = 30;
            sword.WeaponAttributes.HitHarm = 20;
            sword.WeaponAttributes.HitLowerAttack = 25;
            sword.Attributes.BonusStr = 8;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.BonusHits = 25;
            sword.Slayer = SlayerName.ReptilianDeath;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateEpicShield()
        {
            PlateGloves shield = new PlateGloves();
            shield.Name = "Fula Warrior’s Shield";
            shield.Hue = 1173;
            shield.ArmorAttributes.SelfRepair = 6;
            shield.ArmorAttributes.MageArmor = 1;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.ReflectPhysical = 20;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateEpicArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Djallon";
            chest.Hue = 1175;
            chest.BaseArmorRating = 62;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.LowerManaCost = 8;
            chest.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateEpicRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Griot";
            robe.Hue = 2101; // Rich, dark red
            robe.Attributes.BonusInt = 10;
            robe.Attributes.Luck = 60;
            robe.Attributes.RegenMana = 4;
            robe.SkillBonuses.SetValues(0, SkillName.Musicianship, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 15.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateEpicHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Headdress of the Susu Chieftain";
            hat.Hue = 2517; // Vibrant color
            hat.Attributes.BonusDex = 7;
            hat.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            hat.Attributes.NightSight = 1;
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        // Serialization
        public TreasureChestOfGuinea(Serial serial) : base(serial) { }
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

    // --- Custom Lore Book: BookOfGuineanLegends ---
    public class BookOfGuineanLegends : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of Guinea", "Elder Sory of the Highlands",
            new BookPageInfo
            (
                "Long before iron met fire,",
                "these lands were home to",
                "the Mandingue, Fula, Susu,",
                "and many more. Their cities,",
                "like Niani and Timbuktu,",
                "shone bright with gold and",
                "knowledge, and their rivers",
                "teemed with life and story."
            ),
            new BookPageInfo
            (
                "The ancient empires rose:",
                "Ghana, Mali, Songhai.",
                "Kings ruled with wisdom,",
                "traders crossed the Sahara,",
                "and griots sang the tales",
                "of heroes and spirits to",
                "every new generation."
            ),
            new BookPageInfo
            (
                "Then strangers arrived by",
                "sea. The lands changed.",
                "Peoples resisted and endured.",
                "Samory Touré led the Mandinka",
                "against the invaders. In the",
                "highlands, elders kept alive",
                "the fires of freedom."
            ),
            new BookPageInfo
            (
                "Guinea became the first of",
                "her people to claim liberty",
                "in 1958. Sekou Touré’s call",
                "echoed from Fouta Djallon",
                "to the Atlantic, and the",
                "djembe drums of freedom",
                "sounded out once more."
            ),
            new BookPageInfo
            (
                "This chest is filled with",
                "treasures of the ancestors:",
                "the gold of Bambouk, the",
                "wisdom of the griots, and",
                "the courage of countless",
                "generations. Take them with",
                "respect, for you now share",
                "the legacy of Guinea."
            ),
            new BookPageInfo
            (
                "Let the rivers guide you.",
                "Let the drums teach you.",
                "May your path be blessed",
                "by the spirits of this",
                "land. For history lives",
                "not in dust, but in those",
                "who remember and carry it",
                "forward."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfGuineanLegends() : base(false)
        {
            Hue = 1160; // Deep gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of Guinea");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of Guinea");
        }

        public BookOfGuineanLegends(Serial serial) : base(serial) { }
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
