using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfArabiasSands : WoodenChest
    {
        [Constructable]
        public TreasureChestOfArabiasSands()
        {
            Name = "Treasure Chest of Arabia's Sands";
            Hue = 2101; // Sandy golden hue

            // Add items to the chest
            AddItem(new SandRoseArtifact(), 0.20);
            AddItem(CreateDecorativeLamp(), 0.12);
            AddItem(CreateColoredItem<IncenseBurner>("Incense Burner of the Empty Quarter", 2407), 0.18);
            AddItem(CreateAncientCoin(), 0.30);
            AddItem(CreateArabianCoffee(), 0.22);
            AddItem(CreateZamzamWater(), 0.18);
            AddItem(CreateBedouinRobe(), 0.17);
            AddItem(CreateDesertScimitar(), 0.15);
            AddItem(CreateFalconerHood(), 0.14);
            AddItem(CreateSandwalkersBoots(), 0.13);
            AddItem(CreateCarvedCamelFigurine(), 0.18);
            AddItem(CreateMapToIram(), 0.05);
            AddItem(CreateRoyalRing(), 0.10);
            AddItem(new ChroniclesOfTheSands(), 1.0);
            AddItem(new Gold(Utility.Random(2500, 5000)), 0.13);
            AddItem(CreateRareSpices(), 0.11);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative unique items

        private Item CreateAncientCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Ancient Coin of the Nabateans";
            gold.Hue = 2422; // Old gold
            return gold;
        }

        private Item CreateCarvedCamelFigurine()
        {
            WolfStatue camel = new WolfStatue(); // Using wolf as a base for a figurine, customize hue/name
            camel.Name = "Carved Camel Figurine";
            camel.Hue = 1812;
            return camel;
        }

        private Item CreateDecorativeLamp()
        {
            LampPostArtifact lamp = new LampPostArtifact();
            lamp.Name = "Enchanted Oil Lamp";
            lamp.Hue = 2105;
            return lamp;
        }

        private Item CreateMapToIram()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Iram";
            map.Bounds = new Rectangle2D(3500, 3300, 300, 300);
            map.NewPin = new Point2D(3600, 3450);
            map.Protected = true;
            return map;
        }

        private Item CreateRareSpices()
        {
            SackFlourOpen spices = new SackFlourOpen();
            spices.Name = "Sack of Rare Arabian Spices";
            spices.Hue = 1701;
            return spices;
        }

        // Consumable items

        private Item CreateArabianCoffee()
        {
            CoffeeMug coffee = new CoffeeMug();
            coffee.Name = "Royal Qahwa (Arabian Coffee)";
            coffee.Hue = 1171;
            return coffee;
        }

        private Item CreateZamzamWater()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Bottle of Zamzam Water";
            potion.Hue = 96; // Light blue/clear
            potion.Stackable = false;
            potion.Amount = 1;
            return potion;
        }

        // Unique equipment

        private Item CreateBedouinRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Bedouin Magi";
            robe.Hue = 2101;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.LowerManaCost = 10;
            robe.Attributes.RegenMana = 4;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            robe.Attributes.Luck = 200;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDesertScimitar()
        {
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Scimitar of the Desert Prince";
            scimitar.Hue = 2125;
            scimitar.WeaponAttributes.HitFireball = 30;
            scimitar.WeaponAttributes.HitLightning = 20;
            scimitar.WeaponAttributes.SelfRepair = 6;
            scimitar.Attributes.WeaponSpeed = 20;
            scimitar.Attributes.WeaponDamage = 35;
            scimitar.Attributes.BonusStam = 10;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateFalconerHood()
        {
            FeatheredHat hood = new FeatheredHat();
            hood.Name = "Arabian Falconer's Hood";
            hood.Hue = 1175;
            hood.Attributes.BonusDex = 10;
            hood.Attributes.NightSight = 1;
            hood.Attributes.BonusHits = 8;
            hood.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 12.0);
            hood.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            XmlAttach.AttachTo(hood, new XmlLevelItem());
            return hood;
        }

        private Item CreateSandwalkersBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Sandwalker's Boots";
            boots.Hue = 1790;
            boots.Attributes.BonusDex = 7;
            boots.Attributes.LowerRegCost = 10;
            boots.Attributes.Luck = 50;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateRoyalRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of House Saud";
            ring.Hue = 1157;
            ring.Attributes.BonusInt = 8;
            ring.Attributes.BonusStr = 7;
            ring.Attributes.SpellChanneling = 1;
            ring.Attributes.RegenHits = 3;
            ring.Attributes.RegenStam = 3;
            ring.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            ring.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 7.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        // Helper for colored decorative items
        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        public TreasureChestOfArabiasSands(Serial serial) : base(serial) { }

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
    public class ChroniclesOfTheSands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Sands: The Story of Arabia", "A Sage of the Empty Quarter",
            new BookPageInfo
            (
                "From the red dunes of Rub' al Khali,",
                "to the ancient ruins of Iram,",
                "the sands of Arabia hold secrets",
                "as old as time. Kingdoms rose",
                "and fell under the desert sun,",
                "from the Nabateans, masters of",
                "incense and trade, to the",
                "powerful Lihyanites and Kindites."
            ),
            new BookPageInfo
            (
                "In the valleys of Hijaz, the",
                "holy cities of Mecca and",
                "Medina became sanctuaries for",
                "pilgrims and prophets. The",
                "voice of Muhammad, peace be",
                "upon him, echoed from the",
                "caves of Hira, shaping the",
                "destiny of nations."
            ),
            new BookPageInfo
            (
                "The sands bore witness to",
                "the Rashidun and Umayyad",
                "caliphates, to the centuries",
                "of Ottoman rule, and to the",
                "birth of a new nation: the",
                "Kingdom of Saudi Arabia,",
                "forged by the House of Saud,",
                "uniting tribes beneath one banner."
            ),
            new BookPageInfo
            (
                "Here are treasures of legend:",
                "jewels from lost cities,",
                "weapons of desert princes,",
                "robes of mystics, and coins",
                "from caravans vanished beneath",
                "the dunes. All await the",
                "one who is bold enough",
                "to open this chest."
            ),
            new BookPageInfo
            (
                "But beware: the desert keeps",
                "its secrets close, and not",
                "all who seek fortune return.",
                "To disturb the past is to",
                "risk the wrath of its",
                "spirits. Respect what you find,",
                "and may the blessing of",
                "the sands go with you."
            ),
            new BookPageInfo
            (
                "",
                "Let this chest stand as a",
                "reminder: Arabia's story is",
                "written not only in gold, but",
                "in courage, faith, and the",
                "enduring strength of its people.",
                "",
                "- The Sage"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheSands() : base(false)
        {
            Hue = 2101; // sandy golden
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Sands: The Story of Arabia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Sands: The Story of Arabia");
        }

        public ChroniclesOfTheSands(Serial serial) : base(serial) { }

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

    // Custom artifact example: Desert Rose
    public class SandRoseArtifact : Item
    {
        [Constructable]
        public SandRoseArtifact() : base(0xF19)
        {
            Name = "Desert Rose Crystal";
            Hue = 1815;
            Weight = 2.0;
        }

        public SandRoseArtifact(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
