using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfHaitisLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfHaitisLegacy()
        {
            Name = "Treasure Chest of Haiti’s Legacy";
            Hue = 1149; // Deep blue (Haitian flag)

            // Add items to the chest
            AddItem(CreateArtifact("Taino Sun Idol", typeof(ArtifactVase), 2120), 0.15);
            AddItem(CreateArtifact("Vodou Veve of Papa Legba", typeof(CrystalBallStatuette), 1150), 0.12);
            AddItem(CreateArtifact("Drum of Bois Caïman", typeof(FancyCopperSunflower), 242), 0.08);
            AddItem(CreateArtifact("Maroon’s Escape Map", typeof(SimpleMap), 1207), 0.10);
            AddItem(CreateArtifact("Revolutionary Cockade", typeof(Bandana), 33), 0.13);
            AddItem(CreateArtifact("Kanaval Mask", typeof(OrcMask), 1355), 0.13);
            AddItem(CreateArtifact("Pearl of Saint Domingue", typeof(Diamond), 2497), 0.10);
            AddItem(new SongsOfAyitiBook(), 1.0);
            AddItem(CreateFood("Freedom Drumstick", typeof(CookedBird), 0x48F, "Drumstick seasoned with hope"), 0.18);
            AddItem(CreateFood("Sweet Kremas", typeof(MilkChocolate), 0x489, "A creamy Haitian holiday drink"), 0.14);
            AddItem(CreateEquipment(), 0.22);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateVodouWeapon(), 0.15);
            AddItem(CreateArtifact("Symbol of the Revolution", typeof(GoldBricks), 2213), 0.12);
            AddItem(CreateArtifact("Flag of Liberty", typeof(RandomFancyBanner), 1161), 0.09);
            AddItem(new Gold(Utility.Random(1, 4000)), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative artifact helper
        private Item CreateArtifact(string name, Type baseType, int hue)
        {
            Item art = (Item)Activator.CreateInstance(baseType);
            art.Name = name;
            art.Hue = hue;
            return art;
        }

        // Unique food/consumable helper
        private Item CreateFood(string name, Type baseType, int hue, string desc)
        {
            Item food = (Item)Activator.CreateInstance(baseType);
            food.Name = name;
            food.Hue = hue;
            food.LootType = LootType.Blessed;

            return food;
        }

        // Unique revolutionary weapon
        private Item CreateVodouWeapon()
        {
            // Magic Wakizashi as the "Blade of Dessalines"
            Wakizashi blade = new Wakizashi();
            blade.Name = "Blade of Dessalines";
            blade.Hue = 1152; // Silver-blue
            blade.MinDamage = 35;
            blade.MaxDamage = 65;
            blade.Attributes.BonusStr = 12;
            blade.Attributes.BonusHits = 16;
            blade.Attributes.WeaponSpeed = 25;
            blade.Attributes.WeaponDamage = 35;
            blade.Slayer = SlayerName.Repond;
            blade.WeaponAttributes.HitLightning = 25;
            blade.WeaponAttributes.HitLeechHits = 15;
            blade.WeaponAttributes.SelfRepair = 7;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            blade.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            blade.SkillBonuses.SetValues(2, SkillName.Healing, 8.0);
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        // Unique epic equipment
        private Item CreateEquipment()
        {
            // Magic Quarterstaff as "Staff of Ayizan"
            QuarterStaff staff = new QuarterStaff();
            staff.Name = "Staff of Ayizan";
            staff.Hue = 2115; // Spiritual green
            staff.MinDamage = 25;
            staff.MaxDamage = 48;
            staff.Attributes.BonusMana = 18;
            staff.Attributes.SpellDamage = 28;
            staff.Attributes.BonusInt = 12;
            staff.Attributes.CastSpeed = 1;
            staff.WeaponAttributes.HitLowerAttack = 25;
            staff.WeaponAttributes.HitLeechMana = 10;
            staff.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            staff.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        // Unique epic armor
        private Item CreateArmor()
        {
            // DragonChest as "Taino Defender’s Vest"
            DragonChest chest = new DragonChest();
            chest.Name = "Taino Defender’s Vest";
            chest.Hue = 1422; // Sun-gold
            chest.BaseArmorRating = Utility.Random(45, 75);
            chest.ArmorAttributes.LowerStatReq = 18;
            chest.Attributes.BonusHits = 20;
            chest.Attributes.BonusDex = 10;
            chest.ColdBonus = 12;
            chest.EnergyBonus = 15;
            chest.FireBonus = 8;
            chest.PhysicalBonus = 25;
            chest.PoisonBonus = 10;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 14.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Unique epic clothing
        private Item CreateClothing()
        {
            // Robe as "Robe of Toussaint’s Resolve"
            Robe robe = new Robe();
            robe.Name = "Robe of Toussaint’s Resolve";
            robe.Hue = 1164; // Royal blue
            robe.Attributes.Luck = 60;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.BonusInt = 8;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            robe.SkillBonuses.SetValues(2, SkillName.MagicResist, 6.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        public TreasureChestOfHaitisLegacy(Serial serial) : base(serial) { }

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
    public class SongsOfAyitiBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Songs of Ayiti: From Taino to Revolution", "Anonymous Griot",
            new BookPageInfo
            (
                "Before ships touched the sand,",
                "The island sang with Taino hands.",
                "A paradise, green and bright,",
                "Arawak dreams beneath the light."
            ),
            new BookPageInfo
            (
                "Then came Columbus, then the cross,",
                "Chains of iron, lives were lost.",
                "Yet spirits stirred, the drums beat loud,",
                "Hope unbowed, but voices cowed."
            ),
            new BookPageInfo
            (
                "Sugar fields and midnight screams,",
                "Marooned hope and broken dreams.",
                "Vodou flames in secret night,",
                "Freedom calls, and spirits fight."
            ),
            new BookPageInfo
            (
                "Bois Caïman, storm and fire,",
                "Bondye bless, the lwa inspire.",
                "Toussaint, Dessalines, courage vast,",
                "Liberty’s thunder breaks at last."
            ),
            new BookPageInfo
            (
                "Red and blue, the flag unfurls,",
                "First black nation, shock the world.",
                "Songs of Ayiti, never cease—",
                "Born of struggle, rise in peace."
            ),
            new BookPageInfo
            (
                "Yet Ayiti’s tale still goes on,",
                "Through quake and storm, the people strong.",
                "Art and laughter, music’s pride,",
                "Freedom’s flame shall not subside."
            ),
            new BookPageInfo
            (
                "Ayibobo! Shout it high—",
                "For every child, for every cry.",
                "This chest holds our history’s heart,",
                "Ayiti’s soul: undimmed, apart."
            ),
            new BookPageInfo
            (
                "",
                "May you remember: from earth to sky,",
                "Ayiti lives. Ayibobo. Ayibobo!",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SongsOfAyitiBook() : base(false)
        {
            Hue = 1161; // Haitian blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Songs of Ayiti: From Taino to Revolution");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Songs of Ayiti: From Taino to Revolution");
        }

        public SongsOfAyitiBook(Serial serial) : base(serial) { }

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
