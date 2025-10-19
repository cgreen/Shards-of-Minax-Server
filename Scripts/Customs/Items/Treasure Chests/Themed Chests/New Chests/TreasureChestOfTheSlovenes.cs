using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSlovenes : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheSlovenes()
        {
            Name = "Treasure Chest of the Slovenes";
            Hue = 1269; // Lake Bled blue-green

            // Add items to the chest
            AddItem(CreateDecorativeItem<ArtifactVase>("Lake Bled Vase", 1269), 0.15);
            AddItem(CreateDecorativeItem<BakeKitsuneStatue>("Statue of the Goldenhorn (Zlatorog)", 1175), 0.10);
            AddItem(CreateDecorativeItem<IncenseBurner>("Triglav Incense Burner", 137), 0.12);
            AddItem(CreateDecorativeItem<FlowersArtifact>("Lipa Tree Blossom", 68), 0.18);
            AddItem(CreateDecorativeItem<CandelabraOfSouls>("Candelabra of the Ljubljana Dragon", 250), 0.08);
            AddItem(CreateConsumableItem("Carniolan Sausage", typeof(Sausage)), 0.13);
            AddItem(CreateConsumableItem("Potica Cake", typeof(Cake)), 0.10);
            AddItem(CreateConsumableItem("Flask of Medica", typeof(GreenBottle)), 0.11);
            AddItem(CreateSpecialGold("Slovenian Tolar Coins"), 0.15);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.18);
            AddItem(CreateClothing(), 0.18);
            AddItem(CreateAccessory(), 0.17);
            AddItem(new ChronicleOfTheSlovenes(), 1.0);
            AddItem(CreateMap(), 0.06);
            AddItem(new Gold(Utility.Random(3000, 9000)), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumableItem(string name, Type type)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            item.Hue = Utility.RandomList(1269, 68, 1175, 250);
            return item;
        }

        private Item CreateSpecialGold(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.Random(500, 2000);
            return gold;
        }

        private Item CreateWeapon()
        {
            // Legendary Sword of Zlatorog (Goldenhorn)
            Longsword sword = new Longsword();
            sword.Name = "Sword of Zlatorog";
            sword.Hue = 1175;
            sword.MaxDamage = Utility.Random(55, 75);
            sword.MinDamage = Utility.Random(25, 40);
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.BonusStr = 15;
            sword.Attributes.BonusHits = 25;
            sword.Attributes.SpellChanneling = 1;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.SelfRepair = 10;
            sword.Slayer = SlayerName.DragonSlaying;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // PlateChest of the Carniolan Knight
            PlateChest armor = new PlateChest();
            armor.Name = "Plate of the Carniolan Knight";
            armor.Hue = 1269;
            armor.BaseArmorRating = Utility.Random(48, 65);
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusDex = 10;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.Luck = 40;
            armor.PhysicalBonus = 15;
            armor.FireBonus = 7;
            armor.ColdBonus = 9;
            armor.EnergyBonus = 6;
            armor.PoisonBonus = 7;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            // Cloak of the Kurent (Slovenian Carnival spirit)
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Kurent";
            cloak.Hue = 250; // Red
            cloak.Attributes.LowerManaCost = 10;
            cloak.Attributes.BonusStam = 15;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusDex = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateAccessory()
        {
            // Carniolan Honeybee Ring
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Carniolan Bee";
            ring.Hue = 68; // Gold
            ring.Attributes.BonusMana = 10;
            ring.Attributes.Luck = 25;
            ring.Attributes.RegenMana = 3;
            ring.Attributes.RegenStam = 2;
            ring.Attributes.CastRecovery = 2;
            ring.SkillBonuses.SetValues(0, SkillName.AnimalLore, 8.0);
            ring.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 8.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Carantania";
            map.Bounds = new Rectangle2D(1600, 1200, 600, 700);
            map.NewPin = new Point2D(2000, 1600); // Example coords
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheSlovenes(Serial serial) : base(serial) { }

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

    public class ChronicleOfTheSlovenes : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Slovenes", "The Voice of the Lipa Tree",
            new BookPageInfo
            (
                "In ancient mists, the",
                "Slovenes wandered valleys,",
                "forest and lake, from the",
                "shores of the Drava to the",
                "peaks of Triglav. In Carantania,",
                "our ancestors first crowned their",
                "dukes beneath the Lipa tree,",
                "free in spirit and tongue."
            ),
            new BookPageInfo
            (
                "Romans marched through,",
                "leaving roads and legends.",
                "With the coming of Slavs,",
                "the land sang anew—Carniola,",
                "Styria, and the marchlands.",
                "Knights defended, and bishops",
                "prayed. Peasants tilled fields,",
                "dreaming of freedom."
            ),
            new BookPageInfo
            (
                "Under Habsburg shadows,",
                "the Slovenes kept their word,",
                "secret as the spring of",
                "Lake Bled. The Turks rode in,",
                "but the dragon of Ljubljana",
                "watched, and legends grew: Zlatorog,",
                "Kurent, and tales of the wild",
                "Karst winds."
            ),
            new BookPageInfo
            (
                "Empires fell and rose.",
                "The tongue of France echoed in",
                "the Illyrian Provinces, and",
                "national poets awoke. The",
                "voice of Preseren rang out:",
                "\"Live and let live, for all",
                "peoples are kin beneath the sky.\""
            ),
            new BookPageInfo
            (
                "The fires of war swept",
                "the land—one world, then",
                "another. Yet the Slovenes endured,",
                "in mountain redoubts and rivers",
                "deep. At last, in 1991, under",
                "the blue-white-red, the nation",
                "arose: free, proud, and unbowed."
            ),
            new BookPageInfo
            (
                "Now, whoever finds this chest,",
                "know you hold a treasure",
                "of story, not just gold.",
                "Honor the dragon, taste the honey,",
                "walk the forests, climb the peaks.",
                "Remember: to be Slovene is",
                "to cherish freedom, and to",
                "keep the song alive."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheSlovenes() : base(false)
        {
            Hue = 1269; // Lake Bled blue-green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Slovenes");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Slovenes");
        }

        public ChronicleOfTheSlovenes(Serial serial) : base(serial) { }

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
