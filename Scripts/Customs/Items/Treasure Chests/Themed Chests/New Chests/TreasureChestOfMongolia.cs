using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMongolia : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMongolia()
        {
            Name = "Treasure Chest of Mongolia";
            Hue = 2407; // Deep blue for steppe sky

            // Add items to the chest
            AddItem(CreateDecorativeItem<StatueSouth>("Horse Statue of the Steppe", 1109), 0.20);
            AddItem(CreateDecorativeItem<ArtifactLargeVase>("Ornate Mongol Vase", 2412), 0.18);
            AddItem(CreateDecorativeItem<WolfStatue>("Spirit Wolf of the Plains", 2101), 0.13);
            AddItem(CreateDecorativeItem<Urn1Artifact>("Sacred Urn of the Khan", 1151), 0.13);
            AddItem(CreateDecorativeItem<Bow>("Gilded Bow of the Horde", 1161), 0.15);

            AddItem(CreateConsumable<GreaterHealPotion>("Mare's Milk Elixir", 1160), 0.18);
            AddItem(CreateConsumable<BowlOfRotwormStew>("Bowl of Steppe Stew", 2213), 0.18);
            AddItem(CreateConsumable<GreenTea>("Fermented Airag", 1174), 0.15);

            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.20);
            AddItem(CreateBoots(), 0.20);
            AddItem(CreateHat(), 0.18);
            AddItem(CreateCloak(), 0.16);

            AddItem(CreateGoldItem("Golden Horde Coin"), 0.20);
            AddItem(new Gold(Utility.Random(1, 8000)), 0.20);

            AddItem(new ChroniclesOfTheKhan(), 1.0);
            AddItem(CreateMap(), 0.07);
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

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateWeapon()
        {
            CompositeBow bow = new CompositeBow();
            bow.Name = "Bow of Genghis Khan";
            bow.Hue = 2213; // Mongol gold
            bow.WeaponAttributes.HitLightning = 30;
            bow.WeaponAttributes.HitHarm = 25;
            bow.WeaponAttributes.UseBestSkill = 1;
            bow.Attributes.WeaponDamage = 55;
            bow.Attributes.AttackChance = 15;
            bow.Attributes.BonusDex = 10;
            bow.SkillBonuses.SetValues(0, SkillName.Archery, 15.0);
            bow.SkillBonuses.SetValues(1, SkillName.Anatomy, 7.0);
            bow.Slayer = SlayerName.DragonSlaying;
            XmlAttach.AttachTo(bow, new XmlLevelItem());
            return bow;
        }

        private Item CreateArmor()
        {
            LeatherDo armor = new LeatherDo();
            armor.Name = "Steppe Warrior's Lamellar";
            armor.Hue = 2407; // Blue/grey steppe
            armor.BaseArmorRating = Utility.Random(40, 65);
            armor.ArmorAttributes.SelfRepair = 5;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusStr = 10;
            armor.Attributes.BonusStam = 7;
            armor.Attributes.DefendChance = 15;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 8.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBoots()
        {
            FurBoots boots = new FurBoots();
            boots.Name = "Boots of Endless Travel";
            boots.Hue = 2113; // Fur brown
            boots.Attributes.BonusStam = 12;
            boots.Attributes.RegenStam = 3;
            boots.Attributes.Luck = 40;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateHat()
        {
            BearMask hat = new BearMask();
            hat.Name = "Shaman's Bear Headdress";
            hat.Hue = 1109; // Deep black
            hat.Attributes.BonusInt = 8;
            hat.Attributes.BonusMana = 8;
            hat.Attributes.SpellDamage = 12;
            hat.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            hat.SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Eternal Steppe";
            cloak.Hue = 1160; // Green for grassland
            cloak.Attributes.RegenMana = 2;
            cloak.Attributes.BonusHits = 8;
            cloak.Attributes.LowerManaCost = 10;
            cloak.SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.Veterinary, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Secret Map of the Mongol Empire";
            map.Bounds = new Rectangle2D(2100, 1200, 1200, 800);
            map.NewPin = new Point2D(2700, 1800);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfMongolia(Serial serial) : base(serial)
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

    public class ChroniclesOfTheKhan : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Khan", "Temüjin (Genghis Khan)",
            new BookPageInfo
            (
                "In the Year of the Iron",
                "Horse, I, Temüjin,",
                "rose from the blue",
                "Mongol steppe. Clanless,",
                "hunted, I became Genghis",
                "Khan. My name is the",
                "echo of hooves in the",
                "grasslands."
            ),
            new BookPageInfo
            (
                "I united the tribes—",
                "Tayichi’ud, Kereit,",
                "Naiman, Merkit, Tatar.",
                "Where once there was",
                "discord, now one banner",
                "rides the wind. We are",
                "the horse and the bow.",
                "We are the storm."
            ),
            new BookPageInfo
            (
                "My empire spread like",
                "the great herds: swift,",
                "unstoppable. Silk Road,",
                "desert, mountain, river—",
                "all knew the thunder",
                "of Mongol hooves. Cities",
                "fell. Walls crumbled. The",
                "old world ended."
            ),
            new BookPageInfo
            (
                "But I honored the",
                "wise, welcomed the",
                "faithful, protected",
                "merchants, and punished",
                "the greedy. My Yassa",
                "bound all to law and",
                "order. In the Mongol",
                "camp, all men are equal."
            ),
            new BookPageInfo
            (
                "My sons and daughters",
                "carried my will past",
                "sunrise and sunset. The",
                "Great Khanate stretches",
                "beyond the imagination.",
                "But unity, like grass,",
                "must be tended or it",
                "dies."
            ),
            new BookPageInfo
            (
                "Remember, traveler, the",
                "steppe remembers you.",
                "You ride where khans",
                "once rode. Honor the",
                "spirits of the land, and",
                "the wind will carry",
                "your name as it carried",
                "mine."
            ),
            new BookPageInfo
            (
                "This chest is not just",
                "gold and steel. It is a",
                "legacy. Let it remind",
                "you: all empires end,",
                "but the story of the",
                "steppe endures.",
                "",
                "- Genghis Khan"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheKhan() : base(false)
        {
            Hue = 1161; // Regal gold
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Khan");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Khan");
        }

        public ChroniclesOfTheKhan(Serial serial) : base(serial) { }

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
