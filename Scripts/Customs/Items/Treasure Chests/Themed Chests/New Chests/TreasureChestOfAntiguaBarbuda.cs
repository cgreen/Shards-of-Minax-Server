using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAntiguaBarbuda : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAntiguaBarbuda()
        {
            Name = "Treasure Chest of Antigua and Barbuda";
            Hue = 1366; // Caribbean blue

            // Decorative and themed items
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Arawak Painted Vessel", 1277), 0.20);
            AddItem(CreateDecorativeItem<Sculpture1Artifact>("Carved Sugar Mill Miniature", 1157), 0.15);
            AddItem(CreateDecorativeItem<SeaChart>("Navigator's Map of the Leeward Islands", 95), 0.16);
            AddItem(CreateDecorativeItem<GoldBricks>("Spanish Doubloon Hoard", 1174), 0.10);
            AddItem(CreateDecorativeItem<CrystalBallStatuette>("Crystal of the Coral Coast", 1366), 0.11);
            AddItem(CreateDecorativeItem<Sextant>("Buccaneer's Brass Sextant", 1166), 0.13);
            AddItem(CreateDecorativeItem<WindChimes>("Trade Wind Chimes", 1282), 0.13);
            AddItem(CreateDecorativeItem<TricorneHat>("Lost Pirate’s Tricorne", 1169), 0.12);

            // Consumables (Caribbean specialties)
            AddItem(CreateConsumable<RandomDrink>("Black Pineapple Wine", 2115), 0.15);
            AddItem(CreateConsumable<RandomDrink>("Barbuda Spiced Rum", 2101), 0.16);
            AddItem(CreateConsumable<PulledPorkPlatter>("Caribbean Jerk Platter", 1258), 0.12);
            AddItem(CreateConsumable<FruitBasket>("Tropical Fruit Basket", 2127), 0.13);

            // Unique equipment (with custom mods and skills)
            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.21);
            AddItem(CreateBoots(), 0.20);
            AddItem(CreateHat(), 0.18);

            // Lore book
            AddItem(new ChroniclesOfTheTwinIslands(), 1.0);

            // A little gold, always
            AddItem(new Gold(Utility.Random(1, 3500)), 0.19);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Cutlass(), new Scimitar(), new Longsword(), new Bow()
            );
            weapon.Name = "Corsair's Legacy";
            weapon.Hue = Utility.RandomList(95, 1366, 1164);
            weapon.MaxDamage = Utility.Random(38, 77);
            weapon.MinDamage = Utility.Random(18, 38);
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.WeaponAttributes.HitLightning = 25;
            weapon.WeaponAttributes.HitHarm = 18;
            weapon.Slayer = SlayerName.Repond;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            weapon.SkillBonuses.SetValues(2, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new RingmailChest()
            );
            armor.Name = "Redcoat's Colonial Plate";
            armor.Hue = Utility.RandomList(1157, 1153, 1154, 2117); // Rich reds and golds
            armor.BaseArmorRating = Utility.Random(32, 61);
            armor.Attributes.Luck = 55;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStr = 8;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.PhysicalBonus = 18;
            armor.FireBonus = 10;
            armor.EnergyBonus = 12;
            armor.ColdBonus = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Macing, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Buccaneer's Stormwalkers";
            boots.Hue = 1282;
            boots.Attributes.BonusDex = 18;
            boots.Attributes.NightSight = 1;
            boots.Attributes.Luck = 33;
            boots.Attributes.BonusStam = 12;
            boots.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Antiguan Mariner's Hat";
            hat.Hue = 95;
            hat.Attributes.BonusInt = 12;
            hat.Attributes.RegenMana = 2;
            hat.SkillBonuses.SetValues(0, SkillName.Musicianship, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Cartography, 18.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        public TreasureChestOfAntiguaBarbuda(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheTwinIslands : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Twin Islands", "Islander Scribe",
            new BookPageInfo
            (
                "Long before sails broke the",
                "horizon, these islands were",
                "home to the Arawak, gentle",
                "people of sun and sea. Their",
                "villages thrived beneath the",
                "banyan’s shade, living from",
                "the reef, the forest, the",
                "ever-giving land."
            ),
            new BookPageInfo
            (
                "But then came the Caribs,",
                "warriors by canoe, who swept",
                "the beaches with fire and",
                "fear. In time, even their",
                "reign yielded to a new age:",
                "the Spanish sails, then",
                "English, French, pirates,",
                "and privateers."
            ),
            new BookPageInfo
            (
                "Antigua’s harbor became",
                "fortress and sugar fields,",
                "while Barbuda's wild shores",
                "harbored runaway slaves,",
                "frigate birds, and secrets.",
                "Gold changed hands, blood",
                "was spilled, and the islands",
                "grew rich — and scarred."
            ),
            new BookPageInfo
            (
                "The wind speaks in many",
                "tongues: of African drums,",
                "English bells, the hush of",
                "indigo night. Today the twin",
                "islands stand free, their flag",
                "a burst of sunrise above blue",
                "waters — sovereign, proud,",
                "awaiting the next voyager."
            ),
            new BookPageInfo
            (
                "Should you find this chest,",
                "know you touch the legacy",
                "of a hundred nations and",
                "ten thousand storms. Treat",
                "the treasures within with",
                "reverence, for you hold not",
                "just gold, but the heart of",
                "Antigua and Barbuda."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheTwinIslands() : base(false)
        {
            Hue = 1366; // Caribbean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Twin Islands");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Twin Islands");
        }

        public ChroniclesOfTheTwinIslands(Serial serial) : base(serial) { }

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
