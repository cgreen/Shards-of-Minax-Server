using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheBelgianRealms : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheBelgianRealms()
        {
            Name = "Treasure Chest of the Belgian Realms";
            Hue = 1154; // Royal blue, symbolic for Belgium

            // Add unique Belgian themed items to the chest
            AddItem(CreateDecorativeTapestry(), 0.20);
            AddItem(CreateBelgianGoblet(), 0.16);
            AddItem(CreateBelgianChocolate(), 0.22);
            AddItem(CreateWaffleOfRestoration(), 0.15);
            AddItem(CreateElixirOfTrappistWisdom(), 0.12);
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateBelgianCrown(), 0.09);
            AddItem(CreateGhentPlateArmor(), 0.11);
            AddItem(CreateWaterlooBlade(), 0.13);
            AddItem(CreateBrusselsCloak(), 0.15);
            AddItem(CreateFlandersBoots(), 0.13);
            AddItem(CreateTintinCap(), 0.10);
            AddItem(CreateBelgianGoldCoins(), 0.18);
            AddItem(CreateMapToTheBattlefields(), 0.06);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // -- Decorative Item Example --
        private Item CreateDecorativeTapestry()
        {
            Tapestry3N tapestry = new Tapestry3N();
            tapestry.Name = "The Tapestry of Bruges";
            tapestry.Hue = 1358; // rich blue
            return tapestry;
        }

        private Item CreateBelgianGoblet()
        {
            Goblet goblet = new Goblet();
            goblet.Name = "Goblet of Belgian Nobility";
            goblet.Hue = 1289;
            return goblet;
        }

        private Item CreateBelgianChocolate()
        {
            DarkChocolate chocolate = new DarkChocolate();
            chocolate.Name = "Royal Belgian Chocolate";
            chocolate.Hue = 1923;
            return chocolate;
        }

        // -- Unique Consumables --
        private Item CreateWaffleOfRestoration()
        {
            Cake cake = new Cake();
            cake.Name = "Waffle of Restoration";
            cake.Hue = 2213; // golden brown
            cake.LootType = LootType.Blessed;
            return cake;
        }

        private Item CreateElixirOfTrappistWisdom()
        {
            RandomDrink elixir = new RandomDrink();
            elixir.Name = "Elixir of Trappist Wisdom";
            elixir.Hue = 1800; // deep ale color
            return elixir;
        }

        // -- Gold, Coins, and Currency --
        private Item CreateBelgianGoldCoins()
        {
            Gold gold = new Gold(Utility.RandomMinMax(300, 2200));
            gold.Name = "Belgian Ducats";
            return gold;
        }

        // -- Equipment Items --
        private Item CreateBelgianCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Crown of Leopold";
            crown.Hue = 1175; // regal yellow-gold
            crown.Attributes.BonusInt = 8;
            crown.Attributes.BonusHits = 12;
            crown.Attributes.NightSight = 1;
            crown.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            crown.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 7.0);
            XmlAttach.AttachTo(crown, new XmlLevelItem());
            return crown;
        }

        private Item CreateGhentPlateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Plate Armor of Ghent";
            chest.Hue = 2505; // steel-blue
            chest.BaseArmorRating = 58;
            chest.Attributes.BonusStr = 10;
            chest.Attributes.RegenHits = 3;
            chest.Attributes.ReflectPhysical = 12;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 7.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateWaterlooBlade()
        {
            Longsword blade = new Longsword();
            blade.Name = "Blade of Waterloo";
            blade.Hue = 1348; // dark silver
            blade.MinDamage = 38;
            blade.MaxDamage = 74;
            blade.Attributes.BonusDex = 8;
            blade.Attributes.WeaponSpeed = 20;
            blade.WeaponAttributes.HitLeechHits = 20;
            blade.WeaponAttributes.HitLightning = 18;
            blade.WeaponAttributes.SelfRepair = 5;
            blade.Slayer = SlayerName.Repond;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 13.0);
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateBrusselsCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Brussels";
            cloak.Hue = 2301;
            cloak.Attributes.BonusMana = 10;
            cloak.Attributes.LowerRegCost = 18;
            cloak.Attributes.RegenMana = 4;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.EvalInt, 7.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateFlandersBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of Flanders";
            boots.Hue = 2506;
            boots.Attributes.BonusDex = 6;
            boots.Attributes.Luck = 45;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateTintinCap()
        {
            SkullCap cap = new SkullCap();
            cap.Name = "Tintin's Iconic Cap";
            cap.Hue = 2128; // orange
            cap.Attributes.BonusInt = 5;
            cap.Attributes.Luck = 15;
            cap.SkillBonuses.SetValues(0, SkillName.Cartography, 12.0);
            cap.SkillBonuses.SetValues(1, SkillName.DetectHidden, 8.0);
            XmlAttach.AttachTo(cap, new XmlLevelItem());
            return cap;
        }

        // -- Lore Book --
        private Item CreateLoreBook()
        {
            return new ChroniclesOfBelgium();
        }

        // -- Special Map --
        private Item CreateMapToTheBattlefields()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Fields of Waterloo";
            map.Bounds = new Rectangle2D(1500, 1200, 300, 300);
            map.NewPin = new Point2D(1625, 1350);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfTheBelgianRealms(Serial serial) : base(serial)
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

    public class ChroniclesOfBelgium : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Belgium", "Chronicler of Realms",
            new BookPageInfo
            (
                "From the mists of time,",
                "tribes of the Belgae",
                "stood firm by rivers",
                "and hills. The Romans",
                "named this land Gallia",
                "Belgica, its people fierce,",
                "proud, unconquered.",
                ""
            ),
            new BookPageInfo
            (
                "Empires rose and fell.",
                "From Frankish rule to",
                "the days of Charlemagne,",
                "Belgium’s soil knew many",
                "masters, yet its heart",
                "remained wild, steadfast,",
                "divided by tongue but",
                "united in purpose."
            ),
            new BookPageInfo
            (
                "In the middle ages,",
                "the cities of Bruges,",
                "Ghent, and Ypres blossomed,",
                "cloth and art flowing",
                "through their markets.",
                "Dukes and counts forged",
                "alliances, weaving a",
                "tapestry of intrigue."
            ),
            new BookPageInfo
            (
                "Battles raged: the",
                "Golden Spurs, the",
                "siege of Antwerp,",
                "the dawn of new faiths.",
                "Through Spanish yoke,",
                "Austrian reign, and the",
                "rise of Napoleon, Belgium",
                "endured and adapted."
            ),
            new BookPageInfo
            (
                "In 1830, the people",
                "rose and cast off their",
                "chains. A kingdom was",
                "born, free and proud.",
                "Leopold crowned upon the",
                "Lion Throne, a nation",
                "forged of compromise",
                "and courage."
            ),
            new BookPageInfo
            (
                "Through two world wars,",
                "trenches scarred the land,",
                "cities battered, yet never",
                "yielding. Their spirit,",
                "like their waffles and",
                "beer, rich and enduring.",
                "Belgium, crossroads of",
                "Europe, heart of unity."
            ),
            new BookPageInfo
            (
                "Find in these treasures",
                "echoes of Flanders’ fields,",
                "the bells of Bruges,",
                "the wisdom of abbey monks,",
                "the glimmer of gold",
                "in Antwerp’s vaults, the",
                "dreams of Tintin, the",
                "resolve of Waterloo."
            ),
            new BookPageInfo
            (
                "May this chest remind",
                "you: unity can be born",
                "of difference, greatness",
                "from endurance. From",
                "stone and story, Belgium",
                "arose — a land of art,",
                "war, wit, and wonder.",
                "",
                "- Chronicler"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBelgium() : base(false)
        {
            Hue = 1175; // Royal gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Belgium");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Belgium");
        }

        public ChroniclesOfBelgium(Serial serial) : base(serial) { }

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
