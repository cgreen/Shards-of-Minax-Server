using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfPalauanHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfPalauanHistory()
        {
            Name = "Treasure Chest of Palauan History";
            Hue = 1368; // Oceanic blue

            // Decorative, consumable, and lore items
            AddItem(CreateDecorativeShell(), 0.18);
            AddItem(CreateDecorativeCanoeModel(), 0.10);
            AddItem(CreateOceanicMap(), 0.08);
            AddItem(CreatePalauanBreadfruit(), 0.16);
            AddItem(CreatePalauanCoconutDrink(), 0.17);
            AddItem(CreateAncientChiefMask(), 0.12);
            AddItem(new TalesOfPalau(), 1.0); // Always add the lore book
            AddItem(CreateGoldenShellCoin(), 0.18);
            AddItem(CreateLegendaryPearl(), 0.10);

            // Unique equipment
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateLongPants(), 0.16);
            AddItem(CreateCloak(), 0.16);
            AddItem(CreateTribalMask(), 0.10);
            AddItem(CreateFishingTrident(), 0.15);

            // Add a little gold and random potion
            AddItem(new Gold(Utility.Random(750, 4000)), 0.17);
            AddItem(CreateColoredItem<GreaterCurePotion>("Potion of Oceanic Vitality", 1152), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Items
        private Item CreateDecorativeShell()
        {
            Random r = new Random();
            int[] hues = { 1171, 1172, 1152, 1266, 1369 }; // Ocean/pearl hues
            var shell = new LargeVase();
            shell.Name = "Sacred Giant Clamshell";
            shell.Hue = hues[r.Next(hues.Length)];
            return shell;
        }

        private Item CreateDecorativeCanoeModel()
        {
            var model = new AncientShipModelOfTheHMSCape();
            model.Name = "Palauan War Canoe Model";
            model.Hue = 1368;
            return model;
        }

        private Item CreateOceanicMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of the Rock Islands";
            map.Bounds = new Rectangle2D(2000, 1000, 700, 600);
            map.NewPin = new Point2D(2350, 1320);
            map.Protected = true;
            return map;
        }

        private Item CreateGoldenShellCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Golden Shell Coin";
            gold.Amount = Utility.Random(50, 250);
            return gold;
        }

        private Item CreateLegendaryPearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "Legendary Blue Pearl";
            pearl.Hue = 1172;
            return pearl;
        }

        // Consumables
        private Item CreatePalauanBreadfruit()
        {
            FruitPie breadfruit = new FruitPie();
            breadfruit.Name = "Palauan Breadfruit Pie";
            breadfruit.Hue = 2003;
            breadfruit.Stackable = true;
            breadfruit.Amount = Utility.RandomMinMax(2, 4);
            return breadfruit;
        }

        private Item CreatePalauanCoconutDrink()
        {
            GlassMug coconut = new GlassMug();
            coconut.Name = "Coconut Drink of the Sea Chiefs";
            coconut.Hue = 1152;
            return coconut;
        }

        // Armor/Clothing/Equipment
        private Item CreateAncientChiefMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mask of the Ancient Palauan Chief";
            mask.Hue = 1366;
            mask.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.Fishing, 15.0);
            mask.SkillBonuses.SetValues(2, SkillName.AnimalTaming, 10.0);
            mask.Attributes.BonusInt = 10;
            mask.Attributes.NightSight = 1;
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateTribalMask()
        {
            DeerMask mask = new DeerMask();
            mask.Name = "Spirit Mask of the Belau Ancestors";
            mask.Hue = 1266;
            mask.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 18.0);
            mask.SkillBonuses.SetValues(1, SkillName.MagicResist, 12.0);
            mask.Attributes.BonusHits = 15;
            mask.Attributes.Luck = 35;
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Ocean Cloak of Protection";
            cloak.Hue = 1368;
            cloak.Attributes.DefendChance = 12;
            cloak.Attributes.SpellDamage = 7;
            cloak.SkillBonuses.SetValues(0, SkillName.EvalInt, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Navigator's Sea Pants";
            pants.Hue = 1171;
            pants.Attributes.Luck = 18;
            pants.Attributes.BonusStam = 7;
            pants.SkillBonuses.SetValues(0, SkillName.Camping, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Cartography, 14.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new LeafChest(), new WoodlandChest(), new PlateDo(), new DragonTurtleHideChest()
            );
            armor.Name = "Coral-Encrusted Breastplate";
            armor.Hue = 1152;
            armor.BaseArmorRating = Utility.Random(38, 67);
            armor.Attributes.BonusHits = 15;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            armor.ColdBonus = 10;
            armor.PoisonBonus = 5;
            armor.EnergyBonus = 10;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Spear(), new ShortSpear(), new Katana(), new Nunchaku(), new FishermansTrident()
            );
            weapon.Name = "Spear of Milad, Ocean Hero";
            weapon.Hue = 1368;
            weapon.MaxDamage = Utility.Random(34, 62);
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitHarm = 13;
            weapon.Attributes.BonusDex = 15;
            weapon.Attributes.BonusStam = 7;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fishing, 12.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateFishingTrident()
        {
            Pike trident = new Pike();
            trident.Name = "Trident of the Rock Islands";
            trident.Hue = 1172;
            trident.MaxDamage = Utility.Random(36, 57);
            trident.WeaponAttributes.HitFireball = 15;
            trident.WeaponAttributes.HitMagicArrow = 12;
            trident.Attributes.BonusStr = 9;
            trident.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            trident.SkillBonuses.SetValues(1, SkillName.Stealth, 9.0);
            XmlAttach.AttachTo(trident, new XmlLevelItem());
            return trident;
        }

        // Utility: For hue and naming
        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Palauan Lore Book
        public class TalesOfPalau : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Tales of Palau", "The Village Storyteller",
                new BookPageInfo
                (
                    "In the far western Pacific,",
                    "a necklace of emerald",
                    "islands rises from the",
                    "sea—Palau. Our ancestors",
                    "say the first land was born",
                    "from a giant clam, whose",
                    "spirit still guards our",
                    "waters."
                ),
                new BookPageInfo
                (
                    "Long before strangers",
                    "came, chiefs of Airai",
                    "and Koror led their",
                    "clans with wisdom,",
                    "deciding fates by the",
                    "Bai’s sacred fires.",
                    "Navigators read the",
                    "stars and ocean swells."
                ),
                new BookPageInfo
                (
                    "The gods gave gifts: the",
                    "Milad, hero of old, who",
                    "brought fire and spears;",
                    "the first fishermen, who",
                    "taught respect for sea",
                    "and reef. Even now,",
                    "spirits dwell among the",
                    "mangroves at night."
                ),
                new BookPageInfo
                (
                    "Our islands saw wars,",
                    "both old and new. Stone",
                    "monoliths stand in Babeldaob,",
                    "silent as the deep. Shell",
                    "money passed from hand",
                    "to hand, binding families,",
                    "paying debts and honoring",
                    "the gods."
                ),
                new BookPageInfo
                (
                    "In World War II, fire",
                    "fell from the sky. The",
                    "Rock Islands hid both",
                    "friend and foe. But the",
                    "Palauan people endured.",
                    "We rebuilt, we remembered,",
                    "and the ocean kept its",
                    "secrets."
                ),
                new BookPageInfo
                (
                    "Find within this chest the",
                    "echoes of our ancestors,",
                    "the gifts of shell, pearl,",
                    "and spirit. Let the sea",
                    "guide you gently, as it",
                    "guided us.",
                    "",
                    "- Olechotel Belau"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public TalesOfPalau() : base(false)
            {
                Hue = 1172; // Blue pearl
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Tales of Palau");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Tales of Palau");
            }

            public TalesOfPalau(Serial serial) : base(serial) { }

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

        public TreasureChestOfPalauanHistory(Serial serial) : base(serial)
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
}
