using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSolomonIsles : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheSolomonIsles()
        {
            Name = "Treasure Chest of the Solomon Isles";
            Hue = 1289; // Deep ocean blue

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Shell-Encrusted Ceremonial Urn", 1272), 0.20);
            AddItem(CreateDecorativeItem<SnakeStatue>("Totem of the Sea Serpent", 2006), 0.17);
            AddItem(CreateDecorativeItem<CrabBushel>("Crab Bushel of Marovo Lagoon", 1287), 0.18);
            AddItem(CreateDecorativeItem<TikiStatue>("Ancestral Tiki Statue", 1260), 0.15);
            AddItem(CreateNamedItem<RandomFancyCoin>("Ancient Shell Currency"), 0.23);
            AddItem(CreateNamedItem<MagicOrb>("WWII Signal Crystal"), 0.15);
            AddItem(CreateBookOfLore(), 1.0);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.23);
            AddItem(CreateHat(), 0.19);
            AddItem(CreateRobe(), 0.18);
            AddItem(CreateIslandRing(), 0.12);
            AddItem(CreateFishFeast(), 0.20);
            AddItem(CreatePotion(), 0.18);
            AddItem(new Gold(Utility.Random(1200, 3200)), 0.15);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateDecorativeItem<FigureheadOfBmvArarat>("Driftwood Figurehead", 1909), 0.08);
            AddItem(CreateDecorativeItem<WindChimes>("Windchimes of Spirits", 1153), 0.13);
            AddItem(CreateDecorativeItem<ZenRock2Artifact>("Volcanic Island Stone", 1195), 0.16);
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateBookOfLore()
        {
            return new SolomonIslandsChronicle();
        }

        private Item CreateWeapon()
        {
            // WWII Relic or Tribal Weapon
            BaseWeapon weapon;
            if (Utility.RandomBool())
            {
                weapon = new Katana();
                weapon.Name = "Blade of the Island Chieftain";
                weapon.Hue = 1268; // Coral red
                weapon.WeaponAttributes.HitLeechHits = 18;
                weapon.WeaponAttributes.HitFireball = 22;
                weapon.Attributes.BonusStr = 10;
                weapon.Attributes.BonusDex = 8;
                weapon.Attributes.AttackChance = 15;
                weapon.Attributes.WeaponSpeed = 20;
                weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            }
            else
            {
                weapon = new WarAxe();
                weapon.Name = "Headhunter’s War Axe";
                weapon.Hue = 1196; // Jade green
                weapon.WeaponAttributes.HitLightning = 30;
                weapon.WeaponAttributes.HitPoisonArea = 15;
                weapon.Attributes.BonusHits = 15;
                weapon.Attributes.BonusStam = 15;
                weapon.Attributes.RegenStam = 2;
                weapon.SkillBonuses.SetValues(0, SkillName.Macing, 20.0);
            }
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Armor inspired by island materials
            BaseArmor armor;
            switch (Utility.Random(3))
            {
                case 0:
                    armor = new LeafChest();
                    armor.Name = "Woven Palm Breastplate";
                    armor.Hue = 1273;
                    armor.Attributes.BonusHits = 10;
                    armor.Attributes.RegenHits = 3;
                    armor.Attributes.LowerManaCost = 8;
                    armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
                    break;
                case 1:
                    armor = new BoneHelm();
                    armor.Name = "Sharkbone Ritual Helm";
                    armor.Hue = 1150;
                    armor.Attributes.BonusInt = 6;
                    armor.Attributes.NightSight = 1;
                    armor.Attributes.BonusMana = 8;
                    armor.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
                    break;
                default:
                    armor = new StuddedGloves();
                    armor.Name = "Pearl-Studded War Gloves";
                    armor.Hue = 2301;
                    armor.Attributes.BonusDex = 8;
                    armor.Attributes.ReflectPhysical = 12;
                    armor.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
                    break;
            }
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateHat()
        {
            StrawHat hat = new StrawHat();
            hat.Name = "Navigator’s Woven Hat";
            hat.Hue = 1271;
            hat.Attributes.Luck = 25;
            hat.Attributes.BonusDex = 5;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 18.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robes of the Island Shaman";
            robe.Hue = 1173;
            robe.Attributes.BonusMana = 15;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.LowerRegCost = 12;
            robe.Attributes.LowerManaCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateIslandRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Pacific Unity";
            ring.Hue = 1906;
            ring.Attributes.Luck = 40;
            ring.Attributes.BonusHits = 8;
            ring.Attributes.BonusInt = 8;
            ring.SkillBonuses.SetValues(0, SkillName.Peacemaking, 12.0);
            ring.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateFishFeast()
        {
            SushiPlatter platter = new SushiPlatter();
            platter.Name = "Feast of Reef Fish";
            platter.Hue = 85;
            return platter;
        }

        private Item CreatePotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Kastom Herbal Tonic";
            potion.Hue = 2117; // Bright herbal green
            return potion;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Skull Island";
            map.Bounds = new Rectangle2D(5600, 3300, 350, 350);
            map.NewPin = new Point2D(5720, 3460);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheSolomonIsles(Serial serial) : base(serial) { }

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

    public class SolomonIslandsChronicle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Solomon Islands Chronicle", "Kalina of Malaita",
            new BookPageInfo
            (
                "Long before the world",
                "knew the name ‘Solomon’,",
                "our islands were home to",
                "canoes of skilled sailors,",
                "tribes of builders,",
                "warriors and dreamers.",
                "",
                "Here, the sea speaks in",
                "ancient tongues."
            ),
            new BookPageInfo
            (
                "We traded shells and",
                "stone, worshipped spirits",
                "of reef and volcano.",
                "The first Europeans",
                "called us the isles of",
                "gold and headhunters.",
                "Their maps were full",
                "of dread and wonder."
            ),
            new BookPageInfo
            (
                "Centuries later, war",
                "came on metal wings.",
                "The jungle thundered",
                "with gunfire and flame.",
                "Battleships now sleep",
                "in our coral graves,",
                "claimed by tide and",
                "memory."
            ),
            new BookPageInfo
            (
                "Still, the kastom ways",
                "survive. Our carvers",
                "whisper to wood. Our",
                "priests call the rain.",
                "The spirits walk beside",
                "us, and the ancestors",
                "never sleep."
            ),
            new BookPageInfo
            (
                "To those who open this",
                "chest: you hold a piece",
                "of living story. Treasure",
                "the wonders of these",
                "isles, but fear the wrath",
                "of what you do not",
                "respect.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "In every shell, a story.",
                "In every shadow, a ghost.",
                "In every wave, a promise.",
                "",
                "- Kalina of Malaita",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SolomonIslandsChronicle() : base(false)
        {
            Hue = 1289; // Ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Solomon Islands Chronicle");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Solomon Islands Chronicle");
        }

        public SolomonIslandsChronicle(Serial serial) : base(serial) { }

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

    // Optional: A custom TikiStatue for flavor if not present
    public class TikiStatue : Item
    {
        [Constructable]
        public TikiStatue() : base(Utility.RandomList(8562, 8563, 8564))
        {
            Name = "Wooden Tiki Statue";
            Hue = 1209;
            Weight = 6.0;
        }
        public TikiStatue(Serial serial) : base(serial) { }
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
