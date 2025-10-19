using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheDutchGoldenAge : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheDutchGoldenAge()
        {
            Name = "Treasure Chest of the Dutch Golden Age";
            Hue = 1359; // Deep blue, like Delftware

            // Decorative and thematic items
            AddItem(CreateDecorativeTulipVase(), 0.25);
            AddItem(CreateDutchWindmillStatue(), 0.20);
            AddItem(CreateGoldenGuilderCoin(), 0.20);
            AddItem(CreateDelftwarePlate(), 0.16);
            AddItem(CreateRembrandtPainting(), 0.10);
            AddItem(CreateClogArtifact(), 0.13);
            AddItem(CreateMapOfTheVOC(), 0.05);
            AddItem(CreateDutchCheeseWheel(), 0.18);
            AddItem(CreateDutchPipe(), 0.10);
            AddItem(new ChroniclesOfTheLowlands(), 1.0);

            // Consumables
            AddItem(CreateGeneverBottle(), 0.16);
            AddItem(CreateHerringFeast(), 0.13);
            AddItem(CreateTulipBulb(), 0.11);

            // Equipment: Powerful, unique, and themed
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateGoldenCloak(), 0.15);
            AddItem(CreateWideBrimHat(), 0.13);
            AddItem(CreateMerchantBoots(), 0.14);

            // Treasure
            AddItem(new Gold(Utility.Random(2000, 7000)), 0.17);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Decorative themed items
        private Item CreateDecorativeTulipVase()
        {
            ArtifactVase vase = new ArtifactVase();
            vase.Name = "Vase of Golden Age Tulips";
            vase.Hue = 1153; // Bright tulip color
            return vase;
        }

        private Item CreateDutchWindmillStatue()
        {
            Sculpture1Artifact windmill = new Sculpture1Artifact();
            windmill.Name = "Miniature Dutch Windmill";
            windmill.Hue = 2002; // Wooden color
            return windmill;
        }

        private Item CreateGoldenGuilderCoin()
        {
            Gold guilder = new Gold();
            guilder.Amount = 100;
            guilder.Name = "Golden Guilder Coin";
            guilder.Hue = 2213;
            return guilder;
        }

        private Item CreateDelftwarePlate()
        {
            Plate plate = new Plate();
            plate.Name = "Delftware Plate";
            plate.Hue = 1359; // Delft blue
            return plate;
        }

        private Item CreateRembrandtPainting()
        {
            Painting2WestArtifact painting = new Painting2WestArtifact();
            painting.Name = "Rembrandt’s Portrait";
            painting.Hue = 0;
            return painting;
        }

        private Item CreateClogArtifact()
        {
            Shoes clogs = new Shoes();
            clogs.Name = "Wooden Clogs of Amsterdam";
            clogs.Hue = 2129; // Wood hue
            clogs.Attributes.BonusDex = 7;
            clogs.SkillBonuses.SetValues(0, SkillName.Camping, 12.0);
            return clogs;
        }

        private Item CreateMapOfTheVOC()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the VOC Trade Routes";
            map.Bounds = new Rectangle2D(1200, 1800, 500, 350);
            map.NewPin = new Point2D(1300, 1900);
            map.Protected = true;
            return map;
        }

        private Item CreateDutchCheeseWheel()
        {
            CheeseWheel cheese = new CheeseWheel();
            cheese.Name = "Gouda Cheese Wheel";
            cheese.Hue = 1161;
            return cheese;
        }

        private Item CreateDutchPipe()
        {
            Lute pipe = new Lute();
            pipe.Name = "Dutch Clay Pipe";
            pipe.Hue = 2419;
            return pipe;
        }

        private Item CreateGeneverBottle()
        {
            BottleArtifact genever = new BottleArtifact();
            genever.Name = "Bottle of Genever";
            genever.Hue = 1167;
            return genever;
        }

        private Item CreateHerringFeast()
        {
            WoodenBowlOfStew herring = new WoodenBowlOfStew();
            herring.Name = "Pickled Herring Feast";
            herring.Hue = 2213;
            return herring;
        }

        private Item CreateTulipBulb()
        {
            Garlic tulip = new Garlic();
            tulip.Name = "Rare Tulip Bulb";
            tulip.Hue = 1157;
            return tulip;
        }

        // Equipment
        private Item CreateWeapon()
        {
            // Dutch naval officer’s cutlass
            Cutlass sword = new Cutlass();
            sword.Name = "VOC Captain’s Cutlass";
            sword.Hue = 2101;
            sword.MinDamage = 40;
            sword.MaxDamage = 80;
            sword.WeaponAttributes.HitLightning = 25;
            sword.WeaponAttributes.HitLeechMana = 18;
            sword.WeaponAttributes.HitLowerAttack = 12;
            sword.WeaponAttributes.SelfRepair = 7;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.AttackChance = 20;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            sword.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateArmor()
        {
            // Dutch naval armor, reinforced for storms
            PlateChest chest = new PlateChest();
            chest.Name = "Stormguard Chestplate";
            chest.Hue = 2115;
            chest.BaseArmorRating = 58;
            chest.ArmorAttributes.MageArmor = 1;
            chest.Attributes.RegenHits = 4;
            chest.Attributes.BonusHits = 18;
            chest.ArmorAttributes.LowerStatReq = 25;
            chest.ColdBonus = 8;
            chest.FireBonus = 12;
            chest.PhysicalBonus = 18;
            chest.PoisonBonus = 7;
            chest.EnergyBonus = 10;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 13.0);
            chest.SkillBonuses.SetValues(1, SkillName.Cartography, 10.0); // Custom skill if you have it!
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateGoldenCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Golden Cloak of Amsterdam";
            cloak.Hue = 2213;
            cloak.Attributes.Luck = 55;
            cloak.Attributes.BonusMana = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.ItemID, 15.0); // If you have custom trade skill!
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateWideBrimHat()
        {
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Rembrandt’s Wide Brim Hat";
            hat.Hue = 1109;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.NightSight = 1;
            hat.Attributes.LowerManaCost = 15;
            hat.SkillBonuses.SetValues(0, SkillName.Magery, 12.0); // Custom skill for roleplay
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateMerchantBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Merchant’s Leather Boots";
            boots.Hue = 2112;
            boots.Attributes.BonusDex = 10;
            boots.Attributes.Luck = 20;
            boots.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.ItemID, 10.0); // If you have custom
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        // LORE BOOK
        public class ChroniclesOfTheLowlands : BlueBook
        {
            public static readonly BookContent Content = new BookContent
            (
                "Chronicles of the Lowlands", "Anonymous Dutch Chronicler",
                new BookPageInfo
                (
                    "In the 17th century,",
                    "the Low Countries rose to",
                    "unparalleled heights. A land",
                    "of windmills, dikes, tulips,",
                    "and bustling ports—",
                    "the Dutch Republic flourished.",
                    "Merchants sailed to distant",
                    "Indies, returning with spice,",
                    "silk, and gold."
                ),
                new BookPageInfo
                (
                    "Amsterdam’s canals ran deep",
                    "with the wealth of the world.",
                    "Painters—Rembrandt, Vermeer,",
                    "Frans Hals—captured life,",
                    "light, and shadow. Tulip bulbs",
                    "became as precious as jewels.",
                    "But fortunes could turn as",
                    "quickly as the sea’s tide."
                ),
                new BookPageInfo
                (
                    "Armadas clashed on northern",
                    "waters. Traders outwitted rivals,",
                    "and philosophers pondered",
                    "freedom of thought. Here,",
                    "religious tolerance thrived,",
                    "and art found a golden home.",
                    "Yet the dikes always stood",
                    "between land and sea—",
                    "a reminder of fragility."
                ),
                new BookPageInfo
                (
                    "To possess this chest is to",
                    "hold the dreams of explorers,",
                    "the courage of sailors,",
                    "the wisdom of merchants,",
                    "and the vision of artists.",
                    "May fortune favor those",
                    "who cherish the Lowlands’",
                    "legacy."
                ),
                new BookPageInfo
                (
                    "Heed this warning:",
                    "Not all treasures gleam—",
                    "and not all fortunes last.",
                    "",
                    "For the tides of time",
                    "spare no nation,",
                    "but legends endure.",
                    "",
                    "— End of Chronicle —"
                )
            );

            public override BookContent DefaultContent => Content;

            [Constructable]
            public ChroniclesOfTheLowlands() : base(false)
            {
                Hue = 1359; // Delft blue
            }

            public override void AddNameProperty(ObjectPropertyList list)
            {
                list.Add("Chronicles of the Lowlands");
            }

            public override void OnSingleClick(Mobile from)
            {
                LabelTo(from, "Chronicles of the Lowlands");
            }

            public ChroniclesOfTheLowlands(Serial serial) : base(serial) { }

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

        public TreasureChestOfTheDutchGoldenAge(Serial serial) : base(serial)
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
}
