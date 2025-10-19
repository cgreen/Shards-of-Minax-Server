using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheDanes : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheDanes()
        {
            Name = "Treasure Chest of the Danes";
            Hue = 1152; // Deep northern blue

            // Add themed items
            AddItem(CreateRunestone(), 0.18);
            AddItem(CreateDecorativeHorn(), 0.10);
            AddItem(CreateColoredItem<GreaterHealPotion>("Mjød of the Shieldmaidens", 1266), 0.17);
            AddItem(CreateDecorativeBanner(), 0.13);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Skjoldung Kings"), 0.16);
            AddItem(CreateRuneSword(), 0.14);
            AddItem(CreateVikingHelm(), 0.18);
            AddItem(CreateDanishCloak(), 0.16);
            AddItem(CreateUniqueAxe(), 0.11);
            AddItem(CreateUniqueShield(), 0.10);
            AddItem(CreateColoredItem<Ruby>("Ruby of Roskilde", 1899), 0.13);
            AddItem(CreateNamedItem<GreaterHealPotion>("Potion of Viking Endurance"), 0.14);
            AddItem(CreateGoldItem("Danish Gold Coin"), 0.13);
            AddItem(CreateDecorativeBoatModel(), 0.09);
            AddItem(CreateDecorativeHornedCup(), 0.12);
            AddItem(new SagasOfTheDanes(), 1.0);
            AddItem(new Gold(Utility.Random(1, 7500)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // --- Unique Item Creators ---

        private Item CreateRunestone()
        {
            Diamond rune = new Diamond();
            rune.Name = "Runestone of Jelling";
            rune.Hue = 2505;
            return rune;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
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

        private Item CreateDecorativeHorn()
        {
            Sculpture1Artifact horn = new Sculpture1Artifact();
            horn.Name = "Drinking Horn of Harald Bluetooth";
            horn.Hue = 1175;
            return horn;
        }

        private Item CreateDecorativeBanner()
        {
            UltimaBanner banner = new UltimaBanner();
            banner.Name = "Banner of the Dannebrog";
            banner.Hue = 2075;
            return banner;
        }

        private Item CreateDecorativeBoatModel()
        {
            AncientShipModelOfTheHMSCape boat = new AncientShipModelOfTheHMSCape();
            boat.Name = "Model of a Viking Longship";
            boat.Hue = 1170;
            return boat;
        }

        private Item CreateDecorativeHornedCup()
        {
            FancyHornOfPlenty cup = new FancyHornOfPlenty();
            cup.Name = "Horned Cup of Mead";
            cup.Hue = 1160;
            return cup;
        }

        private Item CreateRuneSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Rune Sword of Ragnar";
            sword.Hue = 1109;
            sword.Attributes.WeaponDamage = 45;
            sword.Attributes.WeaponSpeed = 20;
            sword.Attributes.SpellChanneling = 1;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 15.0);
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitLeechHits = 10;
            sword.WeaponAttributes.SelfRepair = 6;
            sword.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateVikingHelm()
        {
            NorseHelm helm = new NorseHelm();
            helm.Name = "Helm of the Viking Raiders";
            helm.Hue = 1102;
            helm.BaseArmorRating = 60;
            helm.Attributes.BonusStr = 10;
            helm.Attributes.BonusHits = 12;
            helm.Attributes.RegenHits = 2;
            helm.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateDanishCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Northern Winds";
            cloak.Hue = 1359; // Frosty blue
            cloak.Attributes.Luck = 30;
            cloak.Attributes.BonusStam = 8;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateUniqueAxe()
        {
            DoubleAxe axe = new DoubleAxe();
            axe.Name = "Dane Axe of the Berserker";
            axe.Hue = 1945; // Blood red
            axe.Attributes.WeaponDamage = 50;
            axe.Attributes.WeaponSpeed = 18;
            axe.Attributes.AttackChance = 15;
            axe.Attributes.DefendChance = 12;
            axe.WeaponAttributes.HitFireball = 20;
            axe.WeaponAttributes.HitLeechStam = 10;
            axe.SkillBonuses.SetValues(0, SkillName.Lumberjacking, 20.0);
            axe.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(axe, new XmlLevelItem());
            return axe;
        }

        private Item CreateUniqueShield()
        {
            WoodenShield shield = new WoodenShield();
            shield.Name = "Round Shield of the Jomsvikings";
            shield.Hue = 1388;
            shield.Attributes.DefendChance = 22;
            shield.Attributes.BonusHits = 15;
            shield.Attributes.ReflectPhysical = 12;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // --- LORE BOOK ---
        public class SagasOfTheDanes : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Sagas of the Danes", "Chronicler of the North",
                new BookPageInfo
                (
                    "From the mists of Skagen’s shore,",
                    "where the grey waves meet the sky,",
                    "the Danes arose—bold seafarers,",
                    "forging legends with oar and axe.",
                    "Their ships crossed cold seas,",
                    "raiding, trading, settling,",
                    "spreading tales from Vinland",
                    "to Miklagard."
                ),
                new BookPageInfo
                (
                    "Harald Bluetooth carved runes,",
                    "uniting fractured clans beneath",
                    "the crimson Dannebrog. He built",
                    "church and fort, calling gods new",
                    "and old. King Gorm and Queen Thyra,",
                    "resting in Jelling, watched the land",
                    "grow strong, from Baltic sands to",
                    "the Skagerrak."
                ),
                new BookPageInfo
                (
                    "In the longhouses, fire crackled,",
                    "and skalds sang of mighty feats—",
                    "the Great Heathen Army that crossed",
                    "to England, the steadfast Queen",
                    "Margrethe who joined the northern",
                    "crowns, the White Christ and Odin",
                    "battling in hearts."
                ),
                new BookPageInfo
                (
                    "Through centuries of frost and war,",
                    "Denmark endured. From Kalmar’s Union",
                    "to the bloodied fields of Dybbøl,",
                    "her spirit held. Explorers set forth:",
                    "Vitus Bering to Siberia, Niels Bohr",
                    "to the atom’s heart, and Andersen to",
                    "fairytale dreamlands."
                ),
                new BookPageInfo
                (
                    "Today, the Dannebrog flies on winds",
                    "older than stone. The runestones",
                    "still speak. The north remembers.",
                    "",
                    "",
                    "",
                    "",
                    "",
                    ""
                ),
                new BookPageInfo
                (
                    "May the finder of this chest recall:",
                    "Gold can be spent, swords can be broken,",
                    "but stories and honor endure beyond death.",
                    "",
                    "- The Chronicler",
                    "",
                    "",
                    "",
                    ""
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public SagasOfTheDanes() : base(false)
            {
                Hue = 1152; // Deep blue
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Sagas of the Danes");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Sagas of the Danes");
            }

            public SagasOfTheDanes(Serial serial) : base(serial) { }

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

        // Serialization
        public TreasureChestOfTheDanes(Serial serial) : base(serial) { }

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
}
