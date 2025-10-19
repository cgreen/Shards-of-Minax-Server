using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheShiningSun : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheShiningSun()
        {
            Name = "Treasure Chest of the Shining Sun";
            Hue = 1149; // Deep Crimson/Red, symbolic for Japan

            // Artifacts & Decorations
            AddItem(CreateNamedArtifact<BakeKitsuneStatue>("Kitsune Guardian Statue", 2412), 0.16);
            AddItem(CreateNamedArtifact<SwordDisplay1WestArtifact>("Masamune's Blade Display", 1175), 0.13);
            AddItem(CreateNamedArtifact<Futon>("Tatami Resting Mat", 2501), 0.12);
            AddItem(CreateNamedArtifact<Bonsai>("Miniature Bonsai of Edo", 1424), 0.12);
            AddItem(CreateNamedArtifact<RedHangingLantern>("Festival Lantern of Gion", 33), 0.12);
            AddItem(CreateNamedArtifact<ZenRock1Artifact>("Stone of Stillness", 1153), 0.09);
            AddItem(CreateNamedArtifact<OrcMask>("Oni Mask of Protection", 2301), 0.10);

            // Consumables & Food
            AddItem(CreateNamedArtifact<SakeArtifact>("Sacred Sake of Izumo", 2101), 0.13);
            AddItem(CreateNamedArtifact<SushiPlatter>("Feast of the Shogun", 2000), 0.14);
            AddItem(CreateNamedArtifact<GreenTea>("Ceremonial Matcha Tea", 1266), 0.15);
            AddItem(CreateNamedArtifact<MisoSoup>("Soothing Miso Soup", 1157), 0.13);
            AddItem(CreateNamedArtifact<BentoBox>("Bento of Prosperity", 2510), 0.12);

            // Unique Equipment
            AddItem(CreateKatana(), 0.23);
            AddItem(CreateYoroi(), 0.21);
            AddItem(CreateKimono(), 0.19);
            AddItem(CreateNinjaTabi(), 0.17);
            AddItem(CreateKabuto(), 0.15);

            // Miscellaneous treasures
            AddItem(CreateGoldItem("Koban Coin (Golden Age)"), 0.17);
            AddItem(CreateNamedArtifact<JadeSkull>("Jade Talisman of Peace", 1420), 0.08);
            AddItem(CreateNamedArtifact<OrigamiCrane>("Origami Crane of Hope", 1150), 0.12);
            AddItem(CreateMap(), 0.07);

            // Lore Book (always present)
            DropItem(new ChroniclesOfTheShiningSun());

            // Random rare scroll
            AddItem(CreateNamedArtifact<SimpleNote>("Ancient Scroll of Bushido", 1309), 0.07);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(1200, 3000));
            gold.Name = name;
            return gold;
        }

        private Item CreateKatana()
        {
            Katana katana = new Katana();
            katana.Name = "Katana of Amaterasu";
            katana.Hue = 1157;
            katana.WeaponAttributes.HitLightning = 25;
            katana.Attributes.BonusDex = 10;
            katana.Attributes.BonusStam = 12;
            katana.Attributes.AttackChance = 10;
            katana.Attributes.WeaponDamage = 30;
            katana.SkillBonuses.SetValues(0, SkillName.Bushido, 18.0);
            katana.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            katana.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(katana, new XmlLevelItem());
            return katana;
        }

        private Item CreateYoroi()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Samurai Yoroi of Legends";
            chest.Hue = 1154;
            chest.BaseArmorRating = Utility.Random(45, 68);
            chest.Attributes.DefendChance = 12;
            chest.Attributes.BonusHits = 15;
            chest.Attributes.BonusStr = 8;
            chest.SkillBonuses.SetValues(0, SkillName.Bushido, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            chest.SkillBonuses.SetValues(2, SkillName.Healing, 7.0);
            chest.ArmorAttributes.LowerStatReq = 15;
            chest.ColdBonus = 10;
            chest.FireBonus = 12;
            chest.EnergyBonus = 8;
            chest.PoisonBonus = 8;
            chest.PhysicalBonus = 18;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateKimono()
        {
            FemaleKimono kimono = new FemaleKimono();
            kimono.Name = "Kimono of the Fuji Blossom";
            kimono.Hue = 1337;
            kimono.Attributes.Luck = 30;
            kimono.Attributes.BonusMana = 8;
            kimono.Attributes.BonusInt = 10;
            kimono.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            kimono.SkillBonuses.SetValues(1, SkillName.Focus, 12.0);
            kimono.SkillBonuses.SetValues(2, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(kimono, new XmlLevelItem());
            return kimono;
        }

        private Item CreateNinjaTabi()
        {
            NinjaTabi tabi = new NinjaTabi();
            tabi.Name = "Ninja Tabi of Silent Steps";
            tabi.Hue = 1109;
            tabi.Attributes.BonusDex = 16;
            tabi.Attributes.NightSight = 1;
            tabi.SkillBonuses.SetValues(0, SkillName.Ninjitsu, 18.0);
            tabi.SkillBonuses.SetValues(1, SkillName.Hiding, 15.0);
            tabi.SkillBonuses.SetValues(2, SkillName.Stealth, 13.0);
            tabi.Attributes.Luck = 15;
            XmlAttach.AttachTo(tabi, new XmlLevelItem());
            return tabi;
        }

        private Item CreateKabuto()
        {
            PlateHelm kabuto = new PlateHelm();
            kabuto.Name = "Demon Kabuto of Takeda";
            kabuto.Hue = 2413;
            kabuto.BaseArmorRating = Utility.Random(20, 44);
            kabuto.ArmorAttributes.LowerStatReq = 10;
            kabuto.Attributes.BonusStr = 7;
            kabuto.Attributes.ReflectPhysical = 12;
            kabuto.Attributes.BonusHits = 7;
            kabuto.SkillBonuses.SetValues(0, SkillName.Anatomy, 7.0);
            kabuto.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(kabuto, new XmlLevelItem());
            return kabuto;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Imperial Palace";
            map.Bounds = new Rectangle2D(1650, 3250, 350, 350); // Example coords
            map.NewPin = new Point2D(1850, 3420);
            map.Protected = true;
            return map;
        }

        private Item CreateNamedArtifact<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        public TreasureChestOfTheShiningSun(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheShiningSun : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Nippon: The Shining Sun", "Monk Yoshitsune",
            new BookPageInfo
            (
                "In the mists before memory,",
                "the land called Nihon rose from",
                "the ocean, shaped by Izanagi and",
                "Izanami. Amaterasu, goddess of the",
                "sun, bestowed light and wisdom.",
                "The people tilled rice, cast bronze,",
                "and worshipped kami in every tree."
            ),
            new BookPageInfo
            (
                "The age of emperors dawned. The",
                "Yamato clan unified the isles.",
                "Samurai lords pledged to their",
                "shogun, blades flashing in service,",
                "banners red as the rising sun.",
                "Zen gardens blossomed, poets sang of",
                "falling cherry petals and honor."
            ),
            new BookPageInfo
            (
                "Through ages of war and peace,",
                "the sword and brush shared power.",
                "Ninja moved as shadows, emperors",
                "dreamed of eternity. The court held",
                "secrets, the monks sought wisdom,",
                "and artisans painted tales of love,",
                "loss, and rebirth."
            ),
            new BookPageInfo
            (
                "Now, the Meiji dawn breaks. Iron",
                "and steam carry old dreams to new",
                "horizons. Yet still, the kami watch.",
                "Still, the spirit of Bushido guides",
                "the bold. Still, the mountains and",
                "rivers remember the ancestors’ oaths.",
                "",
                "May these treasures remind you:"
            ),
            new BookPageInfo
            (
                "\"To walk in harmony with sun and",
                "shadow is the way of Nippon.",
                "Honor the old, cherish the new.",
                "Let the shining sun rise within.\"",
                "",
                "",
                "— Monk Yoshitsune",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheShiningSun() : base(false)
        {
            Hue = 1149; // Crimson Red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Nippon: The Shining Sun");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Nippon: The Shining Sun");
        }

        public ChroniclesOfTheShiningSun(Serial serial) : base(serial) { }

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

    // For OrigamiCrane deco (if not present in your base)
    public class OrigamiCrane : Item
    {
        [Constructable]
        public OrigamiCrane() : base(0x2770)
        {
            Name = "Origami Crane";
            Hue = 1150;
            Weight = 1.0;
        }

        public OrigamiCrane(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    // For Bonsai deco (if not present in your base)
    public class Bonsai : Item
    {
        [Constructable]
        public Bonsai() : base(0x25E5)
        {
            Name = "Bonsai";
            Hue = 1424;
            Weight = 2.0;
        }

        public Bonsai(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
