using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSierraLeone : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSierraLeone()
        {
            Name = "Treasure Chest of Sierra Leone";
            Hue = 1150; // Ocean blue

            // Add items to the chest
            AddItem(new ChroniclesOfSierraLeone(), 1.0);
            AddItem(CreateDecorativeMask(), 0.16);
            AddItem(CreateDiamondArtifact(), 0.18);
            AddItem(CreateColoredItem<GreaterHealPotion>("Bai Bureh's Rejuvenating Brew", 1366), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Koya Kingdom"), 0.15);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Mende Queen"), 0.13);
            AddItem(CreateGoldItem("Freetown Coin"), 0.15);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateFood(), 0.19);
            AddItem(CreateCulturalClothing(), 0.22);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateAmulet(), 0.18);
            AddItem(CreateColoredItem<Sapphire>("Sapphire of the Lion Mountains", 1367), 0.11);
            AddItem(CreateNamedItem<Sextant>("Explorer’s Navigational Sextant"), 0.08);
            AddItem(new Gold(Utility.Random(1, 6000)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mende Ritual Mask";
            mask.Hue = 1372;
            mask.LootType = LootType.Blessed;
            return mask;
        }

        private Item CreateDiamondArtifact()
        {
            Diamond diamond = new Diamond();
            diamond.Name = "Star of Sierra Leone";
            diamond.Hue = 2498; // Brilliant white
            return diamond;
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

        private Item CreateFood()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Tropical Bounty of Sierra Leone";
            return basket;
        }

        private Item CreateCulturalClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Krio Elder's Robe";
            robe.Hue = 1150;
            robe.Attributes.Luck = 30;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.BonusHits = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateWeapon()
        {
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Sword of Freedom";
            scimitar.Hue = 1109;
            scimitar.MinDamage = 25;
            scimitar.MaxDamage = 55;
            scimitar.Attributes.WeaponSpeed = 30;
            scimitar.Attributes.WeaponDamage = 30;
            scimitar.Attributes.BonusStam = 10;
            scimitar.Attributes.ReflectPhysical = 15;
            scimitar.Attributes.CastSpeed = 1;
            scimitar.WeaponAttributes.HitLeechHits = 20;
            scimitar.WeaponAttributes.HitLightning = 25;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Lionheart Chestplate";
            chest.Hue = 1157;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusHits = 20;
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.AbsorptionAttributes.EaterFire = 8;
            chest.AbsorptionAttributes.EaterCold = 8;
            chest.Attributes.DefendChance = 15;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateAmulet()
        {
            GoldNecklace amulet = new GoldNecklace();
            amulet.Name = "Amulet of Resilience";
            amulet.Hue = 1175;
            amulet.Attributes.RegenHits = 3;
            amulet.Attributes.RegenStam = 3;
            amulet.Attributes.RegenMana = 3;
            amulet.Attributes.Luck = 35;
            amulet.Attributes.BonusStr = 5;
            amulet.SkillBonuses.SetValues(0, SkillName.Focus, 10.0);
            amulet.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            return amulet;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lion Mountains";
            map.Bounds = new Rectangle2D(900, 1200, 700, 700);
            map.NewPin = new Point2D(1300, 1700);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSierraLeone(Serial serial) : base(serial) { }

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

    public class ChroniclesOfSierraLeone : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Sierra Leone", "Anonymous Elder",
            new BookPageInfo
            (
                "In the shadow of Lion",
                "Mountains, rivers of hope",
                "and pain have run for",
                "centuries. Once, kingdoms",
                "of the Mende and Temne",
                "flourished, their people",
                "carving stories in wood",
                "and song."
            ),
            new BookPageInfo
            (
                "Foreign ships came with",
                "promises, but brought",
                "chains. From Bance",
                "Island, sorrow sailed",
                "across the sea. Yet in",
                "the age of return,",
                "freed souls from distant",
                "lands stepped ashore."
            ),
            new BookPageInfo
            (
                "They built Freetown, a",
                "beacon for the lost.",
                "Kings and chiefs joined,",
                "fought, united, fell.",
                "Through fire and civil",
                "war, the lion’s heart",
                "still beat—wounded, but",
                "undaunted."
            ),
            new BookPageInfo
            (
                "Diamonds gleamed in the",
                "earth, their beauty both",
                "blessing and curse. Hands",
                "were stained red, yet",
                "dreams of peace and",
                "prosperity shone brighter.",
                "Culture survived in dance,",
                "in stories and drums."
            ),
            new BookPageInfo
            (
                "Now, the green hills",
                "whisper with the voices",
                "of ancestors. Unity is",
                "the shield, and hope the",
                "sword. To find this",
                "chest is to hold the",
                "legacy of Sierra Leone—",
                "enduring, brilliant."
            ),
            new BookPageInfo
            (
                "May you honor the spirit",
                "of this land. May you",
                "carry its memory, as",
                "the lion carries the",
                "dawn. For history is a",
                "river, and the people of",
                "Sierra Leone are its",
                "endless tide."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfSierraLeone() : base(false)
        {
            Hue = 1150; // Ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Sierra Leone");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Sierra Leone");
        }

        public ChroniclesOfSierraLeone(Serial serial) : base(serial) { }

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
