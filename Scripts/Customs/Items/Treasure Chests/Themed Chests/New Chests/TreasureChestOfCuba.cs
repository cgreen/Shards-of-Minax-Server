using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCuba : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCuba()
        {
            Name = "Treasure Chest of Cuba's Hidden History";
            Hue = 2052; // Caribbean blue

            // Add unique items to the chest
            AddItem(new MaxxiaScroll(), 0.03);
            AddItem(CreatePearl(), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Santiago’s Elixir de Vida", 1167), 0.15);
            AddItem(CreateNamedItem<TreasureLevel2>("Map of Lost Havana"), 0.08);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Sugar Baron"), 0.12);
            AddItem(new ChroniclesOfCuba(), 1.0);
            AddItem(new Gold(Utility.Random(500, 5000)), 0.10);
            AddItem(CreateColoredItem<Ruby>("Ruby of Cienfuegos", 1254), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Rum of the Buccaneer"), 0.10);
            AddItem(CreateGoldItem("Cuban Peso Coin"), 0.18);
            AddItem(CreateColoredItem<Bandana>("Bandana of the Guerrillero", 2210), 0.19);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of La Reina del Caribe"), 0.17);
            AddItem(CreateCubanMap(), 0.06);
            AddItem(CreateNamedItem<Sextant>("Navigator’s Astrolabe"), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Bottle of Café Cubano"), 0.18);
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.25);
            AddItem(CreateGuayaberaShirt(), 0.22);
            AddItem(CreatePanamaHat(), 0.20);
            AddItem(CreateMachete(), 0.22);

            // Decorative Cuban artifacts
            AddItem(CreateNamedItem<ArtifactLargeVase>("Spanish Colonial Vase"), 0.14);
            AddItem(CreateNamedItem<BambooStoolArtifact>("Tobacco Farmer's Stool"), 0.12);
            AddItem(CreateNamedItem<FancyPainting>("Painting of Old Havana"), 0.10);
            AddItem(CreateNamedItem<Candelabra>("Morro Castle Candle"), 0.11);
            AddItem(CreateNamedItem<Globe>("Navigator’s Globe of the Antilles"), 0.09);

            // Consumable foods
            AddItem(CreateNamedItem<BreadLoaf>("Loaf of Pan Cubano"), 0.18);
            AddItem(CreateNamedItem<RandomFruitBasket>("Basket of Tropical Fruits"), 0.20);
            AddItem(CreateNamedItem<HotCocoaMug>("Cup of Cuban Chocolate"), 0.15);

        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreatePearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "Pearl of Varadero";
            pearl.Hue = 1153;
            return pearl;
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

        private Item CreateCubanMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Pirate Map of Cuba";
            map.Bounds = new Rectangle2D(5400, 1800, 450, 230); // fictional coords
            map.NewPin = new Point2D(5550, 1950);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(),
                new Scimitar(),
                new Mace(),
                new Crossbow(),
                new Nunchaku()
            );
            weapon.Name = Utility.RandomList(
                "Cutlass of the Havana Corsair",
                "Scimitar of Santiago",
                "Mace of the Sugar Mill",
                "Crossbow of the Taino Scout",
                "Nunchaku of the Revolutionary"
            );
            weapon.Hue = Utility.RandomList(2002, 2210, 1167, 1153, 1254);
            weapon.MaxDamage = Utility.Random(38, 74);
            weapon.MinDamage = Utility.Random(16, 34);
            weapon.Attributes.BonusStr = Utility.RandomMinMax(5, 10);
            weapon.Attributes.BonusDex = Utility.RandomMinMax(3, 10);
            weapon.Attributes.BonusHits = Utility.RandomMinMax(10, 20);
            weapon.Attributes.AttackChance = Utility.RandomMinMax(8, 20);
            weapon.Attributes.DefendChance = Utility.RandomMinMax(6, 14);
            weapon.Attributes.WeaponSpeed = Utility.RandomMinMax(5, 25);
            weapon.WeaponAttributes.HitLeechHits = Utility.RandomMinMax(8, 16);
            weapon.WeaponAttributes.HitFireball = Utility.RandomMinMax(10, 20);
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, Utility.RandomMinMax(12.0, 20.0));
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(),
                new PlateHelm(),
                new StuddedGloves(),
                new StuddedArms()
            );
            armor.Name = Utility.RandomList(
                "Breastplate of the Spanish Galleon",
                "Morion Helm of the Conquistador",
                "Gloves of the Island Rebel",
                "Arms of the Taino Defender"
            );
            armor.Hue = Utility.RandomList(2418, 2002, 1254, 1109);
            armor.BaseArmorRating = Utility.Random(34, 66);
            armor.Attributes.Luck = Utility.RandomMinMax(25, 75);
            armor.Attributes.BonusInt = Utility.RandomMinMax(6, 14);
            armor.Attributes.BonusHits = Utility.RandomMinMax(10, 25);
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 30;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, Utility.RandomMinMax(10.0, 16.0));
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateGuayaberaShirt()
        {
            FancyShirt shirt = new FancyShirt();
            shirt.Name = "Guayabera of the Poet";
            shirt.Hue = 1109; // soft linen white
            shirt.Attributes.Luck = 35;
            shirt.Attributes.BonusMana = 10;
            shirt.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            shirt.SkillBonuses.SetValues(1, SkillName.Musicianship, 10.0);
            XmlAttach.AttachTo(shirt, new XmlLevelItem());
            return shirt;
        }

        private Item CreatePanamaHat()
        {
            StrawHat hat = new StrawHat();
            hat.Name = "Panama Hat of the Old Man and the Sea";
            hat.Hue = 2418; // pale straw
            hat.Attributes.BonusDex = 20;
            hat.Attributes.LowerManaCost = 8;
            hat.SkillBonuses.SetValues(0, SkillName.Fishing, 18.0);
            hat.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMachete()
        {
            Cutlass machete = new Cutlass();
            machete.Name = "Revolutionary’s Machete";
            machete.Hue = 2002;
            machete.MinDamage = 26;
            machete.MaxDamage = 62;
            machete.Attributes.BonusHits = 15;
            machete.Attributes.WeaponSpeed = 12;
            machete.WeaponAttributes.HitLightning = 20;
            machete.WeaponAttributes.HitHarm = 12;
            machete.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            machete.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(machete, new XmlLevelItem());
            return machete;
        }

        public TreasureChestOfCuba(Serial serial) : base(serial)
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

    public class ChroniclesOfCuba : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Cuba: The Island of Resilience", "Isabel de la Isla",
            new BookPageInfo
            (
                "Long before ships sailed these",
                "turquoise waters, the Taino and",
                "Ciboney peoples fished and farmed",
                "upon Cuba’s green coasts.",
                "Theirs was a world of",
                "caciques and gods, of",
                "hidden caves and silent",
                "crocodiles."
            ),
            new BookPageInfo
            (
                "Then the sails came. Spain’s",
                "ironclad soldiers planted flags,",
                "built cathedrals, and harvested",
                "sugar from red earth. Enslaved",
                "Africans sang songs of sorrow",
                "and hope beneath the blazing",
                "sun. Pirates circled Havana’s",
                "fortress walls."
            ),
            new BookPageInfo
            (
                "Through centuries, the island",
                "became a jewel and a battleground.",
                "For freedom, for gold, for power.",
                "The drums of rebellion echoed",
                "in sugarcane fields and city streets.",
                "Heroes and poets, martyrs and",
                "musicians, wrote Cuba’s soul."
            ),
            new BookPageInfo
            (
                "The smoke of cigars and guns",
                "rose together in the revolution.",
                "Barbudos, led by Fidel and Che,",
                "marched from the Sierra Maestra.",
                "Empires faltered. A new flag",
                "rose, and with it, both hope",
                "and hardship."
            ),
            new BookPageInfo
            (
                "Yet the spirit of Cuba is",
                "resilient. From the music of",
                "the Buena Vista to the silent",
                "fisherman of Cojímar, the heart",
                "of this island endures. Her",
                "streets may crumble, but her",
                "stories sing like the surf."
            ),
            new BookPageInfo
            (
                "To those who find this chest:",
                "Let it remind you that Cuba’s",
                "true treasure is not gold or",
                "gems, but the indomitable will",
                "of her people.",
                "",
                "- Isabel de la Isla",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfCuba() : base(false)
        {
            Hue = 2052; // Caribbean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Cuba: The Island of Resilience");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Cuba: The Island of Resilience");
        }

        public ChroniclesOfCuba(Serial serial) : base(serial) { }

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
