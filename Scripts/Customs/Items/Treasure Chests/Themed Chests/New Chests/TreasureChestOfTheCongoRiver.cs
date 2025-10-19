using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheCongoRiver : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheCongoRiver()
        {
            Name = "Treasure Chest of the Congo River";
            Hue = 1420; // Deep jungle green

            // Add items to the chest
            AddItem(CreateArtifactIvoryMask(), 0.13);
            AddItem(CreateDecorativeDrum(), 0.11);
            AddItem(CreateCongoGoldIngot(), 0.15);
            AddItem(CreateSpiritPotion(), 0.17);
            AddItem(CreateLumumbaBlade(), 0.08); // Unique weapon
            AddItem(CreateKubaRoyalRobe(), 0.12); // Unique clothing
            AddItem(CreateCopperBraceletOfTheBakongo(), 0.15);
            AddItem(CreateRiverMap(), 0.09);
            AddItem(new ChroniclesOfTheHeartOfAfrica(), 1.0);
            AddItem(CreateMagicalCongoShield(), 0.10); // Unique armor
            AddItem(CreateJungleBoots(), 0.17);
            AddItem(CreateTotemOfNzambi(), 0.12); // Decorative, lore
            AddItem(CreateKatangaSpear(), 0.10);
            AddItem(CreateHealingHerbBundle(), 0.15);
            AddItem(CreateRareCongoFruitBasket(), 0.12);
            AddItem(CreateUniqueDrink("Congo Palm Wine"), 0.16);
            AddItem(CreateCongoCoin(), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // --- Custom Items Section ---

        private Item CreateArtifactIvoryMask()
        {
            TribalMask mask = new TribalMask();
            mask.Name = "Ivory Mask of the Bakongo";
            mask.Hue = 1153; // Bone white
            mask.Attributes.BonusInt = 10;
            mask.Attributes.BonusMana = 5;
            mask.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
            mask.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateDecorativeDrum()
        {
            Drums drum = new Drums();
            drum.Name = "Ngoma Drum of Spirits";
            drum.Hue = 2101;
            return drum;
        }

        private Item CreateCongoGoldIngot()
        {
            GoldIngot gold = new GoldIngot();
            gold.Name = "Congo Gold Ingot";
            gold.Hue = 1447;
            gold.Amount = Utility.RandomMinMax(1, 10);
            return gold;
        }

        private Item CreateSpiritPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Elixir of Ancestral Spirits";
            potion.Hue = 1170; // Mystic blue
            return potion;
        }

        private Item CreateLumumbaBlade()
        {
            Longsword blade = new Longsword();
            blade.Name = "Lumumba’s Freedom Blade";
            blade.Hue = 2945; // Royal blue
            blade.MinDamage = 35;
            blade.MaxDamage = 70;
            blade.Attributes.WeaponDamage = 40;
            blade.Attributes.SpellChanneling = 1;
            blade.Attributes.BonusStr = 10;
            blade.WeaponAttributes.HitLeechHits = 25;
            blade.WeaponAttributes.HitLowerAttack = 20;
            blade.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            blade.Slayer = SlayerName.ReptilianDeath;
            XmlAttach.AttachTo(blade, new XmlLevelItem());
            return blade;
        }

        private Item CreateKubaRoyalRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Kuba Royal Robe";
            robe.Hue = 2420; // Earthy brown with gold
            robe.Attributes.Luck = 50;
            robe.Attributes.BonusHits = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            robe.Resistances.Physical = 10;
            robe.Resistances.Fire = 5;
            robe.Resistances.Cold = 5;
            robe.Resistances.Poison = 10;
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateCopperBraceletOfTheBakongo()
        {
            GoldBracelet bracelet = new GoldBracelet();
            bracelet.Name = "Copper Bracelet of the Bakongo";
            bracelet.Hue = 242; // Copper
            bracelet.Attributes.BonusDex = 7;
            bracelet.SkillBonuses.SetValues(0, SkillName.Healing, 12.0);
            XmlAttach.AttachTo(bracelet, new XmlLevelItem());
            return bracelet;
        }

        private Item CreateRiverMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Congo River";
            map.Bounds = new Rectangle2D(1000, 1600, 600, 600);
            map.NewPin = new Point2D(1300, 1900);
            map.Protected = true;
            return map;
        }

        private Item CreateMagicalCongoShield()
        {
            OrderShield shield = new OrderShield();
            shield.Name = "Totemic Shield of Nzambi";
            shield.Hue = 1164; // Vibrant green
            shield.Attributes.DefendChance = 20;
            shield.Attributes.BonusStam = 10;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            shield.ArmorAttributes.LowerStatReq = 20;
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateJungleBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Jungle Pathfinder Boots";
            boots.Hue = 2207; // Dark brown/green
            boots.Attributes.BonusDex = 10;
            boots.Attributes.RegenStam = 3;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateTotemOfNzambi()
        {
            StatueSouth totem = new StatueSouth();
            totem.Name = "Totem of Nzambi Mpungu";
            totem.Hue = 1109; // Ebony
            // Purely decorative, but could tie to a custom quest!
            return totem;
        }

        private Item CreateKatangaSpear()
        {
            Spear spear = new Spear();
            spear.Name = "Katanga Miner’s Spear";
            spear.Hue = 1108; // Metallic gray
            spear.MinDamage = 28;
            spear.MaxDamage = 56;
            spear.Attributes.WeaponSpeed = 30;
            spear.Attributes.BonusStam = 7;
            spear.WeaponAttributes.HitPoisonArea = 15;
            spear.SkillBonuses.SetValues(0, SkillName.Fencing, 13.0);
            XmlAttach.AttachTo(spear, new XmlLevelItem());
            return spear;
        }

        private Item CreateHealingHerbBundle()
        {
            Bag herbs = new Bag();
            herbs.Name = "Bundle of Jungle Healing Herbs";
            herbs.Hue = 1415;
            herbs.DropItem(new GreaterCurePotion());
            herbs.DropItem(new GreaterHealPotion());
            herbs.DropItem(new GreaterStrengthPotion());
            return herbs;
        }

        private Item CreateRareCongoFruitBasket()
        {
            FruitBasket basket = new FruitBasket();
            basket.Name = "Basket of Rare Congo Fruits";
            basket.Hue = 1411; // Lush green
            return basket;
        }

        private Item CreateUniqueDrink(string name)
        {
            BottleArtifact bottle = new BottleArtifact();
            bottle.Name = name;
            bottle.Hue = 2425; // Pale yellow (palm wine)
            return bottle;
        }

        private Item CreateCongoCoin()
        {
            Gold gold = new Gold();
            gold.Name = "Congo Franc Coin";
            gold.Amount = Utility.RandomMinMax(1000, 3500);
            return gold;
        }

        // --- Lore Book ---

        public class ChroniclesOfTheHeartOfAfrica : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of the Heart of Africa", "An Anonymous Traveler",
                new BookPageInfo
                (
                    "The Congo River winds like a",
                    "living serpent through the",
                    "heart of Africa, dividing",
                    "realms and lives. Its",
                    "waters nourish ancient rain-",
                    "forests, shelter rare beasts,",
                    "and guard secrets lost to time."
                ),
                new BookPageInfo
                (
                    "The people who call these",
                    "lands home are children of",
                    "kings and spirits. Bakongo",
                    "chiefs once ruled with ivory",
                    "staffs; Kuba artisans wove",
                    "royal robes from raffia; the",
                    "river gave, and the river took."
                ),
                new BookPageInfo
                (
                    "The world's greed soon turned",
                    "to these shores. First came",
                    "traders, then slavers, then",
                    "soldiers. The land bled copper,",
                    "rubber, and gold, while ghosts",
                    "whispered to those who would",
                    "listen—freedom, always."
                ),
                new BookPageInfo
                (
                    "Patrice Lumumba, voice of hope,",
                    "rose from Leopoldville’s dust.",
                    "His words, sharp as blades,",
                    "cut chains forged by empires.",
                    "Yet darkness lingered: intrigue,",
                    "violence, the sorrow of lost",
                    "leaders."
                ),
                new BookPageInfo
                (
                    "Still, the Congo survives.",
                    "Forests regrow. Rivers endure.",
                    "Its people dance, drum, and",
                    "dream, as they always have.",
                    "Here, past and future blend.",
                    "The heart of Africa beats",
                    "eternal, deep and strong."
                ),
                new BookPageInfo
                (
                    "To the seeker who opens this",
                    "chest: These relics are not",
                    "only treasure, but memory.",
                    "Honor what you find, for the",
                    "river watches, and the jungle",
                    "remembers all."
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfTheHeartOfAfrica() : base(false)
            {
                Hue = 1415; // Deep forest green
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of the Heart of Africa");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of the Heart of Africa");
            }

            public ChroniclesOfTheHeartOfAfrica(Serial serial) : base(serial) { }

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

        public TreasureChestOfTheCongoRiver(Serial serial) : base(serial) { }

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
}
