using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheBengalDelta : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheBengalDelta()
        {
            Name = "Treasure Chest of the Bengal Delta";
            Hue = 2063; // Rich green, like the Bengal delta

            // Add items to the chest
            AddItem(CreateNamedItem<BowlArtifact>("Bowl of the Padma River Clay", 2075), 0.18);
            AddItem(CreateNamedItem<PoetryBook>("Songs of Tagore"), 0.10);
            AddItem(CreateNamedItem<RedHangingLantern>("Lantern of Victory Day", 1153), 0.12);
            AddItem(CreateUniqueGear(), 0.24);
            AddItem(CreateArmorPiece(), 0.20);
            AddItem(CreateNamedItem<FeatheredHat>("Mughal Courtier’s Plume", 2452), 0.16);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Sufi Mystics"), 0.17);
            AddItem(CreateNamedItem<GreenTea>("Sundarbans Tea Leaves", 2123), 0.22);
            AddItem(CreateNamedItem<Gold>("Taka of Dhaka", 1281), 0.18);
            AddItem(CreateNamedItem<DecorativeShield8>("Shield of the Royal Bengal Tiger", 2125), 0.10);
            AddItem(CreateUniqueBook(), 1.0);
            AddItem(CreateNamedItem<FullApron>("Apron of the Rickshaw Painter", 1360), 0.16);
            AddItem(CreateNamedItem<Basket2Artifact>("Basket of Jute Fibers", 1164), 0.20);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateFood(), 0.19);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Liberation Marcher", 2008), 0.18);
            AddItem(CreateMap(), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateUniqueBook()
        {
            return new ChroniclesOfBengal();
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Bengal Delta";
            map.Bounds = new Rectangle2D(2500, 1500, 700, 700);
            map.NewPin = new Point2D(3000, 1700);
            map.Protected = true;
            return map;
        }

        private Item CreateUniqueGear()
        {
            // A weapon themed to the Mukti Bahini (freedom fighters)
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Mukti Bahini’s Liberation Blade";
            scimitar.Hue = 2055;
            scimitar.MinDamage = 40;
            scimitar.MaxDamage = 65;
            scimitar.Attributes.WeaponSpeed = 15;
            scimitar.Attributes.WeaponDamage = 30;
            scimitar.WeaponAttributes.HitFireball = 25;
            scimitar.WeaponAttributes.HitDispel = 10;
            scimitar.WeaponAttributes.SelfRepair = 7;
            scimitar.Attributes.BonusStr = 10;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Tactics, 15.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateArmorPiece()
        {
            // Armor referencing 1952 Language Martyrs (Shaheed Minar)
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Shaheed Minar";
            armor.Hue = 1157;
            armor.BaseArmorRating = 55;
            armor.Attributes.BonusHits = 30;
            armor.Attributes.NightSight = 1;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateWeapon()
        {
            // Unique river-themed staff
            GnarledStaff staff = new GnarledStaff();
            staff.Name = "Staff of the Padma River";
            staff.Hue = 2006;
            staff.MinDamage = 25;
            staff.MaxDamage = 55;
            staff.Attributes.SpellChanneling = 1;
            staff.WeaponAttributes.HitLightning = 18;
            staff.WeaponAttributes.HitLeechMana = 10;
            staff.Attributes.BonusMana = 12;
            staff.Attributes.BonusInt = 8;
            staff.SkillBonuses.SetValues(0, SkillName.Magery, 18.0);
            staff.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(staff, new XmlLevelItem());
            return staff;
        }

        private Item CreateFood()
        {
            // Special rice dish
            Cake cake = new Cake();
            cake.Name = "Panta Ilish of the Festival";
            cake.Hue = 2009;
            XmlAttach.AttachTo(cake, new XmlLevelItem());
            return cake;
        }

        public TreasureChestOfTheBengalDelta(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBengal : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Bengal", "Anonymous Scribe",
            new BookPageInfo
            (
                "In the heart of the delta,",
                "where rivers braid the land,",
                "there lies a story ancient,",
                "etched in silt and sand.",
                "This is Bengal, daughter",
                "of the Padma, proud and wide,",
                "her children sowed by sun,",
                "her fate by tide."
            ),
            new BookPageInfo
            (
                "From the age of Pundra kings,",
                "to the sultans and Mughals’ reign,",
                "The Ganges, Meghna, Jamuna,",
                "nourished golden grain.",
                "Poets sang of honeyed air,",
                "musk and mango, silk and spice,",
                "In bazaars of Sonargaon,",
                "traders gambled dice."
            ),
            new BookPageInfo
            (
                "The British flag unfurled,",
                "partitioned hope and home,",
                "Yet the voice of Bengal thundered,",
                "never to be overthrown.",
                "In '52, words became martyrs,",
                "language drenched in red;",
                "The Shaheed Minar stands,",
                "where brave souls bled."
            ),
            new BookPageInfo
            (
                "1971 dawned in fire,",
                "the rivers ran with tears,",
                "Mukti Bahini took the field,",
                "shattering the yoke of fear.",
                "The cries of Dhaka rang",
                "through village and through town,",
                "As Bengal rose to claim her name,",
                "the old empire tumbled down."
            ),
            new BookPageInfo
            (
                "Today the delta blossoms",
                "with hope and ancient pride,",
                "Her cities, her fields, her poetry",
                "forever shall abide.",
                "Who opens this chest, remember",
                "those who dreamed and bled;",
                "Honor their courage, cherish",
                "every tear once shed."
            ),
            new BookPageInfo
            (
                "May the Padma bless your journey,",
                "the Sundarbans your shield;",
                "Let the roar of the Royal Tiger",
                "remind you: never yield.",
                "For Bangladesh is not a name,",
                "but the longing of a land—",
                "Of rivers, rebels, poetry,",
                "and an unbroken stand."
            ),
            new BookPageInfo
            (
                "Signed in the year of freedom,",
                "by the hand of a wandering bard.",
                "",
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
        public ChroniclesOfBengal() : base(false)
        {
            Hue = 2063; // Green of the Bengal delta
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Bengal");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Bengal");
        }

        public ChroniclesOfBengal(Serial serial) : base(serial) { }

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

    // Optional: Add a small poetry book as a decorative item
    public class PoetryBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Songs of Tagore", "Rabindranath Tagore",
            new BookPageInfo
            (
                "Where the mind is without fear",
                "and the head is held high;",
                "Where knowledge is free;",
                "",
                "Into that heaven of freedom,",
                "my Father, let my country awake."
            ),
            new BookPageInfo
            (
                "If they answer not to Thy call,",
                "walk alone, walk alone, walk alone.",
                "If they turn away, and desert you,",
                "O thou unlucky one,",
                "walk alone, walk alone, walk alone."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public PoetryBook() : base(false)
        {
            Hue = 1281; // Golden hue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Songs of Tagore");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Songs of Tagore");
        }

        public PoetryBook(Serial serial) : base(serial) { }

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
