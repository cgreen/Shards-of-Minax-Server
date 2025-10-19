using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTanzania : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTanzania()
        {
            Name = "Treasure Chest of Tanzania";
            Hue = 1258; // Tanzanite blue

            // Decorative & rare items
            AddItem(CreateDecorativeItem<ArtifactVase>("Swahili Pottery of Kilwa", 1157), 0.17);
            AddItem(CreateDecorativeItem<KingsPainting1>("Painting of Mount Kilimanjaro", 1166), 0.11);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Lion Sculpture of Serengeti", 1193), 0.14);
            AddItem(CreateDecorativeItem<LibraryFriendLantern>("Lantern of Stone Town", 2125), 0.15);
            AddItem(CreateDecorativeItem<RandomFancyStatue>("Statuette of a Maasai Warrior", 1366), 0.13);
            AddItem(CreateDecorativeItem<CraneZooStatuette>("Sacred Ibis Figurine", 2128), 0.13);
            AddItem(CreateNamedItem<TanzaniteGem>("Raw Tanzanite Crystal", 1260), 0.15);

            // Unique consumables/food
            AddItem(CreateNamedItem<BentoBox>("Zanzibar Spice Bento", 1436), 0.16);
            AddItem(CreateNamedItem<GreenTea>("Tea of the Rift Valley", 1278), 0.13);
            AddItem(CreateNamedItem<HotCocoaMug>("Cocoa of Lake Victoria", 1192), 0.13);

            // Unique powerful equipment
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateShield(), 0.15);

            // Lore book
            AddItem(new ChronicleOfTanzania(), 1.0);

            // Gold (called "East African Gold")
            AddItem(CreateGoldItem("East African Gold"), 0.17);

            // Special Map (to Kilimanjaro)
            AddItem(CreateMap(), 0.09);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
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
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(500, 3500);
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Kilimanjaro Summit";
            map.Bounds = new Rectangle2D(5200, 1800, 200, 200);
            map.NewPin = new Point2D(5280, 1880);
            map.Protected = true;
            return map;
        }

        // Example of a unique Tanzanian gem
        private class TanzaniteGem : Ruby
        {
            [Constructable]
            public TanzaniteGem()
            {
                Name = "Raw Tanzanite Crystal";
                Hue = 1258;
            }

            // SERIALIZATION CONSTRUCTOR
            public TanzaniteGem(Serial serial) : base(serial) { }

            // SERIALIZE METHOD
            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);
                writer.Write(0); // version, for future use
            }

            // DESERIALIZE METHOD
            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);
                int version = reader.ReadInt();
            }
        }

        // Unique Weapons, Armor, Clothing, Shield

        private Item CreateWeapon()
        {
            BaseWeapon weapon = new Spear();
            weapon.Name = "Spear of the Maasai Chieftain";
            weapon.Hue = 1194; // Deep purple-blue
            weapon.MinDamage = Utility.Random(30, 55);
            weapon.MaxDamage = Utility.Random(56, 90);
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.BonusHits = 15;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.AttackChance = 10;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            weapon.WeaponAttributes.SelfRepair = 5;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = new PlateChest();
            armor.Name = "Chestplate of the Swahili Sultan";
            armor.Hue = 1260; // Tanzanite
            armor.BaseArmorRating = Utility.Random(35, 60);
            armor.Attributes.BonusStr = 12;
            armor.Attributes.Luck = 35;
            armor.AbsorptionAttributes.EaterFire = 12;
            armor.PhysicalBonus = 22;
            armor.FireBonus = 15;
            armor.ColdBonus = 7;
            armor.PoisonBonus = 8;
            armor.EnergyBonus = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Kanga Robe of Unity";
            robe.Hue = Utility.RandomList(1435, 1166, 1191, 1260);
            robe.Attributes.BonusMana = 12;
            robe.Attributes.LowerRegCost = 15;
            robe.Attributes.CastSpeed = 1;
            robe.Attributes.LowerManaCost = 10;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateShield()
        {
            BaseShield shield = new BronzeShield();
            shield.Name = "Shield of Uhuru (Freedom)";
            shield.Hue = 2124; // Bright gold
            shield.Attributes.DefendChance = 15;
            shield.Attributes.RegenHits = 5;
            shield.Attributes.BonusHits = 12;
            shield.Attributes.Luck = 20;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 14.0);
            shield.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Lore Book
        public class ChronicleOfTanzania : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicle of Tanzania", "Mzee wa Historia",
                new BookPageInfo
                (
                    "From the dawn of humankind,",
                    "the Great Rift Valley bore",
                    "witness to the earliest footsteps.",
                    "Long before time was measured,",
                    "the ancestors hunted upon",
                    "Serengeti’s endless plain.",
                    "",
                    "Later, kingdoms rose—Zan-",
                    "zibar’s sultans, the mighty",
                    "chiefs of the Maasai, the",
                    "traders of Kilwa gilded by",
                    "gold and ivory, their dhows",
                    "sailing the Indian Ocean."
                ),
                new BookPageInfo
                (
                    "Arab and Persian traders",
                    "wove the Swahili coast’s rich",
                    "tapestry, blending language,",
                    "faith, and commerce. Caravan",
                    "routes snaked inland, bearing",
                    "cloves, spices, stories, and",
                    "sometimes sorrow: for slavers",
                    "also passed these paths."
                ),
                new BookPageInfo
                (
                    "The mountains loomed,",
                    "Kilimanjaro crowned with snow,",
                    "Ngorongoro’s crater,",
                    "Lake Victoria’s waters, and",
                    "the wild, untamed forests",
                    "of Gombe, echoing with the",
                    "cries of chimps and the",
                    "drumming of distant drums."
                ),
                new BookPageInfo
                (
                    "Colonial shadows swept",
                    "the land: German East Africa,",
                    "then British rule. Names",
                    "changed, but resistance grew.",
                    "Julius Nyerere’s dream",
                    "of Uhuru—freedom—united",
                    "Tanganyika and Zanzibar as",
                    "Tanzania, land of hope."
                ),
                new BookPageInfo
                (
                    "Today, Tanzania stands proud—",
                    "home to more than 120 tribes,",
                    "one nation, a tapestry of",
                    "languages, beliefs, and wild beauty.",
                    "",
                    "In this chest, the riches",
                    "of our history await: gifts",
                    "from savannah and coast, mountain",
                    "and city. Karibu Tanzania!"
                ),
                new BookPageInfo
                (
                    "Let the spirit of Umoja—",
                    "unity—guide you. Guard these",
                    "treasures well, for they tell",
                    "the story of a nation forged",
                    "in diversity, resilience, and",
                    "dreams as tall as Kilimanjaro.",
                    "",
                    "- Mzee wa Historia"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChronicleOfTanzania() : base(false)
            {
                Hue = 1258;
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicle of Tanzania");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicle of Tanzania");
            }

            public ChronicleOfTanzania(Serial serial) : base(serial) { }

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

        public TreasureChestOfTanzania(Serial serial) : base(serial) { }

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
