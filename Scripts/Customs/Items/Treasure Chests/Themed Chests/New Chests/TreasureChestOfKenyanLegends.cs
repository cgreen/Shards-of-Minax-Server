using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfKenyanLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfKenyanLegends()
        {
            Name = "Treasure Chest of Kenyan Legends";
            Hue = 2403; // Rich earthy-red (Maasai shuka color!)

            // Unique decorative artifacts
            AddItem(CreateColoredItem<ArtifactLargeVase>("Swahili Trader's Vase", 1175), 0.15);
            AddItem(CreateColoredItem<WolfStatue>("Simba Guardian Statue", 1359), 0.12);
            AddItem(CreateColoredItem<CraneZooStatuette>("Sacred Ibis Idol", 1266), 0.13);
            AddItem(CreateColoredItem<MapOfTheKnownWorld>("Map of the Great Rift Valley", 2520), 0.08);
            AddItem(CreateColoredItem<GoldBricks>("Lost Gold of Kilwa", 1372), 0.06);
            AddItem(CreateColoredItem<BambooStoolArtifact>("Throne of the Kikuyu Elder", 1459), 0.09);
            AddItem(CreateColoredItem<DecorativeShield3>("Shield of the Mau Mau", 2425), 0.08);

            // Special consumables & loot
            AddItem(CreateColoredItem<GreaterHealPotion>("Susu of Mt. Kenya (Magic Spring Water)", 94), 0.18);
            AddItem(CreateColoredItem<GreenTea>("Maasai Chai Brew", 2115), 0.14);
            AddItem(CreateColoredItem<RandomFruitBasket>("Basket of Rift Valley Fruits", 1260), 0.15);
            AddItem(CreateColoredItem<HoneydewMelon>("Tsavo Sweet Melon", 2053), 0.13);
            AddItem(CreateColoredItem<Quiche>("Nyama Choma Platter", 2091), 0.11);
            AddItem(CreateColoredItem<CoffeeMug>("Kericho Brewed Coffee", 2445), 0.08);

            // Lore book
            AddItem(new ChroniclesOfKenyanLegends(), 1.0);

            // Unique, powerful equipment (clothing, armor, weapons)
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateClothing(), 0.15);

            // Gold and unique coin
            AddItem(CreateGoldItem("Golden Shell Coin of Lamu"), 0.19);
            AddItem(new Gold(Utility.Random(1500, 6000)), 0.16);
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateWeapon()
        {
            // Maasai Lion Spear
            Spear spear = new Spear();
            spear.Name = "Spear of the Maasai Lion";
            spear.Hue = 1161;
            spear.MinDamage = 40;
            spear.MaxDamage = 70;
            spear.Attributes.BonusHits = 30;
            spear.Attributes.BonusStam = 15;
            spear.Attributes.AttackChance = 15;
            spear.WeaponAttributes.HitLightning = 20;
            spear.WeaponAttributes.SelfRepair = 6;
            spear.WeaponAttributes.HitHarm = 15;
            spear.Slayer = SlayerName.ReptilianDeath; // Slays snakes, referencing Kenya's famous wildlife
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            spear.SkillBonuses.SetValues(1, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateArmor()
        {
            // Rhino Hide Plate Chest
            PlateChest armor = new PlateChest();
            armor.Name = "Rhino Hide Plate";
            armor.Hue = 2406;
            armor.BaseArmorRating = 58;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStr = 15;
            armor.Attributes.Luck = 100;
            armor.Attributes.RegenHits = 3;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Kitenge Robe of the High Shaman
            Robe robe = new Robe();
            robe.Name = "Kitenge Robe of the High Shaman";
            robe.Hue = Utility.RandomList(1154, 2101, 1356, 1192, 2432); // vibrant East African hues
            robe.Attributes.NightSight = 1;
            robe.Attributes.BonusMana = 15;
            robe.Attributes.RegenMana = 3;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.LowerRegCost = 15;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfKenyanLegends(Serial serial) : base(serial) { }

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

    public class ChroniclesOfKenyanLegends : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Kenyan Legends", "Elder Mzee Wa Nyota",
            new BookPageInfo
            (
                "In the time before time,",
                "when the Great Rift split",
                "the land and spirits",
                "walked the open plains,",
                "our ancestors roamed",
                "beside the herds. From",
                "the heights of Mt. Kenya",
                "to the distant Indian Sea."
            ),
            new BookPageInfo
            (
                "The Maasai leaped with lions,",
                "guardians of the savannah.",
                "Kikuyu found wisdom where",
                "the fig tree grows,",
                "Luo followed rivers to",
                "the blue lakes,",
                "Mijikenda kept secrets in",
                "sacred kaya forests."
            ),
            new BookPageInfo
            (
                "Invaders came from distant",
                "lands—traders, sultans,",
                "raiders, colonists. Our",
                "stories woven with pain and",
                "pride. For every shackle,",
                "a broken chain. For every",
                "loss, a legend rising."
            ),
            new BookPageInfo
            (
                "The Mau Mau warriors hid",
                "in forest shadows, fighting",
                "for the dawn. The drums",
                "called, and the mountains",
                "echoed back: Uhuru! Freedom!",
                "And so the land awoke,",
                "the lions roared anew."
            ),
            new BookPageInfo
            (
                "Now the baobab remembers.",
                "The flamingo dances on",
                "Lake Nakuru's bright waters.",
                "Children hear the tales of",
                "elders—of magic, of struggle,",
                "of hope like sunrise over",
                "Ngong Hills, shining eternal."
            ),
            new BookPageInfo
            (
                "Whoever finds this chest,",
                "let them carry Kenya's",
                "story. Let the legends",
                "guide your way, as the",
                "stars guide the traveler",
                "across endless night.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "For our past is memory.",
                "Our future, a promise.",
                "Our land, forever magic.",
                "– Elder Mzee Wa Nyota",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfKenyanLegends() : base(false)
        {
            Hue = 2403; // Maasai red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Kenyan Legends");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Kenyan Legends");
        }

        public ChroniclesOfKenyanLegends(Serial serial) : base(serial) { }

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
