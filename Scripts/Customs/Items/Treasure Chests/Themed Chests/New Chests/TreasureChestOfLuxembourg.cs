using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLuxembourg : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLuxembourg()
        {
            Name = "Treasure Chest of Luxembourg";
            Hue = 2065; // A royal blue (Luxembourg flag blue)

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vase of the Alzette", 2125), 0.18);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Bookshelf of European Treaties", 2101), 0.11);
            AddItem(CreateDecorativeItem<Painting4WestArtifact>("Portrait of Count Siegfried", 2065), 0.13);
            AddItem(CreateDecorativeItem<ArtifactVase>("Rose of the Grand Duchess", 1157), 0.15);
            AddItem(CreateDecorativeItem<KingsPainting1>("Old Cityscape of Luxembourg", 2075), 0.10);
            AddItem(CreateDecorativeItem<ZenRock2Artifact>("Rock of the Fortress Walls", 2401), 0.16);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Sword Display of the Fortress Guard", 1102), 0.09);
            AddItem(CreateDecorativeItem<TowerLanternArtifact>("Lantern of the Grund", 1151), 0.20);
            AddItem(CreateDecorativeItem<GoldBricks>("Gold Bullion of European Banks", 2213), 0.10);
            AddItem(CreateFoodItem<BreadLoaf>("Pain d'Épices du Luxembourg", 0), 0.14);
            AddItem(CreateFoodItem<Bottle>("Moselle Valley White Wine", 1257), 0.11);
            AddItem(CreateBookOfLore(), 1.0);

            // Equipment
            AddItem(CreateWeapon(), 0.25);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateCloak(), 0.20);
            AddItem(CreateRing(), 0.18);
            AddItem(CreateSash(), 0.15);

            // Random coin
            AddItem(CreateLuxembourgCoin(), 0.22);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative/Consumable Items
        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }
        private Item CreateFoodItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // Unique "Luxembourgish Franc" gold item
        private Item CreateLuxembourgCoin()
        {
            Gold gold = new Gold(Utility.Random(400, 1200));
            gold.Name = "Luxembourgish Franc";
            gold.Hue = 2213;
            return gold;
        }

        // Book of Lore
        private Item CreateBookOfLore()
        {
            return new ChroniclesOfTheFortressCity();
        }

        // Equipment Methods
        private Item CreateWeapon()
        {
            Broadsword sword = new Broadsword();
            sword.Name = "Fortress Defender’s Broadsword";
            sword.Hue = 2075;
            sword.WeaponAttributes.HitFireball = 40;
            sword.WeaponAttributes.HitLowerAttack = 35;
            sword.WeaponAttributes.SelfRepair = 8;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.AttackChance = 12;
            sword.Attributes.DefendChance = 10;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            sword.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Red Lion";
            chest.Hue = 2065;
            chest.BaseArmorRating = 58;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.Luck = 65;
            chest.Attributes.ReflectPhysical = 10;
            chest.ArmorAttributes.LowerStatReq = 20;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Three Languages";
            cloak.Hue = 1153; // Cyan blue
            cloak.Attributes.BonusMana = 15;
            cloak.Attributes.RegenMana = 3;
            cloak.Attributes.LowerRegCost = 20;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Inscribe, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Eurozone Signet Ring";
            ring.Hue = 1155;
            ring.Attributes.BonusStr = 8;
            ring.Attributes.BonusDex = 8;
            ring.Attributes.BonusInt = 8;
            ring.Attributes.CastRecovery = 2;
            ring.Attributes.CastSpeed = 2;
            ring.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.Focus, 7.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of European Unity";
            sash.Hue = 1288; // Deep red
            sash.Attributes.Luck = 44;
            sash.Attributes.BonusHits = 10;
            sash.Attributes.RegenHits = 2;
            sash.SkillBonuses.SetValues(0, SkillName.Peacemaking, 15.0);
            sash.SkillBonuses.SetValues(1, SkillName.Musicianship, 15.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        public TreasureChestOfLuxembourg(Serial serial) : base(serial) { }

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

    // Custom Lore Book: Chronicles of the Fortress City
    public class ChroniclesOfTheFortressCity : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Fortress City", "Chronicler of the Alzette",
            new BookPageInfo
            (
                "Upon the Bock promontory,",
                "in the year 963, Count",
                "Siegfried purchased Lucilinburhuc,",
                "the 'little fortress' that",
                "would become Luxembourg.",
                "",
                "From stone roots, the city",
                "rose, watching centuries pass."
            ),
            new BookPageInfo
            (
                "Through sieges and treaties,",
                "Luxembourg changed hands:",
                "Burgundians, Habsburgs, French,",
                "Spanish, Prussians — all",
                "left their mark. Yet the",
                "Red Lion flag endured,",
                "waving above the ramparts."
            ),
            new BookPageInfo
            (
                "The city’s walls grew thick,",
                "fortified by Vauban, famed",
                "across Europe. 'Gibraltar of",
                "the North,' they called it,",
                "impregnable but not unbreakable,",
                "as peace reshaped the land."
            ),
            new BookPageInfo
            (
                "In 1867, the fortress was",
                "dismantled; Luxembourg was",
                "declared neutral. Yet the",
                "city thrived, a crossroads",
                "of cultures, where German,",
                "French, and Luxembourgish",
                "tongues mingle in the streets."
            ),
            new BookPageInfo
            (
                "Surviving wars, division, and",
                "occupation, the Grand Duchy",
                "found its place. Today,",
                "Luxembourg is a founder of",
                "the European Union, heart",
                "of diplomacy, and banking."
            ),
            new BookPageInfo
            (
                "To the seeker: Within these",
                "walls, gold and history",
                "lie entwined. Treasure the",
                "stories of the Fortress City,",
                "for they are more enduring",
                "than any coin or sword.",
                "",
                "- Chronicler of the Alzette"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheFortressCity() : base(false)
        {
            Hue = 2065; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Fortress City");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Fortress City");
        }

        public ChroniclesOfTheFortressCity(Serial serial) : base(serial) { }

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
