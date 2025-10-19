using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfIndiasLegacy : WoodenChest
    {
        [Constructable]
        public TreasureChestOfIndiasLegacy()
        {
            Name = "Treasure Chest of India's Legacy";
            Hue = 2125; // Deep sapphire blue

            // Add items to the chest
            AddItem(CreateUniqueArtifact<ArtifactLargeVase>("Vase of the Mauryan Court", 2735), 0.20);
            AddItem(CreateUniqueArtifact<StatueSouth>("Lion Capital of Ashoka", 1175), 0.15);
            AddItem(CreateUniqueArtifact<BlueBeaker>("Holy Water of the Ganges", 1152), 0.13);
            AddItem(CreateUniqueArtifact<Gold>("Coins of the Gupta Empire", 1366), 0.40);
            AddItem(CreateUniqueArtifact<CrystalBallStatuette>("Chandra Gupta's Orb of Wisdom", 1372), 0.08);
            AddItem(CreateUniqueArtifact<Painting1WestArtifact>("Miniature Painting: Mughal Procession", 1164), 0.20);
            AddItem(CreateUniqueArtifact<FancyMirror>("Mirror of the Taj Mahal", 1153), 0.17);
            AddItem(CreateUniqueArtifact<WhiteGrandfatherClock>("Sundial of the Vedas", 1154), 0.09);
            AddItem(CreateUniqueArtifact<RandomFancyBanner>("Banner of the Marathas", 2124), 0.17);
            AddItem(CreateUniqueArtifact<RandomFancyStatue>("Sculpture of Ganesha", 1167), 0.11);
            AddItem(CreateUniqueArtifact<FlowersArtifact>("Garland of Saffron Blossoms", 1153), 0.22);
            AddItem(CreateUniqueArtifact<AncientRunes>("Vedic Tablet", 1165), 0.20);
            AddItem(CreateUniqueArtifact<Urn1Artifact>("Funerary Urn of Harappa", 2735), 0.11);

            // Special Consumables
            AddItem(CreateUniqueConsumable<GreenTea>("Chai of Enlightenment", 1165), 0.18);
            AddItem(CreateUniqueConsumable<SackOfSugar>("Jaggery Sugar", 1150), 0.16);
            AddItem(CreateUniqueConsumable<SushiPlatter>("Royal Thali Feast", 1365), 0.10);
            AddItem(CreateUniqueConsumable<BentoBox>("Saffron Rice Bento", 1167), 0.09);
            AddItem(CreateUniqueConsumable<Watermelon>("Sacred Watermelon of Vrindavan", 1375), 0.11);

            // Epic Equipment
            AddItem(CreateEpicWeapon(), 0.24);
            AddItem(CreateEpicArmor(), 0.24);
            AddItem(CreateEpicClothing(), 0.24);

            // Lore book
            AddItem(new ChronicleOfBharat(), 1.0);

            // Special Map (e.g., to a lost temple)
            AddItem(CreateTreasureMap(), 0.08);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateUniqueArtifact<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateUniqueConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateEpicWeapon()
        {
            BaseWeapon weapon;
            switch (Utility.Random(3))
            {
                case 0: weapon = new Katana(); weapon.Name = "Talwar of Akbar"; break;
                case 1: weapon = new Scimitar(); weapon.Name = "Blade of the Maratha"; break;
                default: weapon = new Dagger(); weapon.Name = "Katar of Kali"; break;
            }
            weapon.Hue = Utility.RandomList(2124, 2735, 1165, 1375); // Emerald, Sapphire, Saffron, Ruby
            weapon.MinDamage = Utility.RandomMinMax(35, 50);
            weapon.MaxDamage = Utility.RandomMinMax(60, 90);
            weapon.Attributes.BonusHits = 20;
            weapon.Attributes.AttackChance = 12;
            weapon.Attributes.DefendChance = 8;
            weapon.Attributes.WeaponDamage = 20;
            weapon.Attributes.WeaponSpeed = 12;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.SelfRepair = 6;
            weapon.WeaponAttributes.HitLeechHits = 10;
            weapon.Slayer = SlayerName.ElementalBan;
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateEpicArmor()
        {
            BaseArmor armor;
            switch (Utility.Random(3))
            {
                case 0: armor = new PlateChest(); armor.Name = "Mughal Emperor's Breastplate"; break;
                case 1: armor = new PlateHelm(); armor.Name = "Rajput Warrior's Helm"; break;
                default: armor = new RingmailChest(); armor.Name = "Vedic Guardian's Chainmail"; break;
            }
            armor.Hue = Utility.RandomList(1153, 1372, 1167, 2125); // Gold, Crystal, Emerald, Blue
            armor.BaseArmorRating = Utility.RandomMinMax(40, 75);
            armor.Attributes.BonusStr = 12;
            armor.Attributes.BonusHits = 16;
            armor.Attributes.ReflectPhysical = 12;
            armor.Attributes.RegenHits = 3;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
            armor.ColdBonus = 10;
            armor.EnergyBonus = 10;
            armor.PhysicalBonus = 20;
            armor.FireBonus = 10;
            armor.PoisonBonus = 10;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateEpicClothing()
        {
            BaseClothing clothing;
            switch (Utility.Random(3))
            {
                case 0: clothing = new Robe(); clothing.Name = "Silk Robe of the Sages"; break;
                case 1: clothing = new FeatheredHat(); clothing.Name = "Peacock Turban"; break;
                default: clothing = new Cloak(); clothing.Name = "Mystic Shawl of Indra"; break;
            }
            clothing.Hue = Utility.RandomList(1153, 1164, 1167, 1372, 2124, 2735); // Rich jewel tones
            clothing.Attributes.BonusInt = 10;
            clothing.Attributes.Luck = 33;
            clothing.Attributes.SpellDamage = 8;
            clothing.SkillBonuses.SetValues(0, SkillName.Meditation, 15.0);
            clothing.SkillBonuses.SetValues(1, SkillName.Magery, 10.0);
            clothing.SkillBonuses.SetValues(2, SkillName.Musicianship, 8.0);
            XmlAttach.AttachTo(clothing, new XmlLevelItem());
            return clothing;
        }

        private Item CreateTreasureMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost Temple of Somnath";
            map.Bounds = new Rectangle2D(2500, 2300, 350, 350);
            map.NewPin = new Point2D(2650, 2450);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfIndiasLegacy(Serial serial) : base(serial)
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

    public class ChronicleOfBharat : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of Bharat", "Sage Vyasa",
            new BookPageInfo
            (
                "Before time was counted,",
                "rivers flowed and gods",
                "whispered in the land",
                "called Bharat. The Indus",
                "and Ganges, sacred and",
                "eternal, watered kingdoms",
                "of myth and memory."
            ),
            new BookPageInfo
            (
                "Great cities rose in",
                "Harappa and Mohenjo-daro,",
                "where traders met and",
                "priests chanted the oldest",
                "hymns. Bronze bells rang",
                "under star-silvered skies."
            ),
            new BookPageInfo
            (
                "Warriors in gilded chariots",
                "wrote the Rigveda in",
                "smoke and song. Ashoka",
                "the Great carved his edicts",
                "on pillars, preaching peace",
                "across a vast empire."
            ),
            new BookPageInfo
            (
                "Golden ages blossomed",
                "in the courts of Gupta.",
                "Poets sang, astronomers",
                "measured the heavens, and",
                "sculptors shaped gods in",
                "stone. The world came to",
                "learn at Nalanda."
            ),
            new BookPageInfo
            (
                "Mughal domes rose",
                "like clouds of marble.",
                "Peacock-throned emperors",
                "ruled from Delhi to Deccan.",
                "Mystics wandered, seeking",
                "the sound at the heart of",
                "all things."
            ),
            new BookPageInfo
            (
                "The chest you open",
                "holds echoes of these",
                "ages: jewels, scrolls,",
                "weapons of legend, and",
                "the promise of Bharat:",
                "unity in diversity,",
                "wisdom beyond time."
            ),
            new BookPageInfo
            (
                "May you carry this",
                "legacy with honor, and",
                "remember: in every heart",
                "the soul of India sings.",
                "",
                "- Vyasa"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfBharat() : base(false)
        {
            Hue = 1372; // Deep ruby red
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of Bharat");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of Bharat");
        }

        public ChronicleOfBharat(Serial serial) : base(serial) { }

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
