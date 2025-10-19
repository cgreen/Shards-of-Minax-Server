using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCyprus : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCyprus()
        {
            Name = "Treasure Chest of Cyprus";
            Hue = 1359; // A turquoise/copper tone

            // Add items to the chest
            AddItem(CreateColoredItem<ArtifactVase>("Amphora of Ancient Salamis", 1369), 0.20);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Aphrodite’s Blessing"), 0.15);
            AddItem(CreateColoredItem<Sandals>("Sandals of Paphos Pilgrim", 1175), 0.17);
            AddItem(CreateNamedItem<GreaterHealPotion>("Crusader’s Healing Elixir"), 0.18);
            AddItem(CreateCyprusSouvla(), 0.12);
            AddItem(CreateColoredItem<Bottle>("Commandaria Wine", 1771), 0.16);
            AddItem(CreateColoredItem<Gold>("Copper Talent", 1192), 0.30);
            AddItem(new Gold(Utility.Random(1, 6000)), 0.10);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateWeapon(), 0.21);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateCloak(), 0.18);
            AddItem(CreateSkullCap(), 0.14);
            AddItem(CreateBookOfLore(), 1.0);
            AddItem(CreateColoredItem<Urn1Artifact>("Byzantine Mosaic Urn", 1278), 0.13);
            AddItem(CreateDecorativeShield(), 0.13);
            AddItem(CreateNamedItem<Bottle>("Elixir of the Blue Grotto"), 0.10);
            AddItem(CreateNamedItem<GoldEarrings>("Venetian Noble's Earrings"), 0.09);
            AddItem(CreateDecorativeSword(), 0.11);
            AddItem(CreateFruitBasket(), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorativeShield()
        {
            DecorativeShield3 shield = new DecorativeShield3();
            shield.Name = "Shield of the Lusignan Knights";
            shield.Hue = 1175;
            return shield;
        }

        private Item CreateDecorativeSword()
        {
            DecorativeSwordWest sword = new DecorativeSwordWest();
            sword.Name = "Sword of Richard the Lionheart";
            sword.Hue = 1150;
            return sword;
        }

        private Item CreateCyprusSouvla()
        {
            Ham ham = new Ham();
            ham.Name = "Souvla of the Ancient Feast";
            ham.Hue = 1107;
            return ham;
        }

        private Item CreateFruitBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Cypriot Figs";
            basket.Hue = 1478;
            return basket;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Kourion Ruins";
            map.Bounds = new Rectangle2D(3320, 2050, 600, 600); // Sample coords
            map.NewPin = new Point2D(3400, 2300);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            Longsword weapon = new Longsword();
            weapon.Name = "Aphrodite’s Adamantine Blade";
            weapon.Hue = 1367;
            weapon.MaxDamage = Utility.Random(40, 90);
            weapon.MinDamage = Utility.Random(20, 50);
            weapon.Attributes.BonusStr = 8;
            weapon.Attributes.BonusDex = 8;
            weapon.Attributes.BonusHits = 20;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.Slayer = SlayerName.ElementalBan;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Byzantine Copperplate Armor";
            armor.Hue = 1192;
            armor.BaseArmorRating = Utility.Random(40, 80);
            armor.Attributes.BonusHits = 25;
            armor.Attributes.Luck = 30;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusInt = 10;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            armor.ColdBonus = 8;
            armor.EnergyBonus = 10;
            armor.FireBonus = 10;
            armor.PhysicalBonus = 25;
            armor.PoisonBonus = 7;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Venetian Magistrate’s Cloak";
            cloak.Hue = 1154;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusInt = 5;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateSkullCap()
        {
            SkullCap cap = new SkullCap();
            cap.Name = "Turban of the Ottoman Pasha";
            cap.Hue = 1776;
            cap.Attributes.BonusMana = 10;
            cap.Attributes.CastRecovery = 1;
            cap.Attributes.SpellDamage = 8;
            cap.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        private Item CreateBookOfLore()
        {
            return new ChroniclesOfTheIslandOfCopper();
        }

        public TreasureChestOfCyprus(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheIslandOfCopper : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Island of Copper", "Historian of Cyprus",
            new BookPageInfo
            (
                "Long before the olive groves,",
                "the island called Cyprus was",
                "a place of copper and legend.",
                "Here, Aphrodite rose from the sea,",
                "and kingdoms vied for power:",
                "Kourion, Salamis, Amathus.",
                "The sun baked stone and myth",
                "into the very earth."
            ),
            new BookPageInfo
            (
                "Phoenicians came with ships,",
                "bearing purple dye and letters.",
                "Greeks built temples to the gods,",
                "Persians claimed the coast, then",
                "Alexander’s armies marched ashore.",
                "The island, ever coveted,",
                "changed rulers with every tide.",
                ""
            ),
            new BookPageInfo
            (
                "Romans paved the roads. Emperors",
                "sent mosaics and marble columns.",
                "Byzantines raised great domes,",
                "their saints shimmering in gold.",
                "Arab raiders, Crusader kings,",
                "the banner of Lusignan,",
                "the crown of Venice. Cyprus,",
                "always at the crossroads."
            ),
            new BookPageInfo
            (
                "Richard Lionheart wed here,",
                "and the Ottomans laid siege.",
                "Mosques rose beside churches.",
                "Turkish and Greek alike tilled",
                "the red soil, shared olives,",
                "argued, and loved in the shadow",
                "of the Troodos. The British came,",
                "and left their mark in stone."
            ),
            new BookPageInfo
            (
                "Now, the island is still divided,",
                "but its heart beats on:",
                "old gods, new faiths, mingled blood.",
                "Seek the ruins, the sweet figs,",
                "the blue sea where Aphrodite walked.",
                "Within this chest, a fragment remains,",
                "of Cyprus—enduring and beautiful,",
                "awaiting discovery."
            ),
            new BookPageInfo
            (
                "Beware, traveler:",
                "the treasures of Cyprus",
                "are not all gold or gems.",
                "Some are memories. Some, curses.",
                "All, precious.",
                "",
                "- Chronicler of the Island of Copper",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheIslandOfCopper() : base(false)
        {
            Hue = 1192; // Copper/bronze hue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Island of Copper");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Island of Copper");
        }

        public ChroniclesOfTheIslandOfCopper(Serial serial) : base(serial) { }

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
