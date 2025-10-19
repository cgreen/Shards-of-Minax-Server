using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfParaguay : WoodenChest
    {
        [Constructable]
        public TreasureChestOfParaguay()
        {
            Name = "Treasure Chest of the Guarani";
            Hue = 2123; // Deep jungle green

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Urn of Lake Ypacaraí", 1345), 0.15);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Spirit Crane of the Pantanal", 1436), 0.12);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Ceremonial Brazier of Asunción", 2417), 0.11);
            AddItem(CreateDecorativeItem<GoldBricks>("Jesuit Gold Ingots", 1281), 0.18);
            AddItem(CreateDecorativeItem<DecorativeShield7>("Shield of the Triple Alliance", 1296), 0.13);
            AddItem(CreateColoredItem<RandomFancyCoin>("Lost Guarani Coin", 1161), 0.16);
            AddItem(CreateColoredItem<GreaterHealPotion>("Yerba Mate Infusion", 1146), 0.20);
            AddItem(CreateColoredItem<RandomFancyPlant>("Lapacho Blossom", 1376), 0.12);
            AddItem(CreateColoredItem<RandomFancyStatue>("Jaguar Idol", 1109), 0.09);
            AddItem(CreateColoredItem<RandomFancyInstrument>("Harp of Paraguay", 2105), 0.13);
            AddItem(CreateDecorativeItem<Painting2WestArtifact>("Sunset over the Chaco", 1357), 0.15);

            // Consumables
            AddItem(CreateColoredItem<GreenTea>("Tereré Gourd", 1810), 0.23);
            AddItem(CreateColoredItem<Banana>("Paraguayan Banana", 53), 0.14);
            AddItem(CreateColoredItem<PeachCobbler>("Dulce de Guayaba", 3005), 0.08);

            // Unique Equipment
            AddItem(CreateArmor(), 0.25);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateLongPants(), 0.22);
            AddItem(CreateFeatheredHat(), 0.20);
            AddItem(CreateBoots(), 0.19);

            // Lore book
            AddItem(new ChroniclesOfParaguay(), 1.0);

            // Some gold
            AddItem(new Gold(Utility.Random(500, 3500)), 0.17);
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

        // Unique Gear

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of Mariscal López";
            chest.Hue = 1171;
            chest.BaseArmorRating = 66;
            chest.Attributes.Luck = 65;
            chest.Attributes.BonusHits = 15;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.RegenHits = 5;
            chest.ArmorAttributes.LowerStatReq = 25;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            chest.SkillBonuses.SetValues(1, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Blade of the Guarani Warriors";
            weapon.Hue = 1916;
            weapon.MinDamage = 34;
            weapon.MaxDamage = 68;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusDex = 7;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Chaco Explorer's Trousers";
            pants.Hue = 1420;
            pants.Attributes.Luck = 25;
            pants.Attributes.BonusStam = 8;
            pants.SkillBonuses.SetValues(0, SkillName.Camping, 18.0);
            pants.SkillBonuses.SetValues(1, SkillName.Tracking, 10.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateFeatheredHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Mbopi Feathered Headdress";
            hat.Hue = 1272;
            hat.Attributes.BonusInt = 8;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Paraná Voyager";
            boots.Hue = 1175;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.RegenStam = 4;
            boots.SkillBonuses.SetValues(0, SkillName.Cartography, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Fishing, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        // LORE BOOK

        public class ChroniclesOfParaguay : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Paraguay: Land of the Guarani", "Hermano Antonio Ruiz",
                new BookPageInfo
                (
                    "In the heart of South America",
                    "lies Paraguay, cradled by rivers",
                    "and hidden by forests deep.",
                    "Long before the conquistadors",
                    "the Guarani people spoke",
                    "with the wind and the jaguar,",
                    "singing to the land."
                ),
                new BookPageInfo
                (
                    "The Jesuit missions rose and",
                    "fell; stone churches echo with",
                    "forgotten hymns. The War of",
                    "the Triple Alliance scorched",
                    "the earth, leaving only ashes",
                    "and legends of lost gold."
                ),
                new BookPageInfo
                (
                    "Yerba mate flows like the",
                    "Paraná, carrying stories of",
                    "friendship and resilience.",
                    "The music of the harp, the",
                    "bloom of the lapacho, the",
                    "calls of birds in the Chaco:",
                    "these are Paraguay's song."
                ),
                new BookPageInfo
                (
                    "Seekers who unlock this chest",
                    "discover more than riches:",
                    "memories of a land where",
                    "jaguars prowl, the spirits walk,",
                    "and ancient gold slumbers",
                    "beneath red earth."
                ),
                new BookPageInfo
                (
                    "Do not forget: the true",
                    "treasure of Paraguay is the",
                    "strength of its people, and the",
                    "echoes of Guarani laughter in",
                    "the evening rain."
                ),
                new BookPageInfo
                (
                    "— Hermano Antonio Ruiz,",
                    "Wanderer of the Río Paraguay"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfParaguay() : base(false)
            {
                Hue = 1109; // Lush green
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Paraguay: Land of the Guarani");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Paraguay: Land of the Guarani");
            }

            public ChroniclesOfParaguay(Serial serial) : base(serial) { }

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

        public TreasureChestOfParaguay(Serial serial) : base(serial) { }

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
