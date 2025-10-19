using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBoliviasLostEmpires : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBoliviasLostEmpires()
        {
            Name = "Treasure Chest of Bolivia’s Lost Empires";
            Hue = 2652; // Deep Andes green

            // Add items to the chest
            AddItem(new AndeanCocaLeaves(), 0.20);
            AddItem(CreateDecorativeArtifact<ArtifactLargeVase>("Tiwanaku Ritual Vase", 1289), 0.14);
            AddItem(CreateDecorativeArtifact<GoldBricks>("Potosí Silver Ingots", 2309), 0.11);
            AddItem(CreateConsumable<GreaterCurePotion>("Chicha of the Sun", 2125), 0.13);
            AddItem(CreateNamedItem<PanFlute>("Mystic Pan Flute of the Altiplano"), 0.15);
            AddItem(CreateUniqueWeapon(), 0.18);
            AddItem(CreateUniqueArmor(), 0.18);
            AddItem(CreateNamedClothing(), 0.17);
            AddItem(CreateUniqueDagger(), 0.13);
            AddItem(new ChroniclesOfBoliviasEmpires(), 1.0);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateGoldItem("Incan Solar Disc"), 0.17);
            AddItem(CreateDecorativeArtifact<ArtifactVase>("Vase of Lake Titicaca", 1165), 0.15);
            AddItem(CreateDecorativeArtifact<QuagmireStatue>("Jaguar Statue of the Aymara", 1109), 0.09);
            AddItem(CreateUniqueFood(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeArtifact<T>(string name, int hue) where T : Item, new()
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

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(4000, 6500);
            return gold;
        }

        private Item CreateUniqueWeapon()
        {
            Scythe weapon = new Scythe();
            weapon.Name = "War Scythe of Tunupa";
            weapon.Hue = 1175; // Golden
            weapon.WeaponAttributes.HitLightning = 40;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLowerAttack = 30;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.MinDamage = 42;
            weapon.MaxDamage = 80;
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.BonusHits = 35;
            weapon.Attributes.Luck = 100;
            weapon.Slayer = SlayerName.Repond;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Potosí Conquistador";
            armor.Hue = 1920; // Silver
            armor.BaseArmorRating = 62;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.Luck = 65;
            armor.PhysicalBonus = 20;
            armor.FireBonus = 15;
            armor.ColdBonus = 15;
            armor.EnergyBonus = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateNamedClothing()
        {
            Poncho clothing = new Poncho();
            clothing.Name = "Rainbow Poncho of the Wiphala";
            clothing.Hue = 33; // Rainbow
            clothing.Attributes.Luck = 40;
            clothing.Attributes.NightSight = 1;
            clothing.SkillBonuses.SetValues(0, SkillName.Meditation, 8.0);
            clothing.SkillBonuses.SetValues(1, SkillName.Musicianship, 12.0);
            XmlAttach.AttachTo(clothing, new XmlLevelItem());
            return clothing;
        }

        private Item CreateUniqueDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Sacrificial Dagger of Lake Titicaca";
            dagger.Hue = 2223; // Aquamarine blue
            dagger.MinDamage = 25;
            dagger.MaxDamage = 59;
            dagger.WeaponAttributes.HitPoisonArea = 35;
            dagger.WeaponAttributes.HitColdArea = 20;
            dagger.Attributes.BonusDex = 12;
            dagger.Attributes.SpellChanneling = 1;
            dagger.SkillBonuses.SetValues(0, SkillName.Poisoning, 18.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Anatomy, 12.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Sun Gate of Tiwanaku";
            map.Bounds = new Rectangle2D(500, 500, 300, 300);
            map.NewPin = new Point2D(650, 650);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueFood()
        {
            CheeseWheel food = new CheeseWheel();
            food.Name = "Wheel of Queso Chuño";
            food.Hue = 1002; // Traditional
            return food;
        }

        // Example of a unique consumable plant
        public class AndeanCocaLeaves : BaseReagent
        {
            [Constructable]
            public AndeanCocaLeaves() : base(0xF8F)
            {
                Name = "Sacred Andean Coca Leaves";
                Hue = 1415;
                Stackable = true;
                Amount = Utility.RandomMinMax(4, 12);
            }
            public AndeanCocaLeaves(Serial serial) : base(serial) { }

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

        public TreasureChestOfBoliviasLostEmpires(Serial serial) : base(serial) { }
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

    public class ChroniclesOfBoliviasEmpires : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Bolivia's Empires", "Suma Qamaña",
            new BookPageInfo
            (
                "In the shadow of the Andes,",
                "great civilizations flourished.",
                "Tiwanaku, cradle of stone and",
                "sky, carved mysteries in the",
                "altiplano winds. They built the",
                "Gate of the Sun, aligned with",
                "solstice and star."
            ),
            new BookPageInfo
            (
                "Long after, the Inca road wound",
                "from Cusco to Collasuyu,",
                "binding highland towns in gold.",
                "The Aymara, the Quechua—each",
                "wove their spirits into earth,",
                "water, sun. Pachamama was",
                "mother to them all."
            ),
            new BookPageInfo
            (
                "Spanish conquistadors came,",
                "drawn by the lure of Potosí.",
                "Silver rivers ran to Spain, but",
                "the land remembered. Empires",
                "rose, fell, and were reborn in",
                "the dreams of revolutionaries."
            ),
            new BookPageInfo
            (
                "Now, the emerald jungles and",
                "salt deserts hold stories untold.",
                "From the high lakes to",
                "the windswept valleys, the",
                "treasures of Bolivia await the",
                "one bold enough to open this",
                "chest."
            ),
            new BookPageInfo
            (
                "Heed the warning, traveler:",
                "What you take from Pachamama,",
                "you must one day return.",
                "",
                "- The Spirits of the Andes",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBoliviasEmpires() : base(false)
        {
            Hue = 2652;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Bolivia's Empires");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Bolivia's Empires");
        }

        public ChroniclesOfBoliviasEmpires(Serial serial) : base(serial) { }

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

    // Example: Pan Flute musical instrument
    public class PanFlute : Item
    {
        [Constructable]
        public PanFlute() : base(0xE9E)
        {
            Name = "Mystic Pan Flute of the Altiplano";
            Hue = 1109;
            Weight = 1.0;
        }
        public PanFlute(Serial serial) : base(serial) { }
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

    // Example: Poncho as clothing
    public class Poncho : Robe
    {
        [Constructable]
        public Poncho() : base()
        {
            Name = "Rainbow Poncho of the Wiphala";
            Hue = 33;
            Weight = 3.0;
        }
        public Poncho(Serial serial) : base(serial) { }
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
