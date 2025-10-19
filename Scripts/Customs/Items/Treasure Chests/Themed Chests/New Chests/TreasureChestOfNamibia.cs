using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNamibia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNamibia()
        {
            Name = "Treasure Chest of Namibia’s History";
            Hue = 2101; // Sandy Desert

            // Add themed items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateNamedArtifact<ArtifactVase>("Etosha Salt Pan Relic", 2006), 0.16);
            AddItem(CreateNamedArtifact<CrystalBallStatuette>("San Spirit Stone", 2125), 0.11);
            AddItem(CreateNamedArtifact<BakeKitsuneStatue>("Desert Fox Idol", 2233), 0.18);
            AddItem(CreateNamedArtifact<GoldBricks>("Kolmanskop Gold Bar", 1358), 0.21);
            AddItem(CreateNamedArtifact<FancyPainting>("Sunset Over Sossusvlei", 2522), 0.16);
            AddItem(CreateConsumable("Herero Herbal Remedy", 1193), 0.14);
            AddItem(CreateConsumable("Desert Survival Rations", 1217), 0.15);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateJewelry(), 0.15);
            AddItem(new Gold(Utility.Random(1500, 4500)), 0.30);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateNamedArtifact<IncenseBurner>("Ovambo Incense Burner", 1175), 0.13);
            AddItem(CreateNamedArtifact<AncientWeapon1>("Damara Ceremonial Blade", 1150), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfNamibia();
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of Namibia";
            map.Bounds = new Rectangle2D(1000, 1900, 1200, 1800);
            map.NewPin = new Point2D(1340, 2250);
            map.Protected = true;
            return map;
        }

        private Item CreateNamedArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable(string name, int hue)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            return potion;
        }

        private Item CreateJewelry()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of Windhoek";
            bracelet.Hue = 1275;
            bracelet.Attributes.Luck = 50;
            bracelet.Attributes.BonusStam = 15;
            bracelet.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Namib Wanderer";
            robe.Hue = Utility.RandomList(2101, 2225, 1161, 1501); // earth/desert tones
            robe.Attributes.BonusHits = 20;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.LowerManaCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Tracking, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm());
            armor.Name = "Armor of the Herero Guardian";
            armor.Hue = Utility.RandomList(1119, 2115, 2055);
            armor.BaseArmorRating = Utility.Random(35, 75);
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.SelfRepair = 4;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Spear(), new Scimitar(), new CompositeBow(), new Club());
            weapon.Name = "Legendary Spear of Chief Maharero";
            weapon.Hue = Utility.RandomList(2006, 1175, 1111);
            weapon.MaxDamage = Utility.Random(36, 66);
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.BonusStam = 10;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitLowerAttack = 20;
            weapon.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Swords, 14.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        public TreasureChestOfNamibia(Serial serial) : base(serial) { }

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

    public class ChroniclesOfNamibia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Namibia", "Amadhila, Keeper of Stories",
            new BookPageInfo
            (
                "From the crimson sands of the",
                "Namib, the world's oldest desert,",
                "to the fertile banks of the Okavango,",
                "our land holds tales carved by",
                "time. Before stone and iron, the",
                "San people painted their stories",
                "on ancient rocks—dancing with",
                "antelopes beneath a burning sun."
            ),
            new BookPageInfo
            (
                "Great herds roamed the Etosha",
                "Pan. Spirits whispered in the",
                "wind, and warriors walked the",
                "Kalahari. The Damara and",
                "Nama wandered, free as the",
                "oryx. Then strangers came.",
                "Ships from cold lands brought",
                "trade, then chains."
            ),
            new BookPageInfo
            (
                "German banners rose in the",
                "shadow of the dunes. The Herero",
                "and Nama fought for their lives,",
                "defending land and memory.",
                "Battles turned the desert red.",
                "The world shifted. Empires fell.",
                "Namibia endured."
            ),
            new BookPageInfo
            (
                "As the century turned, Windhoek",
                "grew from fort to city. The land",
                "waited. In the towns and among",
                "the dunes, voices rose for freedom.",
                "SWAPO banners caught the sun.",
                "Sacrifice gave birth to a nation.",
                "Independence came in 1990."
            ),
            new BookPageInfo
            (
                "Yet the desert is eternal. Oryx",
                "still run. The San still paint.",
                "From Fish River Canyon to the",
                "Skeleton Coast, spirits of past",
                "and future watch. To open this",
                "chest is to hold centuries of hope,",
                "struggle, and dream in your hands."
            ),
            new BookPageInfo
            (
                "Take these treasures, traveler,",
                "but remember the sands hold",
                "memories not easily given. What",
                "you carry now is not just gold,",
                "but the breath of ancient winds.",
                "",
                "- Amadhila, Story Keeper"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfNamibia() : base(false)
        {
            Hue = 2101; // sandy book
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Namibia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Namibia");
        }

        public ChroniclesOfNamibia(Serial serial) : base(serial) { }

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
