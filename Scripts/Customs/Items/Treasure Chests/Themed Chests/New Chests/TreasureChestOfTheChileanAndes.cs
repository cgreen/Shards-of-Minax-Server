using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheChileanAndes : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheChileanAndes()
        {
            Name = "Treasure Chest of the Chilean Andes";
            Hue = 2101; // Deep copper-gold, like a mountain sunset

            // Themed loot!
            AddItem(CreateColoredItem<ArtifactLargeVase>("Ancient Mapuche Urn", 2207), 0.18);
            AddItem(CreateColoredItem<CandelabraOfSouls>("Candelabra of the Atacama", 1153), 0.09);
            AddItem(CreateNamedItem<AcademicBooksArtifact>("Book of Isla de Pascua Myths"), 0.13);
            AddItem(CreateColoredItem<RandomFancyCoin>("Lost Peso of Independence", 2125), 0.23);
            AddItem(CreateNamedItem<CrystalBallStatuette>("Crystal of Neruda's Inspiration"), 0.08);
            AddItem(CreateChileanWine(), 0.16);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateCopperIngot(), 0.22);
            AddItem(CreatePoetCloak(), 0.19);
            AddItem(CreateCopperAxe(), 0.20);
            AddItem(CreatePoncho(), 0.18);
            AddItem(CreateMapucheHelmet(), 0.15);
            AddItem(CreateMiningPick(), 0.19);
            AddItem(CreateLapisRing(), 0.10);
            AddItem(new RelatosDeLosAndes(), 1.0); // Lore book, always in chest
            AddItem(new Gold(Utility.Random(2000, 4000)), 0.22);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative and consumables

        private Item CreateCopperIngot()
        {
            Gold copper = new Gold();
            copper.Name = "Ingot of Chilean Copper";
            copper.Hue = 2418; // Coppery-orange
            copper.Amount = Utility.Random(100, 250);
            return copper;
        }

        private Item CreateChileanWine()
        {
            BottleArtifact wine = new BottleArtifact();
            wine.Name = "Carménère Reserve, 1880";
            wine.Hue = 1359;
            return wine;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Mysterious Andes";
            map.Bounds = new Rectangle2D(1200, 3400, 500, 500); // Fictional coords
            map.NewPin = new Point2D(1450, 3750);
            map.Protected = true;
            return map;
        }

        // Unique powerful equipment

        private Item CreatePoetCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Neruda’s Words";
            cloak.Hue = 1309;
            cloak.Attributes.Luck = 75;
            cloak.Attributes.BonusInt = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Inscribe, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            cloak.Attributes.SpellDamage = 12;
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateCopperAxe()
        {
            DoubleAxe axe = new DoubleAxe();
            axe.Name = "Axe of the Copper Miners";
            axe.Hue = 2418;
            axe.MinDamage = 30;
            axe.MaxDamage = 70;
            axe.WeaponAttributes.HitLeechStam = 15;
            axe.WeaponAttributes.HitLightning = 20;
            axe.Attributes.WeaponDamage = 25;
            axe.Attributes.BonusStr = 8;
            axe.Attributes.AttackChance = 10;
            axe.SkillBonuses.SetValues(0, SkillName.Mining, 18.0);
            XmlAttach.AttachTo(axe, new XmlLevelItem());
            return axe;
        }

        private Item CreatePoncho()
        {
            FancyShirt poncho = new FancyShirt();
            poncho.Name = "Colorful Andean Poncho";
            poncho.Hue = Utility.RandomMinMax(1150, 1370);
            poncho.Attributes.BonusHits = 20;
            poncho.Attributes.BonusStam = 10;
            poncho.SkillBonuses.SetValues(0, SkillName.Herding, 15.0);
            poncho.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10.0);
            XmlAttach.AttachTo(poncho, new XmlLevelItem());
            return poncho;
        }

        private Item CreateMapucheHelmet()
        {
            NorseHelm helm = new NorseHelm();
            helm.Name = "Mapuche War Helm";
            helm.Hue = 1152;
            helm.BaseArmorRating = 58;
            helm.ArmorAttributes.LowerStatReq = 20;
            helm.Attributes.BonusDex = 7;
            helm.Attributes.ReflectPhysical = 9;
            helm.SkillBonuses.SetValues(0, SkillName.Tactics, 11.0);
            helm.SkillBonuses.SetValues(1, SkillName.Parry, 7.0);
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateMiningPick()
        {
            Pickaxe pick = new Pickaxe();
            pick.Name = "Pickaxe of Chuquicamata";
            pick.Hue = 2409;
            pick.MinDamage = 22;
            pick.MaxDamage = 55;
            pick.Attributes.WeaponSpeed = 20;
            pick.Attributes.BonusStr = 9;
            pick.SkillBonuses.SetValues(0, SkillName.Mining, 30.0);
            pick.WeaponAttributes.UseBestSkill = 1;
            pick.WeaponAttributes.HitEnergyArea = 12;
            XmlAttach.AttachTo(pick, new XmlLevelItem());
            return pick;
        }

        private Item CreateLapisRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Lapis Ring of the Pacific";
            ring.Hue = 89; // Blue, for lapis lazuli
            ring.Attributes.BonusMana = 12;
            ring.Attributes.SpellChanneling = 1;
            ring.SkillBonuses.SetValues(0, SkillName.Fishing, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.MagicResist, 7.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        // Helper for generic colored items
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

        public TreasureChestOfTheChileanAndes(Serial serial) : base(serial) { }

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

    public class RelatosDeLosAndes : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Relatos de los Andes", "Anónimo",
            new BookPageInfo
            (
                "Between the sea and the",
                "mountains, where the",
                "Andes cut the sky and",
                "desert meets salt, runs",
                "a long and narrow land.",
                "Here thunder the voices",
                "of old, Mapuche and",
                "Inca, and winds that"
            ),
            new BookPageInfo
            (
                "whisper secrets of gold",
                "and copper veins deep",
                "beneath the earth.",
                "From the Atacama’s silence",
                "to Antarctic snows, from",
                "fiery volcanoes to the",
                "green of the Lake District,",
                "Chile endures."
            ),
            new BookPageInfo
            (
                "Isla de Pascua rises far",
                "on the Pacific, its statues",
                "guarding mysteries.",
                "Pirates, poets, patriots:",
                "all have dreamed along the",
                "coast where Neruda’s pen",
                "met Allende’s hope, and",
                "the Mapuche’s song."
            ),
            new BookPageInfo
            (
                "They tell of rebel chiefs",
                "whose courage shook",
                "an empire; of miners who",
                "fought the mountain and",
                "won, only to lose themselves",
                "in shadowed tunnels; of",
                "wine ripened in sun and",
                "the long slow dusk."
            ),
            new BookPageInfo
            (
                "If you seek the heart",
                "of the Andes, listen not",
                "only for the puma’s call,",
                "but for the voices in the",
                "wind—those who were,",
                "and those yet to come.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Here, in this chest, find",
                "gifts born of earth and",
                "sea, blood and dream.",
                "May the spirit of Chile",
                "travel with you always.",
                "",
                "- Relatos de los Andes",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public RelatosDeLosAndes() : base(false)
        {
            Hue = 1218; // Deep blue, Pacific Ocean
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Relatos de los Andes");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Relatos de los Andes");
        }

        public RelatosDeLosAndes(Serial serial) : base(serial) { }

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
