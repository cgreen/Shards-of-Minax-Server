using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTheMoroccanDynasties : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTheMoroccanDynasties()
        {
            Name = "Treasure Chest of the Moroccan Dynasties";
            Hue = 2101; // Deep Moroccan blue

            // Add themed items
            AddItem(new ChroniclesOfMorocco(), 1.0); // Always include the book
            AddItem(CreateColoredItem<ArtifactLargeVase>("Almohad Ceremonial Vase", 2503), 0.18);
            AddItem(CreateColoredItem<BottleArtifact>("Perfume of Marrakech", 1277), 0.22);
            AddItem(CreateNamedItem<GoldenSandals>("Sandals of Ibn Battuta"), 0.13);
            AddItem(CreateGoldItem("Dinar of the Marinid Sultans"), 0.19);
            AddItem(CreateColoredItem<RandomFancyCoin>("Coin of the Sahara Caravans", 2212), 0.22);
            AddItem(CreateMoorishRobe(), 0.18);
            AddItem(CreateBerberCloak(), 0.17);
            AddItem(CreateMoroccanWeapon(), 0.21);
            AddItem(CreateMoroccanShield(), 0.17);
            AddItem(CreateDesertNomadKhopesh(), 0.13);
            AddItem(CreateAtlasRing(), 0.17);
            AddItem(CreateTagineFeast(), 0.18);
            AddItem(CreateColoredItem<GreenTea>("Mint Tea of Fez", 1197), 0.23);
            AddItem(CreateColoredItem<OrcMask>("Mask of the Blue City", 2075), 0.17);
            AddItem(CreateMap(), 0.10);
            AddItem(CreateSimpleNote(), 0.14);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.17);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
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

        private Item CreateSimpleNote()
        {
            SimpleNote note = new SimpleNote();
            note.TitleString = "Travelers’ Wisdom";
            note.NoteString = "From the winding souks of Marrakech to the wind-battered kasbahs of the Atlas, the dynasties of Morocco rose and fell by the sword and the pen. Seek not only gold, but knowledge within these walls.";
            return note;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost City of Sijilmasa";
            map.Bounds = new Rectangle2D(540, 1540, 400, 400); // Fantasy coordinates
            map.NewPin = new Point2D(690, 1720);
            map.Protected = true;
            return map;
        }

        // UNIQUE WEAPON: The Scimitar of the Saadian Sultan
        private Item CreateMoroccanWeapon()
        {
            Katana scimitar = new Katana();
            scimitar.Name = "Scimitar of the Saadian Sultan";
            scimitar.Hue = 2118; // Rich gold/copper
            scimitar.Attributes.SpellChanneling = 1;
            scimitar.Attributes.CastSpeed = 1;
            scimitar.Attributes.AttackChance = 20;
            scimitar.Attributes.WeaponSpeed = 25;
            scimitar.Attributes.BonusHits = 25;
            scimitar.WeaponAttributes.HitLeechMana = 18;
            scimitar.WeaponAttributes.HitFireball = 15;
            scimitar.WeaponAttributes.SelfRepair = 6;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        // UNIQUE ARMOR: Moorish Ceremonial Robe
        private Item CreateMoorishRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Moorish Ceremonial Robe";
            robe.Hue = 2109; // Indigo blue
            robe.Attributes.Luck = 55;
            robe.Attributes.BonusMana = 18;
            robe.Attributes.BonusInt = 10;
            robe.Attributes.RegenMana = 4;
            robe.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.Magery, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // UNIQUE ARMOR: Berber Nomad’s Desert Cloak
        private Item CreateBerberCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Berber Nomad's Desert Cloak";
            cloak.Hue = 2120; // Desert tan
            cloak.Attributes.Luck = 30;
            cloak.Attributes.BonusDex = 14;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Hiding, 16.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Tracking, 11.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        // UNIQUE SHIELD: Shield of the Almoravid Lion
        private Item CreateMoroccanShield()
        {
            HeaterShield shield = new HeaterShield();
            shield.Name = "Shield of the Almoravid Lion";
            shield.Hue = 1157; // Bright gold
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusHits = 20;
            shield.ArmorAttributes.LowerStatReq = 25;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 18.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        // UNIQUE WEAPON: Desert Nomad’s Khopesh
        private Item CreateDesertNomadKhopesh()
        {
            Scimitar khopesh = new Scimitar();
            khopesh.Name = "Desert Nomad's Khopesh";
            khopesh.Hue = 1109; // Burnished bronze
            khopesh.Attributes.AttackChance = 14;
            khopesh.Attributes.WeaponDamage = 22;
            khopesh.WeaponAttributes.HitHarm = 11;
            khopesh.WeaponAttributes.HitLowerAttack = 12;
            khopesh.SkillBonuses.SetValues(0, SkillName.Tactics, 9.0);
            khopesh.SkillBonuses.SetValues(1, SkillName.Fencing, 12.0);
            XmlAttach.AttachTo(khopesh, new XmlLevelItem());
            return khopesh;
        }

        // UNIQUE JEWELRY: Atlas Ring of Endurance
        private Item CreateAtlasRing()
        {
            GoldRing ring = new GoldRing();
            ring.Name = "Atlas Ring of Endurance";
            ring.Hue = 1167; // Emerald green
            ring.Attributes.BonusStam = 20;
            ring.Attributes.RegenStam = 6;
            ring.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            ring.SkillBonuses.SetValues(1, SkillName.Healing, 12.0);
            ring.Attributes.ReflectPhysical = 8;
            XmlAttach.AttachTo(ring, new XmlLevelItem());
            return ring;
        }

        // UNIQUE FOOTWEAR: Golden Sandals of Ibn Battuta
        private class GoldenSandals : Sandals
        {
            [Constructable]
            public GoldenSandals()
            {
                Name = "Golden Sandals of Ibn Battuta";
                Hue = 2212;
                Attributes.BonusDex = 12;
                Attributes.Luck = 33;
                SkillBonuses.SetValues(0, SkillName.Cartography, 8.0);
                SkillBonuses.SetValues(1, SkillName.Snooping, 7.0);
                XmlAttach.AttachTo(this, new XmlLevelItem());
            }

            public GoldenSandals(Serial serial) : base(serial) { }
            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);
                writer.Write(0);
            }
            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);
                int version = reader.ReadInt();
            }
        }

        // UNIQUE FOOD: Tagine Feast (restores more than standard food)
        private Item CreateTagineFeast()
        {
            Cake tagine = new Cake();
            tagine.Name = "Tagine Feast of the Sultan";
            tagine.Hue = 1197; // Mint green
            tagine.Stackable = true;
            tagine.Amount = 3;
            tagine.Weight = 0.5;
            // Could add XML attachment for extra effect if desired
            return tagine;
        }

        public TreasureChestOfTheMoroccanDynasties(Serial serial) : base(serial) { }
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

    // LORE BOOK: Chronicles of Morocco
    public class ChroniclesOfMorocco : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Morocco: Kingdoms of the Maghreb", "Hakim al-Fasi",
            new BookPageInfo
            (
                "From the dawn of time,",
                "the lands of Morocco",
                "have been shaped by",
                "Berber tribes and",
                "ancient Carthaginians.",
                "Phoenician traders",
                "brought their secrets",
                "to Tangier and beyond."
            ),
            new BookPageInfo
            (
                "Roman legions raised",
                "Volubilis, but in the",
                "shadows the Berber",
                "kings endured. Islam",
                "came with Idris, son",
                "of Ali, who planted",
                "the seeds of empire",
                "at Fes and Meknes."
            ),
            new BookPageInfo
            (
                "The Almoravids swept",
                "from the Sahara,",
                "uniting tribes under",
                "the banner of faith.",
                "Their golden age",
                "spread from Marrakesh",
                "to the gates of Spain.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "The Almohads rose",
                "in rebellion—philosopher-",
                "kings whose wisdom",
                "and zeal built",
                "towering minarets",
                "and filled the world",
                "with light. Their",
                "power waned, but the"
            ),
            new BookPageInfo
            (
                "Marinids carried",
                "the torch, crafting",
                "medersas and gardens.",
                "Mighty Saadians",
                "fought off foreign",
                "invasion with steel,",
                "while poets wrote of",
                "roses and deserts."
            ),
            new BookPageInfo
            (
                "Moulay Ismail forged",
                "imperial Meknes with",
                "iron and dreams.",
                "Through all the tides,",
                "the spirit of the Maghreb",
                "remains—nomads,",
                "warriors, scholars, and",
                "traders, all one people."
            ),
            new BookPageInfo
            (
                "If you hold this chest,",
                "know you hold the",
                "legacy of a land shaped",
                "by sun, sea, and sand,",
                "by lion-hearted sultans",
                "and mystics beneath",
                "the endless sky.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "To the seeker: May the",
                "wind at the gates of the",
                "Sahara guide you, and",
                "the wisdom of Morocco’s",
                "dynasties inspire you.",
                "",
                "- Hakim al-Fasi",
                ""
            )
        );
        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfMorocco() : base(false)
        {
            Hue = 2101; // Moroccan blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Morocco: Kingdoms of the Maghreb");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Morocco: Kingdoms of the Maghreb");
        }

        public ChroniclesOfMorocco(Serial serial) : base(serial) { }
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
