using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfBosnia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfBosnia()
        {
            Name = "Treasure Chest of Bosnia and Herzegovina";
            Hue = 2075; // Deep blue for Bosnian flag

            // Add items to the chest
            AddItem(CreateDecorativeArtifact<ArtifactVase>("Stećak Carved Urn", 2101), 0.16);
            AddItem(CreateDecorativeArtifact<RandomFancyBanner>("Banner of the Golden Lily", 1155), 0.15);
            AddItem(CreateDecorativeArtifact<Lute>("Sevdah Saz", 2413), 0.12);
            AddItem(CreateConsumable<GreaterHealPotion>("Potion of Sarajevo Resilience", 1175), 0.18);
            AddItem(CreateConsumable<Bottle>("Balkan Spice Wine", 1164), 0.10);
            AddItem(CreateConsumable<GreenTea>("Herzegovinian Herbal Tea", 1173), 0.11);
            AddItem(CreateEquipmentSword(), 0.20);
            AddItem(CreateEquipmentArmor(), 0.17);
            AddItem(CreateEquipmentClothing(), 0.19);
            AddItem(new ChroniclesOfBosnia(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 5000)), 0.22);
            AddItem(CreateDecorativeArtifact<Painting1NorthArtifact>("Tale of Mostar Bridge", 2123), 0.11);
            AddItem(CreateDecorativeArtifact<BlueBeaker>("Alchemist’s Flask of Vrelo Bosne", 1161), 0.12);
            AddItem(CreateConsumable<RandomFancyBakedGoods>("Pita of Kings", 2129), 0.14);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorativeArtifact<T>(string name, int hue) where T : Item, new()
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

        // Example: "Sword of Tvrtko" (medieval Bosnian king)
        private Item CreateEquipmentSword()
        {
            Longsword sword = new Longsword();
            sword.Name = "Sword of King Tvrtko";
            sword.Hue = 1170;
            sword.MaxDamage = Utility.Random(40, 75);
            sword.Attributes.WeaponDamage = 60;
            sword.Attributes.BonusStr = 10;
            sword.Attributes.BonusHits = 30;
            sword.Attributes.ReflectPhysical = 15;
            sword.WeaponAttributes.HitLightning = 20;
            sword.WeaponAttributes.HitLeechHits = 12;
            sword.SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
            XmlAttach.AttachTo(sword, new XmlLevelItem());
            return sword;
        }

        // Example: "Janissary Mail" with powerful defenses
        private Item CreateEquipmentArmor()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Janissary Mail of the Drina";
            chest.Hue = 1159;
            chest.BaseArmorRating = Utility.Random(40, 75);
            chest.Attributes.BonusHits = 40;
            chest.Attributes.DefendChance = 12;
            chest.Attributes.RegenHits = 6;
            chest.Attributes.RegenStam = 5;
            chest.ArmorAttributes.MageArmor = 1;
            chest.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            chest.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        // Example: "Cloak of Stećak" (ancient tombstone)
        private Item CreateEquipmentClothing()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of Stećak";
            cloak.Hue = 2106; // Stone-grey
            cloak.Attributes.Luck = 60;
            cloak.Attributes.BonusMana = 15;
            cloak.SkillBonuses.SetValues(0, SkillName.Anatomy, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        public TreasureChestOfBosnia(Serial serial) : base(serial) { }

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

    public class ChroniclesOfBosnia : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Heart-Shaped Land", "Eyewitness to Ages",
            new BookPageInfo
            (
                "Upon these emerald hills",
                "and misty rivers, kingdoms",
                "rose and fell. First Illyrian,",
                "then Roman stone and song.",
                "The banners of Bosnia fluttered,",
                "lilies golden upon blue,",
                "beneath the shadow of",
                "Tvrtko's mighty crown."
            ),
            new BookPageInfo
            (
                "Yet the crescent came,",
                "bearing stories and minarets.",
                "Sarajevo, city of bridges,",
                "became crossroads of faiths:",
                "churchbells, muezzin,",
                "synagogue psalms.",
                "Folk danced the kolo",
                "under Stari Most's arch."
            ),
            new BookPageInfo
            (
                "Ottoman and Habsburg,",
                "brotherhood and blood.",
                "Sevdah songs echo in stone,",
                "laughter in Baščaršija's",
                "bazaars, secrets in",
                "the pines of Sutjeska.",
                "Brave hearts, scarred,",
                "never bowed."
            ),
            new BookPageInfo
            (
                "Rivers Drina, Neretva,",
                "Miljacka—witnesses all.",
                "Empires marched, but roots",
                "grew deeper, songs",
                "sweeter, tales taller.",
                "For here, East and West",
                "wove a tapestry bright",
                "and fierce."
            ),
            new BookPageInfo
            (
                "Let this chest guard",
                "the spirit of Bosnia:",
                "resilient, radiant,",
                "forever whole.",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfBosnia() : base(false)
        {
            Hue = 2075; // Bosnian blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Heart-Shaped Land");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Heart-Shaped Land");
        }

        public ChroniclesOfBosnia(Serial serial) : base(serial) { }

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
