using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBahamianLegends : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBahamianLegends()
        {
            Name = "Treasure Chest of Bahamian Legends";
            Hue = 1367; // Vibrant turquoise-blue

            // Add items to the chest
            AddItem(CreateNamedItem<PirateHat>("Blackbeard's Plumed Hat", 1153), 0.15);
            AddItem(CreateNamedItem<ConchShell>("Queen Conch Shell of Luck", 1266), 0.20);
            AddItem(CreateColoredItem<Necklace>("Necklace of Pink Sand", 1215), 0.13);
            AddItem(CreateDecorItem<GoldBricks>("Spanish Doubloons", 1447), 0.18);
            AddItem(CreateRumBottle(), 0.16);
            AddItem(CreateTropicalFruit(), 0.18);
            AddItem(CreateDecorItem<BlueCrystal>("Sea Glass Crystal", 92), 0.21);
            AddItem(CreateNamedItem<Cloak>("Cape of the Lucayan Shaman", 1166), 0.12);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateLegendaryFishingPole(), 0.11);
            AddItem(new BookOfBahamianLegends(), 1.0);
            AddItem(CreateDecorItem<TreasureMap>("Pirate Treasure Map", 1272), 0.09);
            AddItem(CreateNamedItem<Sandals>("Pirate King's Sandals", 1109), 0.16);
            AddItem(CreateConsumable<CookieMix>("Sea Biscuit", 0), 0.15);
            AddItem(CreateConsumable<BowlOfRotwormStew>("Conch Chowder", 0), 0.14);
            AddItem(CreateNamedItem<GoldRing>("Ring of Andros Isle", 1365), 0.12);
            AddItem(CreateDecorItem<Gold>("Bahamian Gold Coin", 1447), 0.16);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // Helper methods for themed items
        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            return item;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateDecorItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue != 0)
                item.Hue = hue;
            item.Movable = true;
            return item;
        }

        private Item CreateRumBottle()
        {
            BottleArtifact rum = new BottleArtifact();
            rum.Name = "Pirate's Aged Rum";
            rum.Hue = 54;
            return rum;
        }

        private Item CreateTropicalFruit()
        {
            Banana banana = new Banana();
            banana.Name = "Andros Golden Banana";
            banana.Hue = 2212;
            return banana;
        }

        private Item CreateLegendaryFishingPole()
        {
            FishingPole pole = new FishingPole();
            pole.Name = "Legendary Bahamian Fishing Pole";
            pole.Hue = 1175;
            pole.Attributes.Luck = 75;
            pole.SkillBonuses.SetValues(0, SkillName.Fishing, 20.0);
            pole.Attributes.BonusStam = 10;
            pole.Attributes.BonusHits = 10;
            XmlAttach.AttachTo(pole, new XmlLevelItem());
            return pole;
        }

        private Item CreateWeapon()
        {
            Cutlass weapon = new Cutlass();
            weapon.Name = "Sword of Nassau";
            weapon.Hue = 1367; // turquoise
            weapon.MinDamage = Utility.Random(20, 30);
            weapon.MaxDamage = Utility.Random(40, 55);
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.SelfRepair = 7;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.AttackChance = 8;
            weapon.Attributes.ReflectPhysical = 10;
            weapon.Slayer = SlayerName.Repond;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            LeatherChest armor = new LeatherChest();
            armor.Name = "Coral Plated Pirate Armor";
            armor.Hue = 1266;
            armor.BaseArmorRating = Utility.Random(30, 45);
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ColdBonus = 10;
            armor.EnergyBonus = 7;
            armor.FireBonus = 6;
            armor.PhysicalBonus = 12;
            armor.PoisonBonus = 7;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.Luck = 30;
            armor.SkillBonuses.SetValues(0, SkillName.Stealing, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Fishing, 15.0); // Custom skill? Swap for something else if not available.
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateConsumable<T>(string name, int hue = 0) where T : Item, new()
        {
            T food = new T();
            food.Name = name;
            if (hue != 0)
                food.Hue = hue;
            return food;
        }

        public TreasureChestOfBahamianLegends(Serial serial) : base(serial) { }

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

    public class BookOfBahamianLegends : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Book of Bahamian Legends", "Captain Isla Sands",
            new BookPageInfo
            (
                "In the crystal waters,",
                "where the sun kisses",
                "the sea, the islands of",
                "the Bahamas rise—a",
                "land of ancient spirits,",
                "hidden gold, and",
                "fearless souls."
            ),
            new BookPageInfo
            (
                "Long before the",
                "sails of Spain or the",
                "flags of Britain, the",
                "Lucayan people lived,",
                "gathering conch and",
                "singing to the moon."
            ),
            new BookPageInfo
            (
                "Spanish galleons fell",
                "to reefs. Their gold",
                "lost to sand and coral.",
                "Pirates roamed Nassau,",
                "led by Blackbeard, Anne",
                "Bonny, and Calico Jack.",
                "Taverns echoed with tales",
                "of glory and betrayal."
            ),
            new BookPageInfo
            (
                "British redcoats came,",
                "seeking order. Pirates",
                "became legends. The",
                "Queen's men built forts,",
                "but magic still danced",
                "on the waves, and secrets",
                "remained buried."
            ),
            new BookPageInfo
            (
                "The spirit of the sea",
                "guards the treasures.",
                "Beware the currents of",
                "Andros, the mists of",
                "Abaco, and the",
                "whispers of the Blue",
                "Hole, where the past",
                "never sleeps."
            ),
            new BookPageInfo
            (
                "Modern Nassau bustles,",
                "but listen—night winds",
                "still carry stories of",
                "the Lucayan kings,",
                "hidden rum, lost pearls,",
                "and dreams beneath the",
                "Caribbean stars."
            ),
            new BookPageInfo
            (
                "If you hold this chest,",
                "you are now part of",
                "the legend. Let the",
                "luck of the islands",
                "guide you, and may the",
                "tide always bring you",
                "home.",
                "",
                "- Captain Isla Sands"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfBahamianLegends() : base(false)
        {
            Hue = 1367; // Bahamas blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Book of Bahamian Legends");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Book of Bahamian Legends");
        }

        public BookOfBahamianLegends(Serial serial) : base(serial) { }

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

    // --- Add helper class for custom items if needed ---
    public class ConchShell : Item
    {
        [Constructable]
        public ConchShell() : base(Utility.RandomList(0xFC7, 0xFC8)) // Using random shell graphic
        {
            Weight = 1.0;
        }
        public ConchShell(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }

    public class PirateHat : FeatheredHat
    {
        [Constructable]
        public PirateHat() : base()
        {
        }
        public PirateHat(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }

    public class BlueCrystal : Item
    {
        [Constructable]
        public BlueCrystal() : base(0x1F19)
        {
            Weight = 1.0;
            Hue = 92;
        }
        public BlueCrystal(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
