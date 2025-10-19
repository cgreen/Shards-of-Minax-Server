using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMontenegro : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMontenegro()
        {
            Name = "Treasure Chest of Montenegro's Mountain Kings";
            Hue = 2107; // Deep blue-mountain

            // Add items to the chest
            AddItem(CreateColoredItem<ArtifactVase>("Vase of Cetinje Monastery", 1175), 0.15);
            AddItem(CreateDecorativeSword(), 0.18);
            AddItem(CreateRoyalCloak(), 0.13);
            AddItem(CreateAncientCrown(), 0.10);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateBookOfLore(), 1.0);
            AddItem(CreateColoredItem<BottleArtifact>("Elixir of Black Mountain Strength", 2051), 0.15);
            AddItem(CreateColoredItem<Gold>("Ducat of Njegoš", 1289), 0.22);
            AddItem(CreateMonasticScroll(), 0.12);
            AddItem(CreateNamedItem<FeatheredHat>("Prince-Bishop's Cap"), 0.14);
            AddItem(CreateColoredItem<Diamond>("Mountain Sapphire", 1365), 0.19);
            AddItem(CreateHighlanderBoots(), 0.17);
            AddItem(CreateTraditionalKukri(), 0.12);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.23);
            AddItem(CreateVictoryBanner(), 0.07);
            AddItem(CreateMap(), 0.05);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
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

        private Item CreateDecorativeSword()
        {
            DecorativeSwordWest sword = new DecorativeSwordWest();
            sword.Name = "Sword of the Valiant Prince";
            sword.Hue = 2101;
            return sword;
        }

        private Item CreateRoyalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Royal Blue Cloak of Lovćen";
            cloak.Hue = 2065;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.BonusInt = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 12.5);
            cloak.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateAncientCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of the Petrović Dynasty";
            crown.Hue = 1161;
            crown.Attributes.BonusHits = 25;
            crown.Attributes.BonusStam = 10;
            crown.Attributes.BonusMana = 10;
            crown.Attributes.NightSight = 1;
            crown.Attributes.DefendChance = 8;
            crown.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateMonasticScroll()
        {
            SimpleNote scroll = new SimpleNote();
            scroll.NoteString = "By the candle’s glow in Ostrog’s cave, wisdom is preserved. May the mountains shield your spirit, as faith shields your heart.";
            scroll.TitleString = "Scroll of Ostrog Monks";
            return scroll;
        }

        private Item CreateHighlanderBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Highlander Boots of Durmitor";
            boots.Hue = 2100;
            boots.Attributes.BonusDex = 20;
            boots.Attributes.Luck = 25;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateTraditionalKukri()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Mountain Kukri";
            dagger.Hue = 1109;
            dagger.MinDamage = Utility.Random(17, 27);
            dagger.MaxDamage = Utility.Random(37, 55);
            dagger.Attributes.BonusStam = 10;
            dagger.WeaponAttributes.HitLeechStam = 10;
            dagger.WeaponAttributes.HitLowerAttack = 10;
            dagger.WeaponAttributes.SelfRepair = 5;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateVictoryBanner()
        {
            UltimaBanner banner = new UltimaBanner();
            banner.Name = "Banner of Grahovo Victory";
            banner.Hue = 1159;
            return banner;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Montenegro's Wild Peaks";
            map.Bounds = new Rectangle2D(1800, 2200, 350, 375);
            map.NewPin = new Point2D(1950, 2350);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Broadsword(), new Katana(), new Scimitar(), new Pike(), new Bow()
            );
            weapon.Name = "Hero's Blade of the Black Mountain";
            weapon.Hue = Utility.RandomList(1109, 2107, 2065);
            weapon.MaxDamage = Utility.Random(40, 75);
            weapon.MinDamage = Utility.Random(20, 38);
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.BonusHits = 18;
            weapon.WeaponAttributes.HitLightning = 12;
            weapon.WeaponAttributes.HitFireball = 10;
            weapon.WeaponAttributes.SelfRepair = 7;
            weapon.Slayer = SlayerName.Repond;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateHelm(), new LeatherGorget(), new ChainLegs()
            );
            armor.Name = "Warrior's Mail of Crnojević";
            armor.Hue = Utility.RandomList(2107, 2065, 1175, 1161);
            armor.BaseArmorRating = Utility.Random(40, 75);
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.Attributes.BonusHits = 20;
            armor.Attributes.RegenHits = 3;
            armor.Attributes.Luck = 30;
            armor.Attributes.BonusStr = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBookOfLore()
        {
            return new ChroniclesOfTheBlackMountain();
        }

        public TreasureChestOfMontenegro(Serial serial) : base(serial)
        {
        }

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

    public class ChroniclesOfTheBlackMountain : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Black Mountain", "Scribe of Cetinje",
            new BookPageInfo
            (
                "Above the valleys of",
                "the Adriatic, under",
                "the shadow of eternal",
                "peaks, lies Montenegro—",
                "Crna Gora. Born of",
                "stone and storm, its",
                "people defied empire",
                "and bent only to God."
            ),
            new BookPageInfo
            (
                "The mountain kings,",
                "sworn both to sword",
                "and scripture, led",
                "their tribes from",
                "Cetinje’s halls. They",
                "preserved our faith",
                "when all else fell",
                "to flame and blade."
            ),
            new BookPageInfo
            (
                "Ottoman hosts pressed",
                "at every pass. Yet",
                "in every glen and",
                "ridge, highlanders",
                "rose in arms. Outnumbered,",
                "never undone. We fought",
                "for the land, and the",
                "land shaped us."
            ),
            new BookPageInfo
            (
                "Through endless night",
                "and ancient feud, we",
                "held the monastery’s",
                "light. Njegoš, poet-king,",
                "brought wisdom and",
                "glory, his words echo",
                "like mountain thunder.",
                ""
            ),
            new BookPageInfo
            (
                "Glory in freedom,",
                "not in conquest. In",
                "every stone lies a",
                "story. In every son,",
                "a hero. Let the peaks",
                "remember, let the world",
                "not forget: Here stands",
                "the last bastion."
            ),
            new BookPageInfo
            (
                "He who dares the",
                "Black Mountain must",
                "bring courage, for",
                "its treasure is not",
                "gold, but the spirit",
                "of a people unbroken.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Find this chest,",
                "honor our memory.",
                "Take only what you",
                "may bear. For the",
                "greatest riches of",
                "Montenegro are earned,",
                "not stolen.",
                ""
            ),
            new BookPageInfo
            (
                "By the hand of",
                "the Scribe of Cetinje,",
                "in the year of",
                "the mountain wind.",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheBlackMountain() : base(false)
        {
            Hue = 2107; // Deep blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Black Mountain");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Black Mountain");
        }

        public ChroniclesOfTheBlackMountain(Serial serial) : base(serial) { }

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
