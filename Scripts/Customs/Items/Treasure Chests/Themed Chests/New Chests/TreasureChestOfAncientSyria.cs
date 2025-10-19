using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfAncientSyria : WoodenChest
    {
        [Constructable]
        public TreasureChestOfAncientSyria()
        {
            Name = "Treasure Chest of Ancient Syria";
            Hue = 2409; // sandy gold

            // Add items to the chest
            AddItem(new PhoenicianScroll(), 0.10);
            AddItem(CreateLapisLazuli(), 0.18);
            AddItem(CreateColoredItem<GreaterCurePotion>("Elixir of Ugaritic Healing", 1175), 0.18);
            AddItem(CreateNamedItem<Sandals>("Sandals of the Palmyrene Queen"), 0.19);
            AddItem(CreateNamedItem<GoldBracelet>("Bracelet of the Sun God Shamash"), 0.25);
            AddItem(new ChroniclesOfSyria(), 1.0);
            AddItem(new Gold(Utility.Random(2000, 3500)), 0.12);
            AddItem(CreateColoredItem<Ruby>("Ruby of Damascus", 1157), 0.15);
            AddItem(CreateNamedItem<GreaterStrengthPotion>("Potion of Baal's Might"), 0.13);
            AddItem(CreateGoldItem("Syrian Stater Coin"), 0.14);
            AddItem(CreateColoredItem<Cloak>("Cloak of Ebla's Oracle", 1166), 0.20);
            AddItem(CreateNamedItem<GoldEarrings>("Golden Crescent Earring"), 0.17);
            AddItem(CreateMap(), 0.05);
            AddItem(CreateNamedItem<Sextant>("Navigator’s Astrolabe of Ugarit"), 0.09);
            AddItem(CreateNamedItem<GreaterHealPotion>("Damascene Rose Tonic"), 0.20);
            AddItem(CreateWeapon(), 0.23);
            AddItem(CreateArmor(), 0.19);
            AddItem(CreateTunic(), 0.16);
            AddItem(CreateBascinet(), 0.16);
            AddItem(CreateDagger(), 0.21);
            AddItem(CreateDecorativeRelic(), 0.25);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        private Item CreateLapisLazuli()
        {
            Sapphire lapis = new Sapphire();
            lapis.Name = "Lapis Lazuli of Mari";
            lapis.Hue = 1266; // deep blue
            return lapis;
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
            note.NoteString = "O traveler, these lands once flourished beneath the banners of kings both wise and cruel. Know that the sands whisper of forgotten glories and old wounds.";
            note.TitleString = "The Desert's Secret";
            return note;
        }

        private Item CreateMap()
        {
            SimpleMap map = new SimpleMap();
            map.Name = "Map to the Temple of Bel (Palmyra)";
            map.Bounds = new Rectangle2D(4000, 2200, 400, 400);
            map.NewPin = new Point2D(4200, 2300);
            map.Protected = true;
            return map;
        }

        private Item CreateWeapon()
        {
            BaseWeapon weapon = Utility.RandomList<BaseWeapon>(
                new Scimitar(), new Longsword(), new Katana(), new Kryss()
            );
            weapon.Name = "Sword of Ashur";
            weapon.Hue = 1281; // iron/steel blue
            weapon.MaxDamage = Utility.Random(32, 65);
            weapon.Attributes.WeaponSpeed = 15;
            weapon.Attributes.WeaponDamage = 20;
            weapon.SkillBonuses.SetValues(0, SkillName.Swords, 15.0);
            XmlAttach.AttachTo(weapon, new XmlLevelItem());
            return weapon;
        }

        private Item CreateArmor()
        {
            BaseArmor armor = Utility.RandomList<BaseArmor>(
                new PlateChest(), new PlateArms(), new PlateLegs(), new PlateHelm()
            );
            armor.Name = "Plate of the Hittite Warlord";
            armor.Hue = 2125; // bronze/gold
            armor.BaseArmorRating = Utility.Random(38, 62);
            armor.Attributes.BonusStr = 10;
            armor.ArmorAttributes.MageArmor = 1;
            armor.Attributes.BonusHits = 12;
            armor.SkillBonuses.SetValues(0, SkillName.Parry, 10.0);
            armor.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(armor, new XmlLevelItem());
            return armor;
        }

        private Item CreateTunic()
        {
            Tunic tunic = new Tunic();
            tunic.Name = "Tunic of the Aleppan Merchant";
            tunic.Hue = Utility.RandomMinMax(1160, 1190); // rich reds/yellows
            tunic.Attributes.Luck = 30;
            tunic.Attributes.BonusMana = 10;
            tunic.SkillBonuses.SetValues(0, SkillName.ItemID, 15.0);
            tunic.SkillBonuses.SetValues(1, SkillName.Hiding, 10.0);
            XmlAttach.AttachTo(tunic, new XmlLevelItem());
            return tunic;
        }

        private Item CreateBascinet()
        {
            Bascinet helm = new Bascinet();
            helm.Name = "Helmet of the Desert Guard";
            helm.Hue = 1825; // sun-worn gold
            helm.BaseArmorRating = Utility.Random(28, 49);
            helm.Attributes.NightSight = 1;
            helm.ArmorAttributes.LowerStatReq = 20;
            helm.Attributes.BonusDex = 20;
            helm.SkillBonuses.SetValues(0, SkillName.Archery, 10.0);
            helm.SkillBonuses.SetValues(1, SkillName.Anatomy, 10.0);
            helm.PhysicalBonus = 18;
            helm.FireBonus = 8;
            helm.PoisonBonus = 8;
            XmlAttach.AttachTo(helm, new XmlLevelItem());
            return helm;
        }

        private Item CreateDagger()
        {
            Dagger dagger = new Dagger();
            dagger.Name = "Dagger of the Aramaean Shadow";
            dagger.Hue = 2505;
            dagger.MinDamage = Utility.Random(18, 32);
            dagger.MaxDamage = Utility.Random(33, 65);
            dagger.Attributes.BonusStam = 8;
            dagger.Attributes.ReflectPhysical = 10;
            dagger.Slayer = SlayerName.ElementalBan;
            dagger.WeaponAttributes.HitPoisonArea = 15;
            dagger.WeaponAttributes.SelfRepair = 6;
            dagger.SkillBonuses.SetValues(0, SkillName.Stealth, 18.0);
            XmlAttach.AttachTo(dagger, new XmlLevelItem());
            return dagger;
        }

        private Item CreateDecorativeRelic()
        {
            Item relic = Utility.RandomList<Item>(
                CreateColoredItem<ArtifactLargeVase>("Bronze Urn of Ebla", 2125),
                CreateColoredItem<ArtifactVase>("Ivory Vase of Mari", 1153),
                CreateColoredItem<MedusaStatue>("Statue of the Goddess Astarte", 1107),
                CreateColoredItem<BrazierArtifact>("Sacred Flame of Palmyra", 1166),
                CreateColoredItem<BakeKitsuneStatue>("Guardian Jackal of the Oasis", 2515),
                CreateColoredItem<LibraryFriendLantern>("Lantern of Ancient Byblos", 1175)
            );
            return relic;
        }

        public TreasureChestOfAncientSyria(Serial serial) : base(serial)
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

    public class ChroniclesOfSyria : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Chronicles of Ancient Syria", "Scribe of the Sands",
            new BookPageInfo
            (
                "O seeker of fortune,",
                "know that these lands",
                "bore witness to the birth",
                "of empires. Ebla, Mari,",
                "and Ugarit rose from clay,",
                "built cities by the Euphrates,",
                "wrote tablets in cuneiform,",
                "traded cedar and lapis."
            ),
            new BookPageInfo
            (
                "In the halls of Aleppo,",
                "kings made pacts with gods.",
                "Palmyra's pillars reached the sun.",
                "Damascus, oldest of cities,",
                "watched conquerors come and go—",
                "Assyrians, Persians, Greeks,",
                "Romans, and caliphs.",
                ""
            ),
            new BookPageInfo
            (
                "The Queen Zenobia, proud, defiant,",
                "led armies against Rome.",
                "For a moment, Syria’s banner",
                "rose over Egypt and Asia.",
                "But the eagle of the West",
                "prevailed, and Palmyra’s glory",
                "faded to dust in the desert wind.",
                ""
            ),
            new BookPageInfo
            (
                "Yet the spirit of Syria endures.",
                "Its soil hides treasures—",
                "tablets, golden statues,",
                "lost scripts, and ancient songs.",
                "May this chest and its wonders",
                "remind you: beneath the sand,",
                "the past yet breathes.",
                ""
            ),
            new BookPageInfo
            (
                "Take what you find,",
                "but remember the warning:",
                "The gods of old guard",
                "their secrets jealously.",
                "Some relics are gifts,",
                "others are curses.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "May wisdom guide you,",
                "and may the sun rise",
                "upon your path.",
                "",
                "- Scribe of the Sands",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public ChroniclesOfSyria() : base(false)
        {
            Hue = 1287; // lapis lazuli blue
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Chronicles of Ancient Syria");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Chronicles of Ancient Syria");
        }

        public ChroniclesOfSyria(Serial serial) : base(serial) { }

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

    public class PhoenicianScroll : MaxxiaScroll
    {
        [Constructable]
        public PhoenicianScroll()
        {
            Name = "Phoenician Scroll of Letters";
            Hue = 1109;
            LootType = LootType.Blessed;
        }

        public PhoenicianScroll(Serial serial) : base(serial) { }

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
}
