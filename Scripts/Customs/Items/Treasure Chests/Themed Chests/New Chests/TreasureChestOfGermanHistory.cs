using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGermanHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGermanHistory()
        {
            Name = "Treasure Chest of German History";
            Hue = 1109; // Black Forest shade

            AddItem(CreateLoreBook(), 1.0);

            // Decorative Relics
            AddItem(CreateDecor("Gutenberg’s Printing Press Replica", typeof(AncientRunes), 1161), 0.20);
            AddItem(CreateDecor("Teutonic Knight’s Banner", typeof(OrderBanner), 1152), 0.17);
            AddItem(CreateDecor("Black Forest Cuckoo Clock", typeof(LargeGrandfatherClock), 2101), 0.13);
            AddItem(CreateDecor("Iron Crown of Charlemagne", typeof(NorseHelm), 2405), 0.12);
            AddItem(CreateDecor("Bavarian Crystal Stein", typeof(GlassMug), 1153), 0.18);
            AddItem(CreateDecor("Brandenburg Gate Model", typeof(Sculpture1Artifact), 1175), 0.10);
            AddItem(CreateDecor("Prussian Saber Display", typeof(DecorativeSwordWest), 1108), 0.11);
            AddItem(CreateDecor("Wagner’s Opera Score", typeof(AcademicBooksArtifact), 1178), 0.10);
            AddItem(CreateDecor("Imperial Reichsadler Standard", typeof(EvilIdolSkull), 1109), 0.11);

            // Consumables
            AddItem(CreateFood("Black Forest Cake", typeof(Cake), 1133), 0.20);
            AddItem(CreateFood("Bavarian Pretzel", typeof(BreadLoaf), 242), 0.18);
            AddItem(CreateFood("Stein of Dwarven Ale", typeof(CeramicMug), 1107), 0.22);
            AddItem(CreateFood("Hearty Wurst Plate", typeof(Sausage), 38), 0.17);

            // Equipment
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateHat(), 0.18);
            AddItem(CreateClothing(), 0.21);
            AddItem(CreateMusicalInstrument(), 0.14);

            // Coins
            AddItem(CreateCoin("Silver Mark"), 0.15);
            AddItem(CreateCoin("Imperial Thaler"), 0.12);

            // Gold
            AddItem(new Gold(Utility.Random(2500, 8000)), 0.25);
        }

        // Helper Methods
        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decoratives
        private Item CreateDecor(string name, Type type, int hue)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumables
        private Item CreateFood(string name, Type type, int hue)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            item.Hue = hue;
            item.Weight = 1.0;
            return item;
        }

        // Unique Coin
        private Item CreateCoin(string name)
        {
            Gold coin = new Gold(Utility.Random(200, 500));
            coin.Name = name;
            coin.Hue = 2406;
            return coin;
        }

        // Weapons
        private Item CreateWeapon()
        {
            BaseWeapon weapon;
            switch (Utility.Random(4))
            {
                case 0: weapon = new Broadsword(); break;
                case 1: weapon = new Halberd(); break;
                case 2: weapon = new Longsword(); break;
                default: weapon = new WarAxe(); break;
            }
            weapon.Name = "Sword of Frederick Barbarossa";
            weapon.Hue = 1108;
            weapon.MaxDamage = Utility.Random(45, 95);
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusHits = 25;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.WeaponDamage = 35;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            weapon.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Armor
        private Item CreateArmor()
        {
            BaseArmor armor;
            switch (Utility.Random(4))
            {
                case 0: armor = new PlateChest(); break;
                case 1: armor = new PlateHelm(); break;
                case 2: armor = new PlateArms(); break;
                default: armor = new PlateLegs(); break;
            }
            armor.Name = "Imperial Armor of Otto the Great";
            armor.Hue = 1175;
            armor.BaseArmorRating = Utility.Random(35, 75);
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusStam = 10;
            armor.ArmorAttributes.SelfRepair = 6;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Blacksmith, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Hat (for fun - could be Pickelhaube, Crown, etc.)
        private Item CreateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Pickelhaube of the Kaiser";
            hat.Hue = 1109;
            hat.Attributes.Luck = 40;
            hat.Attributes.BonusDex = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Archery, 8.0);
            hat.SkillBonuses.SetValues(1, SkillName.Tactics, 5.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        // Clothing
        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of Goethe’s Wisdom";
            robe.Hue = 2101;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Inscribe, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Instrument
        private Item CreateMusicalInstrument()
        {
            Harp harp = new Harp();
            harp.Name = "Beethoven’s Enchanted Harp";
            harp.Hue = 1154;
            XmlAttach.AttachTo(harp, new XmlLevelItem());
            return harp;
        }

        // Lore Book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfGermany();
        }

        public TreasureChestOfGermanHistory(Serial serial) : base(serial) { }

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

    public class ChroniclesOfGermany : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Fatherland", "The Wanderer",
            new BookPageInfo
            (
                "Here lies the tale of Germany,",
                "from shadowed forests where",
                "tribes once roamed, to mighty",
                "empires, and the spark of",
                "ideas that shaped a continent.",
                "Let the seeker find wisdom,",
                "glory, and warning within.",
                ""
            ),
            new BookPageInfo
            (
                "In ages past, the Teutons",
                "and Cherusci fought the Rome.",
                "The Rhine a wild frontier.",
                "The Black Forest dark,",
                "the Lorelei sang to sailors.",
                "Charlemagne’s crown brought unity,",
                "but the dream was fleeting."
            ),
            new BookPageInfo
            (
                "Barbarossa rode to Crusade,",
                "Otto the Great forged order.",
                "Castles crowned the rivers,",
                "cities rose with pride—Cologne,",
                "Nuremberg, Lübeck, Dresden.",
                "The Hanse’s ships sailed far,",
                "bringing gold and tales home."
            ),
            new BookPageInfo
            (
                "Gutenberg pressed ink to paper.",
                "Luther’s words shook the faith.",
                "The Holy Roman Empire splintered.",
                "Musicians, thinkers, poets rose—",
                "Goethe’s pen, Bach’s hands,",
                "Beethoven’s storms, Grimm’s tales.",
                "The world listened."
            ),
            new BookPageInfo
            (
                "Prussia’s steel, Bismarck’s mind,",
                "the empire unites at last.",
                "Wars scar the land—Napoleon,",
                "Franco, the World at war.",
                "Berlin’s walls rise, then fall.",
                "From ruins, a phoenix: unity anew."
            ),
            new BookPageInfo
            (
                "Today the eagle flies",
                "from Alps to sea. The Fatherland",
                "stands, shaped by strife,",
                "renewed by hope, built on the",
                "brilliance and blood of",
                "ages. Remember—each stone,",
                "each story, makes the whole."
            ),
            new BookPageInfo
            (
                "He who opens this chest,",
                "may the strength of knights,",
                "the mind of poets,",
                "and the will of a people",
                "ever guide your hand.",
                "",
                "- The Wanderer",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfGermany() : base(false)
        {
            Hue = 1108; // Imperial black
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Fatherland");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Fatherland");
        }

        public ChroniclesOfGermany(Serial serial) : base(serial) { }

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
