using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheSeychellesIsles : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheSeychellesIsles()
        {
            Name = "Treasure Chest of the Seychelles Isles";
            Hue = 1366; // Sea-turquoise

            AddItem(CreateDecorativePearl(), 0.15);
            AddItem(CreateDecorativeCoral(), 0.12);
            AddItem(CreateTropicalDrink(), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of Pirate Kings"), 0.09);
            AddItem(CreateColoredItem<Diamond>("Giant Black Pearl", 1109), 0.10);
            AddItem(CreateColoredItem<Sandals>("Sandals of the Reef Walker", 2106), 0.12);
            AddItem(CreateNamedItem<BodySash>("Sailcloth Sash of the Seychelles"), 0.16);
            AddItem(CreateMapToHiddenCove(), 0.05);
            AddItem(CreateDecorativeShip(), 0.11);
            AddItem(CreatePirateRum(), 0.14);
            AddItem(CreateWeapon(), 0.18);
            AddItem(CreateArmor(), 0.17);
            AddItem(CreateUniqueHat(), 0.13);
            AddItem(CreateLongPants(), 0.14);
            AddItem(CreatePirateDagger(), 0.17);
            AddItem(new SeychellesIslesLoreBook(), 1.0);
            AddItem(new Gold(Utility.Random(2500, 2500)), 0.10);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativePearl()
        {
            Diamond pearl = new Diamond();
            pearl.Name = "Lost Seychelles Moon Pearl";
            pearl.Hue = 1153;
            return pearl;
        }

        private Item CreateDecorativeCoral()
        {
            Coral coral = new Coral();
            coral.Name = "Branch of Luminous Coral";
            coral.Hue = 1365;
            return coral;
        }

        private Item CreateTropicalDrink()
        {
            BeverageBottle drink = new BeverageBottle(BeverageType.Liquor);
            drink.Name = "Coconut Nectar of the Tropics";
            drink.Hue = 1825;
            return drink;
        }

        private Item CreateDecorativeShip()
        {
            AncientShipModelOfTheHMSCape ship = new AncientShipModelOfTheHMSCape();
            ship.Name = "Miniature Ghost Galleon";
            ship.Hue = 1001;
            return ship;
        }

        private Item CreatePirateRum()
        {
            BeverageBottle rum = new BeverageBottle(BeverageType.Liquor);
            rum.Name = "Blackbeard's Seychelles Rum";
            rum.Hue = 1175;
            return rum;
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

        private Item CreateMapToHiddenCove()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Hidden Seychelles Cove";
            map.Bounds = new Rectangle2D(5350, 2300, 300, 350);
            map.NewPin = new Point2D(5400, 2450);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            Cutlass cutlass = new Cutlass();
            cutlass.Name = "Cutlass of the Lost Corsair";
            cutlass.Hue = 1172;
            cutlass.MinDamage = 35;
            cutlass.MaxDamage = 65;
            cutlass.Attributes.Luck = 250;
            cutlass.Attributes.WeaponSpeed = 30;
            cutlass.WeaponAttributes.HitLeechStam = 25;
            cutlass.WeaponAttributes.HitLowerAttack = 15;
            cutlass.WeaponAttributes.SelfRepair = 8;
            cutlass.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            cutlass.SkillBonuses.SetValues(1, SkillName.Snooping, 10.0);
            XmlAttach.AttachTo(cutlass, new XmlLevelItem());
            return cutlass;
        }

        private Item CreateArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Blue Lagoon";
            chest.Hue = 1366;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusHits = 20;
            chest.ArmorAttributes.MageArmor = 1;
            chest.ArmorAttributes.LowerStatReq = 30;
            chest.Attributes.BonusStr = 12;
            chest.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Cartography, 15.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateUniqueHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Hat of the Pirate Admiral";
            hat.Hue = 1157;
            hat.Attributes.Luck = 150;
            hat.Attributes.BonusInt = 8;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Cartography, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Tactics, 20.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateLongPants()
        {
            LongPants pants = new LongPants();
            pants.Name = "Sea-Soaked Sailor’s Pants";
            pants.Hue = 1102;
            pants.Attributes.Luck = 30;
            pants.Attributes.BonusMana = 8;
            pants.SkillBonuses.SetValues(0, SkillName.Fishing, 10.0);
            pants.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(pants, new XmlLevelItem());
            return pants;
        }

        private Item CreatePirateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Coral Dagger of Isle Spirits";
            dagger.Hue = 1355;
            dagger.MinDamage = 20;
            dagger.MaxDamage = 54;
            dagger.Attributes.BonusDex = 10;
            dagger.WeaponAttributes.HitFireball = 10;
            dagger.WeaponAttributes.UseBestSkill = 1;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 15.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfTheSeychellesIsles(Serial serial) : base(serial) { }

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

    public class SeychellesIslesLoreBook : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Legends of the Seychelles Isles", "Captain Renard le Blanc",
            new BookPageInfo
            (
                "In the sapphire heart of the",
                "Indian Ocean lie the",
                "Seychelles Isles. Once a",
                "haven for pirates, mariners,",
                "and dreamers, their coves",
                "and jungles whisper secrets",
                "older than the tides."
            ),
            new BookPageInfo
            (
                "First charted by Arab",
                "seafarers, later claimed by",
                "the French in 1756—when a",
                "granite stone was placed on",
                "Mahé to mark the King's name.",
                "British sails soon followed,",
                "fighting for the archipelago’s",
                "riches and spice-laden winds."
            ),
            new BookPageInfo
            (
                "Pirates hid treasures beneath",
                "palm and breadfruit, trading",
                "rum with the local spirits. The",
                "isles became a sanctuary for",
                "runaway slaves, forgotten gods,",
                "and lost fortunes buried in sand.",
                "A thousand tales, a thousand",
                "storms passed."
            ),
            new BookPageInfo
            (
                "Through the centuries, cultures",
                "entwined—African, French,",
                "British, and Indian—giving birth",
                "to a Creole nation. In 1976, the",
                "Seychelles found her freedom,",
                "an island melody in the song of",
                "nations, forever kissed by sun."
            ),
            new BookPageInfo
            (
                "Now, the isles are legend: a",
                "paradise for wanderers, with",
                "coco de mer palms, rare birds,",
                "and waters as blue as lost",
                "dreams. Yet, below the moonlit",
                "waves, treasure still sleeps,",
                "waiting for the hand of fate."
            ),
            new BookPageInfo
            (
                "Take heed, traveler: not all",
                "riches glitter in the sun. Some",
                "lie deep, among coral and ghost",
                "ships. But those who find this",
                "chest awaken the spirit of the",
                "Seychelles. May luck be your",
                "compass, and legend your guide."
            ),
            new BookPageInfo
            (
                "",
                "- Captain Renard le Blanc",
                "",
                "",
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
        public SeychellesIslesLoreBook() : base(false)
        {
            Hue = 1366; // Turquoise sea
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Legends of the Seychelles Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Legends of the Seychelles Isles");
        }

        public SeychellesIslesLoreBook(Serial serial) : base(serial) { }

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
