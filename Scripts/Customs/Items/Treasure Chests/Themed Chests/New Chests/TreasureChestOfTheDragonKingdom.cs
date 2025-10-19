using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheDragonKingdom : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheDragonKingdom()
        {
            Name = "Treasure Chest of the Dragon Kingdom";
            Hue = 2951; // Deep dragon green, feel free to change!

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactVase>("Dragon Vase of Paro", 2001), 0.18);
            AddItem(CreateDecorativeItem<IncenseBurner>("Butter Lamp of Blessings", 2700), 0.14);
            AddItem(CreateDecorativeItem<KingsPainting1>("Thangka of the Thunder Dragon", 2941), 0.11);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Brocade Meditation Seat", 2021), 0.13);
            AddItem(CreateDecorativeItem<ZenRock1Artifact>("Rock of Himalayan Serenity", 2013), 0.10);
            AddItem(CreateDecorativeItem<OrigamiDragon>("Prayer Dragon Origami", 2852), 0.14);

            AddItem(CreateUniqueConsumable("Ara, Spirit of the Himalayas", 1224), 0.17);
            AddItem(CreateUniqueConsumable("Ema Datshi, Fiery Cheese Stew", 1268), 0.15);
            AddItem(CreateUniqueConsumable("Butter Tea of the Monks", 1152), 0.18);

            AddItem(CreateEquipment(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateMysticRobe(), 0.17);

            AddItem(CreateDecorativeItem<GoldBracelet>("Thunder Dragon Gold Bracelet", 2122), 0.17);
            AddItem(CreateDecorativeItem<SilverSteedZooStatuette>("Guardian Takin Figurine", 2107), 0.13);
            AddItem(CreateDecorativeItem<SmallEmptyPot>("Bhutanese Offering Bowl", 2003), 0.18);

            AddItem(CreateGoldItem("Bhutanese Ngultrum Coins"), 0.19);

            AddItem(CreateLoreBook(), 1.0);

            AddItem(CreateMap(), 0.06);
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

        private Item CreateUniqueConsumable(string name, int hue)
        {
            GreaterHealPotion item = new GreaterHealPotion();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(1500, 6000);
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Tiger's Nest Monastery";
            map.Bounds = new Rectangle2D(3200, 3700, 150, 150);
            map.NewPin = new Point2D(3287, 3745);
            map.Protected = true;
            return map;
        }

        // Powerful Equipment
        private Item CreateEquipment()
        {
            Katana weapon = new Katana();
            weapon.Name = "Drukpa's Thunderblade";
            weapon.Hue = 2981; // Electric blue
            weapon.MinDamage = Utility.Random(30, 60);
            weapon.MaxDamage = Utility.Random(60, 100);
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.BonusMana = 10;
            weapon.Attributes.BonusHits = 20;
            weapon.WeaponAttributes.HitLightning = 40;
            weapon.Attributes.CastSpeed = 1;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Fencing, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            DragonChest armor = new DragonChest();
            armor.Name = "Thunder Dragon Scale Chest";
            armor.Hue = 2955; // Deep jade green
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.BonusStam = 20;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.RegenStam = 5;
            armor.Attributes.DefendChance = 10;
            armor.ColdBonus = 20;
            armor.FireBonus = 15;
            armor.EnergyBonus = 20;
            armor.PoisonBonus = 10;
            armor.PhysicalBonus = 10;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateMysticRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Monk’s Robe of Enlightenment";
            robe.Hue = 1289; // Saffron orange
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusInt = 12;
            robe.Attributes.RegenMana = 5;
            robe.Attributes.SpellDamage = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 15.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Lore Book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheThunderDragon();
        }

        public TreasureChestOfTheDragonKingdom(Serial serial) : base(serial)
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

    public class ChroniclesOfTheThunderDragon : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Thunder Dragon", "The Keeper of Legends",
            new BookPageInfo
            (
                "Nestled in the high Himalayas,",
                "the Kingdom of Bhutan—Druk Yul,",
                "Land of the Thunder Dragon—rose",
                "hidden from the world, its",
                "mystic valleys shrouded in mist,",
                "its people bound by tradition,",
                "compassion, and the call of",
                "ancient mountains."
            ),
            new BookPageInfo
            (
                "From the dawn of the dragon,",
                "wise sages and wandering monks",
                "tamed wild spirits, weaving faith",
                "into every stone and stream.",
                "Fortresses—dzongs—stood watch,",
                "guarding peace, as dragon kings",
                "dreamed of unity."
            ),
            new BookPageInfo
            (
                "The 17th century saw Zhabdrung",
                "Ngawang Namgyal, the unifier,",
                "carve the nation’s soul. He",
                "forged a state of wisdom and",
                "sword, blending the sacred and",
                "the sovereign. Thunder echoed",
                "across the valleys—Bhutan was born."
            ),
            new BookPageInfo
            (
                "For centuries, the dragon kings",
                "walked the Middle Path—balancing",
                "isolation and diplomacy, tradition",
                "and change. The world’s storms",
                "beat against the mountains, but",
                "the spirit of Bhutan endured,",
                "hidden in joy and prayer."
            ),
            new BookPageInfo
            (
                "In the 20th century, new winds",
                "brought roads, schools, the seeds",
                "of democracy. The kings guided",
                "their people from darkness to light,",
                "measuring progress not in gold,",
                "but in Gross National Happiness."
            ),
            new BookPageInfo
            (
                "The Thunder Dragon yet guards",
                "these emerald peaks. Its children",
                "honor the old ways, their songs",
                "rising with prayer flags, their",
                "dreams soaring like the black-",
                "necked crane.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Let this chest be your window,",
                "wanderer—see the wisdom of the",
                "Dragon Kingdom. May its blessings",
                "follow you, as the thunder rolls,",
                "and the dragon soars eternally.",
                "",
                "- The Keeper of Legends",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheThunderDragon() : base(false)
        {
            Hue = 2951; // Match chest hue, dragon green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Thunder Dragon");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Thunder Dragon");
        }

        public ChroniclesOfTheThunderDragon(Serial serial) : base(serial) { }

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
