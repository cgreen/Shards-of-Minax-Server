using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSweden : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSweden()
        {
            Name = "Treasure Chest of Swedish Kings";
            Hue = 1154; // Blue-gold, Sweden's colors

            // Add themed loot
            AddItem(CreateDecor("Viking Ship Model", 1154), 0.2);
            AddItem(CreateDecor("Miniature Dala Horse", 1166), 0.15);
            AddItem(CreateDecor("Runestone of Uppsala", 1109), 0.12);
            AddItem(CreateDecor("IKEA Flatpack Furniture Kit", 1175), 0.07);
            AddItem(CreateDecor("Blue and Yellow Banner", 1154), 0.15);
            AddItem(CreateDecor("Royal Crown of Gustav Vasa", 1175), 0.08);
            AddItem(CreateDecor("ABBA Gold Record", 2213), 0.05);
            AddItem(CreateDecor("Nobel Prize Chocolate Medal", 1160), 0.13);
            AddItem(CreateDecor("Lute of the Skald", 1118), 0.12);

            // Unique food and drink
            AddItem(CreateFood("Jar of Lingonberry Jam", 34), 0.16);
            AddItem(CreateFood("Plate of Swedish Meatballs", 2414), 0.12);
            AddItem(CreateFood("Gravlax Platter", 2125), 0.10);
            AddItem(CreateFood("Cinnamon Bun (Kanelbulle)", 2101), 0.12);

            // Epic gear
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateShield(), 0.19);
            AddItem(CreateRoyalCloak(), 0.18);
            AddItem(CreateNobelRobe(), 0.12);
            AddItem(CreateABBAItem(), 0.11);

            // Money & treasures
            AddItem(new Gold(Utility.Random(2500, 5000)), 0.25);
            AddItem(CreateDecor("Gustavian Coin Hoard", 2213), 0.20);

            // Custom Lore Book
            AddItem(new ChroniclesOfSweden(), 1.0);

            // Map to Sweden
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string name, int hue)
        {
            // Using random artifact as base, could use more specific base types
            ArtifactLargeVase decor = new ArtifactLargeVase();
            decor.Name = name;
            decor.Hue = hue;
            return decor;
        }

        private Item CreateFood(string name, int hue)
        {
            // Using bread loaf as a base for all food
            BreadLoaf food = new BreadLoaf();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon;
            int pick = Utility.Random(3);
            switch (pick)
            {
                case 0:
                    weapon = new VikingSword();
                    weapon.Name = "Sword of Gustav Vasa";
                    weapon.Hue = 1175;
                    weapon.WeaponAttributes.HitFireball = 25;
                    weapon.Attributes.BonusStr = 12;
                    weapon.Attributes.WeaponDamage = 35;
                    weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
                    weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
                    break;
                case 1:
                    weapon = new Axe();
                    weapon.Name = "Birger Jarl's War Axe";
                    weapon.Hue = 1109;
                    weapon.WeaponAttributes.HitLightning = 30;
                    weapon.Attributes.BonusDex = 10;
                    weapon.Attributes.AttackChance = 15;
                    weapon.SkillBonuses.SetValues(0, SkillName.Macing, 15.0);
                    weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
                    break;
                default:
                    weapon = new Longsword();
                    weapon.Name = "Viking’s Saga Blade";
                    weapon.Hue = 1154;
                    weapon.WeaponAttributes.HitLeechHits = 20;
                    weapon.Attributes.WeaponSpeed = 20;
                    weapon.Attributes.Luck = 100;
                    weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
                    weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
                    break;
            }
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateShield()
        {
            BaseShield shield = new MetalShield();
            shield.Name = "Sten Sture’s Shield";
            shield.Hue = 1154;
            shield.ArmorAttributes.SelfRepair = 6;
            shield.Attributes.DefendChance = 20;
            shield.Attributes.Luck = 100;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateRoyalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Royal Cloak of the Kalmar Union";
            cloak.Hue = 1175;
            cloak.Attributes.Luck = 150;
            cloak.Attributes.BonusHits = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateNobelRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Nobel Laureate’s Robe";
            robe.Hue = 1160;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.LowerManaCost = 15;
            robe.Attributes.LowerRegCost = 20;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateABBAItem()
        {
            ThighBoots boots = new ThighBoots();
            boots.Name = "ABBA’s Dancing Boots";
            boots.Hue = 2213;
            boots.Attributes.BonusDex = 8;
            boots.Attributes.Luck = 200;
            boots.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Swedish Realms";
            map.Bounds = new Rectangle2D(2200, 2000, 800, 600);
            map.NewPin = new Point2D(2600, 2400);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSweden(Serial serial) : base(serial) { }

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

    // Lore book
    public class ChroniclesOfSweden : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the North", "Compiled by Skald Linnéa",
            new BookPageInfo
            (
                "In the far north,",
                "where the snow meets the sea,",
                "the saga of Sweden begins.",
                "From ancient Uppsala,",
                "the gods and kings watched",
                "over the frozen land.",
                "Odin’s wolves howled,",
                "and the skalds sang."
            ),
            new BookPageInfo
            (
                "Vikings sailed on dragon ships,",
                "their runes carved in stone.",
                "Birger Jarl forged Stockholm.",
                "Gustav Vasa broke the chains",
                "of Denmark and raised",
                "the blue and yellow banner.",
                "Peace and war, famine and feast,",
                "the land endured all."
            ),
            new BookPageInfo
            (
                "Knights rode for the Kalmar Union,",
                "kings dreamed of empires.",
                "From icy forests to golden fields,",
                "the Swedes fished, farmed,",
                "and sang songs of Midsummer.",
                "Gustavian coins filled",
                "the royal chests. Bells rang",
                "in Uppsala’s high towers."
            ),
            new BookPageInfo
            (
                "In time, peace reigned.",
                "Alfred Nobel’s wisdom turned",
                "powder to prize. The world",
                "gathered in Stockholm to",
                "honor minds and souls.",
                "Lindgren wrote of Pippi,",
                "and ABBA’s music swept the world.",
                "Even IKEA built its legacy."
            ),
            new BookPageInfo
            (
                "Taste the lingonberry’s tartness,",
                "feel the midnight sun.",
                "From the sagas of old,",
                "to the songs of today,",
                "Sweden’s heart beats strong.",
                "May these treasures bring you",
                "the luck of the North,",
                "and the courage of Vikings."
            ),
            new BookPageInfo
            (
                "Raise the glass, dance the ring,",
                "sing the song of the Swede.",
                "For in this chest lies",
                "the spirit of a thousand years.",
                "Skål! May your adventures",
                "be as rich as Sweden’s history.",
                "",
                "- Skald Linnéa"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfSweden() : base(false)
        {
            Hue = 1154;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the North");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the North");
        }

        public ChroniclesOfSweden(Serial serial) : base(serial) { }

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
