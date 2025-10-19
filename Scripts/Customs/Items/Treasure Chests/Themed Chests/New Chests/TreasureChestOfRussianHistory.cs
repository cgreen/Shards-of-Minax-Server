using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfRussianHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfRussianHistory()
        {
            Name = "Treasure Chest of Russian History";
            Hue = 2075; // Rich red, hinting at Russia's imperial and soviet history

            // Add items to the chest
            AddItem(new MaxxiaScroll(), 0.05);
            AddItem(CreateFabergeEgg(), 0.14);
            AddItem(CreateColoredItem<BottleArtifact>("Vodka of the Tsars", 1161), 0.16);
            AddItem(CreateColoredItem<GoldBricks>("Tsar’s Gold Ingots", 137), 0.11);
            AddItem(CreateNamedItem<WolfStatue>("Statue of the Winter Wolf"), 0.18);
            AddItem(new TheChronicleOfTheRus(), 1.0);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateNamedItem<PolarBearZooStatuette>("Miniature Polar Bear Totem"), 0.17);
            AddItem(CreateNamedItem<RedPoinsettia>("Imperial Red Poinsettia"), 0.11);
            AddItem(CreateNamedItem<LargeVat>("Barrel of Kvass"), 0.12);
            AddItem(CreateNamedItem<Grapes>("Crimean Vineyard Grapes"), 0.13);
            AddItem(CreateNamedItem<LargeFishingNet>("The Tsar's Net"), 0.12);
            AddItem(CreateGoldItem("Imperial Ruble"), 0.15);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateLongCoat(), 0.20);
            AddItem(CreateFurHat(), 0.18);
            AddItem(CreateDagger(), 0.22);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateFabergeEgg()
        {
            // Uses an existing decorative item as a "Faberge Egg"
            Vase egg = new Vase();
            egg.Name = "Fabergé Egg";
            egg.Hue = 1153; // Brilliant, jeweled blue
            egg.ItemID = 0x9B5; // Decorative
            return egg;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(3000, 8000);
            return gold;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Romanov's Hidden Crypt";
            map.Bounds = new Rectangle2D(650, 2220, 420, 420);
            map.NewPin = new Point2D(810, 2350);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Randomly chooses a fitting weapon
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Broadsword(), new BattleAxe(), new Pike(), new Halberd(), new Katana()
            );
            weapon.Name = "Relic of the Rus";
            weapon.Hue = 1109; // Icy blue steel
            weapon.MaxDamage = Utility.Random(45, 78);
            weapon.Attributes.WeaponDamage = 30;
            weapon.Attributes.BonusHits = 20;
            weapon.WeaponAttributes.HitColdArea = 20;
            weapon.WeaponAttributes.HitFireball = 10;
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateHelm(), new PlateLegs(), new ChainCoif(), new RingmailChest()
            );
            armor.Name = "Cuirass of the Cossack";
            armor.Hue = 1157; // Silver with blue undertones
            armor.BaseArmorRating = Utility.Random(36, 80);
            armor.Attributes.Luck = 20;
            armor.Attributes.BonusDex = 12;
            armor.Attributes.BonusStr = 6;
            armor.Attributes.RegenHits = 3;
            armor.ColdBonus = 15;
            armor.FireBonus = 3;
            armor.PoisonBonus = 3;
            armor.EnergyBonus = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLongCoat()
        {
            // Uses Robe for a "Boyar's Longcoat"
            Robe coat = new Robe();
            coat.Name = "Boyar's Winter Longcoat";
            coat.Hue = 2213; // Royal purple
            coat.Attributes.Luck = 22;
            coat.Attributes.BonusInt = 7;
            coat.Attributes.SpellDamage = 12;
            coat.SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            coat.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(coat, new XmlLevelItem());
            return coat;
        }

        private Item CreateFurHat()
        {
            // "Ushanka" style hat using BearMask for a furry look
            BearMask hat = new BearMask();
            hat.Name = "Ushanka of the Siberian Explorer";
            hat.Hue = 2101; // Furry brown
            hat.Attributes.BonusHits = 15;
            hat.Attributes.BonusStam = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Camping, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateDagger()
        {
            // "Kama" as a Cossack's curved blade
            Kama dagger = new Kama();
            dagger.Name = "Kindjal of the Steppe";
            dagger.Hue = 1154; // Cold steel
            dagger.MinDamage = 22;
            dagger.MaxDamage = 67;
            dagger.Attributes.BonusDex = 10;
            dagger.Attributes.AttackChance = 8;
            dagger.WeaponAttributes.HitDispel = 12;
            dagger.WeaponAttributes.HitLeechMana = 15;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 14.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfRussianHistory(Serial serial) : base(serial) { }

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

    public class TheChronicleOfTheRus : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Chronicle of the Rus", "By Chronicler Nestor",
            new BookPageInfo
            (
                "In the frozen north,",
                "where rivers coil",
                "and endless snows",
                "blanket the land,",
                "rose the tribes of",
                "the Rus. From humble",
                "wooden forts, princes",
                "dreamt of empire."
            ),
            new BookPageInfo
            (
                "Varangians sailed the",
                "Volga and Dnieper,",
                "trading furs for",
                "silver, blades for",
                "honor. Their shields",
                "shone by Novgorod.",
                "Their oaths echoed",
                "in Kiev’s halls."
            ),
            new BookPageInfo
            (
                "Mighty Tsars crowned",
                "themselves in Moscow,",
                "while holy icons",
                "glimmered in candlelight.",
                "Saints and sinners,",
                "monks and serfs—",
                "all were swept up",
                "in the song of Russia."
            ),
            new BookPageInfo
            (
                "Ivan the Terrible,",
                "red as the blood he",
                "spilled, claimed his",
                "destiny by fire and",
                "fear. Peter, the Great,",
                "opened a window to the",
                "west with steel and",
                "dreams of fleets."
            ),
            new BookPageInfo
            (
                "Napoleon’s ashes fed",
                "the snows; winter, the",
                "eternal ally. Empires",
                "rose and fell. Blood",
                "spilled at Borodino,",
                "cries echoed through",
                "the streets of St. Petersburg."
            ),
            new BookPageInfo
            (
                "In October’s storm,",
                "the world changed.",
                "The Red Banner unfurled.",
                "Kings fled, and the",
                "workers’ song thundered.",
                "From revolution’s flame,",
                "new iron giants marched."
            ),
            new BookPageInfo
            (
                "Now, beneath the watch",
                "of ancient forests and",
                "sapphire lakes, the",
                "story endures. Drink",
                "deep, traveler, of",
                "this northern land’s",
                "mystery—its hardship,",
                "its triumph, its soul."
            ),
            new BookPageInfo
            (
                "Beware, for within",
                "this chest lies not",
                "just gold, but the",
                "weight of centuries.",
                "The eyes of the Tsars,",
                "the shadows of the",
                "steppes, and the hope",
                "of a nation unbroken."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public TheChronicleOfTheRus() : base(false)
        {
            Hue = 1157; // Rich, bookish blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Chronicle of the Rus");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Chronicle of the Rus");
        }

        public TheChronicleOfTheRus(Serial serial) : base(serial) { }

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
