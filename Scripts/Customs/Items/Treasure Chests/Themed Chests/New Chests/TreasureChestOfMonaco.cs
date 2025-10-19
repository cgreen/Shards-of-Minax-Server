using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMonaco : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMonaco()
        {
            Name = "Treasure Chest of Monaco";
            Hue = 1153; // Rich blue, evocative of the Mediterranean

            // Add themed items to the chest
            AddItem(CreateDecorativeItem<GoldBricks>("Monaco Gold Bullion", 1175), 0.30);
            AddItem(CreateDecorativeItem<ArtifactVase>("Vase of Grace Kelly", 1254), 0.18);
            AddItem(CreateDecorativeItem<MedusaStatue>("Statue of Prince Rainier", 0), 0.14);
            AddItem(CreateDecorativeItem<LargePainting>("Portrait of the Grimaldi Dynasty", 1281), 0.14);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Monte Carlo Sculpture", 1368), 0.16);
            AddItem(CreateDecorativeItem<CandelabraOfSouls>("Casino de Monte-Carlo Candelabra", 1267), 0.13);
            AddItem(CreateDecorativeItem<GrandmasSpecialRolls>("Royal Pastries", 1166), 0.18);
            AddItem(CreateDecorativeItem<BlueBeaker>("Oceanic Perfume", 1169), 0.14);
            AddItem(CreateDecorativeItem<CrabBushel>("Monaco's Fresh Seafood", 1160), 0.12);
            AddItem(CreateDecorativeItem<Bottle>("Rare Monte Carlo Wine", 1167), 0.13);

            // Powerful Equipment
            AddItem(CreateNobleCloak(), 0.22);
            AddItem(CreateGrandPrixBoots(), 0.20);
            AddItem(CreateMonteCarloRing(), 0.18);
            AddItem(CreateGrimaldiSword(), 0.16);
            AddItem(CreateArmor("Guard of the Rock", new PlateChest(), 1, 1389), 0.13);

            // Consumables
            AddItem(CreateDecorativeItem<CheeseWedge>("Exquisite Monegasque Cheese", 1150), 0.19);
            AddItem(CreateDecorativeItem<Bottle>("Rare Bottle of Champagne", 1153), 0.16);
            AddItem(CreateDecorativeItem<RandomFancyCoin>("Commemorative Monaco Franc", 1161), 0.21);

            // The lore book
            AddItem(new ChronicleOfMonaco(), 1.0);

            // Gold for the casino vibe
            AddItem(new Gold(Utility.Random(3000, 5000)), 0.32);

            // Monaco Map
            AddItem(CreateMonacoMap(), 0.09);
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

        private Item CreateArmor(string name, BaseArmor armor, int bonus, int hue)
        {
            armor.Name = name;
            armor.Hue = hue;
            armor.Attributes.BonusHits = 30 + Utility.Random(15);
            armor.Attributes.LowerManaCost = 10 + Utility.Random(10);
            armor.ArmorAttributes.LowerStatReq = 30;
            armor.Attributes.RegenHits = 5;
            armor.Attributes.NightSight = 1;
            armor.Attributes.Luck = 250;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        // Unique wearable: Noble Cloak of Monaco
        private Item CreateNobleCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Noble Cloak of Monaco";
            cloak.Hue = 1281; // Royal blue
            cloak.Attributes.BonusInt = 10;
            cloak.Attributes.RegenMana = 8;
            cloak.Attributes.BonusMana = 25;
            cloak.Attributes.LowerRegCost = 20;
            cloak.Attributes.Luck = 175;
            cloak.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // Unique boots: Grand Prix Racing Boots
        private Item CreateGrandPrixBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Grand Prix Racing Boots";
            boots.Hue = 1154; // Monaco red
            boots.Attributes.BonusDex = 15;
            boots.Attributes.BonusStam = 25;
            boots.Attributes.RegenStam = 7;
            boots.Attributes.Luck = 150;
            boots.SkillBonuses.SetValues(0, SkillName.Chivalry, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        // Unique ring: Monte Carlo Ring of Luck
        private Item CreateMonteCarloRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Monte Carlo Ring of Luck";
            ring.Hue = 1167; // Gold
            ring.Attributes.Luck = 1000;
            ring.Attributes.BonusHits = 15;
            ring.Attributes.BonusStr = 8;
            ring.Attributes.CastRecovery = 3;
            ring.Attributes.CastSpeed = 2;
            ring.Attributes.SpellDamage = 7;
            ring.SkillBonuses.SetValues(0, SkillName.Magery, 25.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        // Unique weapon: Grimaldi Sword
        private Item CreateGrimaldiSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Grimaldi Sword";
            sword.Hue = 1150; // Silvered blue
            sword.MinDamage = 35;
            sword.MaxDamage = 65;
            sword.Attributes.WeaponSpeed = 25;
            sword.Attributes.WeaponDamage = 40;
            sword.Attributes.BonusStr = 10;
            sword.WeaponAttributes.HitLightning = 35;
            sword.WeaponAttributes.SelfRepair = 5;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Custom Monaco Map
        private Item CreateMonacoMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of Monaco";
            map.Bounds = new Rectangle2D(2600, 3400, 150, 80); // Arbitrary coordinates
            map.NewPin = new Point2D(2650, 3440);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfMonaco(Serial serial) : base(serial) { }

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

    // Monaco History Book
    public class ChronicleOfMonaco : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Monaco", "House of Grimaldi",
            new BookPageInfo
            (
                "Welcome to Monaco,",
                "the storied Rock on the",
                "shores of the blue",
                "Mediterranean. Founded",
                "by ancient Greeks,",
                "seized by Romans, and",
                "in 1297, captured by",
                "François Grimaldi."
            ),
            new BookPageInfo
            (
                "The Grimaldi family",
                "has ruled Monaco for",
                "over 700 years.",
                "Through intrigue and",
                "diplomacy, they held",
                "their city-state against",
                "great powers.",
                ""
            ),
            new BookPageInfo
            (
                "Monaco thrived on",
                "its harbors, and later,",
                "on the allure of its",
                "casino, opened in 1863.",
                "Monte Carlo soon",
                "became a byword for",
                "luxury and fortune.",
                ""
            ),
            new BookPageInfo
            (
                "In the 20th century,",
                "the world watched as",
                "Prince Rainier III wed",
                "Grace Kelly, and",
                "the principality became",
                "a glamorous haven",
                "for the rich and",
                "famous."
            ),
            new BookPageInfo
            (
                "Monaco's narrow",
                "streets roar each year",
                "with the Grand Prix.",
                "Yachts crowd the",
                "harbor. Its palace and",
                "gardens gaze over the",
                "sea, guarding a proud",
                "tradition."
            ),
            new BookPageInfo
            (
                "Though small in size,",
                "Monaco stands tall in",
                "history and prestige.",
                "The story of its people",
                "and princes continues—",
                "a legacy as enduring",
                "as the Rock itself.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Beware, adventurer.",
                "Monaco's treasures are",
                "for those with both",
                "luck and wit. Fortune",
                "favors the bold—",
                "and the House of",
                "Grimaldi never forgets.",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfMonaco() : base(false)
        {
            Hue = 1153; // Mediterranean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Monaco");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Monaco");
        }

        public ChronicleOfMonaco(Serial serial) : base(serial) { }

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
