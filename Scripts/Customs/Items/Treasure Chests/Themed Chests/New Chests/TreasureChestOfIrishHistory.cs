using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfIrishHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfIrishHistory()
        {
            Name = "Treasure Chest of Irish History";
            Hue = 1266; // Deep emerald green

            // Add items to the chest
            AddItem(CreateDecorativeArtifact("Replica of the Book of Kells", typeof(BookOfTruthArtifact), 2122), 0.15);
            AddItem(CreateDecorativeArtifact("Harp of the Dagda", typeof(Lute), 1166), 0.12);
            AddItem(CreateDecorativeArtifact("Fragment of the Blarney Stone", typeof(DecoRock), 2406), 0.18);
            AddItem(CreateDecorativeArtifact("Lugh’s Shining Medallion", typeof(RibbonAward), 1157), 0.15);
            AddItem(CreateDecorativeArtifact("Claddagh Ring", typeof(GoldRing), 1193), 0.20);
            AddItem(CreateDecorativeArtifact("St. Patrick’s Crozier", typeof(BlackStaff), 65), 0.08);
            AddItem(CreateDecorativeArtifact("Stone of Tara", typeof(DecoRock2), 2002), 0.10);
            AddItem(CreateDecorativeArtifact("Replica of the Tara Brooch", typeof(GoldBracelet), 2413), 0.13);
            AddItem(CreateDecorativeArtifact("Tuatha Dé Danann Statuette", typeof(GolemStatuette), 1266), 0.11);

            AddItem(CreateUniqueWeapon(), 0.24);
            AddItem(CreateUniqueArmor(), 0.20);
            AddItem(CreateUniqueCloak(), 0.18);
            AddItem(CreateUniqueBoots(), 0.18);

            AddItem(CreateConsumable("Faerie Mead", typeof(RandomFancyPotion), 68), 0.20);
            AddItem(CreateConsumable("Salmon of Knowledge", typeof(FishSteak), 2500), 0.15);
            AddItem(CreateConsumable("Potato Bread of Stamina", typeof(BreadLoaf), 1153), 0.19);

            AddItem(CreateGoldItem("Celtic Gold Torc"), 0.22);
            AddItem(new AnnalsOfTheEmeraldIsle(), 1.0);
            AddItem(new Gold(Utility.Random(2500, 5500)), 0.15);
            AddItem(CreateMap(), 0.07);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateDecorativeArtifact(string name, Type type, int hue)
        {
            Item item = Activator.CreateInstance(type) as Item;
            if (item != null)
            {
                item.Name = name;
                item.Hue = hue;
            }
            return item;
        }

        private Item CreateConsumable(string name, Type type, int hue)
        {
            Item item = Activator.CreateInstance(type) as Item;
            if (item != null)
            {
                item.Name = name;
                item.Hue = hue;
            }
            return item;
        }

        private Item CreateGoldItem(string name)
        {
            Gold gold = new Gold();
            gold.Name = name;
            return gold;
        }

        private Item CreateUniqueWeapon()
        {
            // Legendary Irish weapons!
            switch (Utility.Random(3))
            {
                case 0:
                    {
                        Longsword sword = new Longsword();
                        sword.Name = "Sword of Nuada";
                        sword.Hue = 1150;
                        sword.MinDamage = 45;
                        sword.MaxDamage = 80;
                        sword.WeaponAttributes.HitLeechMana = 18;
                        sword.WeaponAttributes.HitLightning = 15;
                        sword.WeaponAttributes.SelfRepair = 6;
                        sword.Attributes.BonusStr = 10;
                        sword.Attributes.AttackChance = 12;
                        sword.Attributes.WeaponSpeed = 20;
                        sword.SkillBonuses.SetValues(0, SkillName.Swords, 12.5);
                        XmlAttach.AttachTo(sword, new XmlLevelItem());
                        return sword;
                    }
                case 1:
                    {
                        Spear spear = new Spear();
                        spear.Name = "Spear of Lugh";
                        spear.Hue = 1367;
                        spear.MinDamage = 55;
                        spear.MaxDamage = 95;
                        spear.WeaponAttributes.HitFireball = 25;
                        spear.WeaponAttributes.HitHarm = 13;
                        spear.WeaponAttributes.UseBestSkill = 1;
                        spear.Attributes.BonusDex = 15;
                        spear.Attributes.WeaponDamage = 25;
                        spear.SkillBonuses.SetValues(0, SkillName.Fencing, 13.0);
                        XmlAttach.AttachTo(spear, new XmlLevelItem());
                        return spear;
                    }
                case 2:
                    {
                        BlackStaff staff = new BlackStaff();
                        staff.Name = "Staff of the Druid Kings";
                        staff.Hue = 2122;
                        staff.MinDamage = 30;
                        staff.MaxDamage = 60;
                        staff.WeaponAttributes.HitMagicArrow = 22;
                        staff.WeaponAttributes.MageWeapon = 1;
                        staff.Attributes.SpellChanneling = 1;
                        staff.Attributes.BonusMana = 12;
                        staff.Attributes.CastRecovery = 3;
                        staff.Attributes.LowerManaCost = 18;
                        staff.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
                        staff.SkillBonuses.SetValues(1, SkillName.Meditation, 8.0);
                        XmlAttach.AttachTo(staff, new XmlLevelItem());
                        return staff;
                    }
            }
            return null;
        }

        private Item CreateUniqueArmor()
        {
            // Ancient Celtic armor!
            switch (Utility.Random(3))
            {
                case 0:
                    {
                        PlateChest chest = new PlateChest();
                        chest.Name = "Ancient Celtic Plate";
                        chest.Hue = 2002;
                        chest.BaseArmorRating = 55;
                        chest.Attributes.BonusHits = 25;
                        chest.Attributes.BonusStam = 12;
                        chest.ArmorAttributes.LowerStatReq = 30;
                        chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
                        chest.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
                        XmlAttach.AttachTo(chest, new XmlLevelItem());
                        return chest;
                    }
                case 1:
                    {
                        LeatherDo armor = new LeatherDo();
                        armor.Name = "Druidic Leather Armor";
                        armor.Hue = 1166;
                        armor.BaseArmorRating = 38;
                        armor.Attributes.BonusMana = 18;
                        armor.Attributes.LowerManaCost = 10;
                        armor.ArmorAttributes.MageArmor = 1;
                        armor.SkillBonuses.SetValues(0, SkillName.Meditation, 12.0);
                        armor.SkillBonuses.SetValues(1, SkillName.Healing, 8.0);
                        XmlAttach.AttachTo(armor, new XmlLevelItem());
                        return armor;
                    }
                case 2:
                    {
                        ChainCoif helm = new ChainCoif();
                        helm.Name = "Helm of Cú Chulainn";
                        helm.Hue = 1164;
                        helm.BaseArmorRating = 32;
                        helm.Attributes.BonusStr = 10;
                        helm.Attributes.RegenHits = 5;
                        helm.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
                        helm.SkillBonuses.SetValues(1, SkillName.Bushido, 8.0);
                        XmlAttach.AttachTo(helm, new XmlLevelItem());
                        return helm;
                    }
            }
            return null;
        }

        private Item CreateUniqueCloak()
        {
            Cloak cloak = new Cloak();
            cloak.Name = "Cloak of the Tuatha Dé Danann";
            cloak.Hue = 1266;
            cloak.Attributes.Luck = 100;
            cloak.Attributes.NightSight = 1;
            cloak.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            cloak.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(cloak, new XmlLevelItem());
            return cloak;
        }

        private Item CreateUniqueBoots()
        {
            Boots boots = new Boots();
            boots.Name = "Boots of the Sidhe";
            boots.Hue = 1153;
            boots.Attributes.BonusDex = 15;
            boots.Attributes.RegenStam = 6;
            boots.SkillBonuses.SetValues(0, SkillName.Hiding, 10.0);
            boots.SkillBonuses.SetValues(1, SkillName.Stealth, 8.0);
            XmlAttach.AttachTo(boots, new XmlLevelItem());
            return boots;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map of the Hill of Tara";
            map.Bounds = new Rectangle2D(1700, 1400, 500, 500);
            map.NewPin = new Point2D(1850, 1650);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfIrishHistory(Serial serial) : base(serial) { }

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

    // Custom Lore Book
    public class AnnalsOfTheEmeraldIsle : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Annals of the Emerald Isle", "Seanchai of Tara",
            new BookPageInfo
            (
                "In misted dawns and twilight's gold,",
                "The isle of Eire’s tale unfolds.",
                "From Fomorian shades and Faerie hosts,",
                "To warrior kings and saintly ghosts."
            ),
            new BookPageInfo
            (
                "The Tuatha Dé Danann once held sway,",
                "Bright magic in the ancient clay.",
                "With spear and harp, and wisdom keen,",
                "They ruled the lands of emerald green."
            ),
            new BookPageInfo
            (
                "Great Lugh of the Long Arm fought,",
                "With Nuada’s sword and skills he brought.",
                "Cú Chulainn, hound of Ulster, bold,",
                "His deeds in song forever told."
            ),
            new BookPageInfo
            (
                "The Hill of Tara crowned the kings,",
                "Where Stone of Destiny still sings.",
                "St. Patrick, staff in hand, arose,",
                "And banished serpents, legend goes."
            ),
            new BookPageInfo
            (
                "Through Viking raid and Norman steel,",
                "Through famine’s blight and battle’s wheel,",
                "The heart of Eire, fierce and strong,",
                "Survived in story, faith, and song."
            ),
            new BookPageInfo
            (
                "Let those who seek this chest recall:",
                "Great treasures rise, great empires fall.",
                "But Ireland’s spirit, wild and free,",
                "Endures in stone, and sky, and sea."
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public AnnalsOfTheEmeraldIsle() : base(false)
        {
            Hue = 1266; // Emerald green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Annals of the Emerald Isle");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Annals of the Emerald Isle");
        }

        public AnnalsOfTheEmeraldIsle(Serial serial) : base(serial) { }

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
