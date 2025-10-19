using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLiechtenstein : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLiechtenstein()
        {
            Name = "Treasure Chest of Liechtenstein";
            Hue = 1154; // Royal blue and gold

            // Add items to the chest
            AddItem(new PrincipalityScepter(), 0.10);
            AddItem(CreateColoredItem<GoldBracelet>("Vaduz Heirloom Bracelet", 1289), 0.25);
            AddItem(CreateColoredItem<Ruby>("Ruby of Balzers", 1640), 0.13);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Rhine Valley", 1171), 0.18);
            AddItem(CreateNamedItem<GoldEarrings>("Earrings of the Schellenberg Countess"), 0.15);
            AddItem(CreateDecorativeItem<BambooStoolArtifact>("Throne of the Prince", 1161), 0.09);
            AddItem(CreateDecorativeItem<ArtifactBookshelf>("Castle Library Collection", 1154), 0.08);
            AddItem(CreateNamedItem<GreaterHealPotion>("Liechtensteiner Mirabelle Elixir"), 0.16);
            AddItem(CreateGoldItem("Liechtenstein Francs"), 0.18);
            AddItem(CreateDecorativeItem<Painting1WestArtifact>("Portrait of Johann Adam Andreas", 1175), 0.10);
            AddItem(CreateDecorativeItem<SilverSteedZooStatuette>("Steed of the Alpine Guard", 250), 0.12);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Vase of Alpine Wildflowers", 65), 0.12);
            AddItem(CreateNamedItem<Sextant>("Cartographer's Sextant of Vaduz"), 0.08);
            AddItem(CreateDecorativeItem<GoldBricks>("Bricks from the Castle Wall", 2212), 0.07);
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateCloak(), 0.13);
            AddItem(CreateWideBrimHat(), 0.15);
            AddItem(CreateDagger(), 0.18);
            AddItem(new ChronicleOfThePrinces(), 1.0);
            AddItem(new Gold(Utility.Random(1500, 5000)), 0.13);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

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

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            // Custom "Liechtenstein Pike" with Alpine bonuses
            Pike pike = new Pike();
            pike.Name = "Alpine Pike of the Guard";
            pike.Hue = 1171;
            pike.MinDamage = Utility.Random(35, 60);
            pike.MaxDamage = Utility.Random(60, 90);
            pike.Attributes.WeaponDamage = 45;
            pike.Attributes.BonusStr = 10;
            pike.Attributes.BonusHits = 20;
            pike.Attributes.AttackChance = 15;
            pike.Attributes.DefendChance = 15;
            pike.WeaponAttributes.HitFireball = 25;
            pike.WeaponAttributes.SelfRepair = 6;
            pike.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            pike.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(pike, new XmlLevelItem());
            return pike;
        }

        private Item CreateArmor()
        {
            // Custom "Royal Plate Chest"
            PlateChest chest = new PlateChest();
            chest.Name = "Royal Chestplate of Liechtenstein";
            chest.Hue = 1154;
            chest.BaseArmorRating = Utility.Random(45, 70);
            chest.ArmorAttributes.LowerStatReq = 20;
            chest.Attributes.BonusHits = 25;
            chest.Attributes.BonusDex = 10;
            chest.Attributes.RegenHits = 3;
            chest.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            chest.PhysicalBonus = 22;
            chest.FireBonus = 13;
            chest.ColdBonus = 13;
            chest.PoisonBonus = 12;
            chest.EnergyBonus = 18;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Vaduz Castle";
            cloak.Hue = 1289; // Royal blue
            cloak.Attributes.Luck = 50;
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusMana = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Focus, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateWideBrimHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Hat of the Schellenberg Envoy";
            hat.Hue = 2212; // Gold
            hat.Attributes.BonusInt = 15;
            hat.Attributes.RegenMana = 3;
            hat.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Inscribe, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Daggers of the Rhine Defenders";
            dagger.Hue = 1640;
            dagger.MinDamage = Utility.Random(18, 35);
            dagger.MaxDamage = Utility.Random(40, 70);
            dagger.Attributes.BonusDex = 20;
            dagger.Attributes.AttackChance = 18;
            dagger.WeaponAttributes.HitLeechHits = 12;
            dagger.WeaponAttributes.HitLightning = 18;
            dagger.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        // Special Scepter
        public class PrincipalityScepter : Scepter
        {
            [Constructable]
            public PrincipalityScepter()
            {
                Name = "Scepter of Sovereignty";
                Hue = 2212;
                Attributes.WeaponSpeed = 20;
                Attributes.SpellDamage = 20;
                Attributes.CastRecovery = 3;
                Attributes.CastSpeed = 2;
                Attributes.Luck = 35;
                WeaponAttributes.HitHarm = 25;
                WeaponAttributes.SelfRepair = 7;
                SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
                XmlAttach.AttachTo(this, new XmlLevelItem());
            }
            public PrincipalityScepter(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
            public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
        }

        public TreasureChestOfLiechtenstein(Serial serial) : base(serial) { }
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

    // Custom Lore Book: Chronicle of the Princes
    public class ChronicleOfThePrinces : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Princes of Liechtenstein", "Johann Adam Andreas & Successors",
            new BookPageInfo
            (
                "In the shadow of the Alps,",
                "on the banks of the Rhine,",
                "lies the Principality of",
                "Liechtenstein. Since 1719,",
                "the House of Liechtenstein",
                "has ruled this tiny land,",
                "forged from the lordships",
                "of Schellenberg and Vaduz."
            ),
            new BookPageInfo
            (
                "The Princes, loyal to the",
                "Holy Roman Empire, sought",
                "a seat in the Imperial Diet.",
                "Their domain, though small,",
                "endured wars, emperors,",
                "and revolutions. Yet their",
                "independence was secured",
                "in the Treaty of Vienna."
            ),
            new BookPageInfo
            (
                "Liechtenstein, untouched",
                "by World Wars, became a",
                "haven of neutrality,",
                "a guardian of tradition,",
                "and a pioneer of finance.",
                "Its people, resilient and",
                "proud, built prosperity",
                "among mountain slopes."
            ),
            new BookPageInfo
            (
                "From Vaduz Castle, the",
                "Princes watched over a",
                "free people, granting a",
                "constitution, a voice,",
                "and a modern age. Yet",
                "the past remains alive",
                "in every stone and",
                "every festival."
            ),
            new BookPageInfo
            (
                "Let this chest remind all",
                "who find it: Greatness",
                "need not come from size.",
                "In the heart of the Alps,",
                "the spirit of a nation",
                "shines bright and true.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May the lineage endure,",
                "may the Rhine run clear,",
                "and may Liechtenstein",
                "forever stand sovereign",
                "and free.",
                "",
                "- Chronicle of the Princes",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfThePrinces() : base(false)
        {
            Hue = 1154; // Royal blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Princes of Liechtenstein");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Princes of Liechtenstein");
        }

        public ChronicleOfThePrinces(Serial serial) : base(serial) { }

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
