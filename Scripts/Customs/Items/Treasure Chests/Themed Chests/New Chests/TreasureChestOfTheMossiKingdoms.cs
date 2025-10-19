using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheMossiKingdoms : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfTheMossiKingdoms()
        {
            Name = "Treasure Chest of the Mossi Kingdoms";
            Hue = 2125; // deep gold, symbolizing wealth of ancient Mossi

            // Decorative/themed items
            AddItem(CreateColoredItem<ChangelingStatue>("Statue of Wobgo, Mossi Hero", 2117), 0.15);
            AddItem(CreateColoredItem<Sculpture1Artifact>("Gold Mask of the Mogho Naba", 1288), 0.10);
            AddItem(CreateColoredItem<ArtifactLargeVase>("Ancient Gourounsi Pottery", 2203), 0.13);
            AddItem(CreateColoredItem<QuagmireZooStatuette>("Bronze Horse of Ouagadougou", 1194), 0.12);
            AddItem(CreateNamedItem<Candelabra>("Royal Drum Candelabra", 1281), 0.14);

            // Powerful, themed equipment
            AddItem(CreateMossiWeapon(), 0.20);
            AddItem(CreateMossiArmor(), 0.20);
            AddItem(CreateMossiCloak(), 0.18);
            AddItem(CreateMossiBoots(), 0.15);

            // Consumables/rare food
            AddItem(CreateNamedItem<GreaterHealPotion>("Elixir of Moro-Naba", 1412), 0.18);
            AddItem(CreateColoredItem<Banana>("Sacred Dolo Beer (Banana)", 2122), 0.15);
            AddItem(CreateNamedItem<RandomFancyBakedGoods>("Yam Cake of Victory"), 0.11);
            AddItem(CreateNamedItem<RandomFancyPotion>("Baobab Fruit Potion"), 0.13);

            // Unique currency/treasure
            AddItem(CreateGoldItem("Ancient Mossi Gold Bezant"), 0.22);
            AddItem(CreateColoredItem<Ruby>("Ruby of the Mossi Plains", 1402), 0.11);

            // Custom lore book
            AddItem(new ChroniclesOfTheMossiKings(), 1.0);

            // A royal map
            AddItem(CreateMap(), 0.07);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(800, 2400);
            return gold;
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
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Mossi Kingdoms";
            map.Bounds = new Rectangle2D(2550, 2700, 500, 600);
            map.NewPin = new Point2D(2700, 3000);
            map.Protected = true;
            return map;
        }

        // Unique, powerful Mossi-themed weapon
        private Item CreateMossiWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Spear(), new QuarterStaff(), new Scepter(), new Kryss()
            );
            weapon.Name = "Blade of Ouedraogo, Mossi Founder";
            weapon.Hue = 2115;
            weapon.MaxDamage = Utility.Random(35, 65);
            weapon.Attributes.AttackChance = 12;
            weapon.Attributes.WeaponSpeed = 18;
            weapon.Attributes.BonusStam = 15;
            weapon.WeaponAttributes.HitHarm = 20;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.Attributes.BonusHits = 10;
            weapon.Attributes.ReflectPhysical = 8;
            weapon.Slayer = SlayerName.DragonSlaying;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Unique, powerful Mossi-themed armor
        private Item CreateMossiArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new StuddedArms(), new LeatherGorget(), new Bascinet()
            );
            armor.Name = "Mossi Royal Defender's Mail";
            armor.Hue = 2141;
            armor.BaseArmorRating = Utility.Random(36, 68);
            armor.Attributes.BonusStr = 12;
            armor.Attributes.BonusHits = 18;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 11.0);
            armor.SkillBonuses.SetValues(1, SkillName.MagicResist, 9.0);
            armor.ColdBonus = 8;
            armor.EnergyBonus = 7;
            armor.PhysicalBonus = 20;
            armor.PoisonBonus = 7;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique cloak
        private Item CreateMossiCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Nyonyose Spirit";
            cloak.Hue = 1288;
            cloak.Attributes.Luck = 40;
            cloak.Attributes.BonusMana = 7;
            cloak.Attributes.BonusInt = 6;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 13.0);
            cloak.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Unique boots
        private Item CreateMossiBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Sandals of the Savanna Walker";
            boots.Hue = 1166;
            boots.Attributes.BonusDex = 8;
            boots.Attributes.BonusStam = 9;
            boots.Attributes.LowerManaCost = 7;
            boots.Attributes.LowerRegCost = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 9.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public TreasureChestOfTheMossiKingdoms(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheMossiKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Mossi Kings", "Mossi Griot",
            new BookPageInfo
            (
                "Hear the tale of the Mossi,",
                "Born from Yennenga, the warrior",
                "princess, and Rialé, the horseman.",
                "Their son Ouedraogo founded",
                "Ouagadougou, heart of the Mossi.",
                "From there, the Mossi ruled the",
                "savannas, kings known as Mogho Naba."
            ),
            new BookPageInfo
            (
                "The Mossi rode out in splendor,",
                "horses adorned in golden tack.",
                "They forged powerful kingdoms:",
                "Tenkodogo, Yatenga, Gourma.",
                "Their drums thundered, their",
                "masks danced in the moonlight.",
                "Their griots sang of ancestors."
            ),
            new BookPageInfo
            (
                "Though mighty empires rose—",
                "Songhai, Mali—the Mossi stood",
                "proud and fierce. Their arrows",
                "defended their lands from all",
                "invaders. They thrived through",
                "trade, and the wisdom of kings."
            ),
            new BookPageInfo
            (
                "When the strangers arrived,",
                "clad in iron and bearing flags,",
                "the Mossi kings gathered their",
                "warriors. They resisted with",
                "courage, but the old order fell.",
                "Colonial rule brought hardship,",
                "but never erased their spirit."
            ),
            new BookPageInfo
            (
                "In time, the Mossi led the call",
                "for freedom. Sankara's voice rose",
                "over the land, and the people",
                "united as Burkina Faso—Land of",
                "Upright People. The golden masks",
                "and the royal horses remain.",
                "The drums still sound at dawn."
            ),
            new BookPageInfo
            (
                "O seeker, know that the Mossi",
                "endure, not as rulers only, but",
                "as guardians of memory, pride,",
                "and hope. May this chest remind",
                "you: the past lives on in the",
                "song, the mask, the gold, and",
                "the courage of Burkina Faso."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheMossiKings() : base(false)
        {
            Hue = 1195; // golden brown, symbolizing earth and wealth
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Mossi Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Mossi Kings");
        }

        public ChroniclesOfTheMossiKings(Serial serial) : base(serial) { }

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
