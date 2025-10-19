using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientEgypt : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientEgypt()
        {
            Name = "Treasure Chest of Ancient Egypt";
            Hue = 1281; // Gold sand

            // Add themed items
            AddItem(CreateNamedDeco<ArtifactLargeVase>("Canopic Jar of Osiris", 2125), 0.18);
            AddItem(CreateNamedDeco<SnakeStatue>("Cobra Idol of Wadjet", 1271), 0.10);
            AddItem(CreateNamedDeco<Urn1Artifact>("Urn of Eternal Sand", 2419), 0.18);
            AddItem(CreateNamedDeco<WoodenChest>("Pharaoh’s Sarcophagus Miniature", 2418), 0.11);
            AddItem(CreateNamedDeco<BrazierArtifact>("Sacred Flame of Ra", 1357), 0.13);
            AddItem(CreateNamedDeco<GoldBricks>("Bricks from the Treasure Vault", 2213), 0.17);

            AddItem(CreatePotion("Elixir of the Nile", 1452), 0.15);
            AddItem(CreatePotion("Sands of Anubis", 2301), 0.10);

            AddItem(CreateFood("Royal Fig Cake", 1266), 0.08);
            AddItem(CreateFood("Lotus Petal Tea", 1267), 0.08);

            AddItem(CreateJewelry(), 0.20);

            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateCloak(), 0.19);
            AddItem(CreateHat(), 0.18);

            AddItem(CreateCurrency("Pharaoh’s Gold Coin", 2213), 0.15);
            AddItem(CreateCurrency("Scarab Amulet", 1275), 0.11);

            AddItem(new ScrollOfThePharaohs(), 1.0); // always drop

            AddItem(CreateMap(), 0.07);

            AddItem(new Gold(Utility.RandomMinMax(2000, 7500)), 0.23);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateNamedDeco<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreatePotion(string name, int hue)
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            potion.Stackable = false;
            return potion;
        }

        private Item CreateFood(string name, int hue)
        {
            Cake food = new Cake();
            food.Name = name;
            food.Hue = hue;
            food.Weight = 1.0;
            return food;
        }

        private Item CreateJewelry()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Bracelet of the Crook & Flail";
            bracelet.Hue = 2213;
            bracelet.Attributes.Luck = 80;
            bracelet.Attributes.BonusHits = 10;
            bracelet.Attributes.RegenHits = 2;
            bracelet.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            bracelet.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        private Item CreateCurrency(string name, int hue)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Hue = hue;
            gold.Amount = Utility.RandomMinMax(50, 120);
            return gold;
        }

        private Item CreateWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Scimitar of Sekhmet";
            weapon.Hue = 2219;
            weapon.WeaponAttributes.HitFireball = 30;
            weapon.WeaponAttributes.HitLeechHits = 20;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.Luck = 45;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Breastplate of the Sun God";
            armor.Hue = 2418;
            armor.BaseArmorRating = Utility.RandomMinMax(48, 72);
            armor.Attributes.BonusHits = 18;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.Attributes.Luck = 65;
            armor.ColdBonus = 12;
            armor.EnergyBonus = 18;
            armor.FireBonus = 24;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Nile";
            cloak.Hue = 1266;
            cloak.Attributes.Luck = 90;
            cloak.Attributes.RegenStam = 4;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 16.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 13.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateHat()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Pharaoh's Nemes";
            hat.Hue = 2213;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.BonusMana = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.EvalInt, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Hidden Pyramid";
            map.Bounds = new Rectangle2D(400, 400, 200, 200);
            map.NewPin = new Point2D(498, 512);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfAncientEgypt(Serial serial) : base(serial) { }

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

    public class ScrollOfThePharaohs : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Scroll of the Pharaohs", "High Priest Imhotep",
            new BookPageInfo
            (
                "In the land where the Nile",
                "winds, the gods walked among",
                "men, and kings wore the",
                "double crown. Osiris judges",
                "the dead, while Ra sails",
                "the golden sky. From the",
                "earliest days, Egypt has",
                "been a land of wonder."
            ),
            new BookPageInfo
            (
                "Pyramids rose from desert",
                "sands, eternal monuments to",
                "power and faith. The pharaohs",
                "commanded armies and built",
                "cities. Priests guarded",
                "secrets—rituals of life,",
                "death, and rebirth."
            ),
            new BookPageInfo
            (
                "The Sphinx watches, silent,",
                "over the Giza plateau. In",
                "the Valley of Kings, tombs",
                "hide treasures and curses.",
                "Hieroglyphs whisper tales of",
                "glory, betrayal, and divine",
                "destiny."
            ),
            new BookPageInfo
            (
                "In shadowed temples,",
                "incense burns for Isis, for",
                "Anubis, for Horus. The",
                "Book of the Dead guides",
                "souls to their fate, as",
                "scarabs and ankhs protect",
                "the worthy on their journey."
            ),
            new BookPageInfo
            (
                "Let this scroll record",
                "the wisdom of ages:",
                "Seek knowledge as the",
                "scribe. Be bold as the",
                "lion. Endure as the stone.",
                "",
                "Heed the past, and its",
                "power may serve you."
            ),
            new BookPageInfo
            (
                "Those who disturb the",
                "sleep of pharaohs, beware:",
                "The desert remembers.",
                "The gods judge. Only",
                "the true-hearted may",
                "claim the treasure of",
                "ancient Egypt."
            ),
            new BookPageInfo
            (
                "",
                "",
                "- High Priest Imhotep",
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
        public ScrollOfThePharaohs() : base(false)
        {
            Hue = 2418; // Regal golden
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Scroll of the Pharaohs");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Scroll of the Pharaohs");
        }

        public ScrollOfThePharaohs(Serial serial) : base(serial) { }

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
