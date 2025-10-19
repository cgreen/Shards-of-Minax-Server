using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientKyrgyzstan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientKyrgyzstan()
        {
            Name = "Treasure Chest of Ancient Kyrgyzstan";
            Hue = 1153; // Deep sky blue

            // Add items to the chest
            AddItem(CreateLoreBook(), 1.0);
            AddItem(CreateDecorativeItem(), 0.30);
            AddItem(CreateDecorativeItem(), 0.30);
            AddItem(CreateDecorativeItem(), 0.30);

            AddItem(CreateConsumable(), 0.35);
            AddItem(CreateConsumable(), 0.25);

            AddItem(CreateEpicWeapon(), 0.22);
            AddItem(CreateEpicArmor(), 0.22);
            AddItem(CreateEpicClothing(), 0.22);

            AddItem(CreateMap(), 0.10);
            AddItem(CreateGoldItem("Silk Road Dinar"), 0.14);
            AddItem(new Gold(Utility.Random(1, 5000)), 0.22);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // --- Decorative Items ---
        private Item CreateDecorativeItem()
        {
            switch (Utility.Random(4))
            {
                case 0:
                    var yurt = new ArtifactLargeVase();
                    yurt.Name = "Miniature Felt Yurt of the Steppe";
                    yurt.Hue = 1001; // White
                    return yurt;
                case 1:
                    var banner = new Painting3Artifact();
                    banner.Name = "Silk Banner of the Silk Road";
                    banner.Hue = 1153; // Blue
                    return banner;
                case 2:
                    var eagle = new SilverSteedZooStatuette();
                    eagle.Name = "Statuette of the Golden Eagle";
                    eagle.Hue = 1354; // Gold
                    return eagle;
                case 3:
                    var komuz = new FancyHornOfPlenty();
                    komuz.Name = "Carved Komuz, Instrument of Kyrgyz";
                    komuz.Hue = 2418; // Wood tone
                    return komuz;
                default:
                    var artifact = new ArtifactVase();
                    artifact.Name = "Runic Pottery of Osh";
                    artifact.Hue = 1775;
                    return artifact;
            }
        }

        // --- Consumables ---
        private Item CreateConsumable()
        {
            switch (Utility.Random(3))
            {
                case 0:
                    var kumis = new BottleArtifact();
                    kumis.Name = "Kumis, Mare’s Fermented Milk";
                    kumis.Hue = 1152;
                    return kumis;
                case 1:
                    var beshbarmak = new WoodenBowlOfStew();
                    beshbarmak.Name = "Beshbarmak Feast of Nomads";
                    beshbarmak.Hue = 1107;
                    return beshbarmak;
                case 2:
                    var elixir = new GreaterHealPotion();
                    elixir.Name = "Herbal Elixir of Tien Shan";
                    elixir.Hue = 2052;
                    return elixir;
                default:
                    var airag = new BottleArtifact();
                    airag.Name = "Airag, Spirit of the Steppe";
                    airag.Hue = 1171;
                    return airag;
            }
        }

        // --- Epic Equipment ---
        private Item CreateEpicWeapon()
        {
            var weapon = new Scimitar();
            weapon.Name = "Sword of Manas the Avenger";
            weapon.Hue = 1354; // Gold
            weapon.Attributes.AttackChance = 25;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.WeaponDamage = 45;
            weapon.Attributes.BonusStam = 15;
            weapon.Attributes.SpellChanneling = 1;
            weapon.WeaponAttributes.HitLightning = 35;
            weapon.WeaponAttributes.HitFireball = 25;
            weapon.WeaponAttributes.SelfRepair = 8;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            weapon.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 15.0);
            weapon.SkillBonuses.SetValues(2, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateEpicArmor()
        {
            var chest = new PlateChest();
            chest.Name = "Chestplate of the Eagle Hunter";
            chest.Hue = 2406; // Silver
            chest.BaseArmorRating = 60;
            chest.Attributes.BonusHits = 25;
            chest.ArmorAttributes.LowerStatReq = 30;
            chest.ArmorAttributes.MageArmor = 1;
            chest.Attributes.BonusStr = 10;
            chest.SkillBonuses.SetValues(0, SkillName.AnimalLore, 20.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 12.0);
            chest.ColdBonus = 10;
            chest.PhysicalBonus = 20;
            chest.EnergyBonus = 10;
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateEpicClothing()
        {
            var robe = new Robe();
            robe.Name = "Robe of the Steppe Shaman";
            robe.Hue = 1170; // Sky blue
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusMana = 20;
            robe.Attributes.NightSight = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Healing, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.AnimalTaming, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // --- Map to a Mythic Site ---
        private Item CreateMap()
        {
            var map = new SimpleMap();
            map.Name = "Map to the Valley of Seven Bulls";
            map.Bounds = new Rectangle2D(2200, 1450, 500, 350);
            map.NewPin = new Point2D(2350, 1550);
            map.Protected = true;
            return map;
        }

        // --- Gold/Dinar ---
        private Item CreateGoldItem(string name)
        {
            var gold = new Gold();
            gold.Name = name;
            return gold;
        }

        // --- Lore Book: Epic of Manas ---
        private Item CreateLoreBook()
        {
            return new EpicOfManasChronicle();
        }

        public TreasureChestOfAncientKyrgyzstan(Serial serial) : base(serial) { }

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

    public class EpicOfManasChronicle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Epic of Manas: The Horse Lord’s Chronicle", "Bards of Issyk-Kul",
            new BookPageInfo
            (
                "In the shadow of Tien Shan,",
                "where eagles soar and rivers",
                "sing, the clans of Kyrgyz",
                "gathered. I am Manas,",
                "born of legend, raised in",
                "battle, destined to unite",
                "my people beneath the",
                "eternal blue sky."
            ),
            new BookPageInfo
            (
                "With sword and steed I rode,",
                "from Ala-Too to the golden",
                "vales, defying khans and",
                "tyrants. My brothers and I,",
                "sworn by blood and song,",
                "fought to keep the nomad's",
                "freedom alive."
            ),
            new BookPageInfo
            (
                "We drank kumis by moonlight,",
                "sang the wisdom of shamans,",
                "chased shadows across the",
                "steppe. The Silk Road,",
                "thread of empires, ran",
                "beneath our hooves. Even the",
                "desert wind spoke our name."
            ),
            new BookPageInfo
            (
                "Beware the tale of the wolf,",
                "for old spirits guard these",
                "lands. The sword I wield is",
                "not only steel, but memory.",
                "My ancestors watch from the",
                "snow peaks. The mountains",
                "echo my oath: never bow."
            ),
            new BookPageInfo
            (
                "When you read these words,",
                "remember—Kyrgyzstan is not",
                "just earth and grass, but",
                "story, spirit, and song.",
                "The blue sky above is our",
                "flag, the mountains our",
                "throne, the steppe our soul.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Take these treasures with",
                "honor. May the courage of",
                "the horsemen run with you.",
                "May the blessings of the",
                "shamans shield you. May",
                "Manas ride in your dreams.",
                "",
                "- The Bards of Kyrgyzstan"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public EpicOfManasChronicle() : base(false)
        {
            Hue = 1153; // Sky blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Epic of Manas: The Horse Lord’s Chronicle");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Epic of Manas: The Horse Lord’s Chronicle");
        }

        public EpicOfManasChronicle(Serial serial) : base(serial) { }

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
