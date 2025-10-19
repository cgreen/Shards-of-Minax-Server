using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfGreatZimbabwe : WoodenChest
    {
        [Constructable]
        public TreasureChestOfGreatZimbabwe()
        {
            Name = "Treasure Chest of Great Zimbabwe";
            Hue = 2208; // Deep, golden stone color

            // Add items to the chest
            AddItem(new RandomFancyBanner(), 0.08);
            AddItem(CreateDecorItem<ArtifactLargeVase>("Vessel of the Shona Ancestors", 2412), 0.20);
            AddItem(CreateDecorItem<WolfStatue>("Stone Lion Sentinel", 2101), 0.17);
            AddItem(CreateDecorItem<GoldBricks>("Ingots of Munhumutapa", 1366), 0.16);
            AddItem(CreateDecorItem<Basket1Artifact>("Woven Basket of Baobab Fruit", 2218), 0.22);
            AddItem(CreateDecorItem<QuagmireZooStatuette>("Great Zimbabwe Bird Statuette", 1175), 0.10);

            AddItem(CreateNamedItem<Muffins>("Millet Bread of the Plateau"), 0.20);
            AddItem(CreateNamedItem<BottleArtifact>("Lion's Courage Brew"), 0.14);
            AddItem(CreateColoredItem<Gold>("Zimbabwean Gold Coin", 1366), 0.21);
            AddItem(CreateNamedItem<GreenTea>("Baobab Leaf Infusion"), 0.18);

            AddItem(CreateMbira(), 0.12);
            AddItem(CreateShonaCloak(), 0.15);
            AddItem(CreateMinerBoots(), 0.16);
            AddItem(CreateZebraShield(), 0.13);

            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateShamanKilt(), 0.14);

            AddItem(new ChroniclesOfZimbabwe(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Items
        private Item CreateDecorItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Simple colored item
        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Simple named item
        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        // Unique Equipment
        private Item CreateMbira()
        {
            // Use a decorative instrument as base
            RandomFancyInstrument mbira = new RandomFancyInstrument();
            mbira.Name = "Mbira of the Stone City";
            mbira.Hue = 2212;
            return mbira;
        }

        private Item CreateShonaCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Shona Spirit";
            cloak.Hue = 2412;
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.LowerManaCost = 8;
            cloak.Attributes.Luck = 60;
            cloak.SkillBonuses.SetValues(0, SkillName.AnimalLore, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateMinerBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Prospector's Boots of Gold";
            boots.Hue = 1366;
            boots.Attributes.BonusStam = 12;
            boots.Attributes.BonusStr = 7;
            boots.SkillBonuses.SetValues(0, SkillName.Mining, 20.0);
            boots.Attributes.Luck = 40;
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateZebraShield()
        {
            ChaosShield shield = new ChaosShield();
            shield.Name = "Zebra-Striped Shield";
            shield.Hue = 1153;
            shield.Attributes.DefendChance = 16;
            shield.Attributes.RegenHits = 5;
            shield.ArmorAttributes.LowerStatReq = 15;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateWeapon()
        {
            // Gold-inlaid Scimitar (using Scimitar as base)
            Scimitar weapon = new Scimitar();
            weapon.Name = "Gold-Inlaid Zimbabwean Scimitar";
            weapon.Hue = 1366;
            weapon.MinDamage = Utility.Random(22, 36);
            weapon.MaxDamage = Utility.Random(38, 64);
            weapon.Attributes.BonusStr = 8;
            weapon.Attributes.WeaponSpeed = 14;
            weapon.Attributes.AttackChance = 10;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            // Stone King's Chestplate
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of the Stone King";
            armor.Hue = 2208;
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.BonusHits = 25;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ColdBonus = 10;
            armor.EnergyBonus = 10;
            armor.PhysicalBonus = 15;
            armor.FireBonus = 10;
            armor.PoisonBonus = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Tracking, 15.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateShamanKilt()
        {
            FancyKilt kilt = new FancyKilt();
            kilt.Name = "Shaman's Kilt of Rainmaking";
            kilt.Hue = 1133;
            kilt.Attributes.BonusInt = 9;
            kilt.Attributes.LowerRegCost = 14;
            kilt.Attributes.SpellDamage = 10;
            kilt.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 12.0);
            kilt.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(kilt, new XmlLevelItem());
            return kilt;
        }

        public TreasureChestOfGreatZimbabwe(Serial serial) : base(serial)
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

    public class ChroniclesOfZimbabwe : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Great Zimbabwe", "Mambo Nyatsimba Mutota",
            new BookPageInfo
            (
                "In the heart of Africa,",
                "rises the city of stone.",
                "Here, we built walls that",
                "defy time, trading gold",
                "for wisdom, cattle for",
                "peace. The birds of",
                "Zimbabwe soar high above,",
                "watching all."
            ),
            new BookPageInfo
            (
                "I am Mutota, first of the",
                "Mambos, ruler by right,",
                "chosen by ancestors and",
                "the spirits of the land.",
                "From the Zambezi to the",
                "Limpopo, our reach grew.",
                "Our stones whisper history,",
                "our gold gleams with pride."
            ),
            new BookPageInfo
            (
                "Traders come from far",
                "Arabia, India, bringing",
                "cloth and glass for our",
                "ivory and copper. Our",
                "women and men dance in the",
                "moonlight, their music,",
                "the voice of the mbira,",
                "echoes forever."
            ),
            new BookPageInfo
            (
                "Yet, the greatness of a",
                "kingdom lies not in stone,",
                "but in people. The Shona",
                "endure. Our cattle, our",
                "fields, our children—they",
                "carry our legacy.",
                "May you honor the ancestors.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Beware, treasure-seeker.",
                "Respect these halls, for",
                "they are sacred. The",
                "ancient spirits may judge",
                "the greedy and reward the",
                "wise. May you find gold,",
                "but also wisdom.",
                "",
                "- Mambo Mutota"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfZimbabwe() : base(false)
        {
            Hue = 2208; // Earthy gold-stone color
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Great Zimbabwe");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Great Zimbabwe");
        }

        public ChroniclesOfZimbabwe(Serial serial) : base(serial) { }

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
