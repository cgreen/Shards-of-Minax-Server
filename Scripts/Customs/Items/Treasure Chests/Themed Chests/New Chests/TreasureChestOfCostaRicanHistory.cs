using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCostaRicanHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCostaRicanHistory()
        {
            Name = "Treasure Chest of Costa Rican History";
            Hue = 1407; // Lush green, representing the rainforest

            // Add unique items to the chest
            AddItem(new JadeFrogIdol(), 0.15);
            AddItem(CreateNamedItem<GreenTea>("Sacred Oxcart Brew"), 0.10);
            AddItem(CreateColoredItem<Sculpture1Artifact>("Stone Sphere of Diquís", 2112), 0.20);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateCustomHat(), 0.16);
            AddItem(CreateCustomSandals(), 0.17);
            AddItem(CreateCustomArmor(), 0.18);
            AddItem(CreateCustomWeapon(), 0.18);
            AddItem(CreateColoredItem<FlowersArtifact>("Bouquet of Guaria Morada", 1348), 0.15);
            AddItem(CreateCustomCloak(), 0.13);
            AddItem(CreateGoldItem("Ancient Costa Rican Colón"), 0.20);
            AddItem(new BookOfCostaRicanLore(), 1.0);
            AddItem(CreateCustomPants(), 0.14);
            AddItem(CreateCustomFood(), 0.12);
            AddItem(CreateDecorativeOxcart(), 0.11);
            AddItem(CreateColoredItem<TreasureLevel2>("Golden Quetzal Feather", 1348), 0.08);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // --- Unique and Custom Items ---
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
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
            map.Name = "Map to the Ruins of Guayabo";
            map.Bounds = new Rectangle2D(5200, 1400, 350, 300);
            map.NewPin = new Point2D(5350, 1550);
            map.Protected = true;
            return map;
        }

        private Item CreateCustomHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Traveler’s Sombrero de Palma";
            hat.Hue = 2418; // natural straw color
            hat.Attributes.Luck = 15;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Camping, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateCustomSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Rainforest Path";
            sandals.Hue = 1405;
            sandals.Attributes.BonusDex = 10;
            sandals.Attributes.LowerManaCost = 5;
            sandals.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateCustomArmor()
        {
            LeatherChest chest = new LeatherChest();
            chest.Name = "Armor of the Bribri Shaman";
            chest.Hue = 1326;
            chest.Attributes.BonusInt = 10;
            chest.Attributes.LowerRegCost = 10;
            chest.Attributes.BonusHits = 15;
            chest.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 12.0);
            chest.ColdBonus = 6;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateCustomWeapon()
        {
            QuarterStaff staff = new QuarterStaff();
            staff.Name = "Raincaller’s Ancient Staff";
            staff.Hue = 2051;
            staff.WeaponAttributes.HitLightning = 30;
            staff.Attributes.SpellChanneling = 1;
            staff.Attributes.CastSpeed = 2;
            staff.Attributes.CastRecovery = 1;
            staff.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
            staff.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        private Item CreateCustomCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Eternal Spring";
            cloak.Hue = 1167; // vibrant green
            cloak.Attributes.RegenHits = 3;
            cloak.Attributes.RegenStam = 2;
            cloak.SkillBonuses.SetValues(0, SkillName.Alchemy, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.TasteID, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateCustomPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Explorer’s Cargo Trousers";
            pants.Hue = 1109;
            pants.Attributes.BonusStam = 10;
            pants.Attributes.Luck = 15;
            pants.SkillBonuses.SetValues(0, SkillName.Cartography, 12.0);
            pants.SkillBonuses.SetValues(1, SkillName.Forensics, 8.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateCustomFood()
        {
            Cake cake = new Cake();
            cake.Name = "Traditional Casado Feast";
            cake.Hue = 1161; // colorful plate
            cake.Stackable = false;
            return cake;
        }

        private Item CreateDecorativeOxcart()
        {
            Sculpture2Artifact oxcart = new Sculpture2Artifact();
            oxcart.Name = "Miniature Painted Oxcart";
            oxcart.Hue = 1921; // bold, painted color
            return oxcart;
        }

        // --- Decorative Artifact ---
        public class JadeFrogIdol : ZombieHand
        {
            [Constructable]
            public JadeFrogIdol()
            {
                Name = "Jade Frog Idol of Costa Rica";
                Hue = 1426;
                Weight = 2.0;
            }
            public JadeFrogIdol(Serial serial) : base(serial) { }
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

        // --- Lore Book ---
        public class BookOfCostaRicanLore : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "The Tapestry of Costa Rica", "El Cronista de Tiquicia",
                new BookPageInfo
                (
                    "Before the ships came,",
                    "this land was forest and",
                    "river, stone and song. The",
                    "Bribri, Chorotega, and Boruca",
                    "walked the valleys, shaped",
                    "jade into totems, and raised",
                    "mystic spheres for unknown",
                    "purposes."
                ),
                new BookPageInfo
                (
                    "Colón, a seeker of",
                    "passages, glimpsed these shores.",
                    "Yet it was not gold nor",
                    "conquest, but peace and",
                    "fertility that Costa Rica",
                    "embraced. No viceroy here,",
                    "only governors and farmers,",
                    "carving new life from jungle."
                ),
                new BookPageInfo
                (
                    "In 1821, the chains of",
                    "empire broke. Independence",
                    "rang out—not with war, but",
                    "with the quiet courage of",
                    "self-determination. No standing",
                    "army, only the spirit of",
                    "democracy, learning, and the",
                    "‘pura vida’ way."
                ),
                new BookPageInfo
                (
                    "Banana boats and coffee",
                    "trains carried Costa Rica’s",
                    "bounty to distant ports, but",
                    "her true riches were the",
                    "orchids, quetzals, and cloud",
                    "forests—gifts guarded fiercely",
                    "for generations yet unborn."
                ),
                new BookPageInfo
                (
                    "Now, from volcano to",
                    "beach, from rain-soaked",
                    "jungle to bustling city, this",
                    "land stands as a sanctuary.",
                    "Here, history is not just",
                    "remembered—it is lived.",
                    "",
                    "— El Cronista"
                )
            );
            public override BookContent DefaultContent => Content;

            [Constructable]
            public BookOfCostaRicanLore() : base(false)
            {
                Hue = 1165; // Deep blue, Costa Rican flag color
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("The Tapestry of Costa Rica");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "The Tapestry of Costa Rica");
            }

            public BookOfCostaRicanLore(Serial serial) : base(serial) { }

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

        public TreasureChestOfCostaRicanHistory(Serial serial) : base(serial) { }
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
}
