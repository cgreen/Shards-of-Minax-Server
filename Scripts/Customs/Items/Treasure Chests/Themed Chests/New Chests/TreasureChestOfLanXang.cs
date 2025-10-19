using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLanXang : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLanXang()
        {
            Name = "Treasure Chest of Lan Xang";
            Hue = 2129; // A golden lacquered hue

            // Add unique themed items with probabilities
            AddItem(new MekongJadeBuddha(), 0.10);
            AddItem(CreateDecorativeItem<ArtifactVase>("Lotus Vase of Vientiane", 1191), 0.18);
            AddItem(CreateDecorativeItem<SilverSteedZooStatuette>("Naga of the Mekong", 2065), 0.16);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateConsumable("Khao Niew (Sticky Rice)", 2414), 0.20);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateClothing(), 0.22);
            AddItem(CreateDecorativeItem<GoldBricks>("Royal Gold Ingot of Luang Prabang", 2207), 0.12);
            AddItem(CreateDecorativeItem<FancyCopperSunflower>("Gilded Lotus Blossom", 1157), 0.14);
            AddItem(CreateConsumable("Elixir of the Elephants", 1266), 0.09);
            AddItem(CreateDecorativeItem<KingsGildedStatue>("King Fa Ngum’s Statue", 1359), 0.11);
            AddItem(CreateConsumable("Mekong Herbal Brew", 1337), 0.13);
            AddItem(CreateDecorativeItem<AncientDrum>("Sacred Drum of Wat Phu", 2128), 0.12);
            AddItem(CreateDecorativeItem<BlueBook>("Book of Lao Proverbs", 1153), 0.15);
            AddItem(CreateWeapon(), 0.10);
            AddItem(CreateClothing(), 0.08);
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

        private Item CreateConsumable(string name, int hue)
        {
            // Using GreenTea as base item for all custom consumables for simplicity
            GreenTea item = new GreenTea();
            item.Name = name;
            item.Hue = hue;
            item.Stackable = false;
            return item;
        }

        private Item CreateWeapon()
        {
            // Legendary sword themed after the founder of Lan Xang
            Katana weapon = new Katana();
            weapon.Name = "Sword of Fa Ngum";
            weapon.Hue = 2212;
            weapon.Attributes.WeaponDamage = 55;
            weapon.Attributes.AttackChance = 20;
            weapon.Attributes.DefendChance = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusStam = 15;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Slayer = SlayerName.Repond; // Mythic creatures
            weapon.WeaponAttributes.HitLeechHits = 30;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Ornate helm inspired by temple iconography
            PlateHelm helm = new PlateHelm();
            helm.Name = "Mekong River Helm";
            helm.Hue = 1269;
            helm.BaseArmorRating = 45;
            helm.ArmorAttributes.LowerStatReq = 15;
            helm.Attributes.BonusHits = 15;
            helm.Attributes.BonusMana = 10;
            helm.Attributes.NightSight = 1;
            helm.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            helm.ColdBonus = 7;
            helm.EnergyBonus = 8;
            helm.FireBonus = 7;
            helm.PhysicalBonus = 12;
            helm.PoisonBonus = 10;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateClothing()
        {
            // Monk's robe
            MonkRobe robe = new MonkRobe();
            robe.Name = "Robe of the Enlightened Monk";
            robe.Hue = 1281;
            robe.Attributes.Luck = 75;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.RegenMana = 3;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLoreBook()
        {
            return new ChronicleOfLanXang();
        }

        // Unique decorative “Buddha statue” – using a JadeSkull as the base for a jade Buddha
        public class MekongJadeBuddha : JadeSkull
        {
            [Constructable]
            public MekongJadeBuddha()
            {
                Name = "Jade Buddha of the Mekong";
                Hue = 1272;
                Weight = 5.0;
            }

            public MekongJadeBuddha(Serial serial) : base(serial) { }

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

        public TreasureChestOfLanXang(Serial serial) : base(serial) { }

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

    // Lore book about Laos, the Land of a Million Elephants
    public class ChronicleOfLanXang : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Lan Xang", "A Court Historian",
            new BookPageInfo
            (
                "In the shadow of misty mountains,",
                "beside the mighty Mekong, rose",
                "a kingdom of splendor, faith,",
                "and elephants: Lan Xang,",
                "the Land of a Million Elephants.",
                "",
                "Founded in 1353 by Fa Ngum,",
                "it flourished for centuries."
            ),
            new BookPageInfo
            (
                "The kings ruled from Luang Prabang,",
                "where golden stupas crowned the hills,",
                "and riverboats brought riches.",
                "Monks walked beneath frangipani,",
                "their robes saffron in the dawn,",
                "chanting the old Pali verses",
                "that echo through temples",
                "to this day."
            ),
            new BookPageInfo
            (
                "Lan Xang was famed for its peace,",
                "its art, and its elephants.",
                "Armies rode beside holy naga,",
                "defending the kingdom’s borders.",
                "Yet, even the mightiest elephant",
                "cannot outrun time.",
                "",
                "Divided at last, Lan Xang fell."
            ),
            new BookPageInfo
            (
                "But the spirit of the land endured:",
                "in the laughter of children",
                "splashing in the Mekong;",
                "in the monks at morning alms;",
                "in the gilded temples shining",
                "across three kingdoms.",
                "",
                "Lan Xang lives in every Lao heart."
            ),
            new BookPageInfo
            (
                "May those who open this chest",
                "remember the wisdom of Fa Ngum:",
                "",
                "‘A strong heart builds a strong land.’",
                "",
                "",
                "Fortune and peace to you, traveler.",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfLanXang() : base(false)
        {
            Hue = 1272; // Jade green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Lan Xang");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Lan Xang");
        }

        public ChronicleOfLanXang(Serial serial) : base(serial) { }

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
