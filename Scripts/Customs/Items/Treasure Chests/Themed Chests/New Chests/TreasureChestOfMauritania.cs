using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfMauritania : WoodenChest
    {
        [Constructable]
        public TreasureChestOfMauritania()
        {
            Name = "Treasure Chest of Mauritania";
            Hue = 2125; // Sand-gold color

            // Add items to the chest
            AddItem(new DesertRoseGem(), 0.20);
            AddItem(CreateSaltIngot(), 0.18);
            AddItem(CreateColoredItem<GreaterHealPotion>("Blue Well Elixir", 1132), 0.12);
            AddItem(CreateNamedItem<GoldBracelet>("Tagant Gold Cuff"), 0.33);
            AddItem(CreateNamedItem<Sandals>("Nomad's Indigo Sandals"), 0.25);
            AddItem(CreateMap(), 0.08);
            AddItem(CreateBook(), 1.0);
            AddItem(CreateNamedItem<RandomFancyBanner>("Banner of Chinguetti"), 0.16);
            AddItem(CreateDecorativeBook(), 0.11);
            AddItem(CreateNamedItem<RandomFancyCoin>("Salt Bar Coin"), 0.19);
            AddItem(CreateColoredItem<WolfStatue>("Ancient Saharan Idol", 1154), 0.10);
            AddItem(CreateWeapon(), 0.19);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateClothing(), 0.21);
            AddItem(CreateHeadgear(), 0.19);
            AddItem(CreateDagger(), 0.15);
            AddItem(CreateConsumable(), 0.18);
            AddItem(new Gold(Utility.Random(1, 5000)), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateSaltIngot()
        {
            DecoSalt salt = new DecoSalt(); // Or you can use an ingot item and rename/hue it
            salt.Name = "Ingot of Taghaza Salt";
            salt.Hue = 2498; // White-salt color
            return salt;
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
            map.Name = "Map of the Lost City of Oualata";
            map.Bounds = new Rectangle2D(2600, 2900, 250, 350);
            map.NewPin = new Point2D(2730, 3100);
            map.Protected = true;
            return map;
        }

        private Item CreateDecorativeBook()
        {
            AcademicBooksArtifact book = new AcademicBooksArtifact();
            book.Name = "Saharan Manuscript: Kitab al-Baraka";
            book.Hue = 2117;
            return book;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = new Scimitar();
            weapon.Name = "Saif of the Salt Road";
            weapon.Hue = 1175; // Pale gold
            weapon.MaxDamage = Utility.Random(42, 78);
            weapon.MinDamage = Utility.Random(21, 38);
            weapon.Attributes.BonusStam = 20;
            weapon.Attributes.BonusStr = 8;
            weapon.Attributes.BonusHits = 20;
            weapon.Attributes.AttackChance = 12;
            weapon.WeaponAttributes.HitLeechStam = 25;
            weapon.WeaponAttributes.HitFireArea = 8;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 10.0);
            weapon.SkillBonuses.SetValues(1, SkillName.Anatomy, 6.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = new LeatherDo();
            armor.Name = "Camelhide Vest of Chinguetti";
            armor.Hue = 1412; // Desert leather color
            armor.BaseArmorRating = Utility.Random(38, 67);
            armor.Attributes.BonusHits = 18;
            armor.Attributes.LowerManaCost = 8;
            armor.SkillBonuses.SetValues(0, SkillName.Meditation, 9.0);
            armor.SkillBonuses.SetValues(1, SkillName.Parry, 7.0);
            armor.ArmorAttributes.SelfRepair = 6;
            armor.ColdBonus = 12;
            armor.FireBonus = 18;
            armor.PoisonBonus = 7;
            armor.EnergyBonus = 7;
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateClothing()
        {
            Robe robe = new Robe();
            robe.Name = "Blue Turban Robe of the Moor";
            robe.Hue = 1266;
            robe.Attributes.Luck = 40;
            robe.Attributes.BonusInt = 8;
            robe.SkillBonuses.SetValues(0, SkillName.ItemID, 10.0);
            robe.SkillBonuses.SetValues(1, SkillName.MagicResist, 8.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        private Item CreateHeadgear()
        {
            Bandana headgear = new Bandana();
            headgear.Name = "Imuhagh Indigo Tagelmust";
            headgear.Hue = 1329;
            headgear.Attributes.NightSight = 1;
            headgear.Attributes.BonusDex = 15;
            headgear.Attributes.RegenHits = 2;
            headgear.SkillBonuses.SetValues(0, SkillName.Stealth, 12.0);
            headgear.SkillBonuses.SetValues(1, SkillName.Hiding, 12.0);
            XmlAttach.AttachTo(headgear, new XmlLevelItem());
            return headgear;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Tichitt Knife of the Ancients";
            dagger.Hue = 2506; // Bone/ivory color
            dagger.MinDamage = Utility.Random(13, 35);
            dagger.MaxDamage = Utility.Random(38, 68);
            dagger.Attributes.BonusHits = 12;
            dagger.Attributes.ReflectPhysical = 12;
            dagger.WeaponAttributes.HitDispel = 9;
            dagger.WeaponAttributes.SelfRepair = 7;
            dagger.SkillBonuses.SetValues(0, SkillName.Poisoning, 8.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateConsumable()
        {
            // A unique desert drink
            GreenTeaBasket tea = new GreenTeaBasket();
            tea.Name = "Saharan Mint Tea";
            tea.Hue = 1176;
            return tea;
        }

        private Item CreateBook()
        {
            return new SongOfTheSaharaChronicles();
        }

        public TreasureChestOfMauritania(Serial serial) : base(serial) { }

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

    public class DesertRoseGem : Diamond
    {
        [Constructable]
        public DesertRoseGem()
        {
            Name = "Desert Rose Gem";
            Hue = 2100;
        }

        public DesertRoseGem(Serial serial) : base(serial) { }

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

    public class DecoSalt : Gold
    {
        [Constructable]
        public DecoSalt()
        {
            Name = "Salt of Taghaza";
            Hue = 2498;
        }

        public DecoSalt(Serial serial) : base(serial) { }

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

    public class SongOfTheSaharaChronicles : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Song of the Sahara: Chronicles of Mauritania", "Tariq al-Tagant",
            new BookPageInfo
            (
                "From the dawn of the desert",
                "to the tides of the Atlantic,",
                "Mauritania has carried the",
                "wind’s whisper in its soul.",
                "From the ancient herders of",
                "Tichitt to the stone cities",
                "of Ouadane and Chinguetti,",
                "stories gather like sand."
            ),
            new BookPageInfo
            (
                "Here, Berber tribes guided",
                "caravans of salt and gold,",
                "linking Ghana, Mali, and",
                "beyond. Across endless dunes,",
                "the blue-robed Imuhagh and",
                "Sanhaja made their lives—",
                "proud, unbowed, and fleet as",
                "gazelle under the Saharan sun."
            ),
            new BookPageInfo
            (
                "Scholars wrote in script of",
                "light, preserving wisdom as",
                "Islam spread through Chinguetti,",
                "the 'City of Libraries.'",
                "Minarets rose from dust, and",
                "pilgrims knelt on shifting",
                "ground, learning faith and",
                "law beneath date palms."
            ),
            new BookPageInfo
            (
                "French banners swept in with",
                "the trade winds, but the soul",
                "of the desert never bent. The",
                "people endure in every grain",
                "of salt, every drop of mint",
                "tea, every tune on the tidinit,",
                "every word in the Qur'an,",
                "every footstep on ancient stone."
            ),
            new BookPageInfo
            (
                "Seek not just treasure but the",
                "wisdom of the dunes. For what",
                "is lost in the sands returns",
                "with the wind. May this chest",
                "carry the memory of Mauritania",
                "for all who open its heavy lid.",
                "",
                "- Tariq al-Tagant"
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public SongOfTheSaharaChronicles() : base(false)
        {
            Hue = 2117; // Antique leather
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Song of the Sahara: Chronicles of Mauritania");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Song of the Sahara: Chronicles of Mauritania");
        }

        public SongOfTheSaharaChronicles(Serial serial) : base(serial) { }

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
