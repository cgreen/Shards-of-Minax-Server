using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfVanuatu : WoodenChest
    {
        [Constructable]
        public TreasureChestOfVanuatu()
        {
            Name = "Treasure Chest of Vanuatu";
            Hue = 2100; // Deep ocean blue

            // Add themed items to the chest
            AddItem(CreateDecorativeArtifact(), 0.30);
            AddItem(CreateVolcanicPearl(), 0.17);
            AddItem(CreateColoredItem<GreenTea>("Spirit Kava Brew", 2120), 0.20);
            AddItem(CreateColoredItem<Sculpture2Artifact>("Carved Volcanic Idol", 2419), 0.23);
            AddItem(CreateColoredItem<BoneArms>("Arms of the Fire Dancer", 2946), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Turtle Talisman Bracelet"), 0.17);
            AddItem(CreateMap(), 0.06);
            AddItem(CreateDecorativeMask(), 0.18);
            AddItem(new LoreOfVanuatu(), 1.0);
            AddItem(CreateNamedItem<PewterBowlOfCorn>("Bowl of Island Feast"), 0.09);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Lagoon", 1160), 0.16);
            AddItem(CreateColoredItem<Necklace>("Shell Necklace of Tanna", 2117), 0.19);
            AddItem(CreateGoldItem("Ancient Shell Coin"), 0.12);
            AddItem(CreateOceanicPotion(), 0.15);
            AddItem(CreateVolcanoWeapon(), 0.24);
            AddItem(CreateTotemicArmor(), 0.20);
            AddItem(CreateTribalCloak(), 0.19);
            AddItem(CreateFishermansCap(), 0.17);
            AddItem(CreateExplorerKnife(), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Example unique decorative artifact
        private Item CreateDecorativeArtifact()
        {
            Sculpture2Artifact artifact = new Sculpture2Artifact();
            artifact.Name = "Totem of the Volcano Spirit";
            artifact.Hue = 2419;
            return artifact;
        }

        private Item CreateVolcanicPearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "Volcanic Pearl of Ambrym";
            pearl.Hue = 2946; // Magma-red
            return pearl;
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

        private Item CreateDecorativeMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Ancestor's Spirit Mask";
            mask.Hue = 1172; // Ghostly white
            mask.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 10.0);
            return mask;
        }

        private Item CreateOceanicPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Brew of the Ocean Spirits";
            potion.Hue = 1260; // Turquoise
            return potion;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Volcano's Heart";
            map.Bounds = new Rectangle2D(3000, 2500, 300, 300);
            map.NewPin = new Point2D(3150, 2600);
            map.Protected = true;
            return map;
        }

        // Unique weapon
        private Item CreateVolcanoWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Blade of the Lava Dancer";
            weapon.Hue = 2946; // Magma-red
            weapon.MaxDamage = Utility.Random(45, 85);
            weapon.Attributes.AttackChance = 15;
            weapon.WeaponAttributes.HitFireball = 30;
            weapon.WeaponAttributes.HitLightning = 18;
            weapon.Attributes.BonusDex = 10;
            weapon.Attributes.BonusStam = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Unique armor
        private Item CreateTotemicArmor()
        {
            BoneChest armor = new BoneChest();
            armor.Name = "Totemic Chest of Efate";
            armor.Hue = 2419; // Volcanic brown
            armor.BaseArmorRating = Utility.Random(50, 75);
            armor.Attributes.LowerManaCost = 10;
            armor.Attributes.BonusMana = 15;
            armor.Attributes.SpellDamage = 10;
            armor.Attributes.CastRecovery = 2;
            armor.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            armor.PoisonBonus = 10;
            armor.FireBonus = 20;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique cloak
        private Item CreateTribalCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Island Night";
            cloak.Hue = 2100; // Deep blue
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.Luck = 50;
            cloak.Attributes.RegenMana = 2;
            cloak.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Unique hat/cap
        private Item CreateFishermansCap()
        {
            StrawHat cap = new StrawHat();
            cap.Name = "Fisherman's Lucky Hat";
            cap.Hue = 1265; // Sea green
            cap.Attributes.BonusHits = 10;
            cap.Attributes.BonusStam = 10;
            cap.Attributes.Luck = 35;
            cap.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            cap.SkillBonuses.SetValues(1, SkillName.Camping, 10.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        // Unique knife
        private Item CreateExplorerKnife()
        {
            SkinningKnife knife = new SkinningKnife();
            knife.Name = "Explorer's Obsidian Knife";
            knife.Hue = 1175; // Jet black
            knife.MinDamage = Utility.Random(20, 40);
            knife.MaxDamage = Utility.Random(40, 65);
            knife.Attributes.BonusDex = 12;
            knife.WeaponAttributes.HitDispel = 10;
            knife.WeaponAttributes.SelfRepair = 3;
            knife.SkillBonuses.SetValues(0, SkillName.Camping, 10.0);
            knife.SkillBonuses.SetValues(1, SkillName.Tracking, 8.0);
            XmlAttach.AttachTo(knife, new XmlLevelItem());
            return knife;
        }

        public TreasureChestOfVanuatu(Serial serial) : base(serial)
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

    // --- Custom lore book for Vanuatu ---

    public class LoreOfVanuatu : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Isles of Fire and Water", "Nuvura the Storyteller",
            new BookPageInfo
            (
                "Long before ships found these",
                "shores, the spirits of Vanuatu",
                "danced on waves of fire and",
                "water. Ancestors built canoes",
                "from the trees, and walked",
                "the black sands of Tanna,",
                "their feet warmed by the",
                "breath of Yasur's volcano."
            ),
            new BookPageInfo
            (
                "The Melanesian clans called",
                "upon the strength of the",
                "island, weaving magic from",
                "volcanic stone and coral.",
                "Great masks, carved from",
                "tree and bone, kept watch",
                "over the villages, warding",
                "off the storms and spirits."
            ),
            new BookPageInfo
            (
                "The ocean, ever hungry,",
                "brought gifts and danger.",
                "Pearls of fire, spat from",
                "the sea, held secret power.",
                "The bravest fished on dark",
                "reefs, guided by the light",
                "of their ancestors, whose",
                "bones sleep in hidden caves."
            ),
            new BookPageInfo
            (
                "When strangers came with",
                "strange tongues and iron,",
                "the old magics faded, but",
                "never died. The volcano's",
                "heart beats yet. Listen—",
                "in the night wind, the",
                "ancestors sing. Their",
                "treasures wait to be found."
            ),
            new BookPageInfo
            (
                "Find the Mask of Spirits,",
                "the Blade of the Lava",
                "Dancer, the Totem of Fire,",
                "and honor those who shaped",
                "these isles. Beware—the",
                "treasures are not gifts.",
                "They are a test. The sea",
                "takes as much as it gives."
            ),
            new BookPageInfo
            (
                "If you walk the lava trails,",
                "drink kava with respect,",
                "and listen to the wind, you",
                "may glimpse the old world.",
                "But remember: no soul who",
                "greedily hoards the gifts of",
                "Vanuatu ever finds peace—",
                "above or below the waves."
            ),
            new BookPageInfo
            (
                "Let this book serve as",
                "a guide and a warning.",
                "The Isles of Fire and Water",
                "are alive with ancient",
                "power. Journey wisely,",
                "and honor the spirits,",
                "lest you become a tale",
                "told by the wind."
            ),
            new BookPageInfo
            (
                "- Nuvura, Keeper of Lore",
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
        public LoreOfVanuatu() : base(false)
        {
            Hue = 2100; // Deep ocean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Isles of Fire and Water");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Isles of Fire and Water");
        }

        public LoreOfVanuatu(Serial serial) : base(serial) { }

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
