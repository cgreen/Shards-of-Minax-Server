using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientLibya : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientLibya()
        {
            Name = "Treasure Chest of Ancient Libya";
            Hue = 2106; // Sandy gold

            // Add themed items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Phoenician Merchant’s Vase", 2424), 0.18);
            AddItem(CreateDecorativeItem<WolfStatue>("Desert Wolf Idol", 2401), 0.15);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Scrolls of Cyrene", 2478), 0.13);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Carthaginian Bust", 1151), 0.11);
            AddItem(CreateDecorativeItem<GoldBricks>("Tribute of Tripolitania", 2213), 0.10);
            AddItem(CreateDecorativeItem<Painting2WestArtifact>("Oasis Painting", 2123), 0.14);
            AddItem(CreateDecorativeItem<AncientShipModelOfTheHMSCape>("Wreck of the Syrtis", 1161), 0.06);
            AddItem(CreateDecorativeItem<Urn2Artifact>("Urn of Berber Ancestors", 2010), 0.13);

            AddItem(CreateConsumable<GreenTea>("Desert Mint Tea", 1456), 0.18);
            AddItem(CreateConsumable<FruitBasket>("Oasis Fruit Basket", 1420), 0.13);
            AddItem(CreateConsumable<Dates>("Medjool Dates", 1980), 0.14);
            AddItem(CreateConsumable<Bottle>("Carthage Red Wine", 1177), 0.10);
            AddItem(CreateConsumable<RandomFancyPotion>("Potion of the Garamantes", 1167), 0.12);
            
            AddItem(CreateNamedGold("Ancient Libyan Dinar"), 0.19);

            // Equipment with big modifiers
            AddItem(CreateUniqueWeapon(), 0.25);
            AddItem(CreateUniqueArmor(), 0.25);
            AddItem(CreateUniqueClothing(), 0.18);
            AddItem(CreateUniqueShield(), 0.13);

            // Book of lore
            AddItem(new ChroniclesOfTheLibyanSands(), 1.0);

            // Misc extras
            AddItem(CreateMap(), 0.07);
            AddItem(new Gold(Utility.RandomMinMax(1000, 6000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedGold(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(300, 800);
            return gold;
        }

        private Item CreateUniqueWeapon()
        {
            // Ancient Berber Scimitar
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Berber Scimitar of the Desert Kings";
            scimitar.Hue = 2208;
            scimitar.WeaponAttributes.HitLeechHits = 25;
            scimitar.WeaponAttributes.HitFireball = 20;
            scimitar.WeaponAttributes.UseBestSkill = 1;
            scimitar.Attributes.BonusStam = 10;
            scimitar.Attributes.BonusStr = 10;
            scimitar.Attributes.AttackChance = 15;
            scimitar.Attributes.WeaponSpeed = 30;
            scimitar.Attributes.WeaponDamage = 35;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateUniqueArmor()
        {
            // Garamantes Bronze Plate Chest
            PlateChest chest = new PlateChest();
            chest.Name = "Garamantes Bronze Plate";
            chest.Hue = 1843;
            chest.BaseArmorRating = 45;
            chest.ArmorAttributes.LowerStatReq = 25;
            chest.ArmorAttributes.MageArmor = 1;
            chest.Attributes.BonusHits = 15;
            chest.Attributes.BonusDex = 7;
            chest.Attributes.Luck = 100;
            chest.SkillBonuses.SetValues(0, SkillName.Macing, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            chest.PhysicalBonus = 14;
            chest.FireBonus = 9;
            chest.ColdBonus = 7;
            chest.PoisonBonus = 8;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueClothing()
        {
            // Tuareg Nomad’s Indigo Robe
            Robe robe = new Robe();
            robe.Name = "Tuareg Nomad's Indigo Robe";
            robe.Hue = 1355;
            robe.Attributes.BonusMana = 12;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.SpellDamage = 14;
            robe.Attributes.NightSight = 1;
            robe.Attributes.BonusInt = 6;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 20.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueShield()
        {
            // Shield of the Tripolitanian Legion
            BronzeShield shield = new BronzeShield();
            shield.Name = "Shield of the Tripolitanian Legion";
            shield.Hue = 2419;
            shield.Attributes.DefendChance = 18;
            shield.ArmorAttributes.SelfRepair = 4;
            shield.Attributes.BonusHits = 20;
            shield.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            shield.SkillBonuses.SetValues(1, SkillName.Parry, 15.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of the Libyan Sands";
            map.Bounds = new Rectangle2D(2200, 1600, 500, 400);
            map.NewPin = new Point2D(2350, 1700);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAncientLibya(Serial serial) : base(serial)
        {
        }

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

    public class ChroniclesOfTheLibyanSands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Libyan Sands", "Scribe of Leptis Magna",
            new BookPageInfo
            (
                "Beyond the emerald Nile, westward",
                "where the desert swallows the sun,",
                "lies Libya. Berber tribes roam the",
                "great Sahara, guardians of forgotten",
                "oases and shifting sands."
            ),
            new BookPageInfo
            (
                "Phoenicians sailed the coast,",
                "building mighty Carthage. Greeks",
                "founded Cyrene, city of knowledge.",
                "Roman legions marched beneath",
                "Africa's burning sky, forging",
                "Tripolitania and Cyrenaica."
            ),
            new BookPageInfo
            (
                "Here, temples rose to gods old",
                "and new: Ammon, Tanit, Apollo.",
                "The Garamantes carved tunnels,",
                "bringing water to the thirsty.",
                "Salt caravans and gold crossed",
                "the dunes on camel-back."
            ),
            new BookPageInfo
            (
                "Desert wind swept away empires.",
                "Arab banners followed the Prophet’s",
                "call, bringing new tongue and faith.",
                "Ottomans ruled from stone citadels.",
                "Italians built roads, sowed rebellion."
            ),
            new BookPageInfo
            (
                "But the desert endures. Libyan",
                "warriors and wise women kept",
                "the old ways, singing to the stars.",
                "In these sands are echoes of all",
                "who dared to call Libya home."
            ),
            new BookPageInfo
            (
                "Let the finder of this chest",
                "remember: treasures fade, but",
                "history is eternal, written in",
                "sand and stone. Seek wisdom,",
                "not just gold.",
                "",
                "- Scribe of Leptis Magna"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheLibyanSands() : base(false)
        {
            Hue = 2106; // Sandy gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Libyan Sands");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Libyan Sands");
        }

        public ChroniclesOfTheLibyanSands(Serial serial) : base(serial) { }

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
