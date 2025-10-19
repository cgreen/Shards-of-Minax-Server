using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfVenezuela : WoodenChest
    {
        [Constructable]
        public TreasureChestOfVenezuela()
        {
            Name = "Treasure Chest of Venezuela's Legends";
            Hue = 1172; // A unique gold-blue hue inspired by the Venezuelan flag

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ancient Orinoco Vase", 1378), 0.20);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Crystal Ball of the Llanos", 1153), 0.13);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Portrait of Simón Bolívar", 1154), 0.12);
            AddItem(CreateDecorativeItem<WaterFountain>("Miniature Angel Falls Fountain", 1260), 0.14);
            AddItem(CreateUniqueConsumable<GreenTea>("Café Guayoyo", 1149), 0.30);
            AddItem(CreateUniqueConsumable<BreadLoaf>("Arepa of Renewal", 1189), 0.30);
            AddItem(CreateUniqueConsumable<RandomFancyFish>("Orinoco River Catfish", 1270), 0.15);
            AddItem(CreateGoldItem("Colonial Bolívar Coins"), 0.15);
            AddItem(CreateUniqueClothing(), 0.22);
            AddItem(CreateUniqueArmor(), 0.21);
            AddItem(CreateUniqueWeapon(), 0.20);
            AddItem(CreateUniqueDagger(), 0.15);
            AddItem(CreateUniqueSash(), 0.18);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Jaguar of the Amazon Sculpture", 1109), 0.12);
            AddItem(CreateDecorativeItem<WindChimes>("Sacred Tepui Wind Chimes", 1234), 0.10);
            AddItem(CreateMap(), 0.07);
            AddItem(new Gold(Utility.Random(1500, 6500)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative and Consumable Creators

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            item.LootType = LootType.Blessed;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to El Dorado";
            map.Bounds = new Rectangle2D(700, 1300, 700, 600); // Fictitious in-world coordinates
            map.NewPin = new Point2D(999, 1533);
            map.Protected = true;
            return map;
        }

        // Unique Equipment Creators

        private Item CreateUniqueWeapon()
        {
            Katana weapon = new Katana();
            weapon.Name = "Sword of Libertador";
            weapon.Hue = 1174;
            weapon.MaxDamage = Utility.Random(35, 70);
            weapon.MinDamage = Utility.Random(18, 34);
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 10;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Golden Jaguar";
            armor.Hue = 2212;
            armor.BaseArmorRating = Utility.Random(50, 80);
            armor.Attributes.BonusHits = 20;
            armor.Attributes.BonusStam = 10;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            armor.ColdBonus = 10;
            armor.FireBonus = 10;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 10;
            armor.PhysicalBonus = 20;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robes of the Andean Sage";
            robe.Hue = 1175;
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusMana = 15;
            robe.Attributes.CastRecovery = 2;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of María Lionza";
            dagger.Hue = 1150;
            dagger.MinDamage = 18;
            dagger.MaxDamage = 42;
            dagger.Attributes.BonusDex = 12;
            dagger.WeaponAttributes.HitLowerAttack = 15;
            dagger.WeaponAttributes.HitPoisonArea = 15;
            dagger.Attributes.SpellChanneling = 1;
            dagger.SkillBonuses.SetValues(0, SkillName.Poisoning, 10.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateUniqueSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of the Sacred Tepui";
            sash.Hue = 2052;
            sash.Attributes.BonusInt = 10;
            sash.Attributes.NightSight = 1;
            sash.Attributes.LowerManaCost = 8;
            sash.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 15.0);
            sash.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        // Lore Book
        private Item CreateLoreBook()
        {
            return new ChroniclesOfVenezuela();
        }

        public TreasureChestOfVenezuela(Serial serial) : base(serial) { }

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

    // Lore Book Class
    public class ChroniclesOfVenezuela : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Venezuela: From Legends to Liberty", "Scribe of the Andes",
            new BookPageInfo
            (
                "Beneath the vast Orinoco skies,",
                "where rivers gleam and tepui rise,",
                "the people of Venezuela have",
                "woven legends in the shadow",
                "of emerald jungles and gold-laden",
                "mountains. From the first tribes",
                "and their mighty chiefs, tales",
                "of El Dorado filled the land."
            ),
            new BookPageInfo
            (
                "The Spanish came, bearing iron",
                "and greed, chasing rumors of",
                "hidden cities. Yet they found",
                "resistance in every jungle and",
                "plain. Heroes like Guaicaipuro,",
                "chief of the Caracas, stood tall,",
                "fighting for freedom and honor.",
                ""
            ),
            new BookPageInfo
            (
                "Centuries passed, and liberty",
                "found its voice in Simón Bolívar.",
                "The Liberator led the people",
                "against colonial chains, uniting",
                "nations beneath a single banner.",
                "His sword and words sparked",
                "revolutions, echoing through",
                "the valleys and mountains."
            ),
            new BookPageInfo
            (
                "Yet the land is more than history.",
                "From the mystical María Lionza",
                "to the eternal thunder of Angel",
                "Falls, magic still lingers here.",
                "The jaguar roams, the condor",
                "soars, and the heart of the",
                "llanero beats wild and free.",
                ""
            ),
            new BookPageInfo
            (
                "May these treasures remind you",
                "of the valor, beauty, and wonder",
                "of Venezuela. In every gem and",
                "artifact, a story waits to be told.",
                "",
                "Remember: the greatest treasure",
                "of Venezuela is not gold or jade,",
                "but the spirit of its people.",
                ""
            ),
            new BookPageInfo
            (
                "If you seek El Dorado, beware.",
                "True riches lie within the soul,",
                "the rivers, the music, and the",
                "dreams of the llanos.",
                "",
                "- Scribe of the Andes",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfVenezuela() : base(false)
        {
            Hue = 1155; // Book hue inspired by the blue in Venezuela's flag
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Venezuela: From Legends to Liberty");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Venezuela");
        }

        public ChroniclesOfVenezuela(Serial serial) : base(serial) { }

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
