using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientEthiopia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientEthiopia()
        {
            Name = "Treasure Chest of Ancient Ethiopia";
            Hue = 2949; // deep gold/bronze

            // Unique, themed items
            AddItem(CreateDecorativeItem<ArtifactVase>("Lalibela Stone Chalice", 1109), 0.17);
            AddItem(CreateDecorativeItem<GoldBricks>("Ophir Gold Ingots", 2213), 0.19);
            AddItem(CreateDecorativeItem<BooksWestArtifact>("Scrolls of Ge'ez Wisdom", 1175), 0.16);
            AddItem(CreateDecorativeItem<WolfStatue>("Lion of Judah Statuette", 2419), 0.13);
            AddItem(CreateDecorativeItem<AncientDrum>("Drum of Gondar", 1865), 0.14);
            AddItem(CreateDecorativeItem<Scepter>("Scepter of Sheba", 1378), 0.08);
            AddItem(CreateDecorativeItem<ObsidianSkull>("Obsidian Idol of Axum", 1102), 0.12);
            AddItem(CreateDecorativeItem<BowlArtifact>("Teff Grain Bowl", 1824), 0.14);
            AddItem(CreateDecorativeItem<FancyCopperSunflower>("Sun Disc of D'mt", 2207), 0.07);
            AddItem(CreateDecorativeItem<TowerLanternArtifact>("Ark-Lantern of Lalibela", 1001), 0.09);

            // Unique consumables/food
            AddItem(CreateConsumable<GreenTea>("Ethiopian Coffee Brew", 2105), 0.13);
            AddItem(CreateConsumable<BreadLoaf>("Injera Bread", 1150), 0.19);
            AddItem(CreateConsumable<FruitBasket>("Basket of Ethiopian Figs", 1446), 0.11);
            AddItem(CreateConsumable<AwaseMisoSoup>("Spiced Stew of Axum", 1157), 0.09);
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Queen Makeda’s Honey Cakes", 1282), 0.07);

            // Unique powerful equipment
            AddItem(CreateUniqueWeapon(), 0.20);
            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateUniqueClothing(), 0.18);
            AddItem(CreateUniqueShield(), 0.13);
            AddItem(CreateUniqueJewelry(), 0.17);

            // Lore book
            AddItem(new ChronicleOfEthiopia(), 1.0);

            // Gold and map
            AddItem(new Gold(Utility.Random(900, 6000)), 0.15);
            AddItem(CreateMap(), 0.07);
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

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueWeapon()
        {
            // The Lionblade of Solomon: Holy sword of legend
            Longsword blade = new Longsword();
            blade.Name = "Lionblade of Solomon";
            blade.Hue = 2949; // gold-bronze
            blade.Slayer = SlayerName.Repond;
            blade.MinDamage = 40;
            blade.MaxDamage = 80;
            blade.Attributes.BonusStr = 12;
            blade.Attributes.BonusHits = 20;
            blade.Attributes.SpellChanneling = 1;
            blade.WeaponAttributes.HitLeechHits = 18;
            blade.WeaponAttributes.HitLightning = 25;
            blade.WeaponAttributes.HitDispel = 10;
            blade.WeaponAttributes.SelfRepair = 7;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            blade.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateUniqueArmor()
        {
            // Crowned Helm of Lalibela
            PlateHelm helm = new PlateHelm();
            helm.Name = "Crowned Helm of Lalibela";
            helm.Hue = 1155; // royal blue-gold
            helm.BaseArmorRating = 54;
            helm.ArmorAttributes.MageArmor = 1;
            helm.ArmorAttributes.LowerStatReq = 25;
            helm.Attributes.BonusInt = 10;
            helm.Attributes.BonusDex = 7;
            helm.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            helm.AbsorptionAttributes.EaterFire = 10;
            helm.AbsorptionAttributes.EaterCold = 5;
            helm.FireBonus = 15;
            helm.EnergyBonus = 8;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateUniqueClothing()
        {
            // Royal Shamma Robe
            Robe robe = new Robe();
            robe.Name = "Royal Shamma Robe";
            robe.Hue = 2107; // white with gold accent
            robe.Attributes.Luck = 55;
            robe.Attributes.NightSight = 1;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueShield()
        {
            // Shield of the Ark
            MetalKiteShield shield = new MetalKiteShield();
            shield.Name = "Shield of the Ark";
            shield.Hue = 1175;
            shield.Attributes.BonusHits = 18;
            shield.Attributes.DefendChance = 12;
            shield.ArmorAttributes.LowerStatReq = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            shield.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateUniqueJewelry()
        {
            // Ring of Axum's Blessing
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Axum's Blessing";
            ring.Hue = 1153;
            ring.Attributes.SpellDamage = 13;
            ring.Attributes.CastSpeed = 1;
            ring.Attributes.CastRecovery = 1;
            ring.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Rock-Hewn Churches";
            map.Bounds = new Rectangle2D(3560, 2170, 180, 180);
            map.NewPin = new Point2D(3605, 2250);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAncientEthiopia(Serial serial) : base(serial) { }

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
    public class ChronicleOfEthiopia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Ethiopia", "Anonymous Chronicler",
            new BookPageInfo
            (
                "Land of beginnings, cradle",
                "of kings. Here, in the",
                "highlands, the Ark of the",
                "Covenant is said to rest.",
                "From the Queen of Sheba to",
                "the Lion of Judah, stories",
                "echo in ancient stone and",
                "sacred rivers."
            ),
            new BookPageInfo
            (
                "Before Aksum rose, D'mt",
                "flourished, ruling over",
                "the Red Sea trade. Then,",
                "the Axumite Empire: mighty,",
                "trading gold and myrrh.",
                "Obelisks scraped the sky.",
                "Faith grew strong; churches",
                "were hewn from living rock."
            ),
            new BookPageInfo
            (
                "The Ark, lost to most,",
                "guarded by monks in Axum,",
                "is Ethiopia’s pride. Wars",
                "were waged and empires",
                "fell, but the Lion's sons",
                "endured. Amharic tongues",
                "sang of Solomon’s line.",
                "Crowns passed in legend."
            ),
            new BookPageInfo
            (
                "When the world’s faith",
                "split, Ethiopia held fast.",
                "Saints roamed, and wise men",
                "brought gifts. Candaces",
                "ruled with grace and wit.",
                "Injera fed armies, and",
                "coffee fueled debate. Glory",
                "rose and fell, but hope",
                "remained."
            ),
            new BookPageInfo
            (
                "Let the finder of this",
                "chest remember: Ethiopia’s",
                "treasures are not only",
                "gold or gem, but wisdom,",
                "spirit, and memory. Honor",
                "the past, and walk gently",
                "where the Lion yet roars."
            ),
            new BookPageInfo
            (
                "- Chronicle of Ethiopia",
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
        public ChronicleOfEthiopia() : base(false)
        {
            Hue = 1155; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Ethiopia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Ethiopia");
        }

        public ChronicleOfEthiopia(Serial serial) : base(serial) { }

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
