using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfEswatini : WoodenChest
    {
        [Constructable]
        public TreasureChestOfEswatini()
        {
            Name = "Treasure Chest of the Kingdom of Eswatini";
            Hue = 2101; // Rich blue, inspired by the national flag

            // Add unique, themed items
            AddItem(new LionStatueOfTheSavannah(), 0.16);
            AddItem(CreateColoredItem<GreaterHealPotion>("King Mswati’s Royal Elixir", 2117), 0.12);
            AddItem(CreateNamedItem<GoldBracelet>("Swazi Reed Dance Bracelet"), 0.18);
            AddItem(CreateGoldItem("Emalangeni Coin"), 0.20);
            AddItem(CreateColoredItem<FlowersArtifact>("Bouquet of Marula Blossoms", 2206), 0.16);
            AddItem(CreateNamedItem<BodySash>("Sash of the Umhlanga", 2156), 0.18);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.17);
            AddItem(CreateSwaziShield(), 0.18);
            AddItem(CreateRoyalCloak(), 0.13);
            AddItem(new ChroniclesOfEswatini(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7000)), 0.18);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateDecorativePot(), 0.13);
            AddItem(CreateTraditionalHeadgear(), 0.12);
            AddItem(CreateFoodItem(), 0.19);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Great Chief"), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Marula Nut Earring"), 0.14);
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
            map.Name = "Map of the Ezulwini Valley";
            map.Bounds = new Rectangle2D(3200, 3500, 300, 300);
            map.NewPin = new Point2D(3325, 3620);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Scimitar(), new Spear());
            weapon.Name = "Nguni Warrior’s Blade";
            weapon.Hue = Utility.RandomList(1107, 1289, 2101);
            weapon.MaxDamage = Utility.Random(35, 65);
            weapon.Attributes.BonusStr = 10;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.HitLeechHits = 12;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(new LeatherDo(), new PlateChest());
            armor.Name = "Royal Armor of Eswatini";
            armor.Hue = Utility.RandomList(1151, 2117, 2101);
            armor.BaseArmorRating = Utility.Random(35, 72);
            armor.Attributes.BonusHits = 18;
            armor.Attributes.RegenHits = 3;
            armor.Attributes.LowerManaCost = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateSwaziShield()
        {
            BashingShield shield = new BashingShield();
            shield.Name = "Nguni Cowhide Shield";
            shield.Hue = 2101;
            shield.Attributes.BonusStr = 7;
            shield.Attributes.SpellChanneling = 1;
            shield.SkillBonuses.SetValues(0, SkillName.Anatomy, 9.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateRoyalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Royal Cloak of Eswatini";
            cloak.Hue = 2117;
            cloak.Attributes.Luck = 55;
            cloak.Attributes.RegenMana = 3;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 11.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateDecorativePot()
        {
            ArtifactVase vase = new ArtifactVase();
            vase.Name = "Traditional Swazi Clay Pot";
            vase.Hue = 1107;
            return vase;
        }

        private Item CreateTraditionalHeadgear()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Chief’s Feathered Headpiece";
            hat.Hue = 1151;
            hat.Attributes.BonusDex = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Hiding, 8.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateFoodItem()
        {
            BowlOfRotwormStew bowl = new BowlOfRotwormStew();
            bowl.Name = "Stew of the Royal Homestead";
            return bowl;
        }

        public TreasureChestOfEswatini(Serial serial) : base(serial)
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

    // Unique decorative item
    public class LionStatueOfTheSavannah : WolfStatue
    {
        [Constructable]
        public LionStatueOfTheSavannah()
        {
            Name = "Lion Statue of the Savannah";
            Hue = 1167; // Gold/yellow
        }

        public LionStatueOfTheSavannah(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    // Custom Lore Book
    public class ChroniclesOfEswatini : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Eswatini", "King Mswati III",
            new BookPageInfo
            (
                "In the rolling hills and",
                "savannahs of southern",
                "Africa, a kingdom endures.",
                "Eswatini—land of the Swazi,",
                "guarded by ancestors and",
                "led by kings for centuries.",
                "We are the children of",
                "Ngwane, of Sobhuza, of Mswati."
            ),
            new BookPageInfo
            (
                "Once, our fathers wandered",
                "the valleys, herding cattle,",
                "gathering beneath the marula",
                "tree. They forged a nation",
                "with courage and tradition,",
                "resisting invaders and the",
                "changing winds of time.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Our sacred ceremonies—the",
                "Incwala of Kingship, the",
                "Umhlanga Reed Dance—bind",
                "our people in unity. Our",
                "shield is the cowhide, our",
                "strength is family, our",
                "spirit is unbroken.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "The world knows us as Swazi,",
                "but we know ourselves as",
                "Emaswati. Our land was never",
                "conquered, though colonizers",
                "came and went. When others lost",
                "their thrones, the Lion of",
                "Eswatini still ruled.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Today, we thrive between the",
                "Mbabane mountains and the Lowveld.",
                "Our crafts, our dances, our",
                "songs—these are treasures more",
                "precious than gold.",
                "",
                "",
                "",
                ""
            ),
            new BookPageInfo
            (
                "To all who discover this chest:",
                "Remember us, not just for our",
                "kings, but for our wisdom, our",
                "celebrations, our hope.",
                "",
                "The kingdom endures.",
                "",
                "- King Mswati III",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfEswatini() : base(false)
        {
            Hue = 2101; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Eswatini");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Eswatini");
        }

        public ChroniclesOfEswatini(Serial serial) : base(serial) { }

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
