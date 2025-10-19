using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfArmenia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfArmenia()
        {
            Name = "Treasure Chest of Armenia";
            Hue = Utility.Random(1, 1788);

            // Add items to the chest
            AddItem(new MaxxiaScroll(), 0.05);
            AddItem(CreateColoredItem<GreaterHealPotion>("Ararat Healing Elixir", 1153), 0.15);
            AddItem(CreateColoredItem<Ruby>("Ruby of Ani", 1169), 0.12);
            AddItem(CreateColoredItem<GoldBracelet>("Golden Prowess Bracelet", 1150), 0.17);
            AddItem(CreateGoldItem("Dram of Tigran"), 0.20);
            AddItem(CreateDecorativeKhachkar(), 0.10);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Vagharshapat Pilgrim", 1153), 0.18);
            AddItem(CreateDecorativeVase("Vase of Garni"), 0.08);
            AddItem(new ChroniclesOfArmenia(), 1.0);
            AddItem(CreateMap(), 0.04);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateColoredItem<MaxxiaScroll>("Scroll of Armenian Sanctuary", 1175), 0.10);
            AddItem(new Gold(Utility.Random(100, 5000)), 0.15);
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

        private Item CreateDecorativeKhachkar()
        {
            RockArtifact khachkar = new RockArtifact();
            khachkar.Name = "Khachkar of Noravank";
            khachkar.Hue = 1150; // A deep reddish hue
            return khachkar;
        }

        private Item CreateDecorativeVase(string name)
        {
            ArtifactLargeVase vase = new ArtifactLargeVase();
            vase.Name = name;
            vase.Hue = Utility.RandomMinMax(1100, 1175);
            return vase;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Mount Ararat's Secret Monastery";
            map.Bounds = new Rectangle2D(2500, 2600, 400, 400);
            map.NewPin = new Point2D(2700, 2800);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // Use a Scimitar as base for a traditional Armenian-inspired blade
            Scimitar sword = new Scimitar();
            sword.Name = "Sword of Vardan Mamikonian";
            sword.Hue = Utility.RandomMinMax(1100, 1175);
            sword.MinDamage = Utility.Random(20, 40);
            sword.MaxDamage = Utility.Random(40, 80);
            sword.Attributes.WeaponDamage = 25;
            sword.Attributes.DefendChance = 15;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of Tigran the Great";
            armor.Hue = Utility.RandomMinMax(1100, 1175);
            armor.BaseArmorRating = Utility.Random(30, 70);
            armor.Attributes.BonusHits = 20;
            armor.Attributes.DefendChance = 10;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ArmorAttributes.MageArmor = 1;
            armor.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Mount Ararat";
            cloak.Hue = Utility.RandomMinMax(1120, 1170);
            cloak.Attributes.BonusDex = 15;
            cloak.Attributes.BonusMana = 10;
            cloak.Resistances.Energy = 10;
            cloak.Resistances.Physical = 5;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        public TreasureChestOfArmenia(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class ChroniclesOfArmenia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Armenia", "Historian of Van",
            new BookPageInfo
            (
                "In the dawn of time, Hayk, forefather",
                "of our people, rose against the tyranny",
                "of Bel, carving a land between rugged",
                "peaks and fertile valleys. The spirit of",
                "Hayk echoes through every Armenian soul,",
                "a testament to freedom and resilience.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "By the shores of Lake Van, Urartu flourished,",
                "its citadels crowned with the heavens. Kings",
                "like Argishti and Menua shaped a kingdom of",
                "stone and iron, trading with distant lands,",
                "their engineers carving aqueducts into",
                "mountainsides, their artisans forging bronze",
                "into shimmering reliefs."
            ),
            new BookPageInfo
            (
                "When St. Gregory the Illuminator brought",
                "the light of Christianity in 301 AD, Armenia",
                "became the first nation to embrace the cross.",
                "Monks laid quills to parchment, giving birth",
                "to manuscripts of gold and vermilion. The",
                "sound of hammer on chisel breathed life into",
                "khachkars—stone crosses reaching toward God."
            ),
            new BookPageInfo
            (
                "Under Tigranes the Great, our banners unfurled",
                "from the Euphrates to the Caspian. Yerevan's walls",
                "rose where swirling tea met a bustling bazaar. Yet",
                "Pax Romana and the Silk Road beckoned, and Armenia",
                "straddled both, exchanging silk, spices, and faith.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "In the monasteries of Geghard and Echmiadzin,",
                "echoes of hymns drifted across emerald pastures.",
                "Illuminated Gospels glowed by candlelight, and",
                "pilgrims carved prayers into the basalt cliffs.",
                "The Armenian spirit remained unbroken through",
                "Seljuk sieges and Mongol tides, binding each",
                "generation to its ancient bloodline."
            ),
            new BookPageInfo
            (
                "From Lake Sevan’s silver waves to the pomegranates",
                "of Artsakh, our stones tell stories of kings and",
                "poets. The melodies of duduk carry both sorrow",
                "and hope, weaving memory into every note. We",
                "endure—as long as Mount Ararat clings to the sky,",
                "our homeland lives in heart and bone."
            ),
            new BookPageInfo
            (
                "Let those who uncover this chest remember—",
                "Armenia is more than land; it is a testament",
                "to faith, to survival, to the fire in our veins.",
                "Carry this legacy forward, with honor and",
                "pride, that the stones of our ancestors may",
                "whisper through the ages."
            ),
            new BookPageInfo
            (
                "- Historian of Van",
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
        public ChroniclesOfArmenia() : base(false)
        {
            Hue = 1153; // A royal apricot hue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Armenia");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Armenia");
        }

        public ChroniclesOfArmenia(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadEncodedInt();
        }
    }
}
