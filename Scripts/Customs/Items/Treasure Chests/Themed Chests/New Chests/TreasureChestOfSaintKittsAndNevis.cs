using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSaintKittsAndNevis : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSaintKittsAndNevis()
        {
            Name = "Treasure Chest of Saint Kitts and Nevis";
            Hue = 1164; // Deep Caribbean blue

            AddItem(CreateDecor("ArtifactLargeVase", "Sugarcane Vase", 2129), 0.22);
            AddItem(CreateDecor("WolfStatue", "Monkey Idol of Nevis Peak", 1175), 0.16);
            AddItem(CreateDecor("BrazierArtifact", "Brimstone Hill Beacon", 1109), 0.13);
            AddItem(CreateDecor("SakeArtifact", "Bottle of Kittitian Rum", 1154), 0.22);
            AddItem(CreateDecor("Painting3Artifact", "Portrait of the Black Sands", 1102), 0.18);
            AddItem(CreateNamedItem<GoldBracelet>("Golden Doubloon Bracelet"), 0.21);
            AddItem(new ChroniclesOfTheTwinIsles(), 1.0);
            AddItem(CreateGoldItem("Sugarcane Coin"), 0.13);
            AddItem(CreateColoredItem<Apple>("Nevisian Mango", 1417), 0.18);
            AddItem(CreateColoredItem<Grapes>("Sea-Grape Cluster", 1378), 0.15);
            AddItem(CreateColoredItem<GreaterHealPotion>("Pirate's Coconut Elixir", 1160), 0.17);
            AddItem(CreateDecor("SmallUrn", "Ashes of the Last Carib", 2424), 0.13);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateWeapon(), 0.20);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateBoots(), 0.18);
            AddItem(CreatePirateHat(), 0.20);
            AddItem(CreateRobe(), 0.19);
            AddItem(CreateDagger(), 0.16);
            AddItem(CreateDecor("FanWestArtifact", "West Indies Fan", 1167), 0.11);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        // Helper to create decorative items by type/name/hue
        private Item CreateDecor(string typeName, string name, int hue)
        {
            var item = (Item)Activator.CreateInstance(Type.GetType("Server.Items." + typeName));
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            gold.Amount = Utility.RandomMinMax(1000, 3000);
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

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to Brimstone Hill Fortress";
            map.Bounds = new Rectangle2D(5500, 2100, 250, 250);
            map.NewPin = new Point2D(5625, 2225);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            // A cutlass, of course!
            Cutlass weapon = new Cutlass();
            weapon.Name = "Cutlass of Brimstone Hill";
            weapon.Hue = 1175; // Gold
            weapon.MinDamage = 30;
            weapon.MaxDamage = 68;
            weapon.Attributes.BonusStr = 10;
            weapon.Attributes.WeaponSpeed = 30;
            weapon.Attributes.WeaponDamage = 50;
            weapon.Attributes.Luck = 250;
            weapon.WeaponAttributes.HitLeechHits = 15;
            weapon.WeaponAttributes.HitLightning = 20;
            weapon.WeaponAttributes.HitHarm = 10;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Parry, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            PlateChest armor = new PlateChest();
            armor.Name = "Colonial Guard Breastplate";
            armor.Hue = 1102; // Black volcanic
            armor.BaseArmorRating = 50;
            armor.ArmorAttributes.LowerStatReq = 20;
            armor.Attributes.BonusHits = 25;
            armor.Attributes.BonusStam = 10;
            armor.Attributes.Luck = 150;
            armor.ArmorAttributes.SelfRepair = 5;
            armor.SkillBonuses.SetValues(0, SkillName.Tactics, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Sugar Baron's Boots";
            boots.Hue = 2129; // Sugarcane gold
            boots.Attributes.Luck = 150;
            boots.Attributes.BonusDex = 8;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 10.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreatePirateHat()
        {
            TricorneHat hat = new TricorneHat();
            hat.Name = "Nevisian Pirate Captain's Hat";
            hat.Hue = 1160; // Sea green
            hat.Attributes.BonusInt = 10;
            hat.Attributes.NightSight = 1;
            hat.SkillBonuses.SetValues(0, SkillName.Stealing, 15.0);
            hat.SkillBonuses.SetValues(1, SkillName.Snooping, 12.0);
            hat.SkillBonuses.SetValues(2, SkillName.Tactics, 7.0);
            XmlAttach.AttachTo(hat, new XmlLevelItem());
            return hat;
        }

        private Item CreateRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Nevisian Voodoo Robe";
            robe.Hue = 2101; // Magickal purple
            robe.Attributes.RegenMana = 3;
            robe.Attributes.BonusMana = 18;
            robe.Attributes.CastRecovery = 2;
            robe.Attributes.CastSpeed = 1;
            robe.SkillBonuses.SetValues(0, SkillName.Magery, 12.0);
            robe.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 12.0);
            robe.SkillBonuses.SetValues(2, SkillName.MagicResist, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Carib Obsidian Ritual Knife";
            dagger.Hue = 2424; // Obsidian black
            dagger.MinDamage = 22;
            dagger.MaxDamage = 55;
            dagger.Attributes.BonusHits = 12;
            dagger.Attributes.ReflectPhysical = 10;
            dagger.WeaponAttributes.HitPoisonArea = 15;
            dagger.WeaponAttributes.SelfRepair = 5;
            dagger.SkillBonuses.SetValues(0, SkillName.Anatomy, 10.0);
            dagger.SkillBonuses.SetValues(1, SkillName.Poisoning, 10.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        public TreasureChestOfSaintKittsAndNevis(Serial serial) : base(serial) { }

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

    public class ChroniclesOfTheTwinIsles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of the Twin Isles", "Captain Lucien Sable",
            new BookPageInfo
            (
                "Upon these emerald shores,",
                "the salt wind whispers tales",
                "older than the colonial ships.",
                "Here, the Carib walked,",
                "spirits guided by the volcano,",
                "Nevis Peak. Rivers of sugar",
                "ran, and rum flowed free.",
                "A bounty for the bold."
            ),
            new BookPageInfo
            (
                "The French and English flags",
                "fought for the heart of Kitts.",
                "Fortresses rose, cannons roared,",
                "slaves toiled in the cane.",
                "Buccaneers haunted the coves,",
                "while merchants bartered gold.",
                "Salt, sugar, and souls traded",
                "hands beneath the tropic sun."
            ),
            new BookPageInfo
            (
                "The volcano remembers all.",
                "Brimstone Hill stands eternal,",
                "witness to every invasion.",
                "Legends say pirate gold",
                "still sleeps in black sand,",
                "and spirits in the mango",
                "groves sing to those who",
                "listen under moonlight."
            ),
            new BookPageInfo
            (
                "Twin isles, twin destinies.",
                "Nevis' hot springs heal the",
                "body; Kitts' jungles feed the",
                "soul. Together, they survive",
                "storms and time. The sea",
                "gives and takes, but the",
                "heart of the islands beats",
                "on, fierce and free."
            ),
            new BookPageInfo
            (
                "To the seeker of this chest:",
                "May you find the courage of",
                "the Carib, the luck of the",
                "pirate, and the wisdom of",
                "the elders. Remember, some",
                "treasures belong to the earth.",
                "Disturb not the sacred, and",
                "the isles may grant you peace."
            ),
            new BookPageInfo
            (
                "",
                "— Captain Lucien Sable,",
                "Keeper of the Hidden History",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfTheTwinIsles() : base(false)
        {
            Hue = 1164; // Caribbean blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of the Twin Isles");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of the Twin Isles");
        }

        public ChroniclesOfTheTwinIsles(Serial serial) : base(serial) { }

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
