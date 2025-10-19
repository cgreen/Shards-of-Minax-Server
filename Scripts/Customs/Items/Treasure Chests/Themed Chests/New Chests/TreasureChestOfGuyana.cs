using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGuyana : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGuyana()
        {
            Name = "Treasure Chest of the Land of Many Waters";
            Hue = 1289; // Deep green, like Guyanese rainforest

            // Unique Decorative Artifacts
            AddItem(CreateArtifact<JadeSkull>("Jaguar God Carving", 1166), 0.15);
            AddItem(CreateArtifact<GoldBricks>("El Dorado's Lost Gold Ingot", 2213), 0.10);
            AddItem(CreateArtifact<MiniCherryTree>("Miniature Kaiteur Falls", 0), 0.10);
            AddItem(CreateArtifact<FancyHornOfPlenty>("Horn of Plenty, Demerara", 1153), 0.08);
            AddItem(CreateArtifact<AncientDrum>("Macushi Ceremonial Drum", 2125), 0.10);

            // Consumables
            AddItem(CreateConsumable<RandomDrink>("Rum of the Demerara", 2105), 0.15);
            AddItem(CreateConsumable<BreadLoaf>("Cassava Bread", 1111), 0.18);
            AddItem(CreateConsumable<AwaseMisoSoup>("Wild Pepper Pot Stew", 1325), 0.15);
            AddItem(CreateConsumable<GreaterHealPotion>("Eldorado Elixir", 2213), 0.11);

            // Unique Equipment - Armor
            AddItem(CreateMacushiChieftainArmor(), 0.20);
            AddItem(CreateDutchColonistHat(), 0.18);
            AddItem(CreateMaroonScoutCloak(), 0.17);
            AddItem(CreateAmerindianHealerRobe(), 0.19);

            // Unique Equipment - Weapons
            AddItem(CreateWeapon<Katana>("Dutch Colonist's Rapier", 2413), 0.14);
            AddItem(CreateWeapon<QuarterStaff>("Waruka River Quarterstaff", 2208), 0.12);
            AddItem(CreateWeapon<Bow>("Bow of the Rainforest Archer", 1260), 0.15);

            // Miscellaneous Treasures
            AddItem(CreateArtifact<Diamond>("Sunstone of Kaieteur", 1272), 0.11);
            AddItem(CreateArtifact<SilverEarrings>("Silver Ear Pendants, Arawak", 2001), 0.13);
            AddItem(CreateArtifact<Gold>("Coins of El Dorado", 2213, 3500), 0.16);

            // Lore Book
            AddItem(new ChroniclesOfGuyana(), 1.0);

            // Map to the Lost City of Gold
            AddItem(CreateMap(), 0.08);
        }

        // =============== Item Factory Helpers =====================

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateArtifact<T>(string name, int hue, int amount = 1) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            if (item is Gold gold && amount > 1)
                gold.Amount = amount;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateWeapon<T>(string name, int hue) where T : BaseWeapon, new()
        {
            T weapon = new T();
            weapon.Name = name;
            weapon.Hue = hue;
            weapon.WeaponAttributes.HitHarm = 15;
            weapon.WeaponAttributes.SelfRepair = Utility.Random(3, 7);
            weapon.Attributes.WeaponSpeed = Utility.Random(15, 30);
            weapon.Attributes.WeaponDamage = Utility.Random(20, 40);
            weapon.Attributes.Luck = Utility.Random(50, 90);
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 12.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Gold";
            map.Bounds = new Rectangle2D(5600, 1000, 500, 500);
            map.NewPin = new Point2D(5750, 1250);
            map.Protected = true;
            return map;
        }

        // =============== Unique Equipment Methods =================

        private Item CreateMacushiChieftainArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Macushi Chieftain's Chestplate";
            chest.Hue = 1282;
            chest.BaseArmorRating = 65;
            chest.Attributes.BonusStr = 12;
            chest.Attributes.BonusHits = 20;
            chest.Attributes.RegenHits = 3;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 6.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateDutchColonistHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Dutch Colonist's Tricorne";
            hat.Hue = 2306;
            hat.Attributes.NightSight = 1;
            hat.Attributes.BonusInt = 7;
            hat.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Stealth, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMaroonScoutCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Maroon Scout's Jungle Cloak";
            cloak.Hue = 1415;
            cloak.Attributes.Luck = 60;
            cloak.Attributes.BonusDex = 9;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 14.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Archery, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateAmerindianHealerRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Amerindian Healer's Robe";
            robe.Hue = 1154;
            robe.Attributes.RegenMana = 3;
            robe.Attributes.BonusMana = 8;
            robe.Attributes.CastRecovery = 2;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 7.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // =============== Serialization ===========================

        public TreasureChestOfGuyana(Serial serial) : base(serial) { }
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

    // =============== Lore Book ===========================
    public class ChroniclesOfGuyana : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of Many Waters", "Eldorado Scribe",
            new BookPageInfo
            (
                "From the green heart of the",
                "rainforest to the gold-laced",
                "rivers, Guyana is a land of",
                "mystery, beauty, and power.",
                "Long before the sails of",
                "Spain and the guns of",
                "Holland, the Arawak and",
                "Carib walked these shores."
            ),
            new BookPageInfo
            (
                "The land is cut by mighty",
                "waters — the Demerara,",
                "Essequibo, Berbice — and",
                "veiled in ancient tales.",
                "Here, legend whispers of",
                "El Dorado, a city of gold,",
                "hidden by mist, guarded",
                "by spirits and jaguars."
            ),
            new BookPageInfo
            (
                "Colonists came, seeking gold,",
                "sugar, land, and slaves.",
                "Dutch, French, then British",
                "flags rose and fell. Maroon",
                "warriors and indigenous",
                "chieftains resisted, their",
                "stories flowing like rivers,",
                "unbroken and proud."
            ),
            new BookPageInfo
            (
                "Cane fields spread, Africans",
                "brought in chains, then freed.",
                "Indentured laborers from India,",
                "China, Portugal joined the",
                "melting pot. Guyana became",
                "a land of many peoples,",
                "many faiths, many dreams.",
                ""
            ),
            new BookPageInfo
            (
                "Yet the wild still rules.",
                "The jungle hides secrets:",
                "kaiteur's endless falls,",
                "poisonous frogs, mighty",
                "anacondas, diamond rivers,",
                "and the lost City of Gold.",
                "Some say it waits still,",
                "for the worthy or the wise."
            ),
            new BookPageInfo
            (
                "Treasure hunter, respect the",
                "spirits of this land. Listen",
                "to the drums, heed the calls",
                "of howler monkeys and harpy",
                "eagles. What you take from",
                "Guyana, you must give back",
                "in honor, or be forever lost.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Here in this chest are",
                "memories of Guyana:",
                "golden hopes, jungle",
                "relics, and a map to",
                "El Dorado. May you find",
                "your fortune — but never",
                "lose your soul.",
                "",
                "- Eldorado Scribe"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfGuyana() : base(false)
        {
            Hue = 1272; // Gold/yellow
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of Many Waters");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of Many Waters");
        }

        public ChroniclesOfGuyana(Serial serial) : base(serial) { }
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
