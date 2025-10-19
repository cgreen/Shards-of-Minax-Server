using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfKiribati : WoodenChest
    {
        [Constructable]
        public TreasureChestOfKiribati()
        {
            Name = "Treasure Chest of Ancient Kiribati";
            Hue = 88; // Ocean blue

            AddItem(CreatePearlRelic(), 0.25);
            AddItem(CreateDecorativeArtifact("Navigator's Star Map", typeof(MapOfTheKnownWorld), 1153), 0.18);
            AddItem(CreateDecorativeArtifact("Carved Kiritimati Shell", typeof(DecorativeVines), 2412), 0.22);
            AddItem(CreateDecorativeArtifact("Sun-Bleached Driftwood Idol", typeof(Sculpture1Artifact), 2201), 0.20);
            AddItem(CreateDecorativeArtifact("King's Shark-Tooth Necklace", typeof(BearMask), 2407), 0.15);
            AddItem(CreateDecorativeArtifact("Triton's Sea Goblet", typeof(Goblet), 1357), 0.20);
            AddItem(CreateConsumable("Kava Brew", typeof(RandomDrink), 1167), 0.18);
            AddItem(CreateConsumable("Sweet Pandanus Fruit", typeof(Banana), 1807), 0.14);
            AddItem(CreateConsumable("Elixir of the Trade Winds", typeof(GreenTea), 1266), 0.10);
            AddItem(CreateGoldItem("Pearl-Kiribati Coin"), 0.15);

            AddItem(CreateUniqueEquipment(), 0.35);
            AddItem(CreateSeaArmor(), 0.28);
            AddItem(CreateOceanicClothing(), 0.24);
            AddItem(CreateAncientWeapon(), 0.21);

            AddItem(new ChroniclesOfKiribati(), 1.0);
            AddItem(new Gold(Utility.Random(1000, 4500)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreatePearlRelic()
        {
            Ruby pearl = new Ruby();
            pearl.Name = "Giant Pearl of Tabiteuea";
            pearl.Hue = 1153; // Iridescent white
            return pearl;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateDecorativeArtifact(string name, Type type, int hue)
        {
            Item artifact = (Item)Activator.CreateInstance(type);
            artifact.Name = name;
            artifact.Hue = hue;
            return artifact;
        }

        private Item CreateConsumable(string name, Type type, int hue)
        {
            Item consumable = (Item)Activator.CreateInstance(type);
            consumable.Name = name;
            consumable.Hue = hue;
            return consumable;
        }

        private Item CreateUniqueEquipment()
        {
            // Legendary trident, with epic water-related bonuses
            ShortSpear trident = new ShortSpear();
            trident.Name = "Trident of the Lost Navigators";
            trident.Hue = 1175;
            trident.MinDamage = 30;
            trident.MaxDamage = 70;
            trident.Attributes.BonusDex = 15;
            trident.Attributes.BonusHits = 25;
            trident.Attributes.AttackChance = 12;
            trident.Attributes.WeaponDamage = 30;
            trident.WeaponAttributes.HitLeechStam = 20;
            trident.WeaponAttributes.HitLightning = 15;
            trident.SkillBonuses.SetValues(0, SkillName.Fishing, 18.0);
            trident.SkillBonuses.SetValues(1, SkillName.Cartography, 10.0);
            XmlAttach.AttachTo(trident, new XmlLevelItem());
            return trident;
        }

        private Item CreateSeaArmor()
        {
            // Breastplate made from "Giant Clamshell"
            PlateChest armor = new PlateChest();
            armor.Name = "Clamshell Breastplate of Abemama";
            armor.Hue = 2412;
            armor.BaseArmorRating = 50;
            armor.Attributes.BonusHits = 20;
            armor.ArmorAttributes.SelfRepair = 3;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.RegenHits = 4;
            armor.Attributes.LowerRegCost = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateOceanicClothing()
        {
            // Robe dyed in ocean hues, grants movement bonuses
            Robe robe = new Robe();
            robe.Name = "Wave-Touched Robe of Tarawa";
            robe.Hue = 1358;
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusMana = 12;
            robe.Attributes.NightSight = 1;
            robe.Attributes.BonusDex = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateAncientWeapon()
        {
            // Shark-tooth club: "Tabwabwa's Jaw"
            Club club = new Club();
            club.Name = "Tabwabwa's Shark-Tooth Club";
            club.Hue = 2418;
            club.MinDamage = 25;
            club.MaxDamage = 55;
            club.WeaponAttributes.HitPoisonArea = 10;
            club.WeaponAttributes.SelfRepair = 4;
            club.Attributes.WeaponSpeed = 12;
            club.Attributes.BonusStr = 12;
            club.Slayer = SlayerName.ReptilianDeath;
            club.SkillBonuses.SetValues(0, SkillName.Tactics, 14.0);
            club.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(club, new XmlLevelItem());
            return club;
        }

        public TreasureChestOfKiribati(Serial serial) : base(serial) { }

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

    public class ChroniclesOfKiribati : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Vanishing Isles", "Tione, Keeper of the Sea-Lore",
            new BookPageInfo
            (
                "In the endless blue,",
                "scattered pearls of land",
                "emerged from the sea's",
                "embrace. These are the",
                "islands of Kiribati—",
                "born of coral, shaped",
                "by tide and wind,",
                "watched by the stars."
            ),
            new BookPageInfo
            (
                "Our ancestors sailed",
                "by starlight, weaving",
                "songs of navigation.",
                "They spoke to the wind,",
                "read the ocean's bones,",
                "and found their way",
                "where others would",
                "be lost forever."
            ),
            new BookPageInfo
            (
                "Kings rose and fell",
                "with the tide. Brave",
                "fishermen wrestled the",
                "sea's bounty. Warriors",
                "wore shark-tooth clubs.",
                "Priests cast magic with",
                "shell and sand.",
                ""
            ),
            new BookPageInfo
            (
                "But the sea takes as",
                "much as it gives.",
                "Islands fade. Storms",
                "swallow all. Our lore",
                "remains, etched in bone",
                "and pearl, waiting for",
                "the next wave."
            ),
            new BookPageInfo
            (
                "So journeyer, who",
                "finds this chest—",
                "remember: treasures",
                "are not gold, but",
                "stories. Guard the",
                "memory of Kiribati.",
                "",
                "- Tione"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfKiribati() : base(false)
        {
            Hue = 88; // Ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Vanishing Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Vanishing Isles");
        }

        public ChroniclesOfKiribati(Serial serial) : base(serial) { }

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
