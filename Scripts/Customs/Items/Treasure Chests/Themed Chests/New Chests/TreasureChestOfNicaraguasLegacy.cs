using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNicaraguasLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNicaraguasLegacy()
        {
            Name = "Treasure Chest of Nicaragua’s Legacy";
            Hue = 2113; // Deep jade-green (evokes Central American jungle and jadeite)

            // Add items to the chest
            AddItem(new AncientCacaoRelic(), 0.12);
            AddItem(CreateJadeIdol(), 0.22);
            AddItem(CreateColoredItem<GreaterCurePotion>("Witch's Brew of Masaya", 2515), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Lake Spirits"), 0.19);
            AddItem(new ChroniclesOfNicaragua(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7000)), 0.12);
            AddItem(CreateColoredItem<RandomFancyPottery>("Chorotega Pottery", 2128), 0.16);
            AddItem(CreateNamedItem<Bottle>("Pirate’s Rum of San Juan del Sur"), 0.10);
            AddItem(CreateColoredItem<Diamond>("Jade of the Ancestors", 2117), 0.12);
            AddItem(CreateGoldItem("Gold Coin of León"), 0.16);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Rebel Scout", 1175), 0.18);
            AddItem(CreateNamedItem<GoldNecklace>("Golden Medallion of Granada"), 0.14);
            AddItem(CreateMap(), 0.04);
            AddItem(CreateNamedItem<Sextant>("Navigator’s Sextant of Lake Nicaragua"), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Herbal Tonic of the Cloud Forests"), 0.18);
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateSandinistaJacket(), 0.17);
            AddItem(CreateVolcanoShamanMask(), 0.12);
            AddItem(CreateDagger(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateJadeIdol()
        {
            Diamond jade = new Diamond();
            jade.Name = "Jade Idol of the Nicarao";
            jade.Hue = 2117; // A distinct green
            return jade;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Nicaragua’s Lost Treasures";
            map.Bounds = new Rectangle2D(2100, 2700, 350, 390); // Random coordinates
            map.NewPin = new Point2D(2200, 2850);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Broadsword(), new Katana(), new Scimitar());
            weapon.Name = "Conquistador’s Sword of Granada";
            weapon.Hue = 1172; // Rich steel blue
            weapon.MaxDamage = Utility.Random(35, 80);
            weapon.Attributes.WeaponDamage = 25;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.BonusHits = 20;
            weapon.WeaponAttributes.HitFireball = 30;
            weapon.WeaponAttributes.HitLeechMana = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm());
            armor.Name = "Armor of the Royal Guards";
            armor.Hue = 1171; // Bright silver
            armor.BaseArmorRating = Utility.Random(32, 65);
            armor.Attributes.BonusStr = 10;
            armor.ArmorAttributes.SelfRepair = 3;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateSandinistaJacket()
        {
            Robe jacket = new Robe();
            jacket.Name = "Sandinista Freedom Fighter's Jacket";
            jacket.Hue = 137; // Deep red
            jacket.Attributes.BonusDex = 15;
            jacket.Attributes.BonusHits = 8;
            jacket.Attributes.LowerManaCost = 10;
            jacket.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            jacket.SkillBonuses.SetValues(1, SkillName.Hiding, 18.0);
            XmlAttach.AttachTo(jacket, new XmlLevelItem());
            return jacket;
        }

        private Item CreateVolcanoShamanMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Mask of the Volcano Shaman";
            mask.Hue = 1358; // Fiery orange-red
            mask.Attributes.BonusInt = 18;
            mask.Attributes.NightSight = 1;
            mask.Attributes.SpellDamage = 10;
            mask.SkillBonuses.SetValues(0, SkillName.Magery, 14.0);
            mask.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Rebel Scout";
            dagger.Hue = 1157; // Stealthy shadow
            dagger.MinDamage = Utility.Random(18, 34);
            dagger.MaxDamage = Utility.Random(35, 65);
            dagger.Attributes.BonusStam = 10;
            dagger.Attributes.ReflectPhysical = 12;
            dagger.WeaponAttributes.HitPoisonArea = 20;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Poisoning, 12.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfNicaraguasLegacy(Serial serial) : base(serial) { }

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

    // Sample Custom Decorative/Consumable Item
    public class AncientCacaoRelic : BottleArtifact
    {
        [Constructable]
        public AncientCacaoRelic()
        {
            Name = "Ancient Cacao Relic";
            Hue = 2126; // Deep chocolate brown
        }
        public AncientCacaoRelic(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    public class ChroniclesOfNicaragua : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Land of Lakes and Volcanoes", "Scribe of Granada",
            new BookPageInfo
            (
                "Long before the conquistadors,",
                "the Chorotega and Nicarao walked",
                "the shores of vast lakes. Their",
                "cities rose of clay, their idols",
                "carved from jade and volcanic stone.",
                "",
                "The land trembled with the song",
                "of fire and water."
            ),
            new BookPageInfo
            (
                "Granada and León, rivals in",
                "stone, watched Spanish ships",
                "cross Lake Nicaragua, seeking",
                "gold and souls. Pirates came too,",
                "sailing upriver, leaving smoke",
                "and ghost stories among the reeds."
            ),
            new BookPageInfo
            (
                "Under volcanoes Masaya and",
                "Momotombo, legends were born:",
                "El Güegüense danced, mocking",
                "kings and tyrants. Sorcerers of",
                "Ometepe brewed potions from",
                "jungle roots, watched by jaguars.",
                ""
            ),
            new BookPageInfo
            (
                "Empires crumbled. Somoza ruled,",
                "his boots echoing in marble halls,",
                "until the Sandinistas rose in",
                "the shadows. In the mountains,",
                "rebels whispered, and the land",
                "changed once again."
            ),
            new BookPageInfo
            (
                "Now, in the age of memory,",
                "the old treasures call. Seekers",
                "find gold, jade, rum, and stories",
                "hidden beneath the ceiba trees.",
                "The heart of Nicaragua is a",
                "chest within a chest—one lock,",
                "many keys."
            ),
            new BookPageInfo
            (
                "Beware: spirits of lake and fire",
                "guard their secrets. Not every",
                "treasure glitters. Not every",
                "story is safe to tell.",
                "",
                "- Scribe of Granada",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfNicaragua() : base(false)
        {
            Hue = 2128; // Earthen pottery red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Land of Lakes and Volcanoes");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Land of Lakes and Volcanoes");
        }

        public ChroniclesOfNicaragua(Serial serial) : base(serial) { }

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
