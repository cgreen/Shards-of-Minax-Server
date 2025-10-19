using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAustralia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAustralia()
        {
            Name = "Treasure Chest of Australia";
            Hue = 2425; // A gold-red outback hue

            // Add themed loot
            AddItem(new DreamtimeOpal(), 0.12);
            AddItem(CreateColoredItem<GoldBrick>("Eureka Gold Nugget", 1175), 0.22);
            AddItem(CreateColoredItem<Boomerang>("Woomera's Flight", 2513), 0.15);
            AddItem(CreateNamedItem<FeatheredHat>("Hat of the Bush Ranger"), 0.17);
            AddItem(CreateDecorativeItem<Lute>("Didgeridoo of the Ancients"), 0.15);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateConsumable("Vegemite Sandwich", 2419), 0.10);
            AddItem(CreateNamedItem<GoldEarrings>("Opal-set Earrings"), 0.12);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateBushmanCloak(), 0.16);
            AddItem(CreateExplorerBoots(), 0.15);
            AddItem(CreateUniqueShield(), 0.15);
            AddItem(CreateDecorativeItem<ReptalonZooStatuette>("Kangaroo Statuette"), 0.20);
            AddItem(new Gold(Utility.Random(1, 7000)), 0.16);
            AddItem(CreateDecorativeItem<PetRock>("Miniature Coral Reef Model"), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Unique Artifacts & Decorative
        private Item CreateDecorativeItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = Utility.RandomMinMax(1150, 2515);
            return item;
        }

        // Unique Consumable
        private Item CreateConsumable(string name, int hue)
        {
            Cookies consumable = new Cookies(); // Fun edible type
            consumable.Name = name;
            consumable.Hue = hue;
            consumable.Stackable = true;
            consumable.Amount = Utility.RandomMinMax(1, 4);
            return consumable;
        }

        // Unique Gold Nugget
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

        // Unique Weapon: Gold Rush Pickaxe of Fortune
        private Item CreateWeapon()
        {
            Pickaxe axe = new Pickaxe();
            axe.Name = "Gold Rush Pickaxe of Fortune";
            axe.Hue = 1175;
            axe.MinDamage = 35;
            axe.MaxDamage = 55;
            axe.Attributes.Luck = 300;
            axe.Attributes.WeaponSpeed = 35;
            axe.WeaponAttributes.HitLightning = 25;
            axe.WeaponAttributes.UseBestSkill = 1;
            axe.SkillBonuses.SetValues(0, SkillName.Mining, 25.0);
            axe.Attributes.BonusStr = 10;
            axe.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(axe, new XmlLevelItem());
            return axe;
        }

        // Unique Armor: Bushranger's Duster Coat
        private Item CreateBushmanCloak()
        {
            Cloak coat = new Cloak();
            coat.Name = "Bushranger's Duster Coat";
            coat.Hue = 2425;
            coat.Attributes.Luck = 40;
            coat.Attributes.BonusDex = 12;
            coat.SkillBonuses.SetValues(0, SkillName.Hiding, 18.0);
            coat.SkillBonuses.SetValues(1, SkillName.Stealth, 15.0);
            coat.ClothingAttributes.MageArmor = 1;
            XmlAttach.AttachTo(coat, new XmlLevelItem());
            return coat;
        }

        // Unique Armor: Swagman's Explorer Boots
        private Item CreateExplorerBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Swagman's Explorer Boots";
            boots.Hue = 1875;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.LowerManaCost = 7;
            boots.SkillBonuses.SetValues(0, SkillName.Camping, 20.0);
            boots.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0);
            boots.Attributes.NightSight = 1;
            boots.ClothingAttributes.MageArmor = 1;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        // Unique Shield: Barrier of the Dreamtime Serpent
        private Item CreateUniqueShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Barrier of the Dreamtime Serpent";
            shield.Hue = 2067;
            shield.ArmorAttributes.SelfRepair = 8;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.SpellChanneling = 1;
            shield.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            shield.Attributes.RegenMana = 3;
            shield.ColdBonus = 10;
            shield.EnergyBonus = 10;
            shield.FireBonus = 10;
            shield.PhysicalBonus = 15;
            shield.PoisonBonus = 10;
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Unique Armor: Gold Rush Plate Armor
        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Gold Rush Plate Armor";
            chest.Hue = 1175;
            chest.BaseArmorRating = Utility.Random(40, 70);
            chest.Attributes.Luck = 200;
            chest.Attributes.BonusHits = 15;
            chest.Attributes.RegenHits = 3;
            chest.SkillBonuses.SetValues(0, SkillName.Mining, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 7.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Unique Hat: Akubra
        private Item CreateNamedItem<T>(string name, int hue = 1150) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (item is BaseClothing clothing)
                clothing.Hue = hue;
            return item;
        }

        // Unique Lore Book
        private Item CreateLoreBook()
        {
            return new ChronicleOfAustralia();
        }

        // Custom Dreamtime Opal
        private class DreamtimeOpal : Ruby
        {
            [Constructable]
            public DreamtimeOpal()
            {
                Name = "Dreamtime Opal";
                Hue = 2067; // iridescent
                Weight = 1.0;
            }

            public DreamtimeOpal(Serial serial) : base(serial) { }

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

        // Custom Map
        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Explorer's Map of Terra Australis";
            map.Bounds = new Rectangle2D(2000, 4000, 1200, 900); // Outback-ish
            map.NewPin = new Point2D(2600, 4450);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAustralia(Serial serial) : base(serial) { }

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

    public class ChronicleOfAustralia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Australia", "Anonymous Chronicler",
            new BookPageInfo
            (
                "Long before memory,",
                "the Rainbow Serpent",
                "carved rivers and hills,",
                "while spirits shaped",
                "the Dreamtime. Here",
                "land and sky danced,",
                "and the first people",
                "sang their songlines."
            ),
            new BookPageInfo
            (
                "Through red desert and",
                "rainforest, tribes",
                "painted tales on stone,",
                "echoes of kangaroo",
                "and emu, croc and",
                "platypus. In cool south,",
                "bark canoes drifted",
                "over morning mists."
            ),
            new BookPageInfo
            (
                "Then came sails on",
                "strange horizons:",
                "Macassan praus, Dutch",
                "ghosts, and finally",
                "Captain Cook. Colonists",
                "claimed what was not",
                "theirs; gold fever burned;",
                "and bushrangers roamed."
            ),
            new BookPageInfo
            (
                "From Botany Bay to",
                "Ballarat, cities grew,",
                "and railroads stitched",
                "a continent. Camels",
                "crossed the Nullarbor,",
                "and prospectors dug",
                "for dreamstone, opal,",
                "sapphire and hope."
            ),
            new BookPageInfo
            (
                "Yet beneath the cities,",
                "the songlines endure.",
                "Dreamtime spirits",
                "slumber, the Serpent",
                "winds on, and every",
                "sunset blazes with",
                "ancient light. This",
                "land remembers."
            ),
            new BookPageInfo
            (
                "Here, the lost and the",
                "found, the old and the",
                "new, forever meet.",
                "Some treasures glitter;",
                "some remain secret,",
                "waiting for the brave",
                "or the wise to listen.",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfAustralia() : base(false)
        {
            Hue = 2425; // Outback red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Australia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Australia");
        }

        public ChronicleOfAustralia(Serial serial) : base(serial) { }

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
