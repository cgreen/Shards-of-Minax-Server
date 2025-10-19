using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfTurkmenistan : WoodenChest
    {
        [Constructable]
        public TreasureChestOfTurkmenistan()
        {
            Name = "Treasure Chest of Turkmenistan's Golden Age";
            Hue = 2966; // Rich desert gold

            // Add unique items to the chest
            AddItem(CreateNamedItem<ArtifactLargeVase>("Merv’s Sapphire Vase"), 0.14);
            AddItem(CreateTurkmenCarpet(), 0.20);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the White Horse"), 0.22);
            AddItem(CreateDesertPotion(), 0.17);
            AddItem(CreateBook(), 1.0);
            AddItem(new Gold(Utility.Random(3000, 9000)), 0.20);
            AddItem(CreateNamedItem<RandomFancyCoin>("Silk Road Dirham"), 0.16);
            AddItem(CreateSilkSash(), 0.18);
            AddItem(CreateNamedItem<WolfStatue>("Gökdepe Wolf Idol"), 0.10);
            AddItem(CreateTurkmenCloak(), 0.22);
            AddItem(CreateHorseTrophy(), 0.14);
            AddItem(CreateNamedItem<GreenTea>("Jewel of the Oasis"), 0.10);
            AddItem(CreateNamedItem<RandomFancyPottery>("Goblet of the Akhal Oasis"), 0.09);
            AddItem(CreateNamedItem<RandomFancyPlant>("Desert Lily in Pot"), 0.14);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.24);
            AddItem(CreateHeadgear(), 0.17);
            AddItem(CreateRobe(), 0.20);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateTurkmenCarpet()
        {
            ArtifactVase carpet = new ArtifactVase();
            carpet.Name = "Ancient Turkmen Carpet Fragment";
            carpet.Hue = 2117; // deep red
            return carpet;
        }

        private Item CreateDesertPotion()
        {
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = "Potion of the Karakum Djinn";
            potion.Hue = 1270; // mystical blue
            return potion;
        }

        private Item CreateSilkSash()
        {
            BodySash sash = new BodySash();
            sash.Name = "Sash of the Silk Road";
            sash.Hue = 2075; // vivid turquoise
            sash.Attributes.Luck = 30;
            sash.SkillBonuses.SetValues(0, SkillName.MagicResist, 20.0);
            sash.SkillBonuses.SetValues(1, SkillName.Meditation, 15.0);
            return sash;
        }

        private Item CreateTurkmenCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Five Cities";
            cloak.Hue = 2949; // royal green
            cloak.Attributes.BonusInt = 7;
            cloak.Attributes.RegenStam = 4;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            cloak.SkillBonuses.SetValues(2, SkillName.Ninjitsu, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateHorseTrophy()
        {
            SilverSteedZooStatuette horse = new SilverSteedZooStatuette();
            horse.Name = "Akhal-Teke Trophy";
            horse.Hue = 1153; // shimmering silver-gold
            return horse;
        }

        private Item CreateHeadgear()
        {
            FeatheredHat hat = new FeatheredHat();
            hat.Name = "Turkmen Khan’s Headdress";
            hat.Hue = 1156; // gold-embroidered
            hat.Attributes.BonusStr = 5;
            hat.Attributes.BonusDex = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.AnimalLore, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Tactics, 12.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Parthian Magi";
            robe.Hue = 2955; // mystical indigo
            robe.Attributes.BonusInt = 15;
            robe.Attributes.LowerManaCost = 8;
            robe.Attributes.SpellDamage = 12;
            robe.SkillBonuses.SetValues(0, SkillName.EvalInt, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateWeapon()
        {
            Scimitar scimitar = new Scimitar();
            scimitar.Name = "Sword of Merv’s Guardians";
            scimitar.Hue = 2963; // desert steel
            scimitar.MinDamage = 40;
            scimitar.MaxDamage = 68;
            scimitar.Attributes.BonusStam = 8;
            scimitar.Attributes.BonusHits = 10;
            scimitar.Attributes.WeaponSpeed = 12;
            scimitar.Attributes.AttackChance = 10;
            scimitar.WeaponAttributes.HitHarm = 20;
            scimitar.WeaponAttributes.HitLeechHits = 10;
            scimitar.WeaponAttributes.HitLightning = 14;
            scimitar.SkillBonuses.SetValues(0, SkillName.Swords, 18.0);
            scimitar.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(scimitar, new XmlLevelItem());
            return scimitar;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Breastplate of the Seljuk Champion";
            armor.Hue = 2951; // ancient bronze
            armor.BaseArmorRating = 54;
            armor.Attributes.BonusStr = 12;
            armor.Attributes.DefendChance = 11;
            armor.PhysicalBonus = 16;
            armor.FireBonus = 13;
            armor.ColdBonus = 12;
            armor.PoisonBonus = 14;
            armor.EnergyBonus = 13;
            armor.SkillBonuses.SetValues(0, SkillName.Anatomy, 14.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 7.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBook()
        {
            return new ChronicleOfTheFiveCities();
        }

        private Item CreateNamedItem<T>(string name) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            return item;
        }

        public TreasureChestOfTurkmenistan(Serial serial) : base(serial) { }

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

    public class ChronicleOfTheFiveCities : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicle of the Five Cities", "Ashyr the Scribe",
            new BookPageInfo
            (
                "Beneath the burning sun,",
                "where the shifting sands",
                "swallow all, five cities",
                "rose. Merv, the Pearl.",
                "Nisa, cradle of kings.",
                "Urgench, by the sacred Oxus.",
                "Serakhs and Amul, their",
                "wisdom lost to wind and war."
            ),
            new BookPageInfo
            (
                "Long before the horse",
                "lords thundered, Parthians",
                "built towers that touched",
                "the sky. The Silk Road",
                "brought jade, spices, and",
                "whispers of distant worlds.",
                "Caravans moved as rivers,",
                "their footsteps echoing eternity."
            ),
            new BookPageInfo
            (
                "When night fell, wise men",
                "read the stars. Magi called",
                "down fire. Shahs wore",
                "robes of spun silk, eyes",
                "watchful for Persian and",
                "Roman envoys, and nomad",
                "hordes at the edge of",
                "the desert."
            ),
            new BookPageInfo
            (
                "The Seljuk banners cast",
                "shadows over golden domes.",
                "Turkmen tribesmen rode",
                "the Akhal-Teke, swift as wind.",
                "Their blades defended Merv,",
                "the greatest city beneath",
                "the blue sky, until Mongol",
                "wrath swept all to dust."
            ),
            new BookPageInfo
            (
                "In the ruins, ghosts of",
                "scholars and khans whisper.",
                "They speak of lost gardens,",
                "sacred fires, and hidden",
                "treasures. Those who dare",
                "search the sands may",
                "find their fortune, or join",
                "the lost in silence."
            ),
            new BookPageInfo
            (
                "So remember, seeker:",
                "Every stone and faded",
                "carpet tells a story.",
                "What you find in the",
                "golden chest is yours",
                "by fate and courage.",
                "But respect the spirits",
                "of the ancient cities."
            ),
            new BookPageInfo
            (
                "May the blessing of",
                "Oguz Khan guard you.",
                "Let your shadow grow",
                "long on the desert.",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChronicleOfTheFiveCities() : base(false)
        {
            Hue = 2124; // Silk Road teal
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicle of the Five Cities");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicle of the Five Cities");
        }

        public ChronicleOfTheFiveCities(Serial serial) : base(serial) { }

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
