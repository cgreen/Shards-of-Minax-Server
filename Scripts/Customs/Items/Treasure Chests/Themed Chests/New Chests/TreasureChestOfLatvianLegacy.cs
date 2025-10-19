using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLatvianLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLatvianLegacy()
        {
            Name = "Treasure Chest of Latvia’s Legacy";
            Hue = 2075; // Deep blue, feel free to adjust

            // Decorative items
            AddItem(CreateNamedDeco<BrazierArtifact>("Fire of the Baltic Tribes", 1161), 0.18);
            AddItem(CreateNamedDeco<ArtifactVase>("Riga Pottery of the Hanseatic League", 32), 0.15);
            AddItem(CreateNamedDeco<SwordDisplay3EastArtifact>("Sword of Bearslayer Lāčplēsis", 2101), 0.08);
            AddItem(CreateNamedDeco<LibertyStatue>("Freedom Monument Miniature", 33), 0.10); // Assume custom deco item or swap out
            AddItem(CreateNamedDeco<BowlArtifact>("Daugava River Water Bowl", 1152), 0.15);
            AddItem(CreateNamedDeco<Tapestry1N>("Tapestry of Song and Light", 1154), 0.11);
            AddItem(CreateNamedDeco<FlowersArtifact>("Wildflowers of Gauja", 91), 0.17);
            AddItem(CreateNamedDeco<GoldBricks>("Amber of the Baltic Coast", 1001), 0.13);

            // Consumables & unique loot
            AddItem(CreateUniqueFood<BreadLoaf>("Latvian Rye Bread", 1175), 0.25);
            AddItem(CreateUniqueFood<FruitBasket>("Basket of Forest Berries", 68), 0.22);
            AddItem(CreateUniqueDrink<GreenTea>("Herbal Tēja", 64), 0.23);

            // Powerful equipment
            AddItem(CreateUniqueWeapon(), 0.22);
            AddItem(CreateUniqueArmor(), 0.21);
            AddItem(CreateUniqueClothing(), 0.22);

            // Lore Book
            AddItem(new ChronicleOfLatvia(), 1.0);

            // Currency / gold
            AddItem(CreateLatvianCoin(), 0.18);
            AddItem(new Gold(Utility.Random(1, 6500)), 0.19);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative with name/hue
        private Item CreateNamedDeco<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique food with name/hue
        private Item CreateUniqueFood<T>(string name, int hue) where T : Item, new()
        {
            T food = new T();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        // Unique drink
        private Item CreateUniqueDrink<T>(string name, int hue) where T : Item, new()
        {
            T drink = new T();
            drink.Name = name;
            drink.Hue = hue;
            return drink;
        }

        // Custom Latvian coin (gold with name)
        private Item CreateLatvianCoin()
        {
            Gold coin = new Gold();
            coin.Amount = Utility.Random(100, 500);
            coin.Name = "Ancient Latvian Lats";
            return coin;
        }

        // Unique clothing: Lielvārde Belt
        private Item CreateUniqueClothing()
        {
            BodySash sash = new BodySash();
            sash.Name = "Lielvārde Belt of Wisdom";
            sash.Hue = 1157; // Red
            sash.Attributes.Luck = 150;
            sash.Attributes.BonusInt = 10;
            sash.Attributes.NightSight = 1;
            sash.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        // Unique weapon: Sword of Bear Slayer (Lāčplēsis)
        private Item CreateUniqueWeapon()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Lāčplēsis’ Bearslayer Blade";
            sword.Hue = 2101; // Gold
            sword.MinDamage = 30;
            sword.MaxDamage = 65;
            sword.Attributes.BonusStr = 15;
            sword.Attributes.BonusHits = 40;
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 30;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.WeaponAttributes.HitLeechHits = 12;
            sword.WeaponAttributes.HitLightning = 15;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Unique armor: Folk Chest of the Dainas
        private Item CreateUniqueArmor()
        {
            LeatherChest chest = new LeatherChest();
            chest.Name = "Folk Chest of the Dainas";
            chest.Hue = 2075; // Deep blue
            chest.BaseArmorRating = Utility.Random(45, 70);
            chest.Attributes.RegenMana = 7;
            chest.Attributes.BonusStam = 20;
            chest.Attributes.DefendChance = 15;
            chest.SkillBonuses.SetValues(0, SkillName.Musicianship, 12.0);
            chest.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            chest.ColdBonus = 10;
            chest.FireBonus = 5;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        public TreasureChestOfLatvianLegacy(Serial serial) : base(serial)
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

    // Lore Book: Chronicle of Latvia
    public class ChronicleOfLatvia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Latvia", "The Singers of the Dainas",
            new BookPageInfo
            (
                "In ancient forest shadows",
                "Where the Daugava flows free,",
                "The tribes of Letgallians, Livonians,",
                "Wove song into memory.",
                "Amber gleamed on the coastline,",
                "Trade boats graced the sea,",
                "Riga's towers rising,",
                "Bound in Hanseatic unity."
            ),
            new BookPageInfo
            (
                "The sword of Lāčplēsis,",
                "Bearslayer’s mighty hand,",
                "Drove back the iron crusaders,",
                "Defending his homeland.",
                "Folk songs and runes endured,",
                "In whisper and in word,",
                "The Lielvārde Belt remembered,",
                "By every child heard."
            ),
            new BookPageInfo
            (
                "The Freedom Monument rises,",
                "In Riga’s open square,",
                "For those who sang of freedom,",
                "And fought despair.",
                "Forest brothers lingered,",
                "In shadows deep and wide,",
                "Their hope unbroken,",
                "Though tyrants tried."
            ),
            new BookPageInfo
            (
                "Let these treasures remind you,",
                "Of lands proud and strong,",
                "Of a people whose history",
                "Lives ever in song.",
                "Raise the sun of the morning,",
                "On fields of golden rye,",
                "Latvia's legacy endures,",
                "Under the Baltic sky."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfLatvia() : base(false)
        {
            Hue = 2075; // Deep blue for Latvia
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Latvia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Latvia");
        }

        public ChronicleOfLatvia(Serial serial) : base(serial) { }

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

    // Example custom deco: You can swap this for any deco item if LibertyStatue is not defined.
    public class LibertyStatue : StatueSouth
    {
        [Constructable]
        public LibertyStatue()
        {
            Name = "Freedom Monument Miniature";
            Hue = 33; // Silver/grey
        }

        public LibertyStatue(Serial serial) : base(serial) { }

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
