using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGrenada : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGrenada()
        {
            Name = "Treasure Chest of Grenada";
            Hue = Utility.RandomList(1417, 1150, 2117, 2000); // Red-gold-green hues

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem<Basket1Artifact>("Basket of Nutmeg", 1194), 0.30);
            AddItem(CreateDecorativeItem<LargeVase>("Colonial Spice Jar", 2001), 0.22);
            AddItem(CreateDecorativeItem<RedBottle>("Caribbean Rum Bottle", 1167), 0.25);
            AddItem(CreateDecorativeItem<ManStatuetteSouthArtifact>("Kalinago Ancestor Carving", 2406), 0.18);
            AddItem(CreateDecorativeItem<OrcMask>("Jab Jab Carnival Mask", 1801), 0.18);
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Model of the HMS Grenada", 1193), 0.08);
            AddItem(CreateMap(), 0.12);
            AddItem(CreateFoodItem<GreenTea>("Grenadian Nutmeg Tea", 65), 0.13);
            AddItem(CreateFoodItem<ChocolateNutcracker>("Spiced Chocolate Bar", 1191), 0.10);
            AddItem(CreateFoodItem<RandomFruitBasket>("Basket of Tropical Fruit", 1405), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Caribbean Wind"), 0.14);
            AddItem(CreateNamedItem<BodySash>("Revolutionary’s Sash of 1979"), 0.13);
            AddItem(CreateGoldItem("Grenada Doubloon"), 0.15);

            // Epic equipment (high mod)
            AddItem(CreatePirateHat(), 0.25);
            AddItem(CreateCutlass(), 0.18);
            AddItem(CreateRevolutionaryCoat(), 0.20);
            AddItem(CreateJabJabBoots(), 0.17);
            AddItem(CreateNutmegAmulet(), 0.20);
            AddItem(CreateCocoaStaff(), 0.12);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            if (item is Food food)
                food.FillFactor = 8;
            return item;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(1500, 4500);
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Pirate's Map of Grenada";
            map.Bounds = new Rectangle2D(510, 1180, 400, 400); // Custom coords
            map.NewPin = new Point2D(575, 1350);
            map.Protected = true;
            return map;
        }

        private Item CreatePirateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Pirate King's Hat";
            hat.Hue = 1191;
            hat.Attributes.BonusDex = 10;
            hat.Attributes.BonusStr = 5;
            hat.Attributes.Luck = 100;
            hat.SkillBonuses.SetValues(0, SkillName.Stealth, 20.0);
            hat.SkillBonuses.SetValues(1, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateCutlass()
        {
            Cutlass cutlass = new Cutlass();
            cutlass.Name = "Spice Trader's Cutlass";
            cutlass.Hue = 1167;
            cutlass.MinDamage = Utility.Random(25, 45);
            cutlass.MaxDamage = Utility.Random(60, 80);
            cutlass.Attributes.WeaponSpeed = 30;
            cutlass.Attributes.WeaponDamage = 45;
            cutlass.WeaponAttributes.HitHarm = 25;
            cutlass.WeaponAttributes.HitFireball = 15;
            cutlass.SkillBonuses.SetValues(0, SkillName.Tactics, 18.0);
            XmlAttach.AttachTo(cutlass, new XmlLevelItem());
            return cutlass;
        }

        private Item CreateRevolutionaryCoat()
        {
            Robe robe = new Robe();
            robe.Name = "Coat of the Revolution";
            robe.Hue = 1150; // Red
            robe.Attributes.RegenHits = 8;
            robe.Attributes.BonusStr = 7;
            robe.Attributes.NightSight = 1;
            robe.Attributes.BonusStam = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 18.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 15.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateJabJabBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Jab Jab's Dancing Boots";
            boots.Hue = 2117;
            boots.Attributes.Luck = 80;
            boots.Attributes.BonusDex = 12;
            boots.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Wrestling, 15.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateNutmegAmulet()
        {
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Amulet of Nutmeg Spirit";
            amulet.Hue = 1194;
            amulet.Attributes.BonusMana = 8;
            amulet.Attributes.SpellDamage = 10;
            amulet.Attributes.Luck = 70;
            amulet.SkillBonuses.SetValues(0, SkillName.Alchemy, 20.0);
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateCocoaStaff()
        {
            QuarterStaff staff = new QuarterStaff();
            staff.Name = "Cocoa Planter's Staff";
            staff.Hue = 2101;
            staff.MinDamage = Utility.Random(30, 50);
            staff.MaxDamage = Utility.Random(70, 85);
            staff.Attributes.SpellChanneling = 1;
            staff.Attributes.CastSpeed = 1;
            staff.Attributes.CastRecovery = 2;
            staff.Attributes.BonusInt = 10;
            staff.SkillBonuses.SetValues(0, SkillName.Magery, 16.0);
            staff.SkillBonuses.SetValues(1, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        private Item CreateLoreBook()
        {
            return new GrenadaLoreBook();
        }

        public TreasureChestOfGrenada(Serial serial) : base(serial)
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

    public class GrenadaLoreBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Spirit of Grenada", "Written by The Wandering Scholar",
            new BookPageInfo
            (
                "On the ocean’s edge, Grenada",
                "rose from the green-blue sea.",
                "First came the Kalinago, fierce",
                "and proud, who called it Camahogne,",
                "land of rivers and nutmeg-scented",
                "hills, where rain falls like silver.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Spaniards and French arrived,",
                "and blood was spilled for fertile",
                "soil. The French built forts and",
                "called it La Grenade. Then came the",
                "English, who claimed the island with",
                "iron and law. Grenada’s fields filled",
                "with cane, cocoa, and the spice of life: nutmeg."
            ),
            new BookPageInfo
            (
                "With every wave and storm, the",
                "people endured. Pirates hid in",
                "coveted coves; hurricanes could",
                "not break their spirit. The sound",
                "of the steel drum rose above",
                "the cane fields. Rebels and rulers",
                "came and went."
            ),
            new BookPageInfo
            (
                "In 1795, Fedon’s rebellion burned",
                "bright, but freedom would wait",
                "almost two centuries. In 1974,",
                "Grenada’s flag rose over a free",
                "people. In 1979, a new revolution",
                "promised more, but turmoil",
                "followed as armies landed on the sand."
            ),
            new BookPageInfo
            (
                "Now, Grenada is the Isle of Spice,",
                "where nutmeg and cocoa sail the",
                "world. The music, the laughter, the",
                "resilience of its people—these are",
                "the treasures you now find within",
                "this chest, the heart of the island’s",
                "story. Let the spirit of Grenada",
                "carry you forward."
            ),
            new BookPageInfo
            (
                "‘Carriacou and Petite Martinique,",
                "sisters in the sun, all are bound",
                "together under one flag. Let the",
                "drums sound, the festivals blaze,",
                "and the nutmeg scent lead you home.",
                "",
                "- The Wandering Scholar",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public GrenadaLoreBook() : base(false)
        {
            Hue = 1194; // Nutmeg-gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Spirit of Grenada");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Spirit of Grenada");
        }

        public GrenadaLoreBook(Serial serial) : base(serial) { }

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
