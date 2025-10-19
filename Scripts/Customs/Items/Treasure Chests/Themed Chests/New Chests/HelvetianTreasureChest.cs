using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class HelvetianTreasureChest : WoodenChest
    {
        [Constructable]
        public HelvetianTreasureChest()
        {
            Name = "Helvetian Treasure Chest (Vault of the Alps)";
            Hue = 1153; // Swiss red

            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem("William Tell's Apple", typeof(Apple), 1154), 0.20);
            AddItem(CreateDecorativeItem("Alpine Horn", typeof(RandomFancyInstrument), 0), 0.15);
            AddItem(CreateDecorativeItem("Swiss Confederation Banner", typeof(OrderBanner), 1153), 0.17);
            AddItem(CreateDecorativeItem("Helvetian Shield", typeof(DecorativeShield4), 1153), 0.20);
            AddItem(CreateDecorativeItem("Banker's Gilded Watch", typeof(WristWatch), 1281), 0.13);
            AddItem(CreateDecorativeItem("Edelweiss Flowers", typeof(DecoFlower), 1150), 0.14);
            AddItem(CreateDecorativeItem("St. Bernard Rescue Barrel", typeof(SmallBrownBottle), 241), 0.13);
            AddItem(CreateDecorativeItem("Snowy Alpine Rock", typeof(ZenRock1Artifact), 1152), 0.10);
            AddItem(CreateDecorativeItem("Treasure of the Rhine Falls", typeof(Diamond), 1152), 0.12);

            AddItem(CreateConsumable("Wheel of Swiss Cheese", typeof(CheeseWheel), 51), 0.20);
            AddItem(CreateConsumable("Box of Swiss Chocolate", typeof(WhiteChocolate), 2413), 0.20);
            AddItem(CreateConsumable("Bottle of Mountain Wine", typeof(BottleOfWine), 1161), 0.14);
            AddItem(CreateConsumable("Alpine Herb Elixir", typeof(GreenTea), 1415), 0.18);

            AddItem(CreateUniqueArmor(), 0.19);
            AddItem(CreateUniqueWeapon(), 0.19);
            AddItem(CreateUniqueClothing(), 0.17);
            AddItem(CreateUniqueCloak(), 0.15);

            AddItem(CreateGoldItem("Helvetian Francs"), 0.20);
            AddItem(new Gold(Utility.Random(1500, 5000)), 0.25);

            // Rare legendary item
            AddItem(CreateLegendaryCrossbow(), 0.04);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem(string name, Type type, int hue)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateConsumable(string name, Type type, int hue)
        {
            Item item = (Item)Activator.CreateInstance(type);
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            item.Movable = true;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold(Utility.Random(500, 1200));
            gold.Name = name;
            return gold;
        }

        private Item CreateUniqueArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Armor of the Swiss Guard";
            armor.Hue = 1153; // Swiss red
            armor.Attributes.BonusHits = 25;
            armor.Attributes.RegenHits = 5;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.Luck = 100;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 15.0);
            armor.ColdBonus = 15;
            armor.FireBonus = 10;
            armor.PhysicalBonus = 20;
            armor.PoisonBonus = 10;
            armor.EnergyBonus = 10;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueWeapon()
        {
            Halberd halberd = new Halberd();
            halberd.Name = "Halberd of the Founding Cantons";
            halberd.Hue = 1150; // White
            halberd.MinDamage = 30;
            halberd.MaxDamage = 65;
            halberd.Attributes.WeaponDamage = 40;
            halberd.Attributes.BonusDex = 12;
            halberd.Attributes.AttackChance = 12;
            halberd.WeaponAttributes.HitColdArea = 25;
            halberd.WeaponAttributes.HitLightning = 20;
            halberd.SkillBonuses.SetValues(0, SkillName.Tactics, 20.0);
            halberd.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            halberd.Slayer = SlayerName.Repond;
            XmlAttach.AttachTo(halberd, new XmlLevelItem());
            return halberd;
        }

        private Item CreateUniqueClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Alpine Druid";
            robe.Hue = 1266; // Icy blue
            robe.Attributes.BonusMana = 20;
            robe.Attributes.CastRecovery = 3;
            robe.Attributes.CastSpeed = 2;
            robe.Attributes.LowerManaCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateUniqueCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Helvetia";
            cloak.Hue = 1150; // White
            cloak.Attributes.NightSight = 1;
            cloak.Attributes.BonusInt = 10;
            cloak.Attributes.SpellDamage = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Focus, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateLegendaryCrossbow()
        {
            HeavyCrossbow xbow = new HeavyCrossbow();
            xbow.Name = "William Tell's Legendary Crossbow";
            xbow.Hue = 1177; // Gilded/legendary
            xbow.MinDamage = 50;
            xbow.MaxDamage = 85;
            xbow.Attributes.WeaponSpeed = 30;
            xbow.Attributes.WeaponDamage = 50;
            xbow.Attributes.Luck = 250;
            xbow.WeaponAttributes.HitLightning = 40;
            xbow.WeaponAttributes.HitLowerAttack = 30;
            xbow.WeaponAttributes.HitLeechStam = 20;
            xbow.SkillBonuses.SetValues(0, SkillName.Archery, 25.0);
            xbow.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            xbow.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(xbow, new XmlLevelItem());
            return xbow;
        }

        private Item CreateLoreBook()
        {
            return new ChroniclesOfTheSwissConfederation();
        }

        public HelvetianTreasureChest(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheSwissConfederation : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Swiss Confederation",
            "Archivist of Helvetia",
            new BookPageInfo
            (
                "In the mists of ancient",
                "Alpine valleys, the Helvetii",
                "tribes made their stand.",
                "Here the Romans marched,",
                "and legends began. The",
                "Alps are guardians, as old",
                "as time, silent as the",
                "snow they wear each winter."
            ),
            new BookPageInfo
            (
                "Three cantons—Uri, Schwyz,",
                "and Unterwalden—rose against",
                "the Habsburg yoke in 1291.",
                "Upon the Rütli Meadow, a",
                "pact of eternal brotherhood",
                "was sworn. From this union",
                "the Swiss Confederation was",
                "forged in the fires of freedom."
            ),
            new BookPageInfo
            (
                "In the shadow of the Alps,",
                "William Tell’s arrow flew.",
                "The apple split, the tyrant",
                "fell, and the spirit of",
                "resistance became legend.",
                "With halberd and crossbow,",
                "the Swiss faced emperors",
                "and emerged unbowed."
            ),
            new BookPageInfo
            (
                "Through centuries, the",
                "Confederation grew—cantons",
                "banded together, their bonds",
                "as strong as mountain stone.",
                "Swiss Guards, famed in Rome,",
                "stood loyal; their armor",
                "bright as the dawn above",
                "Lake Geneva."
            ),
            new BookPageInfo
            (
                "Time flowed on; peace became",
                "their shield. In the storms",
                "of Europe, Switzerland",
                "stood neutral, yet vigilant.",
                "Bankers guarded gold,",
                "craftsmen honed watches,",
                "and farmers tended flocks",
                "upon emerald pastures."
            ),
            new BookPageInfo
            (
                "From the Rhine Falls to the",
                "peaks of the Matterhorn,",
                "from Zurich’s markets to",
                "the meadows of Appenzell,",
                "the Helvetian heart beat",
                "steady and strong. All",
                "who come in peace are",
                "welcome in these valleys."
            ),
            new BookPageInfo
            (
                "This chest, the Vault of the",
                "Alps, holds treasures from",
                "every age: the coin of",
                "bankers, the apple of Tell,",
                "armor of guards, wisdom of",
                "the druids, chocolate, wine,",
                "and the indomitable will",
                "of free folk."
            ),
            new BookPageInfo
            (
                "So heed these chronicles,",
                "traveler! The Swiss story",
                "is written in snow, blood,",
                "and brotherhood. Treasure",
                "well the legacy of Helvetia—",
                "for it is not gold, but",
                "freedom, that endures.",
                "",
                "- Archivist of Helvetia"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheSwissConfederation() : base(false)
        {
            Hue = 1153; // Swiss red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Swiss Confederation");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Swiss Confederation");
        }

        public ChroniclesOfTheSwissConfederation(Serial serial) : base(serial) { }

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
