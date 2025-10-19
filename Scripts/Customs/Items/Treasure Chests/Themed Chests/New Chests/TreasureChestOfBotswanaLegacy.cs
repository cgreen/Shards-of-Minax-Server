using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBotswanaLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBotswanaLegacy()
        {
            Name = "Treasure Chest of Botswana’s Legacy";
            Hue = 1152; // A rich, deep blue – color of the national flag

            // Add themed items to the chest
            AddItem(new MaxxiaScroll(), 0.05);
            AddItem(CreateColoredItem<Diamond>("Star of Botswana Diamond", 1955), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Golden Bangle of the Kalahari"), 0.18);
            AddItem(CreateDecorativeItem<WolfStatue>("Okavango Painted Wolf Statuette", 1177), 0.15);
            AddItem(CreateDecorativeItem<ElephantStatue>("Chobe Elephant Statuette", 2105), 0.13);
            AddItem(CreateDecorativeItem<Basket1Artifact>("Tswana Woven Basket", 1182), 0.16);
            AddItem(CreateFoodItem<BreadLoaf>("Kgodu Bread", 0x489), 0.18);
            AddItem(CreateConsumablePotion("Kalanga Sorghum Brew", 0x56E, PotionEffect.Refresh), 0.14);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Watercolor of the Okavango", 1178), 0.14);
            AddItem(CreateGoldItem("Botswana Pula Coin"), 0.18);
            AddItem(new ChroniclesOfBotswanaLegacy(), 1.0);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateThemedClothing(), 0.20);
            AddItem(CreateUniqueCloak(), 0.15);
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
            gold.Amount = Utility.RandomMinMax(1500, 7500);
            return gold;
        }

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

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T deco = new T();
            deco.Name = name;
            deco.Hue = hue;
            return deco;
        }

        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
        {
            T food = new T();
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateConsumablePotion(string name, int hue, PotionEffect effect)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            // You could also attach an XmlScript or effect to the potion if desired
            return potion;
        }

        private Item CreateWeapon()
        {
            // Unique: "Kalahari Lionblade" (Scimitar, named after Botswana's wildlife and desert)
            Scimitar weapon = new Scimitar();
            weapon.Name = "Kalahari Lionblade";
            weapon.Hue = 2125; // Deep gold
            weapon.MinDamage = Utility.Random(22, 35);
            weapon.MaxDamage = Utility.Random(45, 62);
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.WeaponDamage = 35;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.BonusStam = 7;
            weapon.Attributes.AttackChance = 12;
            weapon.Attributes.DefendChance = 10;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.Slayer = SlayerName.ReptilianDeath; // Lions slaying snakes!
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Unique: "Makgadikgadi Spirit Mail" (PlateChest, evocative of salt pans and strength)
            PlateChest armor = new PlateChest();
            armor.Name = "Makgadikgadi Spirit Mail";
            armor.Hue = 2106; // Salt-white/silver
            armor.BaseArmorRating = Utility.Random(45, 80);
            armor.ArmorAttributes.SelfRepair = 7;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.BonusStr = 8;
            armor.Attributes.Luck = 100;
            armor.ColdBonus = 10;
            armor.EnergyBonus = 12;
            armor.PhysicalBonus = 22;
            armor.PoisonBonus = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateThemedClothing()
        {
            // "Tswana Tribal Robe" (Robe, very blue)
            Robe robe = new Robe();
            robe.Name = "Tswana Tribal Robe";
            robe.Hue = 1153; // Light blue from the Botswana flag
            robe.Attributes.Luck = 60;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 9.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            robe.SkillBonuses.SetValues(2, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueCloak()
        {
            // "Cloak of Okavango Mists"
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Okavango Mists";
            cloak.Hue = 1150; // Misty blue-grey
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusInt = 6;
            cloak.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        public TreasureChestOfBotswanaLegacy(Serial serial) : base(serial) { }

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

    // Lore Book: "Chronicles of Botswana"
    public class ChroniclesOfBotswanaLegacy : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Botswana", "Naledi Khama",
            new BookPageInfo
            (
                "In the dawn before diamonds,",
                "before borders were drawn,",
                "the Kalahari sands stretched",
                "beyond the dreams of men.",
                "Here, the people of the land",
                "– the Batswana – followed the",
                "great herds under the wide,",
                "blue sky."
            ),
            new BookPageInfo
            (
                "The Okavango waters arrived",
                "as a blessing. The river does",
                "not run to the sea, but",
                "vanishes into a labyrinth of",
                "marsh and reed, home to lion,",
                "elephant, painted wolf, and",
                "the spirits of ancestors."
            ),
            new BookPageInfo
            (
                "In the era of kings, the",
                "tribes united under Kgosi",
                "Khama, forging peace and",
                "strength against invaders.",
                "Their wisdom is woven in",
                "every basket, their courage",
                "echoes in the drums."
            ),
            new BookPageInfo
            (
                "When the world changed and",
                "flags rose over Africa,",
                "Botswana chose a path of",
                "unity and diamond-bright hope.",
                "The Pula fell from the sky –",
                "rain, prosperity, and pride."
            ),
            new BookPageInfo
            (
                "Now the land is famed for",
                "peace, the gems beneath its",
                "earth, and the wild places",
                "untouched by time. But the",
                "greatest treasure remains the",
                "spirit of her people: strong,",
                "proud, and free."
            ),
            new BookPageInfo
            (
                "To those who open this chest:",
                "know that Botswana's true",
                "legacy is not gold nor stone,",
                "but the unbroken line of",
                "dreamers who call her home.",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Beware, too, the ancient",
                "spirits that wander these",
                "sands. Offer respect, or risk",
                "awakening old stories. May the",
                "rain bless you, and fortune",
                "follow your path.",
                "",
                "- Naledi Khama"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBotswanaLegacy() : base(false)
        {
            Hue = 1152; // Botswana blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Botswana");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Botswana");
        }

        public ChroniclesOfBotswanaLegacy(Serial serial) : base(serial) { }

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

    // Example Custom Decorative Item: ElephantStatue
    public class ElephantStatue : Item
    {
        [Constructable]
        public ElephantStatue() : base(0x20F8) // Choose an appropriate itemID
        {
            Name = "Elephant Statue";
            Weight = 5.0;
        }

        public ElephantStatue(Serial serial) : base(serial) { }

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
}
