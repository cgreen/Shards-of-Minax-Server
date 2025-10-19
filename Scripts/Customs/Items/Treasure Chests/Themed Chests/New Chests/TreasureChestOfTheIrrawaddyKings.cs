using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheIrrawaddyKings : OrnateWoodenChest
    {
        [Constructable]
        public TreasureChestOfTheIrrawaddyKings()
        {
            Name = "Treasure Chest of the Irrawaddy Kings";
            Hue = 2966; // Deep emerald, like the Irrawaddy river

            // Add unique themed items
            AddItem(CreateColoredArtifact<ArtifactVase>("Burmese Celadon Vase", 2124), 0.18);
            AddItem(CreateNamedFood("Royal Mohinga Platter"), 0.13);
            AddItem(CreateColoredArtifact<Painting1NorthArtifact>("Mandalay Palace Painting", 1153), 0.15);
            AddItem(CreateNamedConsumable<GreaterHealPotion>("Elixir of Bagan Mystics"), 0.17);
            AddItem(CreateNamedGem("Sapphire of the Irrawaddy"), 0.16);
            AddItem(CreateNamedGem("Imperial Burmese Ruby"), 0.10);
            AddItem(CreateEquipment(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateRobes(), 0.16);
            AddItem(CreateHat(), 0.17);
            AddItem(CreateDecorativeFan(), 0.15);
            AddItem(CreateUniqueMap(), 0.07);
            AddItem(new ChroniclesOfTheIrrawaddyKings(), 1.0);
            AddItem(CreateColoredArtifact<Sculpture1Artifact>("Golden Lion of Burma", 2213), 0.12);
            AddItem(CreateNamedConsumable<GreaterCurePotion>("Pagoda Tea of Longevity"), 0.13);
            AddItem(CreateNamedFood("Spiced Tea Leaf Salad"), 0.10);
            AddItem(new Gold(Utility.Random(1, 5000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateColoredArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedConsumable<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateNamedFood(string name)
        {
            FruitBasket food = new FruitBasket();
            food.Name = name;
            food.Hue = 2125;
            return food;
        }

        private Item CreateNamedGem(string name)
        {
            Ruby gem = new Ruby();
            gem.Name = name;
            gem.Hue = Utility.RandomList(1157, 1175, 2124); // red, gold, or jade
            return gem;
        }

        private Item CreateRobes()
        {
            MaleKimono robe = new MaleKimono();
            robe.Name = "Royal Robes of Pagan";
            robe.Hue = 1175;
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusMana = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 12.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Headdress of the Konbaung Kings";
            hat.Hue = 2967;
            hat.Attributes.BonusInt = 20;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Inscribe, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Focus, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateDecorativeFan()
        {
            FanNorthArtifact fan = new FanNorthArtifact();
            fan.Name = "Imperial Peacock Fan";
            fan.Hue = 1436;
            return fan;
        }

        private Item CreateEquipment()
        {
            Katana weapon = new Katana();
            weapon.Name = "Sword of King Anawrahta";
            weapon.Hue = 2125;
            weapon.MinDamage = 30;
            weapon.MaxDamage = 62;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.WeaponAttributes.SelfRepair = 8;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.BonusHits = 25;
            weapon.Attributes.SpellChanneling = 1;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the White Elephant";
            armor.Hue = 2498;
            armor.BaseArmorRating = 55;
            armor.Attributes.BonusStr = 20;
            armor.Attributes.DefendChance = 15;
            armor.Attributes.BonusStam = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Bagan Temples";
            map.Bounds = new Rectangle2D(4200, 2900, 320, 390); // Fictional UO coords for Bagan
            map.NewPin = new Point2D(4350, 3025);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheIrrawaddyKings(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheIrrawaddyKings : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Irrawaddy Kings", "Scribe of Mandalay",
            new BookPageInfo
            (
                "In the shadow of the Pagodas,",
                "where the Irrawaddy glides",
                "like jade, kings have risen.",
                "From Pagan’s stone spires,",
                "Anawrahta forged the first",
                "realm, uniting the land",
                "with wisdom and steel."
            ),
            new BookPageInfo
            (
                "The golden bells of Bagan",
                "sang with prayers, while",
                "armies marched beneath",
                "white elephants and peacock",
                "banners. Dynasties rose—",
                "Pagan, Ava, Toungoo, Konbaung.",
                "Their glories glimmer on"
            ),
            new BookPageInfo
            (
                "temple walls and in the",
                "songs of river folk.",
                "Mandalay shone as the last",
                "royal jewel before thunder",
                "from across the seas ended",
                "the kings’ long reign."
            ),
            new BookPageInfo
            (
                "Yet the spirit of Myanmar",
                "endures: in emerald rice",
                "fields, in golden Shwedagon,",
                "in the fire of hope. May the",
                "one who opens this chest",
                "tread softly, for the blessings",
                "and burdens of the Irrawaddy",
                "kings are many."
            ),
            new BookPageInfo
            (
                "Seek the wisdom of ancient",
                "palms, the strength of",
                "elephants, the patience of",
                "the river. Carry our story.",
                "",
                "— Chronicle ends —",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheIrrawaddyKings() : base(false)
        {
            Hue = 2125; // Jade green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Irrawaddy Kings");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Irrawaddy Kings");
        }

        public ChroniclesOfTheIrrawaddyKings(Serial serial) : base(serial) { }

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
