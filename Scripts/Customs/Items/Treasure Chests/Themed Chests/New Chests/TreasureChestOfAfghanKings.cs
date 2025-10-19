using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAfghanKings : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAfghanKings()
        {
            Name = "Treasure Chest of the Afghan Kings";
            Hue = 1369; // Earthy Afghan bronze hue

            AddItem(CreateNamedItem<GoldBracelet>("Koh-i-Noor Replica"), 0.20);
            AddItem(CreateMap(), 0.10);
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.25);
            AddItem(CreateDecorativeItem<ArcaneTable>("Silk Road Trade Table", 2405), 0.20);
            AddItem(CreateDecorativeItem<ObsidianSkull>("Skull of the Hindu Kush", 1109), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Elixir of Bactrian Vitality", 2963), 0.20);
            AddItem(CreateDecorativeItem<MedusaStatue>("Statue of Queen Soraya", 2946), 0.10);
            AddItem(CreateGoldItem("Afghan Gold Dinar"), 0.15);
            AddItem(CreateDecorativeItem<LibraryFriendLantern>("Kabul Reading Lantern", 2120), 0.20);
            AddItem(CreateDecorativeItem<DecorativeShield3>("Shield of the Durrani Empire", 1175), 0.20);
            AddItem(CreateNamedItem<GreaterHealPotion>("Herbal Infusion of Khorasan"), 0.15);
            AddItem(CreateDecorativeItem<BooksWestArtifact>("Scrolls of Ghaznavid Wisdom", 1446), 0.25);
            AddItem(new ChroniclesOfTheMountainKings(), 1.0);
            AddItem(CreateClothingItem(), 0.20);
            AddItem(CreateNamedItem<Dagger>("Knife of Babur"), 0.25);
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
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of the Khyber Pass";
            map.Bounds = new Rectangle2D(2000, 2500, 300, 300);
            map.NewPin = new Point2D(2150, 2650);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            Scimitar sword = new Scimitar();
            sword.Name = "Scimitar of the Pashtun Warlord";
            sword.Hue = 2413;
            sword.MaxDamage = Utility.Random(45, 75);
            sword.WeaponAttributes.HitLeechHits = 15;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Breastplate of the Samanid Guard";
            armor.Hue = 2715;
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.ArmorAttributes.MageArmor = 1;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothingItem()
        {
            Robe robe = new Robe();
            robe.Name = "Royal Robe of Zahir Shah";
            robe.Hue = 1160;
            robe.Attributes.RegenMana = 3;
            robe.Attributes.Luck = 100;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfAfghanKings(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheMountainKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Mountain Kings", "Anonymous Scribe of Balkh",
            new BookPageInfo
            (
                "In lands carved by time and",
                "stone, from the harsh peaks",
                "of the Hindu Kush to the",
                "dust of Herat, kings have",
                "risen and fallen like the",
                "desert wind. Afghanistan,",
                "a place of passage and",
                "power."
            ),
            new BookPageInfo
            (
                "The Greco-Bactrians walked",
                "where the Achaemenids once",
                "ruled. Kushans forged trade",
                "to the east. Through this",
                "place ran silk and iron,",
                "gold and blood. The world",
                "met in its valleys, and",
                "clashed in its passes."
            ),
            new BookPageInfo
            (
                "Mahmud of Ghazni rode",
                "forth with sword and prayer.",
                "The Ghorids, the Timurids,",
                "the Mughals — each left a",
                "legacy in ruin and stone.",
                "Yet none could tame the",
                "tribes of the mountains.",
                ""
            ),
            new BookPageInfo
            (
                "Then came empires: British,",
                "Soviet, and whispers of",
                "the West. Yet still the",
                "Afghan endures. A shepherd",
                "with a rifle, a child with",
                "a poem. They bury their",
                "heroes in silence and",
                "sing their names in fire."
            ),
            new BookPageInfo
            (
                "They call themselves lions.",
                "Brothers to wolves. Sons",
                "of wind and hardship.",
                "Heirs to a land that breaks",
                "empires like brittle clay.",
                "To rule Afghanistan is to",
                "hold water in one’s hand.",
                ""
            ),
            new BookPageInfo
            (
                "If you have found this,",
                "then tread with reverence.",
                "This chest is not merely",
                "treasure. It is memory,",
                "and grief, and war, and",
                "wonder.",
                "",
                "- Keeper of the Sands"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheMountainKings() : base(false)
        {
            Hue = 2712; // Dark earthy-red for Afghan terrain
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Mountain Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Mountain Kings");
        }

        public ChroniclesOfTheMountainKings(Serial serial) : base(serial) { }

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
