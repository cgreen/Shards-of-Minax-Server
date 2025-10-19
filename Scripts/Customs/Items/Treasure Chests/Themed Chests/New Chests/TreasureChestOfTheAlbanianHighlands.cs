using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheAlbanianHighlands : MetalGoldenChest
    {
        [Constructable]
        public TreasureChestOfTheAlbanianHighlands()
        {
            Name = "Treasure Chest of the Albanian Highlands";
            Hue = 2101;

            // Add items to the chest
            AddItem(CreateNamedItem<GoldRing>("Ring of Skanderbeg"), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Sacred Water of Krujë", 1154), 0.20);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateDecorative("Eagle Crest of Illyria", typeof(DecorativeShield1), 1150), 0.20);
            AddItem(CreateBook(), 1.0);
            AddItem(new Gold(Utility.Random(1000, 7000)), 0.25);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateColoredItem<Sextant>("Navigator's Tool from Durrës", 1175), 0.15);
            AddItem(CreateClothing(), 0.20);
            AddItem(CreateArtifact("Flamuri i Lirisë", typeof(ChaosBanner), 1154), 0.18);
        }

        private void AddItem(Item item, double chance)
        {
            if (Utility.RandomDouble() < chance)
                DropItem(item);
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            var item = new T();
            item.Name = name;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            var item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorative(string name, Type type, int hue)
        {
            if (Activator.CreateInstance(type) is Item item)
            {
                item.Name = name;
                item.Hue = hue;
                return item;
            }
            return null;
        }

        private Item CreateArtifact(string name, Type type, int hue)
        {
            var item = CreateDecorative(name, type, hue);
            if (item != null)
                XmlAttach.AttachTo(item, new XmlLevelItem());
            return item;
        }

        private Item CreateMap()
        {
            var map = new SimpleMap
            {
                Name = "Map of the Accursed Mountains",
                Bounds = new Rectangle2D(1100, 1100, 400, 400),
                NewPin = new Point2D(1234, 1302),
                Protected = true
            };
            return map;
        }

        private Item CreateBook()
        {
            return new ChroniclesOfAlbania();
        }

        private Item CreateWeapon()
        {
            var weapon = new Scimitar
            {
                Name = "Blade of Skanderbeg",
                Hue = 1147,
                MinDamage = 35,
                MaxDamage = 60
            };
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Attributes.SpellChanneling = 1;
            weapon.Attributes.BonusStr = 10;
            weapon.WeaponAttributes.HitLeechStam = 15;
            weapon.WeaponAttributes.HitFireball = 25;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            var chest = new PlateChest
            {
                Name = "Illyrian Warplate",
                Hue = 1141,
                BaseArmorRating = 45
            };
            chest.Attributes.BonusHits = 20;
            chest.Attributes.DefendChance = 15;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateClothing()
        {
            var sash = new BodySash
            {
                Name = "Traditional Red Sash of the Highlands",
                Hue = 33
            };
            sash.Attributes.Luck = 30;
            sash.Attributes.NightSight = 1;
            XmlAttach.AttachTo(sash, new XmlLevelItem());
            return sash;
        }

        public TreasureChestOfTheAlbanianHighlands(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    public class ChroniclesOfAlbania : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Albania", "Gjergj Kastrioti",
            new BookPageInfo
            (
                "In the shadow of Illyrian ruins,",
                "our ancestors carved a legacy",
                "on mountain and sea. We are",
                "the children of Eagles, of kings",
                "and poets, of rebels and",
                "prophets. This land breathes",
                "through us — the North cries",
                "in blood, the South in song."
            ),
            new BookPageInfo
            (
                "I am Skanderbeg. Sword of",
                "Albania. Against the Turk I",
                "stood. Not for glory, nor gold,",
                "but for the right to speak in",
                "our tongue, to worship in our",
                "way, to live free beneath the",
                "Albanian sky. Twenty years, I",
                "held the gates of the West."
            ),
            new BookPageInfo
            (
                "Yet even I am a whisper now,",
                "a tale mothers tell their sons",
                "in flickering firelight. But the",
                "mountains remember. The blood",
                "remembers. In every stone of",
                "Krujë, every wave of Durrës, the",
                "spirit of a nation sleeps, never",
                "dying — only waiting."
            ),
            new BookPageInfo
            (
                "Let those who open this chest",
                "know: this is not mere treasure.",
                "It is defiance made steel. History",
                "forged in iron. And as long as",
                "even one voice sings in Gheg or",
                "Tosk, Albania endures.",
                "",
                "— Gjergj Kastrioti"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfAlbania() : base(false)
        {
            Hue = 1154;
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Albania");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Albania");
        }

        public ChroniclesOfAlbania(Serial serial) : base(serial) { }

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
