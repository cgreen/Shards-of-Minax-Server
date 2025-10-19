using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class LostChestOfEquatorialGuinea : WoodenChest
    {
        [Constructable]
        public LostChestOfEquatorialGuinea()
        {
            Name = "Lost Chest of Equatorial Guinea";
            Hue = 1429; // Deep jungle green

            // Add themed items
            AddItem(CreateDecorativeItem<ArtifactVase>("Bubi Clay Pot", 2117), 0.25);
            AddItem(CreateDecorativeItem<ChangelingStatue>("Islander Spirit Idol", 2408), 0.13);
            AddItem(CreateDecorativeItem<RuinedPaintingArtifact>("Colonial Explorer's Portrait", 2448), 0.15);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Fang Chief’s Stool", 1721), 0.20);
            AddItem(CreateDecorativeItem<AncientDrum>("Ritual Drum of Bioko", 2547), 0.18);
            AddItem(CreateDecorativeItem<ExoticWhistle>("Forest Whistle", 1364), 0.19);

            AddItem(CreateConsumable<GreaterHealPotion>("Herbal Brew of Moka Valley", 1416), 0.22);
            AddItem(CreateConsumable<GreenTea>("Islander Green Tea", 1429), 0.23);
            AddItem(CreateConsumable<BentoBox>("Jungle Bento Box", 2730), 0.12);
            AddItem(CreateConsumable<SushiPlatter>("Rio Muni Fish Platter", 1164), 0.13);

            AddItem(CreateGoldItem("Doubloon of the Spanish Fort"), 0.17);
            AddItem(new ChronicleOfTheIslandSecrets(), 1.0);

            // Equipment: explorer/jungle style, strong modifiers and skill bonuses
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateUniqueHat(), 0.14);
            AddItem(CreateUniqueCloak(), 0.10);
            AddItem(CreateJewelry(), 0.16);

            // Random explorer equipment
            AddItem(CreateDecorativeItem<MapOfTheKnownWorld>("Old Map of Bioko", 1726), 0.11);
            AddItem(CreateDecorativeItem<Sextant>("Explorer’s Sextant", 1207), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
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
            if (item is BasePotion bp)
                bp.PotionEffect = PotionEffect.Heal;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Amount = Utility.Random(800, 4000);
            gold.Name = name;
            return gold;
        }

        private Item CreateWeapon()
        {
            // Enchanted explorer’s machete
            ExplorersMachete weapon = new ExplorersMachete();
            weapon.Name = "Machete of the Rainforest";
            weapon.Hue = 1278;
            weapon.MinDamage = Utility.Random(32, 48);
            weapon.MaxDamage = Utility.Random(56, 72);
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.BonusHits = 12;
            weapon.Attributes.AttackChance = 10;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            weapon.WeaponAttributes.SelfRepair = 6;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Jungle Explorer’s Plate Chest
            PlateChest armor = new PlateChest();
            armor.Name = "Explorer’s Reinforced Chestplate";
            armor.Hue = 2213;
            armor.BaseArmorRating = Utility.Random(35, 55);
            armor.ArmorAttributes.LowerStatReq = 30;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.Attributes.Luck = 55;
            armor.Attributes.BonusStr = 8;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tracking, 15.0);
            armor.ColdBonus = 7;
            armor.EnergyBonus = 8;
            armor.FireBonus = 9;
            armor.PhysicalBonus = 15;
            armor.PoisonBonus = 6;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueHat()
        {
            // WideBrimHat: “Colonial Pith Helmet”
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Colonial Pith Helmet";
            hat.Hue = 2424;
            hat.Attributes.BonusDex = 8;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateUniqueCloak()
        {
            // Cloak: “Shroud of the Island Spirits”
            Cloak cloak = new Cloak();
            cloak.Name = "Shroud of the Island Spirits";
            cloak.Hue = 2101;
            cloak.Attributes.RegenHits = 2;
            cloak.Attributes.RegenMana = 2;
            cloak.Attributes.BonusInt = 6;
            cloak.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 7.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateJewelry()
        {
            // GoldBracelet: “Bracelet of Fang Ancestors”
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of Fang Ancestors";
            bracelet.Hue = 1764;
            bracelet.Attributes.BonusMana = 10;
            bracelet.Attributes.SpellDamage = 14;
            bracelet.Attributes.CastRecovery = 2;
            bracelet.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            bracelet.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        public LostChestOfEquatorialGuinea(Serial serial) : base(serial) { }

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

    public class ChronicleOfTheIslandSecrets : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Island’s Secrets", "Explorer Juan del Río",
            new BookPageInfo
            (
                "In the humid jungles and misty isles",
                "of Equatorial Guinea, the Bubi",
                "speak of spirits in the trees and",
                "treasures lost beneath the roots.",
                "The Portuguese passed by; the",
                "Spanish claimed the coast; but only",
                "the brave survived Moka’s hidden",
                "valleys and Malabo’s storms."
            ),
            new BookPageInfo
            (
                "The Fang warriors crossed the river",
                "and vanished into the deep forests.",
                "I have seen their carvings, their",
                "sacred drums echoing at dusk.",
                "The old fort, built by Spain, now",
                "crumbles, half-swallowed by vines.",
                "Yet its vaults still guard coins",
                "marked with strange sigils."
            ),
            new BookPageInfo
            (
                "The mountain Pico Basilé stands",
                "watchful over all. The islanders say",
                "the volcano holds the bones of kings.",
                "Oil was struck, gold was found, but",
                "the true wealth lies in ancient",
                "wisdom—passed from shaman to",
                "shaman beneath the ceiba tree."
            ),
            new BookPageInfo
            (
                "Take heed, explorer: many have",
                "come seeking riches, few have left",
                "with their minds unbroken. The",
                "forest is old. The spirits are older.",
                "If you find this book, remember:",
                "fortune favors only the respectful.",
                "",
                "- Juan del Río"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheIslandSecrets() : base(false)
        {
            Hue = 1166; // Mysterious blue-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Island’s Secrets");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Island’s Secrets");
        }

        public ChronicleOfTheIslandSecrets(Serial serial) : base(serial) { }

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
