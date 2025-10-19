using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfVietLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfVietLegends()
        {
            Name = "Treasure Chest of Viet Legends";
            Hue = Utility.RandomList(2117, 2052, 1266, 1272); // Jade & imperial red hues

            // Decorative/Themed Items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ancient Dong Son Drum", 1272), 0.20);
            AddItem(CreateDecorativeItem<ZenRock1Artifact>("Rock of Ba Na Hills", 2052), 0.17);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Golden Turtle Statuette", 2117), 0.19);
            AddItem(CreateDecorativeItem<QuagmireStatue>("Statue of Lac Long Quan", 1266), 0.12);
            AddItem(CreateDecorativeItem<ChangelingStatue>("Statue of Au Co", 1282), 0.12);
            AddItem(CreateDecorativeItem<OrigamiDragon>("Origami Dragon of the Red River", 1153), 0.14);

            // Consumables
            AddItem(CreateConsumable<BowlOfRotwormStew>("Bowl of Pho Bac", 1801), 0.17);
            AddItem(CreateConsumable<GreenTea>("Ancient Lotus Tea", 2207), 0.14);
            AddItem(CreateConsumable<Dates>("Royal Lychee Fruit", 1460), 0.11);
            AddItem(CreateConsumable<RandomFancyPotion>("Potion of Immortal Courage", 1266), 0.13);

            // Gold + Unique Currency
            AddItem(new Gold(Utility.Random(500, 3500)), 0.15);
            AddItem(CreateUniqueCoin(), 0.10);

            // Themed Powerful Equipment
            AddItem(CreateLegendaryWeapon(), 0.18);
            AddItem(CreateLegendaryArmor(), 0.17);
            AddItem(CreateLegendaryClothing(), 0.16);
            AddItem(CreateLegendaryHat(), 0.15);
            AddItem(CreateLegendaryDagger(), 0.14);

            // Unique Lore Book
            AddItem(new ChroniclesOfTheDragonAndTheFairy(), 1.0);

            // Themed Map
            AddItem(CreateMap(), 0.05);
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

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Ancient Viet Copper Coin";
            gold.Hue = 2418;
            return gold;
        }

        private Item CreateLegendaryWeapon()
        {
            // Sword of the Legendary King An Duong Vuong
            Katana weapon = new Katana();
            weapon.Name = "Heavenly Sword of An Duong Vuong";
            weapon.Hue = 2052;
            weapon.MinDamage = 38;
            weapon.MaxDamage = 65;
            weapon.Attributes.BonusStr = 12;
            weapon.Attributes.BonusHits = 20;
            weapon.Attributes.AttackChance = 13;
            weapon.Attributes.WeaponDamage = 25;
            weapon.Attributes.WeaponSpeed = 18;
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitFireball = 14;
            weapon.WeaponAttributes.HitHarm = 15;
            weapon.WeaponAttributes.UseBestSkill = 1;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 14.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLegendaryArmor()
        {
            // Dragon Scale Armor of Lac Long Quan
            DragonChest armor = new DragonChest();
            armor.Name = "Dragon Scale Armor of Lac Long Quan";
            armor.Hue = 1266;
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusHits = 24;
            armor.Attributes.BonusDex = 10;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.PhysicalBonus = 20;
            armor.FireBonus = 14;
            armor.ColdBonus = 14;
            armor.EnergyBonus = 20;
            armor.PoisonBonus = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLegendaryClothing()
        {
            // Robe of the Trưng Sisters
            Robe robe = new Robe();
            robe.Name = "Silk Robe of the Trưng Sisters";
            robe.Hue = 2117;
            robe.Attributes.Luck = 65;
            robe.Attributes.BonusInt = 8;
            robe.Attributes.CastRecovery = 3;
            robe.Attributes.CastSpeed = 2;
            robe.Attributes.NightSight = 1;
            robe.Attributes.SpellDamage = 15;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 17.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateLegendaryHat()
        {
            // FeatheredHat of Thanh Giong
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Feathered Hat of Thanh Giong";
            hat.Hue = 2052;
            hat.Attributes.BonusStr = 15;
            hat.Attributes.BonusStam = 15;
            hat.Attributes.DefendChance = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            hat.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateLegendaryDagger()
        {
            // Dagger of Thần Kim Quy (Golden Turtle God)
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of Thần Kim Quy";
            dagger.Hue = 1282;
            dagger.MinDamage = 19;
            dagger.MaxDamage = 49;
            dagger.Attributes.BonusMana = 8;
            dagger.Attributes.SpellDamage = 12;
            dagger.Attributes.BonusHits = 7;
            dagger.Attributes.CastSpeed = 2;
            dagger.WeaponAttributes.HitMagicArrow = 17;
            dagger.WeaponAttributes.HitLowerAttack = 15;
            dagger.WeaponAttributes.SelfRepair = 4;
            dagger.SkillBonuses.SetValues(0, SkillName.Ninjitsu, 13.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Temple of Hung Kings";
            map.Bounds = new Rectangle2D(2450, 1620, 390, 450);
            map.NewPin = new Point2D(2570, 1788);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfVietLegends(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheDragonAndTheFairy : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Dragon and the Fairy", "Ancient Scribe of Van Lang",
            new BookPageInfo
            (
                "In the mists of time,",
                "beyond the Red River's flow,",
                "Lac Long Quan, dragon lord,",
                "wed Au Co, mountain fairy.",
                "From their union sprang",
                "a hundred noble eggs,",
                "from which the Viet people",
                "were born to this world."
            ),
            new BookPageInfo
            (
                "Through forests of bamboo,",
                "and mountains veiled in mist,",
                "they built their ancient land,",
                "Van Lang, cradle of kings.",
                "The Hung Kings reigned,",
                "founders of a thousand years.",
                "The Dong Son drums beat,",
                "echoing heroes' hearts."
            ),
            new BookPageInfo
            (
                "Great Trung Sisters rose,",
                "riding war elephants in battle,",
                "defying foreign yoke,",
                "kindling the spirit of freedom.",
                "An Duong Vuong forged",
                "the spiral citadel of Co Loa,",
                "a city of shell and bronze,",
                "protected by turtle god’s claw."
            ),
            new BookPageInfo
            (
                "Thanh Giong ascended,",
                "a boy grown to a giant,",
                "defender of the land,",
                "vanquishing invaders with",
                "an iron horse and burning grass.",
                "The river flows on,",
                "but legends never die."
            ),
            new BookPageInfo
            (
                "In the heart of Vietnam,",
                "where dragons meet fairies,",
                "heroes are born anew.",
                "Let this chest, and its treasures,",
                "remind you of ancient courage,",
                "resilient as bamboo,",
                "unyielding as the sea,",
                "and as radiant as jade."
            ),
            new BookPageInfo
            (
                "Take heed, traveler.",
                "Respect the old ways.",
                "For history is alive,",
                "and the spirits of the land",
                "may yet watch over those",
                "who open this chest.",
                "",
                "— Keeper of the Viet Legends"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheDragonAndTheFairy() : base(false)
        {
            Hue = 2117; // Imperial Jade
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Dragon and the Fairy");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Dragon and the Fairy");
        }

        public ChroniclesOfTheDragonAndTheFairy(Serial serial) : base(serial) { }

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
