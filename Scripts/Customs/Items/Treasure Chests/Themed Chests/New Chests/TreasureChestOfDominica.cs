using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfDominica : WoodenChest
    {
        [Constructable]
        public TreasureChestOfDominica()
        {
            Name = "Treasure Chest of Dominica";
            Hue = 2057; // Emerald-green, for "The Nature Island"

            // Decorative & Cultural Artifacts
            AddItem(CreateColoredItem<ArtifactLargeVase>("Kalinago Heritage Vase", 1272), 0.20);
            AddItem(CreateColoredItem<BambooStoolArtifact>("Carib Bamboo Stool", 1368), 0.20);
            AddItem(CreateNamedItem<CraneZooStatuette>("Sisserou Parrot Figurine"), 0.17);
            AddItem(CreateColoredItem<Painting1WestArtifact>("Roseau Cityscape Painting", 2123), 0.12);
            AddItem(CreateNamedItem<FancyWindChimes>("Boiling Lake Wind Chimes"), 0.10);
            AddItem(CreateColoredItem<FlowersArtifact>("Tropical Bougainvillea", 2124), 0.15);

            // Consumables & Natural Goods
            AddItem(CreateColoredItem<GreenTea>("Dominican Lemongrass Tea", 2125), 0.18);
            AddItem(CreateColoredItem<BentoBox>("Cassava Bread Bento", 2126), 0.13);
            AddItem(CreateColoredItem<Grapes>("Jungle Grapes", 1640), 0.11);
            AddItem(CreateNamedItem<GreaterHealPotion>("Elixir of the Emerald Falls"), 0.20);

            // Unique Currency & Odds-and-Ends
            AddItem(CreateGoldItem("Dominica Florin"), 0.20);
            AddItem(CreateColoredItem<Gold>("Pirate Dubloon", 2413), 0.10);
            AddItem(CreateNamedItem<Ruby>("Fire Opal of Soufriere"), 0.07);

            // Powerful Unique Equipment
            AddItem(CreateDominicaWeapon(), 0.20);
            AddItem(CreateDominicaArmor(), 0.20);
            AddItem(CreateDominicaCloak(), 0.15);
            AddItem(CreateDominicaBoots(), 0.15);

            // Unique Clothing
            AddItem(CreateNamedClothing(), 0.18);

            // The Lore Book
            AddItem(new EmeraldIsleChronicles(), 1.0);

            // Treasure Map
            AddItem(CreateDominicaMap(), 0.07);

            // Gold
            AddItem(new Gold(Utility.Random(2000, 4000)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Decorative & consumable creators
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

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // Equipment creators
        private Item CreateDominicaWeapon()
        {
            // Sisserou Parrotblade (Katana, high speed, energy damage, parrot-themed)
            Katana blade = new Katana();
            blade.Name = "Sisserou Parrotblade";
            blade.Hue = 1635; // Vibrant green/blue
            blade.Attributes.WeaponSpeed = 40;
            blade.Attributes.WeaponDamage = 50;
            blade.Attributes.BonusDex = 10;
            blade.WeaponAttributes.HitLightning = 25;
            blade.WeaponAttributes.HitPoisonArea = 10;
            blade.WeaponAttributes.SelfRepair = 7;
            blade.Slayer = SlayerName.ReptilianDeath;
            blade.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            blade.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateDominicaArmor()
        {
            // Wapiche Rainforest Plate (DragonChest)
            DragonChest chest = new DragonChest();
            chest.Name = "Wapiche Rainforest Plate";
            chest.Hue = 1272; // Deep forest green
            chest.BaseArmorRating = 50;
            chest.Attributes.BonusHits = 20;
            chest.Attributes.Luck = 30;
            chest.Attributes.NightSight = 1;
            chest.ArmorAttributes.SelfRepair = 6;
            chest.AbsorptionAttributes.EaterPoison = 20;
            chest.PhysicalBonus = 15;
            chest.FireBonus = 5;
            chest.PoisonBonus = 20;
            chest.SkillBonuses.SetValues(0, SkillName.AnimalLore, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateDominicaCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Boiling Lake";
            cloak.Hue = 1175; // Misty blue/gray
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.SpellDamage = 12;
            cloak.Attributes.RegenMana = 3;
            cloak.Attributes.LowerRegCost = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateDominicaBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of Waitukubuli";
            boots.Hue = 2117;
            boots.Attributes.BonusStam = 15;
            boots.Attributes.Luck = 25;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Herding, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateNamedClothing()
        {
            // Vibrant island garb
            FancyShirt shirt = new FancyShirt();
            shirt.Name = "Mas Domnik Creole Shirt";
            shirt.Hue = 2412;
            shirt.Attributes.BonusHits = 8;
            shirt.Attributes.Luck = 15;
            shirt.SkillBonuses.SetValues(0, SkillName.Musicianship, 10.0);
            shirt.SkillBonuses.SetValues(1, SkillName.Cooking, 10.0);
            XmlAttach.AttachTo(shirt, new XmlLevelItem());
            return shirt;
        }

        private Item CreateDominicaMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Explorer's Map of Dominica";
            map.Bounds = new Rectangle2D(2250, 3000, 512, 512);
            map.NewPin = new Point2D(2375, 3125);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfDominica(Serial serial) : base(serial) { }

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
    public class EmeraldIsleChronicles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "The Emerald Isle: Chronicles of Dominica", "Written by a Wandering Sage",
            new BookPageInfo
            (
                "Amidst the Caribbean Sea",
                "lies Dominica: wild, lush,",
                "unbroken. Called 'Waitukubuli'",
                "by the Kalinago—the island",
                "that stands tall—her peaks",
                "catch the clouds and her",
                "rivers sing ancient songs.",
                "",
                "Her forests are emerald,",
                "her heart volcanic."
            ),
            new BookPageInfo
            (
                "Long before Columbus sailed,",
                "the Kalinago called this land",
                "home. They fished her rivers,",
                "traced her mountain paths,",
                "and honored her spirit.",
                "",
                "Then came the empires:",
                "Spanish, French, and English,",
                "but none could tame her wilds."
            ),
            new BookPageInfo
            (
                "Plantations rose and fell.",
                "Freed Africans made new roots.",
                "Maroons fled to her jungles,",
                "carving lives from shadowed",
                "valleys. Pirates hid gold in",
                "her coves, as hurricanes",
                "shaped legends.",
                "",
                "Dominica, unconquered."
            ),
            new BookPageInfo
            (
                "Boiling Lake steams in her",
                "heart, while Sisserou parrots",
                "soar above Morne Trois Pitons.",
                "The Carib Territory endures—",
                "heritage alive.",
                "",
                "Let this chest's finder recall:",
                "Dominica is strength, song,",
                "and sanctuary."
            ),
            new BookPageInfo
            (
                "Honor her rivers. Hear the",
                "bamboo wind. Taste cassava",
                "and bay leaf. If you listen,",
                "the island may share her",
                "story—written in green,",
                "water, and fire.",
                "",
                "- The Wandering Sage",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public EmeraldIsleChronicles() : base(false)
        {
            Hue = 2057; // Emerald green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("The Emerald Isle: Chronicles of Dominica");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "The Emerald Isle: Chronicles of Dominica");
        }

        public EmeraldIsleChronicles(Serial serial) : base(serial) { }

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
