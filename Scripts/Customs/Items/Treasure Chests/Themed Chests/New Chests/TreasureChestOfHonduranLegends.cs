using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfHonduranLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfHonduranLegends()
        {
            Name = "Treasure Chest of Honduran Legends";
            Hue = 2052; // Emerald Green (Mayan jade vibe)

            // Decorative and historical artifacts
            AddItem(CreateColoredItem<ArtifactVase>("Lenca Pottery of Intibucá", 2105), 0.18);
            AddItem(CreateColoredItem<ArtifactLargeVase>("Jade Vase of Copán", 1157), 0.13);
            AddItem(CreateNamedItem<QuagmireZooStatuette>("Statuette of the Copán Jaguar"), 0.10);
            AddItem(CreateNamedItem<BrazierArtifact>("Lantern of La Mosquitia"), 0.09);
            AddItem(CreateNamedItem<Gold>("Pirate Doubloon from Roatán"), 0.14);
            AddItem(CreateNamedItem<Drums>("Garífuna Drum of Celebration"), 0.12);
            AddItem(CreateNamedItem<FancyPainting>("Sunrise over Lake Yojoa"), 0.09);

            // Traditional food & drinks
            AddItem(CreateNamedItem<CookieMix>("Baleada Especial"), 0.11);
            AddItem(CreateNamedItem<Cake>("Fiesta Tamal"), 0.11);
            AddItem(CreateNamedItem<GreenTea>("Cup of Honduran Horchata"), 0.12);

            // Legendary equipment
            AddItem(CreateLencaWarHelm(), 0.18);
            AddItem(CreatePiratesBoots(), 0.17);
            AddItem(CreateCopanPriestRobe(), 0.15);
            AddItem(CreateMayanScepter(), 0.13);

            // Lore Book
            AddItem(new ChroniclesOfHonduras(), 1.0);

            // Bonus loot
            AddItem(CreateNamedItem<Sextant>("Navigator's Sextant of the Bay Islands"), 0.10);
            AddItem(CreateColoredItem<SilverSteedZooStatuette>("Silver Macaw Figurine", 2101), 0.10);
            AddItem(CreateGoldItem("Ancient Mayan Coin"), 0.15);

            // Misc equipment
            AddItem(CreateJungleCloak(), 0.14);
            AddItem(CreatePirateCutlass(), 0.17);
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
            gold.Amount = Utility.Random(300, 1500);
            return gold;
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

        // Legendary Equipment

        private Item CreateLencaWarHelm()
        {
            PlateHelm helm = new PlateHelm();
            helm.Name = "Lenca Chief’s War Helm";
            helm.Hue = 2105; // Earthy red-brown
            helm.BaseArmorRating = 60;
            helm.Attributes.BonusHits = 15;
            helm.Attributes.BonusStr = 10;
            helm.Attributes.RegenHits = 3;
            helm.Attributes.ReflectPhysical = 10;
            helm.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            helm.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            helm.ArmorAttributes.SelfRepair = 5;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreatePiratesBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Pirate’s Lucky Boots";
            boots.Hue = 2117; // Deep navy
            boots.Attributes.Luck = 100;
            boots.Attributes.BonusDex = 8;
            boots.Attributes.BonusStam = 10;
            boots.Attributes.NightSight = 1;
            boots.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Snooping, 10.0);
            boots.SkillBonuses.SetValues(2, SkillName.Fencing, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateCopanPriestRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Copán High Priest";
            robe.Hue = 1153; // Jade
            robe.Attributes.BonusMana = 15;
            robe.Attributes.SpellDamage = 15;
            robe.Attributes.CastSpeed = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.Anatomy, 6.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateMayanScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Mayan Scepter of Copán";
            scepter.Hue = 1177; // Gold
            scepter.MinDamage = 25;
            scepter.MaxDamage = 45;
            scepter.WeaponAttributes.HitEnergyArea = 20;
            scepter.WeaponAttributes.HitLeechMana = 15;
            scepter.WeaponAttributes.SelfRepair = 3;
            scepter.Attributes.SpellChanneling = 1;
            scepter.Attributes.CastRecovery = 1;
            scepter.Attributes.WeaponSpeed = 10;
            scepter.SkillBonuses.SetValues(0, SkillName.Macing, 14.0);
            scepter.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        private Item CreateJungleCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Rainforest Spirit";
            cloak.Hue = 1420; // Jungle green
            cloak.Attributes.RegenStam = 4;
            cloak.Attributes.Luck = 25;
            cloak.Attributes.BonusHits = 7;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Tracking, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreatePirateCutlass()
        {
            Cutlass cutlass = new Cutlass();
            cutlass.Name = "Cutlass of the Caribbean Freebooter";
            cutlass.Hue = 2112; // Blackened steel
            cutlass.MinDamage = 22;
            cutlass.MaxDamage = 55;
            cutlass.WeaponAttributes.HitLightning = 15;
            cutlass.WeaponAttributes.SelfRepair = 4;
            cutlass.Attributes.AttackChance = 10;
            cutlass.SkillBonuses.SetValues(0, SkillName.Fencing, 16.0);
            cutlass.SkillBonuses.SetValues(1, SkillName.Parry, 7.0);
            XmlAttach.AttachTo(cutlass, new XmlLevelItem());
            return cutlass;
        }

        public TreasureChestOfHonduranLegends(Serial serial) : base(serial) { }

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

    public class ChroniclesOfHonduras : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Honduras – From Copán to Freedom", "El Scribe del Quetzal",
            new BookPageInfo
            (
                "In the dawn of ages,",
                "the valleys of Copán",
                "echoed with the songs",
                "of Maya kings. Cities",
                "rose and fell beneath",
                "the ceiba trees, temples",
                "carved with gods,",
                "stories in jade and stone."
            ),
            new BookPageInfo
            (
                "The Lenca guarded",
                "mountain paths,",
                "Lempira’s warriors fierce,",
                "defiant as the pines.",
                "Spanish ships came,",
                "bearing fire and greed,",
                "but the spirit of the",
                "earth would not yield."
            ),
            new BookPageInfo
            (
                "Gold from the rivers,",
                "jade from the hills,",
                "ancient drums at",
                "Garífuna shores. The",
                "pirate’s laughter over",
                "Caribbean waves, and",
                "the lost fortunes of",
                "Roatán’s hidden caves."
            ),
            new BookPageInfo
            (
                "Through storms of war,",
                "rebellion and hope,",
                "the people endured.",
                "Freedom declared,",
                "the blue and white",
                "banner rose. The heart",
                "of Honduras beats in",
                "every mountain and sea."
            ),
            new BookPageInfo
            (
                "Let this chest be a",
                "tribute to all who",
                "came before, to the",
                "mysteries of Copán,",
                "the courage of Lempira,",
                "the songs of the jungle,",
                "and the laughter on",
                "the Caribbean shore."
            ),
            new BookPageInfo
            (
                "May you remember:",
                "History is a living river.",
                "In these treasures, find",
                "the tales of the land,",
                "the dreams of a people.",
                "",
                "Viva Honduras.",
                "",
                "- El Scribe del Quetzal"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfHonduras() : base(false)
        {
            Hue = 2105; // Classic clay-red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Honduras – From Copán to Freedom");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Honduras – From Copán to Freedom");
        }

        public ChroniclesOfHonduras(Serial serial) : base(serial) { }

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
