using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfEritreanLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfEritreanLegacy()
        {
            Name = "Treasure Chest of Eritrean Legacy";
            Hue = 2075; // Warm gold-red reminiscent of Eritrean flag

            // Add thematic items
            AddItem(CreateDecorativeItem<ArtifactVase>("Vase of Adulis", 2118), 0.22);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Mosaic of Aksumite Era", 1372), 0.19);
            AddItem(CreateDecorativeItem<FancyPainting>("Portrait of Queen Sheba", 1172), 0.12);
            AddItem(CreateDecorativeItem<QuagmireStatue>("Statue of the Eritrean Lion", 2401), 0.14);
            AddItem(CreateDecorativeItem<BasketOfGreenTeaMug>("Bunna Ceremony Basket", 1801), 0.18);
            AddItem(CreateDecorativeItem<FancySewingMachine>("Asmara Tailor’s Loom", 1289), 0.13);
            AddItem(CreateFoodItem<UnbakedMeatPie>("Injera Platter", 1406), 0.18);

            // Consumables
            AddItem(CreateNamedItem<GreaterHealPotion>("Tigrinya Herbal Tonic"), 0.13);
            AddItem(CreateNamedItem<GreaterCurePotion>("Red Sea Salt Tincture"), 0.12);
            AddItem(CreateNamedItem<RandomFancyBakedGoods>("Honey Pastry of Keren"), 0.17);

            // Unique gold
            AddItem(CreateGoldItem("Nakfa Coins of Resistance"), 0.18);

            // Unique Equipment (high modifiers and skill bonuses)
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateCloak(), 0.17);
            AddItem(CreateBoots(), 0.15);

            // Lore book
            AddItem(new TomeOfEritreanHistory(), 1.0);

            // Random gems and gold
            AddItem(new Gold(Utility.Random(1, 7000)), 0.12);
            AddItem(CreateDecorativeItem<Ruby>("Ruby of the Dahlak Isles", 1157), 0.11);

            // Misc artifacts
            AddItem(CreateDecorativeItem<AncientRunes>("Ancient Ge'ez Tablet", 1901), 0.13);
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

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique Powerful Equipment
        private Item CreateWeapon()
        {
            // A legendary spear, symbolizing resistance
            ShortSpear spear = new ShortSpear();
            spear.Name = "Spearthrower of Massawa";
            spear.Hue = 1177; // Deep blue (Red Sea)
            spear.MinDamage = 45;
            spear.MaxDamage = 72;
            spear.Attributes.BonusStr = 15;
            spear.Attributes.WeaponSpeed = 30;
            spear.Attributes.WeaponDamage = 50;
            spear.Attributes.CastSpeed = 2;
            spear.WeaponAttributes.HitHarm = 25;
            spear.WeaponAttributes.HitFireball = 18;
            spear.Slayer = SlayerName.ReptilianDeath;
            spear.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            spear.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            spear.SkillBonuses.SetValues(2, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateArmor()
        {
            // A legendary breastplate inspired by ancient warriors
            PlateChest armor = new PlateChest();
            armor.Name = "Adulis Guardian's Plate";
            armor.Hue = 1901; // Ancient gold
            armor.BaseArmorRating = 55;
            armor.Attributes.Luck = 120;
            armor.Attributes.BonusHits = 35;
            armor.Attributes.BonusStam = 12;
            armor.ArmorAttributes.LowerStatReq = 40;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            armor.SkillBonuses.SetValues(2, SkillName.Meditation, 8.0);
            armor.PoisonBonus = 12;
            armor.PhysicalBonus = 18;
            armor.FireBonus = 7;
            armor.ColdBonus = 5;
            armor.EnergyBonus = 9;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Mantle of Sheba's Lineage";
            cloak.Hue = 1372; // Royal purple-red
            cloak.Attributes.CastRecovery = 3;
            cloak.Attributes.BonusInt = 10;
            cloak.Attributes.LowerManaCost = 12;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            cloak.Resistances.Physical = 5;
            cloak.Resistances.Fire = 5;
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateBoots()
        {
            Sandals boots = new Sandals();
            boots.Name = "Sandals of the Highlands";
            boots.Hue = 2075; // Earthen
            boots.Attributes.BonusDex = 15;
            boots.Attributes.Luck = 45;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 20.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        public TreasureChestOfEritreanLegacy(Serial serial) : base(serial) { }

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

    public class TomeOfEritreanHistory : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Tome of Eritrean History", "Historian Tsehaye",
            new BookPageInfo
            (
                "In the land of the Red Sea coast,",
                "mountains rise and ancient cities",
                "stand: Adulis, Aksum's harbor,",
                "saw trade and cultures blend.",
                "",
                "Eritrea's story begins before",
                "Rome or Byzantium, when",
                "the Sabeans sailed and kings",
                "dreamed under starlit skies."
            ),
            new BookPageInfo
            (
                "Centuries saw the coming of",
                "empires: Aksumite, Ottoman,",
                "Italian, British. Each left",
                "marks—cathedrals, rails, and scars.",
                "",
                "Asmara blossomed with art deco,",
                "Massawa endured flame and salt.",
                "Villages kept their songs alive."
            ),
            new BookPageInfo
            (
                "But the heart of Eritrea beats",
                "with the will to be free. Wars",
                "forged unity, pain bred pride.",
                "From the valleys of Keren to the",
                "highlands of Asmara, people stood.",
                "",
                "Independence was not given; it",
                "was seized by courage, paid for"
            ),
            new BookPageInfo
            (
                "in blood. The world watched, and",
                "in 1993, Eritrea rose as a nation.",
                "Today, its colors—red, green, blue,",
                "gold—fly above an ancient land.",
                "",
                "May this chest preserve memories,",
                "honor ancestors, and inspire",
                "new legends.",
                "",
                "— Historian Tsehaye"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public TomeOfEritreanHistory() : base(false)
        {
            Hue = 2075; // Warm gold-red, matches the chest
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Tome of Eritrean History");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Tome of Eritrean History");
        }

        public TomeOfEritreanHistory(Serial serial) : base(serial) { }

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
