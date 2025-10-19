using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSandsOfGaza : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheSandsOfGaza()
        {
            Name = "Treasure Chest of the Sands of Gaza";
            Hue = 2419; // Sandy golden hue

            AddItem(CreateDecorativeItem<ArtifactVase>("Mosaic Vase of Ashkelon", 2101), 0.22);
            AddItem(CreateDecorativeItem<AncientWeapon1>("Rust-Edged Philistine Sword", 1866), 0.13);
            AddItem(CreateDecorativeItem<GoldBricks>("Roman Gold Ingots", 1370), 0.16);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Crusader's Bookcase", 2412), 0.14);
            AddItem(CreateDecorativeItem<SacredLavaRock>("Obsidian Idol of Dagon", 1175), 0.10);
            AddItem(CreateDecorativeItem<GargishPortraitArtifact>("Byzantine Mosaic Portrait", 2401), 0.17);
            AddItem(CreateDecorativeItem<TarotCardsArtifact>("Sandswept Prophecy Cards", 1172), 0.13);
            AddItem(CreateNamedItem<Gold>("Shekel of Gaza"), 0.19);
            AddItem(CreateConsumable<RandomFancyPotion>("Healing Sand of Gaza", 1287), 0.18);
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Bread of the Ancient City", 2414), 0.17);
            AddItem(CreateConsumable<RandomDrink>("Wine of the Old Port", 1378), 0.18);
            AddItem(new ChroniclesOfTheEternalSands(), 1.0);

            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.19);
            AddItem(CreateJewelry(), 0.15);

            AddItem(CreateMap(), 0.08);
            AddItem(new Gold(Utility.Random(500, 3000)), 0.15);
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

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            // Ancient Warrior's Scimitar
            Katana weapon = new Katana();
            weapon.Name = "Blade of the Gazan Conqueror";
            weapon.Hue = 1175;
            weapon.MinDamage = 30;
            weapon.MaxDamage = 68;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusDex = 7;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.WeaponAttributes.HitLeechHits = 20;
            weapon.WeaponAttributes.HitFireArea = 10;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Crusader's Platemail
            PlateChest armor = new PlateChest();
            armor.Name = "Crusader’s Breastplate of Gaza";
            armor.Hue = 2101;
            armor.BaseArmorRating = 54;
            armor.ArmorAttributes.SelfRepair = 7;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStr = 8;
            armor.Attributes.RegenHits = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            armor.ColdBonus = 8;
            armor.FireBonus = 10;
            armor.EnergyBonus = 6;
            armor.PhysicalBonus = 12;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Silk Robe of Alexandria
            Robe robe = new Robe();
            robe.Name = "Alexandrian Silk Robe";
            robe.Hue = 1378;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.LowerManaCost = 20;
            robe.Attributes.Luck = 40;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 14.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateJewelry()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Pharaoh’s Solar Bracelet";
            bracelet.Hue = 2412;
            bracelet.Attributes.BonusMana = 8;
            bracelet.Attributes.Luck = 60;
            bracelet.Attributes.RegenMana = 3;
            bracelet.Attributes.SpellDamage = 12;
            bracelet.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Gaza";
            map.Bounds = new Rectangle2D(3300, 2700, 400, 400);
            map.NewPin = new Point2D(3400, 2890);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheSandsOfGaza(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheEternalSands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Eternal Sands", "The Scribe of Gaza",
            new BookPageInfo
            (
                "Upon these windswept sands,",
                "great kingdoms rose and fell.",
                "Gaza, the gateway of empires,",
                "knew the footsteps of the",
                "Pharaoh’s armies, Philistine",
                "warriors, and prophets alike."
            ),
            new BookPageInfo
            (
                "Here, Alexander’s legions marched,",
                "Caesar’s banners unfurled, and the",
                "Caesarean port bustled with merchants,",
                "priests, and dreamers. Rome's mosaics",
                "gleamed beneath desert suns.",
                ""
            ),
            new BookPageInfo
            (
                "When the Crescent Moon ascended,",
                "Gaza flourished, a crossroads of",
                "East and West. The Crusaders came,",
                "then faded like mirages, leaving",
                "cathedrals beside mosques.",
                ""
            ),
            new BookPageInfo
            (
                "In Ottoman days, caravan bells",
                "rang through narrow streets.",
                "Empires faded, but Gaza endured—",
                "her stones holding memory, her",
                "markets brimming with life."
            ),
            new BookPageInfo
            (
                "Beware, traveler: these sands",
                "hold secrets and sorrow. In every",
                "grain, a story; in every ruin,",
                "a warning. The past is never",
                "truly buried beneath the dunes."
            ),
            new BookPageInfo
            (
                "Should you disturb these treasures,",
                "know that the eyes of a thousand",
                "ancient souls watch, and the city",
                "remembers all who pass.",
                "",
                "",
                "- The Scribe of Gaza"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheEternalSands() : base(false)
        {
            Hue = 2419; // Sandy golden
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Eternal Sands");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Eternal Sands");
        }

        public ChroniclesOfTheEternalSands(Serial serial) : base(serial) { }

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
