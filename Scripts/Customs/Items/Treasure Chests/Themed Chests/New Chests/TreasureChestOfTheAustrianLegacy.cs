using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheAustrianLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheAustrianLegacy()
        {
            Name = "Treasure Chest of the Austrian Legacy";
            Hue = 2125; // Imperial Gold

            // Add items to the chest
            AddItem(new ViennaChronicle(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactVase>("Imperial Scepter Replica", 2125), 0.20);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Portrait of Empress Maria Theresa", 1175), 0.16);
            AddItem(CreateDecorativeItem<DecorativeShield10>("Aegis of Austria", 1871), 0.15);
            AddItem(CreateDecorativeItem<FancyPainting>("Vienna Philharmonic Sheet Music", 2101), 0.14);
            AddItem(CreateDecorativeItem<WhiteGrandfatherClock>("Prater Park Clock", 1001), 0.12);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("St. Stephen’s Cathedral Model", 2105), 0.12);

            AddItem(CreateConsumable("Sachertorte Slice", typeof(Cake), 1957), 0.20);
            AddItem(CreateConsumable("Viennese Coffee", typeof(CoffeeMug), 1827), 0.15);
            AddItem(CreateConsumable("Glühwein", typeof(GlassMug), 1378), 0.12);

            AddItem(CreateNamedEquipment<Circlet>("Crown of the Habsburgs", 2125, CreateCrownMods), 0.19);
            AddItem(CreateNamedEquipment<PlainDress>("Maria Theresa’s Gown", 1175, CreateDressMods), 0.18);
            AddItem(CreateNamedEquipment<Longsword>("Sword of the Danube Defender", 1871, CreateSwordMods), 0.18);
            AddItem(CreateNamedEquipment<WizardsHat>("Mozart’s Enchanted Baton", 1154, CreateBatonMods), 0.14);

            AddItem(CreateGoldItem("Austrian Ducat Coin"), 0.17);
            AddItem(CreateMap(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(500, 3000));
            gold.Name = name;
            return gold;
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable(string name, Type itemType, int hue)
        {
            Item item = (Item)Activator.CreateInstance(itemType);
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        // ---- EQUIPMENT CREATORS ----

        private Item CreateNamedEquipment<T>(string name, int hue, Action<T> applyMods) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            applyMods?.Invoke(item);
            XmlAttach.AttachTo(item, new XmlLevelItem());
            return item;
        }

        private void CreateCrownMods(Circlet circlet)
        {
            circlet.Attributes.BonusInt = 15;
            circlet.Attributes.BonusMana = 10;
            circlet.Attributes.Luck = 100;
            circlet.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            circlet.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            circlet.ArmorAttributes.MageArmor = 1;
            circlet.ColdBonus = 10;
            circlet.EnergyBonus = 10;
        }

        private void CreateDressMods(PlainDress dress)
        {
            dress.Attributes.BonusStr = 8;
            dress.Attributes.BonusHits = 25;
            dress.Attributes.CastRecovery = 2;
            dress.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            dress.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
        }

        private void CreateSwordMods(Longsword sword)
        {
            sword.WeaponAttributes.HitFireball = 25;
            sword.WeaponAttributes.HitHarm = 15;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.DefendChance = 15;
            sword.Attributes.WeaponSpeed = 30;
            sword.MinDamage = 30;
            sword.MaxDamage = 65;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            sword.Slayer = SlayerName.ElementalBan;
        }

        private void CreateBatonMods(WizardsHat hat)
        {
            hat.Attributes.BonusInt = 20;
            hat.Attributes.SpellDamage = 25;
            hat.SkillBonuses.SetValues(0, SkillName.Musicianship, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Imperial Crypt";
            map.Bounds = new Rectangle2D(1600, 1300, 250, 250);
            map.NewPin = new Point2D(1725, 1410);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheAustrianLegacy(Serial serial) : base(serial) { }

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

    // ---- LORE BOOK ----

    public class ViennaChronicle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Austria", "Alois von Habsburg",
            new BookPageInfo
            (
                "Austria, land of rivers and",
                "mountains, has seen empires",
                "rise and fall upon its soil.",
                "From ancient Noricum to the",
                "proud Babenbergs, to the dawn",
                "of the Habsburg dynasty, its",
                "destiny forever tied to the",
                "heart of Europe."
            ),
            new BookPageInfo
            (
                "The Danube winds past Vienna,",
                "city of music, of grandeur,",
                "of intrigue. Here emperors",
                "crowned, composers soared, and",
                "revolutions thundered.",
                "",
                "The legacy of Maria Theresa,",
                "of Franz Joseph, of Sisi endures."
            ),
            new BookPageInfo
            (
                "Vienna’s palaces and cathedrals,",
                "ringed by ancient fortresses, bear",
                "silent witness to glory and strife.",
                "Here Mozart played, Beethoven raged,",
                "and Strauss waltzed as the empire",
                "danced toward twilight."
            ),
            new BookPageInfo
            (
                "Yet war came. Empires fell. The",
                "Austrian Eagle’s wings were clipped,",
                "but not broken. In the cafes, art and",
                "science flourished. In the mountains,",
                "heroes fought for freedom.",
                "",
                "Through fire and frost, Austria endured."
            ),
            new BookPageInfo
            (
                "Let this chest honor a land where",
                "history is legend, and legend is",
                "history. Take these treasures, and",
                "remember the glory of the Austrian",
                "Legacy.",
                "",
                "‘Einigkeit macht stark’— Unity is strength."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ViennaChronicle() : base(false)
        {
            Hue = 2125; // Imperial gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Austria");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Austria");
        }

        public ViennaChronicle(Serial serial) : base(serial) { }

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
