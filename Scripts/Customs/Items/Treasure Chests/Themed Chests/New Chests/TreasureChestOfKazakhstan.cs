using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfKazakhstan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfKazakhstan()
        {
            Name = "Treasure Chest of the Eternal Steppe";
            Hue = 1367; // Golden Steppe

            // Add unique themed items to the chest
            AddItem(new ChroniclesOfTheEternalSteppe(), 1.0);
            AddItem(CreateGoldenManStatuette(), 0.13);
            AddItem(CreateColoredItem<Gold>("Turkic Sunstone", 2212), 0.14);
            AddItem(CreateColoredItem<Diamond>("Jade of the Silk Road", 1422), 0.14);
            AddItem(CreateKazakhKumis(), 0.20);
            AddItem(CreateKazakhBaursak(), 0.21);
            AddItem(CreatePotionOfSteppeWinds(), 0.11);
            AddItem(CreateSteppeYurt(), 0.11);
            AddItem(CreateSakaWarriorsHelm(), 0.17);
            AddItem(CreateSteppeNomadsBow(), 0.18);
            AddItem(CreateRobesOfTheTengriShaman(), 0.16);
            AddItem(CreateSilkRoadBoots(), 0.16);
            AddItem(CreateKazakhShield(), 0.18);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.25);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldenManStatuette()
        {
            // Use a decorative artifact as base
            var goldenMan = new ManStatuetteSouthArtifact();
            goldenMan.Name = "Golden Man of Issyk";
            goldenMan.Hue = 2212; // Gold
            return goldenMan;
        }

        private Item CreateSteppeYurt()
        {
            var yurt = new Bedroll();
            yurt.Name = "Miniature Steppe Yurt";
            yurt.Hue = 2414; // Sandy/cloth
            return yurt;
        }

        private Item CreateKazakhKumis()
        {
            var kumis = new RandomDrink();
            kumis.Name = "Bottle of Kumis";
            kumis.Hue = 1152; // Milky white
            return kumis;
        }

        private Item CreateKazakhBaursak()
        {
            var baursak = new Muffins();
            baursak.Name = "Baursak - Bread of the Nomad";
            baursak.Hue = 2413; // Warm bread color
            return baursak;
        }

        private Item CreatePotionOfSteppeWinds()
        {
            var potion = new GreaterAgilityPotion();
            potion.Name = "Potion of Steppe Winds";
            potion.Hue = 1289; // Azure-blue
            return potion;
        }

        private Item CreateSakaWarriorsHelm()
        {
            var helm = new Bascinet();
            helm.Name = "Saka Warrior's Helm";
            helm.Hue = 1153; // Gold
            helm.BaseArmorRating = 50;
            helm.Attributes.BonusStr = 15;
            helm.Attributes.RegenHits = 6;
            helm.Attributes.LowerManaCost = 7;
            helm.SkillBonuses.SetValues(0, SkillName.Anatomy, 15.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateSteppeNomadsBow()
        {
            var bow = new CompositeBow();
            bow.Name = "Bow of the Steppe Nomad";
            bow.Hue = 1279; // Steppe brown
            bow.MinDamage = 18;
            bow.MaxDamage = 38;
            bow.Attributes.BonusDex = 12;
            bow.Attributes.AttackChance = 15;
            bow.Attributes.WeaponSpeed = 25;
            bow.WeaponAttributes.HitHarm = 12;
            bow.WeaponAttributes.HitFireball = 10;
            bow.Slayer = SlayerName.Repond;
            bow.SkillBonuses.SetValues(0, SkillName.Archery, 20.0);
            XmlAttach.AttachTo(bow, new XmlLevelItem());
            return bow;
        }

        private Item CreateRobesOfTheTengriShaman()
        {
            var robe = new Robe();
            robe.Name = "Robes of the Tengri Shaman";
            robe.Hue = 1161; // Sky blue
            robe.Attributes.Luck = 55;
            robe.Attributes.RegenMana = 7;
            robe.Attributes.SpellDamage = 18;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSilkRoadBoots()
        {
            var boots = new Boots();
            boots.Name = "Boots of the Silk Road";
            boots.Hue = 2208;
            boots.Attributes.BonusDex = 8;
            boots.Attributes.RegenStam = 6;
            boots.Attributes.LowerRegCost = 10;
            boots.SkillBonuses.SetValues(0, SkillName.Begging, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateKazakhShield()
        {
            var shield = new BronzeShield();
            shield.Name = "Kazakh Tribal Shield";
            shield.Hue = 1193; // Bronze
            shield.Attributes.DefendChance = 15;
            shield.Attributes.ReflectPhysical = 10;
            shield.Attributes.SpellChanneling = 1;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        public TreasureChestOfKazakhstan(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheEternalSteppe : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Eternal Steppe", "A Nomad's Scribe",
            new BookPageInfo
            (
                "Under the endless blue sky,",
                "the clans of Saka and Turk",
                "roamed the Golden Steppe.",
                "Wind and horse were their",
                "companions. The earth their",
                "bed, the stars their shield."
            ),
            new BookPageInfo
            (
                "We tell tales of the Golden",
                "Man of Issyk, clad in shining",
                "armor, sleeping beneath the",
                "mounds. His spirit guards",
                "the land from shadow, and",
                "his legend rides the wind."
            ),
            new BookPageInfo
            (
                "Along the Silk Road, cities",
                "rose and fell. Merchants from",
                "Samarkand and China bartered",
                "for jade, silk, and stories.",
                "Every yurt a palace; every",
                "guest an honored friend."
            ),
            new BookPageInfo
            (
                "Then thunder came from the",
                "east, as Genghis' hordes swept",
                "through, uniting the land beneath",
                "a single banner. Nomads became",
                "kings, and kings remembered",
                "their roots upon the steppe."
            ),
            new BookPageInfo
            (
                "In the age of iron horses,",
                "the land was carved by new",
                "masters. Yet the soul of the",
                "steppe endures. Our songs",
                "echo in the wind. Our",
                "freedom lives in the grass."
            ),
            new BookPageInfo
            (
                "If you read these words,",
                "stranger, raise a cup of",
                "kumis and remember: the steppe",
                "belongs to no one, yet gives",
                "itself to all with an open",
                "heart.",
                "",
                "- Batyr of the Great Horde"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheEternalSteppe() : base(false)
        {
            Hue = 1283; // Deep blue of the sky
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Eternal Steppe");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Eternal Steppe");
        }

        public ChroniclesOfTheEternalSteppe(Serial serial) : base(serial) { }

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
