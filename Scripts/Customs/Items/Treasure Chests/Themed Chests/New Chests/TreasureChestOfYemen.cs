using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfYemen : WoodenChest
    {
        [Constructable]
        public TreasureChestOfYemen()
        {
            Name = "Treasure Chest of Ancient Yemen";
            Hue = 2101; // Sandstone gold

            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Marib Dam Model", 2419), 0.18);
            AddItem(CreateDecorativeItem<ArtifactVase>("Sabaean Incense Vase", 2414), 0.19);
            AddItem(CreateDecorativeItem<BowlArtifact>("Frankincense Burner", 2413), 0.16);
            AddItem(CreateDecorativeItem<MirrorOfKalandra>("Queen of Sheba's Bronze Mirror", 2420), 0.14);
            AddItem(CreateConsumableItem<GreenTea>("Ancient Yemen Coffee", 2402), 0.17);
            AddItem(CreateConsumableItem<RandomFancyPotion>("Spiced Wine of Shibam", 2503), 0.12);
            AddItem(CreateConsumableItem<JarHoney>("Honey of Arabia Felix", 2123), 0.15);
            AddItem(CreateUniqueJambiya(), 0.22);
            AddItem(CreateUniqueRobe(), 0.18);
            AddItem(CreateUniqueSandals(), 0.15);
            AddItem(CreateUniqueCrown(), 0.09);
            AddItem(CreateUniqueShield(), 0.14);
            AddItem(CreateAncientCoin(), 0.20);
            AddItem(new ScrollsOfArabiaFelix(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 8000)), 0.25);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative items
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Consumables
        private Item CreateConsumableItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique powerful dagger: Jambiya
        private Item CreateUniqueJambiya()
        {
            Dagger jambiya = new Dagger();
            jambiya.Name = "Jambiya of Sheba's Guard";
            jambiya.Hue = 2417;
            jambiya.MinDamage = 25;
            jambiya.MaxDamage = 65;
            jambiya.Attributes.BonusDex = 15;
            jambiya.Attributes.BonusStam = 10;
            jambiya.Attributes.Luck = 80;
            jambiya.WeaponAttributes.HitFireball = 35;
            jambiya.WeaponAttributes.HitLeechHits = 20;
            jambiya.WeaponAttributes.SelfRepair = 6;
            jambiya.SkillBonuses.SetValues(0, SkillName.Stealth, 25.0);
            jambiya.SkillBonuses.SetValues(1, SkillName.Fencing, 15.0);
            jambiya.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(jambiya, new XmlLevelItem());
            return jambiya;
        }

        // Unique Robe
        private Item CreateUniqueRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Sabaean King's Robe";
            robe.Hue = 2513;
            robe.Attributes.BonusInt = 15;
            robe.Attributes.BonusMana = 30;
            robe.Attributes.RegenMana = 4;
            robe.Attributes.CastSpeed = 2;
            robe.Attributes.CastRecovery = 2;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            robe.LootType = LootType.Blessed;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // Unique Sandals
        private Item CreateUniqueSandals()
        {
            Sandals sandals = new Sandals();
            sandals.Name = "Tribal Sandals of Hadhramaut";
            sandals.Hue = 2401;
            sandals.Attributes.BonusHits = 8;
            sandals.Attributes.BonusDex = 12;
            sandals.Attributes.Luck = 40;
            sandals.SkillBonuses.SetValues(0, SkillName.Tracking, 15.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            sandals.LootType = LootType.Blessed;
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        // Unique Crown/Helmet
        private Item CreateUniqueCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of Sheba";
            crown.Hue = 2416;
            crown.Attributes.BonusInt = 18;
            crown.Attributes.Luck = 120;
            crown.Attributes.SpellDamage = 15;
            crown.SkillBonuses.SetValues(0, SkillName.ItemID, 15.0);
            crown.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 15.0);
            crown.ColdBonus = 6;
            crown.EnergyBonus = 8;
            crown.PhysicalBonus = 12;
            crown.FireBonus = 6;
            crown.PoisonBonus = 6;
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        // Unique Shield
        private Item CreateUniqueShield()
        {
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Marib Watch";
            shield.Hue = 2412;
            shield.ArmorAttributes.SelfRepair = 8;
            shield.Attributes.DefendChance = 18;
            shield.Attributes.Luck = 60;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            shield.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // Ancient Coin
        private Item CreateAncientCoin()
        {
            Gold coin = new Gold();
            coin.Name = "Ancient Sabaean Coin";
            coin.Hue = 2423;
            return coin;
        }

        // Custom Lore Book
        public class ScrollsOfArabiaFelix : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "The Scrolls of Arabia Felix", "Al-Katib Al-Sabahi",
                new BookPageInfo
                (
                    "From the dawn-lit mountains",
                    "to the incense roads,",
                    "Yemen thrived as Arabia Felix:",
                    "the Blessed, the Green.",
                    "Here rose the kingdoms of Saba,",
                    "Himyar, Qataban, and Hadhramaut.",
                    "Caravans laden with frankincense",
                    "and myrrh crossed the desert."
                ),
                new BookPageInfo
                (
                    "The Queen of Sheba reigned",
                    "with wisdom and power. Her name",
                    "is whispered in legend, her riches",
                    "sought by all. The mighty Marib Dam",
                    "brought life to the arid valleys, and",
                    "ancient temples reached for the sun.",
                    "Poets sang in the highlands, and",
                    "tribes gathered by moonlit fires."
                ),
                new BookPageInfo
                (
                    "The desert holds secrets:",
                    "lost cities buried beneath sand,",
                    "scripts of a forgotten tongue,",
                    "bronze blades and gold coins.",
                    "When Islam's call echoed,",
                    "Yemen's faith and trade",
                    "shaped the world beyond.",
                    ""
                ),
                new BookPageInfo
                (
                    "Know, seeker, that Yemen's",
                    "story is written in wind and stone,",
                    "in coffee and honey, in the courage",
                    "of its people. These treasures,",
                    "guarded for centuries, are now",
                    "yours to uncover. May the spirit",
                    "of Arabia Felix guide you ever on.",
                    ""
                ),
                new BookPageInfo
                (
                    "Beware, for the spirits of",
                    "Sheba's warriors are restless.",
                    "Take only what wisdom you seek,",
                    "and honor the land of mountains,",
                    "moon, and frankincense.",
                    "",
                    "- Al-Katib Al-Sabahi",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ScrollsOfArabiaFelix() : base(false)
            {
                Hue = 2419; // Golden parchment
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("The Scrolls of Arabia Felix");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "The Scrolls of Arabia Felix");
            }

            public ScrollsOfArabiaFelix(Serial serial) : base(serial) { }

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

        public TreasureChestOfYemen(Serial serial) : base(serial) { }
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
