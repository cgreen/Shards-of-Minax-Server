using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPapuaNewGuinea : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPapuaNewGuinea()
        {
            Name = "Treasure Chest of Papua New Guinea";
            Hue = 2107; // Deep jungle green

            // Add themed items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ancestor Spirit Vase", 2128), 0.18);
            AddItem(CreateDecorativeItem<StatueSouth>("Carved Spirit Guardian", 1164), 0.16);
            AddItem(CreateDecorativeItem<WolfStatue>("Guardian of the Highlands", 2003), 0.10);
            AddItem(CreateDecorativeItem<DragonLamp>("Lamp of the Raggiana Bird", 1359), 0.11);
            AddItem(CreateDecorativeItem<GargoyleVase>("Sepik River Ceremonial Pot", 1153), 0.14);
            AddItem(CreateDecorativeItem<OrcMask>("Headhunter’s Mask", 2117), 0.18);
            AddItem(CreateDecorativeItem<RandomFancyCoin>("Ancient Shell Money", 1154), 0.22);
            AddItem(CreateDecorativeItem<RandomFancyCrystal>("Spirit Crystal of Mt. Wilhelm", 1157), 0.12);
            AddItem(CreateDecorativeItem<BakeKitsuneStatue>("Bird of Paradise Figurine", 1359), 0.16);

            // Themed food & consumables
            AddItem(CreateNamedFood<Banana>("Jungle Banana (Delicacy)", 1165), 0.22);
            AddItem(CreateNamedFood<GreenTea>("Kava Brew (Mildly Mystical)", 2106), 0.17);
            AddItem(CreateNamedFood<RawRibs>("Headhunter’s Smoked Jerky", 2118), 0.13);
            AddItem(CreateNamedFood<BowlOfRotwormStew>("Highland Mumu Stew", 1819), 0.13);
            AddItem(CreateNamedFood<Coconut>("Coconut of the Coral Coast", 1281), 0.12);

            // Unique treasure
            AddItem(CreateGem("Sun Stone of Oro Province"), 0.15);
            AddItem(CreateGem("Opal of the Sepik River"), 0.13);
            AddItem(CreateGoldItem("Ancient Kina Shell Coin"), 0.18);
            AddItem(new Gold(Utility.Random(500, 5000)), 0.24);

            // Unique, powerful gear
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateExplorerHat(), 0.18);
            AddItem(CreateTribalRobe(), 0.18);
            AddItem(CreateJungleBoots(), 0.18);

            // Unique tools & map
            AddItem(CreateNamedItem<Sextant>("Explorer's Jungle Sextant"), 0.08);
            AddItem(CreateNamedItem<FishingPole>("Shaman’s Fishing Pole"), 0.14);
            AddItem(CreatePapuanMap(), 0.05);

            // The lore book!
            AddItem(new ChroniclesOfTheIslandsOfSpirits(), 1.0);
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

        private Item CreateNamedFood<T>(string name, int hue) where T : Item, new()
        {
            T food = new T();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateGem(string name)
        {
            Ruby gem = new Ruby();
            gem.Name = name;
            gem.Hue = Utility.RandomMinMax(1200, 1260);
            return gem;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreatePapuanMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Spirit Isles";
            map.Bounds = new Rectangle2D(600, 900, 350, 400);
            map.NewPin = new Point2D(770, 1120);
            map.Protected = true;
            return map;
        }

        // Unique gear with cool mods and tribal theme!

        private Item CreateWeapon()
        {
            BaseWeapon weapon = new Scythe();
            weapon.Name = "Ceremonial Kukri of the Headhunters";
            weapon.Hue = 1360; // tribal dark
            weapon.MaxDamage = Utility.Random(40, 80);
            weapon.MinDamage = Utility.Random(25, 35);
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 20;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.BonusHits = 10;
            weapon.WeaponAttributes.HitHarm = 25;
            weapon.WeaponAttributes.HitLeechStam = 10;
            weapon.Slayer = SlayerName.Repond;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = new BoneChest();
            armor.Name = "Spirit-Dancer Bone Chest";
            armor.Hue = 1801; // Bleached bone white
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.Attributes.BonusInt = 12;
            armor.Attributes.Luck = 33;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            armor.SkillBonuses.SetValues(2, SkillName.SpiritSpeak, 15.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateExplorerHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Explorer’s Weathered Hat";
            hat.Hue = 1823;
            hat.Attributes.BonusDex = 10;
            hat.Attributes.LowerManaCost = 6;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.DetectHidden, 10.0);
            hat.SkillBonuses.SetValues(2, SkillName.Hiding, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateTribalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Kundu Shaman’s Feather Robe";
            robe.Hue = 1151;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.RegenMana = 2;
            robe.Attributes.LowerRegCost = 12;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateJungleBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Jungle Pathfinder Boots";
            boots.Hue = 1289;
            boots.Attributes.BonusHits = 15;
            boots.Attributes.BonusStam = 10;
            boots.SkillBonuses.SetValues(0, SkillName.Tracking, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public TreasureChestOfPapuaNewGuinea(Serial serial) : base(serial)
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

    public class ChroniclesOfTheIslandsOfSpirits : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Islands of Spirits", "Anonymous Explorer",
            new BookPageInfo
            (
                "I set foot on the islands",
                "where the spirits walk.",
                "Papua New Guinea—land",
                "of a thousand tribes,",
                "ten thousand tongues, and",
                "endless emerald jungles.",
                "Here the ancestors speak",
                "by wind and drum."
            ),
            new BookPageInfo
            (
                "The Highlands echo with",
                "chants of warriors and",
                "spirit-dancers. Men carve",
                "totems of crocodile and",
                "bird, painted in ochre.",
                "The Sepik River twists,",
                "hiding secrets older",
                "than memory."
            ),
            new BookPageInfo
            (
                "Gold lured many, but it",
                "was the stories that",
                "kept them. The fierce",
                "Asaro Mudmen, masked in",
                "ghostly clay, drive back",
                "invaders. Sorcerers call",
                "the rain, and bones sing",
                "beneath volcanoes."
            ),
            new BookPageInfo
            (
                "I met elders who remember",
                "when the world was new.",
                "Their tales dance like fire,",
                "mixing fact and legend.",
                "I saw birds of paradise—",
                "living jewels—glide above",
                "cannibal caves and orchid",
                "valleys."
            ),
            new BookPageInfo
            (
                "War came in iron birds,",
                "leaving broken steel in",
                "the jungle. But the",
                "spirit of the land",
                "remains. The rivers",
                "flow, and the drums",
                "still beat at dusk."
            ),
            new BookPageInfo
            (
                "Beware the restless dead,",
                "the vengeful forest, the",
                "whispers at night. Yet",
                "honor the spirits, and",
                "you may pass unseen—",
                "or claim the lost",
                "treasures of these",
                "haunted isles."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheIslandsOfSpirits() : base(false)
        {
            Hue = 1153; // Tribal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Islands of Spirits");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Islands of Spirits");
        }

        public ChroniclesOfTheIslandsOfSpirits(Serial serial) : base(serial) { }

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
