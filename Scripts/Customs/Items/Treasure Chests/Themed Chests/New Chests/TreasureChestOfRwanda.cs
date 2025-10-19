using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfRwanda : WoodenChest
    {
        [Constructable]
        public TreasureChestOfRwanda()
        {
            Name = "Treasure Chest of Rwanda";
            Hue = 2117; // Deep green, evokes Rwandan hills

            // Add items to the chest
            AddItem(CreateImigongoArt(), 0.25);
            AddItem(CreateGorillaStatue(), 0.18);
            AddItem(CreateNamedItem<GreaterHealPotion>("Mountain Tea Brew"), 0.14);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Unity"), 0.17);
            AddItem(CreateCoffee(), 0.23);
            AddItem(CreateWovenBasket(), 0.19);
            AddItem(CreateNamedItem<GreaterHealPotion>("Lake Kivu Honey Elixir"), 0.14);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Mwami Queen"), 0.15);
            AddItem(new ChroniclesOfRwanda(), 1.0); // Custom lore book
            AddItem(CreateGoldItem("Rwandan Franc Coin"), 0.16);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Intore Dancer"), 0.18);
            AddItem(CreateNamedItem<Sextant>("Explorer's Sextant"), 0.10);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.16);
            AddItem(CreateTraditionalRobe(), 0.15);
            AddItem(CreateHeadpiece(), 0.12);
            AddItem(CreateTraditionalDrum(), 0.10);
            AddItem(CreateBanana(), 0.25);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Artifacts
        private Item CreateImigongoArt()
        {
            Painting2WestArtifact art = new Painting2WestArtifact();
            art.Name = "Imigongo Art Panel";
            art.Hue = 1150; // Black/red geometric Rwandan art
            return art;
        }

        private Item CreateGorillaStatue()
        {
            WolfStatue statue = new WolfStatue();
            statue.Name = "Mountain Gorilla Statuette";
            statue.Hue = 1109;
            return statue;
        }

        private Item CreateWovenBasket()
        {
            Basket4Artifact basket = new Basket4Artifact();
            basket.Name = "Agaseke Peace Basket";
            basket.Hue = 2124;
            return basket;
        }

        private Item CreateTraditionalDrum()
        {
            AncientDrum drum = new AncientDrum();
            drum.Name = "Inanga Drum";
            drum.Hue = 1889;
            return drum;
        }

        // Consumables
        private Item CreateCoffee()
        {
            CoffeeMug coffee = new CoffeeMug();
            coffee.Name = "Rwandan Highland Coffee";
            coffee.Hue = 1187;
            return coffee;
        }

        private Item CreateBanana()
        {
            Banana banana = new Banana();
            banana.Name = "Sweet Plantain";
            return banana;
        }

        // Simple gold coin
        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Helper for custom-named items with optional hue
        private Item CreateNamedItem<T>(string name, int hue = -1) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        // Equipment
        private Item CreateWeapon()
        {
            // “Spear of Nyungwe” - high modifiers, unity/healing vibes
            ShortSpear spear = new ShortSpear();
            spear.Name = "Spear of Nyungwe";
            spear.Hue = 1272;
            spear.MinDamage = 30;
            spear.MaxDamage = 55;
            spear.Attributes.SpellChanneling = 1;
            spear.Attributes.RegenHits = 8;
            spear.Attributes.Luck = 150;
            spear.WeaponAttributes.HitHarm = 25;
            spear.Attributes.BonusStam = 12;
            spear.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            spear.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateArmor()
        {
            // “Umwami's Chestplate” - powerful armor
            PlateChest armor = new PlateChest();
            armor.Name = "Umwami's Chestplate";
            armor.Hue = 2125;
            armor.BaseArmorRating = 65;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.RegenHits = 10;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateTraditionalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Umushanana Ceremony Robe";
            robe.Hue = 2075;
            robe.Attributes.Luck = 75;
            robe.Attributes.BonusMana = 7;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Peacemaking, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateHeadpiece()
        {
            Circlet circlet = new Circlet();
            circlet.Name = "Intore Warrior’s Headband";
            circlet.Hue = 1995;
            circlet.BaseArmorRating = 25;
            circlet.Attributes.BonusDex = 18;
            circlet.Attributes.NightSight = 1;
            circlet.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            circlet.SkillBonuses.SetValues(1, SkillName.Tactics, 8.0);
            circlet.EnergyBonus = 10;
            circlet.FireBonus = 5;
            circlet.PhysicalBonus = 15;
            XmlAttach.AttachTo(circlet, new XmlLevelItem());
            return circlet;
        }

        public TreasureChestOfRwanda(Serial serial) : base(serial) { }

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

    public class ChroniclesOfRwanda : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Rwanda", "Narrator of the Land of a Thousand Hills",
            new BookPageInfo
            (
                "Upon the misty hills of Rwanda,",
                "ancient kingdoms rose and fell.",
                "Mwami kings ruled with wisdom and spear,",
                "Inanga music echoed from fertile valleys,",
                "drums spoke of unity, of sorrow, of hope."
            ),
            new BookPageInfo
            (
                "Here, the Gorilla is guardian and kin,",
                "The land green, the soil rich.",
                "Agaseke baskets weave peace anew,",
                "Imigongo art spirals like rivers and fate."
            ),
            new BookPageInfo
            (
                "Yet, shadow fell in '94,",
                "when brother turned against brother.",
                "A nation wept tears that filled Lake Kivu.",
                "The world watched in silence and shame."
            ),
            new BookPageInfo
            (
                "But from the ashes, hope kindled.",
                "Rwanda rose, reborn and reconciled.",
                "Unity stitched by the hands of survivors.",
                "Children's laughter returned to the hills."
            ),
            new BookPageInfo
            (
                "Coffee blossomed in volcanic earth,",
                "Tea unfurled on gentle slopes.",
                "The drums again called for peace.",
                "The spears became ploughshares."
            ),
            new BookPageInfo
            (
                "Today, Rwanda’s heart beats with life.",
                "A nation strong, a nation healed.",
                "May these treasures remind you:",
                "Even in sorrow, unity grows.",
                "Even from tragedy, beauty returns."
            ),
            new BookPageInfo
            (
                "Carry this memory from the chest.",
                "Honor the past, treasure the present.",
                "",
                "- The Land of a Thousand Hills"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfRwanda() : base(false)
        {
            Hue = 2075; // Royal blue, Rwandan flag color
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Rwanda");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Rwanda");
        }

        public ChroniclesOfRwanda(Serial serial) : base(serial) { }

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
