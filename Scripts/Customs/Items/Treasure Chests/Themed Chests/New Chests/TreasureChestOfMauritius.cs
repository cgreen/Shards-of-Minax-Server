using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMauritius : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMauritius()
        {
            Name = "Treasure Chest of Mauritius";
            Hue = 1266; // A vivid turquoise/sea blue

            // Add themed loot!
            AddItem(CreateColoredItem<ArtifactLargeVase>("Porcelain Vase of Port Louis", 1153), 0.18);
            AddItem(CreateColoredItem<BasketOfGreenTeaMug>("Island Spice Tea Mug", 2125), 0.16);
            AddItem(CreateColoredItem<RandomFancyCoin>("Colonial Gold Escudo", 2213), 0.17);
            AddItem(CreateDodoEgg(), 0.09);
            AddItem(CreateShipModel(), 0.08);
            AddItem(CreateColoredItem<CheeseWheel>("Dutch Governor's Cheese", 1107), 0.15);
            AddItem(CreateNamedItem<Pear>("Sugar Estate Pear", 1287), 0.20);
            AddItem(CreateColoredItem<CrabBushel>("Mauritian Blue Crab Bushel", 1365), 0.13);
            AddItem(CreateColoredItem<ExoticPlum>("Plum of the Slave Coast", 1659), 0.13);
            AddItem(CreateNamedItem<FlowerGarland>("Wreath of Ebony and Flame", 43), 0.16);
            AddItem(CreateMap(), 0.12);
            AddItem(CreateColoredItem<Diamond>("Ruby of Morne Brabant", 1835), 0.12);
            AddItem(new ChroniclesOfMauritius(), 1.0);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateBoots(), 0.17);
            AddItem(CreateHat(), 0.15);
            AddItem(CreateRobe(), 0.16);
            AddItem(CreateSpecialConsumable(), 0.13);

            // Add gold, just for fun
            AddItem(new Gold(Utility.Random(2000, 7000)), 0.21);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDodoEgg()
        {
            EggCaseArtifact egg = new EggCaseArtifact();
            egg.Name = "Extinct Dodo Egg";
            egg.Hue = 2101;
            return egg;
        }

        private Item CreateShipModel()
        {
            AncientShipModelOfTheHMSCape ship = new AncientShipModelOfTheHMSCape();
            ship.Name = "Model of the HMS Mauritius";
            ship.Hue = 1109;
            return ship;
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
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Mascarene Isles";
            map.Bounds = new Rectangle2D(4000, 1400, 400, 400);
            map.NewPin = new Point2D(4100, 1520);
            map.Protected = true;
            return map;
        }

        // EQUIPMENT SECTION (all with unique stats and flavors)

        private Item CreateWeapon()
        {
            // Pirate’s Cutlass with ocean/volcanic hues and explorer’s mods
            Cutlass weapon = new Cutlass();
            weapon.Name = "La Buse's Pirate Cutlass";
            weapon.Hue = 1153; // Deep blue
            weapon.WeaponAttributes.HitHarm = 25;
            weapon.WeaponAttributes.HitLeechStam = 20;
            weapon.WeaponAttributes.HitLowerAttack = 18;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.MinDamage = 25;
            weapon.MaxDamage = 65;
            weapon.Attributes.AttackChance = 12;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.NightSight = 1;
            weapon.Attributes.WeaponSpeed = 10;
            weapon.Attributes.BonusStr = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Volcanic Plate Armor, themed after the Black River Gorges
            PlateChest armor = new PlateChest();
            armor.Name = "Plate of the Black River Gorges";
            armor.Hue = 1109; // Volcanic black
            armor.BaseArmorRating = Utility.Random(38, 70);
            armor.Attributes.BonusHits = 12;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.RegenHits = 2;
            armor.Attributes.DefendChance = 15;
            armor.Attributes.BonusDex = 7;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBoots()
        {
            // Dodo-Feather Sandals for speed, luck, and sneaky skills!
            Sandals boots = new Sandals();
            boots.Name = "Sandals of the Lost Dodo";
            boots.Hue = 2101; // Dodo-grey
            boots.Attributes.Luck = 40;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.NightSight = 1;
            boots.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateHat()
        {
            // Governor's Colonial Tricorne with magic and trade skills
            TricorneHat hat = new TricorneHat();
            hat.Name = "Governor's Tricorne of Port Louis";
            hat.Hue = 43;
            hat.Attributes.BonusInt = 8;
            hat.Attributes.RegenMana = 3;
            hat.Attributes.CastRecovery = 1;
            hat.Attributes.LowerRegCost = 14;
            hat.SkillBonuses.SetValues(0, SkillName.ItemID, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateRobe()
        {
            // Robe of the Sugar Barons (energy, charisma, resistances)
            Robe robe = new Robe();
            robe.Name = "Robe of the Sugar Barons";
            robe.Hue = 2213; // Gold
            robe.Attributes.BonusMana = 15;
            robe.Attributes.BonusHits = 8;
            robe.Attributes.RegenMana = 4;
            robe.Resistances.Energy = 12;
            robe.Resistances.Cold = 8;
            robe.Attributes.Luck = 22;
            robe.SkillBonuses.SetValues(0, SkillName.Cartography, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Begging, 7.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateSpecialConsumable()
        {
            // "Infusion of the Ebony Forest" (super heal potion with unique color and name)
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Infusion of the Ebony Forest";
            potion.Hue = 1287;
            return potion;
        }

        // ==== BOOK OF LORE ====

        public class ChroniclesOfMauritius : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Mauritius: The Jewel of the Indian Ocean", "Captain Henri De La Mer",
                new BookPageInfo
                (
                    "Let it be written,",
                    "in the year of the",
                    "Great Winds, that I",
                    "— Captain Henri De La",
                    "Mer — set foot upon",
                    "the fabled shores of",
                    "Mauritius. Her peaks,",
                    "cloaked in mist and"
                ),
                new BookPageInfo
                (
                    "lush forests, spoke",
                    "of old secrets. Here,",
                    "the Portuguese came,",
                    "named her 'Ilha do",
                    "Cerne'. The Dutch,",
                    "with greed and axes,",
                    "felled ebony trees,",
                    "left dodo bones behind."
                ),
                new BookPageInfo
                (
                    "Then came the French.",
                    "They built Port Louis,",
                    "planted fields of cane,",
                    "named the isle after",
                    "their prince. Corsairs",
                    "and planters, slaves and",
                    "dreamers—fortune and",
                    "fate danced on her reefs."
                ),
                new BookPageInfo
                (
                    "The British followed,",
                    "bringing new order,",
                    "but the spirit of the",
                    "island—her melting pot",
                    "of souls—remained her",
                    "own. Volcanoes slumber",
                    "beneath emerald hills.",
                    "Dodos sleep in legend."
                ),
                new BookPageInfo
                (
                    "Yet, as I write,",
                    "sugar ships fill the",
                    "harbor, and children",
                    "sing in Creole. The",
                    "winds carry the scent",
                    "of spice and salt. The",
                    "jewel of the Indian",
                    "Ocean endures still."
                ),
                new BookPageInfo
                (
                    "O seeker, know this:",
                    "Within these treasures",
                    "lies the heart of",
                    "Mauritius—her music,",
                    "her struggle, her hope.",
                    "May you carry her",
                    "story far, and may",
                    "the island's blessing"
                ),
                new BookPageInfo
                (
                    "ride upon your",
                    "shoulders, wherever",
                    "the waves may bear",
                    "you.",
                    "",
                    "- Captain Henri De La Mer",
                    "",
                    "",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfMauritius() : base(false)
            {
                Hue = 1266; // Sea blue
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Mauritius");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Mauritius");
            }

            public ChroniclesOfMauritius(Serial serial) : base(serial) { }

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

        public TreasureChestOfMauritius(Serial serial) : base(serial)
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
}
