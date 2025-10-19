using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfKuwait : WoodenChest
    {
        [Constructable]
        public TreasureChestOfKuwait()
        {
            Name = "Treasure Chest of the Kuwait Pearl Divers";
            Hue = 2075; // Sand-gold hue

            // Decorative & Thematic Loot
            AddItem(CreatePearl("Lulu al-Kuwait (The Great Kuwaiti Pearl)", 1153), 0.18);
            AddItem(CreateNamedItem<ArtifactLargeVase>("Ancient Dilmun Vase"), 0.15);
            AddItem(CreateNamedItem<BakeKitsuneStatue>("Bedouin Desert Fox Statue"), 0.10);
            AddItem(CreateNamedItem<Ruby>("Desert Sapphire"), 0.12);
            AddItem(CreateColoredItem<Gold>("Gold Dinar Coin", 2207), 0.25);
            AddItem(CreateNamedItem<CrabBushel>("Basket of Gulf Crabs"), 0.10);
            AddItem(CreateNamedItem<FanNorthArtifact>("Gulf Breeze Fan"), 0.08);
            AddItem(CreateNamedItem<LampPost1>("Old Souq Lamp Post"), 0.11);
            AddItem(CreateColoredItem<WaterRelic>("Waters of the Arabian Gulf", 92), 0.10);
            AddItem(CreatePearl("Black Pearl of Failaka", 1109), 0.12);
            AddItem(CreateNamedItem<DecorativeShield5>("Dilmunite Sun Shield"), 0.14);
            AddItem(CreateNamedItem<DecorativeSwordNorth>("Sword of the Kuwaiti Emir"), 0.07);
            AddItem(CreateNamedItem<AncientShipModelOfTheHMSCape>("Model Dhow: Al-Boom"), 0.11);
            AddItem(new ChroniclesOfThePearlKingdom(), 1.0);

            // Consumables
            AddItem(CreateNamedItem<BowlOfBlackrockStew>("Bedouin Lamb Stew"), 0.10);
            AddItem(CreateNamedItem<Dates>("Basket of Dates"), 0.11);
            AddItem(CreateNamedItem<GreenTea>("Mint Tea of the Souq"), 0.09);
            AddItem(CreateNamedItem<BottleArtifact>("Perfume of the Gulf Winds"), 0.08);

            // Special Equipment (Armor/Clothing/Weapons)
            AddItem(CreatePearlDiverRobe(), 0.16);
            AddItem(CreateEmirSash(), 0.13);
            AddItem(CreateMerchantBoots(), 0.18);
            AddItem(CreateDesertHelm(), 0.15);
            AddItem(CreateGulfSaber(), 0.14);
            AddItem(CreateOilBaronShield(), 0.10);

            // Gold
            AddItem(new Gold(Utility.Random(1500, 5000)), 0.30);

            // Bonus: A treasure map to Failaka Island
            AddItem(CreateFailakaMap(), 0.06);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Unique Pearl
        private Item CreatePearl(string name, int hue)
        {
            BlackPearl pearl = new BlackPearl();
            pearl.Name = name;
            pearl.Hue = hue;
            return pearl;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Custom Equipment
        private Item CreatePearlDiverRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Pearl Diver's Robe";
            robe.Hue = 1289; // Oceanic blue
            robe.Attributes.Luck = 60;
            robe.Attributes.BonusDex = 10;
            robe.SkillBonuses.SetValues(0, SkillName.ItemID, 25.0);
            robe.SkillBonuses.SetValues(1, SkillName.Fishing, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateEmirSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Emir's Ceremonial Sash";
            sash.Hue = 1157; // Royal purple
            sash.Attributes.BonusStr = 12;
            sash.Attributes.RegenHits = 4;
            sash.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.Peacemaking, 18.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        private Item CreateMerchantBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Merchant's Sandwalkers";
            boots.Hue = 2419; // Desert tan
            boots.Attributes.Luck = 25;
            boots.Attributes.BonusStam = 8;
            boots.Attributes.NightSight = 1;
            boots.SkillBonuses.SetValues(0, SkillName.ItemID, 14.0);
            boots.SkillBonuses.SetValues(1, SkillName.Begging, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateDesertHelm()
        {
            Bascinet helm = new Bascinet();
            helm.Name = "Helm of the Desert Sentinel";
            helm.Hue = 2213; // Sun-gold
            helm.BaseArmorRating = Utility.Random(30, 60);
            helm.Attributes.BonusInt = 8;
            helm.Attributes.ReflectPhysical = 14;
            helm.ArmorAttributes.LowerStatReq = 20;
            helm.SkillBonuses.SetValues(0, SkillName.Tracking, 12.0);
            helm.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            helm.PhysicalBonus = 16;
            helm.FireBonus = 8;
            helm.ColdBonus = 7;
            helm.PoisonBonus = 7;
            helm.EnergyBonus = 7;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateGulfSaber()
        {
            Scimitar saber = new Scimitar();
            saber.Name = "Gulf Saber of Al-Hasan";
            saber.Hue = 1150; // Silver-blue
            saber.MinDamage = 32;
            saber.MaxDamage = 60;
            saber.Attributes.BonusHits = 25;
            saber.Attributes.WeaponSpeed = 20;
            saber.WeaponAttributes.HitFireball = 20;
            saber.WeaponAttributes.HitDispel = 12;
            saber.WeaponAttributes.SelfRepair = 7;
            saber.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            saber.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(saber, new XmlLevelItem());
            return saber;
        }

        private Item CreateOilBaronShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Oil Baron's Bulwark";
            shield.Hue = 2219; // Black-gold (oil color)
            shield.ArmorAttributes.SelfRepair = 10;
            shield.Attributes.Luck = 50;
            shield.Attributes.BonusMana = 8;
            shield.Attributes.DefendChance = 15;
            shield.SkillBonuses.SetValues(0, SkillName.ItemID, 18.0);
            shield.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Special Map
        private Item CreateFailakaMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Failaka Island Ruins";
            map.Bounds = new Rectangle2D(2000, 1500, 400, 400);
            map.NewPin = new Point2D(2100, 1700);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfKuwait(Serial serial) : base(serial) { }

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

    // Themed Lore Book
    public class ChroniclesOfThePearlKingdom : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Pearl Kingdom", "Sheikh Yusuf al-Sabah",
            new BookPageInfo
            (
                "In the dawn of the desert,",
                "before oil and steel, the",
                "people of Kuwait were",
                "children of the sea and sand.",
                "Pearls, glimmering in the",
                "depths, brought wealth to",
                "our shores, while the dhows",
                "sailed the Gulf in hope."
            ),
            new BookPageInfo
            (
                "Bedouin tribes crossed the",
                "arid plains, building tents",
                "with woven palms, trading",
                "dates, spices, and stories.",
                "Allies and rivals alike,",
                "united when danger came,",
                "as the desert teaches unity.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Dilmun, ancient and distant,",
                "sent its wares and secrets",
                "down the Gulf. Our harbors",
                "grew rich. Then came the",
                "Ottoman shadow, and British",
                "sails—Kuwait, always between",
                "worlds, never conquered,",
                "always surviving."
            ),
            new BookPageInfo
            (
                "In 1938, black gold flowed,",
                "and the world changed. Mud",
                "brick gave way to marble;",
                "pearls faded before oil, but",
                "we remembered our roots. The",
                "songs of the divers echo still,",
                "between skyscrapers and souqs.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "War came, but Kuwait endures.",
                "The land is small, but the",
                "heart is vast. Freedom was",
                "won, lost, and reclaimed, as",
                "the desert winds whisper to",
                "every generation: endure.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "O seeker, you open this chest",
                "with hands not of Kuwait, yet",
                "know this: you touch a kingdom",
                "older than oil, rich as pearls,",
                "and enduring as the endless",
                "sand. May the fortune within",
                "remind you: The greatest wealth",
                "is memory, and survival."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfThePearlKingdom() : base(false)
        {
            Hue = 1153; // Pearl white
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Pearl Kingdom");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Pearl Kingdom");
        }

        public ChroniclesOfThePearlKingdom(Serial serial) : base(serial) { }

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
