using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfEstonianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfEstonianLegends()
        {
            Name = "Treasure Chest of Estonian Legends";
            Hue = 1160; // Blueish tone for the Baltic Sea

            // Add items to the chest
            AddItem(CreateSongFestivalBanner(), 0.18);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Kalev's Ancient Urn"), 0.10);
            AddItem(CreateColoredItem<RandomFancyCoin>("Old Livonian Coin", 2209), 0.16);
            AddItem(CreateNamedItem<RandomFancyCrystal>("The Baltic Amber"), 0.14);
            AddItem(CreateColoredItem<WolfStatue>("The Wolf of Lembitu", 1109), 0.12);
            AddItem(CreateEstonianLoreBook(), 1.0);
            AddItem(new Gold(Utility.Random(1500, 5000)), 0.22);
            AddItem(CreateNamedItem<BreadLoaf>("Traditional Black Rye Bread"), 0.15);
            AddItem(CreateColoredItem<BlueBeaker>("Vana Tallinn Liqueur", 1154), 0.09);
            AddItem(CreateMapToTallinn(), 0.08);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateAmuletOfFreedom(), 0.17);
            AddItem(CreateForestElixir(), 0.19);
            AddItem(CreateNamedItem<CrystalBallStatuette>("Seer's Crystal of Taarapita"), 0.11);
            AddItem(CreateNamedItem<RandomTrophy>("Singing Revolution Commemorative Trophy"), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateSongFestivalBanner()
        {
            // Decorative: Banner for Estonian Song Festival
            OrderBanner banner = new OrderBanner();
            banner.Name = "Laulupidu Banner";
            banner.Hue = 1165; // National blue
            return banner;
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

        private Item CreateEstonianLoreBook()
        {
            return new ChronicleOfEstonia();
        }

        private Item CreateMapToTallinn()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Toompea Castle, Tallinn";
            map.Bounds = new Rectangle2D(1400, 900, 200, 200);
            map.NewPin = new Point2D(1475, 995); // Example coords
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Legendary weapon inspired by Estonian mythology
            Longsword sword = new Longsword();
            sword.Name = "Sword of Kalevipoeg";
            sword.Hue = 1164; // Light blue, mythical
            sword.MaxDamage = Utility.Random(40, 65);
            sword.MinDamage = Utility.Random(25, 39);
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitLeechHits = 15;
            sword.WeaponAttributes.HitMagicArrow = 15;
            sword.WeaponAttributes.UseBestSkill = 1;
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 30;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.AttackChance = 10;
            sword.Slayer = SlayerName.ElementalBan;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // Legendary armor inspired by the forests of Estonia
            LeafChest chest = new LeafChest();
            chest.Name = "Forest Guardian's Leaf Chest";
            chest.Hue = 1266; // Deep green
            chest.BaseArmorRating = Utility.Random(40, 60);
            chest.Attributes.BonusHits = 25;
            chest.Attributes.RegenHits = 5;
            chest.Attributes.Luck = 50;
            chest.Attributes.BonusDex = 5;
            chest.ColdBonus = 15;
            chest.PhysicalBonus = 10;
            chest.FireBonus = 8;
            chest.PoisonBonus = 12;
            chest.EnergyBonus = 10;
            chest.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // Folk costume: White and blue robe with bonuses to music skills
            Robe robe = new Robe();
            robe.Name = "Singer’s National Robe";
            robe.Hue = 1153; // White-blue
            robe.Attributes.BonusMana = 10;
            robe.Attributes.LowerManaCost = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateAmuletOfFreedom()
        {
            // Jewelry: The freedom amulet symbolizes independence
            GoldBracelet amulet = new GoldBracelet();
            amulet.Name = "Amulet of Freedom";
            amulet.Hue = 1170;
            amulet.Attributes.DefendChance = 12;
            amulet.Attributes.RegenStam = 3;
            amulet.Attributes.BonusInt = 8;
            amulet.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            return amulet;
        }

        private Item CreateForestElixir()
        {
            // Consumable: Forest Elixir (heals, cures, and grants stamina)
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Sacred Elixir of Lahemaa Forest";
            potion.Hue = 1270; // Green
            return potion;
        }

        public TreasureChestOfEstonianLegends(Serial serial) : base(serial)
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

    public class ChronicleOfEstonia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Chronicle of Estonia", "Compiled by Lennart the Wise",
            new BookPageInfo
            (
                "Land between forests and sea,",
                "where ancient spirits wander,",
                "Estonia was shaped by time.",
                "Tribes of Aesti fished these",
                "coasts and farmed these fields,",
                "long before swords of iron came.",
                "They sang to the pines and the sky.",
                ""
            ),
            new BookPageInfo
            (
                "When northern winds brought",
                "crusaders, fire met stone.",
                "The Livonian Knights carved",
                "castles of limestone, and the",
                "old gods hid in the misty bogs.",
                "Freedom, stolen, was never",
                "forgotten; hope kindled in song.",
                ""
            ),
            new BookPageInfo
            (
                "Years passed beneath foreign",
                "flags: Danish, Swedish, Russian.",
                "But always, Estonians kept",
                "the rhythm of their land. In",
                "dark woods, stories flourished—",
                "Kalevipoeg’s deeds, tales of",
                "Lembitu, and the wisdom of forests."
            ),
            new BookPageInfo
            (
                "When the world forgot their",
                "name, Estonians gathered by",
                "the thousands. With voices",
                "joined, they raised the Song",
                "Festival’s hymn—a revolution",
                "of harmony. Empires trembled.",
                ""
            ),
            new BookPageInfo
            (
                "In 1991, the chains of empire",
                "broke at last. The blue, black,",
                "and white banner waved again.",
                "Estonia became a star among",
                "free nations, and the ancient",
                "spirit sang through the forests",
                "and the stones once more.",
                ""
            ),
            new BookPageInfo
            (
                "This chest holds relics of",
                "Estonia’s journey: swords of",
                "myth, banners of song, and",
                "echoes of forest magic. May",
                "you honor their story, and",
                "remember the power of song,",
                "freedom, and the silent strength",
                "of an ancient land."
            ),
            new BookPageInfo
            (
                "Tere tulemast Eestisse!",
                "",
                "- Lennart the Wise"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfEstonia() : base(false)
        {
            Hue = 1160; // Baltic blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Chronicle of Estonia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Chronicle of Estonia");
        }

        public ChronicleOfEstonia(Serial serial) : base(serial) { }

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
