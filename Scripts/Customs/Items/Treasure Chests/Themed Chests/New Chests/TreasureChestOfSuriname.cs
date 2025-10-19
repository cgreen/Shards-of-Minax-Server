using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSuriname : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSuriname()
        {
            Name = "Treasure Chest of Suriname";
            Hue = 2101; // Jungle Green

            // Add items to the chest
            AddItem(CreateUniqueDecor<ArtifactVase>("Maroon Clay Pot", 242), 0.17);
            AddItem(CreateUniqueDecor<QuagmireStatue>("Jaguar Guardian Statuette", 2117), 0.12);
            AddItem(CreateUniqueDecor<LargeFishingNet>("Paramaribo Port Net", 1157), 0.13);
            AddItem(CreateUniqueDecor<FanNorthArtifact>("Arawak Feather Fan", 2120), 0.09);
            AddItem(CreateUniqueDecor<Painting1NorthArtifact>("Dutch Colonial Map", 2506), 0.18);
            AddItem(CreateUniqueConsumable<RandomFancyMedicine>("Bush Doctor's Healing Draught", 2071), 0.16);
            AddItem(CreateUniqueConsumable<Bottle>("Saramacca River Rum", 2415), 0.15);
            AddItem(CreateUniqueConsumable<BentoBox>("Javanese Rice Bento", 2053), 0.14);
            AddItem(CreateUniqueConsumable<GreenTea>("Indo-Surinamese Green Tea", 2153), 0.11);
            AddItem(CreateUniqueConsumable<BreadLoaf>("Cassava Bread Loaf", 1153), 0.13);

            // Lore book
            AddItem(new ChroniclesOfSuriname(), 1.0);

            // Unique Equipment
            AddItem(CreateJungleExplorerHat(), 0.18);
            AddItem(CreateMaroonSpiritCloak(), 0.16);
            AddItem(CreateJavaneseSash(), 0.15);
            AddItem(CreateWintiWitchblade(), 0.17);
            AddItem(CreateParamariboPlateArmor(), 0.13);

            // Gold or coins
            AddItem(CreateGoldItem("Surinamese Golden Guilder"), 0.20);

            // Map to secret temple
            AddItem(CreateMap(), 0.06);

            // Misc flavor
            AddItem(CreateUniqueDecor<ObsidianSkull>("Obsidian Skull of the Rainforest", 2405), 0.08);
            AddItem(CreateUniqueConsumable<BowlOfRotwormStew>("Pepperpot Stew", 2113), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateUniqueDecor<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(1000, 3500));
            gold.Name = name;
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Secret Map of the Rainforest Temple";
            map.Bounds = new Rectangle2D(500, 1200, 400, 400); // Example coords
            map.NewPin = new Point2D(650, 1333);
            map.Protected = true;
            return map;
        }

        private Item CreateJungleExplorerHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Jungle Explorer's Pith Helmet";
            hat.Hue = 2107;
            hat.Attributes.Luck = 30;
            hat.Attributes.BonusHits = 8;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            hat.Attributes.NightSight = 1;
            hat.Resistances.Fire = 6;
            hat.Resistances.Poison = 6;
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMaroonSpiritCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Maroon Spirit";
            cloak.Hue = 1175;
            cloak.Attributes.DefendChance = 10;
            cloak.Attributes.BonusStam = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            cloak.Attributes.RegenHits = 2;
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateJavaneseSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Javanese Batik Sash";
            sash.Hue = 2510;
            sash.Attributes.SpellDamage = 10;
            sash.Attributes.BonusMana = 10;
            sash.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 7.5);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateWintiWitchblade()
        {
            Kryss kris = new Kryss();
            kris.Name = "Winti Witchblade";
            kris.Hue = 2055;
            kris.MinDamage = Utility.Random(16, 24);
            kris.MaxDamage = Utility.Random(30, 40);
            kris.Attributes.CastSpeed = 1;
            kris.Attributes.CastRecovery = 2;
            kris.Attributes.SpellChanneling = 1;
            kris.WeaponAttributes.HitPoisonArea = 15;
            kris.WeaponAttributes.HitLeechMana = 10;
            kris.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(kris, new XmlLevelItem());
            return kris;
        }

        private Item CreateParamariboPlateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Paramaribo Colonial Plate";
            armor.Hue = 1153;
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusHits = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            armor.FireBonus = 10;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 8;
            armor.PhysicalBonus = 15;
            armor.ColdBonus = 5;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // You can add more items in this fashion!

        public TreasureChestOfSuriname(Serial serial) : base(serial) { }

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

    // Lore Book
    public class ChroniclesOfSuriname : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Suriname", "Historian Anansi Mingo",
            new BookPageInfo
            (
                "Suriname, cradle of rivers,",
                "jungles, and peoples. The",
                "Arawak and Carib lived here",
                "long before the ships arrived.",
                "Dutch and English came,",
                "fighting for sugar and gold.",
                "Slaves were brought from",
                "Africa—many fled to the",
                "rainforest, becoming Maroons."
            ),
            new BookPageInfo
            (
                "Plantations thrived, cities",
                "grew. Paramaribo, with its",
                "wooden houses and canals,",
                "became a center of trade.",
                "Indigenous, African, Indian,",
                "Javanese, and Chinese peoples",
                "all left their mark.",
                ""
            ),
            new BookPageInfo
            (
                "Slavery ended. The Maroons",
                "were never tamed. New",
                "waves of contract workers",
                "brought their gods, their rice,",
                "and their drums. The jungle",
                "watched it all, silent and deep.",
                ""
            ),
            new BookPageInfo
            (
                "In 1975, Suriname broke its",
                "colonial chains. Now, a",
                "land of many tongues and",
                "creeds, where Winti, Hindoe,",
                "and Islam meet by the river,",
                "and jaguars prowl beneath",
                "emerald leaves.",
                ""
            ),
            new BookPageInfo
            (
                "Let this chest’s treasures",
                "remind you: Suriname’s",
                "history is survival, fusion,",
                "and pride. All are children",
                "of the rivers, and the story",
                "flows on.",
                "",
                "- Anansi Mingo"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfSuriname() : base(false)
        {
            Hue = 2101; // Jungle Green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Suriname");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Suriname");
        }

        public ChroniclesOfSuriname(Serial serial) : base(serial) { }

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
