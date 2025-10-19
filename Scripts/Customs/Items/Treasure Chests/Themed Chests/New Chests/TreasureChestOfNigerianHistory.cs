using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class TreasureChestOfNigerianHistory : WoodenChest
    {
        [Constructable]
        public TreasureChestOfNigerianHistory()
        {
            Name = "Treasure Chest of Nigerian History";
            Hue = 1282; // Lush green - representing Nigeria's flag

            // Add items to the chest
            AddItem(CreateBeninBronzeMask(), 0.20);
            AddItem(CreateYorubaDivinationBowl(), 0.15);
            AddItem(CreateIgboUliStaff(), 0.12);
            AddItem(CreateObaCrown(), 0.10);
            AddItem(CreateZamfaraGoldIngot(), 0.17);
            AddItem(CreateBookOfNigerianLore(), 1.0);
            AddItem(new Gold(Utility.Random(1500, 6500)), 0.18);
            AddItem(CreateColoredItem<GreaterHealPotion>("Benin Queen Mother's Healing Brew", 2001), 0.10);
            AddItem(CreateNamedItem<BodySash>("Sash of the Wole Soyinka", 1902), 0.16);
            AddItem(CreateNamedItem<FeatheredHat>("Calabar King's Feathered Hat", 1416), 0.13);
            AddItem(CreateNokWarClub(), 0.20);
            AddItem(CreateNigerDeltaRobe(), 0.13);
            AddItem(CreatePlateArmorOfTheOba(), 0.17);
            AddItem(CreateThunderStrikeScepter(), 0.13);
            AddItem(CreateBiafraSurvivalRations(), 0.11);
            AddItem(CreateUnityPendant(), 0.15);
        }

        private void AddItem(Item item, double probability)
        {
            if (Utility.RandomDouble() < probability)
            {
                DropItem(item);
            }
        }

        // ---- Decorative/Artifact Items ----
        private Item CreateBeninBronzeMask()
        {
            ArtifactLargeVase mask = new ArtifactLargeVase();
            mask.Name = "Benin Bronze Royal Mask";
            mask.Hue = 2206; // Bronze
            mask.ItemID = 0x2B7B;
            return mask;
        }

        private Item CreateYorubaDivinationBowl()
        {
            BowlArtifact bowl = new BowlArtifact();
            bowl.Name = "Yoruba Ifá Divination Bowl";
            bowl.Hue = 2110;
            return bowl;
        }

        private Item CreateIgboUliStaff()
        {
            BlackStaff staff = new BlackStaff();
            staff.Name = "Igbo Uli Ritual Staff";
            staff.Hue = 1150;
            staff.WeaponAttributes.HitLeechMana = 25;
            staff.SkillBonuses.SetValues(0, SkillName.Magery, 12.5);
            staff.SkillBonuses.SetValues(1, SkillName.Meditation, 7.5);
            staff.Attributes.SpellDamage = 8;
            return staff;
        }

        private Item CreateObaCrown()
        {
            Circlet crown = new Circlet();
            crown.Name = "Oba's Ceremonial Crown";
            crown.Hue = 2125; // Gold
            crown.Attributes.Luck = 60;
            crown.Attributes.BonusInt = 10;
            crown.SkillBonuses.SetValues(0, SkillName.EvalInt, 12.5);
            return crown;
        }

        private Item CreateZamfaraGoldIngot()
        {
            GoldIngot gold = new GoldIngot();
            gold.Name = "Zamfara Royal Gold Ingot";
            gold.Hue = 1175;
            return gold;
        }

        private Item CreateUnityPendant()
        {
            GoldBracelet pendant = new GoldBracelet();
            pendant.Name = "Pendant of Unity";
            pendant.Hue = 1266;
            pendant.Attributes.RegenHits = 3;
            pendant.Attributes.LowerManaCost = 8;
            pendant.SkillBonuses.SetValues(0, SkillName.Peacemaking, 15.0);
            pendant.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            return pendant;
        }

        // ---- Equipment / Themed Gear ----
        private Item CreatePlateArmorOfTheOba()
        {
            PlateChest chest = new PlateChest();
            chest.Name = "Breastplate of the Oba";
            chest.Hue = 2125; // Royal gold
            chest.BaseArmorRating = Utility.Random(50, 70);
            chest.Attributes.BonusHits = 25;
            chest.Attributes.Luck = 50;
            chest.SkillBonuses.SetValues(0, SkillName.Tactics, 10.0);
            chest.SkillBonuses.SetValues(1, SkillName.Macing, 10.0);
            XmlAttach.AttachTo(chest, new XmlLevelItem());
            return chest;
        }

        private Item CreateNokWarClub()
        {
            Maul club = new Maul();
            club.Name = "Nok War Club";
            club.Hue = 1323;
            club.WeaponAttributes.HitPhysicalArea = 20;
            club.WeaponAttributes.HitFireball = 15;
            club.MinDamage = 45;
            club.MaxDamage = 78;
            club.Attributes.WeaponSpeed = 30;
            club.SkillBonuses.SetValues(0, SkillName.Anatomy, 8.0);
            club.SkillBonuses.SetValues(1, SkillName.Tactics, 10.0);
            XmlAttach.AttachTo(club, new XmlLevelItem());
            return club;
        }

        private Item CreateThunderStrikeScepter()
        {
            Scepter scepter = new Scepter();
            scepter.Name = "Scepter of Thunderstrike";
            scepter.Hue = 1407;
            scepter.WeaponAttributes.HitLightning = 30;
            scepter.WeaponAttributes.HitHarm = 10;
            scepter.MinDamage = 38;
            scepter.MaxDamage = 66;
            scepter.Attributes.SpellChanneling = 1;
            scepter.Attributes.SpellDamage = 15;
            scepter.SkillBonuses.SetValues(0, SkillName.Magery, 10.0);
            XmlAttach.AttachTo(scepter, new XmlLevelItem());
            return scepter;
        }

        private Item CreateNigerDeltaRobe()
        {
            Robe robe = new Robe();
            robe.Name = "Robe of the Niger Delta";
            robe.Hue = 1165;
            robe.Attributes.BonusMana = 15;
            robe.Attributes.RegenMana = 4;
            robe.Attributes.LowerManaCost = 10;
            robe.SkillBonuses.SetValues(0, SkillName.Fishing, 15.0);
            robe.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 10.0);
            XmlAttach.AttachTo(robe, new XmlLevelItem());
            return robe;
        }

        // ---- Consumables & Misc ----
        private Item CreateBiafraSurvivalRations()
        {
            Basket1Artifact basket = new Basket1Artifact();
            basket.Name = "Biafra Survival Rations";
            basket.Hue = 1109;
            return basket;
        }

        private Item CreateColoredItem<T>(string name, int hue) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            item.Hue = hue;
            return item;
        }

        private Item CreateNamedItem<T>(string name, int hue = 0) where T : Item, new()
        {
            T item = new T();
            item.Name = name;
            if (hue > 0)
                item.Hue = hue;
            return item;
        }

        // ---- Lore Book ----
        private Item CreateBookOfNigerianLore()
        {
            return new BookOfNigerianHistory();
        }

        public TreasureChestOfNigerianHistory(Serial serial) : base(serial)
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

    // ---- Lore Book Class ----
    public class BookOfNigerianHistory : BlueBook
    {
        public static readonly BookContent Content = new BookContent
        (
            "Book of Nigerian History", "Narrated by Olaudah",
            new BookPageInfo
            (
                "From the ancient Nok,",
                "masters of iron and earth,",
                "through kingdoms of Benin,",
                "Ife, Oyo, and Kanem,",
                "Nigeria's land has long",
                "teemed with kings, art,",
                "warriors and wise priests."
            ),
            new BookPageInfo
            (
                "Benin bronzes gleamed,",
                "Ife's glass beads shone,",
                "Yoruba masked dancers",
                "summoned spirits, while",
                "the Igbo built walls of",
                "Ngwo and Nri priests",
                "read the sky and earth."
            ),
            new BookPageInfo
            (
                "The Hausa states traded",
                "across the desert sands,",
                "Songhai's shadow fell",
                "as Fulani swept the north.",
                "Empires rose, and fell.",
                "Peoples mixed. Cultures",
                "melded under the sun."
            ),
            new BookPageInfo
            (
                "Then strangers came from",
                "distant lands, seeking",
                "slaves, palm oil, riches.",
                "Benin's Obas defied them.",
                "Igbo men and women were",
                "taken on ships, yet hope",
                "sailed with them still."
            ),
            new BookPageInfo
            (
                "1914, one nation forced",
                "from many tongues. Hope,",
                "struggle. In 1960, green",
                "and white flew for the",
                "first time. But peace was",
                "hard-won, and the Biafran",
                "war left scars and stories."
            ),
            new BookPageInfo
            (
                "Yet Nigerians endure:",
                "from Lagos markets to",
                "Kano's city walls, Port",
                "Harcourt's delta to Jos's",
                "plateau. The land of music,",
                "novelists, kings and rebels.",
                "A country forged in hope."
            ),
            new BookPageInfo
            (
                "May those who find this",
                "chest remember: From",
                "Oba's gold to Biafra's",
                "bread, every artifact is a",
                "chapter. The story is not",
                "over. Nigeria rises anew.",
                "",
                ""
            ),
            new BookPageInfo
            (
                "O Nigeria, giant of Africa,",
                "your treasures endure.",
                "",
                "- Olaudah",
                "",
                "",
                "",
                ""
            )
        );

        public override BookContent DefaultContent => Content;

        [Constructable]
        public BookOfNigerianHistory() : base(false)
        {
            Hue = 1282; // Lush green
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Book of Nigerian History");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Book of Nigerian History");
        }

        public BookOfNigerianHistory(Serial serial) : base(serial) { }

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
