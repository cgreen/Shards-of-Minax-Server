using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNorway : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNorway()
        {
            Name = "Treasure Chest of Norway";
            Hue = 2406; // Blue & silver, inspired by Norwegian flag & ice

            // Add items to the chest
            AddItem(new SagasOfNorway(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Runestone of the North", 2101), 0.25);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Seidr Oracle's Crystal", 1153), 0.18);
            AddItem(CreateDecorativeItem<WolfStatue>("Odin’s Wolf Totem", 1109), 0.22);
            AddItem(CreateDecorativeItem<DragonLamp>("Lamp of Midgard", 1150), 0.13);
            AddItem(CreateConsumable<GreaterHealPotion>("Viking Berserker's Mead", 2213), 0.19);
            AddItem(CreateConsumable<RandomFancyFish>("Fjord Salmon Feast", 2074), 0.18);
            AddItem(CreateWeapon(), 0.24);
            AddItem(CreateArmor(), 0.24);
            AddItem(CreateCloak(), 0.18);
            AddItem(CreateHelm(), 0.22);
            AddItem(CreateShield(), 0.19);
            AddItem(CreateSash(), 0.18);
            AddItem(CreateGoldItem("Ancient Norse Coin"), 0.20);
            AddItem(CreateDecorativeItem<SwordDisplay1WestArtifact>("Sword of Harald Fairhair", 2101), 0.16);
            AddItem(CreateMap(), 0.05);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(500, 3000);
            return gold;
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Saga Map of the Fjords";
            map.Bounds = new Rectangle2D(1000, 2000, 300, 500);
            map.NewPin = new Point2D(1150, 2300);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new VikingSword(),
                new Axe(),
                new Spear(),
                new Scimitar()
            );
            weapon.Name = "Mjolnir’s Fury";
            weapon.Hue = 2101; // Frosty blue
            weapon.MaxDamage = Utility.Random(45, 85);
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.WeaponDamage = 25;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitColdArea = 15;
            weapon.Attributes.BonusStam = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(),
                new ChainCoif(),
                new LeatherGorget(),
                new RingmailLegs()
            );
            armor.Name = "Frostforged Norse Plate";
            armor.Hue = 1152;
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.Attributes.BonusHits = 20;
            armor.Attributes.ReflectPhysical = 10;
            armor.Attributes.BonusStr = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            armor.ColdBonus = 20;
            armor.PhysicalBonus = 10;
            armor.FireBonus = 5;
            armor.PoisonBonus = 8;
            armor.EnergyBonus = 5;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Midnight Fjords";
            cloak.Hue = 1175;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.Luck = 100;
            cloak.Attributes.BonusMana = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateHelm()
        {
            NorseHelm helm = new NorseHelm();
            helm.Name = "Helm of Odin’s Wisdom";
            helm.Hue = 2406;
            helm.BaseArmorRating = Utility.Random(25, 55);
            helm.Attributes.BonusInt = 12;
            helm.Attributes.SpellDamage = 10;
            helm.SkillBonuses.SetValues(0, SkillName.EvalInt, 15.0);
            helm.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateShield()
        {
            WoodenShield shield = new WoodenShield();
            shield.Name = "Shield of the Midgard Serpent";
            shield.Hue = 2125;
            shield.Attributes.DefendChance = 20;
            shield.Attributes.BonusDex = 8;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            shield.ColdBonus = 10;
            shield.PoisonBonus = 8;
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of Saga Keepers";
            sash.Hue = 2065;
            sash.Attributes.Luck = 60;
            sash.Attributes.BonusHits = 5;
            sash.SkillBonuses.SetValues(0, SkillName.Inscribe, 15.0);
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        public TreasureChestOfNorway(Serial serial) : base(serial) { }

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

    public class SagasOfNorway : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Sagas of Norway", "Skald Hrafnsson",
            new BookPageInfo
            (
                "Hearken, O traveler, to",
                "the tale of Norway—",
                "where wild fjords cut",
                "deep into earth, and",
                "mountains wear snowy",
                "crowns. The Norsemen",
                "came from ice and fire,",
                "from Odin’s breath."
            ),
            new BookPageInfo
            (
                "Here sailed dragon-ships,",
                "swift as wind, bearing",
                "warriors and kings.",
                "They carved runes,",
                "raised stones to the",
                "gods, and feasted under",
                "the northern lights.",
                "Saga and song were law."
            ),
            new BookPageInfo
            (
                "Harald Fairhair gathered",
                "the clans beneath one",
                "banner; his sword united",
                "the land. But the sagas",
                "speak, too, of wise",
                "queens, bold explorers,",
                "skalds who kept memory,",
                "and farmers of green fjords."
            ),
            new BookPageInfo
            (
                "The Allfather watched,",
                "one eye on Midgard.",
                "Thor’s hammer cracked",
                "the sky. Trolls and Jotun",
                "hid in wild places, while",
                "men and women built",
                "longhouses and dreamed",
                "of Valhalla’s halls."
            ),
            new BookPageInfo
            (
                "Trade and battle, myth",
                "and truth—these shaped",
                "the Norse. Their ships",
                "touched distant shores;",
                "Iceland, Greenland, Vinland",
                "in the west. Even as Christ’s",
                "cross replaced the runes,",
                "the old songs lingered."
            ),
            new BookPageInfo
            (
                "Now, O seeker of treasure,",
                "know this: The riches of",
                "Norway lie not only in gold,",
                "but in courage, in cunning,",
                "and in tales. May this chest",
                "bring you the favor of Odin,",
                "the strength of Thor, and",
                "the wisdom of the skalds."
            ),
            new BookPageInfo
            (
                "Take heed! For some",
                "legends are best left",
                "undisturbed, and some",
                "spirits do not sleep—",
                "not in mountain, nor sea,",
                "nor in the memory of",
                "the North.",
                ""
            ),
            new BookPageInfo
            (
                "- Skald Hrafnsson",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SagasOfNorway() : base(false)
        {
            Hue = 2406; // Frost/blue hue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Sagas of Norway");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Sagas of Norway");
        }

        public SagasOfNorway(Serial serial) : base(serial) { }

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
