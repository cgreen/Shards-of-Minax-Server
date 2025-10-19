using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGuineaBissau : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGuineaBissau()
        {
            Name = "Lost Treasure Chest of Guinea-Bissau";
            Hue = 2112; // Deep green of the mangrove jungle

            // Add items to the chest
            AddItem(CreateArtifact<ArtifactLargeVase>("Balanta Ritual Urn", 2117), 0.17);
            AddItem(CreateArtifact<GoldBricks>("Gold Ingots of Cacheu Fort", 2205), 0.13);
            AddItem(CreateArtifact<LibraryFriendLantern>("Jungle Spirit Lantern", 1376), 0.14);
            AddItem(CreateArtifact<SacredLavaRock>("Sacred Stone of Orango", 2942), 0.11);
            AddItem(CreateArtifact<SnakeStatue>("Snake Fetish of the Bijagos", 1272), 0.10);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateAmulet(), 0.14);
            AddItem(CreateUniqueConsumable(), 0.20);
            AddItem(new ChroniclesOfGuineaBissau(), 1.0);
            AddItem(CreateGoldItem("Colonial Escudo"), 0.16);
            AddItem(new Gold(Utility.Random(4000, 9000)), 0.25);
            AddItem(CreateMap(), 0.05);
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Bissagos Archipelago";
            map.Bounds = new Rectangle2D(3500, 2100, 800, 800);
            map.NewPin = new Point2D(3822, 2399);
            map.Protected = true;
            return map;
        }

        private Item CreateArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            // A jungle survival blade with huge bonuses
            BaseWeapon weapon = new Scimitar();
            weapon.Name = "Machete of Amílcar Cabral";
            weapon.Hue = 2120; // Iron-red
            weapon.MaxDamage = Utility.Random(45, 80);
            weapon.MinDamage = Utility.Random(15, 30);
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.WeaponDamage = 25;
            weapon.Attributes.BonusDex = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Tactics, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Bushido, 10.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Tracking, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Protective armor inspired by animist traditions
            BaseArmor armor = new LeafChest();
            armor.Name = "Balanta Spirit Chestpiece";
            armor.Hue = 2117; // Jungle green
            armor.BaseArmorRating = Utility.Random(35, 60);
            armor.Attributes.Luck = 40;
            armor.Attributes.BonusHits = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            armor.SkillBonuses.SetValues(2, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Woven robe of the rainforest
            Robe robe = new Robe();
            robe.Name = "Woven Robe of the Bijagos";
            robe.Hue = 2118; // Earthy brown
            robe.Attributes.BonusMana = 10;
            robe.Attributes.LowerRegCost = 18;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateAmulet()
        {
            // Ancestral amulet with mystical bonuses
            GoldEarrings amulet = new GoldEarrings();
            amulet.Name = "Amulet of the Rain Spirits";
            amulet.Hue = 1154;
            amulet.Attributes.BonusInt = 15;
            amulet.Attributes.SpellDamage = 13;
            amulet.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            amulet.SkillBonuses.SetValues(1, SkillName.EvalInt, 7.0);
            XmlAttach.AttachTo(amulet, new XmlLevelItem());
            return amulet;
        }

        private Item CreateUniqueConsumable()
        {
            // A rare healing food from the forest
            SushiPlatter food = new SushiPlatter();
            food.Name = "Forest Feast of Bissau";
            food.Hue = 2965; // Exotic color
            food.Stackable = false;
            return food;
        }

        public TreasureChestOfGuineaBissau(Serial serial) : base(serial) { }

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

    public class ChroniclesOfGuineaBissau : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Guinea-Bissau: From Balanta to Independence", "Anonymous Griot",
            new BookPageInfo
            (
                "Beyond the mangroves and",
                "the whispering palms, the",
                "land of rivers was shaped",
                "by many hands: Balanta,",
                "Fula, Mandinka, Papel, all",
                "called it home before the",
                "white sails came."
            ),
            new BookPageInfo
            (
                "The rivers brought trade,",
                "then chains. Cacheu Fort's",
                "guns thundered, gold and",
                "pain entwined. Yet the",
                "spirit of the land lived",
                "on, in masked festivals,",
                "in sacred stones, in the",
                "songs of the griots."
            ),
            new BookPageInfo
            (
                "Colonial banners rose and",
                "fell, but never claimed the",
                "heart of Guinea. The forest",
                "hid warriors, the islands",
                "hid secrets. Spirits danced",
                "in the night, whispering:",
                "\"Freedom will come.\""
            ),
            new BookPageInfo
            (
                "Amílcar Cabral called to",
                "the people: 'Our struggle",
                "is for dignity, for the",
                "right to sing our own",
                "songs, to harvest our own",
                "fields, to name our own",
                "children.'"
            ),
            new BookPageInfo
            (
                "From the green canopies,",
                "revolution grew. The lion",
                "flag flew at dawn. The",
                "chains fell, but the fight",
                "for harmony, justice, and",
                "unity endures."
            ),
            new BookPageInfo
            (
                "Whoever opens this chest,",
                "may you carry forward the",
                "legacy of courage and hope.",
                "May you remember: The land",
                "remembers its children. The",
                "river always finds the sea."
            ),
            new BookPageInfo
            (
                "",
                "- Chronicles of Guinea-Bissau",
                "",
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
        public ChroniclesOfGuineaBissau() : base(false)
        {
            Hue = 2112; // Deep green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Guinea-Bissau");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Guinea-Bissau");
        }

        public ChroniclesOfGuineaBissau(Serial serial) : base(serial) { }

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
