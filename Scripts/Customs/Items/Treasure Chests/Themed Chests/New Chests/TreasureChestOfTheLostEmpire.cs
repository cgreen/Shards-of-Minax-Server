using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheLostEmpire : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheLostEmpire()
        {
            Name = "Treasure Chest of the Lost Empire";
            Hue = 2125; // Deep golden, Inca-style

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ceremonial Qero", 1360), 0.20);
            AddItem(CreateDecorativeItem<GoldBricks>("Sun God's Offering", 2213), 0.12);
            AddItem(CreateDecorativeItem<Sculpture2Artifact>("Silver Llama Idol", 1150), 0.12);
            AddItem(CreateDecorativeItem<CrabBushel>("Sacred Maize Basket", 2425), 0.10);
            AddItem(CreateConsumable<GreaterHealPotion>("Potion of Eternal Health", 1279), 0.16);
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Choclo Cake", 2125), 0.13);
            AddItem(CreateMap(), 0.07);
            AddItem(CreateGoldItem("Sun Empire Coins"), 0.17);
            AddItem(CreateGem("Emerald of Machu Picchu", 1424), 0.12);
            AddItem(CreateUniqueClothing(), 0.25);
            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateUniqueWeapon(), 0.20);
            AddItem(CreateUniqueHeadgear(), 0.16);
            AddItem(new Gold(Utility.Random(3500, 7000)), 0.21);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateLoreBook()
        {
            return new ChronicleOfTheSun();
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGem(string name, int hue)
        {
            Emerald gem = new Emerald();
            gem.Name = name;
            gem.Hue = hue;
            return gem;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Paititi, City of Gold";
            map.Bounds = new Rectangle2D(5050, 640, 480, 480);
            map.NewPin = new Point2D(5170, 750);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Sapa Inca's Sun Robe";
            robe.Hue = 2125;
            robe.Attributes.Luck = 80;
            robe.Attributes.BonusMana = 10;
            robe.Attributes.SpellDamage = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Armor of the Four Suyus";
            chest.Hue = 1161;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusHits = 30;
            chest.Attributes.RegenHits = 2;
            chest.Attributes.DefendChance = 8;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 12.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueWeapon()
        {
            Scimitar tumi = new Scimitar();
            tumi.Name = "Tumi, Sacred Ceremonial Blade";
            tumi.Hue = 1270;
            tumi.MinDamage = 32;
            tumi.MaxDamage = 65;
            tumi.Attributes.BonusHits = 10;
            tumi.Attributes.WeaponSpeed = 25;
            tumi.Attributes.SpellChanneling = 1;
            tumi.Attributes.CastRecovery = 2;
            tumi.WeaponAttributes.HitFireball = 15;
            tumi.WeaponAttributes.HitLeechHits = 10;
            tumi.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(tumi, new XmlLevelItem());
            return tumi;
        }

        private Item CreateUniqueHeadgear()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Mascaypacha of the Sapa Inca";
            hat.Hue = 2213;
            hat.Attributes.Luck = 40;
            hat.Attributes.BonusInt = 8;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        public TreasureChestOfTheLostEmpire(Serial serial) : base(serial)
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

    public class ChronicleOfTheSun : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Sun", "Tupaq Yupanqui",
            new BookPageInfo
            (
                "In the sacred valley,",
                "where the Urubamba winds,",
                "my people raised walls",
                "of stone, strong as",
                "mountains. I am child",
                "of Inti, the Sun God,",
                "born to rule Cuzco,",
                "navel of the world."
            ),
            new BookPageInfo
            (
                "Qhapaq Ñan, the great road,",
                "binds the empire,",
                "from icy Andes to jungles,",
                "from the coast’s silver",
                "to Titicaca’s blue. Four",
                "suyus, one heart. The",
                "chosen women weave, priests",
                "watch the heavens."
            ),
            new BookPageInfo
            (
                "Our gold is the sweat of",
                "the sun. Our silver, the",
                "tears of the moon. Viracocha",
                "gave us wisdom. The Sapa Inca,",
                "child of the sun, commands.",
                "All labor is shared. All food",
                "stored in qollqas for the",
                "people."
            ),
            new BookPageInfo
            (
                "Strangers from beyond the sea",
                "arrive, hungry for gold.",
                "Their thunder weapons roar,",
                "but the soul endures. The last",
                "sons of the sun carry treasures",
                "into the hidden valleys.",
                "The lost city awaits."
            ),
            new BookPageInfo
            (
                "Whoever finds this chest,",
                "remember: the sun returns.",
                "Our story is not ash.",
                "Seek Paititi, city of gold,",
                "and honor the ancestors.",
                "In life, as in legend,",
                "the Inca endure.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Chaska, guardian star,",
                "watch over this legacy.",
                "May Inti bless those",
                "with pure hearts.",
                "",
                "- Tupaq Yupanqui",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheSun() : base(false)
        {
            Hue = 2125; // Golden Sun
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Sun");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Sun");
        }

        public ChronicleOfTheSun(Serial serial) : base(serial) { }

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
