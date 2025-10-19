using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfDjibouti : WoodenChest
    {
        [Constructable]
        public TreasureChestOfDjibouti()
        {
            Name = "Treasure Chest of Djibouti";
            Hue = 1153; // Sandy gold

            // Add items to the chest
            AddItem(CreateSaltCrystal(), 0.30);
            AddItem(CreateTradeBeads(), 0.18);
            AddItem(CreateColoredItem<GreaterCurePotion>("Horn of Africa Coffee", 2106), 0.15);
            AddItem(CreateAncientMap(), 0.10);
            AddItem(CreateDjiboutiRing(), 0.11);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Salt Caravans"), 0.17);
            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateUniqueWeapon(), 0.19);
            AddItem(CreateDjiboutiBook(), 1.0);
            AddItem(CreateDjiboutiGold(), 0.15);
            AddItem(CreateDjiboutiConsumable(), 0.20);
            AddItem(CreateDjiboutiArtifact(), 0.10);
            AddItem(CreateColoredItem<BlueBook>("Treaty of the Gulf", 92), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative Items

        private Item CreateSaltCrystal()
        {
            Diamond salt = new Diamond();
            salt.Name = "Salt Crystal of Lake Assal";
            salt.Hue = 1153; // Pale gold
            return salt;
        }

        private Item CreateTradeBeads()
        {
            BottleArtifact beads = new BottleArtifact();
            beads.Name = "Red Sea Trade Beads";
            beads.Hue = 1359; // Deep blue
            return beads;
        }

        private Item CreateAncientMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Ancient Map of the Gulf of Tadjoura";
            map.Bounds = new Rectangle2D(2000, 1100, 600, 450);
            map.NewPin = new Point2D(2250, 1330);
            map.Protected = true;
            return map;
        }

        private Item CreateDjiboutiArtifact()
        {
            Sculpture1Artifact artifact = new Sculpture1Artifact();
            artifact.Name = "Idole of the Ifat Sultanate";
            artifact.Hue = 2001;
            return artifact;
        }

        private Item CreateDjiboutiGold()
        {
            Gold gold = new Gold(Utility.Random(1000, 3000));
            gold.Name = "Djibouti Francs";
            return gold;
        }

        private Item CreateDjiboutiRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of Tadjoura";
            ring.Hue = 2113;
            ring.Attributes.Luck = 50;
            ring.Attributes.BonusStam = 10;
            ring.Attributes.RegenStam = 3;
            ring.SkillBonuses.SetValues(0, SkillName.Meditation, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        // Consumables

        private Item CreateDjiboutiConsumable()
        {
            CookedBird jerky = new CookedBird();
            jerky.Name = "Salted Camel Jerky";
            jerky.Hue = 2401;
            return jerky;
        }

        // Unique Equipment

        private Item CreateUniqueArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Afar Guardian";
            chest.Hue = 2101;
            chest.BaseArmorRating = Utility.Random(44, 69);
            chest.Attributes.BonusHits = 18;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.RegenHits = 2;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            chest.PhysicalBonus = 12;
            chest.FireBonus = 10;
            chest.PoisonBonus = 8;
            chest.ColdBonus = 6;
            chest.EnergyBonus = 6;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueWeapon()
        {
            Scimitar weapon = new Scimitar();
            weapon.Name = "Sultan's Curved Blade";
            weapon.Hue = 2020;
            weapon.MinDamage = 33;
            weapon.MaxDamage = 64;
            weapon.Attributes.AttackChance = 10;
            weapon.Attributes.WeaponSpeed = 25;
            weapon.Attributes.BonusDex = 10;
            weapon.WeaponAttributes.HitLightning = 15;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.WeaponAttributes.HitHarm = 12;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        // Utility

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

        // Lore Book

        private Item CreateDjiboutiBook()
        {
            return new ChroniclesOfDjibouti();
        }

        public TreasureChestOfDjibouti(Serial serial) : base(serial)
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

    public class ChroniclesOfDjibouti : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Djibouti: Gateway of the Red Sea", "Al-Muqadassi the Chronicler",
            new BookPageInfo
            (
                "In the shadows of the Horn of Africa,",
                "Djibouti has long stood as a",
                "sentinel at the gate between worlds.",
                "Here, the ancient salt caravans",
                "crossed blazing deserts to reach",
                "the shores where sultans traded",
                "ivory, frankincense, and gold."
            ),
            new BookPageInfo
            (
                "The Afar and Somali peoples shaped",
                "these lands, their clans entwined",
                "with the fortunes of sea and sand.",
                "From Obock to Tadjoura, markets",
                "echoed with a thousand tongues,",
                "as sailors from Egypt, Arabia, and",
                "India bartered beneath palm and star."
            ),
            new BookPageInfo
            (
                "The sultanates of Ifat and Adal",
                "rose and fell, their mosques and",
                "forts silent witnesses to centuries",
                "of faith and struggle. The Red Sea,",
                "a highway for pilgrims, warriors,",
                "and merchants, brought distant dreams",
                "to these ancient shores."
            ),
            new BookPageInfo
            (
                "In later days, French tricolor",
                "fluttered above Djibouti’s harbor,",
                "and railways stitched the land to",
                "Abyssinia’s heights. Still, the salt",
                "winds carried secrets and stories.",
                "To cross Lake Assal is to walk the",
                "edge of the world."
            ),
            new BookPageInfo
            (
                "Today, Djibouti stands at the",
                "crossroads of time—its people proud,",
                "its legacy enduring. Let this chest",
                "bear witness to its treasures:",
                "The salt, the blade, the lore,",
                "and the spirit of the Gateway of",
                "the Red Sea."
            ),
            new BookPageInfo
            (
                "May those who seek its fortune",
                "carry the tales of caravan and sultan,",
                "of salt and sea, into the ages beyond.",
                "",
                "- Al-Muqadassi",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfDjibouti() : base(false)
        {
            Hue = 1153;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Djibouti: Gateway of the Red Sea");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Djibouti: Gateway of the Red Sea");
        }

        public ChroniclesOfDjibouti(Serial serial) : base(serial) { }

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
