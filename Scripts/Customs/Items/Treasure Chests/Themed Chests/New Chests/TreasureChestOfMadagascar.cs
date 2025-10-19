using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMadagascar : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMadagascar()
        {
            Name = "Treasure Chest of Madagascar";
            Hue = 2647; // Rich jungle green

            // Add themed items
            AddItem(CreateMadagascarLoreBook(), 1.0);
            AddItem(CreateColoredItem<Sapphire>("Sapphire of the Red Island", 1276), 0.15);
            AddItem(CreateDecorativeItem<BakeKitsuneStatue>("Fanaloka Idol", 1367), 0.10);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vase of Antananarivo", 1865), 0.09);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Pirate’s Brazier", 1172), 0.12);
            AddItem(CreateDecorativeItem<ExoticFish>("Coelacanth Fossil", 2152), 0.08);
            AddItem(CreateColoredItem<GoldBracelet>("Queen Ranavalona’s Bracelet", 2415), 0.11);
            AddItem(CreateNamedItem<BodySash>("Royal Sash of Merina"), 0.16);
            AddItem(CreateNamedItem<GreenTea>("Brew of Malagasy Rainforest"), 0.17);
            AddItem(CreateGoldItem("Antemoro Gold Coin"), 0.20);
            AddItem(CreatePirateMap(), 0.08);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateLemurMask(), 0.19);
            AddItem(CreateExplorerCloak(), 0.13);
            AddItem(CreatePirateHat(), 0.16);
            AddItem(CreatePotion(), 0.13);
            AddItem(new Gold(Utility.Random(2000, 5000)), 0.13);
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

        private Item CreatePirateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Libertalia (Lost Pirate City)";
            map.Bounds = new Rectangle2D(4450, 2300, 300, 300); // Fictive coordinates
            map.NewPin = new Point2D(4550, 2400);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Scimitar(), new Dagger(), new CompositeBow()
            );
            weapon.Name = "Libertalia Pirate’s Blade";
            weapon.Hue = 1175; // Gold
            weapon.MaxDamage = Utility.Random(35, 75);
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.AttackChance = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new LeatherChest(), new StuddedArms(), new PlateLegs(), new LeatherGloves()
            );
            armor.Name = "Merina Royal Guard Armor";
            armor.Hue = Utility.RandomList(2415, 1266, 2647);
            armor.BaseArmorRating = Utility.Random(33, 66);
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.SelfRepair = 3;
            armor.ArmorAttributes.LowerStatReq = 10;
            armor.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLemurMask()
        {
            BearMask mask = new BearMask();
            mask.Name = "Aye-Aye Lemur Mask";
            mask.Hue = 1130;
            mask.Attributes.Luck = 25;
            mask.Attributes.BonusInt = 7;
            mask.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 20.0);
            mask.SkillBonuses.SetValues(1, SkillName.Hiding, 15.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateExplorerCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Malagasy Explorer";
            cloak.Hue = 2971;
            cloak.Attributes.BonusStam = 10;
            cloak.Attributes.BonusMana = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Cartography, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.DetectHidden, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreatePirateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Hat of Captain Misson";
            hat.Hue = 1157;
            hat.Attributes.RegenStam = 5;
            hat.Attributes.AttackChance = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Stealing, 20.0);
            hat.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreatePotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Malagasy Healing Elixir";
            potion.Hue = 2208;
            return potion;
        }

        private Item CreateMadagascarLoreBook()
        {
            return new BookOfTheRedIsland();
        }

        public TreasureChestOfMadagascar(Serial serial) : base(serial) { }

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

    public class BookOfTheRedIsland : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Book of the Red Island", "Queen Ranavalona I",
            new BookPageInfo
            (
                "Upon this great island,",
                "we rule from the highlands",
                "of Antananarivo to the",
                "wild coasts of the pirates.",
                "The people are many,",
                "the lemur spirits ancient,",
                "and the Red Earth eternal.",
                ""
            ),
            new BookPageInfo
            (
                "The Vazimba, first",
                "to settle these lands,",
                "spoke with the ancestors.",
                "After them came the",
                "Sakalava, Betsimisaraka,",
                "and the mighty Merina,",
                "whose power united the hills."
            ),
            new BookPageInfo
            (
                "Across the seas, pirates",
                "fled from justice and",
                "founded Libertalia.",
                "Here, gold changed hands,",
                "oaths were sworn, and",
                "freedom had a price paid",
                "in blood and rum."
            ),
            new BookPageInfo
            (
                "But storms and empires",
                "came. The island fought,",
                "and so did its queens.",
                "Spices, sapphires, and",
                "rare beasts are our",
                "birthright. Our forests",
                "hide more than men know."
            ),
            new BookPageInfo
            (
                "Let those who open",
                "this chest remember:",
                "Madagascar is the Red",
                "Island, ever untamed,",
                "rich in beauty and",
                "fierce in heart.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May the lemur spirit",
                "bring you fortune,",
                "the pirate’s luck guard",
                "your travels, and the",
                "queen’s wisdom guide",
                "your days.",
                "",
                "- Ranavalona I"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfTheRedIsland() : base(false)
        {
            Hue = 2971; // Vivid earthy red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Book of the Red Island");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Book of the Red Island");
        }

        public BookOfTheRedIsland(Serial serial) : base(serial) { }

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
