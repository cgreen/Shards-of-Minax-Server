using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfSaintVincent : WoodenChest
    {
        [Constructable]
        public TreasureChestOfSaintVincent()
        {
            Name = "Treasure Chest of Saint Vincent and the Grenadines";
            Hue = 2065; // Oceanic blue/green

            // Add unique items to the chest
            AddItem(CreateDecorative<ArtifactLargeVase>("Vessel of the Island Ancients", 1266), 0.18);
            AddItem(CreateDecorative<WolfStatue>("Spirit Wolf of Hairouna", 2125), 0.12);
            AddItem(CreateDecorative<RandomFancyCoin>("Pirate's Escudo", 2418), 0.25);
            AddItem(CreateDecorative<ArtifactVase>("Arawak Water Jar", 2001), 0.14);
            AddItem(CreateDecorative<Sandals>("Sandals of the Grenadine Sands", 2115), 0.20);

            AddItem(CreateConsumable<GreenTea>("Herbal Tea of the Rainforest", 1437), 0.22);
            AddItem(CreateConsumable<Banana>("Banana of Bequia", 55), 0.22);
            AddItem(CreateConsumable<Mango>("Mystic Mango", 2122), 0.17);
            AddItem(CreateConsumable<BottleArtifact>("Spiced Rum of the Buccaneers", 1151), 0.28);

            AddItem(CreateEquipment<Cloak>("Carib Shaman's Mantle", 2052), 0.18);
            AddItem(CreateEquipment<Bandana>("Bandana of the Buccaneer King", 1161), 0.20);
            AddItem(CreateEquipment<LongPants>("Sailor’s Sturdy Pants", 1175), 0.18);

            AddItem(CreateWeapon(), 0.22);
            AddItem(CreateArmor(), 0.22);
            AddItem(CreateUniqueShield(), 0.20);

            AddItem(new Gold(Utility.Random(2000, 5000)), 0.12);
            AddItem(new LostLogbookOfSaintVincent(), 1.0); // Custom lore book
            AddItem(CreateMap(), 0.06);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
                DropItem(item);
        }

        private Item CreateDecorative<T>(string name, int hue) where T : Item, new()
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
            if (item is Food f) f.FillFactor = Utility.RandomMinMax(6, 10); // make it filling
            return item;
        }

        private Item CreateEquipment<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            if (item is BaseClothing c)
            {
                c.Attributes.Luck = Utility.Random(20, 75);
                c.SkillBonuses.SetValues(0, SkillName.MagicResist, 10.0);
                c.SkillBonuses.SetValues(1, SkillName.Macing, 10.0);
                XmlAttach.AttachTo(c, new XmlLevelItem());
            }
            return item;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(new Cutlass(), new Scimitar(), new Dagger());
            weapon.Name = "Cutlass of Black Sands";
            weapon.Hue = 1167;
            weapon.MaxDamage = Utility.Random(40, 60);
            weapon.WeaponAttributes.HitLeechMana = 15;
            weapon.WeaponAttributes.HitFireball = 20;
            weapon.WeaponAttributes.HitLowerAttack = 15;
            weapon.WeaponAttributes.UseBestSkill = 1;
            weapon.Attributes.BonusStam = 10;
            weapon.Attributes.BonusHits = 8;
            weapon.Attributes.WeaponSpeed = 20;
            weapon.Slayer = SlayerName.ReptilianDeath;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Fencing, 10.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(new LeatherChest(), new PlateHelm(), new LeatherLegs());
            armor.Name = "Shell Armor of the Carib Warlord";
            armor.Hue = 2101;
            armor.BaseArmorRating = Utility.Random(40, 70);
            armor.ArmorAttributes.SelfRepair = 4;
            armor.ArmorAttributes.MageArmor = 1;
            armor.ArmorAttributes.LowerStatReq = 15;
            armor.Attributes.Luck = 40;
            armor.Attributes.BonusDex = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 15.0);
            armor.SkillBonuses.SetValues(1, SkillName.Healing, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateUniqueShield()
        {
            WoodenShield shield = new WoodenShield();
            shield.Name = "Turtle Shell Shield of the Grenadines";
            shield.Hue = 2108;
            shield.ArmorAttributes.SelfRepair = 3;
            shield.Attributes.DefendChance = 15;
            shield.Attributes.BonusStam = 12;
            shield.SkillBonuses.SetValues(0, SkillName.Parry, 20.0);
            shield.SkillBonuses.SetValues(1, SkillName.Fishing, 8.0);
            XmlAttach.AttachTo(shield, new XmlLevelItem());
            return shield;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Lost Caves of Hairouna";
            map.Bounds = new Rectangle2D(3500, 2400, 400, 350); // Example coords
            map.NewPin = new Point2D(3620, 2650);
            map.Protected = true;
            return map;
        }

        public TreasureChestOfSaintVincent(Serial serial) : base(serial) { }

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

    // ---- Custom Lore Book ----
    public class LostLogbookOfSaintVincent : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Lost Logbook of Saint Vincent", "Captain Jean-Louis DuVal",
            new BookPageInfo
            (
                "12th March, 1700",
                "We have anchored off the",
                "verdant shores of Hairouna,",
                "known to the English as Saint",
                "Vincent. The Carib warriors",
                "watch us from the forest,",
                "their faces painted for war."
            ),
            new BookPageInfo
            (
                "This land is older than",
                "any chart. The Arawaks tell",
                "tales of mountain spirits,",
                "of Soufrière’s fury, and",
                "caves that swallow the",
                "sun itself. The jungle",
                "hides treasures and curses."
            ),
            new BookPageInfo
            (
                "We traded beads and iron",
                "tools for fruit, cassava,",
                "and the wisdom of their",
                "shamans. Yet, not all",
                "welcomed us. Last night,",
                "our sentry vanished—some",
                "say taken by the 'Jabless'."
            ),
            new BookPageInfo
            (
                "On Bequia and Mustique,",
                "the pirates dig deep,",
                "seeking Spanish gold and",
                "runaway slaves find",
                "refuge. The isles are",
                "a tapestry of legend and",
                "loss. I have hidden my",
                "own prize here, God willing."
            ),
            new BookPageInfo
            (
                "Let it be known: the",
                "Carib people, fierce and",
                "free, refuse all masters.",
                "The British and French",
                "fight for dominion, but the",
                "islands remain wild—",
                "the spirits stronger than",
                "any fleet or king."
            ),
            new BookPageInfo
            (
                "I have mapped the",
                "entrance to the caves. If",
                "you have found this book,",
                "seek not just gold but",
                "knowledge. May you honor",
                "the ancestors of these",
                "isles. Beware the wrath of",
                "La Soufrière’s fire."
            ),
            new BookPageInfo
            (
                "May this logbook keep",
                "the memory of the people,",
                "the storms, and the riches",
                "of Saint Vincent and the",
                "Grenadines. May you carry",
                "their stories as you take",
                "my treasure.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "Signed,",
                "Captain Jean-Louis DuVal,",
                "Last of the Free Traders,",
                "1700 AD",
                "",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public LostLogbookOfSaintVincent() : base(false)
        {
            Hue = 1266; // Caribbean azure
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Lost Logbook of Saint Vincent");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Lost Logbook of Saint Vincent");
        }

        public LostLogbookOfSaintVincent(Serial serial) : base(serial) { }

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
