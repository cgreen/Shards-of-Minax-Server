using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAnatolia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAnatolia()
        {
            Name = "Treasure Chest of Anatolian Ages";
            Hue = 2949; // A deep lapis, inspired by Ottoman tiles

            // Themed treasures from Turkey's layered history!
            AddItem(new AncientHittiteIdol(), 0.12);
            AddItem(new ByzantineGoldCoin(), 0.17);
            AddItem(CreateColoredItem<TurkishDelight>("Delight of Topkapi Palace", 1177), 0.18);
            AddItem(CreateColoredItem<TurkishCoffee>("Ottoman Sultan's Coffee", 1151), 0.16);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Rumi's Wisdom"), 0.13);
            AddItem(CreateNamedItem<GoldEarrings>("Sultan's Sapphire Earrings"), 0.10);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateDecorativeItem<RandomFancyBanner>("Sword of Mehmed the Conqueror", 2513), 0.08);
            AddItem(CreateDecorativeItem<LargeVase>("Iznik Painted Vase", 1258), 0.13);
            AddItem(CreateDecorativeItem<TowerLanternArtifact>("Byzantine Lantern", 1873), 0.09);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Fire of Troy", 1359), 0.09);
            AddItem(CreateBookOfLore(), 1.00);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateCloak(), 0.16);
            AddItem(CreateTurban(), 0.13);
            AddItem(CreateShield(), 0.15);
            AddItem(CreateNamedItem<Pitcher>("Ewer of the Bosphorus"), 0.12);
            AddItem(new Gold(Utility.Random(2000, 9000)), 0.19);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
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
            map.Name = "Map of Anatolian Wonders";
            map.Bounds = new Rectangle2D(1250, 2100, 650, 550);
            map.NewPin = new Point2D(1550, 2450); // Troy's area
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // “Yatagan of Suleiman” – legendary Ottoman saber
            Katana yatagan = new Katana();
            yatagan.Name = "Yatagan of Suleiman";
            yatagan.Hue = 2945; // Cerulean blue
            yatagan.WeaponAttributes.HitLeechHits = 15;
            yatagan.WeaponAttributes.HitFireball = 25;
            yatagan.WeaponAttributes.SelfRepair = 7;
            yatagan.WeaponAttributes.HitLowerAttack = 20;
            yatagan.Attributes.AttackChance = 10;
            yatagan.Attributes.BonusHits = 30;
            yatagan.Attributes.WeaponDamage = 40;
            yatagan.Slayer = SlayerName.Repond; // For battling "invaders"
            yatagan.SkillBonuses.SetValues(0, SkillName.Fencing, 20.0);
            yatagan.SkillBonuses.SetValues(1, SkillName.Parry, 12.5);
            XmlAttach.AttachTo(yatagan, new XmlLevelItem());
            return yatagan;
        }

        private Item CreateShield()
        {
            // “Aegis of Byzantium” – a storied round shield
            BaseShield shield = new MetalShield();
            shield.Name = "Aegis of Byzantium";
            shield.Hue = 2226; // Imperial red
            shield.Attributes.DefendChance = 18;
            shield.Attributes.BonusStam = 18;
            shield.Attributes.LowerManaCost = 10;
            shield.Attributes.Luck = 75;
            shield.ArmorAttributes.LowerStatReq = 15;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateArmor()
        {
            // “Janissary’s Plate” – Ottoman elite guard’s armor
            PlateChest armor = new PlateChest();
            armor.Name = "Janissary’s Plate";
            armor.Hue = 2515; // Brass-gold
            armor.BaseArmorRating = 55;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.BonusStr = 12;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.ReflectPhysical = 9;
            armor.Attributes.SpellDamage = 6;
            armor.SkillBonuses.SetValues(0, SkillName.Swords, 13.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            // “Cloak of Whirling Dervishes” – mystical protection
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Whirling Dervishes";
            cloak.Hue = 1153; // White
            cloak.Attributes.CastRecovery = 3;
            cloak.Attributes.CastSpeed = 2;
            cloak.Attributes.RegenMana = 7;
            cloak.Attributes.BonusInt = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateTurban()
        {
            // “Turban of the Grand Vizier” – great mental power
            WizardsHat turban = new WizardsHat();
            turban.Name = "Turban of the Grand Vizier";
            turban.Hue = 1176; // Royal purple
            turban.Attributes.BonusInt = 15;
            turban.Attributes.LowerManaCost = 18;
            turban.Attributes.NightSight = 1;
            turban.SkillBonuses.SetValues(0, SkillName.EvalInt, 16.0);
            turban.SkillBonuses.SetValues(1, SkillName.Magery, 11.0);
            XmlAttach.AttachTo(turban, new XmlLevelItem());
            return turban;
        }

        private Item CreateBookOfLore()
        {
            return new ChroniclesOfAnatolia();
        }

        // --- Custom Deco and Consumables ---

        public class AncientHittiteIdol : StatueSouth
        {
            [Constructable]
            public AncientHittiteIdol()
            {
                Name = "Ancient Hittite Idol";
                Hue = 2405;
                Movable = true;
            }
            public AncientHittiteIdol(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public class ByzantineGoldCoin : Gold
        {
            [Constructable]
            public ByzantineGoldCoin()
            {
                Name = "Byzantine Gold Solidus";
                Hue = 2213; // gleaming gold
                Amount = Utility.RandomMinMax(5, 18);
                Movable = true;
            }
            public ByzantineGoldCoin(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public class TurkishDelight : Cookies
        {
            [Constructable]
            public TurkishDelight()
            {
                Name = "Turkish Delight";
                Hue = 1177; // pink
                Movable = true;
                Stackable = true;
                Amount = Utility.RandomMinMax(2, 5);
            }
            public TurkishDelight(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public class TurkishCoffee : CoffeeMug
        {
            [Constructable]
            public TurkishCoffee()
            {
                Name = "Cup of Turkish Coffee";
                Hue = 1151;
                Movable = true;
            }
            public TurkishCoffee(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        // --- Lore Book ---

        public class ChroniclesOfAnatolia : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of Anatolia", "Anonymous Historian",
                new BookPageInfo
                (
                    "In the heart of the world",
                    "lies Anatolia, the land",
                    "of a thousand empires.",
                    "Here rose the Hittites,",
                    "crafting gods from stone",
                    "and steel. The walls of",
                    "Troy fell to cunning and",
                    "the song of heroes."
                ),
                new BookPageInfo
                (
                    "Rome claimed these coasts,",
                    "then Byzantium, crowned in",
                    "gold and candlelight. Hagia",
                    "Sophia’s domes soared, and",
                    "the Cross ruled from new",
                    "Rome until the Crescent",
                    "moon rose, and thundered",
                    "from the east."
                ),
                new BookPageInfo
                (
                    "The Seljuks carved palaces,",
                    "the Ottomans forged an",
                    "empire on three seas. Sultans",
                    "prayed at dawn in Topkapi,",
                    "their Janissaries’ march echoed",
                    "on silk roads. Coffee steamed,",
                    "poets wrote, the tulips bloomed.",
                    ""
                ),
                new BookPageInfo
                (
                    "Revolutions stirred; the",
                    "old world yielded. Republics",
                    "rose, ancient scripts faded.",
                    "Yet Anatolia endured, each",
                    "stone a memory, each hill a",
                    "tale. The Bosphorus flows,",
                    "linking not only lands but",
                    "the centuries."
                ),
                new BookPageInfo
                (
                    "Whoever opens this chest",
                    "holds the legacy of many.",
                    "From the lion's gate to",
                    "the Red Apple, may you",
                    "walk wisely where emperors",
                    "have dreamed, and remember:",
                    "the story is never finished.",
                    "",
                    "- Chronicles of Anatolia"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfAnatolia() : base(false)
            {
                Hue = 1153; // white/ivory, for ancient parchment
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of Anatolia");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of Anatolia");
            }

            public ChroniclesOfAnatolia(Serial serial) : base(serial) { }

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

        public TreasureChestOfAnatolia(Serial serial) : base(serial) { }

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
