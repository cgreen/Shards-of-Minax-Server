using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSovietUnion : MetalGoldenChest
    {
        [Constructable]
        public TreasureChestOfTheSovietUnion()
        {
            Name = "Treasure Chest of the Soviet Union";
            Hue = 33; // Classic red

            // Deco & Relics
            AddItem(CreateNamedItem<ArtifactVase>("Porcelain Lenin Bust", 38), 0.18);
            AddItem(CreateNamedItem<BottleArtifact>("Vodka Bottle 'Red October'", 1157), 0.15);
            AddItem(CreateNamedItem<Painting1WestArtifact>("Propaganda Poster: For the Motherland!", 33), 0.10);
            AddItem(CreateNamedItem<GoldBricks>("Gilded Hammer and Sickle Relic"), 0.09);
            AddItem(CreateNamedItem<TwentyfiveShield>("Shield of the Red Army", 1645), 0.16);
            AddItem(CreateNamedItem<SnowPileDeco>("Siberian Snow Globe"), 0.14);

            // Consumables
            AddItem(CreateColoredItem<BottledPlague>("Vodka of Endurance", 33), 0.20);
            AddItem(CreateColoredItem<BentoBox>("Ration Box of the Commissar", 33), 0.15);
            AddItem(CreateColoredItem<BreadLoaf>("Stalingrad Black Bread", 1109), 0.14);
            AddItem(CreateColoredItem<CheeseWedge>("Soviet Hard Cheese", 1324), 0.13);

            // Decorative Books & Lore
            AddItem(new RedBookOfRevolution(), 1.0);
            AddItem(CreateMap(), 0.08);

            // Unique Gear
            AddItem(CreateNamedItem<BodySash>("Hero of the Worker Sash", 33), 0.19);
            AddItem(CreateColoredItem<Cloak>("Cloak of the Commissar", 38), 0.18);
            AddItem(CreateNamedItem<Boots>("Steel-Toed Labor Boots"), 0.15);

            // Unique Powerful Equipment
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateHeadgear(), 0.18);

            // Rare collectibles
            AddItem(CreateColoredItem<Gold>("Soviet Ruble Bar", 38), 0.15);
            AddItem(CreateNamedItem<SimpleNote>("Encrypted Spy Letter"), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Soviet Black Site Map";
            map.Bounds = new Rectangle2D(1600, 2100, 300, 250);
            map.NewPin = new Point2D(1705, 2188);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new WarMace(), new BattleAxe(), new Scimitar(), new Bardiche()
            );
            weapon.Name = "Commissar’s Warhammer";
            weapon.Hue = 33;
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.WeaponAttributes.HitLeechStam = 20;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.WeaponAttributes.SelfRepair = 6;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateLegs(), new PlateArms(), new PlateGloves()
            );
            armor.Name = "Worker’s Steel Plating";
            armor.Hue = 1157; // Steel grey
            armor.BaseArmorRating = Utility.Random(35, 75);
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.Attributes.BonusHits = 15;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateHeadgear()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Soviet Officer’s Cap";
            hat.Hue = 33;
            hat.Attributes.Luck = 35;
            hat.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        public TreasureChestOfTheSovietUnion(Serial serial) : base(serial) { }

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

    public class RedBookOfRevolution : RedBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Red Book of Revolution", "Commissar Malenkov",
            new BookPageInfo
            (
                "Comrade, if you read this,",
                "you now hold a relic of",
                "glory and sorrow. In the",
                "Soviet days, the people",
                "rose from the ashes of the",
                "old world. Iron rails and",
                "factories stitched the",
                "Motherland together."
            ),
            new BookPageInfo
            (
                "We toiled and triumphed.",
                "In the name of progress,",
                "our workers lifted steel",
                "as easily as hope.",
                "Inventors and soldiers,",
                "scientists and dreamers,",
                "each became a hero of",
                "the Union."
            ),
            new BookPageInfo
            (
                "Some say strange powers",
                "grew in the snowy wastes.",
                "Experiments whispered",
                "in secret labs beneath",
                "Moscow. Some succeeded.",
                "Some escaped.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Our Red Army marched,",
                "unbreakable. Legends tell",
                "of the Iron Commissar,",
                "whose hammer shattered",
                "enemies and walls alike.",
                "Of the spy who vanished",
                "with a smile and a map.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Now the Union is dust,",
                "but its treasures remain.",
                "Honor the workers,",
                "honor the dream. Take",
                "these relics, but beware—",
                "for some secrets are best",
                "left buried in Siberian",
                "ice."
            ),
            new BookPageInfo
            (
                "If you carry this chest,",
                "carry also the promise:",
                "That one day, a new dawn",
                "will rise over these cold,",
                "endless lands.",
                "",
                "",
                "",
                "- Malenkov"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public RedBookOfRevolution() : base(false)
        {
            Hue = 33; // Soviet red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Red Book of Revolution");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Red Book of Revolution");
        }

        public RedBookOfRevolution(Serial serial) : base(serial) { }

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
