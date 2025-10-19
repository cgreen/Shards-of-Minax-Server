using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAndorra : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAndorra()
        {
            Name = "Treasure Chest of Andorra";
            Hue = 1779; // A rich blue, reminiscent of Andorra's flag

            // Add items to the chest
            AddItem(CreateDecorative<ArtifactVase>("Pyrenean Alpine Vase", 2075), 0.15);
            AddItem(CreateDecorative<Sculpture1Artifact>("Mountain Sculpture of Coma Pedrosa", 1151), 0.12);
            AddItem(CreateDecorative<Urn1Artifact>("Urn of Old Les Escaldes", 2407), 0.14);
            AddItem(CreateNamedConsumable<GreenTea>("Elixir of Pyrenean Vitality", 1418), 0.18);
            AddItem(CreateNamedConsumable<BentoBox>("Smuggler’s Secret Rations", 2619), 0.10);
            AddItem(CreateNamedConsumable<RandomFruitBasket>("Wild Andorran Fruit Basket", 2001), 0.20);
            AddItem(CreateDecorative<SilverSteedZooStatuette>("Statuette of the Silver Steed", 2308), 0.12);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Co-Princes", 0), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Valley Maiden", 2071), 0.13);
            AddItem(CreateNamedEquipment<LongPants>("Alpine Traveler’s Pants"), 0.18);
            AddItem(CreateNamedEquipment<WideBrimHat>("Smuggler’s Wide-Brim Hat"), 0.17);
            AddItem(CreateNamedEquipment<PlateChest>("Armor of the Mountain Guard"), 0.16);
            AddItem(CreateNamedEquipment<QuarterStaff>("Staff of the Co-Princes"), 0.17);
            AddItem(CreateNamedEquipment<Katana>("Sword of La Margineda"), 0.15);
            AddItem(CreateDecorative<AncientDrum>("Drum of the Pyrenean Festival", 1153), 0.08);
            AddItem(CreateGoldItem("Andorran Diner"), 0.12);
            AddItem(CreateMap(), 0.04);
            AddItem(new ChroniclesOfAndorra(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 4000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Decorative item with custom name and hue
        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumable food or drink with custom name and hue
        private Item CreateNamedConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Named unique jewelry
        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        // Equipment with powerful mods, themed for Andorra
        private Item CreateNamedEquipment<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;

            if (item is BaseArmor armor)
            {
                armor.Hue = Utility.RandomMinMax(1150, 2075);
                armor.BaseArmorRating = Utility.Random(38, 62);
                armor.Attributes.BonusHits = 25;
                armor.Attributes.Luck = 50;
                armor.ArmorAttributes.SelfRepair = 7;
                armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
                armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
                XmlAttach.AttachTo(armor, new XmlLevelItem());
                return armor;
            }
            else if (item is BaseClothing clothing)
            {
                clothing.Hue = Utility.RandomMinMax(1150, 2075);
                clothing.Attributes.Luck = 40;
                clothing.Attributes.BonusDex = 12;
                clothing.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
                clothing.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
                XmlAttach.AttachTo(clothing, new XmlLevelItem());
                return clothing;
            }
            else if (item is BaseWeapon weapon)
            {
                weapon.Hue = Utility.RandomMinMax(1150, 2075);
                weapon.MinDamage = Utility.Random(25, 45);
                weapon.MaxDamage = Utility.Random(50, 90);
                weapon.WeaponAttributes.HitLeechHits = 15;
                weapon.WeaponAttributes.HitHarm = 15;
                weapon.WeaponAttributes.SelfRepair = 5;
                weapon.Attributes.BonusStr = 12;
                weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
                weapon.SkillBonuses.SetValues(1, SkillName.Fencing, 10.0);
                XmlAttach.AttachTo(weapon, new XmlLevelItem());
                return weapon;
            }
            else
            {
                return item;
            }
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Valleys of Andorra";
            map.Bounds = new Rectangle2D(1000, 1100, 300, 300);
            map.NewPin = new Point2D(1150, 1300);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAndorra(Serial serial) : base(serial)
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

    public class ChroniclesOfAndorra : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Chronicles of Andorra", "Marc de les Valls",
            new BookPageInfo
            (
                "In the hidden heart of the",
                "Pyrenees lies a land so",
                "ancient that its stones",
                "whisper the tales of",
                "kings and smugglers,",
                "shepherds and saints.",
                "This is Andorra, forged",
                "by snow and stars."
            ),
            new BookPageInfo
            (
                "Long before empires,",
                "Andorrans tended flocks,",
                "hid in mountain passes,",
                "and survived by wit and",
                "will. Legends say Charlemagne",
                "granted our valleys freedom,",
                "rewarding valor against",
                "the Moors."
            ),
            new BookPageInfo
            (
                "Two mighty co-princes,",
                "the Bishop of Urgell and",
                "the Count of Foix, swore",
                "to shield Andorra's peace.",
                "From that pact, the world’s",
                "oldest parliament was born—",
                "the Consell General.",
                ""
            ),
            new BookPageInfo
            (
                "Through wars, plagues, and",
                "the ambitions of kings,",
                "we endured. Smugglers traced",
                "secret paths through snow,",
                "shepherds brought wool and",
                "song to silent valleys.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Andorra thrived on the edge,",
                "guarded by peaks and legend.",
                "A refuge for the persecuted,",
                "a crossroad for the daring.",
                "Our banners flew beneath",
                "the snow and the stars,",
                "answering to no king,",
                "save those chosen by law."
            ),
            new BookPageInfo
            (
                "Now, travelers come from far,",
                "seeking fortune in frost,",
                "commerce in calm. Yet in",
                "the quiet of night, if you",
                "listen, you may hear the",
                "songs of shepherds and the",
                "echoes of ancient pacts.",
                ""
            ),
            new BookPageInfo
            (
                "Let these chronicles remind",
                "the finder: Andorra’s treasure",
                "is not only in gold or gems,",
                "but in her freedom, her",
                "spirit, and the courage of",
                "those who call her home.",
                "",
                "- Marc de les Valls"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfAndorra() : base(false)
        {
            Hue = 1779; // Andorran blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Chronicles of Andorra");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Chronicles of Andorra");
        }

        public ChroniclesOfAndorra(Serial serial) : base(serial) { }

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
