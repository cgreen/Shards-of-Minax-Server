using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfDilmun : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfDilmun()
        {
            Name = "Chest of the Lost Treasures of Dilmun";
            Hue = 1266; // Soft blue-green, reminiscent of the sea

            // Add themed loot
            AddItem(CreatePearl("Pearl of Immortality", 1153), 0.18);
            AddItem(CreateColoredItem<BottleArtifact>("Dilmunite Perfume Bottle", 1154), 0.17);
            AddItem(CreateDecorItem<AncientShipModelOfTheHMSCape>("Miniature Dilmunite Trading Ship", 2407), 0.12);
            AddItem(CreateDecorItem<GoldBricks>("Sunken Gold Bars", 1355), 0.12);
            AddItem(CreateDecorItem<ArtifactLargeVase>("Vase of the Enki Priesthood", 2209), 0.16);
            AddItem(CreateMap(), 0.04);

            AddItem(CreateFoodItem<BentoBox>("Box of Spiced Date Cakes", 0x48E), 0.10);
            AddItem(CreateNamedItem<GreenTea>("Pearl Diver’s Tonic"), 0.13);
            AddItem(CreateColoredItem<RandomFancyPotion>("Elixir of Dilmun", 1266), 0.11);

            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Pearl Kings"), 0.11);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of Ancient Dilmun"), 0.11);

            AddItem(CreatePearlBlade(), 0.15);
            AddItem(CreateDilmuniteCirclet(), 0.14);
            AddItem(CreateSilkSash(), 0.13);

            AddItem(new ChroniclesOfDilmun(), 1.0);

            AddItem(new Gold(Utility.Random(1800, 4000)), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreatePearl(string name, int hue)
        {
            StarSapphire pearl = new StarSapphire();
            pearl.Name = name;
            pearl.Hue = hue;
            return pearl;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.Movable = true;
            return item;
        }

        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.Stackable = false;
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
            map.Name = "Ancient Map of Dilmun";
            map.Bounds = new Rectangle2D(1580, 3260, 400, 400);
            map.NewPin = new Point2D(1607, 3403);
            map.Protected = true;
            return map;
        }

        // Custom Equipment ---------------------------------------

        private Item CreatePearlBlade()
        {
            Katana blade = new Katana();
            blade.Name = "Pearl Blade of Dilmun";
            blade.Hue = 1153;
            blade.Attributes.SpellChanneling = 1;
            blade.Attributes.BonusHits = 20;
            blade.Attributes.WeaponSpeed = 35;
            blade.Attributes.WeaponDamage = 65;
            blade.WeaponAttributes.HitLightning = 35;
            blade.WeaponAttributes.HitDispel = 10;
            blade.WeaponAttributes.HitHarm = 15;
            blade.WeaponAttributes.SelfRepair = 8;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            blade.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.0);
            blade.WeaponAttributes.UseBestSkill = 1;
            blade.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateDilmuniteCirclet()
        {
            Circlet circlet = new Circlet();
            circlet.Name = "Circlet of the Enki";
            circlet.Hue = 2209;
            circlet.Attributes.BonusMana = 25;
            circlet.Attributes.RegenMana = 3;
            circlet.Attributes.CastRecovery = 2;
            circlet.ArmorAttributes.SelfRepair = 6;
            circlet.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            circlet.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            circlet.PhysicalBonus = 10;
            circlet.FireBonus = 10;
            circlet.ColdBonus = 10;
            circlet.PoisonBonus = 10;
            circlet.EnergyBonus = 10;
            XmlAttach.AttachTo(circlet, new XmlLevelItem());
            return circlet;
        }

        private Item CreateSilkSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Silk Sash of the Dilmunite Queen";
            sash.Hue = 1266;
            sash.Attributes.Luck = 65;
            sash.Attributes.BonusInt = 10;
            sash.Attributes.BonusDex = 8;
            sash.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            sash.SkillBonuses.SetValues(1, SkillName.Ninjitsu, 10.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        // END Equipment

        public TreasureChestOfDilmun(Serial serial) : base(serial)
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

    // Custom Lore Book
    public class ChroniclesOfDilmun : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Dilmun", "Elder Ninsun",
            new BookPageInfo
            (
                "Long before the pharaohs rose,",
                "there was Dilmun, the shining",
                "land between two seas. Her",
                "harbors bristled with ships, her",
                "fields bloomed with date and fig.",
                "It was said the gods themselves",
                "came to bathe in her sweet",
                "waters and rest in her gardens."
            ),
            new BookPageInfo
            (
                "The Pearl Divers of Dilmun",
                "dove each dawn, praying to Enki",
                "for breath and fortune. Their",
                "treasures glimmered brighter",
                "than gold, drawing traders from",
                "Ur, Egypt, and Indus. Every tide",
                "brought new secrets, every storm,",
                "a tale of loss and longing."
            ),
            new BookPageInfo
            (
                "But shadows came. First, the",
                "envy of distant kings. Then",
                "the sails of the red-crossed",
                "ships—foreigners who seized",
                "our ports and riches. Yet, even",
                "as palaces fell and temples",
                "crumbled, the spirit of Dilmun",
                "endured, hidden in the sands."
            ),
            new BookPageInfo
            (
                "To the brave who find this chest:",
                "know that these treasures are",
                "echoes of a world between myth",
                "and memory. Let the Pearl Blade",
                "protect you. Let the Sash and",
                "Circlet guide your mind. May the",
                "perfume of ancient flowers and",
                "taste of honeyed dates linger."
            ),
            new BookPageInfo
            (
                "For though the gods have sailed",
                "west, and the sunken ships",
                "sleep, Dilmun is never lost.",
                "She lives where the horizon",
                "meets the sea, and in the heart",
                "of every seeker who dreams",
                "of golden isles and paradise",
                "beyond the reach of time."
            ),
            new BookPageInfo
            (
                "",
                "— Elder Ninsun",
                "Priestess of Dilmun",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfDilmun() : base(false)
        {
            Hue = 1266; // Sea-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Dilmun");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Dilmun");
        }

        public ChroniclesOfDilmun(Serial serial) : base(serial) { }

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
