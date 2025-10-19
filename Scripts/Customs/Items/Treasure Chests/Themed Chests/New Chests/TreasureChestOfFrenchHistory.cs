using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfFrenchHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfFrenchHistory()
        {
            Name = "Treasure Chest of French History";
            Hue = 1153; // Deep royal blue

            // Add items to the chest
            AddItem(CreateDecorativeItem<FancyPainting>("Tapestry of Versailles", 1154), 0.18);
            AddItem(CreateDecorativeItem<TowerLanternArtifact>("Fleur-de-Lis Lantern", 1151), 0.15);
            AddItem(CreateDecorativeItem<GoldBricks>("Lost Gold of the Merovingians", 1272), 0.10);
            AddItem(CreateDecorativeItem<BottlesOfSpoiledWine1Artifact>("Vintage Bordeaux (1789)", 2125), 0.13);
            AddItem(CreateDecorativeItem<Tapestry1N>("Royal Banner of the Capetians", 1175), 0.16);
            AddItem(CreateDecorativeItem<ArcaneTable>("Alchemist's Table of the Enlightenment", 1161), 0.10);
            AddItem(CreateConsumableWine(), 0.23);
            AddItem(CreateConsumableCheese(), 0.16);
            AddItem(CreateConsumableCroissant(), 0.14);
            AddItem(CreateDecorativeItem<DecorativeSwordNorth>("Sword of the Musketeers (Display)", 1206), 0.14);
            AddItem(CreateDecorativeItem<Painting3Artifact>("Portrait of Joan of Arc", 1196), 0.18);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Versailles"), 0.12);
            AddItem(CreateNamedItem<Sextant>("Navigator’s Astrolabe"), 0.12);
            AddItem(CreateGoldItem("Coin of the Sun King"), 0.10);
            AddItem(CreateEquipmentWeapon(), 0.22);
            AddItem(CreateEquipmentArmor(), 0.22);
            AddItem(CreateEquipmentClothing(), 0.22);
            AddItem(new ChroniclesOfFrance(), 1.0);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
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
            gold.Amount = Utility.Random(100, 1000);
            return gold;
        }

        private Item CreateConsumableWine()
        {
            BottleOfWine wine = new BottleOfWine();
            wine.Name = "Bottle of Napoleon’s Reserve";
            wine.Hue = 2117;
            return wine;
        }

        private Item CreateConsumableCheese()
        {
            CheeseWheel cheese = new CheeseWheel();
            cheese.Name = "Royal Cheese Platter";
            cheese.Hue = 1174;
            return cheese;
        }

        private Item CreateConsumableCroissant()
        {
            Muffins croissant = new Muffins();
            croissant.Name = "Croissant of Valor";
            croissant.Hue = 2530;
            return croissant;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Sun King's Hidden Treasury";
            map.Bounds = new Rectangle2D(1300, 1450, 500, 350);
            map.NewPin = new Point2D(1400, 1600);
            map.Protected = true;
            return map;
        }

        // ---- Legendary Equipment Section ----
        private Item CreateEquipmentWeapon()
        {
            // Legendary rapier with French theme
            Longsword weapon = new Longsword();
            weapon.Name = "Charlemagne’s Royal Rapier";
            weapon.Hue = 1281;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.AttackChance = 10;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            weapon.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateEquipmentArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Joan of Arc’s Sacred Breastplate";
            armor.Hue = 2501;
            armor.Attributes.DefendChance = 18;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.SpellChanneling = 1;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            armor.ColdBonus = 12;
            armor.FireBonus = 12;
            armor.PoisonBonus = 12;
            armor.EnergyBonus = 12;
            armor.PhysicalBonus = 12;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateEquipmentClothing()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Musketeer's Cloak";
            cloak.Hue = 1153;
            cloak.Attributes.Luck = 40;
            cloak.Attributes.BonusDex = 7;
            cloak.Attributes.BonusMana = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // ---- End Legendary Equipment Section ----

        public TreasureChestOfFrenchHistory(Serial serial) : base(serial) { }

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

    public class ChroniclesOfFrance : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of France", "Histories du Royaume",
            new BookPageInfo
            (
                "From the misty forests",
                "of ancient Gaul, to the",
                "echoing halls of Versailles,",
                "our story is written in blood,",
                "glory, and song. Vercingetorix",
                "defied Rome; the Franks",
                "forged unity, and the fleur-",
                "de-lis unfurled above kings."
            ),
            new BookPageInfo
            (
                "Charlemagne’s crown gleamed,",
                "empire reborn. Crusaders rode",
                "east for faith and gold. In the",
                "shadowed abbeys, monks",
                "preserved the light of reason.",
                "From cathedral spires, hope",
                "rose to Heaven; beneath, the",
                "peasants toiled."
            ),
            new BookPageInfo
            (
                "Joan of Arc, the Maid, heard",
                "saints’ voices, rallying France",
                "in darkest hour. Castles fell;",
                "banners burned. Yet Paris",
                "endured, as did the dream.",
                "Renaissance brought thinkers,",
                "painters, rebels and light."
            ),
            new BookPageInfo
            (
                "Revolution thundered—Liberty,",
                "Equality, Fraternity! Thrones",
                "toppled; the mob roared. A",
                "soldier from Corsica seized the",
                "world—Napoleon. Triumph and",
                "disaster marched together, as",
                "France danced on the edge of",
                "destiny."
            ),
            new BookPageInfo
            (
                "Empires fell. Republics rose.",
                "Yet always, the French soul",
                "sought glory and justice.",
                "Through wars, treaties, and the",
                "endless pursuit of liberty, the",
                "spirit endured—poets, heroes,",
                "and dreamers unforgotten."
            ),
            new BookPageInfo
            (
                "These treasures remember not",
                "just battles, but the artistry,",
                "the romance, and the undying",
                "hope of a nation forged anew,",
                "again and again.",
                "",
                "Vive la France!",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfFrance() : base(false)
        {
            Hue = 1153; // Blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of France");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of France");
        }

        public ChroniclesOfFrance(Serial serial) : base(serial) { }

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
