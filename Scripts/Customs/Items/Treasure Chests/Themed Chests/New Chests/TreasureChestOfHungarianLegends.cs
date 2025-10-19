using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfHungarianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfHungarianLegends()
        {
            Name = "Treasure Chest of Hungarian Legends";
            Hue = 1157; // Rich, royal blue

            // Add themed items
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateHolyCrown(), 0.06);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Buda Castle Urn", 1153), 0.14);
            AddItem(CreateDecorativeItem<TurulStatuette>("Statuette of the Turul", 2212), 0.10);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Sword of Saint Stephen", 1175), 0.12);
            AddItem(CreateDecorativeItem<GoldBricks>("Lost Gold of the Danube", 1367), 0.16);
            AddItem(CreateConsumableItem<RandomFancyPotion>("Pálinka of the Magyars", 37), 0.20);
            AddItem(CreateConsumableItem<MeatPie>("Hearty Hungarian Goulash", 1926), 0.17);
            AddItem(CreateConsumableItem<Bottle>("Tokaji Wine", 1171), 0.17);
            AddItem(CreateUniqueWeapon(), 0.20);
            AddItem(CreateUniqueArmor(), 0.20);
            AddItem(CreateUniqueClothing(), 0.16);
            AddItem(CreateUniqueHelmet(), 0.13);
            AddItem(CreateUniqueBoots(), 0.18);
            AddItem(CreateHungarianGold("Hungarian Florin"), 0.25);
            AddItem(new Gold(Utility.Random(1000, 8000)), 0.25);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateHungarianGold(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateHolyCrown()
        {
            DecorativeShield2 crown = new DecorativeShield2();
            crown.Name = "Holy Crown of Hungary";
            crown.Hue = 1281; // Goldish
            crown.LootType = LootType.Blessed;
            crown.Weight = 1.0;
            return crown;
        }

        private Item CreateUniqueWeapon()
        {
            // Legendary saber of Attila the Hun
            Katana weapon = new Katana();
            weapon.Name = "Sword of Attila the Hun";
            weapon.Hue = 2425;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.BonusStam = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            weapon.WeaponAttributes.HitLeechHits = 20;
            weapon.WeaponAttributes.HitLeechStam = 10;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Royal Armor of Saint Stephen";
            chest.Hue = 1175; // Deep blue/gold
            chest.BaseArmorRating = 60;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.Luck = 100;
            chest.ArmorAttributes.SelfRepair = 3;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueClothing()
        {
            // Festive Magyar Robe
            Robe robe = new Robe();
            robe.Name = "Magyar Conqueror’s Robe";
            robe.Hue = 33; // Crimson
            robe.Attributes.BonusInt = 15;
            robe.Attributes.LowerManaCost = 8;
            robe.Attributes.LowerRegCost = 12;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            robe.SkillBonuses.SetValues(2, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueHelmet()
        {
            Bascinet helm = new Bascinet();
            helm.Name = "Helm of the Black Army";
            helm.Hue = 2406; // Black steel
            helm.BaseArmorRating = 38;
            helm.ArmorAttributes.DurabilityBonus = 25;
            helm.Attributes.BonusStr = 8;
            helm.Attributes.NightSight = 1;
            helm.SkillBonuses.SetValues(0, SkillName.Tactics, 7.5);
            helm.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateUniqueBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Danube Rider";
            boots.Hue = 2213; // Deep river blue
            boots.Attributes.BonusDex = 10;
            boots.Attributes.Luck = 20;
            boots.Attributes.RegenStam = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            boots.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfHungary();
        }

        public TreasureChestOfHungarianLegends(Serial serial) : base(serial) { }

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

    // Custom Lore Book
    public class ChroniclesOfHungary : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Hungary", "Anonymous",
            new BookPageInfo
            (
                "In ancient times, the",
                "Magyars rode from the",
                "vast steppes to the",
                "Carpathian Basin, led by",
                "Árpád and their fierce",
                "chieftains. The rivers",
                "and plains echoed with",
                "the thunder of hooves."
            ),
            new BookPageInfo
            (
                "From Attila the Hun to",
                "Saint Stephen, Hungary",
                "has been shaped by",
                "conquerors and kings.",
                "The Holy Crown binds",
                "the land, uniting its",
                "peoples under one faith,",
                "one banner."
            ),
            new BookPageInfo
            (
                "Buda rose, adorned by",
                "royal courts, while",
                "peasants toiled and",
                "warriors defended the",
                "realm from all invaders.",
                "The Black Army rode in",
                "defense of Christendom,",
                "their banners proud."
            ),
            new BookPageInfo
            (
                "Turul birds soar above",
                "the Danube, watching",
                "over a land forged in",
                "battle, faith, and fire.",
                "Through centuries of",
                "glory and tragedy, the",
                "Hungarian spirit endures."
            ),
            new BookPageInfo
            (
                "Drink the Tokaji wine,",
                "break bread with friends.",
                "Let the tales of the",
                "past remind you: Hungary",
                "is not a place, but a",
                "people—a legend that",
                "will never fade."
            ),
            new BookPageInfo
            (
                "Those who open this",
                "chest, know: these are",
                "the treasures of the",
                "Kingdom of Hungary.",
                "",
                "– The Anonymous Chronicler",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfHungary() : base(false)
        {
            Hue = 1157; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Hungary");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Hungary");
        }

        public ChroniclesOfHungary(Serial serial) : base(serial) { }

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

    // Custom Turul bird statuette for thematic flavor (can use a base decorative class)
    public class TurulStatuette : StatueSouth
    {
        [Constructable]
        public TurulStatuette()
        {
            Name = "Statuette of the Turul";
            Hue = 2212;
            Weight = 3.0;
        }

        public TurulStatuette(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
