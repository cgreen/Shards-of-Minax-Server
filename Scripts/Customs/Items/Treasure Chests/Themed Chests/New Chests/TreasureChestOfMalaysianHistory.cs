using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMalaysianHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMalaysianHistory()
        {
            Name = "Treasure Chest of Malaysian History";
            Hue = 2120; // Gold and green batik motif

            // Decorative and unique items
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Batik-Covered Bamboo Stool", 2209), 0.15);
            AddItem(CreateDecorativeItem<SwordDisplay3SouthArtifact>("Display: Kris of Melaka", 1175), 0.13);
            AddItem(CreateDecorativeItem<AncientWeapon2>("Rustic Portuguese Cannon Model", 1109), 0.12);
            AddItem(CreateDecorativeItem<FancyPainting>("Painting: Malacca Sultanate", 1418), 0.16);
            AddItem(CreateDecorativeItem<BottleArtifact>("Spice Trader’s Ancient Jar", 1276), 0.17);
            AddItem(CreateDecorativeItem<LargeVase>("Peranakan Porcelain Vase", 2051), 0.17);
            AddItem(CreateDecorativeItem<GoldBricks>("Tin Ingots of the Ipoh Mines", 2410), 0.17);
            AddItem(CreateDecorativeItem<BambooChair>("Royal Bamboo Chair of Kedah", 2210), 0.17);
            AddItem(CreateDecorativeItem<IncenseBurner>("Temple Incense Burner", 1297), 0.17);

            // Consumables & specialty food
            AddItem(CreateConsumable<SushiPlatter>("Platter of Nasi Lemak", 2501), 0.18);
            AddItem(CreateConsumable<GreenTea>("Teh Tarik Mug", 1266), 0.19);
            AddItem(CreateConsumable<BentoBox>("Satay Bento Box", 1278), 0.14);
            AddItem(CreateConsumable<Cake>("Kuih Lapis Layered Cake", 1369), 0.17);
            AddItem(CreateConsumable<RandomFancyPlant>("Orchid Garland", 2115), 0.15);

            // Equipment - uniquely named and themed with powerful modifiers
            AddItem(CreateWeapon_Keris(), 0.17);
            AddItem(CreateWeapon_Blowpipe(), 0.14);
            AddItem(CreateArmor_SultanCloak(), 0.15);
            AddItem(CreateBoots_Melaka(), 0.12);
            AddItem(CreateHat_Songkok(), 0.14);

            // Special coin
            AddItem(CreateSpecialCoin("Ringgit Coin of Federation", 2512), 0.25);

            // Lore Book
            AddItem(new LegendsAndChroniclesOfMalaysia(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative item creator
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumable/Food item creator
        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Special coin
        private Item CreateSpecialCoin(string name, int hue)
        {
            Gold gold = new Gold();
            gold.Amount = Utility.Random(1000, 3000);
            gold.Name = name;
            gold.Hue = hue;
            return gold;
        }

        // Unique Equipment
        private Item CreateWeapon_Keris()
        {
            Dagger keris = new Dagger();
            keris.Name = "Keris of Hang Tuah";
            keris.Hue = 1156;
            keris.MinDamage = 35;
            keris.MaxDamage = 80;
            keris.Attributes.BonusHits = 15;
            keris.Attributes.SpellChanneling = 1;
            keris.Attributes.CastSpeed = 1;
            keris.Attributes.BonusDex = 8;
            keris.Attributes.WeaponSpeed = 25;
            keris.WeaponAttributes.HitLeechHits = 30;
            keris.WeaponAttributes.HitLeechMana = 20;
            keris.WeaponAttributes.HitLightning = 15;
            keris.Slayer = SlayerName.DragonSlaying;
            keris.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            XmlAttach.AttachTo(keris, new XmlLevelItem());
            return keris;
        }

        private Item CreateWeapon_Blowpipe()
        {
            ShortSpear blowpipe = new ShortSpear();
            blowpipe.Name = "Orang Asli Blowpipe";
            blowpipe.Hue = 1367;
            blowpipe.MinDamage = 28;
            blowpipe.MaxDamage = 62;
            blowpipe.Attributes.BonusStam = 10;
            blowpipe.Attributes.BonusHits = 5;
            blowpipe.Attributes.BonusMana = 7;
            blowpipe.WeaponAttributes.HitPoisonArea = 30;
            blowpipe.WeaponAttributes.HitLowerAttack = 10;
            blowpipe.SkillBonuses.SetValues(0, SkillName.Poisoning, 12.0);
            blowpipe.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(blowpipe, new XmlLevelItem());
            return blowpipe;
        }

        private Item CreateArmor_SultanCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Malacca Sultan";
            cloak.Hue = 2202;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.BonusInt = 8;
            cloak.Attributes.SpellDamage = 10;
            cloak.Resistances.Fire = 10;
            cloak.Resistances.Cold = 10;
            cloak.Resistances.Energy = 8;
            cloak.Resistances.Poison = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 18.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateBoots_Melaka()
        {
            Boots boots = new Boots();
            boots.Name = "Merchant’s Boots of Melaka";
            boots.Hue = 2452;
            boots.Attributes.Luck = 15;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.BonusStam = 5;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateHat_Songkok()
        {
            SkullCap hat = new SkullCap();
            hat.Name = "Songkok of Wisdom";
            hat.Hue = 1108;
            hat.Attributes.BonusInt = 12;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.EvalInt, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Inscribe, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        // Lore Book
        public class LegendsAndChroniclesOfMalaysia : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Legends & Chronicles of Malaysia", "Tun Seri Lanang",
                new BookPageInfo
                (
                    "From the misty jungles of Borneo",
                    "and the gold-filled rivers of Perak,",
                    "to the royal courts of Melaka,",
                    "Malaysia’s history is a tapestry",
                    "woven with legends and empires.",
                    "",
                    "Long ago, Srivijaya ruled the seas,",
                    "a maritime kingdom, mighty and rich."
                ),
                new BookPageInfo
                (
                    "The Malacca Sultanate flourished",
                    "on the spice trade, famed from",
                    "China to Arabia. Warriors like",
                    "Hang Tuah defended her honor,",
                    "while sultans welcomed merchants,",
                    "scholars, and explorers from afar.",
                    "",
                    "Portuguese, Dutch, and British flags"
                ),
                new BookPageInfo
                (
                    "would rise and fall over these lands,",
                    "but the spirit of Malaysia endured.",
                    "",
                    "Rubber tappers and tin miners,",
                    "Peranakan artisans and Orang Asli",
                    "hunters—all shaped her destiny.",
                    "",
                    "Independence was claimed in 1957,"
                ),
                new BookPageInfo
                (
                    "as Tunku Abdul Rahman’s voice rang:",
                    "\"Merdeka!\" echoed through the crowd.",
                    "",
                    "Today, Malaysia stands united,",
                    "its people a harmony of many roots:",
                    "Malay, Chinese, Indian, Iban, Kadazan,",
                    "and more, sharing one bountiful land.",
                    "",
                    "To the finder of this chest:"
                ),
                new BookPageInfo
                (
                    "May these treasures remind you of",
                    "Malaysia’s long journey, and inspire",
                    "you to seek wisdom, courage, and unity.",
                    "",
                    "",
                    "- Tun Seri Lanang,",
                    "Chronicler of Kings"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public LegendsAndChroniclesOfMalaysia() : base(false)
            {
                Hue = 2202; // Deep green batik color
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Legends & Chronicles of Malaysia");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Legends & Chronicles of Malaysia");
            }

            public LegendsAndChroniclesOfMalaysia(Serial serial) : base(serial) { }

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

        public TreasureChestOfMalaysianHistory(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
