using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheCongo : MetalChest
    {
        [Constructable]
        public TreasureChestOfTheCongo()
        {
            Name = "Treasure Chest of the Congo";
            Hue = 2419; // Deep jungle green

            // Add items to the chest
            AddItem(CreateSpiritIdol(), 0.10);
            AddItem(CreateDecorativeIvoryMask(), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Nzinga", 0x8A5), 0.17);
            AddItem(CreateNamedItem<RandomFancyStatue>("Nkisi Monkey Fetish", 0x430), 0.14);
            AddItem(CreateColoredItem<GreaterCurePotion>("River Spirits' Healing Draught", 2051), 0.16);
            AddItem(CreateNamedItem<GoldEarrings>("Ivory Loop Earrings", 0x47E), 0.14);
            AddItem(CreateUniqueWeapon(), 0.19);
            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateExplorerCloak(), 0.19);
            AddItem(CreateDrummersCap(), 0.17);
            AddItem(CreateMap(), 0.08);
            AddItem(new ChroniclesOfTheCongo(), 1.0);
            AddItem(CreateGoldItem("Kongolese Cowries", 0x481), 0.21);
            AddItem(CreateColoredItem<Diamond>("Emerald of the Rainforest", 2203), 0.10);
            AddItem(CreateRareFood(), 0.14);
            AddItem(CreateNamedItem<Drums>("Sacred Drum of Mboka", 0x845), 0.11);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateSpiritIdol()
        {
            ChangelingStatue idol = new ChangelingStatue();
            idol.Name = "Nkisi Nkondi Spirit Idol";
            idol.Hue = 2408; // Brown-wooden
            return idol;
        }

        private Item CreateDecorativeIvoryMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Ivory Mask of the Forest Shaman";
            mask.Hue = 1153;
            mask.Attributes.BonusInt = 7;
            mask.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            mask.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateGoldItem(string name, int hue)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Hue = hue;
            gold.Amount = Utility.Random(1000, 4000);
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
            if (hue > 0) item.Hue = hue;
            return item;
        }

        private Item CreateUniqueWeapon()
        {
            Scythe weapon = new Scythe();
            weapon.Name = "Konda of the Rain King";
            weapon.Hue = 2051; // Deep green jade
            weapon.MinDamage = 38;
            weapon.MaxDamage = 65;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.BonusStam = 20;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitPoisonArea = 10;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateUniqueArmor()
        {
            BoneChest armor = new BoneChest();
            armor.Name = "Armor of the Leopard King";
            armor.Hue = 1875; // Leopard gold
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusHits = 30;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.Luck = 40;
            armor.ColdBonus = 10;
            armor.FireBonus = 8;
            armor.PoisonBonus = 30;
            armor.EnergyBonus = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateExplorerCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Belgian Explorer";
            cloak.Hue = 1151; // Faded blue
            cloak.Attributes.RegenMana = 6;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateDrummersCap()
        {
            FeatheredHat cap = new FeatheredHat();
            cap.Name = "Cap of the Royal Drummer";
            cap.Hue = 1369;
            cap.Attributes.BonusDex = 10;
            cap.SkillBonuses.SetValues(0, SkillName.Musicianship, 20.0);
            cap.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Congo River Basin";
            map.Bounds = new Rectangle2D(4500, 1500, 700, 700);
            map.NewPin = new Point2D(4850, 1800);
            map.Protected = true;
            return map;
        }

        private Item CreateRareFood()
        {
            Banana fruit = new Banana();
            fruit.Name = "Wild Plantain of the Congo";
            fruit.Hue = 2137;
            return fruit;
        }

        public TreasureChestOfTheCongo(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheCongo : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Congo", "Nkosi wa Mboka",
            new BookPageInfo
            (
                "From the river's cradle,",
                "Kongo rose—Nzadi a Nzenge,",
                "the river that swallows all rivers.",
                "Forests thick as history’s shadow,",
                "kings crowned in ivory,",
                "spirits dwelling in every tree."
            ),
            new BookPageInfo
            (
                "The Leopard King danced with fire,",
                "and earth gave up copper, gold,",
                "diamonds hidden deep beneath",
                "the roots of ancient time.",
                "Nkisi Nkondi—spirits awoken",
                "by iron nails and desperate prayers."
            ),
            new BookPageInfo
            (
                "Portuguese ships on salt foam,",
                "crosses and cannons,",
                "trade for cloth, for muskets,",
                "for men stolen into the world’s dark belly.",
                "Still, we sang in the old tongue—",
                "Nkisi, river, home."
            ),
            new BookPageInfo
            (
                "White ghosts came with hunger,",
                "a red king ruled with iron hand,",
                "and rivers ran not just with fish",
                "but with sorrow and rubber and blood.",
                "Villages burned, drums silenced,",
                "but the forests remembered."
            ),
            new BookPageInfo
            (
                "Now, Congo’s treasures lie hidden:",
                "the Mask of Ivory Wisdom,",
                "Emeralds from the forest gods,",
                "the Drum that thunders truth,",
                "and the Konda blade that drinks",
                "the tears of fallen kings."
            ),
            new BookPageInfo
            (
                "Let the seeker remember:",
                "Power is a river; riches a snare.",
                "To disturb the Congo’s spirits",
                "is to awaken more than gold.",
                "",
                "- Nkosi wa Mboka"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheCongo() : base(false)
        {
            Hue = 2406; // Jungle green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Congo");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Congo");
        }

        public ChroniclesOfTheCongo(Serial serial) : base(serial) { }

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
