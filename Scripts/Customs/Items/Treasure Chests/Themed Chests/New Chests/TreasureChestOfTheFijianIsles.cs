using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheFijianIsles : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheFijianIsles()
        {
            Name = "Treasure Chest of the Fijian Isles";
            Hue = 2066; // Ocean blue or use any hue fitting for the theme

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateNamedItem<Banana>("Banana of Wakaya", 2053), 0.25);
            AddItem(CreateColoredItem<FruitBasket>("Bountiful Tanoa Fruit Bowl", 1271), 0.22);
            AddItem(CreateNamedItem<Diamond>("Pearl of the South Seas", 1152), 0.13);
            AddItem(CreateDecorativeStatue(), 0.10);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.16);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateShield(), 0.11);
            AddItem(CreatePotion(), 0.13);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateSpecialFish(), 0.14);
            AddItem(new Gold(Utility.Random(2000, 4000)), 0.20);
            AddItem(CreateUniqueItem(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheFijianIsles();
        }

        private Item CreateDecorativeStatue()
        {
            // Use a decorative artifact from your list and customize it
            var statue = new QuagmireStatue();
            statue.Name = "Tiki of the Chief’s Spirit";
            statue.Hue = 2101; // Rich wooden color
            return statue;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Hidden Caves of Viti Levu";
            map.Bounds = new Rectangle2D(500, 2500, 400, 400); // Fijian location suggestion
            map.NewPin = new Point2D(700, 2700);
            map.Protected = true;
            return map;
        }

        private Item CreateSpecialFish()
        {
            FishSteak fish = new FishSteak();
            fish.Name = "Walu, the Sacred Fish";
            fish.Hue = 1268; // Bright, tropical fish color
            return fish;
        }

        private Item CreatePotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Kava Brew of Healing";
            potion.Hue = 1193;
            return potion;
        }

        private Item CreateUniqueItem()
        {
            // A decorative, themed utility item
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Chief’s Ceremonial Feathered Hat";
            hat.Hue = 1166;
            hat.Attributes.Luck = 50;
            hat.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateWeapon()
        {
            // Fijian war clubs or spears—here, using a war fork as a “Fijian Totokia”
            WarFork fork = new WarFork();
            fork.Name = "Totokia, Club of the Islanders";
            fork.Hue = 1289;
            fork.Attributes.WeaponSpeed = 30;
            fork.Attributes.WeaponDamage = 45;
            fork.Attributes.BonusHits = 20;
            fork.Attributes.Luck = 30;
            fork.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            fork.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(fork, new XmlLevelItem());
            return fork;
        }

        private Item CreateShield()
        {
            // Fijian “Vula Shield”
            BronzeShield shield = new BronzeShield();
            shield.Name = "Vula Shield of the Sea Spirits";
            shield.Hue = 1172;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.SpellChanneling = 1;
            shield.Attributes.BonusStam = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateArmor()
        {
            // Woven armor “Armor of Tapa Cloth”
            LeatherChest chest = new LeatherChest();
            chest.Name = "Tapa Cloth Woven Chest";
            chest.Hue = 1125;
            chest.BaseArmorRating = Utility.Random(30, 55);
            chest.Attributes.BonusHits = 15;
            chest.Attributes.RegenHits = 3;
            chest.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            // Sulu (Fijian skirt)
            Skirt sulu = new Skirt();
            sulu.Name = "Ceremonial Sulu of the Chieftain";
            sulu.Hue = Utility.RandomMinMax(1165, 1178);
            sulu.Attributes.Luck = 25;
            sulu.Attributes.BonusMana = 10;
            sulu.SkillBonuses.SetValues(0, SkillName.Peacemaking, 15.0);
            XmlAttach.AttachTo(sulu, new XmlLevelItem());
            return sulu;
        }

        public TreasureChestOfTheFijianIsles(Serial serial) : base(serial)
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

    public class ChroniclesOfTheFijianIsles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Fijian Isles", "High Chief Ro Matanitobua",
            new BookPageInfo
            (
                "Long before the wind carried",
                "sails to our shores, our",
                "ancestors crossed the wild",
                "Pacific in double-hulled",
                "canoes, guided by stars,",
                "sharks, and the voices of",
                "our gods. We made landfall",
                "on Viti Levu and Vanua Levu."
            ),
            new BookPageInfo
            (
                "Villages rose by river and",
                "reef, bound by the mana",
                "of chiefs and the strength",
                "of the yavu—the bones of",
                "our ancestors. Each clan",
                "kept its own secrets:",
                "tapa patterns, war chants,",
                "potent kava for the chiefs."
            ),
            new BookPageInfo
            (
                "When the Tongans came,",
                "so did trade and battle.",
                "The warriors of Fiji carved",
                "Totokia and Ula clubs, and",
                "the vanua echoed with song",
                "and challenge. Chiefs like",
                "Seru Cakobau rose and fell.",
                "The isles united in strife."
            ),
            new BookPageInfo
            (
                "The white sails brought new",
                "faces. Cannons and mission",
                "bells followed. We tasted",
                "gunpowder and gospel. In",
                "1874, Fiji’s chiefs ceded",
                "their land to the Queen.",
                "Still, our hearts remained",
                "loyal to the vanua."
            ),
            new BookPageInfo
            (
                "Today, the spirits walk our",
                "beaches. Old gods rest",
                "beside new faiths. The tapa",
                "cloth is painted with tales",
                "of war, peace, and the",
                "endless blue sea. We stand,",
                "the children of fire and",
                "ocean, fierce and free."
            ),
            new BookPageInfo
            (
                "Guard well these treasures,",
                "for they bear the strength",
                "and mana of our people.",
                "May you honor the memory",
                "of the Chiefs, and may the",
                "sea bring you safely home.",
                "",
                "- Ro Matanitobua"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheFijianIsles() : base(false)
        {
            Hue = 2101; // Deep wood or blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Fijian Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Fijian Isles");
        }

        public ChroniclesOfTheFijianIsles(Serial serial) : base(serial) { }

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
