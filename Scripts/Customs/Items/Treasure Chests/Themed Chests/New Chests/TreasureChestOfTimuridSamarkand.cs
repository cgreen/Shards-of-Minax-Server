using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTimuridSamarkand : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTimuridSamarkand()
        {
            Name = "Treasure Chest of Timurid Samarkand";
            Hue = 1268; // Deep azure, reminiscent of Samarkand tiles

            // Decorative and magical treasures of Uzbekistan
            AddItem(CreateDecorativeItem<ArtifactVase>("Registan Ceremonial Vase", 1266), 0.20);
            AddItem(CreateDecorativeItem<GoldenChalice>("Cup of the Silk Road", 1161), 0.14);
            AddItem(CreateDecorativeItem<BrazierArtifact>("Timurid Brazier of Eternal Flame", 1175), 0.10);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Bukhara’s Scented Vase", 1365), 0.15);
            AddItem(CreateDecorativeItem<RandomFancyIngot>("Ulugh Beg’s Astrolabe", 1152), 0.12);
            AddItem(CreateDecorativeItem<RandomFancyBanner>("Banner of Khiva", 1167), 0.17);
            AddItem(CreateDecorativeItem<JadeSkull>("Jade Amulet of Sogdiana", 1416), 0.13);
            AddItem(CreateDecorativeItem<DecorativeBowWest>("Miniature Silk Road Caravan", 1153), 0.13);
            AddItem(new ChroniclesOfTheJadeCity(), 1.0);

            // Powerful Equipment
            AddItem(CreateTimuridWeapon(), 0.22);
            AddItem(CreateAstronomersRobe(), 0.18);
            AddItem(CreateGoldenChapan(), 0.20);
            AddItem(CreateDesertBoots(), 0.20);
            AddItem(CreateBukharaDagger(), 0.18);
            AddItem(CreateKhwarazmHelm(), 0.15);

            // Consumables and Treasures
            AddItem(CreatePomegranateWine(), 0.11);
            AddItem(CreateSilkRoadSpices(), 0.13);
            AddItem(CreateTimursFeast(), 0.09);
            AddItem(new Gold(Utility.Random(3000, 7000)), 0.14);
            AddItem(CreateGoldItem("Samarkand Coin"), 0.18);
            AddItem(CreateMap(), 0.06);
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

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreatePomegranateWine()
        {
            BottleArtifact wine = new BottleArtifact();
            wine.Name = "Ancient Pomegranate Wine";
            wine.Hue = 1760;
            return wine;
        }

        private Item CreateSilkRoadSpices()
        {
            SackOfSugar spice = new SackOfSugar();
            spice.Name = "Silk Road Spice Bundle";
            spice.Hue = 1163;
            return spice;
        }

        private Item CreateTimursFeast()
        {
            Cake cake = new Cake();
            cake.Name = "Timur’s Victory Feast";
            cake.Hue = 1167;
            return cake;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Afrosiyab";
            map.Bounds = new Rectangle2D(3700, 1300, 500, 500);
            map.NewPin = new Point2D(3850, 1500);
            map.Protected = true;
            return map;
        }

        // Unique Powerful Equipment

        private Item CreateTimuridWeapon()
        {
            Scimitar sword = new Scimitar();
            sword.Name = "Sword of Timur";
            sword.Hue = 1154;
            sword.MinDamage = 40;
            sword.MaxDamage = 72;
            sword.WeaponAttributes.HitHarm = 18;
            sword.WeaponAttributes.HitLeechMana = 20;
            sword.Attributes.AttackChance = 12;
            sword.Attributes.WeaponDamage = 25;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateAstronomersRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Ulugh Beg’s Astronomer’s Robe";
            robe.Hue = 1269;
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.SpellDamage = 18;
            robe.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            robe.SkillBonuses.SetValues(2, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateGoldenChapan()
        {
            Cloak chapan = new Cloak();
            chapan.Name = "Golden Chapan of the Emirs";
            chapan.Hue = 2125;
            chapan.Attributes.BonusMana = 6;
            chapan.Attributes.CastRecovery = 2;
            chapan.Attributes.LowerRegCost = 12;
            chapan.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            chapan.SkillBonuses.SetValues(1, SkillName.Anatomy, 6.0);
            XmlAttach.AttachTo(chapan, new XmlLevelItem());
            return chapan;
        }

        private Item CreateDesertBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Sandswept Boots of Khiva";
            boots.Hue = 1109;
            boots.Attributes.BonusDex = 12;
            boots.Attributes.NightSight = 1;
            boots.Attributes.Luck = 22;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateBukharaDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Bukhara Assassin";
            dagger.Hue = 1170;
            dagger.MinDamage = 28;
            dagger.MaxDamage = 55;
            dagger.WeaponAttributes.HitPoisonArea = 20;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.Attributes.BonusStam = 10;
            dagger.Attributes.WeaponSpeed = 20;
            dagger.SkillBonuses.SetValues(0, SkillName.Poisoning, 18.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Fencing, 14.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateKhwarazmHelm()
        {
            Circlet helm = new Circlet();
            helm.Name = "Circlet of Khwarazm Kings";
            helm.Hue = 1357;
            helm.BaseArmorRating = 40;
            helm.ArmorAttributes.LowerStatReq = 15;
            helm.AbsorptionAttributes.EaterFire = 8;
            helm.Attributes.BonusHits = 12;
            helm.Attributes.LowerManaCost = 5;
            helm.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        public TreasureChestOfTimuridSamarkand(Serial serial) : base(serial) { }

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

    // LORE BOOK

    public class ChroniclesOfTheJadeCity : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Jade City", "Al-Khwarizmi",
            new BookPageInfo
            (
                "In the oasis of the Zarafshan",
                "valley, cities of lapis and jade",
                "rose under the desert sun.",
                "Samarkand, jewel of the Silk",
                "Road, became the crossroads",
                "of worlds—where merchants,",
                "scholars, and conquerors met."
            ),
            new BookPageInfo
            (
                "Caravans carried spice and silk,",
                "while astronomers mapped the",
                "heavens from Ulugh Beg’s lofty",
                "madrasah. In Timur’s court,",
                "emperors gathered poets,",
                "calligraphers, and swordsmiths",
                "from every horizon."
            ),
            new BookPageInfo
            (
                "But empire’s glory is not",
                "eternal. The steppes sent forth",
                "the thunder of nomad hosts,",
                "and the sands reclaimed",
                "lost cities. Yet, beneath",
                "every ruined arch, the",
                "echo of civilization endures."
            ),
            new BookPageInfo
            (
                "Seek the Jade Amulet, talisman",
                "of Sogdian kings. Unlock the",
                "secrets of Ulugh Beg’s astrolabe.",
                "Drink the wine of ancient",
                "gardens, and hear the wisdom",
                "whispered on desert winds."
            ),
            new BookPageInfo
            (
                "These treasures belong not",
                "to any emperor, but to those",
                "with courage, curiosity, and",
                "respect for the past. Let the",
                "Chronicles of the Jade City",
                "inspire those who walk",
                "the Silk Road anew."
            ),
            new BookPageInfo
            (
                "Beware: for the treasures",
                "of Samarkand are guarded",
                "by the spirits of history.",
                "Honor what you take, and",
                "leave wisdom behind in",
                "your passing.",
                "",
                "- Al-Khwarizmi"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheJadeCity() : base(false)
        {
            Hue = 1268; // Lapis-lazuli blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Jade City");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Jade City");
        }

        public ChroniclesOfTheJadeCity(Serial serial) : base(serial) { }

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
