using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfCoteDIvoire : WoodenChest
    {
        [Constructable]
        public TreasureChestOfCoteDIvoire()
        {
            Name = "Treasure Chest of Côte d'Ivoire";
            Hue = 2413; // Rich gold-brown

            AddItem(CreateDecor("Golden Mask of the Baoulé", typeof(ChangelingStatue), 2129), 0.20);
            AddItem(CreateDecor("Ancient Akan Drum", typeof(AncientDrum), 2732), 0.18);
            AddItem(CreateDecor("Cocoa Pod Artifact", typeof(FruitBasket), 2420), 0.18);
            AddItem(CreateDecor("Ivory Coast Trade Beads", typeof(Necklace), 1153), 0.19);
            AddItem(CreateDecor("Gilded Coffee Chalice", typeof(Goblet), 2424), 0.13);
            AddItem(CreateDecor("Senufo Spirit Statue", typeof(TrollStatuette), 2101), 0.12);
            AddItem(CreateDecor("Baule Wood Carving", typeof(Sculpture1Artifact), 1157), 0.16);
            AddItem(CreateDecor("Yamoussoukro Basilica Miniature", typeof(KingsPainting1), 2314), 0.09);

            AddItem(CreateConsumable("Cocoa of Abidjan", typeof(GreenTea), 0x6A6), 0.13);
            AddItem(CreateConsumable("Baoulé Feast Platter", typeof(MeatPie), 0x8AC), 0.12);
            AddItem(CreateConsumable("Ivory Palm Wine", typeof(RandomDrink), 0x486), 0.13);
            AddItem(CreateConsumable("Jollof Rice Bowl", typeof(WoodenBowlOfStew), 0x8A5), 0.13);

            AddItem(CreateUniqueWeapon(), 0.21);
            AddItem(CreateUniqueArmor(), 0.21);
            AddItem(CreateUniquePants(), 0.16);
            AddItem(CreateUniqueHat(), 0.14);
            AddItem(CreateUniqueShield(), 0.11);
            AddItem(CreateUniqueCloak(), 0.13);
            AddItem(new ChroniclesOfCoteDIvoire(), 1.0);
            AddItem(CreateGoldItem("Colonial Francs"), 0.19);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.18);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecor(string name, Type t, int hue)
        {
            Item decor = Activator.CreateInstance(t) as Item;
            decor.Name = name;
            decor.Hue = hue;
            return decor;
        }

        private Item CreateConsumable(string name, Type t, int hue)
        {
            Item food = Activator.CreateInstance(t) as Item;
            food.Name = name;
            food.Hue = hue;
            return food;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateUniqueWeapon()
        {
            // Akan Royal Sword (Katana with buffs)
            Katana sword = new Katana();
            sword.Name = "Akan Royal Sword";
            sword.Hue = 2125;
            sword.MinDamage = 38;
            sword.MaxDamage = 74;
            sword.WeaponAttributes.HitLightning = 35;
            sword.WeaponAttributes.SelfRepair = 6;
            sword.WeaponAttributes.HitLeechHits = 20;
            sword.WeaponAttributes.HitHarm = 15;
            sword.Attributes.BonusStr = 12;
            sword.Attributes.AttackChance = 15;
            sword.Attributes.BonusHits = 25;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 12.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        private Item CreateUniqueArmor()
        {
            // Baule King's Chest (PlateChest)
            PlateChest armor = new PlateChest();
            armor.Name = "Baule King's Chestplate";
            armor.Hue = 2406;
            armor.BaseArmorRating = 58;
            armor.ArmorAttributes.LowerStatReq = 25;
            armor.AbsorptionAttributes.EaterFire = 15;
            armor.Attributes.BonusHits = 15;
            armor.Attributes.BonusDex = 7;
            armor.SkillBonuses.SetValues(0, SkillName.Healing, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniquePants()
        {
            // Senufo Dancer's Kilt (FancyKilt)
            FancyKilt kilt = new FancyKilt();
            kilt.Name = "Senufo Dancer's Kilt";
            kilt.Hue = 2733;
            kilt.Attributes.Luck = 28;
            kilt.Attributes.BonusMana = 12;
            kilt.SkillBonuses.SetValues(0, SkillName.MagicResist, 8.0);
            kilt.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
            XmlAttach.AttachTo(kilt, new XmlLevelItem());
            return kilt;
        }

        private Item CreateUniqueHat()
        {
            // Ivory Warrior Mask (HornedTribalMask)
            HornedTribalMask mask = new HornedTribalMask();
            mask.Name = "Ivory Warrior Mask";
            mask.Hue = 2411;
            mask.Attributes.BonusStr = 7;
            mask.Attributes.NightSight = 1;
            mask.SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(mask, new XmlLevelItem());
            return mask;
        }

        private Item CreateUniqueShield()
        {
            // Protector of Yamoussoukro (DecorativeShield4)
            OrderShield shield = new OrderShield();
            shield.Name = "Protector of Yamoussoukro";
            shield.Hue = 2308;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusHits = 18;
            shield.Attributes.ReflectPhysical = 15;
            shield.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateUniqueCloak()
        {
            // Forest Cloak of the Guro (Cloak)
            Cloak cloak = new Cloak();
            cloak.Name = "Forest Cloak of the Guro";
            cloak.Hue = 2128;
            cloak.Attributes.BonusStam = 8;
            cloak.Attributes.Luck = 20;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 14.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        public TreasureChestOfCoteDIvoire(Serial serial) : base(serial) { }
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

    public class ChroniclesOfCoteDIvoire : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Côte d'Ivoire", "Griot Kouadio",
            new BookPageInfo
            (
                "From the forests and",
                "savannahs, mighty tribes",
                "arose: Akan, Senufo, Guro,",
                "Baule. Kingdoms of gold,",
                "wisdom, and war, their",
                "stories echo in the drums",
                "and masks of our people."
            ),
            new BookPageInfo
            (
                "Salt and gold flowed",
                "across the land, traded",
                "from north to south.",
                "The Akan kings forged",
                "alliances with wisdom,",
                "and the Baule queen led",
                "her people to new homes."
            ),
            new BookPageInfo
            (
                "The shores called to",
                "strangers. Ships of France",
                "anchored on the Gulf of",
                "Guinea. Treaties became",
                "chains. Our land was",
                "claimed in the name of",
                "distant kings. The Ivorian",
                "spirit endured."
            ),
            new BookPageInfo
            (
                "Cocoa and coffee fields",
                "blossomed. Cities rose:",
                "Abidjan, Yamoussoukro,",
                "Korhogo. In 1960, our",
                "chains broke. Our flag",
                "flew over the proud land",
                "once more. Freedom"
            ),
            new BookPageInfo
            (
                "The drumbeats of the",
                "Griot echo in the night.",
                "Remember the gold,",
                "remember the pain,",
                "remember the music.",
                "We are many tribes,",
                "one Côte d'Ivoire."
            ),
            new BookPageInfo
            (
                "May this chest honor",
                "the ancestors and the",
                "dreamers. May you find",
                "riches and wisdom in its",
                "contents, and may the",
                "spirit of Côte d'Ivoire",
                "walk beside you always.",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfCoteDIvoire() : base(false)
        {
            Hue = 2413; // Deep golden brown
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Côte d'Ivoire");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Côte d'Ivoire");
        }

        public ChroniclesOfCoteDIvoire(Serial serial) : base(serial) { }

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
