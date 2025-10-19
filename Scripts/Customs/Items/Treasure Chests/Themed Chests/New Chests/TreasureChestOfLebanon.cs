using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfLebanon : WoodenChest
    {
        [Constructable]
        public TreasureChestOfLebanon()
        {
            Name = "Treasure Chest of the Cedars";
            Hue = 2125; // Deep green, for the Cedar tree

            // Add items to the chest
            AddItem(new PhoenicianChronicles(), 1.0);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Phoenician Amphora", 1165), 0.17);
            AddItem(CreateDecorativeItem<Candelabra>("Cedar Candelabra", 2125), 0.15);
            AddItem(CreateDecorativeItem<SwordDisplay2WestArtifact>("Sword of Tyre Display", 1109), 0.13);
            AddItem(CreateDecorativeItem<Painting3Artifact>("Silk Road Map", 2117), 0.13);
            AddItem(CreateDecorativeItem<Diamond>("Jewel of Byblos", 1151), 0.17);
            AddItem(CreateDecorativeItem<Urn2Artifact>("Urn of Ancient Baalbek", 1877), 0.18);
            AddItem(CreateConsumable<GreenTea>("Cedar Forest Green Tea", 2125), 0.10);
            AddItem(CreateConsumable<PitaBread>("Traditional Pita Bread", 2101), 0.12);
            AddItem(CreateConsumable<LambLeg>("Marinated Lamb Roast", 1810), 0.13);
            AddItem(CreateNamedGold("Tyrian Gold Dinar"), 0.20);
            AddItem(CreateLebaneseWeapon(), 0.19);
            AddItem(CreateLebaneseArmor(), 0.19);
            AddItem(CreateLebaneseCloak(), 0.20);
            AddItem(CreateLebaneseSandals(), 0.18);
            AddItem(CreateLebaneseRing(), 0.20);
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

        private Item CreateConsumable<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedGold(string name)
        {
            Gold gold = new Gold(Utility.RandomMinMax(2000, 6000));
            gold.Name = name;
            return gold;
        }

        private Item CreateLebaneseWeapon()
        {
            // Phoenician Scimitar
            Scimitar weapon = new Scimitar();
            weapon.Name = "Phoenician Scimitar of Tyre";
            weapon.Hue = 1161;
            weapon.MinDamage = 28;
            weapon.MaxDamage = 62;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.WeaponDamage = 40;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.BonusDex = 10;
            weapon.WeaponAttributes.HitFireball = 15;
            weapon.WeaponAttributes.HitLeechHits = 12;
            weapon.Slayer = SlayerName.DragonSlaying;
            weapon.SkillBonuses.SetValues(0, SkillName.Fencing, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLebaneseArmor()
        {
            // Armor of the Cedar Legion
            PlateChest armor = new PlateChest();
            armor.Name = "Chestplate of the Cedar Legion";
            armor.Hue = 2125;
            armor.BaseArmorRating = 58;
            armor.Attributes.BonusStr = 15;
            armor.Attributes.RegenHits = 5;
            armor.Attributes.DefendChance = 10;
            armor.ArmorAttributes.SelfRepair = 6;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 12.0);
            armor.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            armor.ColdBonus = 8;
            armor.EnergyBonus = 7;
            armor.PhysicalBonus = 15;
            armor.FireBonus = 8;
            armor.PoisonBonus = 5;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateLebaneseCloak()
        {
            // Cloak of the Phoenician Merchant
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Phoenician Merchant";
            cloak.Hue = 2213; // Deep purple
            cloak.Attributes.Luck = 60;
            cloak.Attributes.BonusInt = 10;
            cloak.Attributes.BonusMana = 8;
            cloak.Attributes.CastSpeed = 2;
            cloak.Attributes.SpellDamage = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.ItemID, 15.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Cartography, 12.0); // If custom skill exists
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateLebaneseSandals()
        {
            // Sandals of the Mountain Hermit
            Sandals sandals = new Sandals();
            sandals.Name = "Sandals of the Mountain Hermit";
            sandals.Hue = 2115;
            sandals.Attributes.BonusDex = 8;
            sandals.Attributes.LowerManaCost = 6;
            sandals.Attributes.NightSight = 1;
            sandals.SkillBonuses.SetValues(0, SkillName.Hiding, 15.0);
            sandals.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(sandals, new XmlLevelItem());
            return sandals;
        }

        private Item CreateLebaneseRing()
        {
            // Ring of the Cedar
            GoldRing ring = new GoldRing();
            ring.Name = "Ring of the Cedars";
            ring.Hue = 1175;
            ring.Attributes.BonusHits = 18;
            ring.Attributes.LowerRegCost = 10;
            ring.Attributes.BonusStr = 8;
            ring.SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 10.0);
            ring.SkillBonuses.SetValues(1, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        public TreasureChestOfLebanon(Serial serial) : base(serial) { }

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

    // --- Custom Book of Lore: Phoenician Chronicles ---

    public class PhoenicianChronicles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Cedars", "Anonymous Scribe of Byblos",
            new BookPageInfo
            (
                "In the land where the cedar trees rise,",
                "on the coast of the shining sea, the",
                "Phoenicians built their harbors, their ships,",
                "and their legacy. Byblos, Sidon, and Tyre",
                "were crowned with the scent of incense, the",
                "glimmer of purple dye, and the echo of",
                "merchant songs across the waves."
            ),
            new BookPageInfo
            (
                "From their forests, mighty cedars were felled,",
                "to build the ships that sailed the world. The",
                "alphabet was carved and given to the peoples",
                "of the earth. Gold and glass flowed through",
                "their hands, and tales of the purple dye",
                "spread to every distant king."
            ),
            new BookPageInfo
            (
                "When Rome's legions came, the old temples",
                "stood tall—Baalbek's stones defied the ages.",
                "Through conquest and empire, the mountains",
                "remained guardians, and the valleys hid",
                "the wisdom of many faiths and many peoples.",
                "The land became a crossroads, always ancient,",
                "always new."
            ),
            new BookPageInfo
            (
                "From the mountains of the Druze, to the",
                "Christian monasteries, from the bustling",
                "markets of Beirut to the quiet ruins of",
                "Tyre, Lebanon’s heart has endured. Wars",
                "came and passed, but the resilience of",
                "its people, like the cedar, remains unbowed."
            ),
            new BookPageInfo
            (
                "Let this chest be a remembrance: within its",
                "gifts are echoes of the ancient world—ships,",
                "temples, alphabets, faiths, and flavors. May",
                "those who open it remember Lebanon’s long",
                "history—a tale of endurance, beauty, and",
                "the unbroken song of the cedar."
            ),
            new BookPageInfo
            (
                "‘Lebanon is more than a country; it is a",
                "message of freedom and an example of",
                "pluralism for East and West alike.’",
                "",
                "- Khalil Gibran",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public PhoenicianChronicles() : base(false)
        {
            Hue = 2125; // Cedar green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Cedars");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Cedars");
        }

        public PhoenicianChronicles(Serial serial) : base(serial) { }

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

    // --- Custom food item: Pita Bread ---
    public class PitaBread : BreadLoaf
    {
        [Constructable]
        public PitaBread()
        {
            Name = "Traditional Pita Bread";
            Hue = 2101; // Tan
        }

        public PitaBread(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
