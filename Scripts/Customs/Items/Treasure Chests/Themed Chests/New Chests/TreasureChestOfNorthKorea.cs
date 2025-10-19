using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNorthKorea : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNorthKorea()
        {
            Name = "Treasure Chest of North Korea";
            Hue = 1109; // Dark blue, hint of secrecy

            // Add items to the chest
            AddItem(new KimIlSungMedal(), 0.18);
            AddItem(CreateColoredItem<WolfStatue>("Mount Paektu Wolf Statuette", 1157), 0.12);
            AddItem(CreateColoredItem<ReptalonZooStatuette>("Sacred Tiger Figurine", 1194), 0.08);
            AddItem(CreateNamedItem<GreaterHealPotion>("Juche Elixir of Resilience"), 0.13);
            AddItem(new BookOfJucheLore(), 1.0);
            AddItem(CreateUniqueConsumable("Revolutionary Ginseng Tonic", 2979), 0.20);
            AddItem(CreateUniqueConsumable("Mystery Rice Cake", 1151), 0.17);
            AddItem(CreateUniqueConsumable("Pyongyang Soju", 2125), 0.15);
            AddItem(CreateNamedItem<GoldBracelet>("Hero's Star Bracelet"), 0.18);
            AddItem(CreateColoredItem<Sandals>("Agent's Silent Footwear", 2101), 0.16);
            AddItem(CreateWeapon(), 0.28);
            AddItem(CreateArmor(), 0.26);
            AddItem(CreateSpyHat(), 0.17);
            AddItem(CreateSpecialCloak(), 0.15);
            AddItem(CreateLegendaryDagger(), 0.13);
            AddItem(CreateDecorativeBanner(), 0.10);
            AddItem(new Gold(Utility.Random(3000, 9000)), 0.21);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateUniqueConsumable(string name, int hue)
        {
            // Use a simple potion base as a unique consumable.
            GreaterHealPotion potion = new GreaterHealPotion();
            potion.Name = name;
            potion.Hue = hue;
            potion.Weight = 2.0;
            return potion;
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

        private Item CreateDecorativeBanner()
        {
            // Use a painting or banner artifact as a patriotic symbol.
            Painting4WestArtifact banner = new Painting4WestArtifact();
            banner.Name = "Banner of the Eternal President";
            banner.Hue = 1153; // Deep red
            return banner;
        }

        private Item CreateWeapon()
        {
            // Legendary spy blade
            ShadowSai weapon = new ShadowSai();
            weapon.Name = "Blade of the Secret Operative";
            weapon.Hue = 1109;
            weapon.MinDamage = 35;
            weapon.MaxDamage = 70;
            weapon.Attributes.AttackChance = 15;
            weapon.Attributes.BonusDex = 12;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.RegenStam = 4;
            weapon.WeaponAttributes.HitHarm = 15;
            weapon.WeaponAttributes.SelfRepair = 5;
            weapon.SkillBonuses.SetValues(0, SkillName.Stealth, 20.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Poisoning, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateLegendaryDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Supreme Leader";
            dagger.Hue = 1153;
            dagger.MinDamage = 25;
            dagger.MaxDamage = 60;
            dagger.Attributes.CastSpeed = 1;
            dagger.Attributes.WeaponSpeed = 15;
            dagger.Attributes.BonusHits = 20;
            dagger.WeaponAttributes.HitLeechHits = 12;
            dagger.WeaponAttributes.HitLeechMana = 8;
            dagger.SkillBonuses.SetValues(0, SkillName.Anatomy, 12.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Stealth, 12.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateArmor()
        {
            // “Juche Plate Armor” with many strong mods
            PlateChest chest = new PlateChest();
            chest.Name = "Juche Plate of Invincibility";
            chest.Hue = 2982;
            chest.BaseArmorRating = 55;
            chest.Attributes.BonusStr = 15;
            chest.Attributes.BonusHits = 18;
            chest.Attributes.BonusStam = 10;
            chest.Attributes.NightSight = 1;
            chest.ArmorAttributes.SelfRepair = 6;
            chest.AbsorptionAttributes.EaterEnergy = 12;
            chest.PhysicalBonus = 20;
            chest.FireBonus = 8;
            chest.ColdBonus = 8;
            chest.EnergyBonus = 10;
            chest.PoisonBonus = 10;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateSpyHat()
        {
            // Fedora as a “spy hat”
            WideBrimHat hat = new WideBrimHat();
            hat.Name = "Operative's Fedora";
            hat.Hue = 2101;
            hat.Attributes.BonusInt = 10;
            hat.Attributes.LowerManaCost = 10;
            hat.SkillBonuses.SetValues(0, SkillName.Hiding, 20.0);
            hat.SkillBonuses.SetValues(1, SkillName.DetectHidden, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateSpecialCloak()
        {
            // Cloak for stealth/espionage
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Demilitarized Zone";
            cloak.Hue = 1109;
            cloak.Attributes.LowerRegCost = 12;
            cloak.Attributes.BonusMana = 8;
            cloak.SkillBonuses.SetValues(0, SkillName.Stealth, 16.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Ninjitsu, 12.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        public TreasureChestOfNorthKorea(Serial serial) : base(serial) { }

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

    // Custom Medal Item
    public class KimIlSungMedal : GoldBracelet
    {
        [Constructable]
        public KimIlSungMedal()
        {
            Name = "Medal of Kim Il Sung";
            Hue = 1172; // Gold-Red
            Attributes.BonusStr = 10;
            Attributes.BonusInt = 7;
            Attributes.BonusHits = 10;
            SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
        }
        public KimIlSungMedal(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }

    // Custom Lore Book
    public class BookOfJucheLore : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Hermit Kingdom", "The Hidden Scribe",
            new BookPageInfo
            (
                "In the shadowed valleys",
                "beyond the Taedong River,",
                "a land was forged by",
                "iron, fire, and will. Here,",
                "the sun rises first for the",
                "Great Leader, and the",
                "people walk the path of",
                "Juche—self-reliance."
            ),
            new BookPageInfo
            (
                "Mount Paektu stands",
                "sentinel, watching over",
                "the destiny of Korea.",
                "Legends speak of a",
                "heaven-sent child, whose",
                "legacy endures in marble",
                "statues and silent",
                "marches beneath red flags."
            ),
            new BookPageInfo
            (
                "From the ashes of war,",
                "the Hermit Kingdom",
                "sealed its borders and",
                "minds. Songs of unity",
                "echo through the loud-",
                "speakers, while secrets",
                "whisper behind closed",
                "doors."
            ),
            new BookPageInfo
            (
                "The Eternal President",
                "guides with an unseen",
                "hand, his wisdom",
                "inscribed on every stone,",
                "his portraits never far",
                "from watchful eyes.",
                "Suspicion is survival.",
                "Faith is armor."
            ),
            new BookPageInfo
            (
                "Those who unlock this",
                "chest hold a relic of",
                "power, born of secrecy.",
                "Tread carefully. The walls",
                "have ears, and the hills",
                "hold ancient spirits,",
                "forever guarding the",
                "mysteries of the North."
            ),
            new BookPageInfo
            (
                "Beware: within these",
                "gifts lies both hope and",
                "danger. Take only what",
                "you need. May the wisdom",
                "of Paektu guide your",
                "journey. And remember:",
                "the eyes of history are",
                "always watching."
            ),
            new BookPageInfo
            (
                "Let the torch of Juche",
                "illuminate your path, as",
                "it has for all who walk",
                "in the Hermit Kingdom.",
                "",
                "- The Hidden Scribe",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfJucheLore() : base(false)
        {
            Hue = 1109; // Dark blue-black
        }
        public override void AddNameProperty(ObjectPropertyList list) => list.Add("Chronicles of the Hermit Kingdom");
        public override void OnSingleClick(Mobile from) => LabelTo(from, "Chronicles of the Hermit Kingdom");
        public BookOfJucheLore(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.WriteEncodedInt(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadEncodedInt(); }
    }
}
